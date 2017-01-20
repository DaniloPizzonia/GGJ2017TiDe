using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace unsernamespace
{
    public class BotManager : RootComponent
    {
        private List<Bot> bots = new List<Bot>();
        

        public Bot Bot
        {
            get { throw new System.NotImplementedException(); }
            set { }
        }

        public Bot SpawnBot()
        {
            var spawnedBot = Root.I.Get<BotFactory>().CreateBot();
            bots.Add(spawnedBot);
            return spawnedBot;
        }
    }
}