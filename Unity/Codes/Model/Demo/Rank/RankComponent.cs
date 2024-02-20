using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ChildType(typeof(RankInfo))]
    [ComponentOf(typeof(Scene))]
    public class RankComponent:Entity,IAwake,IDestroy
    {
        public List<RankInfo> RankInfos = new List<RankInfo>(100);


    }
}
