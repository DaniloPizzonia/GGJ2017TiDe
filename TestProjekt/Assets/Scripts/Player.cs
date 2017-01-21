using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
    public class Player : RootComponent
    {
        private int live = Root.I.Get<GameConfig>().PlayerLives;
        private int money = Root.I.Get<GameConfig>().PlayerMoney;

		[SerializeField]
		public UnityEvent onChangeMoney = new UnityEvent();
		public UnityEvent OnChangeMoney { get { return onChangeMoney; } }

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
		public int Live
		{
			get
			{
				return live;
			}
		}

        public int ReduceLife()
        {
            return live--;
        }

		public bool CheckMoney( int amount )
		{
			return money > amount;
		}

        public bool Buy( int amount )
        {
			if ( CheckMoney( amount ) )
			{
				Money -= amount;
				return true;
			}
			return false;
		}

		public void GiveMoney( int amount )
		{
			Money += amount;
		}
	}

}
