using UnityEngine;
using System.Collections;

namespace unsernamespace
{
	public class PlaySound : MonoBehaviour
	{
		public AudioClip[] Clips;

		public void Play()
		{
			if ( Clips != null && Clips.Length > 0 )
			{
				int index = (int)Random.Range( 0 , Clips.Length - 1 );
				Sound.I.Play( Clips[ index ] );
			}
		}
	}
}