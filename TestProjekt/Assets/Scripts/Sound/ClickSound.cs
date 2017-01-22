using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class ClickSound : PlaySound
	{
		private void Update()
		{
			for ( int i = 0 ; i < 3 ; i++ )
			{
				if ( Input.GetMouseButtonUp( i ) )
				{
					Play();
				}
			}
		}
	}
}
