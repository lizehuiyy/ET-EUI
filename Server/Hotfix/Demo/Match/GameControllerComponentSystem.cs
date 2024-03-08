using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class GameControllerComponentAwakeSystem : AwakeSystem<GameControllerComponent>
    {
        public override void Awake(GameControllerComponent self)
        {
            
        }
    }
    [FriendClassAttribute(typeof(ET.Room))]
    [FriendClassAttribute(typeof(ET.Gamer))]
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public static class GameControllerComponentSystem
    {
        public static void StartGame(this GameControllerComponent self)
        {

            Room room = self.GetParent<Room>();
            Random rnd = new Random();
            

            foreach (var gamer in room.gamers)
            {
                DeckComponent deckComponent = gamer.GetComponent<DeckComponent>();
                if (deckComponent.TotalDeck.Count != deckComponent.CardCount)
                {
                    Log.Error("牌库不为30");
                    return;
                }
                deckComponent.Shuffle();
                deckComponent.StartDealTo();
            }
            


        }
    }
}
