using System;

namespace ZahidAGA
{
	// Token: 0x02000075 RID: 117
	public static class RadarOptions
	{
		// Token: 0x0400027F RID: 639
		[Save]
		public static bool Enabled = false;

		// Token: 0x04000280 RID: 640
		[Save]
		public static bool TrackPlayer = false;

		// Token: 0x04000281 RID: 641
		[Save]
		public static bool ShowPlayers = false;

		// Token: 0x04000282 RID: 642
		[Save]
		public static bool ShowVehicles = false;

		// Token: 0x04000283 RID: 643
		[Save]
		public static bool ShowVehiclesUnlocked = false;

		// Token: 0x04000284 RID: 644
		[Save]
		public static bool ShowDeathPosition = false;

		// Token: 0x04000285 RID: 645
		public static float RadarZoom = 1f;

		// Token: 0x04000286 RID: 646
		[Save]
		public static float RadarSize = 300f;
	}
}
