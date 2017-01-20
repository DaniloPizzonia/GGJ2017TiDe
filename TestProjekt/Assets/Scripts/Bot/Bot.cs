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
		public UnityEvent onChangeHealth = new UnityEvent();
		public UnityEvent OnChangeHealth { get { return onChangeHealth; } }

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
	}
}