using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a solen worker corpse" )]
	public class BlackSolenWorker : BaseCreature, IBlackSolen
	{
		public override string DefaultName{ get{ return "a black solen worker"; } }

		[Constructable]
		public BlackSolenWorker() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Body = 805;
			BaseSoundID = 959;
			Hue = 0x453;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );

			SetDamage( 5, 7 );

			

			
			
			
			
			

			SetSkill( SkillName.MagicResist, 60.0 );
			SetSkill( SkillName.Tactics, 65.0 );
			SetSkill( SkillName.Wrestling, 60.0 );

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;

			PackGold( Utility.Random( 100, 180 ) );

			SolenHelper.PackPicnicBasket( this );

			PackItem( new ZoogiFungus() );
		}

		public override int GetAngerSound()
		{
			return 0x269;
		}

		public override int GetIdleSound()
		{
			return 0x269;
		}

		public override int GetAttackSound()
		{
			return 0x186;
		}

		public override int GetHurtSound()
		{
			return 0x1BE;
		}

		public override int GetDeathSound()
		{
			return 0x8E;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, Utility.RandomMinMax( 1, 2 ) );
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( SolenHelper.CheckBlackFriendship( m ) )
				return false;
			else
				return base.IsEnemy( m );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			SolenHelper.OnBlackDamage( from );

			base.OnDamage( amount, from, willKill );
		}

		public override int DefaultBloodHue{ get{ return -2; } }
		public override int BloodHueTemplate{ get{ return Utility.RandomGreenHue(); } }

		public BlackSolenWorker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}