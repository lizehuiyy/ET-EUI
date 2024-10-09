﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_hardhero : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_hardhero BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_NameText == null )
     				{
		    			this.m_ELabel_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_Name");
     				}
     				return this.m_ELabel_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_Name");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_ContentText == null )
     				{
		    			this.m_ELabel_ContentText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_Content");
     				}
     				return this.m_ELabel_ContentText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_Content");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_EImage_IconImage == null )
     				{
		    			this.m_EImage_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ContectRect/EImage_Icon");
     				}
     				return this.m_EImage_IconImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ContectRect/EImage_Icon");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_attackText == null )
     				{
		    			this.m_ELabel_attackText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_attack");
     				}
     				return this.m_ELabel_attackText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_attack");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_posText == null )
     				{
		    			this.m_ELabel_posText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_pos");
     				}
     				return this.m_ELabel_posText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_pos");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_lifeText == null )
     				{
		    			this.m_ELabel_lifeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_life");
     				}
     				return this.m_ELabel_lifeText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_life");
     			}
     		}
     	}

		public UnityEngine.Canvas ERect_IconCanvas
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_ERect_IconCanvas == null )
     				{
		    			this.m_ERect_IconCanvas = UIFindHelper.FindDeepChild<UnityEngine.Canvas>(this.uiTransform.gameObject,"ContectRect/ERect_Icon");
     				}
     				return this.m_ERect_IconCanvas;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.Canvas>(this.uiTransform.gameObject,"ContectRect/ERect_Icon");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_Name1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_Name1Text == null )
     				{
		    			this.m_ELabel_Name1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ERect_Icon/ELabel_Name1");
     				}
     				return this.m_ELabel_Name1Text;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ERect_Icon/ELabel_Name1");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_IdText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_ELabel_IdText == null )
     				{
		    			this.m_ELabel_IdText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_Id");
     				}
     				return this.m_ELabel_IdText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ContectRect/ELabel_Id");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_SelectButton == null )
     				{
		    			this.m_EButton_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Select");
     				}
     				return this.m_EButton_SelectButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Select");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_SelectImage == null )
     				{
		    			this.m_EButton_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Select");
     				}
     				return this.m_EButton_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Select");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_SelectEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_SelectEventTrigger == null )
     				{
		    			this.m_EButton_SelectEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EButton_Select");
     				}
     				return this.m_EButton_SelectEventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EButton_Select");
     			}
     		}
     	}

		public UnityEngine.UI.Button EButton_Select1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_Select1Button == null )
     				{
		    			this.m_EButton_Select1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Select1");
     				}
     				return this.m_EButton_Select1Button;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Select1");
     			}
     		}
     	}

		public UnityEngine.UI.Image EButton_Select1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_Select1Image == null )
     				{
		    			this.m_EButton_Select1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Select1");
     				}
     				return this.m_EButton_Select1Image;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Select1");
     			}
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger EButton_Select1EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_Select1EventTrigger == null )
     				{
		    			this.m_EButton_Select1EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EButton_Select1");
     				}
     				return this.m_EButton_Select1EventTrigger;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"EButton_Select1");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELabel_NameText = null;
			this.m_ELabel_ContentText = null;
			this.m_EImage_IconImage = null;
			this.m_ELabel_attackText = null;
			this.m_ELabel_posText = null;
			this.m_ELabel_lifeText = null;
			this.m_ERect_IconCanvas = null;
			this.m_ELabel_Name1Text = null;
			this.m_ELabel_IdText = null;
			this.m_EButton_SelectButton = null;
			this.m_EButton_SelectImage = null;
			this.m_EButton_SelectEventTrigger = null;
			this.m_EButton_Select1Button = null;
			this.m_EButton_Select1Image = null;
			this.m_EButton_Select1EventTrigger = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_ELabel_NameText = null;
		private UnityEngine.UI.Text m_ELabel_ContentText = null;
		private UnityEngine.UI.Image m_EImage_IconImage = null;
		private UnityEngine.UI.Text m_ELabel_attackText = null;
		private UnityEngine.UI.Text m_ELabel_posText = null;
		private UnityEngine.UI.Text m_ELabel_lifeText = null;
		private UnityEngine.Canvas m_ERect_IconCanvas = null;
		private UnityEngine.UI.Text m_ELabel_Name1Text = null;
		private UnityEngine.UI.Text m_ELabel_IdText = null;
		private UnityEngine.UI.Button m_EButton_SelectButton = null;
		private UnityEngine.UI.Image m_EButton_SelectImage = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_SelectEventTrigger = null;
		private UnityEngine.UI.Button m_EButton_Select1Button = null;
		private UnityEngine.UI.Image m_EButton_Select1Image = null;
		private UnityEngine.EventSystems.EventTrigger m_EButton_Select1EventTrigger = null;
		public Transform uiTransform = null;
	}
}
