using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public class RootComponent : UpdateManager
	{
		/// <summary>
		/// Shortcut to root instance
		/// </summary>
		protected Root Root
		{
			get
			{
				return Root.I;
			}
		}
	}
}