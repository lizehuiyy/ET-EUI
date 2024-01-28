
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgSingHeroViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_backgroudButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_backgroudButton == null )
     			{
		    		this.m_EButton_backgroudButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_backgroud");
     			}
     			return this.m_EButton_backgroudButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_backgroudImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_backgroudImage == null )
     			{
		    		this.m_EButton_backgroudImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_backgroud");
     			}
     			return this.m_EButton_backgroudImage;
     		}
     	}

		public UnityEngine.RectTransform EGContectRectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGContectRectRectTransform == null )
     			{
		    		this.m_EGContectRectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGContectRect");
     			}
     			return this.m_EGContectRectRectTransform;
     		}
     	}

		public UnityEngine.UI.Image EI_serverTestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EI_serverTestImage == null )
     			{
		    		this.m_EI_serverTestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGContectRect/EI_serverTest");
     			}
     			return this.m_EI_serverTestImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectButton == null )
     			{
		    		this.m_EButton_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGContectRect/EButton_Select");
     			}
     			return this.m_EButton_SelectButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectImage == null )
     			{
		    		this.m_EButton_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGContectRect/EButton_Select");
     			}
     			return this.m_EButton_SelectImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_ContentText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_ContentText == null )
     			{
		    		this.m_ELabel_ContentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGContectRect/ELabel_Content");
     			}
     			return this.m_ELabel_ContentText;
     		}
     	}

		public UnityEngine.UI.Image EImage_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_IconImage == null )
     			{
		    		this.m_EImage_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGContectRect/EImage_Icon");
     			}
     			return this.m_EImage_IconImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_attackText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_attackText == null )
     			{
		    		this.m_ELabel_attackText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGContectRect/ELabel_attack");
     			}
     			return this.m_ELabel_attackText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_posText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_posText == null )
     			{
		    		this.m_ELabel_posText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGContectRect/ELabel_pos");
     			}
     			return this.m_ELabel_posText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_lifeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_lifeText == null )
     			{
		    		this.m_ELabel_lifeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGContectRect/ELabel_life");
     			}
     			return this.m_ELabel_lifeText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_NameText == null )
     			{
		    		this.m_ELabel_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGContectRect/ELabel_Name");
     			}
     			return this.m_ELabel_NameText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_backgroudButton = null;
			this.m_EButton_backgroudImage = null;
			this.m_EGContectRectRectTransform = null;
			this.m_EI_serverTestImage = null;
			this.m_EButton_SelectButton = null;
			this.m_EButton_SelectImage = null;
			this.m_ELabel_ContentText = null;
			this.m_EImage_IconImage = null;
			this.m_ELabel_attackText = null;
			this.m_ELabel_posText = null;
			this.m_ELabel_lifeText = null;
			this.m_ELabel_NameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_backgroudButton = null;
		private UnityEngine.UI.Image m_EButton_backgroudImage = null;
		private UnityEngine.RectTransform m_EGContectRectRectTransform = null;
		private UnityEngine.UI.Image m_EI_serverTestImage = null;
		private UnityEngine.UI.Button m_EButton_SelectButton = null;
		private UnityEngine.UI.Image m_EButton_SelectImage = null;
		private UnityEngine.UI.Text m_ELabel_ContentText = null;
		private UnityEngine.UI.Image m_EImage_IconImage = null;
		private UnityEngine.UI.Text m_ELabel_attackText = null;
		private UnityEngine.UI.Text m_ELabel_posText = null;
		private UnityEngine.UI.Text m_ELabel_lifeText = null;
		private UnityEngine.UI.Text m_ELabel_NameText = null;
		public Transform uiTransform = null;
	}
}
