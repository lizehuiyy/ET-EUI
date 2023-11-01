using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{

    public class ServerInfoComponentDestroySystem : DestroySystem<ServerInfoComponent>
    {
        public override void Destroy(ServerInfoComponent self)
        {
            foreach (var serverinfo in self.ServerInfoList)
            {
                serverinfo?.Dispose();
            }
            self.ServerInfoList.Clear();
        }
    }
    [FriendClassAttribute(typeof(ET.ServerInfoComponent))]
    public static class ServerInfoComponentSystem
    {
        public static void Add(this ServerInfoComponent self, ServerInfo serverInfo)
        {
            self.ServerInfoList.Add(serverInfo);

        }


    }
}
