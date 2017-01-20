using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class Slower : AttackMode
	{
		[SerializeField]
		private float amount;

		protected override bool attack()
		{
			Bot nearest = Root.I.Get<BotManager>().AllBots.OrderBy( a => Vector3.Distance( a.transform.position , transform.position ) ).FirstOrDefault();

			if ( null != nearest )
			{
				Shot( nearest , new Speed( amount , nearest ) );
				return true;
			}

			return false;
		}
	}
}