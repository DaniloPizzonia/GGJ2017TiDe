using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace{
	public class TowerComitter : MonoBehaviour {
		[SerializeField]
		private GameObject Tower = new GameObject();


		// use this method to pass the selected tower to the TowerManager
		public void CommitTower(object bla) {
			
		//	Root.I.Get<TowerManager>(bla);
			Debug.Log ("hat geklappt");
		}
	}
}