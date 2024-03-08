using System;
using System.IO;


namespace ET
{
    [FriendClassAttribute(typeof(ET.AccountInfoComponent))]
    [FriendClassAttribute(typeof(ET.ServerInfoComponent))]
    [FriendClassAttribute(typeof(ET.RoleInfoComponent))]
    [FriendClassAttribute(typeof(ET.HeroInfoComponent))]
    public static class LoginHelper
    {
        //public static async ETTask Login(Scene zoneScene, string address, string account, string password)
        //{
        //    try
        //    {
        //        // 创建一个ETModel层的Session
        //        R2C_Login r2CLogin;
        //        Session session = null;
        //        try
        //        {
        //            session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
        //            {
        //                r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = password });
        //            }
        //        }
        //        finally
        //        {
        //            session?.Dispose();
        //        }

        //        // 创建一个gate Session,并且保存到SessionComponent中
        //        Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));
        //        gateSession.AddComponent<PingComponent>();
        //        zoneScene.AddComponent<SessionComponent>().Session = gateSession;

        //        G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
        //            new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

        //        Log.Debug("登陆gate成功!");

        //        Game.EventSystem.PublishAsync(new EventType.LoginFinish() {ZoneScene = zoneScene}).Coroutine();
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //    }
        //} 

        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            A2C_LoginAccount a2C_LoginAccount = null;
            Session accountSession = null;

            try
            {
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                password = MD5Helper.StringMD5(password);
                a2C_LoginAccount = (A2C_LoginAccount)await accountSession.Call(new C2A_LoginAccount() { AccountName = account, Password = password });


            }
            catch (Exception e)
            {
                accountSession?.Dispose();

                Log.Error("tryLoginerror:" + e.ToString());
                return ErrorCode.ERR_NetWorkError;

            }

            if (a2C_LoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                return a2C_LoginAccount.Error;
            }
            zoneScene.AddComponent<SessionComponent>().Session = accountSession;
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

            zoneScene.GetComponent<AccountInfoComponent>().Token = a2C_LoginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = a2C_LoginAccount.AccountId;


            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfo a2C_GetServerInfo = null;
            try
            {
                a2C_GetServerInfo = (A2C_GetServerInfo)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetServerInfo()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token

                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_GetServerInfo;

            }
            if (a2C_GetServerInfo.Error != ErrorCode.ERR_Success)
            {
                return a2C_GetServerInfo.Error;
            }
            foreach (var serverInfoProto in a2C_GetServerInfo.ServerInfoList)
            {
                ServerInfo serverInfo = zoneScene.GetComponent<ServerInfoComponent>().AddChild<ServerInfo>();
                serverInfo.FromMessage(serverInfoProto);
                zoneScene.GetComponent<ServerInfoComponent>().Add(serverInfo);
            }

            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }


        public static async ETTask<int> CreateRole(Scene zoneScene, string name)
        {
            A2C_CreateRole a2C_CreateRole = null;

            try
            {
                a2C_CreateRole = (A2C_CreateRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_CreateRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    Name = name,
                    ServerId = zoneScene.GetComponent<ServerInfoComponent>().CurrentServerId,

                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_CreateRole;
            }

            if (a2C_CreateRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_CreateRole.Error.ToString());
                return a2C_CreateRole.Error;
            }
            RoleInfo newRoleInfo = zoneScene.GetComponent<RoleInfoComponent>().AddChild<RoleInfo>();
            newRoleInfo.FromMessage(a2C_CreateRole.RoleInfo);


            zoneScene.GetComponent<RoleInfoComponent>().RoleInfos.Add(newRoleInfo);


            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRoles(Scene zoneScene)
        {
            A2C_GetRole a2C_GetRole = new A2C_GetRole();

            try
            {
                a2C_GetRole = (A2C_GetRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfoComponent>().CurrentServerId,
                });

            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_GetRole;
            }

            if (a2C_GetRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_GetRole.Error.ToString());
                return a2C_GetRole.Error;
            }

            zoneScene.GetComponent<RoleInfoComponent>().RoleInfos.Clear();
            foreach (var roleinfoProto in a2C_GetRole.RoleInfo)
            {
                RoleInfo newRoleInfo = zoneScene.GetComponent<RoleInfoComponent>().AddChild<RoleInfo>();
                newRoleInfo.FromMessage(roleinfoProto);
                Log.Debug("countcopu1111");
                zoneScene.GetComponent<RoleInfoComponent>().RoleInfos.Add(newRoleInfo);
            }



