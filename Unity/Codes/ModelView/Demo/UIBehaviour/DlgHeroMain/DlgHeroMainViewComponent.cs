
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

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_MyCardLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_MyCardLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_MyCardLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EGBackGround/ELoopScrollList_MyCard");
     			}
     			return this.m_ELoopScrollList_MyCardLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text ELabel_CardsNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_CardsNumText == null )
     			{
		    		this.m_ELabel_CardsNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/ELabel_CardsNum");
     			}
     			return this.m_ELabel_CardsNumText;
     		}
     	}

		public UnityEngine.UI.Button EButton_SaveCardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SaveCardButton == null )
     			{
		    		this.m_EButton_SaveCardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_SaveCard");
     			}
     			return this.m_EButton_SaveCardButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_SaveCardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SaveCardImage == null )
     			{
		    		this.m_EButton_SaveCardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_SaveCard");
     			}
     			return this.m_EButton_SaveCardImage;
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

		public UnityEngine.UI.Text ELabel_MMRText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_MMRText == null )
     			{
		    		this.m_ELabel_MMRText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"DlgGameSky/backgroud/ELabel_MMR");
     			}
     			return this.m_ELabel_MMRText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_ELoopScrollList_HeroLoopVerticalScrollRect = null;
			this.m_ELoopScrollList_MyCardLoopVerticalScrollRect = null;
			this.m_ELabel_CardsNumText = null;
			this.m_EButton_SaveCardButton = null;
			this.m_EButton_SaveCardImage = null;
			this.m_ELabel_LvText = null;
			this.m_ELabel_CoinText = null;
			this.m_ELabel_MMRText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_HeroLoopVerticalScrollRect = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_MyCardLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_ELabel_CardsNumText = null;
		private UnityEngine.UI.Button m_EButton_SaveCardButton = null;
		private UnityEngine.UI.Image m_EButton_SaveCardImage = null;
		private UnityEngine.UI.Text m_ELabel_LvText = null;
		private UnityEngine.UI.Text m_ELabel_CoinText = null;
		private UnityEngine.UI.Text m_ELabel_MMRText = null;
		public Transform uiTransform = null;
	}
}
