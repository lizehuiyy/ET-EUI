using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRoom :Entity,IAwake,IUILogic,IDestroy
	{

		public DlgRoomViewComponent View { get => this.Parent.GetComponent<DlgRoomViewComponent>();}

        public Dictionary<int, Scroll_Item_hardhero> ScrollPlayer1HardDic;

        public Dictionary<int, Scroll_Item_backhero> ScrollPlayer2HardDic;

        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList1;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList2;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList3;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList4;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList5;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList6;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList7;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList8;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList9;
        public Dictionary<int, Scroll_Item_buff> ScrollCardBuffDicList10;

        public List<GameObject> HeroStageCard;
        public List<LoopVerticalScrollRect> HeroScrollBuff;

        public List<GameObject> Player1CardLibraryItem;
        public List<GameObject> Player2CardLibraryItem;

        public List<GameObject> EGheroBG;
        public int SelectCardId;

        public ArrowEffectManager arrowEffectManager;



    }
}
