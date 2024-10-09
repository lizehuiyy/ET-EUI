using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.EventType;

namespace ET
{
    public class EndRoundRoomEvent : AEvent<EndRoundRoom>
    {
        protected override void Run(EndRoundRoom a)
        {
            //a.zoneScene.GetComponent<UIComponent>()?.HideWindow(WindowID.WindowID_GameMain);
            //a.zoneScene.GetComponent<UIComponent>()?.ShowWindow(WindowID.WindowID_Room);
            
            a.zoneScene.GetComponent<UIComponent>()?.GetDlgLogic<DlgRoom>()?.ShowEndRoundCard();
        }
    }
}
