
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_HeroSmall : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_HeroSmall BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image EImage_BackGroudImage
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
     				if( this.m_EImage_BackGroudImage == null )
     				{
		    			this.m_EImage_BackGroudImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ContectRect/EImage_BackGroud");
     				}
     				return this.m_EImage_BackGroudImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ContectRect/EImage_BackGroud");
     			}
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

		public void DestroyWidget()
		{
			this.m_EImage_BackGroudImage = null;
			this.m_ELabel_NameText = null;
			this.m_ELabel_IdText = null;
			this.m_ERect_IconCanvas = null;
			this.m_ELabel_Name1Text = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_EImage_BackGroudImage = null;
		private UnityEngine.UI.Text m_ELabel_NameText = null;
		private UnityEngine.UI.Text m_ELabel_IdText = null;
		private UnityEngine.Canvas m_ERect_IconCanvas = null;
		private UnityEngine.UI.Text m_ELabel_Name1Text = null;
		public Transform uiTransform = null;
	}
}
