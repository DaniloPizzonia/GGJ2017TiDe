using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class HealthBar : MonoBehaviour
	{
		[SerializeField]
		private Transform inner;
		[SerializeField]
		private Bot bot;

		private void Update()
		{
			if (
					inner != null
				&&	bot != null
			)
			{
				float progress = (float)bot.Health / bot.MaxHealth;
				inner.transform.localScale = new Vector3( progress , 1 , 1 );
			}

			Camera camera = Camera.main;
			transform.LookAt( transform.position + camera.transform.rotation * Vector3.forward ,
				camera.transform.rotation * Vector3.up );
		}
	}
}
