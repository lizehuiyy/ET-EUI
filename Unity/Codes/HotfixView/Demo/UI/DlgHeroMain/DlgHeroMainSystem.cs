using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using CommandLine;

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
        }

        public static void ShowWindow(this DlgHeroMain self, Entity contextData = null)
        {
            int count = UnitConfigCategory.Instance.GetAll().Count;
            self.AddUIScrollItems(ref self.ScrollItemHeroDic, count);
            self.View.ELoopScrollList_HeroLoopVerticalScrollRect.SetVisible(true, count);
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
                ItemHero.ELabel_attackText.SetText(config.attack.ToString());
                ItemHero.ELabel_lifeText.SetText(config.life.ToString());
                ItemHero.ELabel_posText.SetText(config.Position.ToString());
               
            }
            ItemHero.EButton_SelectButton.AddListener(() => self.OnSelectServerItemHandler(index + 1001));

            Log.Debug(self.ZoneScene().GetComponent<HeroInfoComponent>().SelectHero + "SelectHero");


        }
        public static void OnSelectServerItemHandler(this DlgHeroMain self, int HeroId)
        {
            //self.ZoneScene().GetComponent<ServerInfoComponent>().CurrentServerId = int.Parse(serverId.ToString());
            //Log.Debug($"当前选择的服务器Id 是：{serverId}");
            //self.View.ELoopScrollList_ServerLoopVerticalScrollRect.RefillCells();
            self.ZoneScene().GetComponent<HeroInfoComponent>().SelectHero = HeroId;
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_HeroMain);
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_SingHero);
        }


    }
}
