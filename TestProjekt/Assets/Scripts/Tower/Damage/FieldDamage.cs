using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class FieldDamage : DamageEffect
	{
		private float internal_value;
		private float range;

		protected virtual float value
		{
			get
			{
				return internal_value;
			}
		}
		
		public FieldDamage( float value , float range , Bot target ) : base( target )
		{
			internal_value = value;
			this.range = range;
		}

		protected override void apply( Bot target )
		{
			target.Health -= internal_value;

			Bot[] field = Root.I.Get<BotManager>().AllBots.Where( a => Vector3.Distance( target.transform.position , a.transform.position ) <= range ).ToArray();

			foreach ( Bot bot in field )
			{
				if ( bot != target )
				{
					new Damage( value , bot ).Apply();
				}
			}
		}
	}
}