
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_hardheroDestroySystem : DestroySystem<Scroll_Item_hardhero> 
	{
		public override void Destroy( Scroll_Item_hardhero self )
		{
			self.DestroyWidget();
		}
	}
}
