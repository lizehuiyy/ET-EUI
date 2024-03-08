using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Scene))]

    public class HeroInfoComponent : Entity, IAwake, IDestroy
    {
        public int SelectHero = 0;
        public int DragCardId;
        public List<int> MyCardNum;


    }
}
