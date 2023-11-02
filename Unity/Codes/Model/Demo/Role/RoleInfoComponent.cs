using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType]
    public class RoleInfoComponent :Entity,IAwake,IDestroy
    {
        public List<RoleInfo> RoleInfos = new List<RoleInfo>();  //存储游戏信息
        public long CurrentRoleId = 0;                          //角色ID


    }
}
