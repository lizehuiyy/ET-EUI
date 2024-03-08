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
        //洗牌
        public static void Shuffle(this DeckComponent self)
        {
            if (self.CardCount == self.TotalDeck.Count)
            {
                Random random = new Random();
                List<int> newCards = new List<int>();
                foreach (var card in self.TotalDeck)
                {
                    newCards.Insert(random.Next(newCards.Count + 1), card);
                }

                self.LibraryDeck.Clear();
                self.LibraryDeck.AddRange(newCards);
            }
        }

        //初始发牌
        public static void StartDealTo(this DeckComponent self)
        {

            for (int i = 0; i < 5; i++)
            {
                int card = self.LibraryDeck[self.LibraryDeck.Count-1];
                self.HardDeck.Add(card);
                self.LibraryDeck.Remove(card);
            }
        }

    }
}
