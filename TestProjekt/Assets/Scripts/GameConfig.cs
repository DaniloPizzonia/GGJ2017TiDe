﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class GameConfig : RootComponent
    {
        //Bot
        public float BotHealth { get { return 10.0f; } }
        public float BotSpeed { get { return 10.0f; } }
        public int BotLevel { get { return 1; } }
        public int BotReward { get { return 20; } }
        //Tower
        public float TowerDamage { get { return 20.0f; } }
        public float TowerRange { get { return 20.0f; } }
        public float TowerCooldown { get { return 5.0f; } }
        public int TowerPrice { get { return 50; } }
        public int TowerLevel { get { return 1; } }
        //Player
        public int PlayerMoney { get { return 1500; } }
        public int PlayerLives { get { return 50; } }
       

        public float LevelFactor { get { return 2.3f; } }
        public float DamageRange { get { return 5.0f; } }

    }
}
