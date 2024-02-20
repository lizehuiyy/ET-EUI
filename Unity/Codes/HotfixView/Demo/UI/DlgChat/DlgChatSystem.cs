using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof(DlgChat))]
    [FriendClassAttribute(typeof(ET.ChatInfo))]
    [FriendClassAttribute(typeof(ET.ChatComponent))]
    public static class DlgChatSystem
    {

        public static void RegisterUIEvent(this DlgChat self)
        {
            self.RegisterCloseEvent<DlgChat>(self.View.EButton_CloseButton);
            self.View.EButton_SendButton.AddListenAsync(self.OnSendMessageClickHandler);
            self.View.ELoopScrollList_ChatLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnChatHandler(transform, index);
            });
        }

        public static void ShowWindow(this DlgChat self, Entity contextData = null)
        {
            Log.Debug("ShowWindowRefresh");
            self.Refresh();
        }

        public static void Refresh(this DlgChat self)
        {
            int count = self.ZoneScene().GetComponent<ChatComponent>().GetChatMessageCount();
            self.AddUIScrollItems(ref self.ScrollItemChatDic, count);
            self.View.ELoopScrollList_ChatLoopVerticalScrollRect.SetVisible(true, count);
            self.View.ELoopScrollList_ChatLoopVerticalScrollRect.RefillCells();
        }
        public static void OnChatHandler(this DlgChat self, Transform transform, int index)
        {
            Scroll_Item_chat scroll_Item_Chat = self.ScrollItemChatDic[index].BindTrans(transform);
            Log.Debug("index:"+index.ToString() + self.ZoneScene().GetComponent<ChatComponent>());
            ChatInfo chatinfo = self.ZoneScene().GetComponent<ChatComponent>().GetChatMessageByIndex(index);
    
       
            Log.Debug(index + "chatinfo.Name" + chatinfo.Name + "" + chatinfo.Message);
            scroll_Item_Chat.ELabel_NameText.SetText(chatinfo.Name + ":");
            scroll_Item_Chat.ELabel_chatText.SetText(chatinfo.Message);
        }
        public static async ETTask OnSendMessageClickHandler(this DlgChat self)
        {
            try
            {
                int errorCode = await ChatHelper.SendMessage(self.ZoneScene(), self.View.EInputFieldInputField.text);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                Log.Debug("OnSendMessageClickHandlerRefresh");
                //self.Refresh();

            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }






            await ETTask.CompletedTask;
        }



    }
}
