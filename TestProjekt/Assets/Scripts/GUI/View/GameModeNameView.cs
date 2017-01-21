using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class GameModeNameView : MonoBehaviour
	{
		private Text output = null;

		private void Awake()
		{
			output = GetComponent<Text>();
			Root.I.Get<GameModeManager>().OnChange.AddListener( update_view );
			update_view();
		}

		private void update_view()
		{
			if ( null != output )
			{
				string mode = Root.I.Get<GameModeManager>().Current.Type.ToString();
				output.text = Root.I.Get<Localization>()[ mode ];
			}
		}
	}
}
