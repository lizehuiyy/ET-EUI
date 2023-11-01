using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class AccountSessionsComponentDestroySystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSeesionDictionary.Clear();
        }
    }
    [FriendClassAttribute(typeof(ET.AccountSessionsComponent))]


    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSeesionDictionary.TryGetValue(accountId, out long instanceId))
            {
                return 0;


            }

            return instanceId;
        }

        public static void Add(this AccountSessionsComponent self,long accountId,long sessionInstanceId)
        {
            if (self.AccountSeesionDictionary.ContainsKey(accountId))
            {
                self.AccountSeesionDictionary[accountId] = sessionInstanceId;
            }
            self.AccountSeesionDictionary.Add(accountId, sessionInstanceId);
        
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSeesionDictionary.ContainsKey(accountId))
            {
                self.AccountSeesionDictionary.Remove(accountId);
            
            }
        
        
        }


    }
}
