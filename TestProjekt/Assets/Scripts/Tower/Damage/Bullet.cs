using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class Bullet : MonoBehaviour
	{
		private DamageEffect damage;
		private Bot target;

		[SerializeField]
		private float speed;

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
			}
		}

		private void OnCollisionDamage()
		{
			if ( null != damage )
			{
				damage.Apply();
			}
		}
	}
}
