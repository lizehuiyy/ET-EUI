using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgHeroMain :Entity,IAwake,IUILogic
	{

		public DlgHeroMainViewComponent View { get => this.Parent.GetComponent<DlgHeroMainViewComponent>();}

        public Dictionary<int, Scroll_Item_hero> ScrollItemHeroDic;

    }
}
