using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000081 RID: 129
	public static class OV_PlayerLifeUI
	{
		// Token: 0x06000270 RID: 624 RVA: 0x00003CA4 File Offset: 0x00001EA4
		[Override(typeof(PlayerLifeUI), "hasCompassInInventory", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static bool OV_hasCompassInInventory()
		{
			return MiscOptions.Compass || (bool)OverrideUtilities.CallOriginal(null, new object[0]);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00003CC0 File Offset: 0x00001EC0
		[Override(typeof(PlayerLifeUI), "updateGrayscale", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_updateGrayscale()
		{
			if (!MiscOptions.NoGrayscale)
			{
				OverrideUtilities.CallOriginal(null, new object[0]);
			}
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00003CD6 File Offset: 0x00001ED6
		[OnSpy]
		public static void Disable()
		{
			if (DrawUtilities.ShouldRun())
			{
				OV_PlayerLifeUI.WasCompassEnabled = MiscOptions.Compass;
				MiscOptions.Compass = false;
				PlayerLifeUI.updateCompass();
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00003CF7 File Offset: 0x00001EF7
		[OffSpy]
		public static void Enable()
		{
			if (DrawUtilities.ShouldRun())
			{
				MiscOptions.Compass = OV_PlayerLifeUI.WasCompassEnabled;
				PlayerLifeUI.updateCompass();
			}
		}

		// Token: 0x040002B0 RID: 688
		public static bool WasCompassEnabled;
	}
}
