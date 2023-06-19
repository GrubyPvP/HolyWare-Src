using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000C3 RID: 195
	public class NotificationWindow
	{
		// Token: 0x06000345 RID: 837 RVA: 0x000176F4 File Offset: 0x000158F4
		public void Run()
		{
			GUI.skin = AssetUtilities.Skin;
			if (DateTimeOffset.Now.ToUnixTimeMilliseconds() > this.ExpireTime)
			{
				T.Notifications.Remove(this);
				return;
			}
			if (100L > this.ExpireTime - DateTimeOffset.Now.ToUnixTimeMilliseconds())
			{
				long expireTime = this.ExpireTime;
				DateTimeOffset.Now.ToUnixTimeMilliseconds();
				GUI.Window(this.NotificationNum + 10, new Rect(0f, (float)(Screen.height / 2 - 80 * this.NotificationNum), 220f, 60f), new GUI.WindowFunction(this.Draw), "", "SelectedButtonDropdown");
				return;
			}
			GUI.Window(this.NotificationNum + 10, new Rect(0f, (float)(Screen.height / 2 - 80 * this.NotificationNum), 220f, 60f), new GUI.WindowFunction(this.Draw), "", "SelectedButtonDropdown");
		}

		// Token: 0x06000346 RID: 838 RVA: 0x000177FC File Offset: 0x000159FC
		private void Draw(int windowID)
		{
			GUI.Label(new Rect(25f, 25f, 220f, 70f), "<size=17>" + this.info + "</size>");
			GUI.DrawTexture(new Rect(300f - (float)(this.ExpireTime - DateTimeOffset.Now.ToUnixTimeMilliseconds() - 100L) / 9900f * 220f, 50f, 220f, 10f), AssetUtilities.Skin.verticalScrollbar.normal.background, 0);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00017898 File Offset: 0x00015A98
		public NotificationWindow()
		{
			this.ExpireTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() + 3000L;
		}

		// Token: 0x0400039D RID: 925
		public string info;

		// Token: 0x0400039E RID: 926
		private long ExpireTime;

		// Token: 0x0400039F RID: 927
		public int NotificationNum = T.Notifications.Count + 1;
	}
}
