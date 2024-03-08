using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRoom :Entity,IAwake,IUILogic
	{

		public DlgRoomViewComponent View { get => this.Parent.GetComponent<DlgRoomViewComponent>();}

        public Dictionary<int, Scroll_Item_hardhero> ScrollPlayer1HardDic;

        public Dictionary<int, Scroll_Item_backhero> ScrollPlayer2HardDic;

		

    }
}
