
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRoomViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGhero1BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero1BGRectTransform == null )
     			{
		    		this.m_EGhero1BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero1/EGhero1BG");
     			}
     			return this.m_EGhero1BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer1_stagehero1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer1_stagehero1RectTransform == null )
     			{
		    		this.m_EGplayer1_stagehero1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero1/EGplayer1_stagehero1");
     			}
     			return this.m_EGplayer1_stagehero1RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList1LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList1LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList1LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero1/EGplayer1_stagehero1/ContectRect/ELoopScrollList_BuffList1");
     			}
     			return this.m_ELoopScrollList_BuffList1LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos1Button == null )
     			{
		    		this.m_EButton_SelectPos1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero1/EButton_SelectPos1");
     			}
     			return this.m_EButton_SelectPos1Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos1Image == null )
     			{
		    		this.m_EButton_SelectPos1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero1/EButton_SelectPos1");
     			}
     			return this.m_EButton_SelectPos1Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos1EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos1EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos1EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero1/EButton_SelectPos1");
     			}
     			return this.m_EButton_SelectPos1EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero2BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero2BGRectTransform == null )
     			{
		    		this.m_EGhero2BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero2/EGhero2BG");
     			}
     			return this.m_EGhero2BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer1_stagehero2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer1_stagehero2RectTransform == null )
     			{
		    		this.m_EGplayer1_stagehero2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero2/EGplayer1_stagehero2");
     			}
     			return this.m_EGplayer1_stagehero2RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList2LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList2LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList2LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero2/EGplayer1_stagehero2/ContectRect/ELoopScrollList_BuffList2");
     			}
     			return this.m_ELoopScrollList_BuffList2LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos2Button == null )
     			{
		    		this.m_EButton_SelectPos2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero2/EButton_SelectPos2");
     			}
     			return this.m_EButton_SelectPos2Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos2Image == null )
     			{
		    		this.m_EButton_SelectPos2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero2/EButton_SelectPos2");
     			}
     			return this.m_EButton_SelectPos2Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos2EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos2EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos2EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero2/EButton_SelectPos2");
     			}
     			return this.m_EButton_SelectPos2EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero3BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero3BGRectTransform == null )
     			{
		    		this.m_EGhero3BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero3/EGhero3BG");
     			}
     			return this.m_EGhero3BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer1_stagehero3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer1_stagehero3RectTransform == null )
     			{
		    		this.m_EGplayer1_stagehero3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero3/EGplayer1_stagehero3");
     			}
     			return this.m_EGplayer1_stagehero3RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList3LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList3LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList3LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero3/EGplayer1_stagehero3/ContectRect/ELoopScrollList_BuffList3");
     			}
     			return this.m_ELoopScrollList_BuffList3LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos3Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos3Button == null )
     			{
		    		this.m_EButton_SelectPos3Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero3/EButton_SelectPos3");
     			}
     			return this.m_EButton_SelectPos3Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos3Image == null )
     			{
		    		this.m_EButton_SelectPos3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero3/EButton_SelectPos3");
     			}
     			return this.m_EButton_SelectPos3Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos3EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos3EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos3EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero3/EButton_SelectPos3");
     			}
     			return this.m_EButton_SelectPos3EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero4BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero4BGRectTransform == null )
     			{
		    		this.m_EGhero4BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero4/EGhero4BG");
     			}
     			return this.m_EGhero4BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer1_stagehero4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer1_stagehero4RectTransform == null )
     			{
		    		this.m_EGplayer1_stagehero4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero4/EGplayer1_stagehero4");
     			}
     			return this.m_EGplayer1_stagehero4RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList4LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList4LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList4LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero4/EGplayer1_stagehero4/ContectRect/ELoopScrollList_BuffList4");
     			}
     			return this.m_ELoopScrollList_BuffList4LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos4Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos4Button == null )
     			{
		    		this.m_EButton_SelectPos4Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero4/EButton_SelectPos4");
     			}
     			return this.m_EButton_SelectPos4Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos4Image == null )
     			{
		    		this.m_EButton_SelectPos4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero4/EButton_SelectPos4");
     			}
     			return this.m_EButton_SelectPos4Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos4EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos4EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos4EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero4/EButton_SelectPos4");
     			}
     			return this.m_EButton_SelectPos4EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero5BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero5BGRectTransform == null )
     			{
		    		this.m_EGhero5BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero5/EGhero5BG");
     			}
     			return this.m_EGhero5BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer1_stagehero5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer1_stagehero5RectTransform == null )
     			{
		    		this.m_EGplayer1_stagehero5RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero5/EGplayer1_stagehero5");
     			}
     			return this.m_EGplayer1_stagehero5RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList5LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList5LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList5LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero5/EGplayer1_stagehero5/ContectRect/ELoopScrollList_BuffList5");
     			}
     			return this.m_ELoopScrollList_BuffList5LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos5Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos5Button == null )
     			{
		    		this.m_EButton_SelectPos5Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero5/EButton_SelectPos5");
     			}
     			return this.m_EButton_SelectPos5Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos5Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos5Image == null )
     			{
		    		this.m_EButton_SelectPos5Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero5/EButton_SelectPos5");
     			}
     			return this.m_EButton_SelectPos5Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos5EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos5EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos5EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player1/Hero/hero5/EButton_SelectPos5");
     			}
     			return this.m_EButton_SelectPos5EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGTower_Player1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGTower_Player1RectTransform == null )
     			{
		    		this.m_EGTower_Player1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/Tower/EGTower_Player1");
     			}
     			return this.m_EGTower_Player1RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_player1LoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_player1LoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_player1LoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"BackGroud/player1/Hand/ELoopScrollList_player1");
     			}
     			return this.m_ELoopScrollList_player1LoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player1NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player1NameText == null )
     			{
		    		this.m_ELabel_Player1NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player1/UI/ELabel_Player1Name");
     			}
     			return this.m_ELabel_Player1NameText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player1MMRText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player1MMRText == null )
     			{
		    		this.m_ELabel_Player1MMRText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player1/UI/ELabel_Player1MMR");
     			}
     			return this.m_ELabel_Player1MMRText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player1CoinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player1CoinText == null )
     			{
		    		this.m_ELabel_Player1CoinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player1/UI/ELabel_Player1Coin");
     			}
     			return this.m_ELabel_Player1CoinText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player1TowerHpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player1TowerHpText == null )
     			{
		    		this.m_ELabel_Player1TowerHpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player1/UI/ELabel_Player1TowerHp");
     			}
     			return this.m_ELabel_Player1TowerHpText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player1LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player1LevelText == null )
     			{
		    		this.m_ELabel_Player1LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player1/UI/ELabel_Player1Level");
     			}
     			return this.m_ELabel_Player1LevelText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player1ExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player1ExpText == null )
     			{
		    		this.m_ELabel_Player1ExpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player1/UI/ELabel_Player1Exp");
     			}
     			return this.m_ELabel_Player1ExpText;
     		}
     	}

		public UnityEngine.UI.Button EButton_UpLevelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_UpLevelButton == null )
     			{
		    		this.m_EButton_UpLevelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player1/UI/EButton_UpLevel");
     			}
     			return this.m_EButton_UpLevelButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_UpLevelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_UpLevelImage == null )
     			{
		    		this.m_EButton_UpLevelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player1/UI/EButton_UpLevel");
     			}
     			return this.m_EButton_UpLevelImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_UpLevelTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_UpLevelTextText == null )
     			{
		    		this.m_ELabel_UpLevelTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player1/UI/EButton_UpLevel/ELabel_UpLevelText");
     			}
     			return this.m_ELabel_UpLevelTextText;
     		}
     	}

		public UnityEngine.RectTransform EGItem5_player1LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem5_player1LibraryRectTransform == null )
     			{
		    		this.m_EGItem5_player1LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/CardLibrary/EGItem5_player1Library");
     			}
     			return this.m_EGItem5_player1LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem4_player1LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem4_player1LibraryRectTransform == null )
     			{
		    		this.m_EGItem4_player1LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/CardLibrary/EGItem4_player1Library");
     			}
     			return this.m_EGItem4_player1LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem3_player1LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem3_player1LibraryRectTransform == null )
     			{
		    		this.m_EGItem3_player1LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/CardLibrary/EGItem3_player1Library");
     			}
     			return this.m_EGItem3_player1LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem2_player1LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem2_player1LibraryRectTransform == null )
     			{
		    		this.m_EGItem2_player1LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/CardLibrary/EGItem2_player1Library");
     			}
     			return this.m_EGItem2_player1LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem1_player1LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem1_player1LibraryRectTransform == null )
     			{
		    		this.m_EGItem1_player1LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player1/CardLibrary/EGItem1_player1Library");
     			}
     			return this.m_EGItem1_player1LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGhero6BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero6BGRectTransform == null )
     			{
		    		this.m_EGhero6BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero1/EGhero6BG");
     			}
     			return this.m_EGhero6BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer2_stagehero1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer2_stagehero1RectTransform == null )
     			{
		    		this.m_EGplayer2_stagehero1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero1/EGplayer2_stagehero1");
     			}
     			return this.m_EGplayer2_stagehero1RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList6LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList6LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList6LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero1/EGplayer2_stagehero1/ContectRect/ELoopScrollList_BuffList6");
     			}
     			return this.m_ELoopScrollList_BuffList6LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos6Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos6Button == null )
     			{
		    		this.m_EButton_SelectPos6Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero1/EButton_SelectPos6");
     			}
     			return this.m_EButton_SelectPos6Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos6Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos6Image == null )
     			{
		    		this.m_EButton_SelectPos6Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero1/EButton_SelectPos6");
     			}
     			return this.m_EButton_SelectPos6Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos6EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos6EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos6EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero1/EButton_SelectPos6");
     			}
     			return this.m_EButton_SelectPos6EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero7BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero7BGRectTransform == null )
     			{
		    		this.m_EGhero7BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero2/EGhero7BG");
     			}
     			return this.m_EGhero7BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer2_stagehero2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer2_stagehero2RectTransform == null )
     			{
		    		this.m_EGplayer2_stagehero2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero2/EGplayer2_stagehero2");
     			}
     			return this.m_EGplayer2_stagehero2RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList7LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList7LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList7LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero2/EGplayer2_stagehero2/ContectRect/ELoopScrollList_BuffList7");
     			}
     			return this.m_ELoopScrollList_BuffList7LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos7Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos7Button == null )
     			{
		    		this.m_EButton_SelectPos7Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero2/EButton_SelectPos7");
     			}
     			return this.m_EButton_SelectPos7Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos7Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos7Image == null )
     			{
		    		this.m_EButton_SelectPos7Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero2/EButton_SelectPos7");
     			}
     			return this.m_EButton_SelectPos7Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos7EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos7EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos7EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero2/EButton_SelectPos7");
     			}
     			return this.m_EButton_SelectPos7EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero8BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero8BGRectTransform == null )
     			{
		    		this.m_EGhero8BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero3/EGhero8BG");
     			}
     			return this.m_EGhero8BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer2_stagehero3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer2_stagehero3RectTransform == null )
     			{
		    		this.m_EGplayer2_stagehero3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero3/EGplayer2_stagehero3");
     			}
     			return this.m_EGplayer2_stagehero3RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList8LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList8LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList8LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero3/EGplayer2_stagehero3/ContectRect/ELoopScrollList_BuffList8");
     			}
     			return this.m_ELoopScrollList_BuffList8LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos8Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos8Button == null )
     			{
		    		this.m_EButton_SelectPos8Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero3/EButton_SelectPos8");
     			}
     			return this.m_EButton_SelectPos8Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos8Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos8Image == null )
     			{
		    		this.m_EButton_SelectPos8Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero3/EButton_SelectPos8");
     			}
     			return this.m_EButton_SelectPos8Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos8EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos8EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos8EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero3/EButton_SelectPos8");
     			}
     			return this.m_EButton_SelectPos8EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero9BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero9BGRectTransform == null )
     			{
		    		this.m_EGhero9BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero4/EGhero9BG");
     			}
     			return this.m_EGhero9BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer2_stagehero4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer2_stagehero4RectTransform == null )
     			{
		    		this.m_EGplayer2_stagehero4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero4/EGplayer2_stagehero4");
     			}
     			return this.m_EGplayer2_stagehero4RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList9LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList9LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList9LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero4/EGplayer2_stagehero4/ContectRect/ELoopScrollList_BuffList9");
     			}
     			return this.m_ELoopScrollList_BuffList9LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos9Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos9Button == null )
     			{
		    		this.m_EButton_SelectPos9Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero4/EButton_SelectPos9");
     			}
     			return this.m_EButton_SelectPos9Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos9Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos9Image == null )
     			{
		    		this.m_EButton_SelectPos9Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero4/EButton_SelectPos9");
     			}
     			return this.m_EButton_SelectPos9Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos9EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos9EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos9EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero4/EButton_SelectPos9");
     			}
     			return this.m_EButton_SelectPos9EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGhero10BGRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGhero10BGRectTransform == null )
     			{
		    		this.m_EGhero10BGRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero5/EGhero10BG");
     			}
     			return this.m_EGhero10BGRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGplayer2_stagehero5RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGplayer2_stagehero5RectTransform == null )
     			{
		    		this.m_EGplayer2_stagehero5RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero5/EGplayer2_stagehero5");
     			}
     			return this.m_EGplayer2_stagehero5RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_BuffList10LoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_BuffList10LoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_BuffList10LoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero5/EGplayer2_stagehero5/ContectRect/ELoopScrollList_BuffList10");
     			}
     			return this.m_ELoopScrollList_BuffList10LoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectPos10Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos10Button == null )
     			{
		    		this.m_EButton_SelectPos10Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero5/EButton_SelectPos10");
     			}
     			return this.m_EButton_SelectPos10Button;
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectPos10Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos10Image == null )
     			{
		    		this.m_EButton_SelectPos10Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero5/EButton_SelectPos10");
     			}
     			return this.m_EButton_SelectPos10Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectPos10EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SelectPos10EventTrigger == null )
     			{
		    		this.m_EButton_SelectPos10EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"BackGroud/player2/Hero/hero5/EButton_SelectPos10");
     			}
     			return this.m_EButton_SelectPos10EventTrigger;
     		}
     	}

		public UnityEngine.RectTransform EGTower_Player2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGTower_Player2RectTransform == null )
     			{
		    		this.m_EGTower_Player2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/Tower/EGTower_Player2");
     			}
     			return this.m_EGTower_Player2RectTransform;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_player2LoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_player2LoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_player2LoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"BackGroud/player2/Hand/ELoopScrollList_player2");
     			}
     			return this.m_ELoopScrollList_player2LoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player2NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player2NameText == null )
     			{
		    		this.m_ELabel_Player2NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player2/UI/ELabel_Player2Name");
     			}
     			return this.m_ELabel_Player2NameText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player2MMRText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player2MMRText == null )
     			{
		    		this.m_ELabel_Player2MMRText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player2/UI/ELabel_Player2MMR");
     			}
     			return this.m_ELabel_Player2MMRText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player2CoinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player2CoinText == null )
     			{
		    		this.m_ELabel_Player2CoinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player2/UI/ELabel_Player2Coin");
     			}
     			return this.m_ELabel_Player2CoinText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player2TowerHpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player2TowerHpText == null )
     			{
		    		this.m_ELabel_Player2TowerHpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player2/UI/ELabel_Player2TowerHp");
     			}
     			return this.m_ELabel_Player2TowerHpText;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Player2LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Player2LevelText == null )
     			{
		    		this.m_ELabel_Player2LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"BackGroud/player2/UI/ELabel_Player2Level");
     			}
     			return this.m_ELabel_Player2LevelText;
     		}
     	}

		public UnityEngine.RectTransform EGItem5_player2LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem5_player2LibraryRectTransform == null )
     			{
		    		this.m_EGItem5_player2LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/CardLibrary/EGItem5_player2Library");
     			}
     			return this.m_EGItem5_player2LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem4_player2LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem4_player2LibraryRectTransform == null )
     			{
		    		this.m_EGItem4_player2LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/CardLibrary/EGItem4_player2Library");
     			}
     			return this.m_EGItem4_player2LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem3_player2LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem3_player2LibraryRectTransform == null )
     			{
		    		this.m_EGItem3_player2LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/CardLibrary/EGItem3_player2Library");
     			}
     			return this.m_EGItem3_player2LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem2_player2LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem2_player2LibraryRectTransform == null )
     			{
		    		this.m_EGItem2_player2LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/CardLibrary/EGItem2_player2Library");
     			}
     			return this.m_EGItem2_player2LibraryRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGItem1_player2LibraryRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGItem1_player2LibraryRectTransform == null )
     			{
		    		this.m_EGItem1_player2LibraryRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/player2/CardLibrary/EGItem1_player2Library");
     			}
     			return this.m_EGItem1_player2LibraryRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_EndButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_EndButton == null )
     			{
		    		this.m_EButton_EndButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/UI/EButton_End");
     			}
     			return this.m_EButton_EndButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_EndImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_EndImage == null )
     			{
		    		this.m_EButton_EndImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/UI/EButton_End");
     			}
     			return this.m_EButton_EndImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_GGButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_GGButton == null )
     			{
		    		this.m_EButton_GGButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/UI/EButton_GG");
     			}
     			return this.m_EButton_GGButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_GGImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_GGImage == null )
     			{
		    		this.m_EButton_GGImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/UI/EButton_GG");
     			}
     			return this.m_EButton_GGImage;
     		}
     	}

		public UnityEngine.RectTransform EGArrowEffectParentRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGArrowEffectParentRectTransform == null )
     			{
		    		this.m_EGArrowEffectParentRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/ArrowPanel/EGArrowEffectParent");
     			}
     			return this.m_EGArrowEffectParentRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EGArrowEffectRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGArrowEffectRectTransform == null )
     			{
		    		this.m_EGArrowEffectRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"BackGroud/ArrowPanel/EGArrowEffectParent/EGArrowEffect");
     			}
     			return this.m_EGArrowEffectRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGhero1BGRectTransform = null;
			this.m_EGplayer1_stagehero1RectTransform = null;
			this.m_ELoopScrollList_BuffList1LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos1Button = null;
			this.m_EButton_SelectPos1Image = null;
			this.m_EButton_SelectPos1EventTrigger = null;
			this.m_EGhero2BGRectTransform = null;
			this.m_EGplayer1_stagehero2RectTransform = null;
			this.m_ELoopScrollList_BuffList2LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos2Button = null;
			this.m_EButton_SelectPos2Image = null;
			this.m_EButton_SelectPos2EventTrigger = null;
			this.m_EGhero3BGRectTransform = null;
			this.m_EGplayer1_stagehero3RectTransform = null;
			this.m_ELoopScrollList_BuffList3LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos3Button = null;
			this.m_EButton_SelectPos3Image = null;
			this.m_EButton_SelectPos3EventTrigger = null;
			this.m_EGhero4BGRectTransform = null;
			this.m_EGplayer1_stagehero4RectTransform = null;
			this.m_ELoopScrollList_BuffList4LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos4Button = null;
			this.m_EButton_SelectPos4Image = null;
			this.m_EButton_SelectPos4EventTrigger = null;
			this.m_EGhero5BGRectTransform = null;
			this.m_EGplayer1_stagehero5RectTransform = null;
			this.m_ELoopScrollList_BuffList5LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos5Button = null;
			this.m_EButton_SelectPos5Image = null;
			this.m_EButton_SelectPos5EventTrigger = null;
			this.m_EGTower_Player1RectTransform = null;
			this.m_ELoopScrollList_player1LoopHorizontalScrollRect = null;
			this.m_ELabel_Player1NameText = null;
			this.m_ELabel_Player1MMRText = null;
			this.m_ELabel_Player1CoinText = null;
			this.m_ELabel_Player1TowerHpText = null;
			this.m_ELabel_Player1LevelText = null;
			this.m_ELabel_Player1ExpText = null;
			this.m_EButton_UpLevelButton = null;
			this.m_EButton_UpLevelImage = null;
			this.m_ELabel_UpLevelTextText = null;
			this.m_EGItem5_player1LibraryRectTransform = null;
			this.m_EGItem4_player1LibraryRectTransform = null;
			this.m_EGItem3_player1LibraryRectTransform = null;
			this.m_EGItem2_player1LibraryRectTransform = null;
			this.m_EGItem1_player1LibraryRectTransform = null;
			this.m_EGhero6BGRectTransform = null;
			this.m_EGplayer2_stagehero1RectTransform = null;
			this.m_ELoopScrollList_BuffList6LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos6Button = null;
			this.m_EButton_SelectPos6Image = null;
			this.m_EButton_SelectPos6EventTrigger = null;
			this.m_EGhero7BGRectTransform = null;
			this.m_EGplayer2_stagehero2RectTransform = null;
			this.m_ELoopScrollList_BuffList7LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos7Button = null;
			this.m_EButton_SelectPos7Image = null;
			this.m_EButton_SelectPos7EventTrigger = null;
			this.m_EGhero8BGRectTransform = null;
			this.m_EGplayer2_stagehero3RectTransform = null;
			this.m_ELoopScrollList_BuffList8LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos8Button = null;
			this.m_EButton_SelectPos8Image = null;
			this.m_EButton_SelectPos8EventTrigger = null;
			this.m_EGhero9BGRectTransform = null;
			this.m_EGplayer2_stagehero4RectTransform = null;
			this.m_ELoopScrollList_BuffList9LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos9Button = null;
			this.m_EButton_SelectPos9Image = null;
			this.m_EButton_SelectPos9EventTrigger = null;
			this.m_EGhero10BGRectTransform = null;
			this.m_EGplayer2_stagehero5RectTransform = null;
			this.m_ELoopScrollList_BuffList10LoopVerticalScrollRect = null;
			this.m_EButton_SelectPos10Button = null;
			this.m_EButton_SelectPos10Image = null;
			this.m_EButton_SelectPos10EventTrigger = null;
			this.m_EGTower_Player2RectTransform = null;
			this.m_ELoopScrollList_player2LoopHorizontalScrollRect = null;
			this.m_ELabel_Player2NameText = null;
			this.m_ELabel_Player2MMRText = null;
			this.m_ELabel_Player2CoinText = null;
			this.m_ELabel_Player2TowerHpText = null;
			this.m_ELabel_Player2LevelText = null;
			this.m_EGItem5_player2LibraryRectTransform = null;
			this.m_EGItem4_player2LibraryRectTransform = null;
			this.m_EGItem3_player2LibraryRectTransform = null;
			this.m_EGItem2_player2LibraryRectTransform = null;
			this.m_EGItem1_player2LibraryRectTransform = null;
			this.m_EButton_EndButton = null;
			this.m_EButton_EndImage = null;
			this.m_EButton_GGButton = null;
			this.m_EButton_GGImage = null;
			this.m_EGArrowEffectParentRectTransform = null;
			this.m_EGArrowEffectRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGhero1BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer1_stagehero1RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList1LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos1Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos1Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos1EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero2BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer1_stagehero2RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList2LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos2Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos2Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos2EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero3BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer1_stagehero3RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList3LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos3Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos3Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos3EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero4BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer1_stagehero4RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList4LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos4Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos4Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos4EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero5BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer1_stagehero5RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList5LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos5Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos5Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos5EventTrigger = null;
		private UnityEngine.RectTransform m_EGTower_Player1RectTransform = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_player1LoopHorizontalScrollRect = null;
		private UnityEngine.UI.Text m_ELabel_Player1NameText = null;
		private UnityEngine.UI.Text m_ELabel_Player1MMRText = null;
		private UnityEngine.UI.Text m_ELabel_Player1CoinText = null;
		private UnityEngine.UI.Text m_ELabel_Player1TowerHpText = null;
		private UnityEngine.UI.Text m_ELabel_Player1LevelText = null;
		private UnityEngine.UI.Text m_ELabel_Player1ExpText = null;
		private UnityEngine.UI.Button m_EButton_UpLevelButton = null;
		private UnityEngine.UI.Image m_EButton_UpLevelImage = null;
		private UnityEngine.UI.Text m_ELabel_UpLevelTextText = null;
		private UnityEngine.RectTransform m_EGItem5_player1LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem4_player1LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem3_player1LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem2_player1LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem1_player1LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGhero6BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer2_stagehero1RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList6LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos6Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos6Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos6EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero7BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer2_stagehero2RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList7LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos7Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos7Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos7EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero8BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer2_stagehero3RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList8LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos8Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos8Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos8EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero9BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer2_stagehero4RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList9LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos9Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos9Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos9EventTrigger = null;
		private UnityEngine.RectTransform m_EGhero10BGRectTransform = null;
		private UnityEngine.RectTransform m_EGplayer2_stagehero5RectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_BuffList10LoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_SelectPos10Button = null;
		private UnityEngine.UI.Image m_EButton_SelectPos10Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectPos10EventTrigger = null;
		private UnityEngine.RectTransform m_EGTower_Player2RectTransform = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_player2LoopHorizontalScrollRect = null;
		private UnityEngine.UI.Text m_ELabel_Player2NameText = null;
		private UnityEngine.UI.Text m_ELabel_Player2MMRText = null;
		private UnityEngine.UI.Text m_ELabel_Player2CoinText = null;
		private UnityEngine.UI.Text m_ELabel_Player2TowerHpText = null;
		private UnityEngine.UI.Text m_ELabel_Player2LevelText = null;
		private UnityEngine.RectTransform m_EGItem5_player2LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem4_player2LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem3_player2LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem2_player2LibraryRectTransform = null;
		private UnityEngine.RectTransform m_EGItem1_player2LibraryRectTransform = null;
		private UnityEngine.UI.Button m_EButton_EndButton = null;
		private UnityEngine.UI.Image m_EButton_EndImage = null;
		private UnityEngine.UI.Button m_EButton_GGButton = null;
		private UnityEngine.UI.Image m_EButton_GGImage = null;
		private UnityEngine.RectTransform m_EGArrowEffectParentRectTransform = null;
		private UnityEngine.RectTransform m_EGArrowEffectRectTransform = null;
		public Transform uiTransform = null;
	}
}
