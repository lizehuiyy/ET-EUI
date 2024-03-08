
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgTipsViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image EBackGroudImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBackGroudImage == null )
     			{
		    		this.m_EBackGroudImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBackGroud");
     			}
     			return this.m_EBackGroudImage;
     		}
     	}

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
		    		this.m_EButton_XButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EBackGroud/EButton_X");
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
		    		this.m_EButton_XImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBackGroud/EButton_X");
     			}
     			return this.m_EButton_XImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TipText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TipText == null )
     			{
		    		this.m_ELabel_TipText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EBackGroud/ELabel_Tip");
     			}
     			return this.m_ELabel_TipText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EBackGroudImage = null;
			this.m_EButton_XButton = null;
			this.m_EButton_XImage = null;
			this.m_ELabel_TipText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EBackGroudImage = null;
		private UnityEngine.UI.Button m_EButton_XButton = null;
		private UnityEngine.UI.Image m_EButton_XImage = null;
		private UnityEngine.UI.Text m_ELabel_TipText = null;
		public Transform uiTransform = null;
	}
}
