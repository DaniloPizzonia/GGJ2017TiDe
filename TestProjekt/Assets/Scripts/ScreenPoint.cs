using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace unsernamespace
{
    public class ScreenPoint : MonoBehaviour
    {
        public Image HealthBarPrefab = null;
        private List<Image> healthBars = new List<Image>();
        

        private float fillAmountHealthBar = 0.0f;
        // Use this for initialization
        void Start()
        {
           
            Transform parent = HealthBarPrefab.transform.parent;
            for (int i = 0; i < 30; i++)
            {
                GameObject go = Instantiate(HealthBarPrefab.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
                go.transform.SetParent(parent);
                go.SetActive(false);
                healthBars.Add(go.GetComponent<Image>());
            }
        }

        // Update is called once per frame
        void Update()
        {
            
       
            var botList = Root.I.Get<BotManager>().AllBots;
            for (int i = 0; i < botList.Length; i++)
            {
                var bot = botList[i];
                Vector3 screenPos = Camera.main.WorldToScreenPoint(bot.transform.position+new Vector3(0,2));
                var a = bot.Health / bot.MaxHealth * 100;
                Image img = healthBars[i];
                img.fillAmount = a;
                img.transform.localPosition = screenPos;
                img.gameObject.SetActive(true);
                //Fill Amount von der Gesundheit
                // Gesundheit von den Bots
                
            }
            if (healthBars.Count > botList.Length)
            {
                for (int i = botList.Length; i < healthBars.Count; i++)
                {
                    healthBars[i].gameObject.SetActive(false);
                }
            }
            
        }
    }
}

