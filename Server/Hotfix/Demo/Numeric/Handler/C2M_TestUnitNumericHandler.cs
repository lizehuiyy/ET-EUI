using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET

{
    public class C2M_TestUnitNumericHandler : AMActorLocationRpcHandler<Unit,C2M_TestUnitNumeric, M2C_TestUnitNumeric>
    {
        protected override async ETTask Run(Unit unit, C2M_TestUnitNumeric request, M2C_TestUnitNumeric response, Action reply)
        {

            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            int newGold = numericComponent.GetAsInt(NumericType.Gold) + 100;
            int newExp = numericComponent.GetAsInt(NumericType.Exp) + 50;
            int newLevel = numericComponent.GetAsInt(NumericType.Level) + 1;
            Log.Debug("newGold"+ newGold+ "newExp"+ newExp+ "newLevel"+ newLevel);
            numericComponent.Set(NumericType.Gold, newGold);
            numericComponent.Set(NumericType.Exp, newExp);
            numericComponent.Set(NumericType.Level, newLevel);
            //set 数值改变 setnoevent



            reply();
            await ETTask.CompletedTask;
        }
    }
}
