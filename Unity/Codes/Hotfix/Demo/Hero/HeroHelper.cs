using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.HeroInfoComponent))]
    public static class HeroHelper
    {
        public static async ETTask<int> SaveHeroCard(Scene zoneScene)
        {
            //保存卡片到缓存服
            Session gateSession = zoneScene.GetComponent<SessionComponent>().Session;

            G2C_SaveCard g2C_SaveCard = null;
            try
            {
                C2G_SaveCard c2G_SaveCard = new C2G_SaveCard() { };
                c2G_SaveCard.HeroCardList = zoneScene.GetComponent<HeroInfoComponent>().MyCardNum;


                g2C_SaveCard = (G2C_SaveCard)await gateSession.Call(c2G_SaveCard);

            }
            catch (Exception e)
            {
                Log.Error("保存失败" + e.ToString());
                return ErrorCode.ERR_SaveHeroCard;
            }
            if (g2C_SaveCard.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_SaveCard.Error.ToString());
                return g2C_SaveCard.Error;
            }

            return ErrorCode.ERR_Success;
        }
    }

}
