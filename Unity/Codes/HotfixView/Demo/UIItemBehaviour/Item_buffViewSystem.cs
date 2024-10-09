
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_buffDestroySystem : DestroySystem<Scroll_Item_buff> 
	{
		public override void Destroy( Scroll_Item_buff self )
		{
			self.DestroyWidget();
		}
	}
}
