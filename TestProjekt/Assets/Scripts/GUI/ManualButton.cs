using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class ManualButton : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Transform targetTwo;

        public void Click()
        {
            target.gameObject.SetActive(true);
            targetTwo.gameObject.SetActive(false);
        }
    }

}
