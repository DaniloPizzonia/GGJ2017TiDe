using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
    public class GameModeManager : RootComponent
    {
		[SerializeField]
		private UnityEvent onChange = new UnityEvent();
		public UnityEvent OnChange { get { return onChange; } }

		private GameMode current;
		private GameMode[] mode_list = new GameMode[]
		{
			new HighTide(),
			new LowTide()
		};

		public GameMode Current
		{
			get
			{
				return current;
			}
		}

		public GameModeManager()
		{
			current = mode_list[ 0 ];
			current.Enter();
			OnChange.Invoke();

			// check loop
			new Timer( 1 , () =>
			{
				if ( null != current )
				{
					if ( current.Check() )
					{
						Switch();
					}
				}
			});
		}

		public void Switch()
		{
			int next_index = Array.IndexOf( mode_list , current ) + 1;
			if ( mode_list.Length <= next_index )
			{
				next_index = 0;
			}
			lock( current )
			{
				current.Leave();
				current = mode_list[ next_index ];
				current.Enter();
			}
			OnChange.Invoke();
		}

	}

}

