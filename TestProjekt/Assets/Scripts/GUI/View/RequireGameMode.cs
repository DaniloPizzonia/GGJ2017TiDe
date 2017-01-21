using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace unsernamespace
{
	public class RequireGameMode : MonoBehaviour
	{
		[SerializeField]
		private GameModeType type;

		private void Awake()
		{
			Root.I.Get<GameModeManager>().OnChange.AddListener( update_view );
			update_view();
		}

		private void update_view()
		{
			gameObject.SetActive( Root.I.Get<GameModeManager>().Current.Type == type );
		}
	}
}
