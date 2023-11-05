using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof(DlgServer))]
    [FriendClassAttribute(typeof(ET.ServerInfoComponent))]
    [FriendClassAttribute(typeof(ET.ServerInfo))]
    public static class DlgServerSystem
    {

        public static void RegisterUIEvent(this DlgServer self)
        {
            self.View.E_EnterServerButton.AddListenerAsync(() => { return self.EnterServerHandler(); });

            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollItemRefreshHandler(transform, index);
            });

        }

        public static void ShowWindow(this DlgServer self, Entity contextData = null)
        {
            int count = self.ZoneScene().GetComponent<ServerInfoComponent>().ServerInfoList.Count;


            Log.Debug("servercount " + count);
            self.AddUIScrollItems(ref self.ScrollItemServerTestDic, count);
            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void HideWindow(DlgServer self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemServerTestDic);

        }

        public static void OnSrcollItemRefreshHandler(this DlgServer self, Transform transform, int index)
        {
            Scroll_Item_serverTest serverTest = self.ScrollItemServerTestDic[index].BindTrans(transform);
            ServerInfo info = self.ZoneScene().GetComponent<ServerInfoComponent>().ServerInfoList[index];
            serverTest.EI_serverTestImage.color = info.Id == self.ZoneScene().GetComponent<ServerInfoComponent>().CurrentServerId ? Color.red : Color.cyan;
            serverTest.E_serverTestTipText.SetText(info.ServerName);
            serverTest.EButton_SelectButton.AddListener(() => self.OnSelectServerItemHandler(info.Id));


        }

        public static void OnSelectServerItemHandler(this DlgServer self ,long serverId)
        {
            self.ZoneScene().GetComponent<ServerInfoComponent>().CurrentServerId = int.Parse(serverId.ToString());
            Log.Debug($"当前选择的服务器Id 是：{serverId}");
            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.RefillCells();
        }


        public static async ETTask EnterServerHandler(this DlgServer self)
        {
            bool isSelect = self.ZoneScene().GetComponent<ServerInfoComponent>().CurrentServerId != 0;

            if (!isSelect)
            {
                Log.Error("请选择区服");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRoles(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                
                }

                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Server);
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Role);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }



            await ETTask.CompletedTask;
        }



    }
}
