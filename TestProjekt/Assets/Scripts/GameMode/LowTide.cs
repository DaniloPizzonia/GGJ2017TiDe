using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class LowTide : GameMode
    {
		private float start = 0;

		public float TimeLeft
		{
			get
			{
				return Mathf.Max( Root.I.Get<GameConfig>().LowTideDuration - ( Time.time - start ) , 0 );
			}
		}

		public override GameModeType Type
		{
			get
			{
				return GameModeType.LowTide;
			}
		}

		public override bool Check()
		{
			return 0 >= TimeLeft;
		}

		public override void Enter()
		{
			base.Enter();
			start = Time.time;
		}
	}
}
