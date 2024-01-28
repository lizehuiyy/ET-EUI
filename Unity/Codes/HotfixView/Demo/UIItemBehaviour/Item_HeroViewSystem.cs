
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_heroDestroySystem : DestroySystem<Scroll_Item_hero> 
	{
		public override void Destroy( Scroll_Item_hero self )
		{
			self.DestroyWidget();
		}
	}
}
