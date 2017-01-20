using System;
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

		public void Attack()
		{
			if ( null != attack_mode )
			{
				attack_mode.Attack();
			}
		}
	}
}