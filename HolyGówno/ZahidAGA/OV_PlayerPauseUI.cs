using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000083 RID: 131
	public static class OV_PlayerPauseUI
	{
		// Token: 0x06000276 RID: 630 RVA: 0x00002F35 File Offset: 0x00001135
		[Override(typeof(PlayerPauseUI), "onClickedExitButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedExitButton(ISleekElement button)
		{
			Provider.disconnect();
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00003D31 File Offset: 0x00001F31
		[Override(typeof(PlayerPauseUI), "onClickedSuicideButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_onClickedSuicideButton(ISleekElement button)
		{
			Player.player.life.sendSuicide();
		}
	}
}
