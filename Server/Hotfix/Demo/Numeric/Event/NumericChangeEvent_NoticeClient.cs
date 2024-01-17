using ET.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class NumericChangeEvent_NoticeClient : AEventClass<EventType.NumbericChange>
    {
        protected override async void Run(object a)
        {
            EventType.NumbericChange args = a as EventType.NumbericChange;
            if (!(args.Parent is Unit unit))
            {
                Log.Error("NumericChangeEvent_NoticeClientError");
                return;
            }
            unit.GetComponent<NumericNoticeComponent>()?.NoticeImmdiately(args);

            await ETTask.CompletedTask;
        }
    }
}
