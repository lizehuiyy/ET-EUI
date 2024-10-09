using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.EventType;

namespace ET
{
    public class UpdateRoomEvent : AEvent<UpdateRoom>
    {
        protected override void Run(UpdateRoom a)
        {
            Log.Debug("UpdateRoom");
            a.zoneScene.GetComponent<UIComponent>()?.HideWindow(WindowID.WindowID_GameMain);
            a.zoneScene.GetComponent<UIComponent>()?.ShowWindow(WindowID.WindowID_Room);
        }
    }
}
