using System;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x13B2, 0x13B1 )]
	public class JukaBow : Bow
	{
		public override int OldStrengthReq{ get{ return 80; } }
		public override int OldDexterityReq{ get{ return 80; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsModified
		{
			get{ return Hue >= 1102 && Hue <= 1109; }
		}

		public override string DefaultName{ get{ return IsModified ? "Juka Bow" : null; } }

		[Constructable]
		public JukaBow()
		{
			Hue = Utility.Random( 1110, 8 );
			Identified = true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsModified )
				from.SendMessage( "That has already been modified." );
			else if ( !IsChildOf( from.Backpack ) )
				from.SendMessage( "This must be in your backpack to modify it." );
			else if ( from.Skills[SkillName.Fletching].Base < 100.0 )
				from.SendMessage( "Only a grandmaster bowcrafter can modify this weapon." );
			else
			{
				from.BeginTarget( 2, false, Targeting.TargetFlags.None, new TargetCallback( OnTargetGears ) );
				from.SendLocalizedMessage( 1010614 ); // Which set of gears will you use?
			}
		}

		public void OnTargetGears( Mobile from, object targ )
		{
			Gears g = targ as Gears;

			if ( g == null || !g.IsChildOf( from.Backpack ) )
				from.SendMessage( "Those are not gears." ); // Apparently gears that aren't in your backpack aren't really gears at all. :-(
			else if ( IsModified )
				from.SendMessage( "That has already been modified." );
			else if ( !IsChildOf( from.Backpack ) )
				from.SendMessage( "This must be in your backpack to modify it." );
			else if ( from.Skills[SkillName.Fletching].Base < 100.0 )
				from.SendMessage( "Only a grandmaster bowcrafter can modify this weapon." );
			else
			{
				g.Consume();

				Hue = Utility.Random( 1102, 8 );
				Slayer = (SlayerName)Utility.Random( 2, 25 );

				from.SendMessage( "You modify it." );
			}
		}

		public JukaBow( Serial serial ) : base( serial )
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

			Identified = true;
			if ( Hue == 0 )
				Hue = Utility.Random( 1102, 8 );
		}
	}
}