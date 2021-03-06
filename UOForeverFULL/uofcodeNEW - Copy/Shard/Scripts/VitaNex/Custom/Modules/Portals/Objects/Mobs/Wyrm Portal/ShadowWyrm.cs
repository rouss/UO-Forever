#region References

using Server.Engines.Craft;
using Server.Items;

#endregion

namespace Server.Mobiles
{
    [CorpseName("a shadow wyrm corpse")]
    public class ShadowWyrmPortal : BaseCreature
    {
        public override string DefaultName { get { return "a shadow wyrm"; } }

        [Constructable]
        public ShadowWyrmPortal() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Body = 106;
            BaseSoundID = 362;

            Alignment = Alignment.Dragon;

            SetStr(898, 1030);
            SetDex(68, 200);
            SetInt(488, 620);

            SetHits(558, 599);

            SetDamage(29, 35);


            SetSkill(SkillName.EvalInt, 80.1, 100.0);
            SetSkill(SkillName.Magery, 80.1, 100.0);
            SetSkill(SkillName.Meditation, 52.5, 75.0);
            SetSkill(SkillName.MagicResist, 100.3, 130.0);
            SetSkill(SkillName.Tactics, 97.6, 100.0);
            SetSkill(SkillName.Wrestling, 97.6, 100.0);

            Fame = 22500;
            Karma = -22500;

            VirtualArmor = 70;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.FilthyRich, 3);
            AddLoot(LootPack.Gems, 5);

            if (0.04 > Utility.RandomDouble()) // 2 percent - multipy number x 100 to get percent
            {
                var scroll = new SkillScroll();
                scroll.Randomize();
                PackItem(scroll);
            }
        }

        public override void GenerateLoot(bool spawning)
        {
            base.GenerateLoot(spawning);

            if (!spawning)
            {
                PackBagofRegs(Utility.RandomMinMax(25, 40));
            }
        }

        public override int GetIdleSound()
        {
            return 0x2D5;
        }

        public override int GetHurtSound()
        {
            return 0x2D1;
        }

        public override bool OnBeforeDeath()
        {
            switch (Utility.Random(1000))
            {
                case 0:
                    PackItem(new LeatherDyeTub());
                    break;
                case 1:
                    PackItem(new DragonHead());
                    break;
            }

            if (0.05 > Utility.RandomDouble())
            {
                PackItem(new DragonBoneShards());
            }
            if (0.001 > Utility.RandomDouble())
            {
                PackItem(new DragonHeart());
            }
            return base.OnBeforeDeath();
        }

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            c.DropItem(new Platinum { Amount = 25 });
            c.DropItem(new GargoyleRune());
            if (Utility.RandomDouble() < 0.5)
            {
                c.DropItem(new GargoyleRune());
            }
            if (Utility.RandomDouble() < 0.1)
            {
                c.DropItem(new GargoyleRune());
            }
        }

        public override bool ReacquireOnMovement { get { return true; } }
        public override bool HasBreath { get { return true; } } // fire breath enabled
        public override bool AutoDispel { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Deadly; } }
        public override Poison HitPoison { get { return Poison.Deadly; } }
        public override int TreasureMapLevel { get { return 5; } }

        public override bool BardImmune
        {
            get { return true; }
        }

        public override int Meat { get { return 19; } }
        public override int Hides { get { return 20; } }
        public override int Scales { get { return 10; } }
        public override ScaleType ScaleType { get { return ScaleType.Black; } }
        public override HideType HideType { get { return HideType.Barbed; } }

        public ShadowWyrmPortal(Serial serial)
            : base(serial)
        {}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}