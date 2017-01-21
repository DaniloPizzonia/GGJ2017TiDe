using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace unsernamespace
{
	public class TowerBuyButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject delegate_prefab;
		[SerializeField]
		private Sprite icon_active;
		[SerializeField]
		private Sprite icon_normal;
		[SerializeField]
		private Image image;
		[SerializeField]
		private Text description;

		private TowerDelegate last_instance;

		private TowerDelegate current
		{
			get
			{
				return FindObjectOfType<TowerDelegate>();
			}
		}

		protected int price
		{
			get
			{
				return delegate_prefab.GetComponent<TowerDelegate>().Price;
			}
		}

		protected bool buyable
		{
			get
			{
				return Root.I.Get<Player>().CheckMoney( price ); ;
			}
		}

		private void Awake()
		{
			Root.I.Get<GameModeManager>().OnChange.AddListener( update_icon_all );
		}

		public void Click()
		{
			TowerDelegate current = this.current;
			clear();

			if (
					null == current
				||	current != last_instance
			)
			{
				if ( buyable )
				{
					GameObject container = Instantiate( delegate_prefab );
					TowerDelegate new_delegate = container.GetComponent<TowerDelegate>();
					new_delegate.onLeave.AddListener( clear );
					description.text = Root.I.Get<Localization>()[ "description_" + new_delegate.Name ];
				}
			}

			update_icon();
		}

		private void clear()
		{
			foreach ( TowerDelegate buy_delegate in FindObjectsOfType<TowerDelegate>() )
			{
				Destroy( buy_delegate.gameObject );
			}
			update_icon_all();
		}

		private void update_icon_all()
		{
			foreach( TowerBuyButton btn in FindObjectsOfType<TowerBuyButton>() )
			{
				btn.update_icon();
			}
		}

		private void update_icon()
		{
			if (
					null != current
				&&	current == last_instance
			)
			{
				image.sprite = icon_active;
			}
			else
			{
				image.sprite = icon_normal;
				Button button = image.GetComponent<Button>();
				if ( null != button )
				{
					button.interactable = buyable;
				}
			}
		}
	}
}
