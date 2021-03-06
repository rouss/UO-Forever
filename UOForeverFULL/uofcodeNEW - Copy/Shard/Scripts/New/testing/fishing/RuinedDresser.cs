using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0xC24, 0xBCB )]
	public class RuinedDresser : Item
	{

		[Constructable]
		public RuinedDresser() : base( 0xC24 )
		{
			Weight = 1.0;
			Stackable = false;
			Name = "Ruined Dresser";
		}

		public RuinedDresser( Serial serial ) : base( serial )
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

