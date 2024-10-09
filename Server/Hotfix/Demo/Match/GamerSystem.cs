using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class GamerDestroy : DestroySystem<Gamer>
    {
        public override void Destroy(Gamer self)
        {
            self.UserID = 0;
            self.GActorID = 0;
            self.CActorID = 0;
            self.GateSessionActorId = 0;
            self.Name = string.Empty;
        }
    }



    public static class GamerSystem
    {


    }
}
