using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class TimerGameObject: MonoBehaviour
	{
		private List<Timer> timer_list = new List<Timer>();
		
		private void Awake()
		{
			DontDestroyOnLoad( gameObject );
		}
		
		public void Register( Timer timer )
		{
			lock( timer_list )
			{
				if ( !timer_list.Contains( timer ) )
				{
					timer_list.Add( timer );
				}
			}
		}
		
		public void Unregister( Timer timer )
		{
			lock ( timer_list )
			{
				if ( timer_list.Contains( timer ) )
				{
					timer_list.Remove( timer );
				}
			}
		}
		
		public void Update()
		{
			float time = Time.realtimeSinceStartup;

			lock( timer_list  )
			{
				foreach ( Timer timer in timer_list.ToArray() )
				{
					if (
							timer.Enabled
						&&	timer.NextTick <= time
					)
					{
						timer.Trigger( time );
					}
				}
			}
		}
	}
}
