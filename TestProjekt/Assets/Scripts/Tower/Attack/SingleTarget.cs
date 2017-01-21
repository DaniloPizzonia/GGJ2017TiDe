using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public class SingleTarget : AOE
	{
		protected override Bot[] get_target_list()
		{
			Bot bot = base.get_target_list().ElementAtOrDefault( 0 );
			if ( null != bot )
			{
				transform.LookAt( bot.transform );
				return new Bot[] { bot };
			}
			return new Bot[ 0 ];
		}
	}
}