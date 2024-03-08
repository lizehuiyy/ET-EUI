using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.SessionPlayerComponent))]
    [FriendClassAttribute(typeof(ET.GateMapComponent))]
    [FriendClassAttribute(typeof(ET.HeroInfoComponent))]
    public class C2G_SaveCardHandler : AMRpcHandler<C2G_SaveCard, G2C_SaveCard>
    {
        protected override async ETTask Run(Session session, C2G_SaveCard request, G2C_SaveCard response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error($"请求Scene错误，当前scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
            if (sessionPlayerComponent == null)
            {
                response.Error = ErrorCode.ERR_SessionPlayerError;
                reply();
                return;
            }

            Player player = Game.EventSystem.Get(sessionPlayerComponent.PlayerInstanceId) as Player;
            if (player == null || player.IsDisposed)
            {
                response.Error = ErrorCode.ERR_NonePlayerError;
                reply();
                return;
            }

            try
            {
                GateMapComponent gateMapComponent = player.GetComponent<GateMapComponent>();
                Unit unit = await UnitCacheHelper.GetUnitCache(gateMapComponent.Scene, player.UnitId);
                HeroInfoComponent heroInfoComponent = unit.GetComponent<HeroInfoComponent>();
                if (heroInfoComponent == null)
                {
                    heroInfoComponent = unit.AddComponent<HeroInfoComponent>();
                }
                heroInfoComponent.MyCardNum = request.HeroCardList;
                UnitCacheHelper.AddOrUpdateUnitAllCache(unit);
                reply();
            }
            catch (Exception e)
            {
                Log.Error($"角色保存卡组出现问题 账号ID{player.Account},角色Id：{player.Id},异常信息：{e.ToString()}");

                reply();


            }


            await ETTask.CompletedTask;
        }
    }
}
