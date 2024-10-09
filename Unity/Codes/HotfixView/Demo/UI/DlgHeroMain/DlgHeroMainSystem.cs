using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using CommandLine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Diagnostics.Tracing;
using ILRuntime.Runtime;



namespace ET
{
    [FriendClass(typeof(DlgHeroMain))]
    [FriendClassAttribute(typeof(ET.HeroInfoComponent))]

    public static class DlgHeroMainSystem
    {

        public static void RegisterUIEvent(this DlgHeroMain self)
        {
            self.View.ELoopScrollList_HeroLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollItemRefreshHandler(transform, index);
            });

            self.View.ELoopScrollList_MyCardLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnSrcollItemMyCardHandler(transform, index);
            });
            self.View.EButton_SaveCardButton.AddListenAsync(() => { return self.OnClickSaveHandler(); });
            self.View.EButton_ClearButton.AddListenAsync(() => { return self.OnClickClearHandler(); });

            self.View.EButton_BackButton.AddListenAsync(() => { return self.OnClickBackHandler(); });


        }

        public static void ShowWindow(this DlgHeroMain self, Entity contextData = null)
        {
            int count = UnitConfigCategory.Instance.GetAll().Count;
            Log.Debug(UnitConfigCategory.Instance.GetAll().Count+"countcount");
            self.AddUIScrollItems(ref self.ScrollItemHeroDic, count);
            self.View.ELoopScrollList_HeroLoopVerticalScrollRect.SetVisible(true, count);
            self.ShowMyCard();
        }

        public static void ShowMyCard(this DlgHeroMain self, Entity contextData = null)
        {
            int count = self.ZoneScene().GetComponent<HeroInfoComponent>().MyCardNum.Count;
            for (int i = 0; i < count; i++)
            {
                Log.Debug(self.ZoneScene().GetComponent<HeroInfoComponent>().MyCardNum[i] + "i" + i);
            }
            self.AddUIScrollItems(ref self.ScrollItemMyCardDic, count);
            self.View.ELoopScrollList_MyCardLoopVerticalScrollRect.SetVisible(true, count);
            self.View.ELabel_CardsNumText.SetText("CardNum:" + count);
            if (count == 30)
            {
                self.View.EButton_SaveCardButton.interactable = true;
            }
            else
            {
                self.View.EButton_SaveCardButton.interactable = false;
            }

        }

        public static void OnSrcollItemMyCardHandler(this DlgHeroMain self, Transform transform, int index)
        {
            Scroll_Item_HeroSmall ItemHero = self.ScrollItemMyCardDic[index].BindTrans(transform);
            int cardid = self.ZoneScene().GetComponent<HeroInfoComponent>().MyCardNum[index];

            ItemHero.ELabel_NameText.gameObject.GetComponent<EventTrigger>().triggers.Clear();
            if (UnitConfigCategory.Instance.GetAll().ContainsKey(cardid))
            {
                var config = UnitConfigCategory.Instance.GetAll()[cardid];
                ItemHero.ELabel_NameText.text = config.Name;
                ItemHero.ELabel_Name1Text.text = config.Name;
                ItemHero.ELabel_IdText.text = cardid.ToString();
            }
            EventTrigger.Entry entry = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
                entry.eventID = EventTriggerType.BeginDrag;
                entry.callback.AddListener((BaseEventData eventData) => {
                    OnBeginDragMyCard(ItemHero.ELabel_NameText.gameObject, eventData);
                });
                ItemHero.ELabel_NameText.gameObject.GetComponent<EventTrigger>().triggers.Add(entry);

                EventTrigger.Entry entry1 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
                entry1.eventID = EventTriggerType.Drag;
                entry1.callback.AddListener((BaseEventData eventData) => {
                    OnDragMyCard(ItemHero.ELabel_NameText.gameObject, eventData);
                });
                ItemHero.ELabel_NameText.GetComponent<EventTrigger>().triggers.Add(entry1);

                EventTrigger.Entry entry2 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
                entry2.eventID = EventTriggerType.EndDrag;
                entry2.callback.AddListener((BaseEventData eventData) => {
                    OnEndDragMyCard(ItemHero.ELabel_NameText.gameObject, eventData);
                });
                ItemHero.ELabel_NameText.GetComponent<EventTrigger>().triggers.Add(entry2);

           
                


            //EventListener.Get(ItemHero.ELabel_NameText.gameObject).onBeginDrag = OnBeginDragMyCard;
            //EventListener.Get(ItemHero.ELabel_NameText.gameObject).onDrag = OnDragMyCard;
            //EventListener.Get(ItemHero.ELabel_NameText.gameObject).onEndDrag = OnEndDragMyCard;

            //ItemHero.ELabel_NameText.gameObject.AddComponent<EventTrigger>().AddListener(EventTriggerType.BeginDrag,OnBeginDragMyCard)
            //ItemHero.ELabel_NameText.gameObject.AddComponent<EventTrigger>().AddListener(EventTriggerType.BeginDrag, (BaseEventData eventData) => {

            //    OnBeginDragMyCard(ItemHero.ELabel_NameText.gameObject, eventData);
            //});

            //ItemHero.ELabel_NameText.gameObject.AddComponent<EventTrigger>().AddListener(EventTriggerType.Drag, (BaseEventData eventData) => {

            //    OnDragMyCard(ItemHero.ELabel_NameText.gameObject, eventData);
            //});


            //ItemHero.ELabel_NameText.gameObject.AddComponent<EventTrigger>().AddListener(EventTriggerType.EndDrag, (BaseEventData eventData) => {

            //    OnEndDragMyCard(ItemHero.ELabel_NameText.gameObject, eventData);
            //});

        }
        public static void OnSrcollItemRefreshHandler(this DlgHeroMain self, Transform transform, int index)
        {
            Scroll_Item_hero ItemHero = self.ScrollItemHeroDic[index].BindTrans(transform);
            Log.Debug("OnSrcollItemRefreshHandler" + index + ItemHero);
            //ServerInfo info = self.ZoneScene().GetComponent<ServerInfoComponent>().ServerInfoList[index];
            //serverTest.EI_serverTestImage.color = info.Id == self.ZoneScene().GetComponent<ServerInfoComponent>().CurrentServerId ? Color.red : Color.cyan;
            //serverTest.E_serverTestTipText.SetText(info.ServerName);
            //serverTest.EButton_SelectButton.AddListener(() => self.OnSelectServerItemHandler(info.Id));

            if (UnitConfigCategory.Instance.GetAll().ContainsKey(index + 1001))
            {
                var config = UnitConfigCategory.Instance.GetAll()[index + 1001];
               
                ItemHero.ELabel_ContentText.SetText(config.Desc);
                ItemHero.ELabel_NameText.SetText(config.Name);
                ItemHero.ELabel_Name1Text.SetText(config.Name);
                ItemHero.ELabel_attackText.SetText(config.attack.ToString());
                ItemHero.ELabel_lifeText.SetText(config.life.ToString());
                ItemHero.ELabel_posText.SetText(config.Position.ToString());
                ItemHero.ELabel_IdText.SetText("" + (index + 1001));


            }
            ItemHero.EButton_SelectButton.AddListener(() => self.OnSelectHeroItemHandler(index + 1001));
            
            Log.Debug(self.ZoneScene().GetComponent<HeroInfoComponent>().SelectHero + "SelectHero");



            //ItemHero.EButton_SelectImage.AddListener(EventTriggerType.Drag, OnDrag);
            ////ItemHero.EButton_SelectImage.AddListener(EventTriggerType.EndDrag, OnEndDrag);
            //ItemHero.EButton_SelectImage.AddListener(EventTriggerType.BeginDrag, OnBeginDrag);
            //EventTrigger.(ItemHero.EButton_SelectImage.gameObject).onBeginDrag.AddListener(onBeginDrag);
            //EventListener.Get(ItemHero.EButton_SelectImage.gameObject).onBeginDrag = OnBeginDrag;
            //EventListener.Get(ItemHero.EButton_SelectImage.gameObject).onDrag = OnDrag;
            //EventListener.Get(ItemHero.EButton_SelectImage.gameObject).onEndDrag = OnEndDrag;



            EventTrigger.Entry entry = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry.eventID = EventTriggerType.BeginDrag;
            entry.callback.AddListener((BaseEventData eventData) => {
                OnBeginDrag(ItemHero.EButton_SelectImage.gameObject, eventData);
            });
            ItemHero.EButton_SelectImage.GetComponent<EventTrigger>().triggers.Add(entry);

            EventTrigger.Entry entry1 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry1.eventID = EventTriggerType.Drag;
            entry1.callback.AddListener((BaseEventData eventData) => {
                OnDrag(ItemHero.EButton_SelectImage.gameObject, eventData);
            });
            ItemHero.EButton_SelectImage.GetComponent<EventTrigger>().triggers.Add(entry1);

            EventTrigger.Entry entry2 = new EventTrigger.Entry(); // 保存有事件类型，和回调函数
            entry2.eventID = EventTriggerType.EndDrag;
            entry2.callback.AddListener((BaseEventData eventData) => {
                OnEndDrag(ItemHero.EButton_SelectImage.gameObject, eventData);
            });
            ItemHero.EButton_SelectImage.GetComponent<EventTrigger>().triggers.Add(entry2);

            //AddTriggersListener(ItemHero.EButton_SelectImage.gameObject, EventTriggerType.BeginDrag, OnBeginDrag);
            //AddTriggersListener(ItemHero.EButton_SelectImage.gameObject, EventTriggerType.Drag, OnDrag);
            //AddTriggersListener(ItemHero.EButton_SelectImage.gameObject, EventTriggerType.EndDrag, OnEndDrag);

            //.AddListener(EventTriggerType.BeginDrag, OnBeginDrag);
            //ItemHero.EButton_SelectImage.gameObject.GetComponent<EventTrigger>().AddListener(EventTriggerType.Drag, (BaseEventData eventData) => {

            //    OnDrag(ItemHero.EButton_SelectImage.gameObject, eventData);
            //});


            //ItemHero.EButton_SelectImage.gameObject.GetComponent<EventTrigger>().AddListener(EventTriggerType.EndDrag, (BaseEventData eventData )=> {

            //    OnEndDrag(ItemHero.EButton_SelectImage.gameObject, eventData);
            //});
        }

        /// <summary>
        /// 为组件添加监听事件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="eventTriggerType"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        /// 

        public static void AddTriggersListener(GameObject obj, EventTriggerType eventID, UnityAction<GameObject,BaseEventData> action)
        {
            EventTrigger trigger = obj.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = obj.AddComponent<EventTrigger>();
            }

            if (trigger.triggers.Count == 0)
            {
                trigger.triggers = new List<EventTrigger.Entry>();
            }
            UnityAction<GameObject,BaseEventData> callback = new UnityAction<GameObject,BaseEventData>(action);
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = eventID;
            entry.callback.AddListener((data) => { callback(obj,data); });
            trigger.triggers.Add(entry);
        }


        //public static void AddListener(this Component obj, EventTriggerType eventTriggerType, UnityAction<BaseEventData> callback)
        //{
        //    //添加EventTrigger组件
        //    EventTrigger trigger = obj.GetComponent<EventTrigger>();
        //    if (trigger == null)
        //    {
        //        trigger = obj.gameObject.AddComponent<EventTrigger>();
        //    }

        //    //获取事件列表
        //    List<EventTrigger.Entry> entries = trigger.triggers;
        //    if (entries == null)
        //    {
        //        entries = new List<EventTrigger.Entry>();
        //    }
        //    //获取对应事件
        //    EventTrigger.Entry entry = new EventTrigger.Entry();
        //    bool isExist = false;
        //    for (int i = 0; i < entries.Count; i++)
        //    {
        //        if (entries[i].eventID == eventTriggerType)
        //        {
        //            entry = entries[i];
        //            isExist = true;
        //        }
        //    }
        //    entry.callback.AddListener(callback);
        //    if (!isExist)
        //    {
        //        trigger.triggers.Clear();
        //        trigger.triggers.Add(entry);
        //    }
        //}

        public static void OnBeginDrag(BaseEventData eventData)
        {
            Log.Debug("OnBeginDrag111");
        }

        public static void OnBeginDrag(GameObject go, BaseEventData eventData)
        {
            Log.Debug("OnBeginDrag");
            //DlgHeroMain.DragCardId = go.transform.parent.Find("ELabel_Id").GetComponent<Text>().text.ToInt32();
            Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId = go.transform.parent.Find("ELabel_Id").GetComponent<Text>().text.ToInt32() ;

            RectTransform ERect_Icon = go.transform.parent.Find("ERect_Icon").GetComponent<RectTransform>();

            ERect_Icon.SetVisible(true);
            //Log.Debug(DlgHeroMain.DragCardId + "OnBeginDrag" + eventData.ToString());
        }

        public static void OnDrag(GameObject go, BaseEventData eventData)
        {
            //Log.Debug("OnDrag");

            if (go.GetComponent<RectTransform>())
            {
                Vector3 v3;
                PointerEventData data = eventData as PointerEventData;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(go.GetComponent<RectTransform>(),
                    data.position, data.enterEventCamera, out v3);

                RectTransform ERect_Icon = go.transform.parent.Find("ERect_Icon").GetComponent<RectTransform>();
                //Debug.Log("OnDrag:" + v3);
                ERect_Icon.position = v3;
               // Debug.Log("OnDrag:" + ERect_Icon.localPosition);
            }
            else
            {
                if (SetCameraRayPoint(out Vector3 pos, go))
                {
                    go.transform.position = pos;
                }
            }
        }

        public static void OnEndDrag(GameObject go, BaseEventData eventData)
        {
            //Vector3 v3;
            //PointerEventData data = eventData as PointerEventData;
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(go.GetComponent<RectTransform>(),
            //data.position, data.enterEventCamera, out v3);
            RectTransform ERect_Icon = go.transform.parent.Find("ERect_Icon").GetComponent<RectTransform>();

            RectTransform MyCard = go.transform.parent.parent.parent.parent.parent.Find("ELoopScrollList_MyCard").GetComponent<RectTransform>();
            Vector3 mouseWorld = MyCard.parent.TransformPoint(ERect_Icon.transform.localPosition);
            Vector3 mouseLocal = MyCard.parent.InverseTransformPoint(ERect_Icon.transform.position);
            //Log.Debug(MyCard.transform.name+"mouseWorld" + mouseWorld+ MyCard.transform.position + "mouseLocal"+ mouseLocal);

            if ((Math.Abs(mouseLocal.x - MyCard.transform.localPosition.x) < MyCard.sizeDelta.x / 2) &&
                (Math.Abs(mouseLocal.y - MyCard.transform.localPosition.y) < MyCard.sizeDelta.y / 2))
            {
                //Log.Debug(Game.zoneScene.GetComponent<HeroInfoComponent>().MyCardNum+"在里面" + Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId);
                if (!Game.zoneScene.GetComponent<HeroInfoComponent>().MyCardNum.Contains(Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId ) && Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId != 0)
                { 
                    Game.zoneScene.GetComponent<HeroInfoComponent>().MyCardNum.Add(Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId);
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgHeroMain>()?.ShowMyCard();
                }

            }
            else
            {
                //Log.Debug("在外面");
            }
            Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId = 0;


            ERect_Icon.SetVisible(false);
            ERect_Icon.position = Vector3.zero;
            //Log.Debug("OnEndDrag");
        }



        public static void OnBeginDragMyCard(GameObject go, BaseEventData eventData)
        {

            //DlgHeroMain.DragCardId = go.transform.parent.Find("ELabel_Id").GetComponent<Text>().text.ToInt32();
            Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId = go.transform.parent.Find("ELabel_Id").GetComponent<Text>().text.ToInt32(); ;

            RectTransform ERect_Icon = go.transform.parent.Find("ERect_Icon").GetComponent<RectTransform>();

            ERect_Icon.SetVisible(true);
            //Log.Debug(DlgHeroMain.DragCardId + "OnBeginDrag" + eventData.ToString());
        }

        public static void OnDragMyCard(GameObject go, BaseEventData eventData)
        {


            if (go.GetComponent<RectTransform>())
            {
                Vector3 v3;
                PointerEventData data = eventData as PointerEventData;
                RectTransformUtility.ScreenPointToWorldPointInRectangle(go.GetComponent<RectTransform>(),
                    data.position, data.enterEventCamera, out v3);

                RectTransform ERect_Icon = go.transform.parent.Find("ERect_Icon").GetComponent<RectTransform>();
                Debug.Log("OnDragMyCard:" + v3);
                ERect_Icon.transform.GetComponent<RectTransform>().position = v3;
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

        public static void OnEndDragMyCard(GameObject go, BaseEventData eventData)
        {
            //Vector3 v3;
            //PointerEventData data = eventData as PointerEventData;
            //RectTransformUtility.ScreenPointToWorldPointInRectangle(go.GetComponent<RectTransform>(),
            //data.position, data.enterEventCamera, out v3);
            RectTransform ERect_Icon = go.transform.parent.Find("ERect_Icon").GetComponent<RectTransform>();

            RectTransform MyCard = go.transform.parent.parent.parent.parent.parent.Find("ELoopScrollList_MyCard").GetComponent<RectTransform>();
            Vector3 mouseWorld = MyCard.parent.TransformPoint(ERect_Icon.transform.localPosition);
            Vector3 mouseLocal = MyCard.parent.InverseTransformPoint(ERect_Icon.transform.position);
            //Log.Debug(MyCard.transform.name+"mouseWorld" + mouseWorld+ MyCard.transform.position + "mouseLocal"+ mouseLocal);

            if ((Math.Abs(mouseLocal.x - MyCard.transform.localPosition.x) < MyCard.sizeDelta.x / 2) &&
                (Math.Abs(mouseLocal.y - MyCard.transform.localPosition.y) < MyCard.sizeDelta.y / 2))
            {
                

            }
            else
            {
                Log.Debug(Game.zoneScene.GetComponent<HeroInfoComponent>().MyCardNum + "在外面" + Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId);
                if (Game.zoneScene.GetComponent<HeroInfoComponent>().MyCardNum.Contains(Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId))
                {
                    Log.Debug("包含");
                    //Game.zoneScene.GetComponent<HeroInfoComponent>().MyCardNum.Add(Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId);
                    Game.zoneScene.GetComponent<HeroInfoComponent>().MyCardNum.Remove(Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId);
                    Game.zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgHeroMain>()?.ShowMyCard();
                }
                Log.Debug("在外面");
            }
            Game.zoneScene.GetComponent<HeroInfoComponent>().DragCardId = 0;

            ERect_Icon.SetVisible(false);
            ERect_Icon.position = Vector3.zero;
            //Log.Debug("OnEndDrag");
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


        public static void OnSelectHeroItemHandler(this DlgHeroMain self, int HeroId)
        {
      
            self.ZoneScene().GetComponent<HeroInfoComponent>().SelectHero = HeroId;
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SingHero);
        }

        public static async ETTask OnClickBackHandler(this DlgHeroMain self)
        {
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_GameMain);
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_HeroMain);
            await ETTask.CompletedTask;
        }
        public static async ETTask OnClickClearHandler(this DlgHeroMain self)
        {
            self.ZoneScene().GetComponent<HeroInfoComponent>().MyCardNum.Clear();

            int count = self.ZoneScene().GetComponent<HeroInfoComponent>().MyCardNum.Count;
            self.AddUIScrollItems(ref self.ScrollItemMyCardDic, count);
            self.View.ELoopScrollList_MyCardLoopVerticalScrollRect.SetVisible(true, count);
            self.View.ELabel_CardsNumText.SetText("CardNum:" + count);
            self.View.EButton_SaveCardButton.interactable = false;
            await ETTask.CompletedTask;
        }
        public static async ETTask OnClickSaveHandler(this DlgHeroMain self)
        {
            Log.Debug("OnClickSaveHandler");


            try
            {
                int error = await HeroHelper.SaveHeroCard(self.ZoneScene());
                if (error != ErrorCode.ERR_Success)
                {
                    return;
                }
                
                Log.Debug("保存卡片");
            }
            catch (Exception e)
            {
                Log.Debug(e.ToString());
            }

            await ETTask.CompletedTask;

        }
    }
}
