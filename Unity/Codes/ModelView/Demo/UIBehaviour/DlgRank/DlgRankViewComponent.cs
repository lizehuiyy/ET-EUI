
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRankViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_XButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_XButton == null )
     			{
		    		this.m_EButton_XButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/EButton_X");
     			}
     			return this.m_EButton_XButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_XImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_XImage == null )
     			{
		    		this.m_EButton_XImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/EButton_X");
     			}
     			return this.m_EButton_XImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_RankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_RankText == null )
     			{
		    		this.m_ELabel_RankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/rankTip/ELabel_Rank");
     			}
     			return this.m_ELabel_RankText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_RankTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_RankTipText == null )
     			{
		    		this.m_ELabel_RankTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/Tips/ELabel_RankTip");
     			}
     			return this.m_ELabel_RankTipText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_NameTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_NameTipText == null )
     			{
		    		this.m_ELabel_NameTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/Tips/ELabel_NameTip");
     			}
     			return this.m_ELabel_NameTipText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_MMRTipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_MMRTipText == null )
     			{
		    		this.m_ELabel_MMRTipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/Tips/ELabel_MMRTip");
     			}
     			return this.m_ELabel_MMRTipText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_RankLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_RankLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_RankLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/ELoopScrollList_Rank");
     			}
     			return this.m_ELoopScrollList_RankLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_XButton = null;
			this.m_EButton_XImage = null;
			this.m_ELabel_RankText = null;
			this.m_ELabel_RankTipText = null;
			this.m_ELabel_NameTipText = null;
			this.m_ELabel_MMRTipText = null;
			this.m_ELoopScrollList_RankLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_XButton = null;
		private UnityEngine.UI.Image m_EButton_XImage = null;
		private UnityEngine.UI.Text m_ELabel_RankText = null;
		private UnityEngine.UI.Text m_ELabel_RankTipText = null;
		private UnityEngine.UI.Text m_ELabel_NameTipText = null;
		private UnityEngine.UI.Text m_ELabel_MMRTipText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_RankLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
