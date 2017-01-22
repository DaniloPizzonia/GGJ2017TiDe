using System;
using UnityEngine;

namespace unsernamespace
{
	public class Sound : MonoBehaviour
	{
		private AudioSource source;
		public static Sound I
		{
			get
			{
				return FindObjectOfType<Sound>();
			}
		}

		public void Play( AudioClip clip )
		{
			if ( source == null )
			{
				AudioListener listener = MonoBehaviour.FindObjectOfType<AudioListener>();
				if ( listener == null )
				{
					return;
				}
				source = listener.gameObject.GetComponent<AudioSource>();
				if ( source == null )
				{
					return;
				}
			}
			source.PlayOneShot( clip );
		}
	}
}