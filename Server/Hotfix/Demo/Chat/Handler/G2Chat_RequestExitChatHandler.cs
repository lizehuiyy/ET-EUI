using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class G2Chat_RequestExitChatHandler : AMActorRpcHandler<ChatInfoUnit, G2Chat_RequestExitChat, Chat2G_RequestExitChat>
    {
        protected override async ETTask Run(ChatInfoUnit unit, G2Chat_RequestExitChat request, Chat2G_RequestExitChat response, Action reply)
        {
            ChatInfoUnitComponent chatInfoUnitComponent = unit.DomainScene().GetComponent<ChatInfoUnitComponent>();
            chatInfoUnitComponent.Remove(unit.Id);

            reply();

            await ETTask.CompletedTask;
        }
    }
}
