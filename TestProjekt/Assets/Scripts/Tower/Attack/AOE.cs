using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class AOE : SingleTarget
	{
		[SerializeField]
		private float damage_range;

		protected override DamageEffect get_damage_effect( Bot target ,float damage )
		{
			return new FieldDamage( damage , damage_range , target );
		}
	}
}