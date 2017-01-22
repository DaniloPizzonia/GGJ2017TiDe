using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public class Tower : MonoBehaviour
	{
		[SerializeField]
		private AttackMode attack_mode;

		[SerializeField]
		private UpgradeEvent onUpgrade = new UpgradeEvent();
		public UpgradeEvent OnUpgrade { get { return onUpgrade; } }

		[SerializeField]
		private UnityEvent onUpgradeDone = new UnityEvent();
		public UnityEvent OnUpgradeDone { get { return onUpgradeDone; } }

		private Upgrade[] upgrade_all = new Upgrade[]
		{
			new UpgradeCooldown(),
			new UpgradeDamage(),
			new UpgradeRange()
		};

		public AttackMode Attack_Mode
		{
			get
			{
				return attack_mode;
			}
			set
			{
				attack_mode = value;
			}
		}

		public void Awake()
		{
			Root.I.Get<GameModeManager>().OnChange.AddListener( () =>
			{
				transform.localPosition = Vector3.zero;
			} );

			bind_upgrade();
			if ( null != attack_mode )
			{
				attack_mode.Bind( this );
			}

			foreach ( Upgrade upgrade in upgrade_all )
			{
				upgrade.UpgradeLevel();
			}
		}

		private void bind_upgrade()
		{
			foreach ( Upgrade upgrade in upgrade_all )
			{
				upgrade.OnUpgrade.AddListener( ( UpgradeProperty property , int level , float factor ) =>
				{
					OnUpgrade.Invoke( property , level , factor );
				} );

				upgrade.OnLevelUp.AddListener( () =>
				{
					OnUpgradeDone.Invoke();
				} );
			}
		}

		private void Update()
		{
			if ( null != attack_mode )
			{
				attack_mode.Attack();
			}
		}

		private void OnMouseUp()
		{
			Root.I.Get<TowerManager>().Current = this;
		}

		public T Upgrade<T>() where T : Upgrade
		{
			foreach ( Upgrade upgrade in upgrade_all )
			{
				if ( upgrade is T )
				{
					return upgrade as T;
				}
			}

			return null;
		}
	}
}