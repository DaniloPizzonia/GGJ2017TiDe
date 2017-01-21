using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace unsernamespace{
	public class ChangeColorState : MonoBehaviour {

		public GameObject Tower = new GameObject();
	    public Button[] button = new Button[3];

		public void ChangeColor() {
			//Root.I.Get<>(Tower);
			Root.I.Get<TowerManager>(Tower);
	    }
	}
}