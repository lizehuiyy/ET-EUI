using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.ChatInfoUnitComponent))]
    [FriendClassAttribute(typeof(ET.ChatInfoUnit))]
    public class C2Chat_SendChatInfoHandler : AMActorRpcHandler<ChatInfoUnit, C2Chat_SendChatInfo, Chat2C_SendChatInfo>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2Chat_SendChatInfo request, Chat2C_SendChatInfo response, Action reply)
        {
            if (string.IsNullOrEmpty(request.ChatMessage))
            {
                response.Error = ErrorCode.ERR_ChatMessageEmpty;
                reply();
                return;
            }

            ChatInfoUnitComponent chatInfoUnitComponent = chatInfoUnit.DomainScene().GetComponent<ChatInfoUnitComponent>();


            foreach (var otherUnit in chatInfoUnitComponent.ChatInfoUnitsDict.Values)
            {
                MessageHelper.SendActor(otherUnit.GateSessionActorId, new Chat2C_NoticeChatInfo()
                {
                    Name = chatInfoUnit.Name,
                    ChatMessage = request.ChatMessage,
                });
            }

            reply();
            await ETTask.CompletedTask;


        }
    }
}
