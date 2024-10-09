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
    public class RoomAwakeSystem : AwakeSystem<Room>
    {
        public override void Awake(Room self)
        {

        }
    }
    [FriendClassAttribute(typeof(ET.Room))]
    [FriendClassAttribute(typeof(ET.LandMatchComponent))]
    public static class RoomSystem
    {
        /// <summary>
        /// 斗地主游戏开始
        /// </summary>
        public static void GameStart(this Room self)
        {
            //更改房间状态 从空闲房间移除 添加到游戏中房间列表
            LandMatchComponent Match = self.DomainScene().GetComponent<LandMatchComponent>();

            Match.FreeLandlordsRooms.Remove(self.Id);
            Match.GamingLandlordsRooms.Add(self.Id, self);

            //更该玩家状态
            for (int i = 0; i < self.gamers.Length; i++)
            {
                Gamer gamer = self.gamers[i];
                Match.Waiting.Remove(gamer.UserID);
                Match.Playing.Add(gamer.UserID, self);
            }

            //添加开始斗地主游戏需要的组件
            //...
            self.AddComponent<GameControllerComponent>();

            //开始游戏
            self.GetComponent<GameControllerComponent>().StartGame();
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

        public static long GetOtherUserId(this Room self, long id)
        {
            int seatIndex = self.GetGamerSeat(id);
            int otherSeat = seatIndex == 0 ? 1 : 0;
            return self.gamers[seatIndex].UserID;

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

        public static async ETTask GameOver(this Room self)
        {


            foreach (Gamer gamers in self.gamers)
            {

                Match2G_GGMatch message = new Match2G_GGMatch();

                long instanceId = gamers.GateSessionActorId;
                message.UnitId = gamers.UserID;
                message.PlayerInstanceId = gamers.PlayerInstanceId;
                if (gamers.win == 2)
                {
                    message.Win = 2;

                }
                else
                {
                    message.Win = 1;
                }

                StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(gamers.DomainZone(), "Map");
                G2Match_GGMatch g2Match_GGMatch = (G2Match_GGMatch)await MessageHelper.CallActor(startSceneConfig.InstanceId, message);

            }
        }
    }



}
