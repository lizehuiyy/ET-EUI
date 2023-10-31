using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ChildType(typeof(ServerInfo))]
    public class ServerInfoManagerComponent:Entity,IAwake,IDestroy,ILoad
    {
        public List<ServerInfo> ServerInfo = new List<ServerInfo>();


    }
}
