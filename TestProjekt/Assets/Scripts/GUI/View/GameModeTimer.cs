using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class GameModeTimer : MonoBehaviour
	{
		private Text output;
		private void Awake()
		{
			output = GetComponent<Text>();
		}
		private void Update()
		{
			LowTide mode = Root.I.Get<GameModeManager>().Current as LowTide;
			if ( mode != null )
			{
				output.text = Mathf.FloorToInt( mode.TimeLeft ).ToString();
			}
		}
	}
}
