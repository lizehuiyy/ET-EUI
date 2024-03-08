using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class G2Match_RequestExitMatchHandler : AMActorRpcHandler<Gamer, G2Match_RequestExitMatch, Match2G_RequestExitMatch>
    {
        protected override async ETTask Run(Gamer gamer, G2Match_RequestExitMatch request, Match2G_RequestExitMatch response, Action reply)
        {
            LandMatchComponent landMatchComponent = gamer.DomainScene().GetComponent<LandMatchComponent>();
            landMatchComponent.RemoveLandMatch(gamer.Id);
            landMatchComponent.RemoveGamingMatch(gamer.Id);
            landMatchComponent.RemoveFreeLandMatch(gamer.Id);
            landMatchComponent.RemoveWaitingMatch(gamer.Id);
            landMatchComponent.RemovePlayingMatch(gamer.Id);

            reply();
            await ETTask.CompletedTask;
        }
    }
}
