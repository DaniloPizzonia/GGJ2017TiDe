using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class Slower : RangeDamageAttackMode
	{
		protected override float cooldown_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().SlowTowerCooldown;
			}
		}

		protected override float damage_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().SlowTowerDamage;
			}
		}

		protected override float range_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().SlowTowerRange;
			}
		}

		protected override bool attack()
		{
			Bot[] bot_list = get_target_list();

			foreach ( Bot target in bot_list)
			{
				Shot( target , new Speed( Damage , target ) );
			}

			return bot_list.Length > 0;
		}

		protected virtual Bot[] get_target_list()
		{
			return Root.I.Get<BotManager>().AllBots.Where( a => Vector3.Distance( transform.position , a.transform.position ) <= Range ).ToArray();
		}
	}
}