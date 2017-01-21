using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unsernamespace
{
	public class Localization : RootComponent
	{
		private Dictionary<string , string> data = new Dictionary<string , string>()
		{
			{ "HighTide" , "High Tide" },
			{ "LowTide" , "Low Tide" },
			{ "CoinPrefix" , "Coin: " },
			{ "LifePrefix" , "Life: " },
			{ "GameModeTimer" , "Next wave in: {0} seconds" },
			{ "GameModeBotLeft" , "{0} creeps remaining" }
		};

		public string this[ string key ]
		{
			get
			{
				lock ( data )
				{
					if ( !data.ContainsKey( key ) )
					{
						return "";
					}
					return data[ key ];
				}
			}
		}

	}
}
