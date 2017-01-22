using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class TowerSelection : MonoBehaviour
	{
		private Tower owner = null;

		public void Bind( Tower tower )
		{
			owner = tower;
		}

		private void Update()
		{
			if ( owner != Root.I.Get<TowerManager>().Current )
			{
				Destroy( gameObject );
			}
		}
	}
}
