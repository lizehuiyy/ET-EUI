using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class NumericHelp
    {
        public static async ETTask<int> TestUpdateNumeric(Scene zonescene)
        {
            M2C_TestUnitNumeric m2C_TestUnitNumeric = null;
            try
            {
                m2C_TestUnitNumeric = (M2C_TestUnitNumeric)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2M_TestUnitNumeric() { });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_TestUpdateNumeric;
            }
            if (m2C_TestUnitNumeric.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2C_TestUnitNumeric.Error.ToString());
                return m2C_TestUnitNumeric.Error;
            }


            return ErrorCode.ERR_Success;
        }


        public static async ETTask<int> TestBtn(Scene zonescene)
        {
            M2C_TestBtnAddCoin m2C_TestBtnAddCoin = null;

            try
            {
                m2C_TestBtnAddCoin = (M2C_TestBtnAddCoin)await zonescene.GetComponent<SessionComponent>().Session.Call(new C2M_TestBtnAddCoin() { CoinNum = 1 });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_TestBtnAddCoin;
            }
            if (m2C_TestBtnAddCoin.Error != ErrorCode.ERR_Success)
            {
                Log.Error(m2C_TestBtnAddCoin.Error.ToString());
                return m2C_TestBtnAddCoin.Error;
            }


            return ErrorCode.ERR_Success;
        }


    }
}
