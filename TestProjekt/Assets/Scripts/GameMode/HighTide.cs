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
			Root.I.Get<BotManager>().SpawnBot( SelectBotType() );
		}

		private bool is_boss_level
		{
			get
			{
				return Level % Root.I.Get<GameConfig>().BossInterval == 0;
			}
		}

		private string SelectBotType()
		{
			bool high_level = Level > Root.I.Get<GameConfig>().BossHighCut;

			// At regular intervals, boss mobs will spawn:
			if ( is_boss_level )
			{
				return high_level ? "boss" : "cthulhu";
			}
			// At higher levels, regular bosses may spawn as normal mobs:
			if ( high_level && UnityEngine.Random.Range( 0 , 100 ) < 5 )
			{
				return "boss";
			}

			return "bot";
		}

		protected virtual int get_bot_amount()
		{
			if ( is_boss_level )
			{
				return Root.I.Get<GameConfig>().BossAmount;
			}

			return Root.I.Get<GameConfig>().BotPerLevel;
		}
	}
}
