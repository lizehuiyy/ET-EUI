using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf]
    public class GameControllerComponent:Entity,IAwake,IDestroy
    {
        public int Round;//回合
        public Dictionary<long, int> BuffList;



    }
}
