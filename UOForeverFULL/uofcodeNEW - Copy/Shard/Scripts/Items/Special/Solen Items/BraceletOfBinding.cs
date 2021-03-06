#region References
using System;
using System.Collections.Generic;

using Server.ContextMenus;
using Server.Factions;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Spells;
using Server.Targeting;
#endregion

namespace Server.Items
{
	public class BraceletOfBinding : BaseBracelet, ITranslocationItem
	{
		private int m_Charges;
		private int m_Recharges;
		private string m_Inscription;
		private BraceletOfBinding m_Bound;
		private TransportTimer m_Timer;

		[CommandProperty(AccessLevel.GameMaster)]
		public int Charges
		{
			get { return m_Charges; }
			set
			{
				if (value > MaxCharges)
				{
					m_Charges = MaxCharges;
				}
				else if (value < 0)
				{
					m_Charges = 0;
				}
				else
				{
					m_Charges = value;
				}

				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int Recharges
		{
			get { return m_Recharges; }
			set
			{
				if (value > MaxRecharges)
				{
					m_Recharges = MaxRecharges;
				}
				else if (value < 0)
				{
					m_Recharges = 0;
				}
				else
				{
					m_Recharges = value;
				}

				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxCharges { get { return 20; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxRecharges { get { return 255; } }

		public string TranslocationItemName { get { return "bracelet of binding"; } }

		[CommandProperty(AccessLevel.GameMaster)]
		public string Inscription
		{
			get { return m_Inscription; }
			set
			{
				m_Inscription = value;
				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public BraceletOfBinding Bound
		{
			get
			{
				if (m_Bound != null && m_Bound.Deleted)
				{
					m_Bound = null;
				}

				return m_Bound;
			}
			set { m_Bound = value; }
		}

		[Constructable]
		public BraceletOfBinding()
			: base(0x1086)
		{
			Hue = 0x489;
			Weight = 1.0;

			m_Inscription = "";
		}

		public override void AddNameProperty(ObjectPropertyList list)
		{
			// a bracelet of binding : ~1_val~ ~2_val~
			list.Add(1054000, m_Charges + (m_Inscription.Length == 0 ? "\t " : " :\t" + m_Inscription));
		}

		public override void OnSingleClick(Mobile from)
		{
			LabelToExpansion(from);

			// a bracelet of binding : ~1_val~ ~2_val~
			LabelTo(from, 1054000, m_Charges + (m_Inscription.Length == 0 ? "\t " : " :\t" + m_Inscription));
		}

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			base.GetContextMenuEntries(from, list);

			if (from.Alive && IsChildOf(from))
			{
				BraceletOfBinding bound = Bound;

				list.Add(new BraceletEntry(Activate, 6170, bound != null));
				list.Add(new BraceletEntry(Search, 6171, bound != null));
				list.Add(new BraceletEntry(Bind, bound == null ? 6173 : 6174, true));
				list.Add(new BraceletEntry(Inscribe, 6175, true));
			}
		}

		private delegate void BraceletCallback(Mobile from);

		private class BraceletEntry : ContextMenuEntry
		{
			private readonly BraceletCallback m_Callback;

			public BraceletEntry(BraceletCallback callback, int number, bool enabled)
				: base(number)
			{
				m_Callback = callback;

				if (!enabled)
				{
					Flags |= CMEFlags.Disabled;
				}
			}

			public override void OnClick()
			{
				Mobile from = Owner.From;

				if (from.CheckAlive())
				{
					m_Callback(from);
				}
			}
		}

		public override void OnDoubleClick(Mobile from)
		{
			BraceletOfBinding bound = Bound;

			if (bound == null)
			{
				Bind(from);
			}
			else
			{
				Activate(from);
			}
		}

		public void Activate(Mobile from)
		{
			BraceletOfBinding bound = Bound;

			if (Deleted || bound == null)
			{
				return;
			}

			if (!IsChildOf(from))
			{
// You must have the object in your backpack to use it.
				from.SendLocalizedMessage(1042664); 
			}
			else if (m_Timer != null)
			{
// The bracelet is already attempting contact. You decide to wait a moment.
				from.SendLocalizedMessage(1054013); 
			}
			else
			{
				from.PlaySound(0xF9);
				from.LocalOverheadMessage(
					MessageType.Regular, 0x5D, true, "* You concentrate on the bracelet to summon its power *");

				from.Frozen = true;

				m_Timer = new TransportTimer(this, from);
				m_Timer.Start();
			}
		}

		private class TransportTimer : Timer
		{
			private readonly BraceletOfBinding m_Bracelet;
			private readonly Mobile m_From;

			public TransportTimer(BraceletOfBinding bracelet, Mobile from)
				: base(TimeSpan.FromSeconds(2.0))
			{
				m_Bracelet = bracelet;
				m_From = from;
			}

			protected override void OnTick()
			{
				m_Bracelet.m_Timer = null;
				m_From.Frozen = false;

				if (m_Bracelet.Deleted || m_From.Deleted)
				{
					return;
				}

				if (m_Bracelet.CheckUse(m_From, false))
				{
					var boundRoot = m_Bracelet.Bound.RootParent as Mobile;

					if (boundRoot != null)
					{
						m_Bracelet.Charges--;

						BaseCreature.TeleportPets(m_From, boundRoot.Location, boundRoot.Map, true);

						m_From.PlaySound(0x1FC);
						m_From.MoveToWorld(boundRoot.Location, boundRoot.Map);
						m_From.PlaySound(0x1FC);
					}
				}
			}
		}

		public void Search(Mobile from)
		{
			BraceletOfBinding bound = Bound;

			if (Deleted || bound == null)
			{
				return;
			}

			if (!IsChildOf(from))
			{
// You must have the object in your backpack to use it.
				from.SendLocalizedMessage(1042664); 
			}
			else
			{
				CheckUse(from, true);
			}
		}

		private bool CheckUse(Mobile from, bool successMessage)
		{
			BraceletOfBinding bound = Bound;

			if (bound == null)
			{
				return false;
			}

			var boundRoot = bound.RootParent as Mobile;

			if (Charges == 0)
			{
				// The bracelet glows black. It must be charged before it can be used again.
				from.SendLocalizedMessage(1054005);
				return false;
			}

			if (from.FindItemOnLayer(Layer.Bracelet) != this)
			{
				// You must equip the bracelet in order to use its power.
				from.SendLocalizedMessage(1054004);
				return false;
			}

			if (boundRoot == null || boundRoot.NetState == null || boundRoot.FindItemOnLayer(Layer.Bracelet) != bound)
			{
				// The bracelet emits a red glow. The bracelet's twin is not available for transport.
				from.SendLocalizedMessage(1054006);
				return false;
			}

			if (!EraAOS && from.Map != boundRoot.Map)
			{
				// The bracelet glows black. The bracelet's target is on another facet.
				from.SendLocalizedMessage(1054014);
				return false;
			}

			if (Sigil.ExistsOn(from))
			{
				// You can't do that while carrying the sigil.
				from.SendLocalizedMessage(1061632);
				return false;
			}

			if (!SpellHelper.CheckTravel(from, TravelCheckType.RecallFrom))
			{
				return false;
			}

			if (!SpellHelper.CheckTravel(from, boundRoot.Map, boundRoot.Location, TravelCheckType.RecallTo))
			{
				return false;
			}

			if (boundRoot.Map == Map.Felucca && from is PlayerMobile && ((PlayerMobile)from).Young)
			{
				// You decide against traveling to Felucca while you are still young.
				from.SendLocalizedMessage(1049543);
				return false;
			}

			if (from.Kills >= Mobile.MurderCount && boundRoot.Map != Map.Felucca)
			{
				// You are not allowed to travel there.
				from.SendLocalizedMessage(1019004);
				return false;
			}

			if (from.Criminal)
			{
				// Thou'rt a criminal and cannot escape so easily.
				from.SendLocalizedMessage(1005561, "", 0x22);
				return false;
			}

			if (SpellHelper.CheckCombat(from))
			{
				// Wouldst thou flee during the heat of battle??
				from.SendLocalizedMessage(1005564, "", 0x22);
				return false;
			}

			if (WeightOverloading.IsOverloaded(from))
			{
				// Thou art too encumbered to move.
				from.SendLocalizedMessage(502359, "", 0x22);
				return false;
			}

			if (from.Region.IsPartOf(typeof(Jail)))
			{
				// You'll need a better jailbreak plan than that!
				from.SendLocalizedMessage(1114345, "", 0x35);
				return false;
			}

			if (boundRoot.Region.IsPartOf(typeof(Jail)))
			{
				// You are not allowed to travel there.
				from.SendLocalizedMessage(1019004);
				return false;
			}

			if (successMessage)
			{
				// The bracelet's twin is available for transport.
				from.SendLocalizedMessage(1054015);
			}

			return true;
		}

		public void Bind(Mobile from)
		{
			if (Deleted)
			{
				return;
			}

			if (!IsChildOf(from))
			{
// You must have the object in your backpack to use it.
				from.SendLocalizedMessage(1042664); 
			}
			else
			{
// Target the bracelet of binding you wish to bind this bracelet to.
				from.SendLocalizedMessage(1054001); 
				from.Target = new BindTarget(this);
			}
		}

		private class BindTarget : Target
		{
			private readonly BraceletOfBinding m_Bracelet;

			public BindTarget(BraceletOfBinding bracelet)
				: base(-1, false, TargetFlags.None)
			{
				m_Bracelet = bracelet;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (m_Bracelet.Deleted)
				{
					return;
				}

				if (!m_Bracelet.IsChildOf(from))
				{
// You must have the object in your backpack to use it.
					from.SendLocalizedMessage(1042664); 
				}
				else if (targeted is BraceletOfBinding)
				{
					var bindBracelet = (BraceletOfBinding)targeted;

					if (bindBracelet == m_Bracelet)
					{
// You cannot bind a bracelet of binding to itself!
						from.SendLocalizedMessage(1054012); 
					}
					else if (!bindBracelet.IsChildOf(from))
					{
// You must have the object in your backpack to use it.
						from.SendLocalizedMessage(1042664); 
					}
					else
					{
// You bind the bracelet to its counterpart. The bracelets glow with power.
						from.SendLocalizedMessage(1054003); 
						from.PlaySound(0x1FA);

						m_Bracelet.Bound = bindBracelet;
					}
				}
				else
				{
// You can only bind this bracelet to another bracelet of binding!
					from.SendLocalizedMessage(1054002); 
				}
			}
		}

		public void Inscribe(Mobile from)
		{
			if (Deleted)
			{
				return;
			}

			if (!IsChildOf(from))
			{
// You must have the object in your backpack to use it.
				from.SendLocalizedMessage(1042664); 
			}
			else
			{
// Enter the text to inscribe upon the bracelet :
				from.SendLocalizedMessage(1054009); 
				from.Prompt = new InscribePrompt(this);
			}
		}

		private class InscribePrompt : Prompt
		{
			private readonly BraceletOfBinding m_Bracelet;

			public InscribePrompt(BraceletOfBinding bracelet)
			{
				m_Bracelet = bracelet;
			}

			public override void OnResponse(Mobile from, string text)
			{
				if (m_Bracelet.Deleted)
				{
					return;
				}

				if (!m_Bracelet.IsChildOf(from))
				{
// You must have the object in your backpack to use it.
					from.SendLocalizedMessage(1042664); 
				}
				else
				{
// You mark the bracelet with your inscription.
					from.SendLocalizedMessage(1054011); 
					m_Bracelet.Inscription = text;
				}
			}

			public override void OnCancel(Mobile from)
			{
 // You decide not to inscribe the bracelet at this time.
				from.SendLocalizedMessage(1054010);
			}
		}

		public BraceletOfBinding(Serial serial)
			: base(serial)
		{ }

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.WriteEncodedInt(1); // version

			writer.WriteEncodedInt(m_Recharges);

			writer.WriteEncodedInt(m_Charges);
			writer.Write(m_Inscription);
			writer.Write(Bound);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadEncodedInt();

			switch (version)
			{
				case 1:
						m_Recharges = reader.ReadEncodedInt();
						goto case 0;
				case 0:
					{
						m_Charges = Math.Min(reader.ReadEncodedInt(), MaxCharges);
						m_Inscription = reader.ReadString();
						Bound = (BraceletOfBinding)reader.ReadItem();
					}
						break;
			}
		}
	}
}