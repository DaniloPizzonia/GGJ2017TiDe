using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class credits : MonoBehaviour
	{
		[SerializeField]
		private Transform[] credits_list;
		[SerializeField]
		private Transform[] menu;

		public void enable()
		{
			foreach( Transform t in credits_list )
			{
				t.gameObject.SetActive( true );
			}
			foreach ( Transform t in menu )
			{
				t.gameObject.SetActive( false );
			}
		}

		public void disable()
		{
			foreach ( Transform t in menu )
			{
				t.gameObject.SetActive( true );
			}
			foreach ( Transform t in credits_list )
			{
				t.gameObject.SetActive( false );
			}
		}
	}
}
