using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class ReturnToMainMenu : MonoBehaviour
    {
        [SerializeField]
        public Transform target;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                target.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}

