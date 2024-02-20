using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ChatComponentDestroySystem : DestroySystem<ChatComponent>
    {
        public override void Destroy(ChatComponent self)
        {
            foreach (var chatInfo in self.ChatMessageQueue)
            {
                chatInfo?.Dispose();
            }
            self.ChatMessageQueue.Clear();
        }
    }
    [FriendClassAttribute(typeof(ET.ChatComponent))]
    public static class ChatComponentSystem
    {
        
        public static void Add(this ChatComponent self,ChatInfo chatInfo)
        {
            if (self.ChatMessageQueue.Count>=100)
            {
                ChatInfo oldChatInfo = self.ChatMessageQueue.Dequeue();
                oldChatInfo?.Dispose();
            }
            self.ChatMessageQueue.Enqueue(chatInfo);
        }


        public static int GetChatMessageCount(this ChatComponent self)
        {
            return self.ChatMessageQueue.Count;
        }
        public static ChatInfo GetChatMessageByIndex(this ChatComponent self, int index)
        {

            Log.Debug("GetChatMessageByIndex" + self.ChatMessageQueue.Count);
            ChatInfo[] queueArray = self.ChatMessageQueue.ToArray();
            return queueArray[index];
        
        }

    }
}
