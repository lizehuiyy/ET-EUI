using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    
    [ComponentOf]
    public class HeroInfoComponent : Entity, IAwake, IDestroy, IUnitCache
    {
        public List<int> MyCardNum;
    }
}
