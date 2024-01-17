namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGameMain :Entity,IAwake,IUILogic
	{

		public DlgGameMainViewComponent View { get => this.Parent.GetComponent<DlgGameMainViewComponent>();} 

		 

	}
}
