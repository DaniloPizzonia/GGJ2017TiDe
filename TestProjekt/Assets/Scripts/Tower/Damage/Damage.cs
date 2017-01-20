using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public class Damage : DamageEffect
	{
		private float internal_value;

		protected virtual float value
		{
			get
			{
				return internal_value;
			}
		}
		
		public Damage( float value )
		{
			internal_value = value;
		}

		public override bool Apply( Bot bot )
		{
			bot.Health -= internal_value;
			return true;
		}
	}
}