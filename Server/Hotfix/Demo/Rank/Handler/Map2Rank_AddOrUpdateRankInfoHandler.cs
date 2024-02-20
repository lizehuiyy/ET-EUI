using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Map2Rank_AddOrUpdateRankInfoHandler : AMActorHandler<Scene, Map2Rank_AddOrUpdateRankInfo>
    {
        protected override async ETTask Run(Scene scene, Map2Rank_AddOrUpdateRankInfo message)
        {
            RankInfoComponent rankInfoComponent = scene.GetComponent<RankInfoComponent>();
            rankInfoComponent.AddOrUpdate(message.RankInfo);
            await ETTask.CompletedTask;
        }
    }
}
