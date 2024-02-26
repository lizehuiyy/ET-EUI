using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.SessionPlayerComponent))]
    [FriendClassAttribute(typeof(ET.SessionStateComponent))]
    [FriendClassAttribute(typeof(ET.GateMapComponent))]
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    [FriendClassAttribute(typeof(ET.UnitGateComponent))]
    public class C2G_EnterGameHandler : AMRpcHandler<C2G_EnterGame, G2C_EnterGame>
    {
        protected override async ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response, Action reply)
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

            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.Account.GetHashCode()))
                {
                    if (instanceId != session.InstanceId || player.IsDisposed)
                    {
                        response.Error = ErrorCode.ERR_PlayerSessionError;
                        reply();
                        return;
                    }
                    if (session.GetComponent<SessionStateComponent>() != null && session.GetComponent<SessionStateComponent>().State == SessionState.Game)
                    {
                        response.Error = ErrorCode.ERR_SessionError;
                        reply();
                        return;
                    }

                    if (player.PlayerState == PlayerState.Map)
                    {
                        try
                        {
                            IActorResponse reqEnter = await MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestEnterGameState() { });


                            if (reqEnter.Error == ErrorCode.ERR_Success)
                            {
                                reply();
                                return;
                            }

                            Log.Error("二次登陆失败1" + reqEnter.Error + "|||" + reqEnter.Message);
                            response.Error = ErrorCode.ERR_ReEnterGameError;
                            await DisconnectHelp.KickPlayer(player, true);
                            reply();
                            session?.disconnect().Coroutine();
                        }
                        catch (Exception e)
                        {
                            Log.Error("二次登陆失败" + e.ToString());
                            response.Error = ErrorCode.ERR_ReEnterGameError2;
                            await DisconnectHelp.KickPlayer(player, true);
                            reply();
                            session?.disconnect().Coroutine();

                            throw;
                        }
                        return;

                    }


                    try
                    {
                        //GateMapComponent gateMapComponent = player.AddComponent<GateMapComponent>();
                        //gateMapComponent.Scene = await SceneFactory.Create(gateMapComponent, "GateMap", SceneType.Map);

                        //Unit unit = UnitFactory.Create(gateMapComponent.Scene,player.Id,UnitType.Player);
                        //unit.AddComponent<UnitGateComponent, long>(session.InstanceId);

                        (bool isNewPlayer, Unit unit) = await UnitHelper.LoadUnit(player);
                        unit.AddComponent<UnitGateComponent, long>(player.InstanceId);

                        player.ChatInfoInstanceId = await this.EnterWorldChatServer(unit);//登录聊天服
                        player.MatchInstanceId = await this.EnterMatchServer(unit);//登录寻找比赛服


                        await UnitHelper.InitUnit(unit, isNewPlayer);

                        response.MyId = unit.Id;
                        reply();

                        StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Map");
                        await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name);



                        SessionStateComponent sessionStateComponent = session.GetComponent<SessionStateComponent>();
                        if (sessionStateComponent == null)
                        {
                            sessionStateComponent = session.AddComponent<SessionStateComponent>();
                        }
                        sessionStateComponent.State = SessionState.Map;
                        player.PlayerState = PlayerState.Map;

                    }
                    catch (Exception e)
                    {
                        Log.Error($"角色进入游戏逻辑服出现问题 账号ID{player.Account},角色Id：{player.Id},异常信息：{e.ToString()}");
                        response.Error = ErrorCode.ERR_EnterGameError;
                        reply();
                        await DisconnectHelp.KickPlayer(player, true);
                        session?.disconnect().Coroutine();

                    }


                }


            }
        }


        private async ETTask<long> EnterWorldChatServer(Unit unit)
        {

            Log.Debug(" + unit.GetComponent<RoleInfo>().Name" + unit.GetComponent<RoleInfo>().Name);
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "ChatInfo");
            Chat2G_EnterChat chat2G_EnterChat = (Chat2G_EnterChat)await MessageHelper.CallActor(startSceneConfig.InstanceId, new G2Chat_EnterChat()
            {
                UnitId = unit.Id,
                Name = unit.GetComponent<RoleInfo>().Name,
                GateSessionActorId = unit.GetComponent<UnitGateComponent>().GateSessionActorId,
            });

            return chat2G_EnterChat.ChatInfoUnitInstanceId;
        }
        private async ETTask<long> EnterMatchServer(Unit unit)
        {

            Log.Debug(" + unit.GetComponent<RoleInfo>().Name" + unit.GetComponent<RoleInfo>().Name);
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "Match");
            Match2G_EnterMatch match2G_EnterMatch = (Match2G_EnterMatch)await MessageHelper.CallActor(startSceneConfig.InstanceId, new G2Match_EnterMatch()
            {
                UnitId = unit.Id,
                Name = unit.GetComponent<RoleInfo>().Name,
                GateSessionActorId = unit.GetComponent<UnitGateComponent>().GateSessionActorId,
                MMR = unit.GetComponent<NumericComponent>().GetAsInt((int)NumericType.MMR),

            });

            return match2G_EnterMatch.MatchInfoUnitInstanceId;
        }


        
    }
}
