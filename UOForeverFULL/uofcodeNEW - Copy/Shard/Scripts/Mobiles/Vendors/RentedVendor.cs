#region References
using System;
using System.Collections.Generic;

using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Multis;
using Server.Prompts;
#endregion

namespace Server.Mobiles
{
	public class VendorRentalDuration
	{
		public static readonly VendorRentalDuration[] Instances = new[]
		{
			new VendorRentalDuration(TimeSpan.FromDays(7.0), 1062361), // 1 Week
			new VendorRentalDuration(TimeSpan.FromDays(14.0), 1062362), // 2 Weeks
			new VendorRentalDuration(TimeSpan.FromDays(21.0), 1062363), // 3 Weeks
			new VendorRentalDuration(TimeSpan.FromDays(28.0), 1062364) // 1 Month
		};

		private readonly TimeSpan m_Duration;
		private readonly int m_Name;

		public TimeSpan Duration { get { return m_Duration; } }
		public int Name { get { return m_Name; } }

		public int ID
		{
			get
			{
				for (int i = 0; i < Instances.Length; i++)
				{
					if (Instances[i] == this)
					{
						return i;
					}
				}

				return 0;
			}
		}

		private VendorRentalDuration(TimeSpan duration, int name)
		{
			m_Duration = duration;
			m_Name = name;
		}
	}

	public class RentedVendor : PlayerVendor
	{
		private Timer m_RentalExpireTimer;

		public RentedVendor(
			Mobile owner, BaseHouse house, VendorRentalDuration duration, int rentalPrice, bool landlordRenew, int rentalGold)
			: base(owner, house)
		{
			RentalDuration = duration;
			RentalPrice = RenewalPrice = rentalPrice;
			LandlordRenew = landlordRenew;
			RenterRenew = false;

			RentalCurrency = rentalGold;

			RentalExpireTime = DateTime.UtcNow + duration.Duration;
			m_RentalExpireTimer = new RentalExpireTimer(this, duration.Duration);
			m_RentalExpireTimer.Start();
		}

		public RentedVendor(Serial serial)
			: base(serial)
		{ }

