using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class BotFactory : RootComponent
	{   //TODO Formel für HP    
        public Bot CreateBot()
        {
            GameObject bot = GameObject.Instantiate(Resources.Load<GameObject>("bot"));
            return bot.GetComponent<Bot>();
        }
	}
}