using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class UpgradeButton
	{
		[SerializeField]
		private UpgradeProperty type;

		public void Click()
		{
			switch( type )
			{
				case UpgradeProperty.Cooldown:
					break;
				case UpgradeProperty.Damage:
					break;
				case UpgradeProperty.Range:
					break;
			}
		}
	}
}
