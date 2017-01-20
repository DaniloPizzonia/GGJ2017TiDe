using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace unsernamespace
{
	public class Tower : MonoBehaviour
	{
		private float health;
		private float speed;
		private AttackMode attack_mode;

		[SerializeField]
		private ModeType attack_type;

		private void Awake()
		{
			attack_mode = Root.I.Get<AttackModeManager>().GetModeOfType( attack_type );
		}

		public void Attack()
		{
			if ( null != attack_mode )
			{
				attack_mode.Attack();
			}
		}
	}
}