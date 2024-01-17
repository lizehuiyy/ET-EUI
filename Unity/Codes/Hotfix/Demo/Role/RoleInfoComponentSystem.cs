using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class RoleInfoComponentDestroySystem : DestroySystem<RoleInfoComponent>
    {
        public override void Destroy(RoleInfoComponent self)
        {
            foreach (var roleinfo in self.RoleInfos)
            {
                roleinfo?.Dispose();
            }
            self.RoleInfos.Clear();
            self.CurrentRoleId = 0;


        }
    }




    public static class RoleInfoComponentSystem
    {



    }
}
