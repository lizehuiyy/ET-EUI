using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class StageCardStateAwakeSystem : AwakeSystem<StageCardState>
    {
        public override void Awake(StageCardState self)
        {

            self.BuffList = new Dictionary<int, int>();
        }
    }
    public class DeckComponentAwakeSystem : AwakeSystem<DeckComponent>
    {
        public override void Awake(DeckComponent self)
        {
            self.TotalDeck = new List<int>();
            self.HardDeck = new List<NotStageCard>();
            self.LibraryDeck = new List<NotStageCard>();
            self.StageDeck = new List<StageCardState>();
            
            StageCardState stageCardState = new StageCardState();
            stageCardState.Star = 1;
            self.playerRoundResult = new PlayerRoundResult();
            for (int i = 0; i < 7; i++)
            {
                self.StageDeck.Add(stageCardState);
                CardResult cardResult = new CardResult();
                self.playerRoundResult.CardResultList.Add(cardResult);
            }
            self.TowerHP = 30;
            self.Coin = 10;
            self.Level = 1;
            self.Exp = 0;
            //self.useCardList = new List<UseCardProto>();
        }
    }



    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public static class DeckComponentSystem
    {
        //洗牌
        public static void Shuffle(this DeckComponent self)
        {
            if (self.CardCount == self.TotalDeck.Count)
            {
                Random random = new Random();
                List<NotStageCard> newCards = new List<NotStageCard>();
                foreach (var card in self.TotalDeck)
                {
                    NotStageCard temp = new NotStageCard();
                    temp.CardId = card;
                    temp.Star = 1;
                    //newCards.Insert(random.Next(newCards.Count + 1), temp);
                    newCards.Add(temp);
                }

                self.LibraryDeck.Clear();
                self.LibraryDeck.AddRange(newCards);
            }
        }

        public static void ClearResult(this DeckComponent self)
        {
            self.playerRoundResult = new PlayerRoundResult();
            for (int i = 0; i < 7; i++)
            {
                CardResult cardResult = new CardResult();
                self.playerRoundResult.CardResultList.Add(cardResult);
            }
        }


        //初始发牌
        public static void StartDealTo(this DeckComponent self)
        {

            for (int i = 0; i < 5; i++)
            {
                NotStageCard card = self.LibraryDeck[self.LibraryDeck.Count - 1];
                self.HardDeck.Add(card);
                self.LibraryDeck.Remove(card);
            }
        }
        public static void StartDealToText(this DeckComponent self)
        {

            for (int i = 0; i < 5; i++)
            {
                NotStageCard card = self.LibraryDeck[self.LibraryDeck.Count - 1];
                self.HardDeck.Add(card);
                self.LibraryDeck.Remove(card);
            }
        }




        public static void UpdateStageStar(this DeckComponent self)
        {
            foreach (var item in self.StageDeck)
            {
                //puppey
                if (item.UpStar == 1 && item.Star < 3 && item.CardId == 1040)
                {
                    item.Star = item.Star + 1;
                    var config = UnitConfigCategory.Instance.GetAll()[item.CardId];
                    item.BaseAttack = config.attack + item.Star*2 - 1;
                    item.BaseLife = config.life + item.Star*2 - 1;
                }
                //sakda
                else if (item.UpStar == 1 && item.Star < 4 && item.CardId == 1078)
                {
                    item.Star = item.Star + 1;
                    var config = UnitConfigCategory.Instance.GetAll()[item.CardId];
                    item.BaseAttack = config.attack + item.Star * 3 - 1;
                    item.BaseLife = config.life + item.Star * 3 - 1;
                }
                //
                else if (item.UpStar == 1 && item.Star < 4 && item.CardId == 1049)
                {
                    item.Star = item.Star + 1;
                    var config = UnitConfigCategory.Instance.GetAll()[item.CardId];
                    item.BaseAttack = config.attack + item.Star * 1 - 1;
                    item.BaseLife = config.life + item.Star * 1 - 1;
                }

                //普通卡
                else if (item.UpStar == 1 && item.Star < 3 && item.CardId != 1019)
                {
                    item.Star = item.Star + 1;
                    var config = UnitConfigCategory.Instance.GetAll()[item.CardId];
                    item.BaseAttack = config.attack + item.Star - 1;
                    item.BaseLife = config.life + item.Star - 1;
                }

            }
        }
        public static List<int> GetStageCardPos(this DeckComponent self)
        {
            List<int> AttackList = new List<int>();
            for (int j = 1; j < 6; j++)
            {
                if ( self.StageDeck[j].CardId != 0 && self.StageDeck[j].TotalLife > 0)
                {
                    AttackList.Add(j);
                }
            }
            return AttackList;

        }
        public static List<int> GetStageDeBuffYYFCardPos(this DeckComponent self)
        {
            List<int> AttackList = new List<int>();
            for (int j = 1; j < 6; j++)
            {
                if (self.StageDeck[j].CardId != 0 && self.StageDeck[j].TotalLife > 0 && self.StageDeck[j].BuffList.ContainsKey(1050))
                {
                    AttackList.Add(j);
                }
            }
            return AttackList;

        }
        public static List<int> GetMockeryCardPos(this DeckComponent self)
        {
            List<int> AttackList = new List<int>();
            for (int j = 1; j < 6; j++)
            {
                if (self.StageDeck[j].CardId != 0 && self.StageDeck[j].Mockery>=1 && self.StageDeck[j].TotalLife > 0)
                {
                    AttackList.Add(j);
                }
            }
            return AttackList;
        }

        public static void BuffListToResult(this DeckComponent self)
        {
            foreach (var item in self.StageDeck)
            {
                foreach (var item1 in item.BuffList)
                {
                    BuffProto buffProto = new BuffProto();
                    buffProto.BuffCardId = item1.Key;
                    buffProto.BuffCardStar = item.Star;
                    buffProto.BuffNum = item1.Value;
                    self.playerRoundResult.CardResultList[item.Pos].BuffList.Add(buffProto);
                }
            }
        }

        public static void ImmuneClear(this DeckComponent self)
        {
            foreach (var item in self.StageDeck)
            {
                if (item.Immune > 0)
                {
                    if (item.Disarm > 0)
                    {
                        item.Disarm = 0;
                    }
                    if (item.Vertigo > 0)
                    {
                        item.Vertigo = 0;
                    }
                    if (item.Silent > 0)
                    {
                        item.Silent = 0;
                    }
                    if (item.Blinding > 0)
                    {
                        item.Blinding = 0;
                        item.Blind = 0;
                    }
                    if (item.BuffList.Count > 0)
                    {
                        self.BuffListClear(item);
                    }

                }
                
            
            }

        }

        public static void BuffListClear(this DeckComponent self,StageCardState stageCardState)
        {
            foreach (var item in stageCardState.BuffList)
            {
                switch (item.Key)
                {
                    //CEB
                    case 1003:
                        stageCardState.BuffAttack -= item.Value;
                        break;
                        //yatoro
                    case 1004:
                        stageCardState.DeBuffAttack += item.Value;
                        stageCardState.DeBuffLife += item.Value;
                        break;
                        //xiao8
                    case 1016:
                        stageCardState.BuffLife -= item.Value;
                        break;
                        //sumail
                    case 1038:
                        stageCardState.DeBuffAttack += item.Value;
                        stageCardState.DeBuffLife += item.Value;
                        break;
                        //noone
                    case 1039:
                        stageCardState.DeBuffAttack += item.Value;
                        stageCardState.DeBuffLife += item.Value;
                        stageCardState.FramSpeed += item.Value;
                        break;
                    
                }
            }

        }

        //更新场上卡牌状态
        public static void UpdateStageDeck(this DeckComponent self)
        {
            foreach (var item in self.StageDeck)
            {
                if (item.CardId != 0)
                {
                    if (item.IsByLifeDebuff == 0 && item.IsByLifeBuff == 0)
                        item.TotalLife = item.TotalLife + item.BuffLife + item.DeBuffLife;
                    else if (item.IsByLifeDebuff == 0 && item.IsByLifeBuff == 1)
                        item.TotalLife = item.TotalLife + item.DeBuffLife;
                    else if (item.IsByLifeDebuff == 1 && item.IsByLifeBuff == 0)
                        item.TotalLife = item.TotalLife + item.BuffLife;
                    else if (item.IsByLifeDebuff == 1 && item.IsByLifeBuff == 1)
                        item.TotalLife = item.TotalLife;

                    if (item.IsByAttackDebuff == 0 && item.IsByAttackBuff == 0)
                        item.TotalAttack = item.TotalAttack + item.BuffAttack + item.DeBuffAttack;
                    else if (item.IsByAttackDebuff == 0 && item.IsByAttackBuff == 0)
                        item.TotalAttack = item.TotalAttack + item.DeBuffAttack;
                    else if (item.IsByAttackDebuff == 1 && item.IsByAttackBuff == 0)
                        item.TotalAttack = item.TotalAttack + item.BuffAttack;
                    else if (item.IsByAttackDebuff == 1 && item.IsByAttackBuff == 1)
                        item.TotalAttack = item.TotalAttack;
                    item.BuffLife = 0;
                    item.DeBuffLife = 0;
                    item.BuffAttack = 0; 
                    item.DeBuffAttack = 0;

                }
            }
           
        }

        public static int FindEmptyStageDeck(this DeckComponent self)
        {
            for (int i = 1; i < 6; i++)
            {

                if (self.StageDeck[i].CardId == 0)
                {
                    return i;
                }

            }

            return 0;
        }
        public static void NewToOldCard(this DeckComponent self)
        {
            foreach (var item in self.StageDeck)
            {
                item.NewUp = 0;
            }
        
        }

        public static void HardDeckClear(this DeckComponent self,List<SkillCard> CardList)
        {
            for (int i = 0; i < CardList.Count; i++)
            {
                NotStageCard item = new NotStageCard();
                item.CardId = CardList[i].CardId;
                item.Star = CardList[i].CardStar;
                if (self.HardDeck.Contains(item))
                {
                    self.LibraryDeck.Add(item);
                }
            }
            self.HardDeck.Clear();
        }



    }
}
