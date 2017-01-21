using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{

	public class UpgradeManager
	{
		private float UpgradeRange(float range, float lvlFactor, int lvl)
		{
			return range * (1.0f + lvlFactor * 0.1f * lvl);
		}
		private float UpgradeDamage(float dmg, float lvlFactor, int lvl)
		{
			return dmg * lvl + (lvl - 1.0f) * lvlFactor * 2.0f;
		}
		private float UpgradeCooldown(float cd, int lvl)
		{
			return cd * Mathf.Pow(0.9f, lvl - 1);
		}


		public void UpgradeTower(Tower instance, int newLevel)
		{
			Root root = Root.I;
			GameConfig conf = root.Get<GameConfig>();

			float lvlFac = conf.LevelFactor;

			AttackMode attackMode = instance.Attack_Mode;

			if(attackMode as AOE != null)
			{
				AOE aoe = attackMode as AOE;
				aoe.SetDamage(UpgradeDamage(conf.TowerDamage, lvlFac, newLevel));
				aoe.SetRange(UpgradeRange(conf.TowerRange, lvlFac, newLevel));
				aoe.SetDamageRange(UpgradeRange(conf.TowerDamageRange, lvlFac, newLevel));
			}
			else if(attackMode as SingleTarget != null)
			{
				SingleTarget st = attackMode as SingleTarget;
				st.SetDamage(UpgradeDamage(conf.TowerDamage, lvlFac, newLevel));
				st.SetRange(UpgradeRange(conf.TowerRange, lvlFac, newLevel));
			}
			else
			{
				Slower slo = attackMode as Slower;
				slo.SetDamage(UpgradeDamage(conf.TowerDamage, lvlFac, newLevel));
				slo.SetRange(UpgradeRange(conf.TowerRange, lvlFac, newLevel));
			}

			instance.Cooldown = UpgradeCooldown(conf.TowerCooldown, newLevel);
		}
	
	}
}
