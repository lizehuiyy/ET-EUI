using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterOpcode.C2M_TestRequest)]
	[ProtoContract]
	public partial class C2M_TestRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string request { get; set; }

	}

	[Message(OuterOpcode.M2C_TestResponse)]
	[ProtoContract]
	public partial class M2C_TestResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string response { get; set; }

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterOpcode.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int MapIndex { get; set; }

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterOpcode.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

// 自己unitId
		[ProtoMember(4)]
		public long MyId { get; set; }

	}

	[Message(OuterOpcode.MoveInfo)]
	[ProtoContract]
	public partial class MoveInfo: Object
	{
		[ProtoMember(1)]
		public List<float> X = new List<float>();

		[ProtoMember(2)]
		public List<float> Y = new List<float>();

		[ProtoMember(3)]
		public List<float> Z = new List<float>();

		[ProtoMember(4)]
		public float A { get; set; }

		[ProtoMember(5)]
		public float B { get; set; }

		[ProtoMember(6)]
		public float C { get; set; }

		[ProtoMember(7)]
		public float W { get; set; }

		[ProtoMember(8)]
		public int TurnSpeed { get; set; }

	}

	[Message(OuterOpcode.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo: Object
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int ConfigId { get; set; }

		[ProtoMember(3)]
		public int Type { get; set; }

		[ProtoMember(4)]
		public float X { get; set; }

		[ProtoMember(5)]
		public float Y { get; set; }

		[ProtoMember(6)]
		public float Z { get; set; }

		[ProtoMember(7)]
		public float ForwardX { get; set; }

		[ProtoMember(8)]
		public float ForwardY { get; set; }

		[ProtoMember(9)]
		public float ForwardZ { get; set; }

		[ProtoMember(10)]
		public List<int> Ks = new List<int>();

		[ProtoMember(11)]
		public List<long> Vs = new List<long>();

		[ProtoMember(12)]
		public MoveInfo MoveInfo { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateUnits)]
	[ProtoContract]
	public partial class M2C_CreateUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.M2C_CreateMyUnit)]
	[ProtoContract]
	public partial class M2C_CreateMyUnit: Object, IActorMessage
	{
		[ProtoMember(1)]
		public UnitInfo Unit { get; set; }

	}

	[Message(OuterOpcode.M2C_StartSceneChange)]
	[ProtoContract]
	public partial class M2C_StartSceneChange: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long SceneInstanceId { get; set; }

		[ProtoMember(2)]
		public string SceneName { get; set; }

	}

	[Message(OuterOpcode.M2C_RemoveUnits)]
	[ProtoContract]
	public partial class M2C_RemoveUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<long> Units = new List<long>();

	}

	[Message(OuterOpcode.C2M_PathfindingResult)]
	[ProtoContract]
	public partial class C2M_PathfindingResult: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.C2M_Stop)]
	[ProtoContract]
	public partial class C2M_Stop: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	[ProtoContract]
	public partial class M2C_PathfindingResult: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

		[ProtoMember(5)]
		public List<float> Xs = new List<float>();

		[ProtoMember(6)]
		public List<float> Ys = new List<float>();

		[ProtoMember(7)]
		public List<float> Zs = new List<float>();

	}

	[Message(OuterOpcode.M2C_Stop)]
	[ProtoContract]
	public partial class M2C_Stop: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public float X { get; set; }

		[ProtoMember(4)]
		public float Y { get; set; }

		[ProtoMember(5)]
		public float Z { get; set; }

		[ProtoMember(6)]
		public float A { get; set; }

		[ProtoMember(7)]
		public float B { get; set; }

		[ProtoMember(8)]
		public float C { get; set; }

		[ProtoMember(9)]
		public float W { get; set; }

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterOpcode.C2G_Ping)]
	[ProtoContract]
	public partial class C2G_Ping: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_Ping)]
	[ProtoContract]
	public partial class G2C_Ping: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long Time { get; set; }

	}

	[Message(OuterOpcode.G2C_Test)]
	[ProtoContract]
	public partial class G2C_Test: Object, IMessage
	{
	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterOpcode.C2M_Reload)]
	[ProtoContract]
	public partial class C2M_Reload: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.M2C_Reload)]
	[ProtoContract]
	public partial class M2C_Reload: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterOpcode.C2R_Login)]
	[ProtoContract]
	public partial class C2R_Login: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.R2C_Login)]
	[ProtoContract]
	public partial class R2C_Login: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Address { get; set; }

		[ProtoMember(2)]
		public long Key { get; set; }

		[ProtoMember(3)]
		public long GateId { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterOpcode.C2G_LoginGate)]
	[ProtoContract]
	public partial class C2G_LoginGate: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long GateId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGate)]
	[ProtoContract]
	public partial class G2C_LoginGate: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	[ProtoContract]
	public partial class G2C_TestHotfixMessage: Object, IMessage
	{
		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterOpcode.C2M_TestRobotCase)]
	[ProtoContract]
	public partial class C2M_TestRobotCase: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[Message(OuterOpcode.M2C_TestRobotCase)]
	[ProtoContract]
	public partial class M2C_TestRobotCase: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterOpcode.C2M_TransferMap)]
	[ProtoContract]
	public partial class C2M_TransferMap: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_TransferMap)]
	[ProtoContract]
	public partial class M2C_TransferMap: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(A2C_LoginAccount))]
	[Message(OuterOpcode.C2A_LoginAccount)]
	[ProtoContract]
	public partial class C2A_LoginAccount: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string AccountName { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.A2C_LoginAccount)]
	[ProtoContract]
	public partial class A2C_LoginAccount: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.A2C_Disconnect)]
	[ProtoContract]
	public partial class A2C_Disconnect: Object, IMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

	}

	[Message(OuterOpcode.ServerInfoProto)]
	[ProtoContract]
	public partial class ServerInfoProto: Object
	{
		[ProtoMember(1)]
		public int Id { get; set; }

		[ProtoMember(2)]
		public int Status { get; set; }

		[ProtoMember(3)]
		public string ServerName { get; set; }

	}

	[ResponseType(nameof(A2C_GetServerInfo))]
	[Message(OuterOpcode.C2A_GetServerInfo)]
	[ProtoContract]
	public partial class C2A_GetServerInfo: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetServerInfo)]
	[ProtoContract]
	public partial class A2C_GetServerInfo: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<ServerInfoProto> ServerInfoList = new List<ServerInfoProto>();

	}

	[Message(OuterOpcode.RoleInfoProto)]
	[ProtoContract]
	public partial class RoleInfoProto: Object
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int State { get; set; }

		[ProtoMember(4)]
		public long AccountId { get; set; }

		[ProtoMember(5)]
		public long LastLoginTime { get; set; }

		[ProtoMember(6)]
		public long CreateTime { get; set; }

		[ProtoMember(7)]
		public int ServerId { get; set; }

		[ProtoMember(8)]
		public long Coin { get; set; }

		[ProtoMember(9)]
		public long Gem { get; set; }

		[ProtoMember(10)]
		public int Level { get; set; }

		[ProtoMember(11)]
		public int Exp { get; set; }

		[ProtoMember(12)]
		public int WinMatch { get; set; }

		[ProtoMember(13)]
		public int LoseMatch { get; set; }

		[ProtoMember(14)]
		public int MMR { get; set; }

	}

	[ResponseType(nameof(A2C_CreateRole))]
	[Message(OuterOpcode.C2A_CreateRole)]
	[ProtoContract]
	public partial class C2A_CreateRole: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public string Name { get; set; }

		[ProtoMember(4)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_CreateRole)]
	[ProtoContract]
	public partial class A2C_CreateRole: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public RoleInfoProto RoleInfo { get; set; }

	}

	[ResponseType(nameof(A2C_GetRole))]
	[Message(OuterOpcode.C2A_GetRole)]
	[ProtoContract]
	public partial class C2A_GetRole: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(4)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetRole)]
	[ProtoContract]
	public partial class A2C_GetRole: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<RoleInfoProto> RoleInfo = new List<RoleInfoProto>();

	}

	[ResponseType(nameof(A2C_DeleteRole))]
	[Message(OuterOpcode.C2A_DeleteRole)]
	[ProtoContract]
	public partial class C2A_DeleteRole: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

		[ProtoMember(3)]
		public long RoleInfoId { get; set; }

		[ProtoMember(4)]
		public int ServerId { get; set; }

	}

	[Message(OuterOpcode.A2C_DeleteRole)]
	[ProtoContract]
	public partial class A2C_DeleteRole: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long DeleteRoleInfoId { get; set; }

	}

	[ResponseType(nameof(A2C_GetRealmKey))]
	[Message(OuterOpcode.C2A_GetRealmKey)]
	[ProtoContract]
	public partial class C2A_GetRealmKey: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.A2C_GetRealmKey)]
	[ProtoContract]
	public partial class A2C_GetRealmKey: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string RealmKey { get; set; }

		[ProtoMember(2)]
		public string RealmAddress { get; set; }

	}

	[ResponseType(nameof(R2C_LoginRealm))]
	[Message(OuterOpcode.C2R_LoginRealm)]
	[ProtoContract]
	public partial class C2R_LoginRealm: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long AccountId { get; set; }

		[ProtoMember(2)]
		public string RealmTokenKey { get; set; }

	}

	[Message(OuterOpcode.R2C_LoginRealm)]
	[ProtoContract]
	public partial class R2C_LoginRealm: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string GateSessionKey { get; set; }

		[ProtoMember(2)]
		public string GateAddress { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGameGate))]
	[Message(OuterOpcode.C2G_LoginGameGate)]
	[ProtoContract]
	public partial class C2G_LoginGameGate: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Key { get; set; }

		[ProtoMember(2)]
		public long RoleId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGameGate)]
	[ProtoContract]
	public partial class G2C_LoginGameGate: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGameGate))]
	[Message(OuterOpcode.C2G_EnterGame)]
	[ProtoContract]
	public partial class C2G_EnterGame: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterGame)]
	[ProtoContract]
	public partial class G2C_EnterGame: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public long MyId { get; set; }

		[ProtoMember(5)]
		public List<int> HeroCardList = new List<int>();

	}

	[Message(OuterOpcode.M2C_NoticeUnitNumeric)]
	[ProtoContract]
	public partial class M2C_NoticeUnitNumeric: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int NumericType { get; set; }

		[ProtoMember(4)]
		public long NewValue { get; set; }

	}

	[ResponseType(nameof(M2C_TestUnitNumeric))]
	[Message(OuterOpcode.C2M_TestUnitNumeric)]
	[ProtoContract]
	public partial class C2M_TestUnitNumeric: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_TestUnitNumeric)]
	[ProtoContract]
	public partial class M2C_TestUnitNumeric: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(M2C_TestBtnAddCoin))]
	[Message(OuterOpcode.C2M_TestBtnAddCoin)]
	[ProtoContract]
	public partial class C2M_TestBtnAddCoin: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int CoinNum { get; set; }

	}

	[Message(OuterOpcode.M2C_TestBtnAddCoin)]
	[ProtoContract]
	public partial class M2C_TestBtnAddCoin: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(Chat2C_SendChatInfo))]
	[Message(OuterOpcode.C2Chat_SendChatInfo)]
	[ProtoContract]
	public partial class C2Chat_SendChatInfo: Object, IActorChatInfoRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string ChatMessage { get; set; }

	}

	[Message(OuterOpcode.Chat2C_SendChatInfo)]
	[ProtoContract]
	public partial class Chat2C_SendChatInfo: Object, IActorChatInfoResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.Chat2C_NoticeChatInfo)]
	[ProtoContract]
	public partial class Chat2C_NoticeChatInfo: Object, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public string ChatMessage { get; set; }

	}

	[Message(OuterOpcode.RankInfoProto)]
	[ProtoContract]
	public partial class RankInfoProto: Object
	{
		[ProtoMember(1)]
		public long ID { get; set; }

		[ProtoMember(2)]
		public long UnitId { get; set; }

		[ProtoMember(3)]
		public string Name { get; set; }

		[ProtoMember(4)]
		public int MMR { get; set; }

	}

	[ResponseType(nameof(Rank2C_GetRankInfo))]
	[Message(OuterOpcode.C2Rank_GetRankInfo)]
	[ProtoContract]
	public partial class C2Rank_GetRankInfo: Object, IActorRankInfoRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.Rank2C_GetRankInfo)]
	[ProtoContract]
	public partial class Rank2C_GetRankInfo: Object, IActorRankInfoResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<RankInfoProto> RankInfoProtoList = new List<RankInfoProto>();

	}

	[ResponseType(nameof(Match2C_StartMatch))]
	[Message(OuterOpcode.C2Match_StartMatch)]
	[ProtoContract]
	public partial class C2Match_StartMatch: Object, IActorMatchRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public List<int> HeroCardList = new List<int>();

	}

	[Message(OuterOpcode.Match2C_StartMatch)]
	[ProtoContract]
	public partial class Match2C_StartMatch: Object, IActorMatchResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.MatchSuccessProto)]
	[ProtoContract]
	public partial class MatchSuccessProto: Object
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int MMR { get; set; }

		[ProtoMember(4)]
		public int CardNum { get; set; }

		[ProtoMember(5)]
		public int Coin { get; set; }

		[ProtoMember(6)]
		public int TowerHp { get; set; }

	}

	[Message(OuterOpcode.NotStageCard)]
	[ProtoContract]
	public partial class NotStageCard: Object
	{
		[ProtoMember(1)]
		public int CardId { get; set; }

		[ProtoMember(2)]
		public int Star { get; set; }

		[ProtoMember(3)]
		public int CardPos { get; set; }

	}

	[Message(OuterOpcode.Match2C_StartMatchSuccess)]
	[ProtoContract]
	public partial class Match2C_StartMatchSuccess: Object, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<MatchSuccessProto> Proto = new List<MatchSuccessProto>();

		[ProtoMember(2)]
		public List<NotStageCard> HeroCardList = new List<NotStageCard>();

	}

	[ResponseType(nameof(G2C_SaveCard))]
	[Message(OuterOpcode.C2G_SaveCard)]
	[ProtoContract]
	public partial class C2G_SaveCard: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public List<int> HeroCardList = new List<int>();

	}

	[Message(OuterOpcode.G2C_SaveCard)]
	[ProtoContract]
	public partial class G2C_SaveCard: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.UseCardProto)]
	[ProtoContract]
	public partial class UseCardProto: Object
	{
		[ProtoMember(1)]
		public int CardId { get; set; }

		[ProtoMember(2)]
		public int CardPos { get; set; }

		[ProtoMember(3)]
		public int CardStar { get; set; }

		[ProtoMember(4)]
		public int SelectCardPos { get; set; }

		[ProtoMember(5)]
		public int SelectCardPlayer { get; set; }

		[ProtoMember(6)]
		public int SelectCardId { get; set; }

		[ProtoMember(7)]
		public int SelectSkill { get; set; }

		[ProtoMember(8)]
		public List<SkillCard> CardList = new List<SkillCard>();

	}

	[Message(OuterOpcode.SkillCard)]
	[ProtoContract]
	public partial class SkillCard: Object
	{
		[ProtoMember(1)]
		public int CardId { get; set; }

		[ProtoMember(2)]
		public int CardPos { get; set; }

		[ProtoMember(3)]
		public int CardStar { get; set; }

		[ProtoMember(4)]
		public int CardType { get; set; }

		[ProtoMember(5)]
		public int CardAttack { get; set; }

		[ProtoMember(6)]
		public int CardLife { get; set; }

	}

	[Message(OuterOpcode.StageCardProto)]
	[ProtoContract]
	public partial class StageCardProto: Object
	{
		[ProtoMember(1)]
		public int CardId { get; set; }

		[ProtoMember(2)]
		public int CardPos { get; set; }

		[ProtoMember(3)]
		public int Fram { get; set; }

		[ProtoMember(4)]
		public int UseSkill { get; set; }

		[ProtoMember(5)]
		public int UseSkill2 { get; set; }

		[ProtoMember(6)]
		public int UpStar { get; set; }

	}

	[ResponseType(nameof(Match2C_EndRoundMatch))]
	[Message(OuterOpcode.C2Match_EndRoundMatch)]
	[ProtoContract]
	public partial class C2Match_EndRoundMatch: Object, IActorMatchRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public List<UseCardProto> UseCardList = new List<UseCardProto>();

		[ProtoMember(3)]
		public List<StageCardProto> StageCardList = new List<StageCardProto>();

	}

	[Message(OuterOpcode.Match2C_EndRoundMatch)]
	[ProtoContract]
	public partial class Match2C_EndRoundMatch: Object, IActorMatchResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[Message(OuterOpcode.BuffProto)]
	[ProtoContract]
	public partial class BuffProto: Object
	{
		[ProtoMember(1)]
		public int BuffCardId { get; set; }

		[ProtoMember(2)]
		public int BuffCardStar { get; set; }

		[ProtoMember(3)]
		public int BuffNum { get; set; }

	}

	[Message(OuterOpcode.CardResult)]
	[ProtoContract]
	public partial class CardResult: Object
	{
		[ProtoMember(1)]
		public int CardId { get; set; }

		[ProtoMember(2)]
		public int CardPos { get; set; }

		[ProtoMember(3)]
		public int CardStar { get; set; }

		[ProtoMember(4)]
		public int TotalLife { get; set; }

		[ProtoMember(5)]
		public int TotalAttack { get; set; }

		[ProtoMember(6)]
		public int Armor { get; set; }

		[ProtoMember(7)]
		public int Mockery { get; set; }

		[ProtoMember(8)]
		public int DisarmRound { get; set; }

		[ProtoMember(9)]
		public int VertigoRound { get; set; }

		[ProtoMember(10)]
		public List<int> AttackPos = new List<int>();

		[ProtoMember(11)]
		public List<int> AttackDamage = new List<int>();

		[ProtoMember(12)]
		public List<int> ReflexDamage = new List<int>();

		[ProtoMember(13)]
		public List<int> Crit = new List<int>();

		[ProtoMember(14)]
		public List<int> ReCrit = new List<int>();

		[ProtoMember(15)]
		public List<int> Dodge = new List<int>();

		[ProtoMember(16)]
		public List<int> Blind = new List<int>();

		[ProtoMember(17)]
		public List<int> Reset = new List<int>();

		[ProtoMember(18)]
		public List<int> UseSkill = new List<int>();

		[ProtoMember(19)]
		public List<int> UseSkillDmg = new List<int>();

		[ProtoMember(20)]
		public List<BuffProto> BuffList = new List<BuffProto>();

		[ProtoMember(21)]
		public int UseSkillCD { get; set; }

		[ProtoMember(22)]
		public List<SkillCard> CardList = new List<SkillCard>();

	}

	[Message(OuterOpcode.PlayerRoundResult)]
	[ProtoContract]
	public partial class PlayerRoundResult: Object
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public List<CardResult> CardResultList = new List<CardResult>();

		[ProtoMember(3)]
		public int TowerHp { get; set; }

		[ProtoMember(4)]
		public List<UseCardProto> useCardList = new List<UseCardProto>();

		[ProtoMember(5)]
		public int Coin { get; set; }

		[ProtoMember(6)]
		public int winorlose { get; set; }

		[ProtoMember(7)]
		public int Round { get; set; }

	}

	[Message(OuterOpcode.Match2C_EndRoundResponse)]
	[ProtoContract]
	public partial class Match2C_EndRoundResponse: Object, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<PlayerRoundResult> PlayerRoundResultList = new List<PlayerRoundResult>();

	}

	[ResponseType(nameof(Match2C_GGMatch))]
	[Message(OuterOpcode.C2Match_GGMatch)]
	[ProtoContract]
	public partial class C2Match_GGMatch: Object, IActorMatchRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterOpcode.Match2C_GGMatch)]
	[ProtoContract]
	public partial class Match2C_GGMatch: Object, IActorMatchResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

}
