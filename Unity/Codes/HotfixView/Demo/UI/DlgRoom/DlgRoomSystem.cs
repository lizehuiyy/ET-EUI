using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ILRuntime.Runtime;
using UnityEngine.UIElements;
using DG.Tweening;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using ILRuntime.Runtime.Debugger.Protocol;


namespace ET
{
    public class DlgRoomAwakeSystem : AwakeSystem<DlgRoom>
    {
        public override void Awake(DlgRoom self)
        {
            self.HeroStageCard = new List<GameObject>();
            self.Player1CardLibraryItem = new List<GameObject>();
            self.Player2CardLibraryItem = new List<GameObject>();
            self.SelectCardId = 0;
            self.arrowEffectManager = self.View.EGArrowEffectRectTransform.gameObject.GetComponent<ArrowEffectManager>();
            Log.Debug(self.arrowEffectManager + "self.arrowEffectManager");
          
           
            self.HeroScrollBuff = new List<LoopVerticalScrollRect>();
        }
    }

    public class DlgRoomDestroySystem : DestroySystem<DlgRoom>
    {
        public override void Destroy(DlgRoom self)
        {
            
        }
    }




    [FriendClass(typeof(DlgRoom))]
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    [FriendClassAttribute(typeof(ET.GameControlComponent))]
    [FriendClassAttribute(typeof(ET.Scroll_Item_backhero))]
    [FriendClassAttribute(typeof(ET.Scroll_Item_hardhero))]
    public static class DlgRoomSystem
    {

