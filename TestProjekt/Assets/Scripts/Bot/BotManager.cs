using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace unsernamespace
{
    public class BotManager : RootComponent
    {
        private List<Bot> bots = new List<Bot>();

        public Bot[] AllBots
        {
            get { return bots.ToArray(); }
        }

        public Bot SpawnBot( string type )
        {
            Bot spawnedBot = Root.I.Get<BotFactory>().CreateBot( type );
            bots.Add(spawnedBot);
            return spawnedBot;
        }

        public void Unregister(Bot botToDestroy)
        {
            bots.Remove(botToDestroy);
        }
    }
}