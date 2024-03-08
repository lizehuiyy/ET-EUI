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

        public static void FromMessage(this Gamer self, MatchProto matchProto)
        {
            self.Id = matchProto.ID;
            self.UserID = matchProto.UnitId;
            self.Name = matchProto.Name;
            self.MMR = matchProto.MMR;
        }

        public static MatchProto ToMessage(this Gamer self)
        {
            MatchProto matchProto = new MatchProto();
            matchProto.ID = self.Id;
            matchProto.UnitId = self.UserID;
            matchProto.Name = self.Name;
            matchProto.MMR = self.MMR;
            return matchProto;
        }





    }
}
