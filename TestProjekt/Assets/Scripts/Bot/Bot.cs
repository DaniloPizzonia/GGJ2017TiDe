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
		public UnityEvent onChangHalth = new UnityEvent();
		public UnityEvent OnChgangeHalth { get { return onChangHalth; } }

		[SerializeField]
		public UnityEvent onChangSpeed = new UnityEvent();
		public UnityEvent OnChangSpeed { get { return onChangSpeed; } }

		public float Health
		{
			get
			{
				return health;
			}
			set
			{
				health = value;
				onChangHalth.Invoke();
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
				onChangSpeed.Invoke();
			}
		}
	}
}