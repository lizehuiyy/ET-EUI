using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{

    public enum AccountType
    {
        General = 0,
        BlackList = 1,


    }
    public class Account : Entity, IAwake
    {
        public string AccountName;
        public string Password;
        public long CreateTime; //创建时间
        public int AccountType; //账号类型
        //public int Coin;        //账号金币
        //public int Gem;         //账号充值宝石
        //public int Level;       //账号等级
        //public int Exp;         //账号升级经验
        //public int WinMatch;    //账号胜场
        //public int LoseMatch;   //账号负场
        //public int MMR;         //天梯积分
    }
}
