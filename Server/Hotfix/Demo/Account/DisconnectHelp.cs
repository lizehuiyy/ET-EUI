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

        public static async ETTask KickPlayer(Player player,bool isException = false)
        {
            if (player == null || player.IsDisposed)
            {
                return;
            }

            long instanceId = player.InstanceId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.Account.GetHashCode()))
            {
                if (player.IsDisposed || instanceId != player.InstanceId)
                {
                    return;
                }
                if (!isException)
                { 
                    switch (player.PlayerState)
                    {

                        case PlayerState.Disconnect:

                            break;

                        case PlayerState.Gate:

                            break;

                        case PlayerState.Game:
                            //通知游戏逻辑服下线 unit角色逻辑 并将数据存入数据库

                            break;
                    }
                }

                player.PlayerState = PlayerState.Disconnect;
                player.DomainScene().GetComponent<PlayerComponent>()?.Remove(player.Account);
                player?.Dispose();
                await TimerComponent.Instance.WaitAsync(300);

            }
            
        }


    }
}
