using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ChildType]
    public class Gamer:Entity,IAwake,IDestroy
    {
        /// <summary>
        /// 来自数据库中的永久ID
        /// </summary>
        public long UserID { get; set; }
        public long GateSessionActorId { get; set; }
        public string Name { get; set; }
        public int MMR { get; set; }
        /// <summary>
        /// 玩家GateActorID
        /// </summary>
        public long GActorID { get; set; }
        /// <summary>
        /// 玩家ClientActorID
        /// </summary>
        public long CActorID { get; set; }
        /// <summary>
        /// 默认为假 Session断开/离开房间时触发离线
        /// </summary>
        public bool isOffline { get; set; }
    }
}
