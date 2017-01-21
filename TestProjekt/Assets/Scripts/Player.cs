using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class Player : RootComponent
    {
        private int lives = Root.I.Get<GameConfig>().PlayerLives;
        private int money = Root.I.Get<GameConfig>().PlayerMoney;

        public int ReduceLife()
        {
            return lives--;
        }

        public int ReduceMoney(int towerPrice)
        {
            return money - towerPrice;
        }
    }

}
