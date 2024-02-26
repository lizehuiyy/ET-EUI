using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Reflection;
using UnityEngine.EventSystems;

namespace ET
{
    [FriendClass(typeof(DlgSingHero))]
    [FriendClassAttribute(typeof(ET.HeroInfoComponent))]
    public static class DlgSingHeroSystem
    {

        public static void RegisterUIEvent(this DlgSingHero self)
        {
            self.View.EButton_backgroudButton.onClick.AddListener(()=>self.OnCloseHandler());
        } 

        public static void ShowWindow(this DlgSingHero self, Entity contextData = null)
        {
            self.View.EGContectRectRectTransform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0);
            self.View.EGContectRectRectTransform.DOScale(Vector3.one, 0.3f).onComplete += () => { self.Refresh(); };



        }

        public static void OnCloseHandler(this DlgSingHero self)
        {
            self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_SingHero);
            self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_HeroMain);

        }



        public static void Refresh(this DlgSingHero self)
        {
            int HeroId = self.ZoneScene().GetComponent<HeroInfoComponent>().SelectHero;
            Log.Debug("HeroId"+ HeroId);
            if (UnitConfigCategory.Instance.GetAll().ContainsKey(HeroId))
            {
                var config = UnitConfigCategory.Instance.GetAll()[HeroId];
                Log.Debug("NAME" + config.Name + HeroId);
                self.View.ELabel_ContentText.SetText(config.Desc);
                self.View.ELabel_NameText.SetText(config.Name);
                self.View.ELabel_attackText.SetText(config.attack.ToString());
                self.View.ELabel_lifeText.SetText(config.life.ToString());
                self.View.ELabel_posText.SetText(config.Position.ToString());
            }


        }


    }
}
