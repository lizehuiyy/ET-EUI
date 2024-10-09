using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class GameControlComponentSystem
    {
        public static void XXXXX(this GameControlComponent self)
        {

        

        }

    }

    public class GameControlComponentDestroySystem : DestroySystem<GameControlComponent>
    {
        public override void Destroy(GameControlComponent self)
        {


        }
    }
    public class GameControlComponentAwakeSystem : AwakeSystem<GameControlComponent>
    {
        public override void Awake(GameControlComponent self)
        {
            self.UseCardList = new List<UseCardProto>();
            self.StageCardList = new List<StageCardProto>();
            self.PlayerRoundResultList = new List<PlayerRoundResult>();
        }
    }
}
