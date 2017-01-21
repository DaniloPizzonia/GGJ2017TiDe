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

		[SerializeField]
		private float speed;

		[SerializeField]
		public UnityEvent onHit = new UnityEvent();
		public UnityEvent OnHit { get { return onHit; } }

		public void Bind( DamageEffect damage , Bot target )
		{
			this.damage = damage;
			this.target = target;
		}

		private void Update()
		{
			if ( null != target )
			{
				transform.position = Vector3.MoveTowards( transform.position , target.transform.position , Time.deltaTime * speed );
				transform.LookAt( target.transform.position );
			}
		}

		private void OnCollisionDamage()
		{
			if ( null != damage )
			{
				if ( damage.Apply() )
				{
					onHit.Invoke();
				}
			}
		}
	}
}
