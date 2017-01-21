using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class UpgradeButton : MonoBehaviour
	{
		[SerializeField]
		private UpgradeProperty type;

		public void Click()
		{

			if (
					!Root.I.Get<UpgradeManager>().Enabled
				||	type != Root.I.Get<UpgradeManager>().Mode
			)
			{
				Root.I.Get<UpgradeManager>().Enable( type );
			}
			else
			{
				Root.I.Get<UpgradeManager>().Disable();
			}
		}

		private void Update()
		{

			if (
					Input.GetMouseButtonUp( 1 )
				||	Input.GetKeyUp( KeyCode.Escape )
			)
			{
				Root.I.Get<UpgradeManager>().Disable();
			}

		}
	}
}
