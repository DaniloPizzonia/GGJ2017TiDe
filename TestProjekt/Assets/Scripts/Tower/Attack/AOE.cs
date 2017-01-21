using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class AOE : SingleTarget
	{
		private float damage_range;

		protected override float cooldown_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().AOECooldown;
			}
		}

		protected override float damage_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().AOEDamage;
			}
		}

		protected override float range_factor
		{
			get
			{
				return Root.I.Get<GameConfig>().AOERange;
			}
		}

		public override void Bind( Tower tower )
		{
			base.Bind( tower );

			tower.OnUpgrade.AddListener( ( UpgradeProperty property , int lvl , float factor ) =>
			{
				switch ( property )
				{
					case UpgradeProperty.Damage:
						damage_range = range_factor * ( 1.0f + Root.I.Get<GameConfig>().LevelFactor * 0.1f * lvl );
						break;
				}
			} );
		}

		protected override DamageEffect get_damage_effect( Bot target ,float damage )
		{
			return new FieldDamage( damage , damage_range , target );
		}
	}
}