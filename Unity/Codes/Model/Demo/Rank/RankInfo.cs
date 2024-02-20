using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class RankInfo :Entity,IAwake,IDestroy
    {
        public long UnitId = 0;
        public string Name = string.Empty;
        public int MMR = 0;

    }
}
