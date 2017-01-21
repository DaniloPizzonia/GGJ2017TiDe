using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
		
		public Damage( float value , Bot target ) : base( target )
		{
			internal_value = value;
		}

		protected override void apply( Bot bot )
		{
			bot.Health -= internal_value;
			int level = Root.I.Get<GameModeManager>().Current.Level;

			Root.I.Get<Player>().GiveMoney(
				Mathf.FloorToInt(
					Root.I.Get<GameConfig>().BotReward * Mathf.Pow( level , Root.I.Get<GameConfig>().LevelRewardFactor )
				)
			);
		}
	}
}