using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace unsernamespace
{
	public class TowerManager : RootComponent
	{
		private List<Tower> tower_collection = new List<Tower>();

		public Tower[] All
		{
			get
			{
				return tower_collection.ToArray();
			}
		}
	}
}