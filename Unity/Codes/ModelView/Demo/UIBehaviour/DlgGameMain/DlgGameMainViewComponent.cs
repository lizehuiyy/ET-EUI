
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgGameMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_startButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_startButton == null )
     			{
		    		this.m_EButton_startButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_start");
     			}
     			return this.m_EButton_startButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_startImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_startImage == null )
     			{
		    		this.m_EButton_startImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_start");
     			}
     			return this.m_EButton_startImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Text == null )
     			{
		    		this.m_ELabel_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_start/ELabel_");
     			}
     			return this.m_ELabel_Text;
     		}
     	}

		public UnityEngine.UI.Button EButton_TestButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TestButton == null )
     			{
		    		this.m_EButton_TestButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Test");
     			}
     			return this.m_EButton_TestButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_TestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TestImage == null )
     			{
		    		this.m_EButton_TestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Test");
     			}
     			return this.m_EButton_TestImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_TestText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TestText == null )
     			{
		    		this.m_ELabel_TestText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Test/ELabel_Test");
     			}
     			return this.m_ELabel_TestText;
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

		public UnityEngine.UI.Button EButton_HeroButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_HeroButton == null )
     			{
		    		this.m_EButton_HeroButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Hero");
     			}
     			return this.m_EButton_HeroButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_HeroImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_HeroImage == null )
     			{
		    		this.m_EButton_HeroImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Hero");
     			}
     			return this.m_EButton_HeroImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_HeroText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_HeroText == null )
     			{
		    		this.m_ELabel_HeroText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Hero/ELabel_Hero");
     			}
     			return this.m_ELabel_HeroText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_startButton = null;
			this.m_EButton_startImage = null;
			this.m_ELabel_Text = null;
			this.m_EButton_TestButton = null;
			this.m_EButton_TestImage = null;
			this.m_ELabel_TestText = null;
			this.m_ELabel_LvText = null;
			this.m_ELabel_CoinText = null;
			this.m_EButton_HeroButton = null;
			this.m_EButton_HeroImage = null;
			this.m_ELabel_HeroText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_startButton = null;
		private UnityEngine.UI.Image m_EButton_startImage = null;
		private UnityEngine.UI.Text m_ELabel_Text = null;
		private UnityEngine.UI.Button m_EButton_TestButton = null;
		private UnityEngine.UI.Image m_EButton_TestImage = null;
		private UnityEngine.UI.Text m_ELabel_TestText = null;
		private UnityEngine.UI.Text m_ELabel_LvText = null;
		private UnityEngine.UI.Text m_ELabel_CoinText = null;
		private UnityEngine.UI.Button m_EButton_HeroButton = null;
		private UnityEngine.UI.Image m_EButton_HeroImage = null;
		private UnityEngine.UI.Text m_ELabel_HeroText = null;
		public Transform uiTransform = null;
	}
}
