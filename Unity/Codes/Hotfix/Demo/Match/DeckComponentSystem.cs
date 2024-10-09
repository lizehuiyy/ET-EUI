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
            self.HardDeck = new List<NotStageCard>();
            self.LibraryDeck = new List<int>();
            self.FieldDeck = new List<int>();
            self.StageDeck = new List<StageCardState>();
            StageCardState stageCardState = new StageCardState();
            for (int i = 0; i < 7; i++)
            {

                self.StageDeck.Add(stageCardState);
            }
            self.Level = 1;
            self.Exp = 0;
        }
    }



    [FriendClassAttribute(typeof(ET.DeckComponent))]
    public static class DeckComponentSystem
    {
        public static void UpdateStageDeck(this DeckComponent self)
        { 
        
        
        
        }

        public static int FindEmptyStageDeck(this DeckComponent self)
        {
            for (int i = 1; i < 6; i++)
            {

                if (self.StageDeck[i].CardId == 0)
                {
                    return i;
                }

            }
            return 0;
        }
    }
}
