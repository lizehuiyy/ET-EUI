using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class RankHelper
    {

        public static async ETTask<int> GetRankInfo(Scene zoneScene)
        {
            Rank2C_GetRankInfo rank2C_GetRankInfo = null;
            try
            {
                rank2C_GetRankInfo = (Rank2C_GetRankInfo)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2Rank_GetRankInfo() { });

            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_Success;
            }
            if (rank2C_GetRankInfo.Error != ErrorCode.ERR_Success)
            {
                return rank2C_GetRankInfo.Error;
            }



            zoneScene.GetComponent<RankComponent>().ClearAll();
            for (int i = 0; i < rank2C_GetRankInfo.RankInfoProtoList.Count; i++)
            {
                zoneScene.GetComponent<RankComponent>().Add(rank2C_GetRankInfo.RankInfoProtoList[i]);
            }

            return rank2C_GetRankInfo.Error;
        }

    }
}
