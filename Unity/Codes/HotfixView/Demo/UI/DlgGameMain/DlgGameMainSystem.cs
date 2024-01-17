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
        }

		public static void ShowWindow(this DlgGameMain self, Entity contextData = null)
		{


			self.Refresh().Coroutine();
		}

		 
		public static async ETTask Refresh(this DlgGameMain self)
		{

			
			Unit unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            Log.Debug(numericComponent.GetAsInt((int)NumericType.Level)+ "RefreshRefreshRefresh"+ numericComponent.GetAsInt((int)NumericType.Gold));
            self.View.ELabel_LvText.SetText($"LV:{numericComponent.GetAsInt((int)NumericType.Level)}");
			self.View.ELabel_CoinText.SetText(numericComponent.GetAsInt((int)NumericType.Gold).ToString());


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
