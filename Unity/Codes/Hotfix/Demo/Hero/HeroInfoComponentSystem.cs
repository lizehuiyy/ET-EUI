using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{

    public class HeroInfoComponentSystemAwakeSystem : AwakeSystem<HeroInfoComponent>
    {
        public override void Awake(HeroInfoComponent self)
        {
            self.MyCardNum = new List<int>();
        }
    }
    public static class HeroInfoComponentSystem
    {
    }
}
