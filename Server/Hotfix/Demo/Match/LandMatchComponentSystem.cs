using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.LandMatchComponent))]
    [FriendClassAttribute(typeof(ET.Room))]
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public static class LandMatchComponentSystem
    {
        public static void AddLandMatch(this LandMatchComponent self, Gamer gamer)
        {
            if (self.InLandMatchGamer.ContainsKey(gamer.Id))
            {
                Log.Error($"chatInfoUnit is exist!:{gamer.Id}");
                return;
            }
            self.InLandMatchGamer.Add(gamer.Id, gamer);

        }

        public static Gamer GetLandMatch(this LandMatchComponent self, long id)
        {
            self.InLandMatchGamer.TryGetValue(id, out Gamer gamer);
            return gamer;

        }

        public static void RemoveLandMatch(this LandMatchComponent self, long id)
        {
            if (self.InLandMatchGamer.TryGetValue(id, out Gamer gamer))
            {
                self.InLandMatchGamer.Remove(id);
                gamer?.Dispose();
            }

        }
        public static void RemoveGamingMatch(this LandMatchComponent self, long id)
        {
            if (self.GamingLandlordsRooms.TryGetValue(id, out Room room))
            {
                self.GamingLandlordsRooms.Remove(id);
                room?.Dispose();
            }

        }
        public static void RemoveFreeLandMatch(this LandMatchComponent self, long id)
        {
            if (self.FreeLandlordsRooms.TryGetValue(id, out Room room))
            {
                self.FreeLandlordsRooms.Remove(id);
                room?.Dispose();
            }

        }
        public static void RemoveWaitingMatch(this LandMatchComponent self, long id)
        {
            if (self.Waiting.TryGetValue(id, out Room room))
            {
                self.Waiting.Remove(id);
                room?.Dispose();
            }

        }
        public static void RemovePlayingMatch(this LandMatchComponent self, long id)
        {
            if (self.Playing.TryGetValue(id, out Room room))
            {
                self.Playing.Remove(id);
                room?.Dispose();
            }

        }





        public static Room Get(this LandMatchComponent self, long id)
        {
            self.Waiting.TryGetValue(id, out Room room);
            return room;

        }

        public static Room GetPlayingRoom(this LandMatchComponent self, long UserId)
        {
            self.Playing.TryGetValue(UserId, out Room room);
            return room;

        }
        public static Room GetGamingLandRoom(this LandMatchComponent self, long RoomId)
        {
            self.GamingLandlordsRooms.TryGetValue(RoomId, out Room room);
            return room;

        }




        /// <summary>
        /// 斗地主匹配队列人数加一
        /// 队列模式 所以没有插队/离队操作
        /// 队列满足匹配条件时 创建新房间
        /// </summary>
        public static void AddGamerToMatchingQueue(this LandMatchComponent self, Gamer gamer)
        {
            //添加玩家到队列
            self.MatchingQueue.Enqueue(gamer);
            Log.Debug("一位玩家加入队列");
            //广播通知所有匹配中的玩家
            //self.Broadcast(new Actor_LandMatcherPlusOne_NTT() { MatchingNumber = self.MatchingQueue.Count });

            //检查匹配状态
            self.MatchingCheck();
        }

        /// <summary>
        /// 检查匹配状态 每当有新排队玩家加入时执行一次
        /// </summary>
        /// <param name="self"></param>
        public static async void MatchingCheck(this LandMatchComponent self)
        {
            //如果有空房间 且 正在排队的玩家>0
            Room room = self.GetFreeLandlordsRoom();
            if (room != null)
            {
                while (self.MatchingQueue.Count > 0 && room.Count < 2)
                {
                    self.JoinRoom(room, self.MatchingQueue.Dequeue());
                }
            } //else 如果没有空房间 且 正在排队的玩家>=1
            else if (self.MatchingQueue.Count >= 1)
            {

                //创建新房间
                room = self.AddChildWithId<Room>(IdGenerater.Instance.GenerateId());
                await room.AddComponent<MailBoxComponent>().AddLocation();
                self.FreeLandlordsRooms.Add(room.Id, room);

                while (self.MatchingQueue.Count > 0 && room.Count < 3)
                {
                    self.JoinRoom(room, self.MatchingQueue.Dequeue());
                }
            }
        }
        /// <summary>
        /// 获取一个可以添加座位的房间 没有则返回null
        /// </summary>
        public static Room GetFreeLandlordsRoom(this LandMatchComponent self)
        {
            return self.FreeLandlordsRooms.Where(p => p.Value.Count < 2).FirstOrDefault().Value;
        }
        /// <summary>
        /// 加入房间
        /// </summary>
        public static void JoinRoom(this LandMatchComponent self, Room room, Gamer gamer)
        {
            //玩家可能掉线
            if (gamer == null)
            {
                return;
            }

            //玩家加入房间 成为已经进入房间的玩家
            //绑定玩家与房间 以后可以通过玩家UserID找到所在房间
            self.Waiting[gamer.UserID] = room;
            //为玩家添加座位 
            room.Add(gamer);
            //房间广播
            Log.Info($"玩家{gamer.UserID}进入房间");
            //Actor_GamerEnterRoom_Ntt broadcastMessage = new Actor_GamerEnterRoom_Ntt();
            //foreach (Gamer _gamer in room.gamers)
            //{
            //    if (_gamer == null)
            //    {
            //        //添加空位
            //        broadcastMessage.Gamers.Add(new GamerInfo());
            //        continue;
            //    }

            //    //添加玩家信息
            //    //GamerInfo info = new GamerInfo() { UserID = _gamer.UserID, IsReady = room.IsGamerReady(gamer) };
            //    GamerInfo info = new GamerInfo() { UserID = _gamer.UserID };
            //    broadcastMessage.Gamers.Add(info);
            //}
            //广播房间内玩家消息 每次有人进入房间都会收到一次广播
            //room.Broadcast(broadcastMessage);

            //向Gate上的User发送匹配成功 
            //ActorMessageSender actorProxy = Game.Scene.GetComponent<ActorMessageSenderComponent>().Get(gamer.GActorID);
            //actorProxy.Send(new Actor_MatchSucess_M2G() { GamerID = gamer.InstanceId });\
            //匹配成功  房间内玩家数量=2
            if (room.Count == 2)
            {
                room.GameStart();

                List<MatchSuccessProto> protolist = new List<MatchSuccessProto>();

                foreach (var roomGamer in room.gamers)
                {
                    MatchSuccessProto proto = new MatchSuccessProto();
                    proto.CardNum = roomGamer.GetComponent<DeckComponent>().HardDeck.Count;
                    proto.UnitId = roomGamer.UserID;
                    proto.MMR = roomGamer.MMR;
                    proto.Name = roomGamer.Name;
                    proto.Coin = roomGamer.GetComponent<DeckComponent>().Coin;
                    proto.TowerHp = roomGamer.GetComponent<DeckComponent>().TowerHP;
                    protolist.Add(proto);
                }
                foreach (var roomGamer in room.gamers)
                {
                    List<NotStageCard> CardList = new List<NotStageCard>();

                    foreach (var card in roomGamer.GetComponent<DeckComponent>().HardDeck)
                    {
                        NotStageCard item = new NotStageCard();
                        item.CardId = card.CardId;
                        item.Star = 1;
                        CardList.Add(item);
                    }


                    MessageHelper.SendActor(roomGamer.GateSessionActorId, new Match2C_StartMatchSuccess()
                    {
                        Proto = protolist,
                        HeroCardList = CardList,


                    }) ;
                }
            }



        }

    }
}
