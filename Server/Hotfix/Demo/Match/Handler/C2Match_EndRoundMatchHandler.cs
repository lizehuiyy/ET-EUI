using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class C2Match_EndRoundMatchHandler : AMActorRpcHandler<Gamer, C2Match_EndRoundMatch, Match2C_EndRoundMatch>
    {
        protected override async ETTask Run(Gamer gamer, C2Match_EndRoundMatch request, Match2C_EndRoundMatch response, Action reply)
        {


            reply();

            await ETTask.CompletedTask;
        }
    }
}
