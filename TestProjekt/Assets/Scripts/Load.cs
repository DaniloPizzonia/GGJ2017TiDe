using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unsernamespace
{
    public class Load : MonoBehaviour
    {
        void Start()
        {
			Root.I.Get<GameModeManager>();
        }
    }
}

