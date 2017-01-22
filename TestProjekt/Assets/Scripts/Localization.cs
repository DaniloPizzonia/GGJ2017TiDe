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
			{ "upgrade" , "Upgrades" },
			{ "tower" , "Tower" },
			{ "GameModeTimer" , "Next wave in: {0} seconds" },
			{ "GameModeBotLeft" , "{0} creeps remaining" },
			{ "description_singletarget" , "Name: {0}\nDamage: {1}\nRange: {2}\nCooldown: {3}s" },
			{ "description_aoe" , "Name: {0}\nDamage: {1}\nRange: {2}\nCooldown: {3}s" },
			{ "description_slower" , "Name: {0}\nDamage: {1}\nRange: {2}\nCooldown: {3}s" },
			{ "name_singletarget" , "Single target" },
			{ "name_aoe" , "AOE" },
			{ "name_slower" , "Slower" }
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
