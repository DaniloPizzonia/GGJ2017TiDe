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

		public override int MaxHealth
		{
			get
			{
				return Mathf.CeilToInt( base.MaxHealth * health_factor );
			}
		}
	}
}
