using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ChildType(typeof(ChatInfoUnit))]
    [ComponentOf(typeof(Scene))]

    public class ChatInfoUnitComponent  :Entity,IAwake,IDestroy
    {

        public Dictionary<long, ChatInfoUnit> ChatInfoUnitsDict = new Dictionary<long, ChatInfoUnit>();
    }
}
