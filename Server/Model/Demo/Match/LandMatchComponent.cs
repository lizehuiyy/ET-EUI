using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ChildType]
    [ComponentOf(typeof(Scene))]
    public class LandMatchComponent : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 所有登录匹配服务器玩家
        /// </summary>
        public readonly Dictionary<long, Gamer> InLandMatchGamer = new Dictionary<long, Gamer>();


        /// <summary>
        /// 所有游戏中的房间列表
        /// </summary>
        public readonly Dictionary<long, Room> GamingLandlordsRooms = new Dictionary<long, Room>();

        /// <summary>
        /// 所有游戏没有开始的房间列表 Room.Id/Room
        /// </summary>
        public readonly Dictionary<long, Room> FreeLandlordsRooms = new Dictionary<long, Room>();

        /// <summary>
        /// 所有在房间中待机的玩家 UserID/Room
        /// </summary>
        public readonly Dictionary<long, Room> Waiting = new Dictionary<long, Room>();

        /// <summary>
        /// 所有正在游戏的玩家 UserID/Room
        /// </summary>
        public readonly Dictionary<long, Room> Playing = new Dictionary<long, Room>();

        /// <summary>
        /// 匹配中的玩家队列
        /// </summary>
        public readonly Queue<Gamer> MatchingQueue = new Queue<Gamer>();



    }
}
