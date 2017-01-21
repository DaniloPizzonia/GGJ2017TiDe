using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class LowTide : GameMode
    {
		public float TimeLeft
		{
			get
			{
				return 0;
			}
		}

		public override GameModeType Type
		{
			get
			{
				return GameModeType.LowTide;
			}
		}
	}
}