		public VendorRentalDuration RentalDuration { get; private set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RentalPrice { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool LandlordRenew { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool RenterRenew { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Renew { get { return LandlordRenew && RenterRenew && House != null && House.DecayType != DecayType.Condemned; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RenewalPrice { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int RentalCurrency { get; set; }

		[CommandProperty(AccessLevel.GameMaster, true)]
		public DateTime RentalExpireTime { get; private set; }

		public override bool IsOwner(Mobile m)
		{
			return m == Owner || m.AccessLevel >= AccessLevel.GameMaster || AccountHandler.CheckAccount(m, Owner);
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Landlord
		{
			get
			{
				if (House != null)
				{
					return House.Owner;
				}

				return null;
			}
		}

		public bool IsLandlord(Mobile m)
		{
			return House != null && House.IsOwner(m);
		}

		public void ComputeRentalExpireDelay(out int days, out int hours)
		{
			TimeSpan delay = RentalExpireTime - DateTime.UtcNow;

			if (delay <= TimeSpan.Zero)
			{
				days = 0;
				hours = 0;
			}
			else
			{
				days = delay.Days;
				hours = delay.Hours;
			}
		}

		public void SendRentalExpireMessage(Mobile to)
		{
			int days, hours;
			ComputeRentalExpireDelay(out days, out hours);

			// The rental contract on this vendor will expire in ~1_DAY~ day(s) and ~2_HOUR~ hour(s).
			to.SendLocalizedMessage(1062464, days + "\t" + hours);
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			m_RentalExpireTimer.Stop();
		}

		public override void Destroy(bool toBackpack)
		{
			if (RentalCurrency > 0 && House != null && House.IsAosRules)
			{
				if (House.MovingCrate == null)
				{
					House.MovingCrate = new MovingCrate(House);
				}

				Banker.Deposit(House.MovingCrate, TypeOfCurrency, RentalCurrency);
				RentalCurrency = 0;
			}

			base.Destroy(toBackpack);
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			if (from.Alive)
			{
				if (IsOwner(from))
				{
					list.Add(new ContractOptionsEntry(this));
				}
				else if (IsLandlord(from))
				{
					if (RentalCurrency > 0)
					{
						list.Add(new CollectRentEntry(this));
					}

					list.Add(new TerminateContractEntry(this));
					list.Add(new ContractOptionsEntry(this));
				}
			}

			base.GetContextMenuEntries(from, list);
		}

		private class ContractOptionsEntry : ContextMenuEntry
		{
			private readonly RentedVendor m_Vendor;

			public ContractOptionsEntry(RentedVendor vendor)
				: base(6209)
			{
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				Mobile from = Owner.From;

				if (m_Vendor.Deleted || !from.CheckAlive())
				{
					return;
				}

				if (m_Vendor.IsOwner(from))
				{
					from.CloseGump(typeof(RenterVendorRentalGump));
					from.SendGump(new RenterVendorRentalGump(m_Vendor));

					m_Vendor.SendRentalExpireMessage(from);
				}
				else if (m_Vendor.IsLandlord(from))
				{
					from.CloseGump(typeof(LandlordVendorRentalGump));
					from.SendGump(new LandlordVendorRentalGump(m_Vendor));

					m_Vendor.SendRentalExpireMessage(from);
				}
			}
		}

		private class CollectRentEntry : ContextMenuEntry
		{
			private readonly RentedVendor m_Vendor;

			public CollectRentEntry(RentedVendor vendor)
				: base(6212)
			{
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				Mobile from = Owner.From;

				if (m_Vendor.Deleted || !from.CheckAlive() || !m_Vendor.IsLandlord(from))
				{
					return;
				}

				if (m_Vendor.RentalCurrency <= 0)
				{
					return;
				}

				int depositedCurrency = Banker.DepositUpTo(from, m_Vendor.TypeOfCurrency, m_Vendor.RentalCurrency);

				m_Vendor.RentalCurrency -= depositedCurrency;

				if (depositedCurrency > 0)
				{
					from.SendMessage(
						"{0:#,0} {1} has been deposited into your bank box.", depositedCurrency, m_Vendor.TypeOfCurrency.Name);
				}

				if (m_Vendor.RentalCurrency > 0)
				{
					from.SendLocalizedMessage(500390); // Your bank box is full.
				}
			}
		}

		private class TerminateContractEntry : ContextMenuEntry
		{
			private readonly RentedVendor m_Vendor;

			public TerminateContractEntry(RentedVendor vendor)
				: base(6218)
			{
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				Mobile from = Owner.From;

				if (m_Vendor.Deleted || !from.CheckAlive() || !m_Vendor.IsLandlord(from))
				{
					return;
				}

				from.SendMessage(
					"Enter the amount of {0} you wish to offer the renter in exchange for immediate termination of this contract?",
					m_Vendor.TypeOfCurrency.Name);

				from.Prompt = new RefundOfferPrompt(m_Vendor);
			}
		}

		private class RefundOfferPrompt : Prompt
		{
			private readonly RentedVendor m_Vendor;

			public RefundOfferPrompt(RentedVendor vendor)
			{
				m_Vendor = vendor;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (!m_Vendor.CanInteractWith(from, false) || !m_Vendor.IsLandlord(from))
				{
					return;
				}

				text = text.Trim();

				int amount;

				if (!int.TryParse(text, out amount))
				{
					amount = -1;
				}

				Mobile owner = m_Vendor.Owner;

				if (owner == null)
				{
					return;
				}

				if (amount < 0)
				{
					from.SendLocalizedMessage(1062506); // You did not enter a valid amount.  Offer canceled.
				}
				else if (Banker.GetBalance(from, m_Vendor.TypeOfCurrency) < amount)
				{
					from.SendLocalizedMessage(1062507); // You do not have that much money in your bank account.
				}
				else if (owner.Map != m_Vendor.Map || !owner.InRange(m_Vendor, 5))
				{
					from.SendLocalizedMessage(1062505); // The renter must be closer to the vendor in order for you to make this offer.
				}
				else
				{
					from.SendLocalizedMessage(1062504); // Please wait while the renter considers your offer.

					owner.CloseGump(typeof(VendorRentalRefundGump));
					owner.SendGump(new VendorRentalRefundGump(m_Vendor, from, amount));
				}
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(0); // version

			writer.WriteEncodedInt(RentalDuration.ID);

			writer.Write(RentalPrice);
			writer.Write(LandlordRenew);
			writer.Write(RenterRenew);
			writer.Write(RenewalPrice);

			writer.Write(RentalCurrency);

			writer.WriteDeltaTime(RentalExpireTime);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadEncodedInt();

			int durationID = reader.ReadEncodedInt();

			RentalDuration = durationID < VendorRentalDuration.Instances.Length
								 ? VendorRentalDuration.Instances[durationID]
								 : VendorRentalDuration.Instances[0];

			RentalPrice = reader.ReadInt();
			LandlordRenew = reader.ReadBool();
			RenterRenew = reader.ReadBool();
			RenewalPrice = reader.ReadInt();

			RentalCurrency = reader.ReadInt();

			RentalExpireTime = reader.ReadDeltaTime();

			TimeSpan delay = RentalExpireTime - DateTime.UtcNow;

			m_RentalExpireTimer = new RentalExpireTimer(this, delay > TimeSpan.Zero ? delay : TimeSpan.Zero);
			m_RentalExpireTimer.Start();
		}

		private class RentalExpireTimer : Timer
		{
			private readonly RentedVendor m_Vendor;

			public RentalExpireTimer(RentedVendor vendor, TimeSpan delay)
				: base(delay, vendor.RentalDuration.Duration)
			{
				m_Vendor = vendor;

				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				int renewalPrice = m_Vendor.RenewalPrice;

				if (m_Vendor.Renew && m_Vendor.HoldCurrency >= renewalPrice)
				{
					m_Vendor.HoldCurrency -= renewalPrice;
					m_Vendor.RentalCurrency += renewalPrice;

					m_Vendor.RentalPrice = renewalPrice;

					m_Vendor.RentalExpireTime = DateTime.UtcNow + m_Vendor.RentalDuration.Duration;
				}
				else
				{
					m_Vendor.Destroy(true);
				}
			}
		}
	}
}