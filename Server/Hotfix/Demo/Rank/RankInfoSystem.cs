using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.RankInfo))]
    public static class RankInfoSystem
    {

        public static void FromMessage(this RankInfo self, RankInfoProto rankInfoProto)
        {
            self.Id = rankInfoProto.ID;
            self.UnitId = rankInfoProto.UnitId;
            self.Name = rankInfoProto.Name;
            self.MMR = rankInfoProto.MMR;
        }

        public static RankInfoProto ToMessage(this RankInfo self)
        {
            RankInfoProto rankInfoProto = new RankInfoProto();
            rankInfoProto.ID = self.Id;
            rankInfoProto.UnitId = self.UnitId;
            rankInfoProto.Name = self.Name;
            rankInfoProto.MMR = self.MMR;
            return rankInfoProto;
        }

    }
}
