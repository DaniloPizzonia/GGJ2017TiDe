using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public abstract class AttackMode : MonoBehaviour
	{

		[SerializeField]
		private GameObject bullet_prefab;

		[SerializeField]
		public UnityEvent onAttack = new UnityEvent();
		public UnityEvent OnAttack { get { return onAttack; } }

		[SerializeField]
		public UnityEvent onShot = new UnityEvent();
		public UnityEvent OnShoot { get { return onShot; } }

		public void Attack()
		{
			if ( attack() )
			{
				onAttack.Invoke();
			}
		}

		protected abstract bool attack();

		public void Shot( Bot target , DamageEffect damage_effect )
		{
			GameObject container = Instantiate( bullet_prefab );
			Bullet bullet = container.GetComponent<Bullet>();
			if ( null == bullet )
			{
				return;
			}

			bullet.Bind( damage_effect , target );
			onShot.Invoke();
		}
	}
}