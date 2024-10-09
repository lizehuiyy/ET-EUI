using NLog.LayoutRenderers.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.Room))]
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public class C2Match_EndRoundMatchHandler : AMActorRpcHandler<Gamer, C2Match_EndRoundMatch, Match2C_EndRoundMatch>
    {
        protected override async ETTask Run(Gamer gamer, C2Match_EndRoundMatch request, Match2C_EndRoundMatch response, Action reply)
        {

            LandMatchComponent matchComponent = gamer.DomainScene().GetComponent<LandMatchComponent>();
            Room room = matchComponent.GetPlayingRoom(gamer.UserID);

            DeckComponent deckComponent = gamer.GetComponent<DeckComponent>();

            int round = room.Round[gamer.UserID];
            room.Round[gamer.UserID] = round + 1;

            deckComponent.playerRoundResult.useCardList.Clear();
            

            //新使用的卡
            for (int i = 0; i < request.UseCardList.Count; i++)
            {

                StageCardState temp = new StageCardState();
                temp.CardId = request.UseCardList[i].CardId;
                temp.Pos = request.UseCardList[i].CardPos;
                var config = UnitConfigCategory.Instance.GetAll()[temp.CardId];
                var item = deckComponent.HardDeck.Find(x => x.CardId == temp.CardId);
                temp.Position = config.Position;
                temp.Star = item.Star;
                temp.StartStar = temp.Star;
                temp.BaseLife = config.life + temp.Star - 1;
                temp.BaseAttack = config.attack + temp.Star - 1;
                temp.TotalLife = temp.BaseLife;
                temp.TotalAttack = temp.BaseAttack;
                temp.MaxLife = temp.BaseLife;
                temp.MaxAttack = temp.BaseAttack;
                temp.Fram = 0;
                temp.UseSkill = 0;
                temp.UpStar = 0;
                temp.FramSpeed = config.fram;
                temp.NewUp = 1;
                temp.Disarm = 0;
                temp.Immune = 0;
                temp.Silent = 0;
                temp.Vertigo = 0;
                temp.AttackNum = 1;
                temp.AttackFault = 0;
                temp.Dodge = 0;
                temp.DefinitelyHit = 0;
                temp.Mockery = 0;
                temp.Round = 1;
                temp.Armor = 0;
                temp.Crit = 0;
                temp.CritDamage = 100;
                temp.ReCrit = 0;
                temp.ReCritDamage = 100;
                temp.ReDamage = 1;
                deckComponent.playerRoundResult.useCardList.Add(request.UseCardList[i]);

                
                if (item != null)
                {
                    deckComponent.HardDeck.Remove(item);
                }
                deckComponent.StageDeck[temp.Pos] = temp;
            }
            for (int i = 0; i < request.UseCardList.Count; i++)
            {
                room.GetComponent<GameControllerComponent>().UseCard(gamer.UserID, request.UseCardList[i]);
            }
            

            //场上的卡更新
            for (int j = 0; j < request.StageCardList.Count; j++)
            {
                var item = deckComponent.StageDeck.Find(x => x.CardId == request.StageCardList[j].CardId);
                if (item != null && item.Pos == request.StageCardList[j].CardPos)
                {
                    item.Fram = request.StageCardList[j].Fram;
                    item.UseSkill = request.StageCardList[j].UseSkill;
                    item.UseSkill2 = request.StageCardList[j].UseSkill2;
                    item.UpStar = request.StageCardList[j].UpStar;
                    if (item.UseSkill >= 1)
                    {
                        room.GetComponent<GameControllerComponent>().UseSkill(gamer.UserID,item);
                        
                    }
                }

            }

            deckComponent.UpdateStageStar();


            




            





            List<int> RoundList = new List<int>();
            foreach (Gamer gamers in room.gamers)
            {
                if(room.Round.ContainsKey(gamers.UserID))
                { 
                    RoundList.Add(room.Round[gamers.UserID]);
                }
            }
            if (RoundList.Count == 2 && RoundList[0] == RoundList[1])
            {
                room.GetComponent<GameControllerComponent>().UpdateBuffList();
                room.GetComponent<GameControllerComponent>().CompareCard();

                

                List <PlayerRoundResult> playerRoundResultList = new List<PlayerRoundResult>();
                playerRoundResultList.Add(room.gamers[0].GetComponent<DeckComponent>().playerRoundResult);
                playerRoundResultList.Add(room.gamers[1].GetComponent<DeckComponent>().playerRoundResult);

                
                foreach (Gamer gamers in room.gamers)
                {
                    gamers.GetComponent<DeckComponent>().NewToOldCard();

                    MessageHelper.SendActor(gamers.GateSessionActorId, new Match2C_EndRoundResponse()
                    {
                        PlayerRoundResultList = playerRoundResultList,
                        
                    });
                }
                room.gamers[0].GetComponent<DeckComponent>().ClearResult();
                room.gamers[1].GetComponent<DeckComponent>().ClearResult();
            }
            reply();

            await ETTask.CompletedTask;
        }
    }
}
