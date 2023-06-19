using System;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000067 RID: 103
	public static class AimbotOptions
	{
		// Token: 0x04000191 RID: 401
		[Save]
		public static bool Enabled = false;

		// Token: 0x04000192 RID: 402
		[Save]
		public static bool UseGunDistance = false;

		// Token: 0x04000193 RID: 403
		[Save]
		public static bool Smooth = false;

		// Token: 0x04000194 RID: 404
		[Save]
		public static bool OnKey = true;

		// Token: 0x04000195 RID: 405
		[Save]
		public static bool UseFovAim = true;

		// Token: 0x04000196 RID: 406
		public static float MaxSpeed = 20f;

		// Token: 0x04000197 RID: 407
		[Save]
		public static float AimSpeed = 5f;

		// Token: 0x04000198 RID: 408
		[Save]
		public static float Distance = 300f;

		// Token: 0x04000199 RID: 409
		[Save]
		public static float FOV = 15f;

		// Token: 0x0400019A RID: 410
		[Save]
		public static ELimb TargetLimb = 13;

		// Token: 0x0400019B RID: 411
		[Save]
		public static TargetMode TargetMode = TargetMode.Distance;

		// Token: 0x0400019C RID: 412
		[Save]
		public static bool NoAimbotDrop = false;
	}
}
