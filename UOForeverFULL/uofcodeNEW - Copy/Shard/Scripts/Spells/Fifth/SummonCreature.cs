#region References
using System;

using Server.Mobiles;
#endregion

namespace Server.Spells.Fifth
{
	public class SummonCreatureSpell : MagerySpell
	{
		private static readonly SpellInfo m_Info = new SpellInfo(
			"Summon Creature", "Kal Xen", 16, false, Reagent.Bloodmoss, Reagent.MandrakeRoot, Reagent.SpidersSilk);

		public override SpellCircle Circle { get { return SpellCircle.Fifth; } }

		public SummonCreatureSpell(Mobile caster, Item scroll)
			: base(caster, scroll, m_Info)
		{ }

		// NOTE: Creature list based on 1hr of summon/release on OSI.

		private static readonly Type[] m_Types = new[]
		{
			typeof(PolarBear), typeof(GrizzlyBear), typeof(BlackBear), typeof(Horse), typeof(Walrus), typeof(Chicken),
			typeof(Scorpion), typeof(GiantSerpent), typeof(Llama), typeof(Alligator), typeof(GreyWolf), typeof(Slime),
			typeof(Eagle), typeof(Gorilla), typeof(SnowLeopard), typeof(Pig), typeof(Hind), typeof(Rabbit)
		};

		public override bool CheckCast()
		{
			if (!base.CheckCast())
			{
				return false;
			}

			if ((Caster.Followers + 2) > Caster.FollowersMax)
			{
				Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if (CheckSequence())
			{
				try
				{
					var creature = (BaseCreature)Activator.CreateInstance(m_Types[Utility.Random(m_Types.Length)]);

					//creature.ControlSlots = 2;

					TimeSpan duration = TimeSpan.Zero;

					if (Caster.EraAOS)
					{
						duration = TimeSpan.FromSeconds((2 * Caster.Skills.Magery.Fixed) / 5);
					}
					else if (Caster.EraUOR)
					{
						duration = TimeSpan.FromSeconds(4.0 * Caster.Skills[SkillName.Magery].Value);
					}
					else if (Caster.EraT2A)
					{
						duration = TimeSpan.FromSeconds(4.0 * Caster.Skills[SkillName.Magery].Value);
					}

					SpellHelper.Summon(creature, Caster, 0x215, duration, false, false);
				}
				catch
				{ }
			}

			FinishSequence();
		}

		public override TimeSpan GetCastDelay()
		{
			if (Caster != null && Caster.EraAOS)
			{
				return TimeSpan.FromTicks(base.GetCastDelay().Ticks * 5);
			}

			return base.GetCastDelay() + TimeSpan.FromSeconds(6.0);
		}
	}
}