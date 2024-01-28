
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgSingHeroViewComponentAwakeSystem : AwakeSystem<DlgSingHeroViewComponent> 
	{
		public override void Awake(DlgSingHeroViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgSingHeroViewComponentDestroySystem : DestroySystem<DlgSingHeroViewComponent> 
	{
		public override void Destroy(DlgSingHeroViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
