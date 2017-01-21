using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class LifeView : MonoBehaviour
	{
		private Text output = null;

		private void Awake()
		{
			output = GetComponent<Text>();
			Root.I.Get<Player>().OnChangeLife.AddListener( update_view );
			update_view();
		}

		private void update_view()
		{
			if ( null != output )
			{
				output.text = Root.I.Get<Player>().Life.ToString();
			}
		}
	}
}
