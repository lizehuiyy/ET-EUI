using ET.EventType;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [NumericWatcher(NumericType.Level)]
    [NumericWatcher(NumericType.Gold)]
    [NumericWatcher(NumericType.Exp)]
    [NumericWatcher(NumericType.MMR)]

    public class NumericWatcher_RefreashMainUI : INumericWatcher
    {
        public void Run(NumbericChange args)
        {
            Log.Debug("NumericWatcher_RefreashMainUI");
            args.Parent.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgGameMain>()?.Refresh();
        }
    }
}
