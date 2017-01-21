using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public abstract class RangeDamageAttackMode : AttackMode
	{
		private float damage;
		private float range = 0;

		public float Damage
		{
			get
			{
				return damage;
			}
		}
		public float Range
		{
			get
			{
				return range;
			}
		}

		protected abstract float damage_factor
		{
			get;
		}

		protected abstract float range_factor
		{
			get;
		}

		public override void Bind( Tower tower )
		{
			base.Bind( tower );

			tower.OnUpgrade.AddListener( ( UpgradeProperty property , int lvl , float factor ) =>
			{
				switch ( property )
				{
					case UpgradeProperty.Damage:
						damage = damage_factor * lvl + ( lvl - 1.0f ) * Root.I.Get<GameConfig>().LevelFactor * 2.0f;
						break;
					case UpgradeProperty.Range:
						range = range_factor * ( 1.0f + Root.I.Get<GameConfig>().LevelFactor * 0.1f * lvl );
						break;
				}
			});
		}
	}
}