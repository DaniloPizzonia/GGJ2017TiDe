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
            GameModeManager gmm = Root.I.Get<GameModeManager>();

            int level = gmm.Current.Level;
            bool bossRound = level % 5 == 0;
            bool highLevel = level > 10;

            // At regular intervals, boss mobs will spawn:
            if (bossRound)
            {
                return highLevel ? "boss" : "cthulhu";
            }
            // At higher levels, regular bosses may spawn as normal mobs:
            if(highLevel && Random.Range(0, 100) < 50)
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