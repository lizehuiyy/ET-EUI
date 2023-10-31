﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgLoginSystem
	{

		public static void RegisterUIEvent(this DlgLogin self)
		{
			self.View.E_LoginButton.AddListenAsync(() => {return  self.OnLoginClickHandler();});
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{
			
		}
		
		public static async ETTask OnLoginClickHandler(this DlgLogin self)
		{
			try 
			{
                int errorCode =  await LoginHelper.Login(
                    self.DomainScene(),
                    ConstValue.LoginAddress,
                    self.View.E_AccountInputField.GetComponent<InputField>().text,
                    self.View.E_PasswordInputField.GetComponent<InputField>().text);
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error("errorCode:" + errorCode.ToString());
					return;
				}
				//显示登录成功之后的逻辑
				self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
            } 
			catch (Exception e)
			{
				Log.Debug(e.ToString());
			}
			
		}
		
		public static void HideWindow(this DlgLogin self)
		{

		}
		
	}
}
