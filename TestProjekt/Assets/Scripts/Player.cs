using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
    public class Player : RootComponent
    {
        private int life = Root.I.Get<GameConfig>().PlayerLives;
        private int money = Root.I.Get<GameConfig>().PlayerMoney;

        [SerializeField]
        private UnityEvent onChangeMoney = new UnityEvent();
        public UnityEvent OnChangeMoney { get { return onChangeMoney; } }

        [SerializeField]
        private UnityEvent onChangeLife = new UnityEvent();
        public UnityEvent OnChangeLife { get { return onChangeLife; } }

        [SerializeField]
        private UnityEvent onDie = new UnityEvent();
        public UnityEvent OnDie { get { return onDie; } }

        public int Money
        {
            get
            {
                return money;
            }
            private set
            {
                money = value;
                onChangeMoney.Invoke();
            }
        }
        public int Life
        {
            get
            {
                return life;
            }
            private set
            {
                life = value;
                onChangeLife.Invoke();
            }
        }

        public int ReduceLife()
        {
            if (Life <= 0)
            {
                onDie.Invoke();
                Root.I.Reset();
                return Life = 0;
            }
            return Life--;
        }

        public bool CheckMoney(int amount)
        {
            return money >= amount;
        }

        public bool Buy(int amount)
        {
            if (CheckMoney(amount))
            {
                Money -= amount;
                return true;
            }
            return false;
        }

        public void GiveMoney(int amount)
        {
            Money += amount;
        }
    }

}
