using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public abstract class DamageEffect
	{
		private bool is_applyed = false;
		private Bot target;
		
		public DamageEffect( Bot bot )
		{
			target = bot;
		}

		public bool Apply()
		{ 
			if ( !is_applyed )
			{
				return false;
			}

			apply( target );
			is_applyed = true;
			return true;
		}

		protected abstract void apply( Bot bot );
	}
}