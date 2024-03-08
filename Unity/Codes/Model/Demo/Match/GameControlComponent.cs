using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public struct UseCard
    {
        public int CardId;
        public int CardPos;
    }
    public struct StageCard
    {
        public int CardId;
        public int CardPos;
        public int Fram;
        public int UseSkill;
    }


    [ComponentOf]
    public class GameControlComponent:Entity,IAwake,IDestroy
    {
        public int SelectHardCard = 0;

        public List<UseCard> UseCardList;
        public List<StageCard> StageCardList;


    }
}
