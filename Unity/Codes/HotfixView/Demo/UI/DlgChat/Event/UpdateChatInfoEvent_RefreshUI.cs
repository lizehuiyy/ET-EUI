using ET.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class UpdateChatInfoEvent_RefreshUI : AEvent<UpdateChatInfo>
    {
        protected override void Run(UpdateChatInfo a)
        {
            Log.Debug("UpdateChatInfoEvent_RefreshUIRefresh");
            a.zoneScene.GetComponent<UIComponent>()?.GetDlgLogic<DlgChat>()?.Refresh();
        }
    }
}
