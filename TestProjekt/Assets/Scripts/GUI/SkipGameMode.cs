using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class SkipGameMode : MonoBehaviour
	{
		private Button button;

		private bool active
		{
			get
			{
				return Root.I.Get<GameModeManager>().Current is LowTide;
			}
		}

		private void Awake()
		{
			button = GetComponent<Button>();
		}

		private void Update()
		{
			if ( null != button )
			{
				button.interactable = active;
			}
		}

		public void Click()
		{
			if ( active )
			{
				Root.I.Get<GameModeManager>().Switch();
			}
		}
	}
}
