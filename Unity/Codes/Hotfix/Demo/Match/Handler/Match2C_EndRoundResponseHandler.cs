using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.GameControlComponent))]
    public class Match2C_EndRoundResponseHandler : AMHandler<Match2C_EndRoundResponse>
    {
        protected override void Run(Session session, Match2C_EndRoundResponse message)
        {
            Log.Debug(message.PlayerRoundResultList[0].UnitId + "Match2C_EndRoundResponseHandler" + message.ToString());
            Log.Debug(message.PlayerRoundResultList[1].UnitId + "Match2C_EndRoundResponseHandler" + message.ToString());

            GameControlComponent gameControlComponent = session.ZoneScene().GetComponent<Room>().GetComponent<GameControlComponent>();
            gameControlComponent.PlayerRoundResultList = message.PlayerRoundResultList;


            Game.EventSystem.Publish(new EventType.EndRoundRoom() { zoneScene = session.ZoneScene() });
        }
    }
}
