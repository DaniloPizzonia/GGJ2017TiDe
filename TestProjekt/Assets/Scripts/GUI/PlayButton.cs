using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        
        public void Click()
        {
            target.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
