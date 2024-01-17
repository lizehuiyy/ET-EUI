using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class C2R_LoginRealmHandler : AMRpcHandler<C2R_LoginRealm, R2C_LoginRealm>
    {
        protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response, Action reply)
        {

            if (session.DomainScene().SceneType != SceneType.Realm)
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

            if (token == null || token != request.RealmTokenKey)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.disconnect().Coroutine();
                return;
            }

            session.DomainScene().GetComponent<TokenComponent>().Remove(request.AccountId);

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginRealm, request.AccountId))
                {
                    StartSceneConfig config = RealmGateAddressHelper.GetGate(session.DomainScene().Zone, request.AccountId);
                    G2R_GetLoginGateKey g2R_GetLoginKey = (G2R_GetLoginGateKey)await MessageHelper.CallActor(config.InstanceId, new R2G_GetLoginGateKey() { AccountId = request.AccountId });

                    if (g2R_GetLoginKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = g2R_GetLoginKey.Error;
                        reply();
                        return;
                    }
                    response.GateSessionKey = g2R_GetLoginKey.GateSessionKey;
                    response.GateAddress = config.OuterIPPort.ToString();
                    reply();
                    session?.disconnect().Coroutine();

                }
            }

            await ETTask.CompletedTask;
        }
    }
}
