
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgGameMainViewComponentAwakeSystem : AwakeSystem<DlgGameMainViewComponent> 
	{
		public override void Awake(DlgGameMainViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgGameMainViewComponentDestroySystem : DestroySystem<DlgGameMainViewComponent> 
	{
		public override void Destroy(DlgGameMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
