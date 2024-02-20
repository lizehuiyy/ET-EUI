using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class ChatHelper
    {
        public static async ETTask<int> SendMessage(Scene ZoneScene, string message)
        {
            if (String.IsNullOrEmpty(message))
            {
                return ErrorCode.ERR_ChatMessageEmpty;
            }

            Chat2C_SendChatInfo chat2C_SendChatInfo = null;
            try
            {
                chat2C_SendChatInfo = (Chat2C_SendChatInfo)await ZoneScene.GetComponent<SessionComponent>().Session.Call(new C2Chat_SendChatInfo() { ChatMessage = message });
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }
            if (chat2C_SendChatInfo.Error != ErrorCode.ERR_Success)
            {
                return chat2C_SendChatInfo.Error;
            }


            return ErrorCode.ERR_Success;
        }




    }
}
