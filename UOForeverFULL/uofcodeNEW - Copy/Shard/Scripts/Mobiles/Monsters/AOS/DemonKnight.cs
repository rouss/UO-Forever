#region References
using System;
using System.Collections.Generic;

using Server.Items;
#endregion

namespace Server.Mobiles
{
	[CorpseName("a demon knight corpse")]
	public class DemonKnight : BaseCreature
	{
		public override bool IgnoreYoungProtection { get { return EraML; } }

		

		

		public static Mobile FindRandomPlayer(BaseCreature creature)
		{
			List<DamageStore> rights = GetLootingRights(creature.DamageEntries, creature.HitsMax);

			for (int i = rights.Count - 1; i >= 0; --i)
			{
				DamageStore ds = rights[i];

				if (!ds.m_HasRight)
				{
					rights.RemoveAt(i);
				}
			}

			if (rights.Count > 0)
			{
				return rights[Utility.Random(rights.Count)].m_Mobile;
			}

			return null;
		}

		public override WeaponAbility GetWeaponAbility()
		{
			switch (Utility.Random(3))
			{
				default:
					//case 0:
					return WeaponAbility.DoubleStrike;
				case 1:
					return WeaponAbility.WhirlwindAttack;
				case 2:
					return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public DemonKnight()
			: base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = NameList.RandomName("demon knight");
			Title = "the Dark Father";
			Body = 318;
			BaseSoundID = 0x165;

            Alignment = Alignment.Demon;

			SetStr(500);
			SetDex(100);
			SetInt(1000);

			SetHits(30000);
			SetMana(5000);

			SetDamage(17, 21);

			SetSkill(SkillName.Necromancy, 120, 120.0);
			SetSkill(SkillName.SpiritSpeak, 120.0, 120.0);

			SetSkill(SkillName.DetectHidden, 80.0);
			SetSkill(SkillName.EvalInt, 100.0);
			SetSkill(SkillName.Magery, 140.0);
			SetSkill(SkillName.Meditation, 120.0);
			SetSkill(SkillName.MagicResist, 150.0);
			SetSkill(SkillName.Tactics, 100.0);
			SetSkill(SkillName.Wrestling, 120.0);

			Fame = 28000;
			Karma = -28000;

			VirtualArmor = 64;
		}

        public override void OnDeath(Container c)
        {
            var scroll = new SkillScroll();
            scroll.Randomize();
            c.DropItem(scroll);

            scroll = new SkillScroll();
            scroll.Randomize();
            c.DropItem(scroll);

            scroll = new SkillScroll();
            scroll.Randomize();
            c.DropItem(scroll);

            scroll = new SkillScroll();
            scroll.Randomize();
            c.DropItem(scroll);

            base.OnDeath(c);
        }

		public override void GenerateLoot()
		{
			AddLoot(LootPack.SuperBoss, 2);
			AddLoot(LootPack.HighScrolls, Utility.RandomMinMax(6, 60));
		}

		public override bool BardImmune { get { return true; } }
		public override bool Unprovokable { get { return true; } }
		public override bool AreaPeaceImmune { get { return EraSE; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public override int TreasureMapLevel { get { return 1; } }
		public override bool AlwaysMurderer { get { return true; } }

		private static bool m_InHere;

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			if (from == null || from == this || m_InHere)
			{
				return;
			}

			m_InHere = true;

			from.Damage(Utility.RandomMinMax(8, 20), this);

			MovingEffect(from, 0xECA, 10, 0, false, false, 0, 0);
			PlaySound(0x491);

			if (0.05 > Utility.RandomDouble())
			{
				Timer.DelayCall(TimeSpan.FromSeconds(1.0), CreateBones_Callback, from);
			}

			m_InHere = false;
		}

		public virtual void CreateBones_Callback(Mobile from)
		{
			Map map = from.Map;

			if (map == null)
			{
				return;
			}

			int count = Utility.RandomMinMax(1, 3);

			for (int i = 0; i < count; ++i)
			{
				int x = from.X + Utility.RandomMinMax(-1, 1);
				int y = from.Y + Utility.RandomMinMax(-1, 1);
				int z = from.Z;

				if (!map.CanFit(x, y, z, 16, false, true))
				{
					z = map.GetAverageZ(x, y);

					if (z == from.Z || !map.CanFit(x, y, z, 16, false, true))
					{
						continue;
					}
				}

				var bone = new UnholyBone
				{
					Hue = 0,
					Name = "unholy bones",
					ItemID = Utility.Random(0xECA, 9)
				};

				bone.MoveToWorld(new Point3D(x, y, z), map);
			}
		}

		public DemonKnight(Serial serial)
			: base(serial)
		{ }

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			reader.ReadInt();
		}
	}
}