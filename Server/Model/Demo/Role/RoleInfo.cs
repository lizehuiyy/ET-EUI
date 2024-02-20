using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{


    public enum RoleInfoState
    {
        Normal = 0,
        Freeze = 1,



    }

    [ComponentOf]
#if SERVER
    public class RoleInfo : Entity, IAwake, ITransfer, IUnitCache
#else
      public class RoleInfo : Entity,IAwake
#endif
    {
        public string Name;

        public int ServerId;

        public int State;

        public long AccountId;

        public long LastLoginTime;

        public long CreateTime;


    }
}
