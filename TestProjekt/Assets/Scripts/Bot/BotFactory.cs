using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class BotFactory : RootComponent
	{   
        public float HPBot()
        {
            return Root.I.Get<GameConfig>().BotLevel * Root.I.Get<GameConfig>().BotHealth;
        }

        public Bot CreateBot()
        {
            GameObject bot = GameObject.Instantiate(Resources.Load<GameObject>("bot"));
            return bot.GetComponent<Bot>();
        }
	}
}