using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
	public abstract class GameMode
	{
		public GameMode()
		{

		}

		public abstract GameModeType Type
		{
			get;
		}

		public int Index
		{
			get
			{
				return 0;
			}
		}
	}
}