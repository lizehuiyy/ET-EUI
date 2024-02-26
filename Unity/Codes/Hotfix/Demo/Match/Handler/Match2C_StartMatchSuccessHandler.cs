using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class Match2C_StartMatchSuccessHandler : AMHandler<Match2C_StartMatchSuccess>
    {
        protected override void Run(Session session, Match2C_StartMatchSuccess message)
        {
            Gamer gamer1 = session.ZoneScene().GetComponent<Room>().AddChild<Gamer>(true);
            Gamer gamer2 = session.ZoneScene().GetComponent<Room>().AddChild<Gamer>(true);
            long myid = session.ZoneScene().GetComponent<PlayerComponent>().MyId;
            if (message.UnitId1 == myid)
            {
                gamer1.Name = message.Name1;
                gamer1.MMR = message.MMR1;
                gamer1.UserID = message.UnitId1;
                gamer2.Name = message.Name2;
                gamer2.MMR = message.MMR2;
                gamer2.UserID = message.UnitId2;
            }
            else if (message.UnitId2 == myid)
            {
                gamer1.Name = message.Name2;
                gamer1.MMR = message.MMR2;
                gamer1.UserID = message.UnitId2;
                gamer2.Name = message.Name1;
                gamer2.MMR = message.MMR1;
                gamer2.UserID = message.UnitId1;
            }

            session.ZoneScene().GetComponent<Room>().Add(gamer1);
            session.ZoneScene().GetComponent<Room>().Add(gamer2);





            Game.EventSystem.Publish(new EventType.UpdateRoom() { zoneScene = session.ZoneScene() });

        }
    }
}
