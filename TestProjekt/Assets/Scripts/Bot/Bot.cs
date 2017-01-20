using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public class Bot : MonoBehaviour
	{
        [SerializeField]
		private float health;
        [SerializeField]
		private float speed;

		[SerializeField]
		public UnityEvent onChangeHealth = new UnityEvent();
		public UnityEvent OnChangeHealth { get { return onChangeHealth; } }

        [SerializeField]
        public UnityEvent onDie = new UnityEvent();
        public UnityEvent OnDie { get { return onDie; } }

        [SerializeField]
		public UnityEvent onChangeSpeed = new UnityEvent();
		public UnityEvent OnChangeSpeed { get { return onChangeSpeed; } }


		public float Health
		{
			get
			{
				return health;
			}
			set
			{
				health = value;
				onChangeHealth.Invoke();
            }
		}

		public float Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
				onChangeSpeed.Invoke();
			}
		}
        void OnDestroy()
        {
            Root.I.Get<BotManager>().Unregister(this);
        }
        void Awake()
        {
            OnChangeHealth.AddListener(CheckHealth);
        }
        private void CheckHealth()
        {
            if (Health<=0)
            {
                Destroy(gameObject);
            }
        }
	}
}