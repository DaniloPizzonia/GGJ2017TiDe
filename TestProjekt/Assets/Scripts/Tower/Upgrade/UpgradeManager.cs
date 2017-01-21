using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public class UpgradeManager : RootComponent
	{
		private UpgradeProperty mode;
		private bool enabled = false;

		public bool Enabled
		{
			get
			{
				return enabled;
			}
		}

		public UpgradeProperty Mode
		{
			get
			{
				return mode;
			}
		}

		public void Enable( UpgradeProperty mode )
		{
			this.mode = mode;
			enabled = true;
		}

		public void Disable()
		{
			enabled = false;
		}

		public void Upgrade( Tower tower )
		{
			if ( !enabled )
			{
				return;
			}

			switch( mode )
			{
				case UpgradeProperty.Cooldown:
					tower.Upgrade<UpgradeCooldown>();
					break;
				case UpgradeProperty.Damage:
					tower.Upgrade<UpgradeDamage>();
					break;
				case UpgradeProperty.Range:
					tower.Upgrade<UpgradeRange>();
					break;
			}
		}
	}
}
