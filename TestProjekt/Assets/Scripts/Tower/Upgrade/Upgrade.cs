﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public abstract class Upgrade
	{
		private int level;

		[SerializeField]
		private UpgradeEvent onUpgrade = new UpgradeEvent();
		public UpgradeEvent OnUpgrade { get { return onUpgrade; } }

		[SerializeField]
		private UnityEvent onLevelUp = new UnityEvent();
		public UnityEvent OnLevelUp { get { return onLevelUp; } }

		public int price
		{
			get
			{
				return Mathf.CeilToInt( Root.I.Get<GameConfig>().TowerUpdatePrice * Mathf.Pow( 1.5f , level ) );
			}
		}

		public void UpgradeLevel()
		{
			level++;
			apply();
			onLevelUp.Invoke();
		}

		protected void upgrade_property( UpgradeProperty property , float factor=1 )
		{
			onUpgrade.Invoke( property , level , factor );
		}

		protected abstract void apply();
	}
}