using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{

    [ComponentOf]
    [ChildType]
    public class Room :Entity ,IAwake,IDestroy
    {
        /// <summary>
        /// 当前房间的2个座位 UserID/seatIndex
        /// </summary>
        public readonly Dictionary<long, int> seats = new Dictionary<long, int>();

        /// <summary>
        /// 当前房间的所有所有玩家 空位为null
        /// </summary>
        public readonly Gamer[] gamers = new Gamer[2];

        /// <summary>
        /// 房间中玩家的数量
        /// </summary>
        public int Count { get { return seats.Values.Count; } }

    }
}
