namespace ET
{
    public enum PlayerState
    {
        Disconnect,
        Gate,
        Map,
        Game,

    }

    [ObjectSystem]

    public class PlayerSystem : AwakeSystem<Player, long, long>
    {
        public override void Awake(Player self, long accountId, long roleId)
        {
            self.Account = accountId;
            self.UnitId = roleId;
        }
    }

    public sealed class Player : Entity, IAwake<string>, IAwake<long, long>,IDestroy
    {
        public long Account { get; set; }

        public long SessionInstanceId { get; set; }
        public Session ClientSession { get; set; }

        public long UnitId { get; set; }

        public PlayerState PlayerState { get; set; }

        public long ChatInfoInstanceId { get; set; }
        public long MatchInstanceId { get; set; }


    }
}