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
    }
}