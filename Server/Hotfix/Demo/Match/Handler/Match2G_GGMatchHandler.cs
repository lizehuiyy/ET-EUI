using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.GateMapComponent))]
    public class Match2G_GGMatchHandler : AMActorRpcHandler<Scene, Match2G_GGMatch, G2Match_GGMatch>
    {

        protected override async ETTask Run(Scene scene, Match2G_GGMatch request, G2Match_GGMatch response, Action reply)
        {


            //Player player = Game.EventSystem.Get(request.PlayerInstanceId) as Player;
            //GateMapComponent gateMapComponent = player.GetComponent<GateMapComponent>();
            //Unit unit = await UnitCacheHelper.GetUnitCache(gateMapComponent.Scene, player.UnitId);
            //if (unit.GetComponent<UnitGateComponent>() == null)
            //    unit.AddComponent<UnitGateComponent, long>(player.InstanceId);

            Unit unit = scene.GetComponent<UnitComponent>().Get(request.UnitId);

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
            int newMMR = 0;
            if (request.Win == 1)
                newMMR = numericComponent.GetAsInt(NumericType.MMR) + 25;
            else
                newMMR = numericComponent.GetAsInt(NumericType.MMR) - 25;
            if (newMMR < 0)
            {
                newMMR = 0;
            }
            numericComponent.Set(NumericType.MMR, newMMR);
            reply();
          
            //RankHelper.AddOrUpdateLevelRank(unit);

            
            await ETTask.CompletedTask;
        }
    }
}
