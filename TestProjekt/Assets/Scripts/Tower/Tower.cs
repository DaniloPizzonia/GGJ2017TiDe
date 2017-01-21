﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace unsernamespace
{
	public class Tower : MonoBehaviour
	{
		[SerializeField]
		private AttackMode attack_mode;
		[SerializeField]
		private float cooldown;

		private float last_shoot;

		public AttackMode Attack_Mode
		{
			get
			{
				return attack_mode;
			}
			set { }
		}
		public float Cooldown
		{
			get
			{
				return cooldown;
			}
			set
			{
				cooldown = value;
			}
		}

		public void Attack()
		{
			if (
					null != attack_mode
				&&	attack_mode.Attack()
			)
			{
				last_shoot = Time.time;
			}
		}

		private void Update()
		{
			if ( Time.time - last_shoot > cooldown )
			{
				Attack();
			}
		}
	}
}