
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRoomViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.UI.Button EndButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EndButton == null )
     			{
		    		this.m_EndButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGroud/UI/End");
     			}
     			return this.m_EndButton;
     		}
     	}

		public UnityEngine.UI.Image EndImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EndImage == null )
     			{
		    		this.m_EndImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGroud/UI/End");
     			}
     			return this.m_EndImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELoopScrollList_player1LoopHorizontalScrollRect = null;
			this.m_ELabel_Player1NameText = null;
			this.m_ELabel_Player1MMRText = null;
			this.m_ELoopScrollList_player2LoopHorizontalScrollRect = null;
			this.m_ELabel_Player2NameText = null;
			this.m_ELabel_Player2MMRText = null;
			this.m_EndButton = null;
			this.m_EndImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_player1LoopHorizontalScrollRect = null;
		private UnityEngine.UI.Text m_ELabel_Player1NameText = null;
		private UnityEngine.UI.Text m_ELabel_Player1MMRText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_player2LoopHorizontalScrollRect = null;
		private UnityEngine.UI.Text m_ELabel_Player2NameText = null;
		private UnityEngine.UI.Text m_ELabel_Player2MMRText = null;
		private UnityEngine.UI.Button m_EndButton = null;
		private UnityEngine.UI.Image m_EndImage = null;
		public Transform uiTransform = null;
	}
}
