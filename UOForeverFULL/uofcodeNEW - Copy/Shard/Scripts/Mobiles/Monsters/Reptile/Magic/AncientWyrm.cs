#region References

using Server.Engines.Craft;
using Server.Items;

#endregion

namespace Server.Mobiles
{
    [CorpseName("a wyrm corpse")]
    public class AncientWyrm : BaseCreature
    {
        public override string DefaultName { get { return "an ancient wyrm"; } }

        [Constructable]
        public AncientWyrm() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Body = 46;
            BaseSoundID = 362;

            Alignment = Alignment.Dragon;

            SetStr(1096, 1185);
            SetDex(86, 175);
            SetInt(686, 775);

            SetHits(658, 711);

            SetDamage(29, 35);


            SetSkill(SkillName.EvalInt, 80.1, 100.0);
            SetSkill(SkillName.Magery, 80.1, 100.0);
            SetSkill(SkillName.Meditation, 52.5, 75.0);
            SetSkill(SkillName.MagicResist, 100.5, 150.0);
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

            if (0.08 > Utility.RandomDouble()) // 2 percent - multipy number x 100 to get percent
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
                PackBagofRegs(Utility.RandomMinMax(30, 50));
            }
        }

        public override bool OnBeforeDeath()
        {
            switch (Utility.Random(500))
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

        public override int GetIdleSound()
        {
            return 0x2D3;
        }

        public override int GetHurtSound()
        {
            return 0x2D1;
        }

        public override bool ReacquireOnMovement { get { return true; } }
        public override bool HasBreath { get { return true; } } // fire breath enabled
        public override bool AutoDispel { get { return true; } }
        public override HideType HideType { get { return HideType.Barbed; } }
        public override int Hides { get { return 40; } }
        public override int Meat { get { return 19; } }
        public override int Scales { get { return 12; } }
        public override ScaleType ScaleType { get { return (ScaleType) Utility.Random(4); } }
        public override Poison PoisonImmune { get { return Poison.Regular; } }
        public override Poison HitPoison { get { return Utility.RandomBool() ? Poison.Lesser : Poison.Regular; } }
        public override int TreasureMapLevel { get { return 5; } }
        public override int DefaultBloodHue { get { return -2; } }
        public override int BloodHueTemplate { get { return Utility.RandomGreyHue(); } }

        public AncientWyrm(Serial serial)
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