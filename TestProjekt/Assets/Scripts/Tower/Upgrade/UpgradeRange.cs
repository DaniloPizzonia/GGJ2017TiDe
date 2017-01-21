using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unsernamespace
{
	public class UpgradeRange : Upgrade
	{
		protected override void apply()
		{
			upgrade_property( UpgradeProperty.Range );
		}
	}
}
