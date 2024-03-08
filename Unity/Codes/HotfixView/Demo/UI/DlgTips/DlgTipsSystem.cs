using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace ET
{
	[FriendClass(typeof(DlgTips))]
	public static  class DlgTipsSystem
	{

		public static void RegisterUIEvent(this DlgTips self)
		{
            self.View.EButton_XButton.onClick.AddListener(() => self.OnCloseHandler());
        }


        public static void ShowWindow(this DlgTips self, Entity contextData = null)
		{
            self.View.EBackGroudImage.transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0);
			self.View.EBackGroudImage.transform.DOScale(Vector3.one, 0.3f);


        }
        public static void OnCloseHandler(this DlgTips self)
        {
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Tips);

        }

        public static void ShowText(this DlgTips self,string text)
		{
			self.View.ELabel_TipText.text = text;
		
		
		}
		 

	}
}
