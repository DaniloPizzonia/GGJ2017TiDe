using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public class TowerManager : RootComponent
	{
		private List<Tower> tower_collection = new List<Tower>();
		private Tower current;

		[SerializeField]
		private UnityEvent onChangeSelection = new UnityEvent();
		public UnityEvent OnChangeSelection { get { return onChangeSelection; } }

		public Tower[] All
		{
			get
			{
				return tower_collection.ToArray();
			}
		}

		public Tower Current
		{
			get
			{
				return current;
			}
			set
			{
				current = value;
				OnChangeSelection.Invoke();
				create_selection( value );
			}
		}

		private void create_selection( Tower target )
		{
			if ( null == target )
			{
				return;
			}
			GameObject selection = GameObject.Instantiate( Resources.Load<GameObject>( "selection" ) );
			selection.transform.SetParent( target.transform , true );
			selection.transform.localPosition = Vector3.zero;
			selection.transform.localScale = new Vector3( 0.2f , 0.2f , 0.2f );
			selection.GetComponent<TowerSelection>().Bind( target );
		}

		public Tower Create( GameObject prefab , TowerContainer parent , Action<Tower> callback=null )
		{
			GameObject container = GameObject.Instantiate( prefab );
			container.transform.SetParent( parent.transform , true );
			container.transform.localPosition = Vector3.zero;
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

			Current = tower;
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

		public int Price()
		{
			return Root.I.Get<GameConfig>().TowerPrice;
		}
	}
}