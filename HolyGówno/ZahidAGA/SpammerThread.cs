using System;
using System.Threading;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x0200008B RID: 139
	public static class SpammerThread
	{
		// Token: 0x0600028C RID: 652 RVA: 0x00011714 File Offset: 0x0000F914
		[Thread]
		public static void Spammer()
		{
			for (;;)
			{
				Thread.Sleep(MiscOptions.SpammerDelay);
				if (MiscOptions.SpammerEnabled & MiscOptions.ChatGlobal)
				{
					ChatManager.sendChat(0, MiscOptions.SpamText);
				}
				if (MiscOptions.SpammerEnabled & MiscOptions.ChatArea)
				{
					ChatManager.sendChat(1, MiscOptions.SpamText);
				}
				if (MiscOptions.SpammerEnabled & MiscOptions.ChatGroup)
				{
					ChatManager.sendChat(2, MiscOptions.SpamText);
				}
				if (MiscOptions.SpammerEnabled & MiscOptions.ChatSay)
				{
					ChatManager.sendChat(4, MiscOptions.SpamText);
				}
			}
		}
	}
}
