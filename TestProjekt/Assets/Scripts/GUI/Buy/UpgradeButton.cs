﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class UpgradeButton : MonoBehaviour
	{
		[SerializeField]
		private UpgradeProperty type;

		private void Awake()
		{
			Root.I.Get<TowerManager>().OnChangeSelection.AddListener( update_icon );
			update_icon();
		}

		public void Click()
		{
			Tower current = Root.I.Get<TowerManager>().Current;
			if ( null == current )
			{
				return;
			}
			Upgrade upgrade = get_upgrade( current );
			if ( null == upgrade )
			{
				return;
			}
			if ( Root.I.Get<Player>().Buy( upgrade.price ) )
			{
				upgrade.UpgradeLevel();
			}

			Root.I.Get<TowerManager>().OnChangeSelection.Invoke();
		}

		private void update_icon()
		{
			Button button = GetComponent<Button>();
			if ( null != button )
			{
				Tower current = Root.I.Get<TowerManager>().Current;
				button.interactable =
						current != null
					&&	Root.I.Get<Player>().CheckMoney( get_upgrade( current ).price );
			}
		}

		private Upgrade get_upgrade( Tower tower )
		{
			switch ( type )
			{
				case UpgradeProperty.Damage:
					return tower.Upgrade<UpgradeDamage>();
					break;
				case UpgradeProperty.Range:
					return tower.Upgrade<UpgradeRange>();
					break;
				case UpgradeProperty.Cooldown:
					return tower.Upgrade<UpgradeCooldown>();
					break;
			}
			return null;
		}
	}
}
