using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf]
    public class DeckComponent:Entity,IAwake,IDestroy
    {
        public int CardCount = 30;
        //所有牌库
        public List<int> TotalDeck;
        //手牌
        public List<int> HardDeck;
        //牌库
        public List<int> LibraryDeck;
        //场上的
        public List<int> FieldDeck;



    }
}
