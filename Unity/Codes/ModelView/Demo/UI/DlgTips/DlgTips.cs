namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTips :Entity,IAwake,IUILogic
	{

		public DlgTipsViewComponent View { get => this.Parent.GetComponent<DlgTipsViewComponent>();} 

		 

	}
}
