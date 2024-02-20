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

        public static async ETTask KickPlayer(Player player, bool isException = false)
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

                        case PlayerState.Map:
                            //通知游戏逻辑服下线 unit角色逻辑 并将数据存入数据库
                            M2G_RequestExitGame m2G_RequestExitGame = (M2G_RequestExitGame)await MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestExitGame() { });

                            //通知聊天服下线Unit
                            Chat2G_RequestExitChat chat2G_RequestExitChat = (Chat2G_RequestExitChat)await MessageHelper.CallActor(player.ChatInfoInstanceId, new G2Chat_RequestExitChat());


                            //通知移除账号角色登录信息
                            long LoginCenterConfigSceneId = StartSceneConfigCategory.Instance.LoginCenterConfig.InstanceId;
                            L2G_RemoveLoginRecord l2G_RemoveLoginRecord = (L2G_RemoveLoginRecord)await MessageHelper.CallActor(LoginCenterConfigSceneId,
                                new G2L_RemoveLoginRecord()
                                {
                                    AccountId = player.Account,
                                    ServerId = player.DomainZone()
                                });


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
