using ET.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.NumericNoticeComponent))]
    public static class NumericNoticeComponentSystem
    {
        public static void NoticeImmdiately(this NumericNoticeComponent self, NumbericChange args)
        {
            Unit unit = self.GetParent<Unit>();

            self.NoticeUnitNumericMessage.UnitId = unit.Id;
            self.NoticeUnitNumericMessage.NumericType = args.NumericType;
            self.NoticeUnitNumericMessage.NewValue = args.New;
            MessageHelper.SendToClient(unit,self.NoticeUnitNumericMessage);


        }

    }
}
