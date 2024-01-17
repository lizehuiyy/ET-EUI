using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    public class C2A_GetRoleHandler : AMRpcHandler<C2A_GetRole, A2C_GetRole>
    {
        protected override async ETTask Run(Session session, C2A_GetRole request, A2C_GetRole response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求Scene错误，当前Scene：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestSessionRepeatedly;
                reply();
                session?.disconnect().Coroutine();
                return;
            }


            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole, request.AccountId))
                {
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                        .Query<RoleInfo>(d => d.AccountId == request.AccountId && d.ServerId == request.ServerId && d.State == (int)RoleInfoState.Normal);
                    if (roleInfos != null && roleInfos.Count == 0)
                    {
                        reply();
                        return;
                    }

                    foreach (var roleInfo in roleInfos)
                    {
                        response.RoleInfo.Add(roleInfo.ToMessage());
                        roleInfo?.Dispose();

                    }
                    roleInfos.Clear();
                    reply();


                }
            }


            await ETTask.CompletedTask;
        }
    }
}
