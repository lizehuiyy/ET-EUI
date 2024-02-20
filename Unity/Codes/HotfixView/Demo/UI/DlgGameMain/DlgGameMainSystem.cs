using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgGameMain))]
	public static  class DlgGameMainSystem
	{

		public static void RegisterUIEvent(this DlgGameMain self)
		{
             self.View.EButton_TestButton.AddListenAsync(() => { return self.OnTestClickHandler(); });
             self.View.EButton_HeroButton.AddListenAsync(() => { return self.OnHeroClickHandler(); });
             self.View.EButton_ChatButton.AddListenAsync(() => { return self.OnChatClickHandler(); });
             self.View.EButton_RankButton.AddListenAsync(() => { return self.OnRankClickHandler(); });
        }

		public static void ShowWindow(this DlgGameMain self, Entity contextData = null)
		{


			self.Refresh().Coroutine();
		}

		 
		public static async ETTask Refresh(this DlgGameMain self)
		{

			
			Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            Log.Debug(numericComponent.GetAsInt((int)NumericType.Level)+ "RefreshRefreshRefresh"+ numericComponent.GetAsInt((int)NumericType.Gold) + "MMR:" + numericComponent.GetAsInt((int)NumericType.MMR));
            self.View.ELabel_LvText.SetText($"LV:{numericComponent.GetAsInt((int)NumericType.Level)}");
			self.View.ELabel_CoinText.SetText($"Coin:{numericComponent.GetAsInt((int)NumericType.Gold)}");
            self.View.ELabel_MMRText.SetText($"MMR:{numericComponent.GetAsInt((int)NumericType.MMR)}");

            await ETTask.CompletedTask;
		}
        public static async ETTask OnHeroClickHandler(this DlgGameMain self)
        {
            Log.Debug("OnHeroClickHandler");
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_GameMain);
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_HeroMain);
            await ETTask.CompletedTask;
        }
        public static async ETTask OnChatClickHandler(this DlgGameMain self)
        {
            Log.Debug("OnChatClickHandler");
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Chat);
            await ETTask.CompletedTask;
        }
        public static async ETTask OnRankClickHandler(this DlgGameMain self)
        {
            Log.Debug("OnChatClickHandler");
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Rank);
            await ETTask.CompletedTask;
        }

        public static async ETTask OnTestClickHandler(this DlgGameMain self)
		{
            try
            {
				int error = await NumericHelp.TestUpdateNumeric(self.ZoneScene());
				if (error != ErrorCode.ERR_Success)
				{
					return;
				}
				Log.Debug("发送更新属性消息成功");
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }

            await ETTask.CompletedTask;
		}
    }
}
