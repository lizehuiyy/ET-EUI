﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class UserInfo : Entity, IAwake
    {
        public int Coin;        //账号金币
        public int Gem;         //账号充值宝石
        public int Level;       //账号等级
        public int Exp;         //账号升级经验
        public int WinMatch;    //账号胜场
        public int LoseMatch;   //账号负场
        public int MMR;         //天梯积分
    }
    public class UserInfoAwakeSystem : AwakeSystem<UserInfo>
    {
        public override void Awake(UserInfo self)
        {
            self.Coin = 100;
            self.Gem = 0;
            self.Level = 1;
            self.Exp = 0;
            self.WinMatch = 0;
            self.LoseMatch = 0;
            self.MMR = 0;
        }
    }



}
