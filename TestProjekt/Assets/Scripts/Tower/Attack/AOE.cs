using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class AOE : AttackMode
	{
		[SerializeField]
		private float damage;
		[SerializeField]
		private float range = 0;

		protected override bool attack()
		{
			Bot[] bot_list = get_target_list();

			foreach ( Bot target in bot_list)
			{
				Shot( target , new Damage( damage , target ) );
			}

			return bot_list.Length > 0;
		}

		protected virtual Bot[] get_target_list()
		{
			return Root.I.Get<BotManager>().AllBots.Where( a => Vector3.Distance( transform.position , a.transform.position ) <= range ).ToArray();
		}
	}
}