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
			{ "HighTide" , "Ebbe" },
			{ "LowTide" , "Flut" }
		};

		public string this[ string key ]
		{
			get
			{
				return data[ key ];
			}
		}

	}
}
