using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class Speed : DamageEffect
	{
		private float internal_value;

		protected virtual float value
		{
			get
			{
				return internal_value;
			}
		}

		public Speed( float value , Bot target ) : base ( target )
		{
			internal_value = value;
		}

		protected override void apply( Bot bot )
		{
			bot.Speed = Mathf.Max( Root.I.Get<GameConfig>().BotMinSpeed ,  ( bot.Speed - ( internal_value * ( 1 / ( bot.InitialSpeed / bot.Speed ) ) ) ) );
		}
	}
}