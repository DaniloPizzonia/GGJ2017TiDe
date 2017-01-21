using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
    public class GameModeManager : RootComponent
    {
		private GameMode mode;

		[SerializeField]
		private UnityEvent onChange = new UnityEvent();
		public UnityEvent OnChange { get { return onChange; } }

		public GameMode Current
		{
			get
			{
				return null;
			}
		}

	}

}

