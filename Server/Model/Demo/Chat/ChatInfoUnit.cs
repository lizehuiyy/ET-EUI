using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ChatInfoUnit:Entity,IAwake,IDestroy
    {
        public long GateSessionActorId;
        public string Name;

    }
}
