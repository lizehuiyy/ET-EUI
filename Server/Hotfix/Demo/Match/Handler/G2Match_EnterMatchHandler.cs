using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class G2Match_EnterMatchHandler : AMActorRpcHandler<Scene,G2Match_EnterMatch,Match2G_EnterMatch>
    {
        protected override async ETTask Run(Scene scene, G2Match_EnterMatch request, Match2G_EnterMatch response, Action reply)
        {
            LandMatchComponent matchComponent = scene.GetComponent<LandMatchComponent>();

            //Room room = matchComponent.Get(request.UnitId);

            //if (room != null && !room.IsDisposed)
            //{
            //    Gamer gamer = room.GetGamerFromUserID(request.UnitId);


            //    gamer.GateSessionActorId = request.GateSessionActorId;
            //    gamer.Name = request.Name;
            //    response.MatchInfoUnitInstanceId = gamer.InstanceId;
            //    //chatInfoUnit.Name = request.Name;
            //    //chatInfoUnit.GateSessionActorId = request.GateSessionActorId;
            //    //response.ChatInfoUnitInstanceId = chatInfoUnit.InstanceId;
            //    reply();
            //}
            //else
            //{
                Gamer gamer = matchComponent.AddChildWithId<Gamer>(request.UnitId);
                gamer.AddComponent<MailBoxComponent>();


                gamer.UserID = request.UnitId;
                gamer.GateSessionActorId = request.GateSessionActorId;
                gamer.Name = request.Name;
                gamer.MMR = request.MMR;
                response.MatchInfoUnitInstanceId = gamer.InstanceId;
                

                //登录land服务器添加dic
                matchComponent.AddLandMatch(gamer);

                //matchComponent.AddGamerToMatchingQueue(gamer);
                //告诉玩家进入寻找比赛队列成功    并不是寻找比赛成功
                reply();

            //}

            await ETTask.CompletedTask;
        }
    }
}
