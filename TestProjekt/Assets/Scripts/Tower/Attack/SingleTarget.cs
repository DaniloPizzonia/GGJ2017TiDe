using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class SingleTarget : AttackMode
	{

		[SerializeField]
		private float damage;
		[SerializeField]
		private float range = 0;

		protected override bool attack()
		{
			Bot nearest = Root.I.Get<BotManager>().AllBots.OrderBy( a => Vector3.Distance( a.transform.position , transform.position ) ).FirstOrDefault();

			if (
					null != nearest
				&&	range >= Vector3.Distance( nearest.transform.position , transform.position )
			)
			{
				transform.LookAt( nearest.transform );
				Shot( nearest , get_damage_effect( nearest , damage ) );
				return true;
			}

			return false;
		}


		protected virtual DamageEffect get_damage_effect( Bot target , float amount )
		{
			return new Damage( damage , target );
		}
	}
}