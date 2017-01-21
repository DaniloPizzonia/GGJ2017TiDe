using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        public Transform target;
        void Start()
        {
            target.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

