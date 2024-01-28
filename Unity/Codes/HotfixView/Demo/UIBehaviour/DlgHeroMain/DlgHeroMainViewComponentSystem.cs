
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgHeroMainViewComponentAwakeSystem : AwakeSystem<DlgHeroMainViewComponent> 
	{
		public override void Awake(DlgHeroMainViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgHeroMainViewComponentDestroySystem : DestroySystem<DlgHeroMainViewComponent> 
	{
		public override void Destroy(DlgHeroMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
