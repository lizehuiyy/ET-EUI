using UnityEngine;
using UnityEngine.EventSystems;
namespace ET
{
    public class EventListener : EventTrigger
    {
        public delegate void VoidDelegate(GameObject go, BaseEventData data);

        public VoidDelegate onClick;
        public VoidDelegate onDown;
        public VoidDelegate onEnter;
        public VoidDelegate onExit;
        public VoidDelegate onUp;
        public VoidDelegate onBeginDrag;
        public VoidDelegate onDrag;
        public VoidDelegate onEndDrag;

        public VoidDelegate onSelect;
        public VoidDelegate onUpdateSelect;
        public VoidDelegate onLongPress; //长按按键


        private PointerEventData longPressEventData;
        private bool isPointDown = false;
        public float interval = 1f; //长按按键判断间隔
        public float invokeInterval = 0.2f; //长按状态方法调用间隔 
        private float lastInvokeTime; //鼠标点击下的时间
        private float timer;

        public static EventListener Get(GameObject go)
        {
            //3d 检测
            if (Camera.main)
            {
                PhysicsRaycaster raycaster = Camera.main.gameObject.GetComponent<PhysicsRaycaster>();
                if (raycaster == null)
                    raycaster = Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
            }

            //UI 检测
            EventListener listener = go.GetComponent<EventListener>();
            if (listener == null)
                listener = go.AddComponent<EventListener>();

            return listener;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (onClick != null) onClick(gameObject, eventData);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            isPointDown = true;
            lastInvokeTime = Time.time;
            longPressEventData = eventData;
            if (onDown != null) onDown(gameObject, eventData);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (onEnter != null) onEnter(gameObject, eventData);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            isPointDown = false; //鼠标移出按钮时推出长按状态
            if (onExit != null) onExit(gameObject, eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            isPointDown = false;
            if (onUp != null) onUp(gameObject, eventData);
        }


        public override void OnBeginDrag(PointerEventData eventData)
        {
            if (onBeginDrag != null) onBeginDrag(gameObject, eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (onDrag != null) onDrag(gameObject, eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            if (onEndDrag != null) onEndDrag(gameObject, eventData);
        }


        public override void OnSelect(BaseEventData eventData)
        {
            if (onSelect != null) onSelect(gameObject, eventData);
        }

        public override void OnUpdateSelected(BaseEventData eventData)
        {
            if (onUpdateSelect != null) onUpdateSelect(gameObject, eventData);
        }

        private void Update()
        {
            if (isPointDown)
            {
                if (Time.time - lastInvokeTime > interval)
                {
                    timer += Time.deltaTime;
                    if (timer > invokeInterval)
                    {
                        onLongPress.Invoke(gameObject, longPressEventData);
                        timer = 0;
                    }
                }
            }
        }
    }
}