using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class Player : RootComponent
    {
        [SerializeField]
        private int lifepoints;
        [SerializeField]
        private int money;

        public int Lifepoints { get { return lifepoints; } set { value = lifepoints; } }
        public int Money { get { return money; } set {value = money; } }

        public void ReduceLifepoints()
        {
            this.Lifepoints--;
        }
        public void ReduceMoney(int price)
        {
            
        }
    }

}
