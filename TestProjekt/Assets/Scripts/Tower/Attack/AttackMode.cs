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

		private float last_shoot;
		private float cooldown;

		public bool Attack()
		{
			bool success = false;
			if ( Time.time - last_shoot > cooldown )
			{
				success = attack();
				if ( success )
				{
					onAttack.Invoke();
					last_shoot = Time.time;
				}
			}

			return success;
		}

		public virtual void Bind( Tower tower )
		{
			tower.OnUpgrade.AddListener( ( UpgradeProperty property , int level , float factor ) =>
			{
				switch ( property )
				{
					case UpgradeProperty.Cooldown:
						cooldown = cooldown_factor * Mathf.Pow( 0.9f , level - 1 );
						break;
				}
			});
		}

		protected abstract float cooldown_factor
		{
			get;
		}

		protected abstract bool attack();

		public void Shot( Bot target , DamageEffect damage_effect )
		{
			GameObject container = Instantiate( bullet_prefab );
			container.transform.position = transform.position;
			container.transform.localScale = Vector3.one;
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