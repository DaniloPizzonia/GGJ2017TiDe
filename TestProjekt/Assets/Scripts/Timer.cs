using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class Timer
	{
		public float Interval { get; set; }
		public bool Enabled { get; set; }
		public float NextTick { get; private set; }
		public float LastTick { get; private set; }

		private Action action;

		public Timer( float interval , Action action )
		{
			this.action = action;
			Interval = interval;
			Enabled = true;
			NextTick = Time.realtimeSinceStartup + Interval;
			LastTick = Time.realtimeSinceStartup;

			GameObject.Register( this );
		}
		
		private TimerGameObject GameObject
		{
			get
			{
				TimerGameObject obj = MonoBehaviour.FindObjectOfType<TimerGameObject>();

				if ( null != obj )
				{
					return obj;
				}

				GameObject instance = new UnityEngine.GameObject();
				instance.transform.SetParent( null );
				UnityEngine.GameObject.DontDestroyOnLoad( instance );
				obj = instance.AddComponent<TimerGameObject>();
				obj.name = "timer";
				return obj;
			}
		}

		public void Trigger( float time )
		{
			NextTick = time + Interval;
			LastTick = time;

			action();
		}
		
		public void Destroy()
		{
			GameObject.Unregister( this );
		}
	}
}