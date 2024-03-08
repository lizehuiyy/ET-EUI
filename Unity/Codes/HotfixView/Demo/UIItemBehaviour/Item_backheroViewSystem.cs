
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_backheroDestroySystem : DestroySystem<Scroll_Item_backhero> 
	{
		public override void Destroy( Scroll_Item_backhero self )
		{
			self.DestroyWidget();
		}
	}
}
