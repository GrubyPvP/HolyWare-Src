using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000AD RID: 173
	public class DropDown
	{
		// Token: 0x06000305 RID: 773 RVA: 0x0000422D File Offset: 0x0000242D
		public DropDown()
		{
			this.IsEnabled = false;
			this.ListIndex = 0;
			this.ScrollView = Vector2.zero;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00015880 File Offset: 0x00013A80
		public static DropDown Get(string identifier)
		{
			DropDown dropDown;
			DropDown result;
			if (DropDown.DropDownManager.TryGetValue(identifier, out dropDown))
			{
				result = dropDown;
			}
			else
			{
				dropDown = new DropDown();
				DropDown.DropDownManager.Add(identifier, dropDown);
				result = dropDown;
			}
			return result;
		}

		// Token: 0x040002F7 RID: 759
		public static Dictionary<string, DropDown> DropDownManager = new Dictionary<string, DropDown>();

		// Token: 0x040002F8 RID: 760
		public bool IsEnabled;

		// Token: 0x040002F9 RID: 761
		public int ListIndex;

		// Token: 0x040002FA RID: 762
		public Vector2 ScrollView;
	}
}
