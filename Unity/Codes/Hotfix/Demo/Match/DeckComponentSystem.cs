using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class DeckComponentAwakeSystem : AwakeSystem<DeckComponent>
    {
        public override void Awake(DeckComponent self)
        {
            self.TotalDeck = new List<int>();
            self.HardDeck = new List<int>();
            self.LibraryDeck = new List<int>();
            self.FieldDeck = new List<int>();
        }
    }



    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public static class DeckComponentSystem
    {

        

    }
}
