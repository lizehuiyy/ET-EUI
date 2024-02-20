using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [Timer(TimerType.RankUI)]

    public class RankUITimer : ATimer<DlgRank>
    {
        public override void Run(DlgRank t)
        {
			t?.RefreshRankInfo().Coroutine();
        }
    }


    [FriendClass(typeof(DlgRank))]
    [FriendClassAttribute(typeof(ET.RankInfo))]
    public static class DlgRankSystem
    {

        public static void RegisterUIEvent(this DlgRank self)
        {
            self.RegisterCloseEvent<DlgRank>(self.View.EButton_XButton);
            self.View.ELoopScrollList_RankLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnRankItemLoopHandler(transform, index);
            });
        }

        public static void ShowWindow(this DlgRank self, Entity contextData = null)
        {
            self.RefreshRankInfo().Coroutine();
            self.Timer = TimerComponent.Instance.NewRepeatedTimer(5000, TimerType.RankUI, self);

        }

        public static void HideWindow(this DlgRank self, Entity contextData = null)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
        }

        public static void OnRankItemLoopHandler(this DlgRank self, Transform transform, int index)
        {
            Scroll_Item_rank scroll_Item_Rank = self.ScrollItemRank[index].BindTrans(transform);
            RankInfo rankinfo = self.ZoneScene().GetComponent<RankComponent>().GetRankInfoByIndex(index);

            int order = index + 1;
            scroll_Item_Rank.ELabel_RankText.SetText("" + order);
            scroll_Item_Rank.ELabel_NameText.SetText("" + rankinfo.Name);
            scroll_Item_Rank.ELabel_MMRText.SetText("" + rankinfo.MMR);




        }
        public static async ETTask RefreshRankInfo(this DlgRank self)
        {
            try
            {
                Scene zoneScene = self.ZoneScene();
                int errorCode = await RankHelper.GetRankInfo(zoneScene);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                if (!zoneScene.GetComponent<UIComponent>().IsWindowVisible(WindowID.WindowID_Rank))
                {
                    return;
                }
                int count = self.ZoneScene().GetComponent<RankComponent>().GetRankCount();
                self.AddUIScrollItems(ref self.ScrollItemRank, count);
                self.View.ELoopScrollList_RankLoopVerticalScrollRect.SetVisible(true, count);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }



        }


    }
}
