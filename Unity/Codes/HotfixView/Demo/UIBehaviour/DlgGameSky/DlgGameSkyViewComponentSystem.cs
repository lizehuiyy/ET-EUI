
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgGameSkyViewComponentAwakeSystem : AwakeSystem<DlgGameSkyViewComponent> 
	{
		public override void Awake(DlgGameSkyViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgGameSkyViewComponentDestroySystem : DestroySystem<DlgGameSkyViewComponent> 
	{
		public override void Destroy(DlgGameSkyViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
