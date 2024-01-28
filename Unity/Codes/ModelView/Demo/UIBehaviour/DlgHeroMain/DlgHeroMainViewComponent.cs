
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgHeroMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_HeroLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_HeroLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_HeroLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EGBackGround/ELoopScrollList_Hero");
     			}
     			return this.m_ELoopScrollList_HeroLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text ELabel_LvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_LvText == null )
     			{
		    		this.m_ELabel_LvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"DlgGameSky/backgroud/ELabel_Lv");
     			}
     			return this.m_ELabel_LvText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_CoinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_CoinText == null )
     			{
		    		this.m_ELabel_CoinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"DlgGameSky/backgroud/ELabel_Coin");
     			}
     			return this.m_ELabel_CoinText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_ELoopScrollList_HeroLoopVerticalScrollRect = null;
			this.m_ELabel_LvText = null;
			this.m_ELabel_CoinText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_HeroLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_ELabel_LvText = null;
		private UnityEngine.UI.Text m_ELabel_CoinText = null;
		public Transform uiTransform = null;
	}
}
