using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ET
{
    [FriendClassAttribute(typeof(ET.HeroInfoComponent))]
    [FriendClassAttribute(typeof(ET.AccountInfoComponent))]
    public static class MatchHelper
    {
        public static async ETTask<int> StartMatch(Scene zoneScene)
        {
            //角色请求进入寻找比赛
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;

            Match2C_StartMatch match2C_StartMatch = null;
            try
            {
                match2C_StartMatch = (Match2C_StartMatch)await gateSession.Call(new C2Match_StartMatch()
                {
                    HeroCardList = zoneScene.GetComponent<HeroInfoComponent>().MyCardNum
                });
            }
            catch (Exception e)
            {
                Log.Error("进入匹配失败" + e.ToString());
                //zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_StartMatch;
            }
            if (match2C_StartMatch.Error != ErrorCode.ERR_Success)
            {
                Log.Error(match2C_StartMatch.Error.ToString());
                return match2C_StartMatch.Error;
            }



            //zoneScene.GetComponent<PlayerComponent>().MyId = g2C_EnterGame.MyId;


            //await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_SceneChangeFinish>();

            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> StopMatch(Scene zoneScene)
        {
            //角色请求进入寻找比赛
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;

            Match2C_StartMatch match2C_StartMatch = null;
            try
            {
                match2C_StartMatch = (Match2C_StartMatch)await gateSession.Call(new C2Match_StartMatch() { });
            }
            catch (Exception e)
            {
                Log.Error("进入匹配失败" + e.ToString());
                //zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_StopMatch;
            }
            if (match2C_StartMatch.Error != ErrorCode.ERR_Success)
            {
                Log.Error(match2C_StartMatch.Error.ToString());
                return match2C_StartMatch.Error;
            }



            //zoneScene.GetComponent<PlayerComponent>().MyId = g2C_EnterGame.MyId;


            //await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_SceneChangeFinish>();

            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> EndRoundMatch(Scene zoneScene)
        {
            //角色请求进入寻找比赛
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;

            Match2C_EndRoundMatch match2C_EndRoundMatch = null;
            try
            {
                match2C_EndRoundMatch = (Match2C_EndRoundMatch)await gateSession.Call(new C2Match_EndRoundMatch() { });
            }
            catch (Exception e)
            {
                Log.Error("回合结束失败" + e.ToString());
                //zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_EndMatch;
            }
            if (match2C_EndRoundMatch.Error != ErrorCode.ERR_Success)
            {
                Log.Error(match2C_EndRoundMatch.Error.ToString());
                return match2C_EndRoundMatch.Error;
            }

            //表演动画

            //zoneScene.GetComponent<PlayerComponent>().MyId = g2C_EnterGame.MyId;


            //await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_SceneChangeFinish>();

            return ErrorCode.ERR_Success;
        }
        public static async ETTask<int> GGMatch(Scene zoneScene)
        {
            //角色请求进入寻找比赛
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;

            Match2C_GGMatch match2C_GGMatch = null;
            try
            {
                match2C_GGMatch = (Match2C_GGMatch)await gateSession.Call(new C2Match_GGMatch()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                });
            }
            catch (Exception e)
            {
                Log.Error("投降失败" + e.ToString());
                //zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_EndMatch;
            }
            if (match2C_GGMatch.Error != ErrorCode.ERR_Success)
            {
                Log.Error(match2C_GGMatch.Error.ToString());
                return match2C_GGMatch.Error;
            }

            Log.Debug("投降成功");
            

            return ErrorCode.ERR_Success;
        }


    }
}
