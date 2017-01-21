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
			set { }
		}

		private void Awake()
		{
			Root.I.Get<GameModeManager>().OnChange.AddListener( () =>
			{
				transform.position = Vector3.zero;
			} );

			bind_upgrade();

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
				});
			}
		}

		private void Update()
		{
			if ( null != attack_mode )
			{
				attack_mode.Attack();
			}
		}

		private void OnClick()
		{
			Root.I.Get<UpgradeManager>().Upgrade( this );
		}

		public void Upgrade<T>() where T: Upgrade
		{
			bool success = false;
			foreach( Upgrade upgrade in upgrade_all )
			{
				if ( upgrade is T )
				{
					if ( Root.I.Get<Player>().Buy( upgrade.price ) )
					{
						upgrade.UpgradeLevel();
						success = true;
					}
				}
			}

			if ( success )
			{
				OnUpgradeDone.Invoke();
			}
		}

	}
}