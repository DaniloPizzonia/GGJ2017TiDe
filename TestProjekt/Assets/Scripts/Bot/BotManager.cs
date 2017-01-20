﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace unsernamespace
{
    public class BotManager : RootComponent
    {
        public BotManager()
        {
            Timer timer = new Timer(1, () =>
            {
                SpawnBot();
            });
        }
        private List<Bot> bots = new List<Bot>();


        public Bot[] AllBots
        {
            get { return bots.ToArray(); }
        }

        public Bot SpawnBot()
        {
            Bot spawnedBot = Root.I.Get<BotFactory>().CreateBot();
            bots.Add(spawnedBot);
            return spawnedBot;
        }
    }
}