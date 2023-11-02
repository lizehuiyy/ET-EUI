using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgTest))]
	public static  class DlgTestSystem
	{

		public static void RegisterUIEvent(this DlgTest self)
		{
            self.View.E_EnterMapButton.onClick.AddListener(self.OnEnterMapClickHandler);
		}

		public static void ShowWindow(this DlgTest self, Entity contextData = null)
		{
			self.View.EText_TestText.text = "niubi";
		}

		public static void OnEnterMapClickHandler(this DlgTest self)
		{
			Log.Debug("Enter Map");
		
		}
		 

	}
}
