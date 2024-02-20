using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.ChatInfo))]
    public class Chat2C_NoiceChatInfoHandler : AMHandler<Chat2C_NoticeChatInfo>
    {
        protected override void Run(Session session, Chat2C_NoticeChatInfo message)
        {
            ChatInfo chatInfo = session.DomainScene().GetComponent<ChatComponent>().AddChild<ChatInfo>(true);
            chatInfo.Name = message.Name;
            Log.Debug("message.Name"+ chatInfo.Name);
            chatInfo.Message = message.ChatMessage;
            session.DomainScene().GetComponent<ChatComponent>().Add(chatInfo);
            Game.EventSystem.Publish(new EventType.UpdateChatInfo() { zoneScene = session.ZoneScene()});
        }
    }
}
