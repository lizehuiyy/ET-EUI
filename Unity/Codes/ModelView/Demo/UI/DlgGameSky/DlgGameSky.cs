namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgGameSky :Entity,IAwake,IUILogic
	{

		public DlgGameSkyViewComponent View { get => this.Parent.GetComponent<DlgGameSkyViewComponent>();} 

		 

	}
}
