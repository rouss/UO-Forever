using System;
using Server;

namespace Server.Items
{
	public class BedOfNailsEast : BaseAddon
	{
		public override BaseAddonDeed Deed{ get{ return new BedOfNailsEastDeed(); } }
		public override bool RetainDeedHue{ get{ return true; } }

		[Constructable]
		public BedOfNailsEast()
		{
			AddComponent( new AddonComponent( 10888 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 10887 ), 0, 1, 0 );
		}

		public BedOfNailsEast( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public class BedOfNailsEastDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new BedOfNailsEast(); } }

		[Constructable]
		public BedOfNailsEastDeed()
		{
			Name = "deed for a bed of nails (east)";
		}

		public BedOfNailsEastDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}