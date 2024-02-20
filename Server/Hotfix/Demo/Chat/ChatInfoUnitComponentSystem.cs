using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ChatInfoUnitComponentDestroy : DestroySystem<ChatInfoUnitComponent>
    {
        public override void Destroy(ChatInfoUnitComponent self)
        {
            foreach (var chatInfoUnit in self.ChatInfoUnitsDict.Values)
            {
                chatInfoUnit?.Dispose();
            }
        }
    }
    [FriendClassAttribute(typeof(ET.ChatInfoUnitComponent))]
    public static class ChatInfoUnitComponentSystem
    {
        public static void Add(this ChatInfoUnitComponent self, ChatInfoUnit chatInfoUnit)
        {
            if (self.ChatInfoUnitsDict.ContainsKey(chatInfoUnit.Id))
            {
                Log.Error($"chatInfoUnit is exist!:{chatInfoUnit.Id}");
                return;
            }
            self.ChatInfoUnitsDict.Add(chatInfoUnit.Id,chatInfoUnit);

        }

        public static ChatInfoUnit Get(this ChatInfoUnitComponent self, long id)
        {
            self.ChatInfoUnitsDict.TryGetValue(id, out ChatInfoUnit chatInfoUnit);
            return chatInfoUnit;
        
        }

        public static void Remove(this ChatInfoUnitComponent self,long id)
        {
            if (self.ChatInfoUnitsDict.TryGetValue(id,out ChatInfoUnit chatInfoUnit))
            {
                self.ChatInfoUnitsDict.Remove(id);
                chatInfoUnit?.Dispose();
            }
        
        }


    }
}
