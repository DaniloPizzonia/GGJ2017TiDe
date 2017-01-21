using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace unsernamespace{
	public class ChangeColorState : MonoBehaviour {

	    public Button[] button = new Button[3];

		public void ChangeColor(int i) {
			//Root.I.Get<>
	        switch(i) {
	            case 0:
	                button[0].enabled = false;
	                Debug.Log("Tower 1");
	                break;
	            case 1:
	                button[1].enabled = false;
	                Debug.Log("Tower 2");
	                break;
	            case 2:
	                button[2].enabled = false;
	                Debug.Log("Tower 3");
	                break;

	            default:
	                break;
	        }
	    }
	}
}