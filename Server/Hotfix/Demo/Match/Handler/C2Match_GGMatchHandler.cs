using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OfficeOpenXml.FormulaParsing.EpplusExcelDataProvider;

namespace ET
{
    [FriendClassAttribute(typeof(ET.Room))]
    public class C2Match_GGMatchHandler : AMActorRpcHandler<Gamer, C2Match_GGMatch, Match2C_GGMatch>
    {
        protected override async ETTask Run(Gamer gamer, C2Match_GGMatch request, Match2C_GGMatch response, Action reply)
        {

            LandMatchComponent matchComponent = gamer.DomainScene().GetComponent<LandMatchComponent>();

            Room room = matchComponent.GetPlayingRoom(gamer.UserID);

            foreach (Gamer gamers in room.gamers)
            {

                Match2G_GGMatch message = new Match2G_GGMatch();
                
                long instanceId = gamers.GateSessionActorId;
                message.UnitId = gamers.UserID;
                message.PlayerInstanceId = gamers.PlayerInstanceId;
                if (gamers.UserID == gamer.UserID)
                {
                    message.Win = 0;
                    
                }
                else
                {
                    message.Win = 1;
                }

                StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(gamers.DomainZone(), "Map");
                G2Match_GGMatch g2Match_GGMatch = (G2Match_GGMatch)await MessageHelper.CallActor(startSceneConfig.InstanceId, message);

            }


             reply();

            await ETTask.CompletedTask;
        }
    }
}
