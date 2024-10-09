using Microsoft.CodeAnalysis.CSharp.Syntax;
using MongoDB.Driver.Core.Misc;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace ET
{
    
    public class GameControllerComponentAwakeSystem : AwakeSystem<GameControllerComponent>
    {
        public override void Awake(GameControllerComponent self)
        {
            self.Round = 0;
            self.BuffList = new Dictionary<long, int>();
        }
    }
    [FriendClassAttribute(typeof(ET.Room))]
    [FriendClassAttribute(typeof(ET.Gamer))]
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    [FriendClassAttribute(typeof(ET.GameControllerComponent))]
    public static class GameControllerComponentSystem
    {
        public static void StartGame(this GameControllerComponent self)
        {

            Room room = self.GetParent<Room>();



            foreach (var gamer in room.gamers)
            {
                DeckComponent deckComponent = gamer.GetComponent<DeckComponent>();
                if (deckComponent.TotalDeck.Count != deckComponent.CardCount)
                {
                    Log.Error("牌库不为30");
                    return;
                }
                deckComponent.Shuffle();
                deckComponent.StartDealTo();
                room.Round[gamer.UserID] = 0;
            }
        }

        public static void UseCard(this GameControllerComponent self, long UserId, UseCardProto UseCard)
        {
            var config = UnitConfigCategory.Instance.GetAll()[UseCard.CardId];



            int bit = Convert.ToInt32(config.type, 2);
            Room room = self.GetParent<Room>();
            Gamer Mygamer = null;
            DeckComponent MyDeckComponent = null;
            DeckComponent EnemyDeckComponent = null;
            Random ran = new Random();
            foreach (var item in room.gamers)
            {
                if (item.UserID == UserId)
                {
                    MyDeckComponent = item.GetComponent<DeckComponent>();
                    Mygamer = item;
                }
                else
                {
                    EnemyDeckComponent = item.GetComponent<DeckComponent>();
                }
            }
            UseCard.CardStar = MyDeckComponent.StageDeck[UseCard.CardPos].Star;


            if (UseCard.CardId == 1019)
            {
                MyDeckComponent.StageDeck[UseCard.CardPos].CopyCardId = EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].CardId;
            }
            ////Aui 2000
            //if (UseCard.CardId == 1067)
            //{
            //    List<int> cardList = new List<int>();

            //    for (int i = 0; i < 3; i++)
            //    {
            //        int number;
            //        do
            //        {
            //            number = ran.Next(0, MyDeckComponent.LibraryDeck.Count); ;
            //        } while (cardList.Contains(number));
            //        cardList.Add(number);
            //    }
            //}


            for (int i = 0; i < 5; i++)
            {
                int bit0 = (bit >> i) & 1;
                if (bit0 == 1)
                {
                    switch (i)
                    {
                        //常驻
                        case 0:
                            self.AddBuff(UserId, UseCard);
                            break;
                        //战吼
                        case 1:
                            self.UseBattleCard(UserId, UseCard);
                            break;
                        //亡语
                        case 2:
                            break;
                        //瞬发
                        case 3:
                            break;
                        //主动
                        case 4:
                            break;
                        default:
                            break;
                    }


                }
            }



        }
        //使用战吼卡
        public static void UseBattleCard(this GameControllerComponent self, long UserId, UseCardProto UseCard)
        {
            Room room = self.GetParent<Room>();
            DeckComponent MyDeckComponent = null;
            DeckComponent EnemyDeckComponent = null;
            foreach (var item in room.gamers)
            {
                if (item.UserID == UserId)
                {
                    MyDeckComponent = item.GetComponent<DeckComponent>();
                }
                else {
                    EnemyDeckComponent = item.GetComponent<DeckComponent>();
                }
            }

            var random = new Random();
            List<int> AttackList = EnemyDeckComponent.GetStageCardPos();
            List<int> MyList = MyDeckComponent.GetStageCardPos();
            switch (UseCard.CardId)
            {
                //ana
                case 1002:
                    foreach (var item in MyDeckComponent.StageDeck)
                    {
                        if (item.NewUp == 0)
                        {
                            NotStageCard temp = new NotStageCard();
                            temp.CardId = item.CardId;
                            temp.Star = item.Star;
                            MyDeckComponent.LibraryDeck.Add(temp);
                            MyDeckComponent.LibraryDeck = RandomSort(MyDeckComponent.LibraryDeck);
                            StageCardState stageCardState2 = new StageCardState();
                            MyDeckComponent.StageDeck[item.Pos] = stageCardState2;
                        }
                    }
                    foreach (var item in EnemyDeckComponent.StageDeck)
                    {
                        if (item.NewUp == 0)
                        {
                            NotStageCard temp = new NotStageCard();
                            temp.CardId = item.CardId;
                            temp.Star = item.Star;
                            EnemyDeckComponent.LibraryDeck.Add(temp);
                            EnemyDeckComponent.LibraryDeck = RandomSort(EnemyDeckComponent.LibraryDeck);
                            StageCardState stageCardState3 = new StageCardState();
                            EnemyDeckComponent.StageDeck[item.Pos] = stageCardState3;
                        }
                    }
                    break;
                //kaka
                case 1009:
                    var ppd = EnemyDeckComponent.StageDeck.Find(x => x.CardId == 1014);
                    int ppdstar = 0;
                    if (ppd != null)
                    {
                        ppdstar = ppd.Star;
                    }
                    if (ppdstar < UseCard.CardStar)
                    {
                        MyDeckComponent.StageDeck[UseCard.SelectCardPos].BuffLife += (UseCard.CardStar - ppdstar);
                    }
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].BuffAttack += UseCard.CardStar;
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].DeadCardId = 1009;
                    break;
                //fata
                case 1010:
                    foreach (var item in MyDeckComponent.StageDeck)
                    {
                        if (UseCard.CardId != item.CardId)
                        {
                            item.BuffAttack -= 1;
                            item.BuffLife -= 1;
                        }
                    }

                    break;
                //sansheng
                case 1011:

                    break;
                //Chuan
                case 1015:
                    MyDeckComponent.StageDeck[UseCard.CardPos].Disarm = 9999;
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Disarm = 9999;
                    break;
                //fy
                case 1019:


                    break;
                //hyhy
                case 1020:
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Vertigo = 1;
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].TotalLife -= 3;
                    break;
                //Dendi
                case 1021:
                    NotStageCard temp1 = new NotStageCard();
                    temp1.CardId = UseCard.SelectCardPos;
                    temp1.Star = EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Star;
                    EnemyDeckComponent.LibraryDeck.Add(temp1);
                    EnemyDeckComponent.LibraryDeck = RandomSort(EnemyDeckComponent.LibraryDeck);
                    StageCardState stageCardState = new StageCardState();
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos] = stageCardState;
                    break;
                //Xnova
                case 1031:
                    int star = MyDeckComponent.StageDeck[UseCard.CardPos].Star;
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].Immune = star;
                    MyDeckComponent.StageDeck[UseCard.CardPos].Immune = 9999;
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].NoDead = star;
                    break;
                //chalice
                case 1033:
                    int star1 = MyDeckComponent.StageDeck[UseCard.CardPos].Star;
                    for (int i = 0; i < star1; i++)
                    {
                        var card = MyDeckComponent.LibraryDeck[random.Next(MyDeckComponent.LibraryDeck.Count)];
                        int pos1033 = MyDeckComponent.FindEmptyStageDeck();
                        StageCardState newCard = self.newStageCard(card.CardId, pos1033, card.Star);
                        card.CardPos = pos1033;
                        MyDeckComponent.StageDeck[pos1033] = newCard;
                        MyDeckComponent.LibraryDeck.Remove(card);
                        UseCardProto useCardProto = MyDeckComponent.playerRoundResult.useCardList.Find(x => x.CardId == 1033);

                        SkillCard skillCard = new SkillCard();
                        skillCard.CardId = card.CardId;
                        skillCard.CardPos = pos1033;
                        skillCard.CardStar = card.Star;


                        useCardProto.CardList.Add(skillCard);
                        UseCardProto usecard = new UseCardProto();
                        usecard.CardId = card.CardId;
                        usecard.CardPos = pos1033;
                        usecard.CardStar = card.Star;
                        EnemyDeckComponent.playerRoundResult.useCardList.Add(usecard);
                    }


                    break;
                //miposhka
                case 1034:
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].Dodge = UseCard.CardStar * 10;
                    break;
                //Skiter
                case 1036:
                    int num = UseCard.CardStar;
                    num = 2;
                    for (int j = 0; j < num; j++)
                    {
                        int pos7 = MyDeckComponent.FindEmptyStageDeck();
                        StageCardState newCard = self.newStageCard(UseCard.CardId, pos7, num);
                        newCard.TotalLife = 1;
                        newCard.TotalAttack /= 2;
                        MyDeckComponent.StageDeck[pos7] = newCard;

                        if (pos7 != 0)
                        {
                            var card1036 = MyDeckComponent.playerRoundResult.useCardList.Find(x => x.CardId == 1036);
                            SkillCard skillCard = new SkillCard();
                            skillCard.CardId = UseCard.CardId;
                            skillCard.CardStar = num;
                            skillCard.CardPos = pos7;
                            skillCard.CardAttack = newCard.TotalAttack;
                            skillCard.CardLife = 1;
                            skillCard.CardType = 1;
                            card1036.CardList.Add(skillCard);
                        }
                       
                    }
                    break;
                //Puppey
                case 1040:
                    MyDeckComponent.StageDeck[UseCard.CardPos].Immune = 9999;

                    break;
                //jerax
                case 1043:
                    if (UseCard.CardStar == 1)
                        EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Vertigo = 1;
                    else if (UseCard.CardStar == 2)
                        EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Silent = 2;
                    else if (UseCard.CardStar == 3)
                        EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Vertigo = 2;
                    break;
                //Fear
                case 1046:
                    if (UseCard.SelectCardPlayer == 2)
                        EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Silent = UseCard.CardStar;
                    else
                        MyDeckComponent.StageDeck[UseCard.SelectCardPos].Silent = UseCard.CardStar;

                    break;
                //MMY
                case 1047:
                    if (UseCard.SelectCardPlayer == 2)
                    {
                        EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].TotalLife -=  UseCard.CardStar;
                        EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Blinding = UseCard.CardStar;
                        EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Blind = 50;
                    }
                    else
                    {
                        MyDeckComponent.StageDeck[UseCard.SelectCardPos].Blinding = UseCard.CardStar;
                        MyDeckComponent.StageDeck[UseCard.SelectCardPos].Blind = 50;
                    }


                    break;
                //FCB 鼠大王
                case 1048:
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].TotalLife -= (2 * UseCard.CardStar + 4);
                    break;
                //w33
                case 1049:

                    for (int j = 0; j < UseCard.CardStar; j++)
                    {
                        int pos6 = MyDeckComponent.FindEmptyStageDeck();
                        StageCardState newCard = self.newStageCard(UseCard.CardId, pos6, UseCard.CardStar);
                        MyDeckComponent.StageDeck[pos6] = newCard;

                        var card1049 = MyDeckComponent.playerRoundResult.useCardList.Find(x => x.CardId == 1049);

                        SkillCard skillCard = new SkillCard();
                        skillCard.CardId = UseCard.CardId;
                        skillCard.CardStar = UseCard.CardStar;
                        skillCard.CardPos = pos6;
                        skillCard.CardAttack = newCard.TotalAttack;
                        skillCard.CardLife = newCard.TotalLife;
                        skillCard.CardType = 1;
                        card1049.CardList.Add(skillCard);
                    }
                    break;
                //iceiceice
                case 1050:

                    int AttackCount = AttackList.Count < (UseCard.CardStar + 1) ? AttackList.Count : (UseCard.CardStar + 1);

                    for (int j = 0; j < AttackCount; j++)
                    {
                        int index = random.Next(0, AttackList.Count);
                        int pos1050 = AttackList[index];
                        //EnemyDeckComponent.StageDeck[pos1050].DeBuffToYYF = 1;
                        EnemyDeckComponent.StageDeck[pos1050].TotalLife -= 1;
                        AttackList.RemoveAt(index);

                        EnemyDeckComponent.StageDeck[pos1050].BuffList.Add(1050, 1);

                    }
                    break;
                //Akke
                case 1053:
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].Disarm = UseCard.CardStar;

                    break;
                //EGM
                case 1055:
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].DeadCardId = 1055;

                    break;
                //yoky
                case 1058:
                    int AttackCount1 = AttackList.Count < (UseCard.CardStar + 1) ? AttackList.Count : (UseCard.CardStar + 1);
                    if (UseCard.SelectSkill == 1)
                    {
                        for (int j = 0; j < AttackCount1; j++)
                        {
                            int pos4 = random.Next(0, AttackList.Count);
                            EnemyDeckComponent.StageDeck[pos4].Vertigo = 1;
                            AttackList.RemoveAt(pos4);
                        }
                    }
                    else if (UseCard.SelectSkill == 2)
                    {
                        for (int j = 0; j < AttackCount1; j++)
                        {
                            int pos5 = random.Next(0, AttackList.Count);
                            EnemyDeckComponent.StageDeck[pos5].TotalLife -= 3;
                            AttackList.RemoveAt(pos5);
                        }
                    }

                    break;
                

                //Zfreek
                case 1062:
                    int cardnum = MyDeckComponent.HardDeck.Count();
                    MyDeckComponent.HardDeckClear(UseCard.CardList);

                    int DestroyNum = UseCard.SelectSkill + (UseCard.CardStar > 1 ? UseCard.CardStar - 1 : 0);
                    int DestroyNum1 = DestroyNum > AttackList.Count ? AttackList.Count : DestroyNum;
                    var card1062 = MyDeckComponent.playerRoundResult.useCardList.Find(x => x.CardId == 1062);
                    card1062.CardList.Clear();
                    for (int i = 1; i < 6; i++)
                    {
                        if (EnemyDeckComponent.StageDeck[i].CardId != 0 && DestroyNum1 > 0 && EnemyDeckComponent.StageDeck[i].NewUp == 0)
                        {
                            SkillCard skillCard = new SkillCard();
                            skillCard.CardId = EnemyDeckComponent.StageDeck[i].CardId;
                            skillCard.CardPos = i;
                            
                            card1062.CardList.Add(skillCard);

                            StageCardState stageCardState1062 = new StageCardState();
                            EnemyDeckComponent.StageDeck[i] = stageCardState1062;
                            DestroyNum1 -= 1;
                        }
                    }
                    break;
                //garder
                case 1063:
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].BuffList.Add(1063,1);
                    break;
                //hao
                case 1066:
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].TotalLife -= UseCard.CardStar;
                    break;
                //  QO
                case 1060:
                    MyDeckComponent.StageDeck[UseCard.CardPos].UseSkillCd = 7;
                    break;
                    //loda
                case 1023:
                    MyDeckComponent.StageDeck[UseCard.CardPos].UseSkillCd = 1;
                    break;
                //820
                case 1045:
                    MyDeckComponent.StageDeck[UseCard.CardPos].UseSkillCd = 1;
                    break;
                //YYF
                case 1070:
                    MyDeckComponent.StageDeck[UseCard.CardPos].UseSkillCd = 7;
                    break;
                //GH
                case 1071:
                    MyDeckComponent.StageDeck[UseCard.CardPos].UseSkillCd = 7;
                    break;
                //NothingToSay
                case 1073:
                    int pos1 = random.Next(0, AttackList.Count);
                    AttackList.RemoveAt(pos1);
                    int pos2 = random.Next(0, AttackList.Count);
                    AttackList.RemoveAt(pos2);

                    EnemyDeckComponent.StageDeck[pos1].TotalLife -= (UseCard.CardStar + 1);
                    EnemyDeckComponent.StageDeck[pos2].TotalLife -= (UseCard.CardStar + 1);
                    break;
                //33
                case 1077:
                    for (int i = 0; i < MyDeckComponent.StageDeck.Count; i++)
                    {
                        if (UseCard.CardStar == 1)
                        {
                            MyDeckComponent.StageDeck[i].BaseAttack += 1;
                        }
                        else if (UseCard.CardStar == 2)
                        {
                            MyDeckComponent.StageDeck[i].BaseAttack += 1;
                            MyDeckComponent.StageDeck[i].SuchBlood += 1;
                        }
                        else if (UseCard.CardStar == 3)
                        {
                            MyDeckComponent.StageDeck[i].BaseAttack += 1;
                            MyDeckComponent.StageDeck[i].SuchBlood += 1;
                            MyDeckComponent.StageDeck[i].Armor += 1;
                        }

                    }
                    break;
                //nine
                case 1079:
                    MyDeckComponent.StageDeck[UseCard.SelectCardPos].Offset += UseCard.CardStar;
                    break;
                //tofu
                case 1081:
                    EnemyDeckComponent.StageDeck[UseCard.SelectCardPos].TotalLife -= UseCard.CardStar;
                    AttackList.RemoveAt(UseCard.SelectCardPos);
                    int pos = random.Next(0, AttackList.Count);
                    EnemyDeckComponent.StageDeck[pos].Vertigo = 1;
                    break;
                //dy
                case 1084:
                    if (MyList.Count > 0)
                    {
                        for (int i = 0; i < UseCard.CardStar; i++)
                        {
                            if (MyList.Count > i + 1)
                            {
                                StageCardState newCard = self.newStageCard(999, i, 1);
                                newCard.TotalLife = MyDeckComponent.StageDeck[UseCard.CardPos].TotalLife;
                                newCard.TotalAttack = MyDeckComponent.StageDeck[UseCard.CardPos].TotalAttack;

                            }
                        }

                    }
                    break;
                //MATUMBAMAN
                case 1088:
                    if (UseCard.CardStar == 1)
                    {
                        if (MyList.Count > 1)
                        {
                            StageCardState newCard = self.newStageCard(998, MyList[0], 1);
                            newCard.TotalLife = 1;
                            newCard.TotalAttack = 1;
                            MyDeckComponent.StageDeck[MyList[0]] = newCard;
                            StageCardState newCard1 = self.newStageCard(998, MyList[1], 1);
                            newCard1.TotalLife = 1;
                            newCard1.TotalAttack = 1;
                            MyDeckComponent.StageDeck[MyList[1]] = newCard1;

                        }
                        else if (MyList.Count == 1)
                        {
                            StageCardState newCard = self.newStageCard(998, MyList[0], 1);
                            newCard.TotalLife = 1;
                            newCard.TotalAttack = 1;
                            MyDeckComponent.StageDeck[MyList[0]] = newCard;
                        }
                    }
                    else if (UseCard.CardStar == 2)
                    {
                        if (MyList.Count > 1)
                        {
                            StageCardState newCard = self.newStageCard(997, MyList[0], 1);
                            newCard.TotalLife = 2;
                            newCard.TotalAttack = 2;
                            MyDeckComponent.StageDeck[MyList[0]] = newCard;
                            StageCardState newCard1 = self.newStageCard(997, MyList[1], 1);
                            newCard1.TotalLife = 2;
                            newCard1.TotalAttack = 2;
                            MyDeckComponent.StageDeck[MyList[1]] = newCard1;

                        }
                        else if (MyList.Count == 1)
                        {
                            StageCardState newCard = self.newStageCard(997, MyList[0], 1);
                            newCard.TotalLife = 2;
                            newCard.TotalAttack = 2;
                            MyDeckComponent.StageDeck[MyList[0]] = newCard;
                        }

                    }
                    else if (UseCard.CardStar == 3)
                    {
                        if (MyList.Count > 0)
                        {
                            StageCardState newCard = self.newStageCard(996, MyList[0], 1);
                            newCard.TotalLife = 6;
                            newCard.TotalAttack = 6;
                            MyDeckComponent.StageDeck[MyList[0]] = newCard;
                        }

                    }
                    break;
                //topson
                case 1085:
                    MyDeckComponent.StageDeck[UseCard.CardPos].SuchBlood = UseCard.CardStar;
                    break;
                case 0:

                    break;
            }

        }

        public static void UpdateBuffList(this GameControllerComponent self)
        {
            Room room = self.GetParent<Room>();
            DeckComponent MyDeckComponent = null;
            DeckComponent EnemyDeckComponent = null;

            MyDeckComponent = room.gamers[0].GetComponent<DeckComponent>();
            EnemyDeckComponent = room.gamers[1].GetComponent<DeckComponent>();
            self.UpdateBuffList(MyDeckComponent, EnemyDeckComponent);
            self.UpdateBuffList(EnemyDeckComponent, MyDeckComponent);


            MyDeckComponent.ImmuneClear();
            EnemyDeckComponent.ImmuneClear();




            MyDeckComponent.UpdateStageDeck();
            EnemyDeckComponent.UpdateStageDeck();


        }

        //当前上场BUFF生效
        public static void AddBuff(this GameControllerComponent self, long UserId, UseCardProto UseCard)
        {
            Room room = self.GetParent<Room>();
            DeckComponent MyDeckComponent = null;
            DeckComponent EnemyDeckComponent = null;
            foreach (var item in room.gamers)
            {
                if (item.UserID == UserId)
                {
                    MyDeckComponent = item.GetComponent<DeckComponent>();
                }
                else
                {
                    EnemyDeckComponent = item.GetComponent<DeckComponent>();
                }
            }


            int cardid = 0;
            if (UseCard.CardId == 1019)
            {
                cardid = MyDeckComponent.StageDeck[UseCard.CardPos].CopyCardId;
            }
            else
            {
                cardid = UseCard.CardId;
            }
            switch (cardid)
            {
                
                //Ame
                case 1012:
                    //item.FramSpeed *= (item.Star + 1);
                    MyDeckComponent.StageDeck[UseCard.CardPos].FramSpeed += (UseCard.CardStar + 1);
                    break;
                //Universe
                case 1013:
                    MyDeckComponent.StageDeck[UseCard.CardPos].DefinitelyHit = 9999;
                    MyDeckComponent.StageDeck[UseCard.CardPos].AttackFault = 4 - UseCard.CardStar * 1;
                    break;
                
                //bone7
                case 1024:
                    MyDeckComponent.StageDeck[UseCard.CardPos].TotalLife -= UseCard.CardStar;
                    MyDeckComponent.StageDeck[UseCard.CardPos].Mockery = 9999;
                    break;
                //wings
                case 1026:
                case 1027:
                case 1028:
                case 1029:
                case 1030:
                    if (MyDeckComponent.StageDeck.Exists(x => x.CardId == 1026) && MyDeckComponent.StageDeck.Exists(x => x.CardId == 1027) &&
                        MyDeckComponent.StageDeck.Exists(x => x.CardId == 1028) && MyDeckComponent.StageDeck.Exists(x => x.CardId == 1029) &&
                        MyDeckComponent.StageDeck.Exists(x => x.CardId == 1030))
                    {
                        EnemyDeckComponent.TowerHP = 0;
                    }

                    break;
                //ori
                case 1032:
                    MyDeckComponent.StageDeck[UseCard.CardPos].ReflexDamage = UseCard.CardStar * 0.1f + 0.3f;
                    break;
                // oldchicken
                case 1035:
                    MyDeckComponent.StageDeck[UseCard.CardPos].Crit = 17;
                    MyDeckComponent.StageDeck[UseCard.CardPos].CritDamage = 125 * UseCard.CardStar + 75;
                    MyDeckComponent.StageDeck[UseCard.CardPos].ReCrit = 50 - 10 * UseCard.CardStar;
                    MyDeckComponent.StageDeck[UseCard.CardPos].ReCritDamage = 400;

                    break;

                //Rotk
                case 1056:
                    MyDeckComponent.StageDeck[UseCard.CardPos].Armor = UseCard.CardStar;
                    MyDeckComponent.StageDeck[UseCard.CardPos].Mockery = 9999;
                    break;

                //dyrachyo
                case 1089:
                    MyDeckComponent.StageDeck[UseCard.CardPos].DefinitelyHit = 10 + 20 * UseCard.CardStar;

                    break;



            }
        }

        public static void UpdateBuffList(this GameControllerComponent self, DeckComponent MyDeckComponent, DeckComponent EnemyDeckComponent)
        {
            //foreach (var item in MyDeckComponent.StageDeck)
            for(int k = 1;k<6;k++)
            {
                var item = MyDeckComponent.StageDeck[k];
                int cardId = item.CardId;
                if (item.CardId == 1019)
                {
                    cardId = item.CopyCardId;
                }
                List<int> posList = EnemyDeckComponent.GetStageCardPos();
                List<int> MyposList = MyDeckComponent.GetStageCardPos();
                //List<int> MyEmptyPosList = MyDeckComponent.FindEmptyStageDeck();
                var random = new Random();
                var ppd = EnemyDeckComponent.StageDeck.Find(x => x.CardId == 1014);
                var EGM = EnemyDeckComponent.StageDeck.Find(x => x.CardId == 1055);
                int ppdstar = 0;
                if (ppd != null)
                {
                    ppdstar = ppd.Star;
                }
                switch (cardId)
                {
                    //Notail
                    case 1001:
                        if (item.NewUp == 0)
                        {
                            foreach (var item1 in MyDeckComponent.StageDeck)
                            {
                                if (ppdstar < item.Star)
                                {
                                    item1.TotalLife += item.Star - ppdstar;
                                    if (item1.TotalLife > item1.MaxLife)
                                    {
                                        item1.TotalLife = item1.MaxLife;
                                    }

                                }

                            }
                        }


                        break;
                    //BurNing
                    case 1007:
                        if (item.Fram == 1)
                        {
                            item.Dodge = item.Star * 20;
                        }
                        else
                        {
                            item.Dodge = 0;
                        }
                        break;
                    //Mu
                    case 1025:
                        if (item.Round % 2 == 0)
                        {
                            item.TotalAttack *= 2;
                            item.TotalLife *= 2;
                        }
                        else
                        {
                            item.TotalAttack /= 2;
                            item.TotalLife /= 2;
                        }
                        break;
                    // RTZ
                    case 1018:
                        if (MyDeckComponent.StageDeck.Count == 1 && EnemyDeckComponent.StageDeck.Count >= 2)
                        {
                            item.TotalAttack *= 2;
                            item.TotalLife *= 2;
                            item.AttackNum = 5;
                        }
                        break;
                    //Ceb
                    case 1003:
                        foreach (var item1 in MyDeckComponent.StageDeck)
                        {
                            if (!item1.BuffList.ContainsKey(1003))
                            {
                                item1.BuffAttack += item.Star;
                                item1.BuffList.Add(1003, item.Star);
                            }
                            
                        }
                        break;
                    //Yatoro
                    case 1004:
                        foreach (var item1 in EnemyDeckComponent.StageDeck)
                        {
                            if (item1.Position == 1)
                            {
                                if (!item1.BuffList.ContainsKey(1004))
                                {
                                    item1.DeBuffAttack -= item.Star * 2;
                                    item1.DeBuffLife -= item.Star * 2;
                                    item1.BuffList.Add(1004, item.Star * 2);
                                }
                                    
                               
                            }
                        }
                        break;
                    //Sumail
                    case 1038:
                        foreach (var item1 in EnemyDeckComponent.StageDeck)
                        {
                            if (item1.Position == 2)
                            {
                                if (!item1.BuffList.ContainsKey(1038))
                                {
                                    item1.DeBuffAttack -= item.Star * 2;
                                    item1.DeBuffLife -= item.Star * 2;
                                    item1.BuffList.Add(1038, item.Star * 2);
                                }
                            }
                        }
                        break;
                    //xiao8
                    case 1016:
                        if (ppd != null)
                        {
                            ppdstar = ppd.Star;
                        }
                        foreach (var item1 in MyDeckComponent.StageDeck)
                        {
                            if (ppdstar < item.Star)
                            {
                                if (!item1.BuffList.ContainsKey(1016))
                                {
                                    item1.BuffLife += (item.Star - ppdstar);
                                    item1.BuffList.Add(1016, (item.Star - ppdstar));
                                }
                            }

                        }
                        break;
                    //noone
                    case 1039:
                        if (EnemyDeckComponent.StageDeck[item.Pos].CardId != 0)
                        {
                            if (!EnemyDeckComponent.StageDeck[item.Pos].BuffList.ContainsKey(1039))
                            {
                                EnemyDeckComponent.StageDeck[item.Pos].FramSpeed -= item.Star;
                                EnemyDeckComponent.StageDeck[item.Pos].DeBuffLife -= item.Star;
                                EnemyDeckComponent.StageDeck[item.Pos].DeBuffAttack -= item.Star;
                                EnemyDeckComponent.StageDeck[item.Pos].BuffList.Add(1039, item.Star);
                            }
                        }
                        break;
                    //Sccc
                    case 1044:
                        if ((item.Round - 2) % 4 == 0)
                        {
                            item.AttackNum = item.Star + 2;
                        }
                        else
                        {
                            item.AttackNum = 1;
                        }
                        break;


                    //Mushi
                    case 1051:
                        if (4 - item.StartStar == item.Round)
                        {

                            for (int i = 0; i < posList.Count; i++)
                            {
                                EnemyDeckComponent.StageDeck[posList[i]].TotalLife -= ((item.StartStar * 2) + 1);
                                MyDeckComponent.playerRoundResult.CardResultList[item.Pos].UseSkill.Add(posList[i]);
                                MyDeckComponent.playerRoundResult.CardResultList[item.Pos].UseSkillDmg.Add(((item.StartStar * 2) + 1));
                            }
                        }
                        break;
                    //XBOCT
                    case 1054:

                        for (int i = 0; i < posList.Count; i++)
                        {
                            EnemyDeckComponent.StageDeck[posList[i]].TotalLife -= item.Star;
                            MyDeckComponent.playerRoundResult.CardResultList[item.Pos].UseSkill.Add(posList[i]);
                            MyDeckComponent.playerRoundResult.CardResultList[item.Pos].UseSkillDmg.Add(item.Star);
                        }
                        
                        break;

                    //BuLba
                    case 1052:
                        if (item.NewUp == 1)
                        {
                            int getCardNum = EnemyDeckComponent.HardDeck.Count < item.Star ? EnemyDeckComponent.HardDeck.Count : item.Star;

                            List<NotStageCard> HardDeck = EnemyDeckComponent.HardDeck;
                            for (int i = 0; i < getCardNum; i++)
                            {
                                var UseCardProto = MyDeckComponent.playerRoundResult.useCardList.Find(x => x.CardId == 1052);
                                int ran = random.Next(0, EnemyDeckComponent.HardDeck.Count);
                                var hardcard = HardDeck[ran];
                                HardDeck.RemoveAt(ran);
                                SkillCard skillCard = new SkillCard();
                                skillCard.CardId = hardcard.CardId;
                                skillCard.CardStar = hardcard.Star;

                                UseCardProto.CardList.Add(skillCard);
                            }



                        }

                        break;
                    //QO
                    case 1060:
                        if (item.Round % (6-item.StartStar) == 0)
                        {
                            item.UseSkillCd = 7;
                        }
                        break;

                    //Agressif霸气
                    case 1061:
                        int fantasy = random.Next(1, 101);
                        int Odds = (item.Star * 5 + 35);
                        if (item.Fantasy == 1)
                        {
                            Odds = 8;
                        }
                        if (item.NewUp == 2)
                        {
                            Odds = 0;
                        }
                        if (fantasy < Odds)
                        {
                            if (MyposList.Count > 0)
                            {
                                int pos7 = MyDeckComponent.FindEmptyStageDeck();
                                StageCardState newCard = self.newStageCard(item.CardId, pos7, item.Star);
                                newCard.TotalLife = 1;
                                newCard.TotalAttack = 1;
                                newCard.Fantasy = 1;
                                newCard.NewUp = 2;
                                
                                MyDeckComponent.StageDeck[pos7] = newCard;
                                
                                if (pos7 != 0)
                                {
                                    var card1061 = MyDeckComponent.playerRoundResult.CardResultList[item.Pos];

                                    SkillCard skillCard = new SkillCard();
                                    skillCard.CardId = item.CardId;
                                    skillCard.CardStar = item.Star;
                                    skillCard.CardPos = pos7;
                                    skillCard.CardAttack = 1;
                                    skillCard.CardLife = 1;
                                    skillCard.CardType = 3;
                                    card1061.CardList.Add(skillCard);
                                }
                               

                            }
                        }
                        break;
                    //Super
                    case 1068:
                        if (item.Star * 2 > ppdstar)
                        {
                            item.TotalLife += item.Star * 2 - ppdstar;
                            if (item.TotalLife > item.MaxLife)
                            {
                                item.TotalLife = item.MaxLife;
                            }
                        }

                        break;
                    //820
                    case 1045:
                        if (item.Round % (5-item.StartStar) == 0)
                        {
                            item.UseSkillCd = 1;
                        }
                        break;
                    //YYF
                    case 1070:
                        if (item.Round % (6-item.StartStar) == 0)
                        {
                            item.UseSkillCd = 7;
                        }
                        break;
                    //GH
                    case 1071:
                        if (item.Round % (6-item.StartStar) == 0)
                        {
                            item.UseSkillCd = 7;
                        }
                        break;
                    //Collapse
                    case 1074:
                        if (item.Round % (5 - item.StartStar) == 0)
                        {
                            item.UseSkillCd = 1;
                        }
                        break;
                    //XINQ
                    case 1076:
                        if (item.Round % (6-item.StartStar) == 0)
                        {
                            item.UseSkillCd = 1;
                        }
                        break;
                    //TORONTOTOKYO
                    case 1075:
                        if (item.NewUp == 1)
                        {
                            int getCardNum = EnemyDeckComponent.HardDeck.Count < item.Star ? EnemyDeckComponent.HardDeck.Count : item.Star;

                            List<NotStageCard> RemoveCards = new List<NotStageCard>();
                            for (int i = 0; i < getCardNum; i++)
                            {
                                //移除手牌  加到list  移除牌库 加到手牌  list加到牌库
                                int cardpos = random.Next(0, EnemyDeckComponent.HardDeck.Count);
                                NotStageCard card = EnemyDeckComponent.HardDeck[cardpos];
                                var UseCardProto = MyDeckComponent.playerRoundResult.useCardList.Find(x => x.CardId == 1075);
                                SkillCard skillCard = new SkillCard();
                                skillCard.CardId = card.CardId;
                                skillCard.CardStar = card.Star;
                                if (UseCardProto != null)
                                {
                                    UseCardProto.CardList.Add(skillCard);
                                }
                                RemoveCards.Add(card);
                                EnemyDeckComponent.HardDeck.RemoveAt(cardpos);

                                int cardLibrary = random.Next(0, EnemyDeckComponent.LibraryDeck.Count);
                                NotStageCard card1 = EnemyDeckComponent.LibraryDeck[cardLibrary];
                                EnemyDeckComponent.LibraryDeck.RemoveAt(cardLibrary);
                                EnemyDeckComponent.HardDeck.Add(card1);
                            }
                            for (int i = 0; i < RemoveCards.Count; i++)
                            {
                                EnemyDeckComponent.LibraryDeck.Add(RemoveCards[i]);
                            }



                        }

                        break;
                    //emo
                    case 1086:
                        int attackbuff = (30 - MyDeckComponent.TowerHP) / (2 * item.Star + 2);
                        item.BuffLife = attackbuff;
                        item.BuffAttack = attackbuff;
                        break;
                    case 0:
                        break;
                }

                if (item.DeadCardId == 1055)
                {

                    if (ppd!=null && ppdstar < EGM.Star)
                    {
                        item.TotalLife += EGM.Star - ppdstar;
                        if (item.TotalLife > item.MaxLife)
                        {
                            item.TotalLife = item.MaxLife;
                        }

                    }
                }

            }
        }


        public static StageCardState newStageCard(this GameControllerComponent self, int CardId, int CardPos, int star)
        {
            StageCardState card = new StageCardState();
            card.CardId = CardId;
            card.Pos = CardPos;
            var config = UnitConfigCategory.Instance.GetAll()[card.CardId];
            card.Star = star;
            card.BaseAttack = config.attack + card.Star - 1;
            card.BaseLife = config.life + card.Star - 1;
            card.TotalAttack = card.BaseAttack;
            card.TotalLife = card.BaseLife;
            card.MaxLife = card.TotalLife;
            card.MaxAttack = card.TotalAttack;
            card.Position = config.Position;
            card.Fram = 0;
            card.UseSkill = 0;
            card.UpStar = 0;
            card.FramSpeed = config.fram;
            card.NewUp = 1;
            card.Disarm = 0;
            card.Immune = 0;
            card.Silent = 0;
            card.Vertigo = 0;
            card.AttackNum = 1;
            card.AttackFault = 0;
            card.Dodge = 0;
            card.DefinitelyHit = 0;
            card.Mockery = 0;
            card.Round = 1;
            card.Armor = 0;
            card.ReflexDamage = 0;
            card.Crit = 0;
            card.CritDamage = 100;
            card.ReCrit = 0;
            card.ReCritDamage = 100;
            card.ReDamage = 1;




            return card;
        }

        public static void UseSkill(this GameControllerComponent self, long UserId, StageCardState card)
        {
            Room room = self.GetParent<Room>();
            DeckComponent MyDeckComponent = null;
            DeckComponent EnemyDeckComponent = null;

            var random = new Random();
            foreach (var item in room.gamers)
            {
                if (item.UserID == UserId)
                {
                    MyDeckComponent = item.GetComponent<DeckComponent>();
                }
                else
                {
                    EnemyDeckComponent = item.GetComponent<DeckComponent>();
                }
            }
            List<int> MyList = MyDeckComponent.GetStageCardPos();
            var ppd = EnemyDeckComponent.StageDeck.Find(x => x.CardId == 1014);
            int ppdstar = 0;
            if (ppd != null)
            {
                ppdstar = ppd.Star;
            }


            switch (card.CardId)
            {
                //loda
                case 1023:
                    EnemyDeckComponent.TowerHP -= MyDeckComponent.StageDeck[card.Pos].Star * 2;
                    break;

                //Sneyking
                case 1037:
                    //UseSkill2为要跳跃的位置
                    if (MyDeckComponent.StageDeck[card.UseSkill2].CardId == 0)
                    {
                        MyDeckComponent.StageDeck[card.UseSkill2] = MyDeckComponent.StageDeck[card.Pos];
                        StageCardState stageCardState = new StageCardState();
                        MyDeckComponent.StageDeck[card.Pos] = stageCardState;
                        MyDeckComponent.StageDeck[card.UseSkill2].Pos = card.UseSkill2;

                        MyDeckComponent.playerRoundResult.CardResultList[card.UseSkill2].UseSkill.Add(card.UseSkill2);
                    }

                    break;
                //820
                case 1045:
                    if (card.UseSkillCd == 1 && card.UseSkill == 1)
                    {
                        
                        //Useskill2 交换的位置 1-5为自己 6-10为敌人 
                        if (card.UseSkill2 >0 && card.UseSkill2 <6 && MyDeckComponent.StageDeck[card.UseSkill2].CardId != 0)
                        {
                            StageCardState temp = MyDeckComponent.StageDeck[card.UseSkill2];
                            temp.Pos = card.Pos;
                            MyDeckComponent.StageDeck[card.UseSkill2] = MyDeckComponent.StageDeck[card.Pos];
                            MyDeckComponent.StageDeck[card.Pos] = temp;
                            MyDeckComponent.StageDeck[card.UseSkill2].Pos = card.UseSkill2;
                            card.UseSkillCd -= 1;
                            MyDeckComponent.playerRoundResult.CardResultList[card.UseSkill2].UseSkill.Add(card.UseSkill2);
                        }
                      
                    }
                   
                    break;
                //Sylar
                case 1057:
                    card.BuffToTempRound = card.Star + 1;
                    card.TotalLife += card.Star + 2;
                    card.Crit = 40;
                    card.CritDamage = 120 + card.Star * 40;
                    MyDeckComponent.playerRoundResult.CardResultList[card.Pos].UseSkill.Add(card.BuffToTempRound);
                    break;
                //QO
                case 1060:
                    for (int i = 0; i < 3; i++)
                    {
                        int bit0 = (card.UseSkillCd >> i) & 1;
                        if (card.UseSkill == 1 && bit0 == 1 && i == 0)
                        {
                            card.UseSkillCd -= 1;
                            MyDeckComponent.StageDeck[card.UseSkill2] = MyDeckComponent.StageDeck[card.Pos];
                            StageCardState stageCardState = new StageCardState();
                            MyDeckComponent.StageDeck[card.Pos] = stageCardState;
                            MyDeckComponent.StageDeck[card.UseSkill2].Pos = card.UseSkill2;
                        }
                        else if (card.UseSkill == 2 && bit0 == 1 && i == 1)
                        {
                            card.Offset = 1;
                            card.BuffToTempRound = 1;
                            card.UseSkillCd -= 2;
                        }
                        else if (card.UseSkill == 3 && bit0 == 1 && i == 2)
                        {
                            card.BuffAttack += 3;
                            card.BuffToTempRound = 1;
                            card.UseSkillCd -= 4;
                        }
                        
                    }




                    break;
                //YYF
                case 1070:
                    for (int i = 0; i < 3; i++)
                    {
                        int bit0 = (card.UseSkillCd >> i) & 1;
                        if (card.UseSkill == 1 && bit0 == 1 && i == 0)
                        {
                            card.Dodge = 60;
                            card.BuffToTempRound = 1;
                            card.UseSkillCd -= 1;
                        }
                        else if (card.UseSkill == 2 && bit0 == 1 && i == 1)
                        {
                            card.Crit = 60;
                            card.CritDamage = 180;
                            card.BuffToTempRound = 1;
                            card.UseSkillCd -= 2;
                        }
                        else if (card.UseSkill == 3 && bit0 == 1 && i == 2)
                        {
                            EnemyDeckComponent.StageDeck[card.UseSkill2].Vertigo = 1;
                            card.UseSkillCd -= 4;
                        }
                    }




                    break;
                //GH
                case 1071:
                    for (int i = 0; i < 3; i++)
                    {
                        int bit0 = (card.UseSkillCd >> i) & 1;
                        if (card.UseSkill == 1 && bit0 == 1 && i == 0)
                        {
                            //治疗
                            MyDeckComponent.StageDeck[card.UseSkill2].TotalLife += 3;
                            card.UseSkillCd -= 1;
                        }
                        else if (card.UseSkill == 2 && bit0 == 1 && i == 1)
                        {
                            //致盲
                            EnemyDeckComponent.StageDeck[card.UseSkill2].Blinding = 1;
                            EnemyDeckComponent.StageDeck[card.UseSkill2].Blind = 50;
                            card.UseSkillCd -= 2;
                        }
                        else if (card.UseSkill == 3 && bit0 == 1 && i == 2)
                        {
                            EnemyDeckComponent.StageDeck[card.UseSkill2].Vertigo = 1;
                            card.UseSkillCd -= 4;
                        }
                    }




                    break;
                //Collapse
                case 1074:
                    if (card.UseSkillCd == 1)
                    {
                        EnemyDeckComponent.StageDeck[card.UseSkill] = MyDeckComponent.StageDeck[card.UseSkill2];
                        StageCardState stageCardState = new StageCardState();
                        EnemyDeckComponent.StageDeck[card.UseSkill2] = stageCardState;
                        EnemyDeckComponent.StageDeck[card.UseSkill].Pos = card.UseSkill;
                        card.UseSkillCd -= 1;
                    }
                    break;
                //XINQ
                case 1076:
                    if (card.UseSkillCd == 1)
                    {
                        int AbNormal = 0;
                        if (card.Disarm > 0)
                        {
                            AbNormal += 1;
                            card.Disarm = 0;
                        }
                        if (card.Vertigo > 0)
                        {
                            AbNormal += 1;
                            card.Vertigo = 0;
                        }
                        if (card.Silent > 0)
                        {
                            AbNormal += 1;
                            card.Silent = 0;
                        }
                        if (card.Blinding > 0)
                        {
                            AbNormal += 1;
                            card.Blinding = 0;
                            card.Blind = 0;
                        }
                        if (AbNormal > 0)
                        {

                            int pos = random.Next(0, MyList.Count);
                            if (ppdstar < AbNormal)
                            {
                                MyDeckComponent.StageDeck[pos].TotalLife += (AbNormal - ppdstar);
                                MyDeckComponent.StageDeck[pos].MaxLife += (AbNormal - ppdstar);
                            }


                        }
                        card.UseSkillCd -= 1;

                    }


                    break;
                case 0:

                    break;

            }
            MyDeckComponent.playerRoundResult.CardResultList[card.Pos].CardId = card.CardId;
            MyDeckComponent.playerRoundResult.CardResultList[card.Pos].CardPos = card.Pos;
            MyDeckComponent.playerRoundResult.CardResultList[card.Pos].CardStar = card.Star;
            MyDeckComponent.playerRoundResult.CardResultList[card.Pos].UseSkill.Add(card.UseSkill);
            MyDeckComponent.playerRoundResult.CardResultList[card.Pos].UseSkillCD = card.UseSkillCd;
            if (card.UseSkill2 > 0)
                MyDeckComponent.playerRoundResult.CardResultList[card.Pos].UseSkill.Add(card.UseSkill2);


        }



        public static List<T> RandomSort<T>(List<T> list)
        {
            var random = new Random();
            var newList = new List<T>();
            foreach (var item in list)
            {
                newList.Insert(random.Next(newList.Count), item);
            }
            return newList;
        }
        public static void DeadCard(this GameControllerComponent self, DeckComponent mainPlayer, DeckComponent OtherPlayer)
        {

            for (int i = 1; i < 6; i++)
            {
                if (mainPlayer.StageDeck[i].CardId != 0 && mainPlayer.StageDeck[i].TotalLife <= 0)
                {

                    NotStageCard temp = new NotStageCard();
                    temp.CardId = mainPlayer.StageDeck[i].CardId;
                    temp.Star = mainPlayer.StageDeck[i].Star;
                    mainPlayer.LibraryDeck.Add(temp);
                    mainPlayer.LibraryDeck = RandomSort(mainPlayer.LibraryDeck);
                    self.BuffToResult(temp.CardId,mainPlayer, OtherPlayer);
                    //清空
                    StageCardState stageCardState = new StageCardState();
                    mainPlayer.StageDeck[i] = stageCardState;

              



                }
            }

        }

        public static void BuffToResult(this GameControllerComponent self, int Deadcardid, DeckComponent mainPlayer, DeckComponent OtherPlayer)
        {
            bool Other = false;
            bool main = false;
            for (int i = 1; i < 6; i++)
            {
                if (OtherPlayer.StageDeck[i].CardId != 0)
                {
                    int value;
                    if (OtherPlayer.StageDeck[i].BuffList.TryGetValue(Deadcardid, out value))
                    {
                        Other = true;
                        switch (Deadcardid)
                        {
                            //yatoro
                            case 1004:
                                OtherPlayer.StageDeck[i].DeBuffAttack += value;
                                OtherPlayer.StageDeck[i].DeBuffLife += value;
                                break;
                            //Sumail
                            case 1038:
                                OtherPlayer.StageDeck[i].DeBuffAttack += value;
                                OtherPlayer.StageDeck[i].DeBuffLife += value;
                                break;


                        }
                    }

                }

                if (mainPlayer.StageDeck[i].CardId != 0)
                {
                    int value;
                    if (mainPlayer.StageDeck[i].BuffList.TryGetValue(Deadcardid, out value))
                    {
                        main = true;
                        switch (Deadcardid)
                        {
                            //Ceb
                            case 1003:
                                mainPlayer.StageDeck[i].BuffAttack -= value;
                                break;
                            //xiao8
                            case 1016:
                                mainPlayer.StageDeck[i].BuffLife -= value;
                                break;


                        }
                    }
                }
            }

            if (Other)
            {
                OtherPlayer.UpdateStageDeck();
            }
            if (main)
            {
                mainPlayer.UpdateStageDeck();
            }
        }


        public static void StatusEndRound(this GameControllerComponent self, DeckComponent mainPlayer)
        {
            for (int i = 1; i < 6; i++)
            {
                if (mainPlayer.StageDeck[i].CardId != 0)
                {
                    if (mainPlayer.StageDeck[i].Immune > 0)
                        mainPlayer.StageDeck[i].Immune -= 1;
                    if (mainPlayer.StageDeck[i].Vertigo > 0)
                        mainPlayer.StageDeck[i].Vertigo -= 1;
                    if (mainPlayer.StageDeck[i].Disarm > 0)
                        mainPlayer.StageDeck[i].Disarm -= 1;
                    if (mainPlayer.StageDeck[i].Silent > 0)
                        mainPlayer.StageDeck[i].Silent -= 1;
                    if (mainPlayer.StageDeck[i].NoDead > 0)
                        mainPlayer.StageDeck[i].NoDead -= 1;
                    if (mainPlayer.StageDeck[i].DeBuffToYYF > 0)
                        mainPlayer.StageDeck[i].DeBuffToYYF -= 1;
                    if (mainPlayer.StageDeck[i].Blinding > 0)
                    {
                        mainPlayer.StageDeck[i].Blinding -= 1;
                        if (mainPlayer.StageDeck[i].Blinding == 0)
                        {
                            mainPlayer.StageDeck[i].Blind -= 0;
                        }
                            
                    }

                    if (mainPlayer.StageDeck[i].BuffToTempRound > 0)
                    {
                        mainPlayer.StageDeck[i].BuffToTempRound -= 1;
                        if (mainPlayer.StageDeck[i].BuffToTempRound == 0)
                        {
                            if (mainPlayer.StageDeck[i].CardId == 1057)
                            {
                                mainPlayer.StageDeck[i].Crit = 0;
                                mainPlayer.StageDeck[i].CritDamage = 100;
                            }
                            else if (mainPlayer.StageDeck[i].CardId == 1060)
                            {
                                mainPlayer.StageDeck[i].BuffAttack -= 3;
                                mainPlayer.StageDeck[i].Offset = 0;
                            }
                            else if (mainPlayer.StageDeck[i].CardId == 1070)
                            {
                                mainPlayer.StageDeck[i].Crit = 0;
                                mainPlayer.StageDeck[i].CritDamage = 100;
                                mainPlayer.StageDeck[i].Dodge = 0;
                            }
                        }
                    }
                    if (mainPlayer.StageDeck[i].BuffList.ContainsKey(1063))
                    {
                        mainPlayer.StageDeck[i].BuffList.Remove(1063);
                    }

                    
                    mainPlayer.UpdateStageDeck();
                    mainPlayer.StageDeck[i].UseSkill = 0;
                    mainPlayer.StageDeck[i].Round += 1;
                }
            }
        }
        public static (int, int, int, int,int,int,int) AttackTarget(this GameControllerComponent self, DeckComponent mainPlayer,StageCardState mainCard, DeckComponent OtherPlayer, StageCardState OtherCard)
        {
            //mainPlayer.DefinitelyHit
            var random = new Random();
            int ranDodge = random.Next(1, 101);//是否闪避
            int ranBlind = random.Next(1, 101);//是否致盲
            int ranDefintelyHit = random.Next(1, 101);//是否必中
            int ranCrit = random.Next(1, 101);//是否暴击
            int ReflexDamage = 0;
            int Crit = 0;
            int ReCrit = 0;
            int Dodge = 0;
            int Blind = 0;
            int Reset = 0;
            int damage = 0;
            if (ranDefintelyHit <= mainCard.DefinitelyHit || (ranDodge >= OtherCard.Dodge && ranBlind >= mainCard.Blind))
            {
                if (OtherCard.Armor < mainCard.TotalAttack)
                {
                    int CritDamage = 100;
                    if (ranCrit <= mainCard.Crit)
                    {
                        Crit = 1;
                        CritDamage = mainCard.CritDamage;
                    }
                    int otherCrit = random.Next(1, 101);
                    int otherCritDamage = 100;
                    if (otherCrit <= OtherCard.ReCrit)
                    {
                        ReCrit = 1;
                        otherCritDamage = OtherCard.ReCritDamage;
                    }
                    int tempattack = 0;
                    if (mainCard.CardId == 1082 && OtherCard.Position == 2)
                    {
                        //maybe对上2号位加攻击
                        tempattack = mainCard.Star * 2 + 1;
                    }

                    damage = (mainCard.TotalAttack + tempattack - OtherCard.Armor) * (CritDamage / 100) * (otherCritDamage / 100);
                    OtherCard.ReAttackNum += 1;
                    if (OtherCard.Offset > 0)
                    {
                        Reset = 1;
                        OtherCard.Offset -= 1;
                        damage = 0;

                    }
                    else
                    {
                        OtherCard.TotalLife -= (int)(damage * OtherCard.ReDamage);
                        if (OtherCard.BuffList.ContainsKey(1050) && damage > 0)
                        {
                            List<int> attackList = OtherPlayer.GetStageDeBuffYYFCardPos();
                            for (int i = 0; i < attackList.Count; i++)
                            {
                                if (OtherPlayer.StageDeck[attackList[i]].CardId != OtherCard.CardId)
                                {
                                    OtherPlayer.StageDeck[attackList[i]].TotalLife -= 1;

                                    int value = OtherPlayer.StageDeck[attackList[i]].BuffList[1050];
                                    OtherPlayer.StageDeck[attackList[i]].BuffList[1050] = value + 1;


                                }

                            }
                        }
                        if (OtherCard.TotalLife <= 0)
                        {
                            self.DeadVoid(OtherPlayer, OtherPlayer, OtherCard);
                        }
                        if (OtherCard.ReflexDamage > 0)
                        {
                            ReflexDamage = (int)(damage * OtherCard.ReflexDamage);
                            if (ReflexDamage > 0)
                            {
                                mainCard.TotalLife -= ReflexDamage;
                                if (mainCard.TotalLife <= 0)
                                {
                                    self.DeadVoid(mainPlayer, OtherPlayer, mainCard);
                                }
                               

                            }
                        }
                    }



                }
            }
            else
            {
                if (ranDodge >= OtherCard.Dodge)
                {
                    Dodge = 1;
                }
                if (ranBlind >= mainCard.Blind)
                {
                    Blind = 1;
                }

            }
        
            return (ReflexDamage,Crit,ReCrit,Dodge,Blind,Reset, damage);

        }

        public static void DeadVoid(this GameControllerComponent self, DeckComponent mainPlayer, DeckComponent OtherPlayer, StageCardState Card)
        {
            var config = UnitConfigCategory.Instance.GetAll()[Card.CardId];
            int bit = Convert.ToInt32(config.type, 2);
            int bit0 = (bit >> 2) & 1;
            if (bit0 == 1)
            {
                int cardid = Card.CardId;
                if (Card.CardId == 1019)
                {
                    cardid = Card.CopyCardId;
                }
                //亡语
                switch (cardid)
                {
                    //kaka
                    case 1009:
                        var card = mainPlayer.StageDeck.Find(x => x.DeadCardId == 1009);
                        if (card != null)
                        {
                            card.TotalLife -= 1;
                            card.TotalAttack -= 1;
                            if (card.TotalLife <= 0)
                            {
                                self.DeadCard(mainPlayer, OtherPlayer);
                            }
                        }
                        break;
                    //fata
                    case 1010:
                        for (int j = 1; j < 6; j++)
                        {
                            if (mainPlayer.StageDeck[j].CardId != 0)
                            {
                                mainPlayer.StageDeck[j].TotalLife += (Card.Star + 1);
                                mainPlayer.StageDeck[j].TotalAttack += (Card.Star + 1);
                            }
                        }
                        break;
                    //w33
                    case 1049:
                        for (int j = 1; j < 6; j++)
                        {
                            if (mainPlayer.StageDeck[j].CardId == 1049)
                            {
                                mainPlayer.StageDeck[j].TotalLife = 0;
                                self.DeadCard(mainPlayer, OtherPlayer);
                            }
                        }
                        break;
                        //EGM
                    case 1055:
                        var cardEGM = mainPlayer.StageDeck.Find(x => x.DeadCardId == 1055);
                        if (cardEGM != null)
                        {
                            cardEGM.DeadCardId = 0;
                        }

                        break;


                }
            }


        }

        public static void FindCardTarget(this GameControllerComponent self, DeckComponent mainPlayer, DeckComponent Other,int i)
        {
            //for (int i = 1; i < 6; i++) 
            {
                //眩晕
                if (mainPlayer.StageDeck[i].CardId != 0 && mainPlayer.StageDeck[i].Disarm == 0 && mainPlayer.StageDeck[i].Fram == 0 && mainPlayer.StageDeck[i].Vertigo <= 0 )
                {
                    //获取队友列表  若为空 则攻击失误没用 还是会攻击对方
                    var random = new Random();
                    int ran = random.Next(0, 11);
                    List<int> AttackList = mainPlayer.GetStageCardPos();
                    if (AttackList.Contains(i))
                    {
                        AttackList.Remove(i);
                    }
                    if (AttackList.Count == 0 || mainPlayer.StageDeck[i].AttackFault == 0 || ran <= mainPlayer.StageDeck[i].AttackFault)
                    {
                        //所有攻击对象
                        List<int> EnemyAttackList = Other.GetStageCardPos();

                        //攻击塔
                        if (EnemyAttackList.Count == 0)
                        {
                            Other.TowerHP -= mainPlayer.StageDeck[i].Star;
                            mainPlayer.playerRoundResult.CardResultList[i].AttackPos.Add(-1);
                        }
                        else
                        {
                            //嘲讽对象
                            List<int> EnemyMockeryList = Other.GetMockeryCardPos();
                            if (EnemyMockeryList.Count > 0)
                            {
                                int targetNum = mainPlayer.StageDeck[i].AttackNum > EnemyMockeryList.Count ? EnemyMockeryList.Count : mainPlayer.StageDeck[i].AttackNum;

                                for (int k = 0; k < targetNum; k++)
                                {
                                    int ranMock = random.Next(0, EnemyMockeryList.Count);
                                    //Other.StageDeck[EnemyMockeryList[ranMock]].TotalLife -= mainPlayer.StageDeck[i].TotalAttack;

                                    var (ReflexDamage, Crit, ReCrit, Dodge, Blind, Reset, damage) = self.AttackTarget(mainPlayer, mainPlayer.StageDeck[i], Other, Other.StageDeck[EnemyMockeryList[ranMock]]);

                                    mainPlayer.playerRoundResult.CardResultList[i].ReflexDamage.Add(ReflexDamage);
                                    mainPlayer.playerRoundResult.CardResultList[i].Crit.Add(Crit);
                                    mainPlayer.playerRoundResult.CardResultList[i].ReCrit.Add(ReCrit);
                                    mainPlayer.playerRoundResult.CardResultList[i].Dodge.Add(Dodge);
                                    mainPlayer.playerRoundResult.CardResultList[i].Blind.Add(Blind);
                                    mainPlayer.playerRoundResult.CardResultList[i].Reset.Add(Reset);
                                    mainPlayer.playerRoundResult.CardResultList[i].AttackDamage.Add(damage);
                                    mainPlayer.playerRoundResult.CardResultList[i].AttackPos.Add(EnemyMockeryList[ranMock]);
                                    mainPlayer.playerRoundResult.CardResultList[i].TotalAttack = mainPlayer.StageDeck[i].TotalAttack;

                                    Other.playerRoundResult.CardResultList[EnemyMockeryList[ranMock]].TotalLife = Other.StageDeck[EnemyMockeryList[ranMock]].TotalLife;
                                    EnemyMockeryList.RemoveAt(ranMock);
                                }


                            }
                            else {
                                int targetNum = mainPlayer.StageDeck[i].AttackNum;
                                //多重攻击
                                for (int k = 0; k < targetNum; k++)
                                {
                                    if (EnemyAttackList.Count == 0)
                                        break;
                                    //是否包含对立位置
                                    if (k == 0 && EnemyAttackList.Contains(i))
                                    {
                                        //Other.StageDeck[i].TotalLife -= mainPlayer.StageDeck[i].TotalAttack;
                                        var (ReflexDamage, Crit, ReCrit, Dodge, Blind, Reset, damage) = self.AttackTarget(mainPlayer, mainPlayer.StageDeck[i], Other, Other.StageDeck[i]);
                                        mainPlayer.playerRoundResult.CardResultList[i].ReflexDamage.Add(ReflexDamage);
                                        mainPlayer.playerRoundResult.CardResultList[i].Crit.Add(Crit);
                                        mainPlayer.playerRoundResult.CardResultList[i].ReCrit.Add(ReCrit);
                                        mainPlayer.playerRoundResult.CardResultList[i].Dodge.Add(Dodge);
                                        mainPlayer.playerRoundResult.CardResultList[i].Blind.Add(Blind);
                                        mainPlayer.playerRoundResult.CardResultList[i].Reset.Add(Reset);
                                        mainPlayer.playerRoundResult.CardResultList[i].AttackDamage.Add(damage);
                                        mainPlayer.playerRoundResult.CardResultList[i].AttackPos.Add(i);
                                        Other.playerRoundResult.CardResultList[i].TotalLife = Other.StageDeck[i].TotalLife;
                                        EnemyAttackList.Remove(i);
                                    }
                                    else
                                    {
                                        //寻找可攻击目标 并随机攻击
                                        int ranAttack = random.Next(0, EnemyAttackList.Count);
                                        //Other.StageDeck[ranAttack].TotalLife -= mainPlayer.StageDeck[i].TotalAttack;
                                        int pos = EnemyAttackList[ranAttack];
                                        var (ReflexDamage, Crit, ReCrit, Dodge, Blind, Reset,damage) = self.AttackTarget(mainPlayer, mainPlayer.StageDeck[i], Other, Other.StageDeck[pos]);
                                        mainPlayer.playerRoundResult.CardResultList[i].ReflexDamage.Add(ReflexDamage);
                                        mainPlayer.playerRoundResult.CardResultList[i].Crit.Add(Crit);
                                        mainPlayer.playerRoundResult.CardResultList[i].ReCrit.Add(ReCrit);
                                        mainPlayer.playerRoundResult.CardResultList[i].Dodge.Add(Dodge);
                                        mainPlayer.playerRoundResult.CardResultList[i].Blind.Add(Blind);
                                        mainPlayer.playerRoundResult.CardResultList[i].Reset.Add(Reset);
                                        mainPlayer.playerRoundResult.CardResultList[i].AttackDamage.Add(damage);
                                        mainPlayer.playerRoundResult.CardResultList[i].AttackPos.Add(pos);
                                        Other.playerRoundResult.CardResultList[pos].TotalLife = Other.StageDeck[pos].TotalLife;
                                        EnemyAttackList.Remove(pos);
                                    }


                                }



                            }

                        }

                    }
                    else
                    {
                        int ran2 = random.Next(0, AttackList.Count);
                        int pos = AttackList[ran2];
                        mainPlayer.StageDeck[pos].TotalLife -= mainPlayer.StageDeck[i].TotalAttack;
                        mainPlayer.playerRoundResult.CardResultList[i].AttackPos.Add(pos + 5);
                    }
                    mainPlayer.playerRoundResult.CardResultList[i].CardId = mainPlayer.StageDeck[i].CardId;
                    mainPlayer.playerRoundResult.CardResultList[i].CardPos = mainPlayer.StageDeck[i].Pos;
                    mainPlayer.playerRoundResult.CardResultList[i].CardStar = mainPlayer.StageDeck[i].Star;
                    mainPlayer.playerRoundResult.CardResultList[i].TotalLife = mainPlayer.StageDeck[i].TotalLife;
                    mainPlayer.playerRoundResult.CardResultList[i].TotalAttack = mainPlayer.StageDeck[i].TotalAttack;
                    mainPlayer.playerRoundResult.CardResultList[i].Armor = mainPlayer.StageDeck[i].Armor;
                    mainPlayer.playerRoundResult.CardResultList[i].Mockery = mainPlayer.StageDeck[i].Mockery;


                }
                else 
                {
                    mainPlayer.playerRoundResult.CardResultList[i].CardId = mainPlayer.StageDeck[i].CardId;
                    mainPlayer.playerRoundResult.CardResultList[i].CardPos = mainPlayer.StageDeck[i].Pos;
                    mainPlayer.playerRoundResult.CardResultList[i].CardStar = mainPlayer.StageDeck[i].Star;
                    mainPlayer.playerRoundResult.CardResultList[i].TotalLife = mainPlayer.StageDeck[i].TotalLife;
                    mainPlayer.playerRoundResult.CardResultList[i].TotalAttack = mainPlayer.StageDeck[i].TotalAttack;
                    mainPlayer.playerRoundResult.CardResultList[i].DisarmRound = mainPlayer.StageDeck[i].Disarm;
                    mainPlayer.playerRoundResult.CardResultList[i].Armor = mainPlayer.StageDeck[i].Armor;
                    mainPlayer.playerRoundResult.CardResultList[i].Mockery = mainPlayer.StageDeck[i].Mockery;


                }



            }
        }

        public static void CardFram(this GameControllerComponent self, DeckComponent mainPlayer)
        {
            for (int i = 1; i < 6; i++)
            {
                if (mainPlayer.StageDeck[i].CardId != 0 && mainPlayer.StageDeck[i].Fram == 1 && mainPlayer.StageDeck[i].Vertigo <= 0)
                {
                    mainPlayer.Coin += mainPlayer.StageDeck[i].FramSpeed;
                    //mainPlayer.StageDeck[i].Fram = 0;
                    mainPlayer.playerRoundResult.CardResultList[i].AttackPos.Add(-2);//-2为fram -1为攻击塔
                }
            }
        }

        public static void AttackEndBalance(this GameControllerComponent self,DeckComponent mainPlayer, DeckComponent OtherPlayer)
        {

            Random ran = new Random();
            for (int i = 1; i < 6; i++) 
            {
                if (mainPlayer.StageDeck[i].CardId != 0)
                {
                    switch (mainPlayer.StageDeck[i].CardId)
                    {
                        
                        //March
                        case 1064:
                            int ranAttack = ran.Next(0, 100);
                            if (ranAttack < 17)
                            {
                                for (int j = 0;j< mainPlayer.playerRoundResult.CardResultList[i].AttackPos.Count;j++)
                                {
                                    OtherPlayer.StageDeck[mainPlayer.playerRoundResult.CardResultList[i].AttackPos[j]].Vertigo = 2;


                                }

                                


                            }
                            break;
                        case 0:

                            break;
                    }

                    if (mainPlayer.StageDeck[i].BuffList.ContainsKey(1063))
                    {
                        //garder
                        if (mainPlayer.StageDeck[i].ReAttackNum >= 2)
                        {
                            List<int> attacklist = new List<int>();
                            var card1063 = mainPlayer.StageDeck.Find(x => x.CardId == 1063);
                            for (int j = 1; j < 6; j++)
                            {
                                if (OtherPlayer.playerRoundResult.CardResultList[j].AttackPos.Contains(i))
                                {
                                    attacklist.Add(j);
                                    OtherPlayer.StageDeck[j].Vertigo = 2;
                                    SkillCard skillCard = new SkillCard();
                                    mainPlayer.playerRoundResult.CardResultList[card1063.Pos].UseSkill.Add(j);
                                    mainPlayer.playerRoundResult.CardResultList[card1063.Pos].UseSkillDmg.Add(0);
                                }
                            }
                            int ranId = ran.Next(0, attacklist.Count);
                            OtherPlayer.StageDeck[attacklist[ranId]].TotalLife -= mainPlayer.StageDeck[i].Star * 2 + 1;
                            mainPlayer.playerRoundResult.CardResultList[card1063.Pos].UseSkillDmg[ranId] = mainPlayer.StageDeck[i].Star * 2 + 1;



                        }
                    }

                }
            }

        }
        
        public static void CompareCard(this GameControllerComponent self)
        {

            Room room = self.GetParent<Room>();
            DeckComponent deckComponent1 = room.gamers[0].GetComponent<DeckComponent>();
            DeckComponent deckComponent2 = room.gamers[1].GetComponent<DeckComponent>();
            deckComponent1.playerRoundResult.UnitId = room.gamers[0].UserID;
            deckComponent2.playerRoundResult.UnitId = room.gamers[1].UserID;


            //self.CompareCardTwoPlayer(deckComponent1, deckComponent2);
            //for (int i = 1; i < 6; i++)
            //{
            //    for (int j = 1; j < 4; j++)
            //    {
            //        self.CompareCardPlayer(deckComponent1, deckComponent2, j, i);
            //        self.CompareCardPlayer(deckComponent2, deckComponent1, j, i);
            //    }
            //}



            for (int i = 1; i < 6; i++)
            {
                deckComponent1.StageDeck[i].ReAttackNum = 0;
                deckComponent2.StageDeck[i].ReAttackNum = 0;
                deckComponent1.playerRoundResult.CardResultList[i].UseSkillCD = deckComponent1.StageDeck[i].UseSkillCd;
                deckComponent2.playerRoundResult.CardResultList[i].UseSkillCD = deckComponent2.StageDeck[i].UseSkillCd;
            }
            for (int i = 1; i < 6; i++)
            {
                int Card1Life = deckComponent1.StageDeck[i].TotalLife;
                int Card2Life = deckComponent2.StageDeck[i].TotalLife;
                
                if (Card1Life > 0)
                {
                    self.FindCardTarget(deckComponent1, deckComponent2, i);
                }
                if (Card2Life > 0)
                {
                    self.FindCardTarget(deckComponent2, deckComponent1, i);
                }   
            }

            self.AttackEndBalance(deckComponent1,deckComponent2);
            self.AttackEndBalance(deckComponent2,deckComponent1);

            self.CardFram(deckComponent1);
            self.CardFram(deckComponent2);


            self.DeadCard(deckComponent1, deckComponent2);
            self.DeadCard(deckComponent2, deckComponent1);


            

            self.StatusEndRound(deckComponent1);
            self.StatusEndRound(deckComponent2);
            self.Round += 1;
            deckComponent1.playerRoundResult.Round = self.Round;
            deckComponent2.playerRoundResult.Round = self.Round;
            deckComponent1.playerRoundResult.TowerHp = deckComponent1.TowerHP;
            deckComponent2.playerRoundResult.TowerHp = deckComponent2.TowerHP;
            deckComponent1.playerRoundResult.Coin = deckComponent1.Coin;
            deckComponent2.playerRoundResult.Coin = deckComponent2.Coin;

            //1赢 2输 3平局 
            if (deckComponent1.TowerHP <= 0 && deckComponent2.TowerHP <= 0)
            {
                deckComponent1.playerRoundResult.winorlose = 3;
                deckComponent2.playerRoundResult.winorlose = 3;
                room.gamers[0].win = 3;
                room.gamers[1].win = 3;
                room.GameOver().Coroutine();
            }
            else if (deckComponent1.TowerHP <= 0 && deckComponent2.TowerHP > 0)
            {
                deckComponent1.playerRoundResult.winorlose = 2;
                deckComponent2.playerRoundResult.winorlose = 1;
                room.gamers[0].win = 2;
                room.gamers[1].win = 1;
                room.GameOver().Coroutine();
            }
            else if (deckComponent1.TowerHP >0 && deckComponent2.TowerHP <= 0)
            {
                deckComponent1.playerRoundResult.winorlose = 1;
                deckComponent2.playerRoundResult.winorlose = 2;
                room.gamers[0].win = 1;
                room.gamers[1].win = 2;
                room.GameOver().Coroutine();
            }
            


        }
    }
}
