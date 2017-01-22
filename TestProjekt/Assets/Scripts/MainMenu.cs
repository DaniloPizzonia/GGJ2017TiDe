using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        public Transform target;
      //  public Text levelText = null;

        void Start()
        {
            target.gameObject.SetActive(true);
            Time.timeScale = 0;
            //SetHighestScore();
        }

      /*  public void SetHighestScore()
        {
            int level = Root.I.Get<GameModeManager>().Current.Level;
            levelText.text = "Level Record: <b><size=36>" + level + "</size></b>";
        }*/
    }
}

