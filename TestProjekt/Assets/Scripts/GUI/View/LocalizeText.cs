using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class LocalizeText : MonoBehaviour
	{
		[SerializeField]
		private string term;

		private void Awake()
		{
			Text text = GetComponent<Text>();
			if ( null != text )
			{
				text.text = Root.I.Get<Localization>()[ term ];
			}
		}
	}
}
