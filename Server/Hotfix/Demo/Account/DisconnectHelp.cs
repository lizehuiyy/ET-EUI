using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class DisconnectHelp
    {
        public static async ETTask disconnect(this Session self)
        {
            if (self == null || self.IsDisposed)
            {
                return;
            }

            long InstanceId = self.InstanceId;
            await TimerComponent.Instance.WaitAsync(1000);

            if (self.InstanceId != InstanceId)
            {
                return;
            }

            self.Dispose();
        
        
        }


    }
}
