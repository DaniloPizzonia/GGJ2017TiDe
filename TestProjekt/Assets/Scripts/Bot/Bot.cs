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
		private float health;
		private float speed;

		[SerializeField]
		private UnityEvent onChangeHealth = new UnityEvent();
		public UnityEvent OnChangeHealth { get { return onChangeHealth; } }

        [SerializeField]
		private UnityEvent onDie = new UnityEvent();
        public UnityEvent OnDie { get { return onDie; } }

		[SerializeField]
		private UnityEvent onChangeSpeed = new UnityEvent();
		public UnityEvent OnChangeSpeed { get { return onChangeSpeed; } }
		
		private bool alive = true;

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

		public virtual int MaxHealth
		{
			get
			{
				return Mathf.CeilToInt( Root.I.Get<GameConfig>().BotHealth *
					Mathf.Pow(
						Root.I.Get<GameConfig>().LevelFactor , 
						Root.I.Get<GameModeManager>().Current.Level
				));
			}
		}

		public virtual float InitialSpeed
		{
			get
			{
				return Root.I.Get<GameConfig>().BotSpeed;
			}
		}

		private void OnDestroy()
        {
            Root.I.Get<BotManager>().Unregister(this);
        }

		private void Awake()
        {
            OnChangeHealth.AddListener(CheckHealth);
			health = MaxHealth;
			speed = InitialSpeed;

			PathingScript path = GetComponent<PathingScript>();
			if ( null != path )
			{
				path.OnExitReach.AddListener( () =>
				{
					if ( alive )
					{
						alive = false;
						Root.I.Get<Player>().ReduceLife();
					}
				});
			}
        }

		private void reward()
		{
			int level = Root.I.Get<GameModeManager>().Current.Level;

			Root.I.Get<Player>().GiveMoney(
				Mathf.FloorToInt(
					Root.I.Get<GameConfig>().BotReward * Mathf.Pow( level , Root.I.Get<GameConfig>().LevelRewardFactor )
				)
			);
		}

        private void CheckHealth()
        {
            if ( Health <= 0 )
            {
				if ( alive )
				{
					reward();
				}
				alive = false;
                Destroy(gameObject);
            }
        }
	}
}