using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ILRuntime.Runtime;

namespace ET
{
    [FriendClass(typeof(DlgRoom))]
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    [FriendClassAttribute(typeof(ET.GameControlComponent))]
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
        }

        public static async ETTask OnClickEndHandler(this DlgRoom self)
        {
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
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Room);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_GameMain);
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }

            await ETTask.CompletedTask;


        }

        public static void ShowWindow(this DlgRoom self, Entity contextData = null)
        {
            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);

            Gamer gamer2 = self.ZoneScene().GetComponent<Room>().GetGamer(1);

            self.View.ELabel_Player1NameText.SetText(gamer1.Name);
            self.View.ELabel_Player1MMRText.SetText(gamer1.MMR + "");

            self.View.ELabel_Player2NameText.SetText(gamer2.Name);
            self.View.ELabel_Player2MMRText.SetText(gamer2.MMR + "");

            int count1 = gamer1.GetComponent<DeckComponent>().HardDeck.Count;
            Log.Debug(UnitConfigCategory.Instance.GetAll().Count + "countcount");
            self.AddUIScrollItems(ref self.ScrollPlayer1HardDic, count1);
            self.View.ELoopScrollList_player1LoopHorizontalScrollRect.SetVisible(true, count1);

            int count2 = 5;
            Log.Debug(UnitConfigCategory.Instance.GetAll().Count + "countcount");
            self.AddUIScrollItems(ref self.ScrollPlayer2HardDic, count2);
            self.View.ELoopScrollList_player2LoopHorizontalScrollRect.SetVisible(true, count2);



            self.View.EButton_EndButton.interactable = true;
            self.View.EButton_GGButton.interactable = true;

        }

        public static void OnSrcollPlayer1RefreshHandler(this DlgRoom self, Transform transform, int index)
        {

            Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);


            Scroll_Item_hardhero ItemHero = self.ScrollPlayer1HardDic[index].BindTrans(transform);
            int cardid = gamer1.GetComponent<DeckComponent>().HardDeck[index];
            Log.Debug(gamer1 + "" + cardid);
            var config = UnitConfigCategory.Instance.GetAll()[cardid];

            ItemHero.ELabel_NameText.text = config.Name;
            ItemHero.ELabel_Name1Text.text = config.Name;
            ItemHero.ELabel_IdText.text = cardid.ToString();
            




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
            go.transform.parent.localPosition = Vector3.zero;
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


        }


    }
}
