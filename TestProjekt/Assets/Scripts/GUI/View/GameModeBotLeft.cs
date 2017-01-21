using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class GameModeBotLeft : MonoBehaviour
	{
		private Text output;
		private void Awake()
		{
			output = GetComponent<Text>();
		}
		private void Update()
		{
			HighTide mode = Root.I.Get<GameModeManager>().Current as HighTide;
			if ( mode != null )
			{
				string text = Root.I.Get<Localization>()[ "GameModeBotLeft" ];
				if ( 0 < mode.BotLeft )
				{
					output.text = string.Format( text , Mathf.FloorToInt( mode.BotLeft ).ToString() );
				}
				else
				{
					output.text = "";
				}
			}
		}
	}
}
