using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class SummonedAirElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }
		public override string DefaultName{ get{ return "an air elemental"; } }

		[Constructable]
		public SummonedAirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr( 200 );
			SetDex( 200 );
			SetInt( 100 );

			SetHits( 150 );
			SetStam( 50 );

			SetDamage( 6, 9 );

			
			

			
			
			
			
			

			SetSkill( SkillName.Meditation, 90.0 );
			SetSkill( SkillName.EvalInt, 70.0 );
			SetSkill( SkillName.Magery, 70.0 );
			SetSkill( SkillName.MagicResist, 60.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 80.0 );

			VirtualArmor = 40;
			ControlSlots = 2;
		}

		public override int DefaultBloodHue{ get{ return -1; } }

		public SummonedAirElemental( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 655;
		}
	}
}