            return 0;

        }

        public static async ETTask<int> DeleteRole(Scene zoneScene)
        {
            A2C_DeleteRole a2C_DeleteRole = null;


            try
            {
                a2C_DeleteRole = (A2C_DeleteRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_DeleteRole()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RoleInfoId = zoneScene.GetComponent<RoleInfoComponent>().CurrentRoleId,
                    ServerId = zoneScene.GetComponent<ServerInfoComponent>().CurrentServerId

                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_DeleteRole;
            }
            if (a2C_DeleteRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_DeleteRole.Error.ToString());
                return a2C_DeleteRole.Error;
            }
            int index = zoneScene.GetComponent<RoleInfoComponent>().RoleInfos.FindIndex((info) => { return info.Id == a2C_DeleteRole.DeleteRoleInfoId; });

            zoneScene.GetComponent<RoleInfoComponent>().RoleInfos.RemoveAt(index);



            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            A2C_GetRealmKey a2C_GetRealmKey = null;

            try
            {
                a2C_GetRealmKey = (A2C_GetRealmKey)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRealmKey()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    ServerId = zoneScene.GetComponent<ServerInfoComponent>().CurrentServerId
                });
            }
            catch (Exception e)
            {
                Log.Error("A2C_GetRealmKey Error:" + e.ToString());
                return ErrorCode.ERR_GetRealmKey;
            }

            if (a2C_GetRealmKey.Error != ErrorCode.ERR_Success)
            {
                Log.Error("a2C_GetRealmKey error:" + a2C_GetRealmKey.Error.ToString());
                return a2C_GetRealmKey.Error;
            }

            zoneScene.GetComponent<AccountInfoComponent>().RealmKey = a2C_GetRealmKey.RealmKey;
            zoneScene.GetComponent<AccountInfoComponent>().RealmAddress = a2C_GetRealmKey.RealmAddress;
            zoneScene.GetComponent<SessionComponent>().Session.Dispose();


            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> EnterGame(Scene zoneScene)
        {
            string realmAddress = zoneScene.GetComponent<AccountInfoComponent>().RealmAddress;


            //链接Realm 分配获取的Gate
            R2C_LoginRealm r2C_LoginRealm;
            Session session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));

            try
            {
                r2C_LoginRealm = (R2C_LoginRealm)await session.Call(new C2R_LoginRealm()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RealmTokenKey = zoneScene.GetComponent<AccountInfoComponent>().RealmKey
                });
            }
            catch (Exception e)
            {
                Log.Error("链接Realm" + e.ToString());
                session?.Dispose();
                return ErrorCode.ERR_EnterRealm;
            }

            session?.Dispose();
            if (r2C_LoginRealm.Error != ErrorCode.ERR_Success)
            {
                Log.Error("r2C_LoginRealm error:" + r2C_LoginRealm.Error.ToString());
                return r2C_LoginRealm.Error;
            }


            Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2C_LoginRealm.GateAddress));
            gateSession.AddComponent<PingComponent>();

            zoneScene.GetComponent<SessionComponent>().Session = gateSession;

            //开始连接Gate

            long currentRoleId = zoneScene.GetComponent<RoleInfoComponent>().CurrentRoleId;
            G2C_LoginGameGate g2C_LoginGameGate = null;


            try
            {
                long accountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId;
                g2C_LoginGameGate = (G2C_LoginGameGate)await gateSession.Call(new C2G_LoginGameGate()
                {
                    Key = r2C_LoginRealm.GateSessionKey,
                    AccountId = accountId,
                    RoleId = currentRoleId
                });

                Log.Debug("登录Gate成功");


            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2C_LoginGameGate.Error != ErrorCode.ERR_Success)
            {
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return g2C_LoginGameGate.Error;
            }
            await EnterGameMap(zoneScene);
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> EnterGameMap(Scene zoneScene)
        {
            //角色正式请求进入游戏逻辑服
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;

            G2C_EnterGame g2C_EnterGame = null;
            try
            {
                g2C_EnterGame = (G2C_EnterGame)await gateSession.Call(new C2G_EnterGame() { });
            }
            catch (Exception e)
            {
                Log.Error("角色进入逻辑服失败" + e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }
            if (g2C_EnterGame.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_EnterGame.Error.ToString());
                return g2C_EnterGame.Error;
            }

            Log.Debug("角色进入游戏成功");

            zoneScene.GetComponent<PlayerComponent>().MyId = g2C_EnterGame.MyId;
            zoneScene.GetComponent<HeroInfoComponent>().MyCardNum = g2C_EnterGame.HeroCardList;


            await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_SceneChangeFinish>();
            Log.Debug("角色进入场景成功");
            return ErrorCode.ERR_Success;
        }


    }
}