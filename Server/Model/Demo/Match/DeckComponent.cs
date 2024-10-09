using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{



    public class StageCardState:Entity,IAwake,IDestroy
    {
        public int CardId { get; set; }//场上卡ID
        public int CopyCardId { get; set; }//场上卡ID
        public int BuffLife { get; set; }//受到BUFF生命
        public int BuffAttack { get; set; }//受到BUFF攻击
        public int DeBuffLife { get; set; }//受到BUFF生命
        public int DeBuffAttack { get; set; }//受到BUFF攻击
        public int BaseLife { get; set; }//基础生命
        public int BaseAttack { get; set; }//基础攻击
        public int IsByLifeBuff { get; set; }//是否受到buff影响  1为buff不影响 默认0为影响
        public int IsByLifeDebuff { get; set; }//是否受到buff影响

        public int IsByAttackBuff { get; set; }//是否受到buff影响
        public int IsByAttackDebuff { get; set; }//是否受到buff影响
        public int TotalLife { get; set; }//总计生命
        public int TotalAttack { get; set; }//总计攻击

        public int MaxLife { get; set; }//总计生命
        public int MaxAttack { get; set; }//总计攻击

        public int Pos { get; set; } //位置
        public int Position { get; set; } //几号位

        public int StartStar { get; set; } //上场时星级
        public int Star { get; set; } //星级
        public int FramSpeed { get; set; } //打钱效率


        //本回合要干的事情

        public int ReAttackNum { get; set; }  //收到攻击次数
        public int Fantasy { get; set; }  //幻想
        public int Fram { get; set; }  //打钱
        public int IsUseSkill { get; set; }//是否可以使用技能
        public int UseSkill { get; set; }//使用技能
        public int UseSkill2 { get; set; }//使用技能
        public int UseSkillCd { get; set; }//使用技能CD
        public int UpStar { get; set; }//升星

        public int NewUp { get; set; }  //是否是新上场的


        //状态 回合数量
        public int Disarm { get; set; }  //缴械
        public int Vertigo { get; set; }  //眩晕
        public int Silent { get; set; }  //沉默
        public int Immune { get; set; }  //免疫
        public int NoDead { get; set; }  //免死
        public int Offset { get; set; }  //抵消一次伤害 折光


        public int AttackNum { get; set; }  //攻击目标数量
        public int AttackFault { get; set; }//攻击失误概率
       
        public int Mockery { get; set; }//嘲讽
        public int Round { get; set; }//上场轮次

        public int Dodge { get; set; } //闪避
        public int DefinitelyHit { get; set; }//必中
        public int Armor { get; set; }//护甲
        public int SuchBlood { get; set; }//吸血
        public float ReflexDamage { get; set; }//反射伤害
        public int Crit { get; set; }//暴击率
        public int CritDamage { get; set; }//暴击伤害
        public int ReCrit { get; set; }//受到的暴击率
        public int ReCritDamage { get; set; }//受到的暴击伤害

        public int Blinding { get; set; }//致盲 回合
        public int Blind { get; set; }//致盲 概率
        public int DeadCardId { get; set; }//受到亡语的buff卡片ID
        public int DeBuffToYYF { get; set; }//受到团战魔术师Buff
        public int BuffToEGM { get; set; }//受到EGMBuff
        public int BuffToTempRound { get; set; }//临时增益回合数量
        public float ReDamage { get; set; }//受到额外伤害
        public Dictionary<int, int> BuffList { get; set; }//buffList

        public StageCardState()
        {
            BuffList = new Dictionary<int, int>();

           
        }



    }


    [ComponentOf]
    public class DeckComponent:Entity,IAwake,IDestroy
    {
        public int CardCount = 30;
        //所有牌库
        public List<int> TotalDeck;
        //手牌
        public List<NotStageCard> HardDeck;
        //牌库
        public List<NotStageCard> LibraryDeck;
        //场上的
        public List<StageCardState> StageDeck;
        //塔血量
        public int TowerHP ;
        //金币
        public int Coin;
        //等级
        public int Level;
        //经验
        public int Exp;
        //每回合结果
        public PlayerRoundResult playerRoundResult;

       



    }
}
