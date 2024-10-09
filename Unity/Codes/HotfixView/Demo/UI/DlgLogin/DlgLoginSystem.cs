using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using ILRuntime.Runtime;
using UnityEngine.Windows;


namespace ET
{
    public static class DlgLoginSystem
    {

        public static void RegisterUIEvent(this DlgLogin self)
        {
            self.View.E_LoginButton.AddListenAsync(() => { return self.OnLoginClickHandler(); });
        }

        public static void ShowWindow(this DlgLogin self, Entity contextData = null)
        {

            //测试代码
            //Vector3 back = new Vector3(0, -276, 0);
            //Vector3 target = self.View.E_LoginImage.transform.parent.parent.position + new Vector3(0,0,-20);
            //Vector3 local = new Vector3(0, -176, 0);

            //self.View.E_LoginButton.transform.DOLocalMove(back, 0.2f).OnComplete(() => {
            //self.View.E_LoginButton.transform.DOMove(target, 0.2f).SetDelay(0.3f).OnComplete(() => {
            //    //self.View.E_LoginButton.transform.DOLocalMove(local, 0.2f).OnComplete(() => {


            //    //});
            //});
            //});
            Log.Debug("login");
            //Vector3 target = new Vector3(0, 0, -1080);
            //self.View.E_LoginButton.transform.DORotate(target, 3f, RotateMode.FastBeyond360).OnComplete(() =>
            //{

            //});



            //string binaryString = "1111011"; // 二进制字符串
            //int bit = Convert.ToInt32(binaryString, 2);
            //int bit0 = (bit >> 2) & 1;
            //Log.Debug(bit0 + "");
            //self.View.EGprite_CoinRectTransform.transform.DOLocalRotate(new Vector3(0,360*10,0), 2f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);





            self.View.ESCommonUI.SetLabelContent("登录界面");
        }

        public static async ETTask OnLoginClickHandler(this DlgLogin self)
        {
            try
            {
                int errorCode = await LoginHelper.Login(
                    self.DomainScene(),
                    ConstValue.LoginAddress,
                    self.View.E_AccountInputField.GetComponent<InputField>().text,
                    self.View.E_PasswordInputField.GetComponent<InputField>().text);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error("errorCode:" + errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.GetServerInfos(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }



                //显示登录成功之后的逻辑
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Server);
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
