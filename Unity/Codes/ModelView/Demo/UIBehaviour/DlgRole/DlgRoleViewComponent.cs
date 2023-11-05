
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRoleViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button EButton_CreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateButton == null )
     			{
		    		this.m_EButton_CreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_Create");
     			}
     			return this.m_EButton_CreateButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateImage == null )
     			{
		    		this.m_EButton_CreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_Create");
     			}
     			return this.m_EButton_CreateImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_CreateText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_CreateText == null )
     			{
		    		this.m_ELabel_CreateText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EButton_Create/ELabel_Create");
     			}
     			return this.m_ELabel_CreateText;
     		}
     	}

		public UnityEngine.UI.Button EButton_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ConfirmButton == null )
     			{
		    		this.m_EButton_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_Confirm");
     			}
     			return this.m_EButton_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ConfirmImage == null )
     			{
		    		this.m_EButton_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_Confirm");
     			}
     			return this.m_EButton_ConfirmImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_ConfirmText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_ConfirmText == null )
     			{
		    		this.m_ELabel_ConfirmText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EButton_Confirm/ELabel_Confirm");
     			}
     			return this.m_ELabel_ConfirmText;
     		}
     	}

		public UnityEngine.UI.Button EButton_DeleteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_DeleteButton == null )
     			{
		    		this.m_EButton_DeleteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/EButton_Delete");
     			}
     			return this.m_EButton_DeleteButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_DeleteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_DeleteImage == null )
     			{
		    		this.m_EButton_DeleteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EButton_Delete");
     			}
     			return this.m_EButton_DeleteImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_DeleteText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_DeleteText == null )
     			{
		    		this.m_ELabel_DeleteText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EButton_Delete/ELabel_Delete");
     			}
     			return this.m_ELabel_DeleteText;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoopScrollList_RoleLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_RoleLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_RoleLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"EGBackGround/ELoopScrollList_Role");
     			}
     			return this.m_ELoopScrollList_RoleLoopHorizontalScrollRect;
     		}
     	}

		public UnityEngine.UI.InputField EInputField_CreateInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputField_CreateInputField == null )
     			{
		    		this.m_EInputField_CreateInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EGBackGround/EInputField_Create");
     			}
     			return this.m_EInputField_CreateInputField;
     		}
     	}

		public UnityEngine.UI.Image EInputField_CreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputField_CreateImage == null )
     			{
		    		this.m_EInputField_CreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/EInputField_Create");
     			}
     			return this.m_EInputField_CreateImage;
     		}
     	}

		public UnityEngine.UI.Text EInputField_TextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInputField_TextText == null )
     			{
		    		this.m_EInputField_TextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/EInputField_Create/EInputField_Text");
     			}
     			return this.m_EInputField_TextText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_EButton_CreateButton = null;
			this.m_EButton_CreateImage = null;
			this.m_ELabel_CreateText = null;
			this.m_EButton_ConfirmButton = null;
			this.m_EButton_ConfirmImage = null;
			this.m_ELabel_ConfirmText = null;
			this.m_EButton_DeleteButton = null;
			this.m_EButton_DeleteImage = null;
			this.m_ELabel_DeleteText = null;
			this.m_ELoopScrollList_RoleLoopHorizontalScrollRect = null;
			this.m_EInputField_CreateInputField = null;
			this.m_EInputField_CreateImage = null;
			this.m_EInputField_TextText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_EButton_CreateButton = null;
		private UnityEngine.UI.Image m_EButton_CreateImage = null;
		private UnityEngine.UI.Text m_ELabel_CreateText = null;
		private UnityEngine.UI.Button m_EButton_ConfirmButton = null;
		private UnityEngine.UI.Image m_EButton_ConfirmImage = null;
		private UnityEngine.UI.Text m_ELabel_ConfirmText = null;
		private UnityEngine.UI.Button m_EButton_DeleteButton = null;
		private UnityEngine.UI.Image m_EButton_DeleteImage = null;
		private UnityEngine.UI.Text m_ELabel_DeleteText = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoopScrollList_RoleLoopHorizontalScrollRect = null;
		private UnityEngine.UI.InputField m_EInputField_CreateInputField = null;
		private UnityEngine.UI.Image m_EInputField_CreateImage = null;
		private UnityEngine.UI.Text m_EInputField_TextText = null;
		public Transform uiTransform = null;
	}
}
