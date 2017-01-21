using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class Wave
    {
        BotManager botmanager = new BotManager();

        public Wave()
        {
            Timer timer = new Timer(Root.I.Get<GameConfig>().WaveWaitTime, () => { botmanager.SpawnBot(); });
        }


    }
}

