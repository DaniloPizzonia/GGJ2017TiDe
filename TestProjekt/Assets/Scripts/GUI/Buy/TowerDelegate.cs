using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public class TowerDelegate : MonoBehaviour
	{
		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		public UnityEvent onApply = new UnityEvent();
		public UnityEvent OnApply { get { return onApply; } }

		[SerializeField]
		public UnityEvent onLeave = new UnityEvent();
		public UnityEvent OnLeave { get { return onLeave; } }

		private TowerContainer current_target = null;
		private Vector3 last_mouse_position;

		public int Price
		{
			get
			{
				return Root.I.Get<TowerManager>().Price();
			}
		}

		private void Update()
		{
			if ( last_mouse_position != Input.mousePosition )
			{
				current_target = raycast_container();
				if ( null != current_target )
				{
					transform.SetParent( current_target.transform , true );
					transform.localPosition = Vector3.zero;
				}
			}

			if ( Input.GetMouseButtonUp ( 0 ) )
			{
				if (
						null != current_target
					&&	Root.I.Get<Player>().Buy( Price )
				)
				{
					Root.I.Get<TowerManager>().Create( prefab , current_target );
					onApply.Invoke();
				}

				onLeave.Invoke();
			}

			if (
					Input.GetMouseButtonUp( 1 )
				||	Input.GetKeyUp( KeyCode.Escape )
			)
			{
				onLeave.Invoke();
			}

		}

		private TowerContainer raycast_container()
		{
			TowerContainer result = current_target;
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			if ( Physics.Raycast( ray , out hit ) )
			{
				float nearest_distance = float.MaxValue;
				foreach ( TowerContainer container in FindObjectsOfType<TowerContainer>() )
				{
					if (
							container == current_target
						|| 0 >= container.transform.childCount
					)
					{
						float distance = Vector3.Distance( container.transform.position , hit.point );
						if ( distance < nearest_distance )
						{
							nearest_distance = distance;
							result = container;
						}
					}
				}
			}
			return result;
		}
	}
}
