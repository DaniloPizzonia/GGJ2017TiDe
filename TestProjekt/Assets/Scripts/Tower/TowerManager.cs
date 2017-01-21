using System;
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

		public Tower Create( GameObject prefab , Action<Tower> callback=null )
		{
			GameObject container = GameObject.Instantiate( prefab );
			Tower tower = container.GetComponent<Tower>();
			if ( null == tower )
			{
				throw new Exception( "wrong prefab" );
			}
			if ( null != callback )
			{
				callback( tower );
			}
			lock ( tower_collection )
			{
				tower_collection.Add( tower );
			}
			return tower;
		}

		public void Unregister( Tower tower )
		{
			lock ( tower_collection )
			{
				if ( tower_collection.Contains( tower ) )
				{
					tower_collection.Add( tower );
				}
			}
		}
	}
}