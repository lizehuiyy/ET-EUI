using NLog.LayoutRenderers.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.ChatInfoUnit))]
    public class G2Chat_EnterChatHandler : AMActorRpcHandler<Scene, G2Chat_EnterChat, Chat2G_EnterChat>
    {
        protected override async ETTask Run(Scene scene, G2Chat_EnterChat request, Chat2G_EnterChat response, Action reply)
        {
            ChatInfoUnitComponent chatInfoUnitComponent = scene.GetComponent<ChatInfoUnitComponent>();

            ChatInfoUnit chatInfoUnit = chatInfoUnitComponent.Get(request.UnitId);

            if (chatInfoUnit != null && !chatInfoUnit.IsDisposed)
            {
                chatInfoUnit.Name = request.Name;
                chatInfoUnit.GateSessionActorId = request.GateSessionActorId;
                response.ChatInfoUnitInstanceId = chatInfoUnit.InstanceId;
                reply();
                return;
            }

            chatInfoUnit = chatInfoUnitComponent.AddChildWithId<ChatInfoUnit>(request.UnitId);
            chatInfoUnit.AddComponent<MailBoxComponent>();

            chatInfoUnit.Name = request.Name;
            chatInfoUnit.GateSessionActorId = request.GateSessionActorId;
            response.ChatInfoUnitInstanceId = chatInfoUnit.InstanceId;
            chatInfoUnitComponent.Add(chatInfoUnit);

            reply();
            await ETTask.CompletedTask;
        }
    }
}
