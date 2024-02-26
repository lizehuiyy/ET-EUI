
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

		public UnityEngine.UI.Button EButton_ChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChatButton == null )
     			{
		    		this.m_EButton_ChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Chat");
     			}
     			return this.m_EButton_ChatButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChatImage == null )
     			{
		    		this.m_EButton_ChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Chat");
     			}
     			return this.m_EButton_ChatImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_ChatText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_ChatText == null )
     			{
		    		this.m_ELabel_ChatText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Chat/ELabel_Chat");
     			}
     			return this.m_ELabel_ChatText;
     		}
     	}

		public UnityEngine.UI.Button EButton_RankButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RankButton == null )
     			{
		    		this.m_EButton_RankButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Rank");
     			}
     			return this.m_EButton_RankButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_RankImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RankImage == null )
     			{
		    		this.m_EButton_RankImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Rank");
     			}
     			return this.m_EButton_RankImage;
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
		    		this.m_ELabel_RankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_Rank/ELabel_Rank");
     			}
     			return this.m_ELabel_RankText;
     		}
     	}

		public UnityEngine.UI.Button EButton_StopButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_StopButton == null )
     			{
		    		this.m_EButton_StopButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Stop");
     			}
     			return this.m_EButton_StopButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_StopImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_StopImage == null )
     			{
		    		this.m_EButton_StopImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Stop");
     			}
     			return this.m_EButton_StopImage;
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
			this.m_ELabel_MMRText = null;
			this.m_EButton_HeroButton = null;
			this.m_EButton_HeroImage = null;
			this.m_ELabel_HeroText = null;
			this.m_EButton_ChatButton = null;
			this.m_EButton_ChatImage = null;
			this.m_ELabel_ChatText = null;
			this.m_EButton_RankButton = null;
			this.m_EButton_RankImage = null;
			this.m_ELabel_RankText = null;
			this.m_EButton_StopButton = null;
			this.m_EButton_StopImage = null;
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
		private UnityEngine.UI.Text m_ELabel_MMRText = null;
		private UnityEngine.UI.Button m_EButton_HeroButton = null;
		private UnityEngine.UI.Image m_EButton_HeroImage = null;
		private UnityEngine.UI.Text m_ELabel_HeroText = null;
		private UnityEngine.UI.Button m_EButton_ChatButton = null;
		private UnityEngine.UI.Image m_EButton_ChatImage = null;
		private UnityEngine.UI.Text m_ELabel_ChatText = null;
		private UnityEngine.UI.Button m_EButton_RankButton = null;
		private UnityEngine.UI.Image m_EButton_RankImage = null;
		private UnityEngine.UI.Text m_ELabel_RankText = null;
		private UnityEngine.UI.Button m_EButton_StopButton = null;
		private UnityEngine.UI.Image m_EButton_StopImage = null;
		public Transform uiTransform = null;
	}
}
