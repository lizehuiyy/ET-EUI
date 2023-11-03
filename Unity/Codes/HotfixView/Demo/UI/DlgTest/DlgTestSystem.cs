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

			self.View.ELoopScrollList_LoopHorizontalScrollRect.AddItemRefreshListener((Transform transform, int index) => 
			{
				self.OnLoopListItemRefreshHandler(transform, index);
			});
		}

		public static void ShowWindow(this DlgTest self, Entity contextData = null)
		{
			self.View.EText_TestText.text = "niubi";
			self.View.ESCommonUI.SetLabelContent("测试界面");

			int count = 100;
			self.AddUIScrollItems(ref self.ScrollItemServerTestDic, count);
			self.View.ELoopScrollList_LoopHorizontalScrollRect.SetVisible(true,count);
		}

		public static void HideWindow(this DlgTest self)
		{
			self.RemoveUIScrollItems(ref self.ScrollItemServerTestDic);
		}

		public static void OnEnterMapClickHandler(this DlgTest self)
		{
			Log.Debug("Enter Map");
		
		}

		public static void OnLoopListItemRefreshHandler(this DlgTest self, Transform transform,int index)
		{
			Scroll_Item_serverTest itemServerTest = self.ScrollItemServerTestDic[index].BindTrans(transform);

			itemServerTest.E_serverTestTipText.text = $"{index}服";



		}
		 

	}
}
