using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ActorMessageHandler]
    public class A2L_loginAccountRequestHandler : AMActorRpcHandler<Scene, A2L_loginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_loginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
            long accountId = request.AccountId;

            Log.Debug(accountId+"acc");
            using ( await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountId.GetHashCode()))
            {
                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
                {
                    reply();
                    return;
                }
                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone,accountId);

                var g2L_DisconnectGateUnit  = (G2L_DisconnectGateUnit)await MessageHelper.CallActor(gateConfig.InstanceId, 
                    new L2G_DisconnectGateUnit() { AccountId = accountId });

                response.Error = g2L_DisconnectGateUnit.Error;
                reply();
            }
 
        }
    }
}
