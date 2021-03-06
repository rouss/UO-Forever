using System;

namespace Server.Engines.Harvest
{
	public class HarvestResource
	{
		public Type[] Types { get; set; }

		public double ReqSkill { get; set; }
		public double MinSkill { get; set; }
		public double MaxSkill { get; set; }

		public Expansion ReqExpansion { get; set; }

		public object SuccessMessage { get; private set; }

		public void SendSuccessTo( Mobile m )
		{
			if ( SuccessMessage is int )
				m.SendLocalizedMessage( (int)SuccessMessage );
			else if ( SuccessMessage is string )
				m.SendMessage( (string)SuccessMessage );
		}

		public HarvestResource( Expansion reqExpansion, double reqSkill, double minSkill, double maxSkill, object message, params Type[] types )
		{
			ReqExpansion = reqExpansion;
			ReqSkill = reqSkill;
			MinSkill = minSkill;
			MaxSkill = maxSkill;
			Types = types;
			SuccessMessage = message;
		}
	}
}