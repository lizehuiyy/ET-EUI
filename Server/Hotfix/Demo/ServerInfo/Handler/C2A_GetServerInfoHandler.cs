using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class C2A_GetServerInfoHandler : AMRpcHandler<C2A_GetServerInfo, A2C_GetServerInfo>
    {
        protected override async ETTask Run(Session session, C2A_GetServerInfo request, A2C_GetServerInfo response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求Scene错误，当前Scene为：{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            //string token = session.DomainScene().GetComponent<TokenComponent>()

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_GetServerInfo;
                reply();
                session.Dispose();
                return;
            }

            

            await ETTask.CompletedTask;
        }
    }
}