        public static void RegisterUIEvent(this DlgRoom self)
        {
            self.View.ELoopScrollList_player1LoopHorizontalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollPlayer1RefreshHandler(transform, index);
            });
            self.View.ELoopScrollList_player2LoopHorizontalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollPlayer2RefreshHandler(transform, index);
            });


            self.View.EButton_EndButton.AddListenAsync(self.OnClickEndHandler);
            self.View.EButton_GGButton.AddListenAsync(self.OnClickGGHandler);


            self.View.EButton_SelectPos1Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 1);
            self.View.EButton_SelectPos2Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 2);
            self.View.EButton_SelectPos3Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 3);
            self.View.EButton_SelectPos4Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 4);
            self.View.EButton_SelectPos5Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 5);
            self.View.EButton_SelectPos6Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 6);
            self.View.EButton_SelectPos7Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 7);
            self.View.EButton_SelectPos8Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 8);
            self.View.EButton_SelectPos9Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 9);
            self.View.EButton_SelectPos10Button.AddListenerAsyncWithId(self.OnClickSelectPosCardHandler, 10);






            self.InitStageHero();
        }
        public static void InitStageHero(this DlgRoom self)
        {
            GameObject StageCard = null;

            self.Player1CardLibraryItem.Add(self.View.EGItem1_player1LibraryRectTransform.gameObject);
            self.Player2CardLibraryItem.Add(self.View.EGItem1_player2LibraryRectTransform.gameObject);
            self.Player1CardLibraryItem.Add(self.View.EGItem2_player1LibraryRectTransform.gameObject);
            self.Player2CardLibraryItem.Add(self.View.EGItem2_player2LibraryRectTransform.gameObject);
            self.Player1CardLibraryItem.Add(self.View.EGItem3_player1LibraryRectTransform.gameObject);
            self.Player2CardLibraryItem.Add(self.View.EGItem3_player2LibraryRectTransform.gameObject);
            self.Player1CardLibraryItem.Add(self.View.EGItem4_player1LibraryRectTransform.gameObject);
            self.Player2CardLibraryItem.Add(self.View.EGItem4_player2LibraryRectTransform.gameObject);
            self.Player1CardLibraryItem.Add(self.View.EGItem5_player1LibraryRectTransform.gameObject);
            self.Player2CardLibraryItem.Add(self.View.EGItem5_player2LibraryRectTransform.gameObject);

            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (i == 1 && j == 1)
                        StageCard = self.View.EGplayer1_stagehero1RectTransform.gameObject;
                    else if (i == 1 && j == 2)
                        StageCard = self.View.EGplayer1_stagehero2RectTransform.gameObject;
                    else if (i == 1 && j == 3)
                        StageCard = self.View.EGplayer1_stagehero3RectTransform.gameObject;
                    else if (i == 1 && j == 4)
                        StageCard = self.View.EGplayer1_stagehero4RectTransform.gameObject;
                    else if (i == 1 && j == 5)
                        StageCard = self.View.EGplayer1_stagehero5RectTransform.gameObject;
                    else if (i == 2 && j == 1)
                        StageCard = self.View.EGplayer2_stagehero1RectTransform.gameObject;
                    else if (i == 2 && j == 2)
                        StageCard = self.View.EGplayer2_stagehero2RectTransform.gameObject;
                    else if (i == 2 && j == 3)
                        StageCard = self.View.EGplayer2_stagehero3RectTransform.gameObject;
                    else if (i == 2 && j == 4)
                        StageCard = self.View.EGplayer2_stagehero4RectTransform.gameObject;
                    else if (i == 2 && j == 5)
                        StageCard = self.View.EGplayer2_stagehero5RectTransform.gameObject;
                    self.HeroStageCard.Add(StageCard);


                }
            }
            self.View.ELoopScrollList_BuffList1LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 1);
            });
            self.View.ELoopScrollList_BuffList2LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 2);
            });
            self.View.ELoopScrollList_BuffList3LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 3);
            });
            self.View.ELoopScrollList_BuffList4LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 4);
            });
            self.View.ELoopScrollList_BuffList5LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 5);
            });
            self.View.ELoopScrollList_BuffList6LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 6);
            });
            self.View.ELoopScrollList_BuffList7LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 7);
            });
            self.View.ELoopScrollList_BuffList8LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 8);
            });
            self.View.ELoopScrollList_BuffList9LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 9);
            });
            self.View.ELoopScrollList_BuffList10LoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollScrollBuffListHandler(transform, index, 10);
            });


        }
        public static async ETTask InitStageCard(this DlgRoom self, int cardid, int pos)
        {
            GameObject ContectRect = self.HeroStageCard[pos - 1];




            await ETTask.CompletedTask;
        }


        public static async ETTask OnClickSelectPosCardHandler(this DlgRoom self, int index)
        {
            int cardid = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().SelectSkillCard;
            StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardid);
            useCard.UseSkill2 = index;
            Log.Debug("OnClickSelectPosCardHandler" + index + "index---cardid" + cardid);
            Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.View.EGArrowEffectParentRectTransform.SetVisible(false);
            self.View.EButton_SelectPos1Button.SetVisible(false);
            self.View.EButton_SelectPos2Button.SetVisible(false);
            self.View.EButton_SelectPos3Button.SetVisible(false);
            self.View.EButton_SelectPos4Button.SetVisible(false);
            self.View.EButton_SelectPos5Button.SetVisible(false);
            await ETTask.CompletedTask;
        }
        public static async ETTask ShowBuffListRound(this DlgRoom self, PlayerRoundResult roundResult, int player)
        {
            DeckComponent deckComponent = self.ZoneScene().GetComponent<Room>().GetGamer(player - 1).GetComponent<DeckComponent>();
            for (int i = 1; i < 6; i++)
            {
                if (roundResult.CardResultList[i].CardId != 0 && deckComponent.StageDeck[i].CardId == roundResult.CardResultList[i].CardId)
                {
                    for (int j = 1; j < roundResult.CardResultList[i].BuffList.Count; j++)
                    {
                        if (deckComponent.StageDeck[i].BuffList.ContainsKey(roundResult.CardResultList[i].BuffList[j].BuffCardId))
                        {

                        }
                        else
                        {
                            switch (roundResult.CardResultList[i].BuffList[j].BuffCardId)
                            {
                                //ceb
                                case 1003:
                                    deckComponent.StageDeck[i].TotalAttack += roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    break;
                                //yatoro
                                case 1004:
                                    deckComponent.StageDeck[i].TotalLife -= roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    deckComponent.StageDeck[i].TotalAttack -= roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    break;
                                //xiao8
                                case 1016:
                                    deckComponent.StageDeck[i].TotalLife += roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    break;
                                //sumail
                                case 1038:
                                    deckComponent.StageDeck[i].TotalLife -= roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    deckComponent.StageDeck[i].TotalAttack -= roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    break;
                                //noone
                                case 1039:
                                    deckComponent.StageDeck[i].TotalLife -= roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    deckComponent.StageDeck[i].TotalAttack -= roundResult.CardResultList[i].BuffList[j].BuffNum;
                                    break;
                            }
                        }

                    }
                }

            }

            GameObject CardContect = null;




            for (int k = 1; k < 6; k++)
            {
                if (player == 1)
                {
                    CardContect = self.HeroStageCard[k - 1];
                }
                else if (player == 2)
                {
                    CardContect = self.HeroStageCard[k + 4];
                }

                Text Label_Attack = CardContect.transform.Find("ContectRect/Label_attack").GetComponent<Text>();
                Text Label_Life = CardContect.transform.Find("ContectRect/Label_life").GetComponent<Text>();
                Log.Debug(deckComponent.StageDeck[k].TotalAttack + "ShowBuffListRound" + deckComponent.StageDeck[k].TotalLife);
                Label_Attack.SetText("" + deckComponent.StageDeck[k].TotalAttack);
                Label_Life.SetText("" + deckComponent.StageDeck[k].TotalLife);
            }
            await ETTask.CompletedTask;
        }


        public static async ETTask ShowRoundEndHeroAnim(this DlgRoom self, PlayerRoundResult roundResult, int player)
        {
            DeckComponent deckComponent = self.ZoneScene().GetComponent<Room>().GetGamer(player - 1).GetComponent<DeckComponent>();

            DeckComponent EndeckComponent = null;
            if (player == 1)
            {
                EndeckComponent = self.ZoneScene().GetComponent<Room>().GetGamer(1).GetComponent<DeckComponent>();
            }

            else if (player == 2)
            {
                EndeckComponent = self.ZoneScene().GetComponent<Room>().GetGamer(0).GetComponent<DeckComponent>();
            }
            
            for (int i = 0; i < roundResult.useCardList.Count; i++)
            {
                var useCardProto = roundResult.useCardList[i];
                switch (useCardProto.CardId)
                {
                    //Chalice
                    case 1033:
                        for (int j = 0; i < useCardProto.CardList.Count; j++)
                        {
                            self.libraryUpCardAnim(player, useCardProto.CardList[j].CardId, useCardProto.CardList[j].CardPos, i);
                        }
                        break;
                    //Skiter
                    case 1036:
                        for (int j = 0; j < useCardProto.CardList.Count; j++)
                        {
                            await TimerComponent.Instance.WaitAsync(3000);
                            self.MateCardAnim(player, useCardProto.CardPos, useCardProto.CardList[j].CardId, useCardProto.CardList[j].CardPos, useCardProto.CardList[j].CardAttack, useCardProto.CardList[j].CardLife);
                        }
                        break;
                    //W33
                    case 1049:

                        for (int j = 0; j < useCardProto.CardList.Count; j++)
                        {
                            await TimerComponent.Instance.WaitAsync(3000);
                            self.MateCardAnim(player, useCardProto.CardPos, useCardProto.CardList[j].CardId, useCardProto.CardList[j].CardPos, useCardProto.CardList[j].CardAttack, useCardProto.CardList[j].CardLife);
                        }
                        break;
                    //Bulba
                    case 1052:
                        for (int j = 0; j < useCardProto.CardList.Count; j++)
                        {
                            Log.Debug(j + "cardid bulba " + useCardProto.CardList[j].CardId);
                        }
                        break;
                    //Zfreek
                    case 1062:
                        for (int j = 0; j < useCardProto.CardList.Count; j++)
                        {
                            int targetplayer = player == 1 ? 2 : 1;
                            self.RemoveCardAnim(targetplayer, useCardProto.CardList[j].CardPos);
                        }
                        break;
                }



            }

            for (int k = 1; k < 6; k++)
            {

                var CardResultProto = roundResult.CardResultList[k];
                if (CardResultProto.CardId == 0)
                {
                    continue;
                }

                GameObject ItemHero = null;
                if (player == 1)
                {
                    ItemHero = self.HeroStageCard[CardResultProto.CardPos - 1];
                }
                else if (player == 2)
                {
                    ItemHero = self.HeroStageCard[CardResultProto.CardPos + 4];
                }
                //Sneyking
                switch (CardResultProto.CardId)
                {
                    case 1037:
                        StageCardState cardSneyking = deckComponent.StageDeck.Where(x => x.CardId == 1037).FirstOrDefault();
                        if (CardResultProto != null && cardSneyking != null && CardResultProto.UseSkill.Count>0)
                        {
                            Log.Debug("切换Sneyking跳跃英雄" + CardResultProto.CardPos + "curpos" + cardSneyking.Pos);
                            if (CardResultProto.CardPos != cardSneyking.Pos)
                            {
                                int pos = cardSneyking.Pos;
                                int cardid = CardResultProto.CardId;
                                int curpos = CardResultProto.CardPos;
                                int attack = cardSneyking.TotalAttack;
                                int life = cardSneyking.TotalLife;
                                Log.Debug("切换Sneyking跳跃英雄" + "cardid" + cardid + "pos" + pos + "curpos" + curpos + "attack" + attack + "life" + life);
                                self.MovePosCardAnim(player, pos, cardid, curpos, attack, life);

                            }
                        }
                        break;
                        //820
                    case 1045:
                        StageCardState card820 = deckComponent.StageDeck.Where(x => x.CardId == 1037).FirstOrDefault();
                        if (CardResultProto != null && card820 != null && CardResultProto.UseSkill.Count > 0)
                        {
                            Log.Debug("切换820英雄" + CardResultProto.CardPos + "curpos" + card820.Pos);
                            if (CardResultProto.UseSkill.Count > 0 && CardResultProto.UseSkill[0] > 0 && CardResultProto.UseSkill[0] < 6)
                            {
                                int pos = card820.Pos;
                                int cardid = CardResultProto.CardId;
                                int curpos = CardResultProto.CardPos;
                                int attack = card820.TotalAttack;
                                int life = card820.TotalLife;

                                int cardtargetId = deckComponent.StageDeck[CardResultProto.UseSkill[0]].CardId;
                                int cardtargetattack = deckComponent.StageDeck[CardResultProto.UseSkill[0]].TotalAttack;
                                int cardtargetlife = deckComponent.StageDeck[CardResultProto.UseSkill[0]].TotalLife;
                                Log.Debug("切换820英雄" + "cardid" + cardid + "pos" + pos + "curpos" + curpos + "attack" + attack + "life" + life);
                                self.MovePosCardAnim(player, pos, cardid, curpos, attack, life, true);
                                self.MovePosCardAnim(player, CardResultProto.UseSkill[0], cardtargetId, pos, cardtargetattack, cardtargetlife, true);

                            }
                        }
                        break;

                    //XBOCT
                    case 1054:
                       
                        for (int v = 0; v < CardResultProto.UseSkill.Count; v++)
                        {
                            Debug.Log(CardResultProto.UseSkill[v] + "酸雾扣血" + CardResultProto.UseSkillDmg[v]);
                            GameObject target = null;
                            if (player == 2)
                            {
                                target = self.HeroStageCard[CardResultProto.UseSkill[v] - 1];
                            }
                            else if (player == 1)
                            {
                                target = self.HeroStageCard[CardResultProto.UseSkill[v] + 4];
                            }
                            Debug.Log(EndeckComponent.StageDeck[CardResultProto.UseSkill[v]].TotalLife + "酸雾扣血" + CardResultProto.UseSkillDmg[v]);
                            EndeckComponent.StageDeck[CardResultProto.UseSkill[v]].TotalLife -= CardResultProto.UseSkillDmg[v];
                            Text Label_life = target.transform.Find("ContectRect/Label_life").GetComponent<Text>();
                            
                            Label_life.text = "" + EndeckComponent.StageDeck[CardResultProto.UseSkill[v]].TotalLife;
                        }

                        break;
                    //Sylar
                    case 1057:
                        if (CardResultProto.UseSkill.Count > 0)
                        {
                            deckComponent.StageDeck[CardResultProto.CardPos].TotalLife += CardResultProto.CardStar + 2;
                           
                            Text Label_life1 = ItemHero.transform.Find("ContectRect/Label_life").GetComponent<Text>();
                            Label_life1.text = "" + deckComponent.StageDeck[CardResultProto.CardPos].TotalLife;
                        }


                        break;
                    //QO
                    case 1060:
                        if (CardResultProto.UseSkill.Count > 0)
                        {
                            StageCardState cardQO = deckComponent.StageDeck.Where(x => x.CardId == 1060).FirstOrDefault();
                            
                            
                            if (CardResultProto.UseSkill[0] == 1)
                            {
                                int pos = cardQO.Pos;
                                int cardid = CardResultProto.CardId;
                                int curpos = CardResultProto.CardPos;
                                int attack = cardQO.TotalAttack;
                                int life = cardQO.TotalLife;
                                self.MovePosCardAnim(player, pos, cardid, curpos, attack, life);
                            }
                            else if (CardResultProto.UseSkill[0] == 2)
                            {

                            }
                            else if (CardResultProto.UseSkill[0] == 3)
                            {
                                //deckComponent.StageDeck[CardResultProto.CardPos].TotalAttack += 3;
                                //Text Label_attack = ItemHero.transform.Find("ContectRect/Label_attack").GetComponent<Text>();
                                //Label_attack.text = "" + deckComponent.StageDeck[CardResultProto.CardPos].TotalAttack;
                            }

                            
                        }
                        break;
                    //霸气
                    case 1061:
                        for (int j = 0; j < CardResultProto.CardList.Count; j++)
                        {
                            await TimerComponent.Instance.WaitAsync(3000);
                            self.MateCardAnim(player, CardResultProto.CardPos, CardResultProto.CardList[j].CardId, CardResultProto.CardList[j].CardPos, CardResultProto.CardList[j].CardAttack, CardResultProto.CardList[j].CardLife);
                        }
                        break;


                }
                deckComponent.StageDeck[CardResultProto.CardPos].UseSkillCd = CardResultProto.UseSkillCD;
                Log.Debug(CardResultProto.CardId +"CardResultProto.UseSkillCD" + CardResultProto.UseSkillCD);
                int bit1 = CardResultProto.UseSkillCD  & 1;
                int bit2 = CardResultProto.UseSkillCD >> 1 & 1;
                int bit3 = CardResultProto.UseSkillCD >> 2 & 1;
                UnityEngine.UI.Button Button_Skill = ItemHero.transform.Find("ContectRect/StatePanel/Button_Skill").GetComponent<UnityEngine.UI.Button>();
                UnityEngine.UI.Button Button_Skill1 = ItemHero.transform.Find("ContectRect/StatePanel/Button_Skill1").GetComponent<UnityEngine.UI.Button>();
                UnityEngine.UI.Button Button_Skill2 = ItemHero.transform.Find("ContectRect/StatePanel/Button_Skill2").GetComponent<UnityEngine.UI.Button>();

                Button_Skill.interactable = bit1 == 0 ? false : true;
                Button_Skill1.interactable = bit2 == 0 ? false : true;
                Button_Skill2.interactable = bit3 == 0 ? false : true;


                if (CardResultProto.CardId != 0)
                {
                    
                    GameObject Image_disarm = ItemHero.transform.Find("ContectRect/Image_disarm").gameObject;
                    if (CardResultProto.DisarmRound > 0)
                    {
                        Log.Debug(CardResultProto.CardId + "--" + CardResultProto.CardPos + "CardResultProto.DisarmRound" + CardResultProto.DisarmRound);
                        Image_disarm.SetActive(true);
                    }
                    else
                    {
                        Image_disarm.SetActive(false);
                    }

                    GameObject Image_Mockery = ItemHero.transform.Find("ContectRect/Image_Mockery").gameObject;
                    if (CardResultProto.Mockery > 0)
                    {
                        Image_Mockery.SetActive(true);
                    }
                    else {
                        Image_Mockery.SetActive(false);
                    }
                    GameObject Image_Armor = ItemHero.transform.Find("ContectRect/Image_Armor").gameObject;
                    Text Label_Armor = ItemHero.transform.Find("ContectRect/Label_Armor").GetComponent<Text>();
                    if (CardResultProto.Armor > 0)
                    {
                        Image_Armor.SetActive(true);
                        Label_Armor.gameObject.SetActive(true);
                        Label_Armor.text = CardResultProto.Armor + "";
                    }
                    else
                    {
                        Image_Armor.SetActive(false);
                        Label_Armor.gameObject.SetActive(false);
                    }


                    
                }




            }
            await ETTask.CompletedTask;
        }



        public static async ETTask ShowEndRoundCard(this DlgRoom self)
        {


            Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().UseCardList.Clear();
            Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Clear();

            GameControlComponent gameControlComponent = self.ZoneScene().GetComponent<Room>().GetComponent<GameControlComponent>();
            long MyId = self.ZoneScene().GetComponent<PlayerComponent>().MyId;

            PlayerRoundResult MyPlayerRoundResult = null;
            PlayerRoundResult EnemyPlayerRoundResult = null;

            foreach (var item in gameControlComponent.PlayerRoundResultList)
            {
                if (item.UnitId == MyId)
                {
                    MyPlayerRoundResult = item;
                }
                else
                {
                    EnemyPlayerRoundResult = item;
                }
            }
            Log.Debug("ShowEndRoundCard" + MyPlayerRoundResult.Round);
            //上场敌方英雄
            Log.Debug("上场敌方英雄" + EnemyPlayerRoundResult.useCardList.Count);
            for (int i = 0; i < EnemyPlayerRoundResult.useCardList.Count; i++)
            {
                await self.EnemyUpCardAnim(EnemyPlayerRoundResult.useCardList[i].CardId, EnemyPlayerRoundResult.useCardList[i].CardPos, i);
            }





            await self.ShowRoundEndHeroAnim(MyPlayerRoundResult, 1);

            await self.ShowRoundEndHeroAnim(EnemyPlayerRoundResult, 2);

            await self.ShowBuffListRound(MyPlayerRoundResult, 1);

            await self.ShowBuffListRound(EnemyPlayerRoundResult, 2);

            Log.Debug("123");
            await TimerComponent.Instance.WaitAsync(3000);
            Log.Debug("456");
            Log.Debug("循环遍历自己与敌人相同位置的卡互相攻击");
            //循环遍历自己与敌人相同位置的卡互相攻击
            float time = 0;
            for (int i = 1; i < 6; i++)
            {
                CardResult cardResult = MyPlayerRoundResult.CardResultList[i];
                CardResult cardResult1 = EnemyPlayerRoundResult.CardResultList[i];
                if (cardResult.CardId != 0)
                {
                    for (int j = 0; j < cardResult.AttackPos.Count; j++)
                    {
                        if (cardResult.AttackPos[j] != -1)
                        {
                            time = self.AttackAnim(1, cardResult, j, MyPlayerRoundResult.CardResultList, EnemyPlayerRoundResult.CardResultList);
                            await TimerComponent.Instance.WaitAsync((long)time * 1000);
                        }
                    }
                }
                Log.Debug("敌人的卡" + i + "cardid" + cardResult1.CardId);
                if (cardResult1.CardId != 0)
                {
                    for (int k = 0; k < cardResult1.AttackPos.Count; k++)
                    {
                        if (cardResult1.AttackPos[k] != -1)
                        {
                            time = self.AttackAnim(2, cardResult1, k, EnemyPlayerRoundResult.CardResultList, MyPlayerRoundResult.CardResultList);
                            await TimerComponent.Instance.WaitAsync((long)time * 1000);
                        }

                    }
                }

            }
            Log.Debug("调用等待时间前");
            await TimerComponent.Instance.WaitAsync((long)time * 1000 + 1000);


            // 遍历攻击塔
            Log.Debug("遍历攻击塔");
            for (int k = 1; k < 6; k++)
            {

                CardResult cardResult1 = MyPlayerRoundResult.CardResultList[k];
                CardResult cardResult2 = EnemyPlayerRoundResult.CardResultList[k];
                for (int i = 0; i < cardResult1.AttackPos.Count; i++)
                {
                    if (cardResult1.CardId != 0 && cardResult1.AttackPos[i] == -1)
                    {
                        Log.Debug(cardResult1.CardPos + "遍历攻击塔" + cardResult1.CardId + "攻击位置" + cardResult1.AttackPos[i]);
                        time = self.AttackAnim(1, cardResult1, i, MyPlayerRoundResult.CardResultList, EnemyPlayerRoundResult.CardResultList);

                    }

                }
                for (int i = 0; i < cardResult2.AttackPos.Count; i++)
                {
                    if (cardResult2.CardId != 0 && cardResult2.AttackPos[i] == -1)
                    {

                        Log.Debug("遍历攻击塔" + cardResult2.CardId + "攻击位置" + cardResult2.AttackPos);
                        time = self.AttackAnim(2, cardResult2, i, EnemyPlayerRoundResult.CardResultList, MyPlayerRoundResult.CardResultList);

                    }
                }


            }
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);
            Gamer gamer2 = self.ZoneScene().GetComponent<Room>().GetGamer(1);
            gamer1.GetComponent<DeckComponent>().TowerHP = MyPlayerRoundResult.TowerHp;
            gamer2.GetComponent<DeckComponent>().TowerHP = EnemyPlayerRoundResult.TowerHp;

            self.View.ELabel_Player1TowerHpText.SetText(gamer1.GetComponent<DeckComponent>().TowerHP + "");
            self.View.ELabel_Player2TowerHpText.SetText(gamer2.GetComponent<DeckComponent>().TowerHP + "");
            await TimerComponent.Instance.WaitAsync(2000);
            Log.Debug("判断输赢" + MyPlayerRoundResult.winorlose);
            if (MyPlayerRoundResult.winorlose > 0)
            {
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_GameMain);
                self.DomainScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Room);

            }



            // 遍历fram

            Log.Debug("遍历fram");
            for (int u = 1; u < 6; u++)
            {
                CardResult cardResult1 = MyPlayerRoundResult.CardResultList[u];
                if (cardResult1.AttackPos.Contains(-2))
                {
                    self.FramAnim(1, u);
                }

                CardResult cardResult2 = EnemyPlayerRoundResult.CardResultList[u];
                if (cardResult2.AttackPos.Contains(-2))
                {
                    self.FramAnim(2, u);
                }

            }
            await TimerComponent.Instance.WaitAsync(3000);
            self.View.EButton_EndButton.interactable = true;

            await ETTask.CompletedTask;
        }

        public static async ETTask EnemyUpCardAnim(this DlgRoom self, int cardId, int targetpos, int i)
        {
            Gamer gamer2 = Game.zoneScene.GetComponent<Room>().GetGamer(1);
            int Count = gamer2.GetComponent<DeckComponent>().HardDeck.Count;
            Scroll_Item_backhero itemhero = self.ScrollPlayer2HardDic[i];
            Transform contentRect = itemhero.EGContectRectRectTransform;
            GameObject TargetCardContect = self.HeroStageCard[targetpos + 4].transform.Find("ContectRect").gameObject;
            Vector3 target = TargetCardContect.transform.position + new Vector3(0, 0, -20);
            contentRect.DOMove(target, 1f).SetDelay(0.3f).OnComplete(() =>
            {
                contentRect.DOLocalMove(new Vector3(contentRect.localPosition.x, contentRect.localPosition.y, 0), 1f).OnComplete(() =>
                {
                    contentRect.transform.localPosition = Vector3.zero;
                    gamer2.GetComponent<DeckComponent>().HardDeck.RemoveAt(i);
                    self.ShowEnemyCard();

                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowStageCard(true, 2, targetpos, cardId);
                    Debug.Log("EnemyUpCardAnimEnd1");

                });
            });
            await TimerComponent.Instance.WaitAsync(2300);
            Debug.Log("EnemyUpCardAnimEnd2");
            
        }
        public static void ChangeCardAnim(this DlgRoom self, int player, int cardId, int pos, int targetpos)
        {
            Gamer gamer = null;
            GameObject itemhero = null;
            GameObject Targetitemhero = null;
            DeckComponent deckComponent = null;
            if (player == 1)
            {
                gamer = Game.zoneScene.GetComponent<Room>().GetGamer(0);
                itemhero = self.HeroStageCard[pos - 1];
                Targetitemhero = self.HeroStageCard[targetpos - 1];
            }
            else if (player == 2)
            {
                gamer = Game.zoneScene.GetComponent<Room>().GetGamer(1);
                itemhero = self.HeroStageCard[pos + 4];
                Targetitemhero = self.HeroStageCard[targetpos + 4];
            }
            deckComponent = gamer.GetComponent<DeckComponent>();
            Transform contentRect = itemhero.transform.Find("ContectRect");
            GameObject TargetCardContect = Targetitemhero.transform.Find("ContectRect").gameObject;
            Vector3 target = TargetCardContect.transform.position + new Vector3(0, 0, -20);
            contentRect.DOMove(target, 1f).SetDelay(0.3f).OnComplete(() =>
            {
                contentRect.DOLocalMove(new Vector3(contentRect.localPosition.x, contentRect.localPosition.y, 0), 1f).OnComplete(() =>
                {
                    contentRect.transform.localPosition = Vector3.zero;

                    itemhero.gameObject.SetActive(false);
                    StageCardState stageCardState = new StageCardState();
                    deckComponent.StageDeck[pos] = stageCardState;
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowStageCard(true, player, targetpos, cardId);


                });
            });
        }
        //i为牌库的第几张
        public static void libraryUpCardAnim(this DlgRoom self, int player, int cardId, int targetpos, int i)
        {

            Gamer gamer1 = Game.zoneScene.GetComponent<Room>().GetGamer(player - 1);
            Log.Debug(player + "MylibraryUpCardAnim" + cardId + "pos" + targetpos);
            GameObject itemhero = null;
            GameObject TargetCardContect = null;
            if (player == 1)
            {
                itemhero = self.Player1CardLibraryItem[i];
                TargetCardContect = self.HeroStageCard[targetpos - 1].transform.Find("ContectRect").gameObject;
            }
            else if (player == 2)
            {
                itemhero = self.Player2CardLibraryItem[i];
                TargetCardContect = self.HeroStageCard[targetpos + 4].transform.Find("ContectRect").gameObject;
            }

            Transform contentRect = itemhero.transform.Find("ContectRect"); ;
            Vector3 target = TargetCardContect.transform.position + new Vector3(0, 0, -20);
            contentRect.DOMove(target, 1f).SetDelay(0.3f).OnComplete(() =>
            {
                contentRect.DOLocalMove(new Vector3(contentRect.localPosition.x, contentRect.localPosition.y, 0), 1f).OnComplete(() =>
                {
                    contentRect.transform.localPosition = Vector3.zero;
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowStageCard(true, 1, targetpos, cardId);


                });
            });
        }

        public static void RemoveCardAnim(this DlgRoom self, int player, int cardPos)
        {
            Gamer gamer = null;
            GameObject itemhero = null;
            GameObject target = null;
            Log.Debug("RemoveCardAnim" + player + "cardPos" + cardPos);
            if (player == 1)
            {
                gamer = Game.zoneScene.GetComponent<Room>().GetGamer(0);
                itemhero = self.HeroStageCard[cardPos - 1];
                target = self.View.EGItem1_player1LibraryRectTransform.gameObject;
            }
            else if(player == 2)
            {
                gamer = Game.zoneScene.GetComponent<Room>().GetGamer(1);
                itemhero = self.HeroStageCard[cardPos + 4];
                target = self.View.EGItem2_player2LibraryRectTransform.gameObject;
            }
            Transform contentRect = itemhero.transform.Find("ContectRect"); 

            contentRect.DOMove(target.transform.position, 2f).SetDelay(0.3f).OnComplete(() =>
            {
                
                itemhero.SetActive(false);
                contentRect.transform.localPosition = Vector3.zero;
            });
            Vector3 targetRo = new Vector3(0, 0, -1080);
            contentRect.transform.DORotate(targetRo, 2f, RotateMode.FastBeyond360).OnComplete(() =>
            {
                contentRect.transform.localRotation = new Quaternion(0,0,0,0);
            });

        }



        //分身系英雄
        public static void MateCardAnim(this DlgRoom self, int player, int cardPos, int cardId, int targetpos, int cardAttack, int cardLife)
        {
            Gamer gamer1 = Game.zoneScene.GetComponent<Room>().GetGamer(player - 1);
            Log.Debug("MateCardAnim" + cardId + "pos" + targetpos);
            GameObject itemhero = null;
            GameObject TargetCardContect = null;
            if (player == 1)
            {
                itemhero = self.HeroStageCard[cardPos - 1];
                TargetCardContect = self.HeroStageCard[targetpos - 1].transform.Find("ContectRect").gameObject;
            }
            else if (player == 2)
            {
                itemhero = self.HeroStageCard[cardPos + 4];
                TargetCardContect = self.HeroStageCard[targetpos + 4].transform.Find("ContectRect").gameObject;
            }
            Transform contentRect = itemhero.transform.Find("ContectRect"); ;
            Vector3 target = TargetCardContect.transform.position + new Vector3(0, 0, -20);
            contentRect.DOMove(target, 1f).SetDelay(0.3f).OnComplete(() =>
            {
                contentRect.DOLocalMove(new Vector3(contentRect.localPosition.x, contentRect.localPosition.y, 0), 1f).OnComplete(() =>
                {
                    contentRect.transform.localPosition = Vector3.zero;
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowStageCard(true, player, targetpos, cardId, cardAttack, cardLife);


                });
            });
        }
        //换位置技能
        public static void MovePosCardAnim(this DlgRoom self, int player, int cardPos, int cardId, int targetpos, int cardAttack, int cardLife, bool oldclose = false)
        {
            Gamer gamer = null;
            GameObject itemhero = null;
            GameObject Targetitemhero = null;
            if (player == 1)
            {
                gamer = Game.zoneScene.GetComponent<Room>().GetGamer(0);
                itemhero = self.HeroStageCard[cardPos - 1];
                Targetitemhero = self.HeroStageCard[targetpos - 1];
            }
            else if (player == 2)
            {
                gamer = Game.zoneScene.GetComponent<Room>().GetGamer(1);
                itemhero = self.HeroStageCard[cardPos + 4];
                Targetitemhero = self.HeroStageCard[targetpos + 4];
            }
            Log.Debug("MylibraryUpCardAnim" + cardId + "pos" + targetpos);


            Transform contentRect = itemhero.transform.Find("ContectRect"); ;
            GameObject TargetCardContect = Targetitemhero.transform.Find("ContectRect").gameObject;
            Vector3 target = TargetCardContect.transform.position + new Vector3(0, 0, -20);
            contentRect.DOMove(target, 1f).SetDelay(0.3f).OnComplete(() =>
            {
                contentRect.DOLocalMove(new Vector3(contentRect.localPosition.x, contentRect.localPosition.y, 0), 1f).OnComplete(() =>
                {
                    contentRect.transform.localPosition = Vector3.zero;
                    itemhero.gameObject.SetActive(oldclose);
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowStageCard(true, player, targetpos, cardId, cardAttack, cardLife);


                });
            });
        }


        public static float FramAnim(this DlgRoom self, int player, int pos)
        {
            int index = (player - 1) * 5 + pos - 1;
            GameObject CardContect = self.HeroStageCard[index].transform.Find("ContectRect").gameObject;
            Transform Coin = CardContect.transform.Find("EGImage_Coin");
            Coin.gameObject.SetActive(true);
            Transform Target = null;
            if (player == 1)
                Target = self.View.ELabel_Player1CoinText.transform;
            else
                Target = self.View.ELabel_Player2CoinText.transform;
            Coin.DOLocalRotate(new Vector3(0, 360 * 10, 0), 2f, RotateMode.FastBeyond360).SetEase(Ease.OutCubic);
            Coin.DOLocalMove(new Vector3(0, 100, 0), 2f).OnComplete(() =>
            {
                Coin.DOMove(Target.position, 1f).OnComplete(() => { Coin.gameObject.SetActive(false); });
            });

            return 2;
        }

        //攻击方玩家 位置  目标位置 生命
        public static float AttackAnim(this DlgRoom self, int player, CardResult cardResult, int i, List<CardResult> MyCardResultList, List<CardResult> CardResultList)
        {
            int index = (player - 1) * 5 + cardResult.CardPos - 1;
            int targetplayer = player == 1 ? 2 : 1;
            int targetindex = (targetplayer - 1) * 5 + cardResult.AttackPos[i] - 1;
            Log.Debug("AttackAnim" + player + "pos" + cardResult.CardPos + "targetplayer" + targetplayer + "targetindex" + targetindex + "target" + cardResult.AttackPos[i]);
            GameObject CardContect = self.HeroStageCard[index].transform.Find("ContectRect").gameObject;
            GameObject TargetCardContect = null;
            Text TargetLabel_life = null;
            Text Label_Attack = self.HeroStageCard[index].transform.Find("ContectRect/Label_attack").GetComponent<Text>();
            Label_Attack.SetText("" + MyCardResultList[cardResult.CardPos].TotalAttack);
            DeckComponent MyDeckComponent = null;
            DeckComponent EnemydeckComponent = null;
            if (cardResult.AttackPos[i] == -1 && targetplayer == 1)
            {
                TargetCardContect = self.View.EGTower_Player1RectTransform.gameObject;
            }
            else if (cardResult.AttackPos[i] == -1 && targetplayer == 2)
            {
                TargetCardContect = self.View.EGTower_Player2RectTransform.gameObject;
            }
            else
            {
                TargetCardContect = self.HeroStageCard[targetindex].transform.Find("ContectRect/Label_Name").gameObject;
                TargetLabel_life = self.HeroStageCard[targetindex].transform.Find("ContectRect/Label_life").GetComponent<Text>();

            }
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);
            Gamer gamer2 = self.ZoneScene().GetComponent<Room>().GetGamer(1);
            if (player == 1)
            {
                MyDeckComponent = gamer1.GetComponent<DeckComponent>();
                EnemydeckComponent = gamer2.GetComponent<DeckComponent>();
            }
            else if (player == 2)
            {
                MyDeckComponent = gamer2.GetComponent<DeckComponent>();
                EnemydeckComponent = gamer1.GetComponent<DeckComponent>();
            }


            Vector3 back = CardContect.transform.localPosition + new Vector3(0, player == 1 ? -100 : 100, 0);

            Vector3 local = CardContect.transform.localPosition;

            CardContect.transform.DOLocalMove(back, 0.2f).OnComplete(() =>
            {
                CardContect.transform.DOMove(TargetCardContect.transform.position, 0.2f).SetDelay(0.3f).OnComplete(() =>
                {
                    CardContect.transform.DOLocalMove(local, 0.2f).OnComplete(() =>
                    {
                        //if (target != -1 && life<=0)
                        //{
                        //    TargetCardContect.gameObject.SetActive(false);
                        //}
                        if (TargetLabel_life != null)
                        {
                            Log.Debug(CardResultList[cardResult.AttackPos[i]].CardId + "cardid" + CardResultList[cardResult.AttackPos[i]].TotalLife);
                            EnemydeckComponent.StageDeck[cardResult.AttackPos[i]].TotalLife -= cardResult.AttackDamage[i];
                            TargetLabel_life.SetText("" + EnemydeckComponent.StageDeck[cardResult.AttackPos[i]].TotalLife);
                        }

                    });
                });
            });
            return 1.5f;

        }
        public static async ETTask OnClickSelectHardHandler(this DlgRoom self, int cardid)
        {
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);
            DeckComponent deckComponent = gamer1.GetComponent<DeckComponent>();
            int pos = deckComponent.FindEmptyStageDeck();
            Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowStageCard(true, 1, pos, cardid);
           
            var card = deckComponent.HardDeck.Find(t => t.CardId == cardid);
            if (card != null)
            {
                deckComponent.HardDeck.Remove(card);
            }
            Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowMyCard();

            UseCardProto useCard = new UseCardProto();
            useCard.CardId = cardid;
            useCard.CardPos = pos;
            Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().UseCardList.Add(useCard);


            self.View.EGArrowEffectParentRectTransform.SetVisible(false);


            Debug.Log("self.ScrollPlayer1HardDic.Count" + self.ScrollPlayer1HardDic.Count);
            for (int i = 0; i < self.ScrollPlayer1HardDic.Count; i++)
            {
                Scroll_Item_hardhero ItemHero = self.ScrollPlayer1HardDic[i];
                if(ItemHero.uiTransform!=null)
                    ItemHero.EButton_Select1Button.SetVisible(false);
            }


            


            await ETTask.CompletedTask;
        }

        public static async ETTask OnClickEndHandler(this DlgRoom self)
        {
            self.View.EButton_EndButton.interactable = false;
            try
            {
                int error = await MatchHelper.EndRoundMatch(self.ZoneScene());
                if (error != ErrorCode.ERR_Success)
                {
                    return;
                }
                Log.Debug("回合结束");
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }

            await ETTask.CompletedTask;
        }
        public static async ETTask OnClickGGHandler(this DlgRoom self)
        {
            try
            {
                int error = await MatchHelper.GGMatch(self.ZoneScene());
                if (error != ErrorCode.ERR_Success)
                {
                    return;
                }
                Log.Debug("投降");
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_GameMain);
                self.DomainScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Room);

            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }

            await ETTask.CompletedTask;


        }

        public static void ShowStageCard(this DlgRoom self, bool active, int player = 0, int pos = 0, int cardId = 0, int cardAttack = -1, int cardLife = -1)
        {

            Transform StageCard = null;
            if (player == 1 && pos == 1)
                StageCard = self.View.EGplayer1_stagehero1RectTransform;
            else if (player == 1 && pos == 2)
                StageCard = self.View.EGplayer1_stagehero2RectTransform;
            else if (player == 1 && pos == 3)
                StageCard = self.View.EGplayer1_stagehero3RectTransform;
            else if (player == 1 && pos == 4)
                StageCard = self.View.EGplayer1_stagehero4RectTransform;
            else if (player == 1 && pos == 5)
                StageCard = self.View.EGplayer1_stagehero5RectTransform;
            else if (player == 2 && pos == 1)
                StageCard = self.View.EGplayer2_stagehero1RectTransform;
            else if (player == 2 && pos == 2)
                StageCard = self.View.EGplayer2_stagehero2RectTransform;
            else if (player == 2 && pos == 3)
                StageCard = self.View.EGplayer2_stagehero3RectTransform;
            else if (player == 2 && pos == 4)
                StageCard = self.View.EGplayer2_stagehero4RectTransform;
            else if (player == 2 && pos == 5)
                StageCard = self.View.EGplayer2_stagehero5RectTransform;
            if (StageCard == null)
                return;

            if (active == false)
            {
                StageCard.gameObject.SetActive(false);
                return;
            }
            StageCard.gameObject.SetActive(true);
            var config = UnitConfigCategory.Instance.GetAll()[cardId];
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);
            Gamer gamer2 = self.ZoneScene().GetComponent<Room>().GetGamer(1);
            DeckComponent MydeckComponent = null;
            DeckComponent EnemydeckComponent = null;
            if (player == 1)
            {
                MydeckComponent = gamer1.GetComponent<DeckComponent>();
                EnemydeckComponent = gamer2.GetComponent<DeckComponent>();
            }
            else
            {
                MydeckComponent = gamer2.GetComponent<DeckComponent>();
                EnemydeckComponent = gamer1.GetComponent<DeckComponent>();
            }
            StageCardState stageCardState = new StageCardState();
            stageCardState.CardId = cardId;

            Text Label_Name = StageCard.Find("ContectRect/Label_Name").GetComponent<Text>();
            if (Label_Name != null)
                Label_Name.text = config.Name;
            Text Label_Content = StageCard.Find("ContectRect/Label_Content").GetComponent<Text>();
            if (Label_Content != null)
                Label_Content.text = config.Desc;
            Text Label_attack = StageCard.Find("ContectRect/Label_attack").GetComponent<Text>();
            if (Label_attack != null && cardAttack < 0)
            {
                Label_attack.text = config.attack.ToString();
                stageCardState.TotalAttack = config.attack;
            }
            else if (cardAttack >= 0)
            {
                stageCardState.TotalAttack = cardAttack;
                Label_attack.text = cardAttack.ToString();

            }
            Text Label_pos = StageCard.Find("ContectRect/Label_pos").GetComponent<Text>();
            if (Label_pos != null)
                Label_pos.text = config.Position.ToString();
            Text Label_life = StageCard.Find("ContectRect/Label_life").GetComponent<Text>();
            if (Label_life != null && cardLife < 0)
            {
                Label_life.text = config.life.ToString();
                stageCardState.TotalLife = config.life;
            }
            else if (cardLife >= 0)
            {
                stageCardState.TotalLife = cardLife;
                Label_life.text = cardLife.ToString();
            }
            Text Label_Id = StageCard.Find("ContectRect/Label_Id").GetComponent<Text>();
            if (Label_Id != null)
                Label_Id.text = config.Id.ToString();

            stageCardState.Pos = pos;
            Log.Debug("pos" + pos);
            MydeckComponent.StageDeck[pos] = stageCardState;

            UnityEngine.UI.Button Image_Icon = StageCard.Find("ContectRect/Image_Icon").GetComponent<UnityEngine.UI.Button>();
            Image_Icon.onClick.AddListener(() =>
            {
                GameControlComponent gameControlComponent = self.ZoneScene().GetComponent<Room>().GetComponent<GameControlComponent>();
                long MyId = self.ZoneScene().GetComponent<PlayerComponent>().MyId;
                PlayerRoundResult PlayerRoundResult = null;

                foreach (var item in gameControlComponent.PlayerRoundResultList)
                {
                    if (item.UnitId == MyId && player == 1)
                    {
                        PlayerRoundResult = item;
                    }
                    else if (item.UnitId != MyId && player == 2)
                    {
                        PlayerRoundResult = item;
                    }
                }
                self.ShowBuffList(player, pos, PlayerRoundResult.CardResultList[pos].BuffList.Count);
            });


            Transform StatePanel = StageCard.Find("ContectRect/StatePanel");
            UnityEngine.UI.Button Button_Select = StageCard.Find("ContectRect/Button_Select").GetComponent<UnityEngine.UI.Button>();
            Button_Select.onClick.AddListener(() =>
            {
                if (StatePanel.gameObject.activeSelf == false)
                    StatePanel.gameObject.SetActive(true);
                else if (StatePanel.gameObject.activeSelf == true)
                    StatePanel.gameObject.SetActive(false);
            });
            UnityEngine.UI.Button Button_SelectCard = StageCard.Find("ContectRect/Button_SelectCard").GetComponent<UnityEngine.UI.Button>();
            Button_SelectCard.onClick.AddListener(() =>
            {
                self.View.EGArrowEffectParentRectTransform.SetVisible(false);
                self.SelectCardId = cardId;
                int SelectCardid = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().SelectHardCard;
                //StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                UseCardProto proto = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().UseCardList.Find(t => t.CardId == SelectCardid);
                proto.SelectCardId = cardId;
                proto.SelectCardPos = pos;
                proto.SelectCardPlayer = player;
                Button_SelectCard.SetVisible(false);

            });





            UnityEngine.UI.Button Button_Skill = StageCard.Find("ContectRect/StatePanel/Button_Skill").GetComponent<UnityEngine.UI.Button>();
            Text Text_Skill = Button_Skill.gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
            UnityEngine.UI.Button Button_Skill1 = StageCard.Find("ContectRect/StatePanel/Button_Skill1").GetComponent<UnityEngine.UI.Button>();
            Text Text_Skill1 = Button_Skill1.gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
            UnityEngine.UI.Button Button_Skill2 = StageCard.Find("ContectRect/StatePanel/Button_Skill2").GetComponent<UnityEngine.UI.Button>();
            Text Text_Skill2 = Button_Skill2.gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>();
            UnityEngine.UI.Button Button_Skilling = StageCard.Find("ContectRect/StatePanel/Button_Skilling").GetComponent<UnityEngine.UI.Button>();
            UnityEngine.UI.Button Button_Fram = StageCard.Find("ContectRect/StatePanel/Button_Fram").GetComponent<UnityEngine.UI.Button>();
            UnityEngine.UI.Button Button_Framing = StageCard.Find("ContectRect/StatePanel/Button_Framing").GetComponent<UnityEngine.UI.Button>();
            string SkillType = config.type;
            //int bit = Convert.ToInt32(SkillType, 2);
            //BitArray bits = new BitArray(new int[] { bit });

            int bit = Convert.ToInt32(SkillType, 2);
            int bit0 = (bit >> 4) & 1;

            if (bit0 == 1)
            {
                Button_Skill.onClick.AddListener(() =>
                {
                    int limit = MydeckComponent.StageDeck[pos].limit;
                    if (cardId == 1057)
                    {
                        if (limit == 1)
                        {
                            return;
                        }
                        else
                        {
                            MydeckComponent.StageDeck[pos].limit = 1;
                        }
                    }
                    
                    StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                    if (useCard == null)
                    {
                        useCard = new StageCardProto();
                        useCard.CardId = cardId;
                        useCard.CardPos = pos;
                        useCard.Fram = 0;
                        useCard.UseSkill = 1;
                        Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Add(useCard);
                    }
                    else
                    {
                        useCard.Fram = 0;
                        useCard.UseSkill = 1;
                    }
                    Button_Skill.SetVisible(false);
                    Button_Skill1.SetVisible(false);
                    Button_Skill2.SetVisible(false);
                    Button_Skilling.SetVisible(true);

                    Button_Fram.SetVisible(true);
                    Button_Framing.SetVisible(false);
                    Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().SelectSkillCard = cardId;

                    if (cardId == 1037 || cardId == 1045 || cardId == 1060)
                    {
                        Transform HeroTemp = self.HeroStageCard[pos - 1].transform.parent;
                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.View.EGArrowEffectParentRectTransform.SetVisible(true);
                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.arrowEffectManager.SetStartPos(HeroTemp.position);
                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.arrowEffectManager.ClearCollisionObject();

                        for (int i = 1; i < 6; i++)
                        {

                            if ((MydeckComponent.StageDeck[i].CardId == 0 && cardId == 1037) ||
                            (MydeckComponent.StageDeck[i].CardId != 0 && cardId == 1045 && pos != i) ||
                            (MydeckComponent.StageDeck[i].CardId == 0 && cardId == 1060))
                            {
                                if (i == 1)
                                {
                                    self.arrowEffectManager.SetCollisionObject(self.View.EGhero1BGRectTransform, self.View.EButton_SelectPos1Button.gameObject);
                                }
                                else if (i == 2)
                                {
                                    self.arrowEffectManager.SetCollisionObject(self.View.EGhero2BGRectTransform, self.View.EButton_SelectPos2Button.gameObject);
                                }
                                else if (i == 3)
                                {
                                    self.arrowEffectManager.SetCollisionObject(self.View.EGhero3BGRectTransform, self.View.EButton_SelectPos3Button.gameObject);
                                }
                                else if (i == 4)
                                {
                                    self.arrowEffectManager.SetCollisionObject(self.View.EGhero4BGRectTransform, self.View.EButton_SelectPos4Button.gameObject);
                                }
                                else if (i == 5)
                                {
                                    self.arrowEffectManager.SetCollisionObject(self.View.EGhero5BGRectTransform, self.View.EButton_SelectPos5Button.gameObject);
                                }

                            }


                        }

                    }

                });
                Button_Skill1.onClick.AddListener(() => {
                    StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                    if (useCard == null)
                    {
                        useCard = new StageCardProto();
                        useCard.CardId = cardId;
                        useCard.CardPos = pos;
                        useCard.Fram = 0;
                        useCard.UseSkill = 2;
                        Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Add(useCard);
                    }
                    else
                    {
                        useCard.Fram = 0;
                        useCard.UseSkill = 2;
                    }
                    Button_Skill.SetVisible(false);
                    Button_Skill1.SetVisible(false);
                    Button_Skill2.SetVisible(false);
                    Button_Skilling.SetVisible(true);
                    Button_Fram.SetVisible(true);
                    Button_Framing.SetVisible(false);

                });
                Button_Skill2.onClick.AddListener(() => {
                    StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                    if (useCard == null)
                    {
                        useCard = new StageCardProto();
                        useCard.CardId = cardId;
                        useCard.CardPos = pos;
                        useCard.Fram = 0;
                        useCard.UseSkill = 3;
                        Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Add(useCard);
                    }
                    else
                    {
                        useCard.Fram = 0;
                        useCard.UseSkill = 3;
                    }
                    Button_Skill.SetVisible(false);
                    Button_Skill1.SetVisible(false);
                    Button_Skill2.SetVisible(false);
                    Button_Skilling.SetVisible(true);
                    Button_Fram.SetVisible(true);
                    Button_Framing.SetVisible(false);

                });
                Button_Skilling.onClick.AddListener(() =>
                {

                    StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                    useCard.UseSkill = 0;
                    int UseSkillCd = MydeckComponent.StageDeck[pos].UseSkillCd;
                    int bit1 = UseSkillCd >> 1 & 1;
                    int bit2 = UseSkillCd >> 2 & 1;
                    int bit3 = UseSkillCd >> 3 & 1;
                    Button_Skill.SetVisible(bit1 == 0 ? false : true);
                    Button_Skill1.SetVisible(bit2 == 0 ? false : true);
                    Button_Skill2.SetVisible(bit3 == 0 ? false : true);
                    Button_Skilling.SetVisible(false);

                });
                if (cardId == 1060)//QO
                {
                    Text_Skill.text = "跳刀";
                    Text_Skill1.text = "折光";
                    Text_Skill2.text = "隐匿";
                    Button_Skill1.SetVisible(true);
                    Button_Skill2.SetVisible(true);

                }
                else if (cardId == 1070)//yyf
                {

                }
                else
                {
                    Button_Skill1.SetVisible(true);
                    Button_Skill2.SetVisible(true);
                }


            }
            else
            {
                Button_Skill.interactable = false;
            }


            Button_Fram.onClick.AddListener(() =>
            {
                StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                if (useCard == null)
                {
                    useCard = new StageCardProto();
                    useCard.CardId = cardId;
                    useCard.CardPos = pos;
                    useCard.Fram = 1;
                    useCard.UseSkill = 0;
                    Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Add(useCard);
                }
                else
                {
                    useCard.Fram = 1;
                    useCard.UseSkill = 0;
                }
                Button_Fram.SetVisible(false);
                Button_Framing.SetVisible(true);
                Button_Skill.SetVisible(true);
                Button_Skilling.SetVisible(false);
            });
            Button_Framing.onClick.AddListener(() =>
            {

                StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                useCard.Fram = 0;
                Button_Fram.SetVisible(true);
                Button_Framing.SetVisible(false);
            });

            UnityEngine.UI.Button Button_UpStar = StageCard.Find("ContectRect/StatePanel/Button_UpStar").GetComponent<UnityEngine.UI.Button>();
            UnityEngine.UI.Button Button_UpStaring = StageCard.Find("ContectRect/StatePanel/Button_UpStaring").GetComponent<UnityEngine.UI.Button>();

            Button_UpStar.onClick.AddListener(() =>
            {
                StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);
                if (useCard == null)
                {
                    useCard = new StageCardProto();
                    useCard.CardId = cardId;
                    useCard.CardPos = pos;
                    useCard.UpStar = 1;
                    Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Add(useCard);
                }
                else
                {
                    useCard.UpStar = 1;
                }

                Button_UpStar.SetVisible(false);
                Button_UpStaring.SetVisible(true);
            });
            Button_UpStaring.onClick.AddListener(() =>
            {
                StageCardProto useCard = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().StageCardList.Find(t => t.CardId == cardId);

                useCard.UpStar = 0;
                Button_UpStar.SetVisible(true);
                Button_UpStaring.SetVisible(false);
            });




        }


        public static void ShowBuffList(this DlgRoom self, int player, int index, int count)
        {
            Debug.Log("ShowBuffList1");
            if (index == 1 && player == 1)
            {
                if (self.View.ELoopScrollList_BuffList1LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList1, count);
                    self.View.ELoopScrollList_BuffList1LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList1LoopVerticalScrollRect.SetVisible(false);
                }

                //self.View.ELoopScrollList_BuffList1LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 2 && player == 1)
            {
                if (self.View.ELoopScrollList_BuffList2LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList2, count);
                    self.View.ELoopScrollList_BuffList2LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList2LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList2LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 3 && player == 1)
            {
                if (self.View.ELoopScrollList_BuffList3LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList3, count);
                    self.View.ELoopScrollList_BuffList3LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList3LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList3LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 4 && player == 1)
            {
                if (self.View.ELoopScrollList_BuffList4LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList4, count);
                    self.View.ELoopScrollList_BuffList4LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList4LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList4LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 5 && player == 1)
            {
                if (self.View.ELoopScrollList_BuffList5LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList5, count);
                    self.View.ELoopScrollList_BuffList5LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList5LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList5LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 1 && player == 2)
            {
                if (self.View.ELoopScrollList_BuffList6LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList6, count);
                    self.View.ELoopScrollList_BuffList6LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList6LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList6LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 2 && player == 2)
            {
                if (self.View.ELoopScrollList_BuffList7LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList7, count);
                    self.View.ELoopScrollList_BuffList7LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList7LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList7LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 3 && player == 2)
            {
                if (self.View.ELoopScrollList_BuffList8LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList8, count);
                    self.View.ELoopScrollList_BuffList8LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList8LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList8LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 4 && player == 2)
            {
                if (self.View.ELoopScrollList_BuffList9LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList9, count);
                    self.View.ELoopScrollList_BuffList9LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList9LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList9LoopVerticalScrollRect.gameObject.SetActive(false);
            }
            if (index == 5 && player == 2)
            {
                if (self.View.ELoopScrollList_BuffList10LoopVerticalScrollRect.IsActive() == false)
                {
                    self.AddUIScrollItems(ref self.ScrollCardBuffDicList10, count);
                    self.View.ELoopScrollList_BuffList10LoopVerticalScrollRect.SetVisible(true, count);
                }
                else
                {
                    self.View.ELoopScrollList_BuffList10LoopVerticalScrollRect.SetVisible(false);
                }
                //self.View.ELoopScrollList_BuffList10LoopVerticalScrollRect.gameObject.SetActive(false);
            }



            Debug.Log("ShowBuffList2");

        }

        public static void ShowMyCard(this DlgRoom self, Entity contextData = null)
        {
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);
            int count1 = gamer1.GetComponent<DeckComponent>().HardDeck.Count;
            
            self.AddUIScrollItems(ref self.ScrollPlayer1HardDic, count1);
            self.View.ELoopScrollList_player1LoopHorizontalScrollRect.SetVisible(true, count1);
            Log.Debug(count1 + "countcount" + self.ScrollPlayer1HardDic.Count);
        }
        public static void ShowEnemyCard(this DlgRoom self, Entity contextData = null)
        {
            Gamer gamer2 = self.ZoneScene().GetComponent<Room>().GetGamer(1);
            int count2 = gamer2.GetComponent<DeckComponent>().HardDeck.Count;
            Log.Debug(UnitConfigCategory.Instance.GetAll().Count + "countcount");
            self.AddUIScrollItems(ref self.ScrollPlayer2HardDic, count2);
            self.View.ELoopScrollList_player2LoopHorizontalScrollRect.SetVisible(true, count2);
        }
        public static void ShowWindow(this DlgRoom self, Entity contextData = null)
        {
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);

            Gamer gamer2 = self.ZoneScene().GetComponent<Room>().GetGamer(1);

            self.View.ELabel_Player1NameText.SetText(gamer1.Name);
            self.View.ELabel_Player1MMRText.SetText(gamer1.MMR + "");
            self.View.ELabel_Player1CoinText.SetText(gamer1.GetComponent<DeckComponent>().Coin + "");
            self.View.ELabel_Player1TowerHpText.SetText(gamer1.GetComponent<DeckComponent>().TowerHP + "");

            self.View.ELabel_Player2NameText.SetText(gamer2.Name);
            self.View.ELabel_Player2MMRText.SetText(gamer2.MMR + "");
            self.View.ELabel_Player2CoinText.SetText(gamer2.GetComponent<DeckComponent>().Coin + "");
            self.View.ELabel_Player2TowerHpText.SetText(gamer2.GetComponent<DeckComponent>().TowerHP + "");

            int count1 = gamer1.GetComponent<DeckComponent>().HardDeck.Count;
            Log.Debug(UnitConfigCategory.Instance.GetAll().Count + "countcount");
            self.AddUIScrollItems(ref self.ScrollPlayer1HardDic, count1);
            self.View.ELoopScrollList_player1LoopHorizontalScrollRect.SetVisible(true, count1);

            int count2 = gamer2.GetComponent<DeckComponent>().HardDeck.Count;
            Log.Debug(UnitConfigCategory.Instance.GetAll().Count + "countcount");
            self.AddUIScrollItems(ref self.ScrollPlayer2HardDic, count2);
            self.View.ELoopScrollList_player2LoopHorizontalScrollRect.SetVisible(true, count2);



            self.View.EButton_EndButton.interactable = true;
            self.View.EButton_GGButton.interactable = true;


        }
        public static void OnSrcollScrollBuffListHandler(this DlgRoom self, Transform transform, int index, int i)
        {
            Scroll_Item_buff ItemHero = null;
            if (i == 1)
                ItemHero = self.ScrollCardBuffDicList1[index].BindTrans(transform);
            if (i == 2)
                ItemHero = self.ScrollCardBuffDicList2[index].BindTrans(transform);
            if (i == 3)
                ItemHero = self.ScrollCardBuffDicList3[index].BindTrans(transform);
            if (i == 4)
                ItemHero = self.ScrollCardBuffDicList4[index].BindTrans(transform);
            if (i == 5)
                ItemHero = self.ScrollCardBuffDicList5[index].BindTrans(transform);
            if (i == 6)
                ItemHero = self.ScrollCardBuffDicList6[index].BindTrans(transform);
            if (i == 7)
                ItemHero = self.ScrollCardBuffDicList7[index].BindTrans(transform);
            if (i == 8)
                ItemHero = self.ScrollCardBuffDicList8[index].BindTrans(transform);
            if (i == 9)
                ItemHero = self.ScrollCardBuffDicList9[index].BindTrans(transform);
            if (i == 10)
                ItemHero = self.ScrollCardBuffDicList10[index].BindTrans(transform);



            GameControlComponent gameControlComponent = self.ZoneScene().GetComponent<Room>().GetComponent<GameControlComponent>();
            long MyId = self.ZoneScene().GetComponent<PlayerComponent>().MyId;
            PlayerRoundResult MyPlayerRoundResult = null;
            PlayerRoundResult EnemyPlayerRoundResult = null;
            foreach (var item in gameControlComponent.PlayerRoundResultList)
            {
                if (item.UnitId == MyId)
                {
                    MyPlayerRoundResult = item;
                }
                else
                {
                    EnemyPlayerRoundResult = item;
                }
            }

            if (i < 6)
            {
                int cardid = MyPlayerRoundResult.CardResultList[i].BuffList[index].BuffCardId;
                int cardStar = MyPlayerRoundResult.CardResultList[i].BuffList[index].BuffCardStar;
                int BuffNum = MyPlayerRoundResult.CardResultList[i].BuffList[index].BuffNum;
                var config = UnitConfigCategory.Instance.GetAll()[cardid];
                ItemHero.ELabel_NameText.SetText(config.Desc + "--" + cardStar + "X" + config.Name);
            }
            else
            {
                int cardid = EnemyPlayerRoundResult.CardResultList[i - 5].BuffList[index].BuffCardId;
                int cardStar = EnemyPlayerRoundResult.CardResultList[i - 5].BuffList[index].BuffCardStar;
                int BuffNum = EnemyPlayerRoundResult.CardResultList[i - 5].BuffList[index].BuffNum;
                var config = UnitConfigCategory.Instance.GetAll()[cardid];
                ItemHero.ELabel_NameText.SetText(config.Desc + "--" + cardStar + "X" + config.Name);
            }



        }
        public static void OnSrcollPlayer1RefreshHandler(this DlgRoom self, Transform transform, int index)
        {

            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);


            Scroll_Item_hardhero ItemHero = self.ScrollPlayer1HardDic[index].BindTrans(transform);
            int cardid = gamer1.GetComponent<DeckComponent>().HardDeck[index].CardId;
            Log.Debug(gamer1 + "" + cardid);
            var config = UnitConfigCategory.Instance.GetAll()[cardid];

            ItemHero.ELabel_NameText.text = config.Name;
            ItemHero.ELabel_Name1Text.text = config.Name;
            ItemHero.ELabel_IdText.text = cardid.ToString();



            ItemHero.EButton_SelectButton.gameObject.GetComponent<EventTrigger>().triggers.Clear();

            EventTrigger.Entry entry = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((BaseEventData eventData) =>
            {
                OnPointerEnter(ItemHero.ELabel_NameText.gameObject, eventData);
            });
            ItemHero.EButton_SelectButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry);

            EventTrigger.Entry entry1 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry1.eventID = EventTriggerType.PointerExit;
            entry1.callback.AddListener((BaseEventData eventData) =>
            {
                OnPointerExit(ItemHero.ELabel_NameText.gameObject, eventData);
            });
            ItemHero.EButton_SelectButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry1);

            EventTrigger.Entry entry2 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry2.eventID = EventTriggerType.BeginDrag;
            entry2.callback.AddListener((BaseEventData eventData) =>
            {
                OnBeginDrag(ItemHero.ELabel_NameText.gameObject, eventData);
            });
            ItemHero.EButton_SelectButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry2);

            EventTrigger.Entry entry3 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry3.eventID = EventTriggerType.Drag;
            entry3.callback.AddListener((BaseEventData eventData) =>
            {
                OnDrag(ItemHero.ELabel_NameText.gameObject, eventData);
            });
            ItemHero.EButton_SelectButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry3);

            EventTrigger.Entry entry4 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry4.eventID = EventTriggerType.EndDrag;
            entry4.callback.AddListener((BaseEventData eventData) =>
            {
                OnEndDrag(ItemHero.ELabel_NameText.gameObject, eventData);
            });
            ItemHero.EButton_SelectButton.gameObject.GetComponent<EventTrigger>().triggers.Add(entry4);

            ItemHero.EButton_Select1Button.AddListenerAsyncWithId(self.OnClickSelectHardHandler, cardid);

        }

        public static void OnBeginDrag(GameObject go, BaseEventData eventData)
        {
            int cardid = go.transform.parent.Find("ELabel_Id").GetComponent<Text>().text.ToInt32();
            Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().SelectHardCard = cardid;
        }

        public static void OnDrag(GameObject go, BaseEventData eventData)
        {
            if (go.GetComponent<RectTransform>())
            {
                Vector3 v3;
                PointerEventData data = eventData as PointerEventData;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(go.GetComponent<RectTransform>(),
                    data.position, data.enterEventCamera, out v3);

                //RectTransform ERect_Icon = go.transform.parent.Find("ERect_Icon").GetComponent<RectTransform>();
                Debug.Log("OnDragMyCard:" + v3);
                go.transform.parent.position = v3;
                // Debug.Log("OnDrag:" + ERect_Icon.localPosition);
            }
            else
            {
                if (SetCameraRayPoint(out Vector3 pos, go))
                {
                    go.transform.parent.GetComponent<RectTransform>().position = pos;
                }
            }
        }

        public static void OnEndDrag(GameObject go, BaseEventData eventData)
        {

            Vector3 v3;
            PointerEventData data = eventData as PointerEventData;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(go.GetComponent<RectTransform>(),
                data.position, data.enterEventCamera, out v3);
            Transform Hero = go.transform.parent.parent.parent.parent.parent.parent.Find("Hero");

            for (int i = 0; i < 5; i++)
            {
                RectTransform HeroTemp = Hero.Find("hero" + (i + 1)).GetComponent<RectTransform>();
                Vector3 mouseLocal = HeroTemp.parent.InverseTransformPoint(go.transform.parent.position);
                if ((Math.Abs(mouseLocal.x - HeroTemp.transform.localPosition.x) < HeroTemp.sizeDelta.x / 2) &&
                    (Math.Abs(mouseLocal.y - HeroTemp.transform.localPosition.y) < HeroTemp.sizeDelta.y / 2))
                {
                    go.transform.parent.localPosition = Vector3.zero;
                    int cardid = Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().SelectHardCard;
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowStageCard(true, 1, i + 1, cardid);
                    Log.Debug("在里面");
                    Gamer gamer1 = Game.zoneScene.GetComponent<Room>().GetGamer(0);

                    //var item = gamer1.GetComponent<DeckComponent>().HardDeck.Find(x => x.CardId == cardid);
                    DeckComponent deckComponent = gamer1.GetComponent<DeckComponent>();
                   
                    var card = deckComponent.HardDeck.Find(t => t.CardId == cardid);
                    if (card != null)
                    {
                        deckComponent.HardDeck.Remove(card);
                    }
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.ShowMyCard();


                    var config = UnitConfigCategory.Instance.GetAll()[cardid];
                    string SkillType = config.type;
                    int bit = Convert.ToInt32(SkillType, 2);
                    int bit0 = (bit >> 5) & 1;
                    int bit1 = (bit >> 6) & 1;
                    int bit2 = (bit >> 7) & 1;
                    Log.Debug("cardid:" + cardid + "bit0:" + bit0 + "bit1:" + bit1);
                    if (bit0 == 1 || bit1 == 1 || bit2 == 1)
                    {

                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.View.EGArrowEffectParentRectTransform.SetVisible(true);
                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.arrowEffectManager.SetStartPos(HeroTemp.position);
                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.arrowEffectManager.ClearCollisionObject();
                        //除自己外队友
                        if (bit0 == 1)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (j != i)
                                {
                                    GameObject btn = Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.HeroStageCard[j].transform.Find("ContectRect/Button_SelectCard").gameObject;
                                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.arrowEffectManager.SetCollisionObject(
                                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.HeroStageCard[j].GetComponent<RectTransform>(), btn);
                                }
                            }
                            if (deckComponent.StageDeck.Count == 1)
                            {
                                Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.View.EGArrowEffectParentRectTransform.SetVisible(false);
                            }

                        }
                        //敌方
                        else if (bit1 == 1)
                        {
                            for (int j = 5; j < 10; j++)
                            {
                                GameObject btn = Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.HeroStageCard[j].transform.Find("ContectRect/Button_SelectCard").gameObject;
                                Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.arrowEffectManager.SetCollisionObject(
                                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.HeroStageCard[j].GetComponent<RectTransform>(), btn);
                            }
                            Gamer gamer2 = Game.zoneScene.GetComponent<Room>().GetGamer(1);
                            DeckComponent deckComponent2 = gamer1.GetComponent<DeckComponent>();
                            if (deckComponent2.StageDeck.Count == 0)
                            {
                                Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.View.EGArrowEffectParentRectTransform.SetVisible(false);
                            }
                        }
                        else if (bit2 == 1)
                        {
                            int count = Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>().ScrollPlayer1HardDic.Count;
                            for (int j = 0; j < count; j++)
                            {

                                Scroll_Item_hardhero ItemHero = Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>().ScrollPlayer1HardDic[j];
                                if (ItemHero.uiTransform != null)
                                {
                                    RectTransform rectTransform = ItemHero.uiTransform.Find("ContectRect").GetComponent<RectTransform>();
                                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.arrowEffectManager.SetCollisionObject(
                                        rectTransform, ItemHero.EButton_Select1Button.gameObject);
                                }
                               
                            }
                            if (count == 0)
                            {
                                Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.View.EGArrowEffectParentRectTransform.SetVisible(false);
                            }



                        }


                    }
                    


                    UseCardProto useCard = new UseCardProto();
                    useCard.CardId = cardid;
                    useCard.CardPos = i + 1;
                    Debug.Log(useCard.CardId + "UseCardListadd" + useCard.CardPos);
                    Game.zoneScene.GetComponent<Room>().GetComponent<GameControlComponent>().UseCardList.Add(useCard);

                    if (cardid == 1062)
                    {
                        Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoom>()?.UpZfreek();
                    }

                    return;

                }
                else
                {

                    Log.Debug("在外面");
                }
            }
            go.transform.parent.localPosition = Vector3.zero;





        }
        public static void UpZfreek(this DlgRoom self)
        {
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);
            DeckComponent deckComponent = gamer1.GetComponent<DeckComponent>();
            int count = gamer1.GetComponent<DeckComponent>().HardDeck.Count;
          
            var card1062 = self.ZoneScene().GetComponent<Room>().GetComponent<GameControlComponent>().UseCardList.Find(t => t.CardId == 1062);
            card1062.SelectSkill = count;
            
            for (int i = 0; i < count; i++)
            {
                SkillCard item = new SkillCard();
                item.CardId = deckComponent.HardDeck[i].CardId;
                item.CardStar = deckComponent.HardDeck[i].Star;
                card1062.CardList.Add(item);
            }
            deckComponent.HardDeck.Clear();
            //动画
            for (int i = 0; i < self.ScrollPlayer1HardDic.Count; i++)
            {
                Scroll_Item_hardhero ItemHero = self.ScrollPlayer1HardDic[i];
            }

            int count1 = deckComponent.HardDeck.Count;
            self.AddUIScrollItems(ref self.ScrollPlayer1HardDic, count1);
            self.View.ELoopScrollList_player1LoopHorizontalScrollRect.SetVisible(true, count1);
        }

        public static void OnPointerEnter(GameObject go, BaseEventData eventData)
        {
            go.transform.parent.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        public static void OnPointerExit(GameObject go, BaseEventData eventData)
        {
            go.transform.parent.localScale = new Vector3(1, 1, 1);
        }

        public static bool SetCameraRayPoint(out Vector3 pos, GameObject go)
        {
            pos = Vector3.zero;

            if (Camera.main == null)
                return false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            float dist = 1000;

            if (Physics.Raycast(ray, out hit, dist))
            {
                if (go == hit.transform.gameObject)
                    return false;

                pos = hit.point;
                return true;
            }

            return false;
        }


        public static void OnSrcollPlayer2RefreshHandler(this DlgRoom self, Transform transform, int index)
        {

            Scroll_Item_backhero ItemHero = self.ScrollPlayer2HardDic[index].BindTrans(transform);
        }


    }
}
