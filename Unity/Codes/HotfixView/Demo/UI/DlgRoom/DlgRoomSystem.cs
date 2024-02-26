using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgRoom))]
	public static  class DlgRoomSystem
	{

		public static void RegisterUIEvent(this DlgRoom self)
		{
		 
		}

		public static void ShowWindow(this DlgRoom self, Entity contextData = null)
		{
			Gamer gamer1 = self.ZoneScene().GetComponent<Room>().GetGamer(0);

            Gamer gamer2 = self.ZoneScene().GetComponent<Room>().GetGamer(1);

            self.View.ELabel_Player1NameText.SetText(gamer1.Name);
            self.View.ELabel_Player1MMRText.SetText(gamer1.MMR + "");

            self.View.ELabel_Player2NameText.SetText(gamer2.Name);
            self.View.ELabel_Player2MMRText.SetText(gamer2.MMR + "");



        }

		 

	}
}
