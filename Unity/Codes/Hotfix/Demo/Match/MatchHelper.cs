using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class MatchHelper
    {
        public static async ETTask<int> StartMatch(Scene zoneScene)
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
                return ErrorCode.ERR_NetWorkError;
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
                return ErrorCode.ERR_NetWorkError;
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



    }
}
