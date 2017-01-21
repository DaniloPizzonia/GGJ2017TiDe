using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
	public class HighTide : GameMode
	{
		public override GameModeType Type
		{
			get
			{
				return GameModeType.HighTide;
			}
		}

		private int bot_to_spawn;

		public HighTide()
		{
			new Timer( Root.I.Get<GameConfig>().BotSpawnInterval , spawn );
		}

		public int BotLeft
		{
			get
			{
				return bot_to_spawn;
			}
		}

		public override void Enter()
		{
			base.Enter();
			bot_to_spawn = get_bot_amount();
		}

		public override bool Check()
		{
			return	0 >= bot_to_spawn
				&&	0 >= Root.I.Get<BotManager>().AllBots.Length;
		}

		private void spawn()
		{
			if ( 
					!Active
				||	0 >= bot_to_spawn
			)
			{
				return;
			}
			bot_to_spawn--;
			Root.I.Get<BotManager>().SpawnBot();
		}

		protected virtual int get_bot_amount()
		{
			return Root.I.Get<GameConfig>().BotPerLevel;
		}
	}
}
