using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class TowerDescriptionView : MonoBehaviour
	{
		private Text output = null;

		private void Awake()
		{
			output = GetComponent<Text>();
			Root.I.Get<TowerManager>().OnChangeSelection.AddListener( update_view );
			update_view();
		}

		private void update_view()
		{
			Tower selection = Root.I.Get<TowerManager>().Current;
			output.text = "";

			if (
					null != output
				&&	null != selection
				&&	null != selection.Attack_Mode
			)
			{
				output.text = selection.Attack_Mode.ToString();
			}
		}
	}
}
