namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        public const int ERR_NetWorkError = 200002;//网络错误
        public const int ERR_LoginInfoError = 200003;//登录信息错误
        public const int ERR_LoginInfoBlackError = 200004;//登录信息黑名单
        public const int ERR_LoginInfoPasswordError = 200005;//登录信息密码错误
        public const int ERR_AccountNameFromError = 200006;//登录信息账号格式错误
        public const int ERR_PassworkFromError = 200007;//登录信息密码格式错误
        public const int ERR_RequestRepeatedly = 200008;//多次请求服务器
        public const int ERR_GetServerInfo = 200009;//获取服务器列表
        public const int ERR_TokenError = 200010;//获取服务器Token
        public const int ERR_CreateRole = 200011;//创建人物
        public const int ERR_CreateRoleNameNull = 200013;//创建人物名字为空
        public const int ERR_CreateRoleNameSame = 200014;//创建人物名字相同
        public const int ERR_RequestSessionRepeatedly = 200015;//多次请求重复报错
        public const int ERR_GetRole = 200016;//创建人物
        public const int ERR_DeleteRole = 200017;//创建人物
        public const int ERR_RoleNotExist = 200018;//人物不存在
        public const int ERR_GetRealmKey = 200019;//GetRealm
        public const int ERR_RequestSceneTypeError = 200020;//A2R_GetRealmKey
        public const int ERR_EnterRealm = 200021;//A2R_EnterRealm
        public const int ERR_ConnectGateKeyError = 200022;//链接GATE 错误
        public const int ERR_OtherAccountLogin = 200023;//其他玩家登录
        public const int ERR_SessionPlayerError = 200024;//EnterGame session error
        public const int ERR_NonePlayerError = 200025;//EnterGame 没有玩家
        public const int ERR_PlayerSessionError = 200026;//EnterGame session error
        public const int ERR_SessionError = 200027;//已经进入游戏逻辑服
        public const int ERR_EnterGameError = 200028;//已经进入游戏逻辑服
        public const int ERR_ReEnterGameError = 200029;//已经进入游戏逻辑服
        public const int ERR_ReEnterGameError2 = 200030;//已经进入游戏逻辑服
        public const int ERR_TestUpdateNumeric = 200031;//
        public const int ERR_TestBtnAddCoin = 200032;//
        public const int ERR_CoinNumNotExist = 200033;//
        public const int ERR_ChatMessageEmpty = 200034;//发送聊天内容为空
    }
}