using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.RankInfoComponent))]
    public class C2Rank_GetRankInfoHandler : AMActorRpcHandler<Scene, C2Rank_GetRankInfo, Rank2C_GetRankInfo>
    {
        protected override async ETTask Run(Scene scene, C2Rank_GetRankInfo request, Rank2C_GetRankInfo response, Action reply)
        {
            RankInfoComponent rankInfoComponent = scene.GetComponent<RankInfoComponent>();

            foreach (var rankInfo in rankInfoComponent.SortedRankInfoList)
            {
                response.RankInfoProtoList.Add(rankInfo.Key.ToMessage());
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
