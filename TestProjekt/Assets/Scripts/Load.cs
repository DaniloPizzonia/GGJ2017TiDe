using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class Load : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Root.I.Get<BotManager>().SpawnBot();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

