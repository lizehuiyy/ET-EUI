using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class RoomDestroy : DestroySystem<Room>
    {
        public override void Destroy(Room self)
        {
            foreach (var gamer in self.gamers)
            {
                gamer?.Dispose();
            }
        }
    }
    [FriendClassAttribute(typeof(ET.Room))]
    public static class RoomSystem
    {


        public static Gamer GetGamer(this Room self, int index)
        {

            Log.Debug("GetChatMessageByIndex" + self.gamers.Length);
            Gamer gamer = self.gamers[index];
            //ChatInfo[] queueArray = self.ChatMessageQueue.ToArray();
            return gamer;

        }




        public static Gamer GetGamerFromUserID(this Room self, long id)
        {
            int seatIndex = self.GetGamerSeat(id);
            if (seatIndex >= 0)
            {
                return self.gamers[seatIndex];
            }

            return null;
        }

        public static int GetGamerSeat(this Room self, long id)
        {
            if (self.seats.TryGetValue(id, out int seatIndex))
            {
                return seatIndex;
            }

            return -1;
        }


        /// <summary>
        /// 添加玩家 没有空位时提示错误
        /// </summary>
        /// <param name="gamer"></param>
        public static void Add(this Room self, Gamer gamer)
        {
            int seatIndex = self.GetEmptySeat();
            //玩家需要获取一个座位坐下
            if (seatIndex >= 0)
            {
                self.gamers[seatIndex] = gamer;
                self.seats[gamer.UserID] = seatIndex;
            }
            else
            {
                Log.Error("房间已满无法加入");
            }
        }

        /// <summary>
        /// 获取空座位
        /// </summary>
        /// <returns>返回座位索引，没有空座位时返回-1</returns>
        public static int GetEmptySeat(this Room self)
        {
            for (int i = 0; i < self.gamers.Length; i++)
            {
                if (self.gamers[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }
    }



}
