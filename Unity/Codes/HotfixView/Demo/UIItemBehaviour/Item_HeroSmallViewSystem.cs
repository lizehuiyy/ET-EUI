﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_HeroSmallDestroySystem : DestroySystem<Scroll_Item_HeroSmall> 
	{
		public override void Destroy( Scroll_Item_HeroSmall self )
		{
			self.DestroyWidget();
		}
	}
}
