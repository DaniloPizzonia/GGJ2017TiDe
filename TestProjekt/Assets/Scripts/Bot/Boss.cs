using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class Boss : Bot
	{
		[SerializeField]
		private float health_factor;
		[SerializeField]
		private float speed_factor = 1;

		public override int MaxHealth
		{
			get
			{
				return Mathf.CeilToInt( base.MaxHealth * health_factor );
			}
		}

		public override float InitialSpeed
		{
			get
			{
				return base.InitialSpeed * speed_factor;
			}
		}
	}
}
