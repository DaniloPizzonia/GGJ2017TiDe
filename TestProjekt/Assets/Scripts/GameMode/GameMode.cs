using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace unsernamespace
{
	public abstract class GameMode
	{
		private int level;

		[SerializeField]
		private UnityEvent onLevelUp = new UnityEvent();
		public UnityEvent OnLevelUp { get { return onLevelUp; } }

		[SerializeField]
		private UnityEvent onEnter = new UnityEvent();
		public UnityEvent OnEnter { get { return onEnter; } }

		[SerializeField]
		private UnityEvent onLeave = new UnityEvent();
		public UnityEvent OnLeave { get { return onLeave; } }

		public abstract GameModeType Type
		{
			get;
		}

		public int Level
		{
			get
			{
				return level;
			}
		}

		public bool Active
		{
			get
			{
				return Root.I.Get<GameModeManager>().Current == this;
			}
		}

		public void LevelUp()
		{
			level++;
			onLevelUp.Invoke();
		}

		public virtual void Enter()
		{
			LevelUp();
			OnEnter.Invoke();
		}

		public virtual void Leave()
		{
			OnLeave.Invoke();
		}

		public virtual bool Check()
		{
			return false;
		}
	}
}