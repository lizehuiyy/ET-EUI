using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.Gamer))]
    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public class C2Match_StartMatchHandler : AMActorRpcHandler<Gamer, C2Match_StartMatch, Match2C_StartMatch>
    {
        protected override async ETTask Run(Gamer gamer, C2Match_StartMatch request, Match2C_StartMatch response, Action reply)
        {



            //ChatInfoUnitComponent chatInfoUnitComponent = chatInfoUnit.DomainScene().GetComponent<ChatInfoUnitComponent>();
            LandMatchComponent matchComponent = gamer.DomainScene().GetComponent<LandMatchComponent>();

            //Gamer gamer = matchComponent.GetChild<Gamer>(unit.Id);
            DeckComponent deckComponent = gamer.AddComponent<DeckComponent>();
            deckComponent.TotalDeck = request.HeroCardList;


            Room room = matchComponent.Get(gamer.UserID);

            if (room != null && !room.IsDisposed)
            {






            }
            else
            {
                matchComponent.AddGamerToMatchingQueue(gamer);

            }


            reply();
            await ETTask.CompletedTask;
        }
    }
}
