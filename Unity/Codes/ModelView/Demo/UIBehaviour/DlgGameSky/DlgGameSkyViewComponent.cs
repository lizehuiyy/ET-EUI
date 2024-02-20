
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgGameSkyViewComponent : Entity,IAwake,IDestroy 
	{
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
		    		this.m_ELabel_LvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"backgroud/ELabel_Lv");
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
		    		this.m_ELabel_CoinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"backgroud/ELabel_Coin");
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
		    		this.m_ELabel_MMRText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"backgroud/ELabel_MMR");
     			}
     			return this.m_ELabel_MMRText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELabel_LvText = null;
			this.m_ELabel_CoinText = null;
			this.m_ELabel_MMRText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ELabel_LvText = null;
		private UnityEngine.UI.Text m_ELabel_CoinText = null;
		private UnityEngine.UI.Text m_ELabel_MMRText = null;
		public Transform uiTransform = null;
	}
}
