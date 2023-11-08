using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing.Printing;
using System.Xml.Linq;

namespace ET
{
    [FriendClass(typeof(DlgRole))]
    [FriendClassAttribute(typeof(ET.RoleInfoComponent))]
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    public static class DlgRoleSystem
    {

        public static void RegisterUIEvent(this DlgRole self)
        {
            self.View.EButton_ConfirmButton.AddListenerAsync(() => { return self.OnClickConfirmHandler(); });
            self.View.EButton_CreateButton.AddListenerAsync(() => { return self.OnClickCreateHandler(); });
            self.View.EButton_DeleteButton.AddListenerAsync(() => { return self.OnClickDeleteHandler(); });
            self.View.ELoopScrollList_RoleLoopHorizontalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnRoleListRefreshHandler(transform, index);
            });
        }

        public static void ShowWindow(this DlgRole self, Entity contextData = null)
        {
            self.RefreshRoleItems();
        }


        public static void RefreshRoleItems(this DlgRole self)
        {
            int count = self.ZoneScene().GetComponent<RoleInfoComponent>().RoleInfos.Count;
            Log.Debug("count" + count);
            self.AddUIScrollItems(ref self.ScrollItemRoles, count);
            self.View.ELoopScrollList_RoleLoopHorizontalScrollRect.SetVisible(true, count);

        }

        public static void OnRoleListRefreshHandler(this DlgRole self, Transform transform, int index)
        {
            Scroll_Item_role scroll_Item_Role = self.ScrollItemRoles[index].BindTrans(transform);
            RoleInfo info = self.ZoneScene().GetComponent<RoleInfoComponent>().RoleInfos[index];

            scroll_Item_Role.EI_RoleImageImage.color = info.Id == self.ZoneScene().GetComponent<RoleInfoComponent>().CurrentRoleId ? Color.green : Color.gray;
            scroll_Item_Role.E_serverTestTipText.SetText(info.Name);
            scroll_Item_Role.EButton_SelectButton.AddListener(() => { self.OnRoleItemClickHandler(info.Id); });

        }
        public static void OnRoleItemClickHandler(this DlgRole self,long roleId)
        {
            self.ZoneScene().GetComponent<RoleInfoComponent>().CurrentRoleId = roleId;
            self.View.ELoopScrollList_RoleLoopHorizontalScrollRect.RefillCells();


        }


        public static async ETTask OnClickConfirmHandler(this DlgRole self)
        {
            if (self.ZoneScene().GetComponent<RoleInfoComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择你的角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error("GetRealmKey Error" + errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.EnterGame(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error("GetRealmKey Error" + errorCode.ToString());
                    return;
                }


            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            await ETTask.CompletedTask;
        }
        public static async ETTask OnClickCreateHandler(this DlgRole self)
        {
            string name = self.View.EInputField_TextText.text;
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("name is null");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }



            await ETTask.CompletedTask;
        }
        public static async ETTask OnClickDeleteHandler(this DlgRole self)
        {
            if (self.ZoneScene().GetComponent<RoleInfoComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择需要删除的角色");
                return;
            }
            try
            {
                int errorCode = await LoginHelper.DeleteRole(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.RefreshRoleItems();


            }
            catch (Exception e)
            {
                Log.Error(e.ToString());

            }


            await ETTask.CompletedTask;
        }
    




    }
}
