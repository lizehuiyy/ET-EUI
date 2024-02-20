using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.RankInfoComponent))]
    [FriendClassAttribute(typeof(ET.RankInfo))]
    public static class RankInfoComponentSystem
    {
        public static async ETTask LoadRankInfo(this RankInfoComponent self)
        {
            var rankInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<RankInfo>(d => true, collection: "RankInfoComponent");
            foreach (RankInfo rankInfo in rankInfoList)
            {
                self.AddChild(rankInfo);
                self.RankInfosDictionary.Add(rankInfo.UnitId, rankInfo);
                self.SortedRankInfoList.Add(rankInfo,rankInfo.UnitId);

            }

        }

        public static void AddOrUpdate(this RankInfoComponent self,RankInfo newRankInfo)
        {
            if (self.RankInfosDictionary.ContainsKey(newRankInfo.UnitId))
            {
                RankInfo oldRankInfo = self.RankInfosDictionary[newRankInfo.UnitId];
                if (oldRankInfo.MMR == newRankInfo.MMR)
                {
                    return;
                }
                DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Remove<RankInfo>(oldRankInfo.UnitId,oldRankInfo.Id,"RankInfoComponent").Coroutine();
                self.RankInfosDictionary.Remove(oldRankInfo.UnitId);
                self.SortedRankInfoList.Remove(oldRankInfo);
                oldRankInfo?.Dispose();
                    
            
            }
            self.AddChild(newRankInfo);
            self.RankInfosDictionary.Add(newRankInfo.UnitId,newRankInfo);
            self.SortedRankInfoList.Add(newRankInfo,newRankInfo.UnitId);
            DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newRankInfo.UnitId, newRankInfo, "RankInfoComponent").Coroutine();
        
        }



    }
}
