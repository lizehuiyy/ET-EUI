
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgChatViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CloseButton == null )
     			{
		    		this.m_EButton_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/EButton_Close");
     			}
     			return this.m_EButton_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CloseImage == null )
     			{
		    		this.m_EButton_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/EButton_Close");
     			}
     			return this.m_EButton_CloseImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_ChatLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ChatLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ChatLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"BackGround/ELoopScrollList_Chat");
     			}
     			return this.m_ELoopScrollList_ChatLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.InputField EInputFieldInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputFieldInputField == null )
     			{
		    		this.m_EInputFieldInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"BackGround/EInputField");
     			}
     			return this.m_EInputFieldInputField;
     		}
     	}

		public UnityEngine.UI.Image EInputFieldImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputFieldImage == null )
     			{
		    		this.m_EInputFieldImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/EInputField");
     			}
     			return this.m_EInputFieldImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_SendButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SendButton == null )
     			{
		    		this.m_EButton_SendButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"BackGround/EButton_Send");
     			}
     			return this.m_EButton_SendButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_SendImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_SendImage == null )
     			{
		    		this.m_EButton_SendImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"BackGround/EButton_Send");
     			}
     			return this.m_EButton_SendImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_CloseButton = null;
			this.m_EButton_CloseImage = null;
			this.m_ELoopScrollList_ChatLoopVerticalScrollRect = null;
			this.m_EInputFieldInputField = null;
			this.m_EInputFieldImage = null;
			this.m_EButton_SendButton = null;
			this.m_EButton_SendImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_CloseButton = null;
		private UnityEngine.UI.Image m_EButton_CloseImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_ChatLoopVerticalScrollRect = null;
		private UnityEngine.UI.InputField m_EInputFieldInputField = null;
		private UnityEngine.UI.Image m_EInputFieldImage = null;
		private UnityEngine.UI.Button m_EButton_SendButton = null;
		private UnityEngine.UI.Image m_EButton_SendImage = null;
		public Transform uiTransform = null;
	}
}
