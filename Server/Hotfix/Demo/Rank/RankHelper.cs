using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.RankInfo))]
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    public static class RankHelper
    {
        public static void AddOrUpdateLevelRank(Unit unit)
        {
            using (RankInfo rankInfo = unit.DomainScene().AddChild<RankInfo>())
            {
                rankInfo.UnitId = unit.Id;
                rankInfo.Name = unit.GetComponent<RoleInfo>().Name;
                rankInfo.MMR = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.MMR);

                Map2Rank_AddOrUpdateRankInfo message = new Map2Rank_AddOrUpdateRankInfo();
                message.RankInfo = rankInfo;
                long instanceId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(),"Rank").InstanceId;
                MessageHelper.SendActor(instanceId,message);


            }

        }
    }
}
