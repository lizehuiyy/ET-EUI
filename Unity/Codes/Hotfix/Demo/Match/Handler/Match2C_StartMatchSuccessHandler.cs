using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public class Match2C_StartMatchSuccessHandler : AMHandler<Match2C_StartMatchSuccess>
    {
        protected override void Run(Session session, Match2C_StartMatchSuccess message)
        {
            Gamer gamer1 = session.ZoneScene().GetComponent<Room>().AddChild<Gamer>(true);
            Gamer gamer2 = session.ZoneScene().GetComponent<Room>().AddChild<Gamer>(true);

            session.ZoneScene().GetComponent<Room>().AddComponent<GameControlComponent>();

            DeckComponent deckComponent1 = gamer1.AddComponent<DeckComponent>();
            DeckComponent deckComponent2 = gamer2.AddComponent<DeckComponent>();
            long myid = session.ZoneScene().GetComponent<PlayerComponent>().MyId;
            foreach (var proto in message.Proto)
            {
                if (proto.UnitId == myid)
                {
                    gamer1.Name = proto.Name;
                    gamer1.MMR = proto.MMR;
                    gamer1.UserID = proto.UnitId;
                    deckComponent1.TowerHP = proto.TowerHp;
                    deckComponent1.Coin = proto.Coin;
                    
                }
                else if (proto.UnitId != myid)
                {
                    gamer2.Name = proto.Name;
                    gamer2.MMR = proto.MMR;
                    gamer2.UserID = proto.UnitId;
                    deckComponent2.TowerHP = proto.TowerHp;
                    deckComponent2.Coin = proto.Coin;
                    for (int i = 0; i < proto.CardNum; i++)
                    {
                        NotStageCard card = new NotStageCard();
                        card.CardId = -1;
                        card.Star = -1;
                        deckComponent2.HardDeck.Add(card);
                    }
                }
            }
            deckComponent1.HardDeck = message.HeroCardList;



            session.ZoneScene().GetComponent<Room>().Add(gamer1);
            session.ZoneScene().GetComponent<Room>().Add(gamer2);





            Game.EventSystem.Publish(new EventType.UpdateRoom() { zoneScene = session.ZoneScene() });

        }
    }
}
