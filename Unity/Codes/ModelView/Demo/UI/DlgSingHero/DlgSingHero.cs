namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgSingHero :Entity,IAwake,IUILogic
	{

		public DlgSingHeroViewComponent View { get => this.Parent.GetComponent<DlgSingHeroViewComponent>();} 

		 

	}
}
