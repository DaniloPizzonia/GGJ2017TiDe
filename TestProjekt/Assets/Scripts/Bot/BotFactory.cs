﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public class BotFactory : RootComponent
	{
        public Bot CreateBot()
        {
            Bot bot = new Bot();

            return bot;
        }
	}
}