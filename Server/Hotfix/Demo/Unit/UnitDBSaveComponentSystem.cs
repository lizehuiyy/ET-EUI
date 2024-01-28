using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class UnitDBSaveComponentAwakeSystem : AwakeSystem<UnitDBSaveComponent>
    {
        public override void Awake(UnitDBSaveComponent self)
        {
            self.Timer = TimerComponent.Instance.NewRepeatedTimer(10000, TimerType.SaveChangeDBData, self);
        }
    }

    public class UnitDBSaveComponentDestroySystem : DestroySystem<UnitDBSaveComponent>
    {
        public override void Destroy(UnitDBSaveComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    public class UnitAddComponentSystem : AddComponentSystem<Unit>
    {
        public override void AddComponent(Unit self, Entity component)
        {
            Type type = component.GetType();
            if (!(typeof(IUnitCache).IsAssignableFrom(type)))
            {
                return;
            }
            self.GetComponent<UnitDBSaveComponent>()?.AddChange(type);
        }
    }

    public class UnitGetComponentSystem : GetComponentSystem<Unit>
    {
        public override void GetComponent(Unit self, Entity component)
        {
            Type type = component.GetType();
            if (!(typeof(IUnitCache).IsAssignableFrom(type)))
            {
                return;
            }
            self.GetComponent<UnitDBSaveComponent>()?.AddChange(type);
        }
    }




    public static class UnitDBSaveComponentSystem
    {
        public static void AddChange(this UnitDBSaveComponent self, Type type)
        {
            self.EntityChangeTypeSet.Add(type);

        }

        public static void SaveChange(this UnitDBSaveComponent self)
        {
            if (self.EntityChangeTypeSet.Count <= 0)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();

            Other2UnitCache_AddOrUpdateUnit message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = unit.Id, };
            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(MongoHelper.ToBson(unit));

            foreach (Type type in self.EntityChangeTypeSet)
            {
                Entity entity = unit.GetComponent(type);
                if (entity == null || entity.IsDisposed)
                {
                    continue;
                }

                Log.Debug("开始保存变化部分的Entity数据" + type.FullName);
                message.EntityTypes.Add(type.FullName);
                message.EntityBytes.Add(MongoHelper.ToBson(entity));

            }
            self.EntityChangeTypeSet.Clear();
            MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(unit.Id).InstanceId, message).Coroutine();



        }




    }




    [Timer(TimerType.SaveChangeDBData)]
    public class UnitDBSaveComponentTimer : ATimer<UnitDBSaveComponent>
    {
        public override void Run(UnitDBSaveComponent self)
        {
            try
            {
                if (self.IsDisposed || self.Parent == null)
                {
                    return;
                }

                if (self.DomainScene() == null)
                {
                    return;
                }

                self?.SaveChange();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());

            }
        }
    }
}
