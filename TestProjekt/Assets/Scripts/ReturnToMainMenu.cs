using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
    public class ReturnToMainMenu : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        // Use this for initialization
        void Start()
        {
            //OnDie Listener
            Root.I.Get<Player>().OnDie.AddListener(() =>
			{
				show();
				Root.I.Reset();
				show();
			} );
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                show();
            }
        }

        private void show()
        {
			if ( null != target )
			{
				target.gameObject.SetActive( true );
				Time.timeScale = 0;
			}
        }
    }
}

