using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class SingleTarget : RangeDamageAttackMode
	{
		protected override float cooldown_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().RangetowerCooldown;
			}
		}

		protected override float damage_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().RangetowerDamage;
			}
		}

		protected override float range_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().RangetowerRange;
			}
		}


		protected override bool attack()
		{
			Bot nearest = Root.I.Get<BotManager>().AllBots.OrderBy( a => Vector3.Distance( a.transform.position , transform.position ) ).FirstOrDefault();

			if (
					null != nearest
				&&	Range >= Vector3.Distance( nearest.transform.position , transform.position )
			)
			{
				Vector3 target_position = nearest.transform.position;
				target_position.y = transform.position.y;
				transform.LookAt( target_position );
				Shot( nearest , get_damage_effect( nearest , Damage ) );
				return true;
			}

			return false;
		}


		protected virtual DamageEffect get_damage_effect( Bot target , float amount )
		{
			return new Damage( Damage , target );
		}
	}
}