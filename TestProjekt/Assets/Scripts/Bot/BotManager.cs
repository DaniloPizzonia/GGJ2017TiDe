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

        private string SelectBotType()
        {
            bool bossRound = Root.I.Get<GameModeManager>().Current.Level % 2 == 0;
            if(bossRound)
            {
                return "boss";
            }

            return "bot";
        }

        public Bot SpawnBot()
        {
            string botType = SelectBotType();
            Bot spawnedBot = Root.I.Get<BotFactory>().CreateBot(botType);
            bots.Add(spawnedBot);
            return spawnedBot;
        }

        public void Unregister(Bot botToDestroy)
        {
            bots.Remove(botToDestroy);
        }
    }
}