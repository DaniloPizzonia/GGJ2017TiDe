using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public class Bullet : MonoBehaviour
	{
		private DamageEffect damage;
		private Bot target;
		private float start;

		[SerializeField]
		private float speed;
		[SerializeField]
		private float timeout;

		[SerializeField]
		public UnityEvent onHit = new UnityEvent();
		public UnityEvent OnHit { get { return onHit; } }

		private void Awake()
		{
			start = Time.time;
		}

		public void Bind( DamageEffect damage , Bot target )
		{
			this.damage = damage;
			this.target = target;
		}

		private void Update()
		{
			if ( null != target )
			{
				Vector3 target_postion = target.transform.position;
				Vector3 position = transform.position;
				transform.position = Vector3.MoveTowards( position , target_postion , Time.deltaTime * speed );
				transform.LookAt( new Vector3( target_postion.x , position.y , target_postion.z ) );
			}
			else
			{
				Destroy( gameObject );
			}

			if ( Time.time - start > timeout )
			{
				OnCollisionEnter( null );
			}
		}

		private void OnCollisionEnter( Collision collision )
		{
			if (
					null != collision
				&&	collision.gameObject.layer != LayerMask.NameToLayer( "Bot" )
			)
			{
				return;
			}

			if ( null != damage )
			{
				if ( damage.Apply() )
				{
					onHit.Invoke();
				}
			}
			Destroy( gameObject );
		}
	}
}
