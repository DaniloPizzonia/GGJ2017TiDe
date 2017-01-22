using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class GameConfig : RootComponent
    {
        //Bot
        public float BotHealth { get { return 20.0f; } }
        public float BotSpeed { get { return 5.0f; } }
		public float BotMinSpeed { get { return 1.0f; } }
		public int BotLevel { get { return 1; } }
        public int BotReward { get { return 50; } }
		public int BotPerLevel { get { return 20; } }
		public int BotSpawnInterval { get { return 1; } }

		//Boss
		public int BossInterval { get { return 5; } }
		public int BossHighCut { get { return 10; } }
		public int BossAmount { get { return 1; } }

		//Rangetower
		public float RangetowerDamage { get { return 17.0f; } }
        public float RangetowerRange { get { return 4f; } }
        public float RangetowerCooldown { get { return 1f; } }       

        //AOETower
        public float AOEDamage { get { return 12.0f; } }
        public float AOERange { get { return 3.0f; } }
        public float AOECooldown { get { return 5.0f; } }
        public float AOESplashRange { get { return 3.0f; } }
       
        //SlowTower
        public float SlowTowerDamage { get { return 0.25f; } }
        public float SlowTowerRange { get { return 3.0f; } }
        public float SlowTowerCooldown { get { return 0.5f; } }

        //
        public int TowerPrice { get { return 1000 ; } } //Tower Price = 1000
        public int TowerLevel { get { return 1; } }
        public float TowerDamageRange { get { return 5.0f; } }
		public float TowerUpdatePrice { get { return 500.0f; } } //Tower Update Price = 500
        //

        //Player
        public int PlayerMoney { get { return 2000; } }
        public int PlayerLives { get { return 50; } }
        

        public float LevelFactor { get { return 1.5f; } }       
        public float LowTideDuration { get { return 35.0f; } }
        public float LevelRewardFactor { get { return 1.01f; } }
		public float LevelCooldownFactor { get { return 0.75f; } }
		public float LevelReward { get { return 10f; } }

	}
}

