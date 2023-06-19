using System;

namespace ZahidAGA
{
	// Token: 0x0200006B RID: 107
	public static class WeaponOptions
	{
		// Token: 0x040001C2 RID: 450
		[Save]
		public static bool ShowWeaponInfo = false;

		// Token: 0x040001C3 RID: 451
		[Save]
		public static bool HeatShot = false;

		// Token: 0x040001C4 RID: 452
		[Save]
		public static float HeatShotVolume = 2f;

		// Token: 0x040001C5 RID: 453
		[Save]
		public static int TracerTime = 2;

		// Token: 0x040001C6 RID: 454
		[Save]
		public static bool Tracers = false;

		// Token: 0x040001C7 RID: 455
		public static bool RemoveHammerDelay = false;

		// Token: 0x040001C8 RID: 456
		public static bool RemoveBurstDelay = false;

		// Token: 0x040001C9 RID: 457
		public static bool InstantReload = false;

		// Token: 0x040001CA RID: 458
		[Save]
		public static bool SafeZone = false;

		// Token: 0x040001CB RID: 459
		[Save]
		public static bool Admin = false;

		// Token: 0x040001CC RID: 460
		[Save]
		public static bool DamageIndicators = false;

		// Token: 0x040001CD RID: 461
		[Save]
		public static bool CustomCrosshair = false;

		// Token: 0x040001CE RID: 462
		[Save]
		public static SerializableColor CrosshairColor = new SerializableColor(255, 0, 0);

		// Token: 0x040001CF RID: 463
		[Save]
		public static bool NoRecoil = false;

		// Token: 0x040001D0 RID: 464
		[Save]
		public static float NoRecoil1 = 0f;

		// Token: 0x040001D1 RID: 465
		[Save]
		public static float NoSpread1 = 0f;

		// Token: 0x040001D2 RID: 466
		[Save]
		public static bool NoSpread = false;

		// Token: 0x040001D3 RID: 467
		[Save]
		public static bool NoSway = false;

		// Token: 0x040001D4 RID: 468
		[Save]
		public static bool NoDrop = false;

		// Token: 0x040001D5 RID: 469
		[Save]
		public static bool RemoveReloadDelay = false;

		// Token: 0x040001D6 RID: 470
		[Save]
		public static bool OofOnDeath = false;

		// Token: 0x040001D7 RID: 471
		[Save]
		public static float OofOnDeathVol = 2f;

		// Token: 0x040001D8 RID: 472
		[Save]
		public static bool AutoReload = false;

		// Token: 0x040001D9 RID: 473
		[Save]
		public static bool EnableBulletDropPrediction = false;

		// Token: 0x040001DA RID: 474
		[Save]
		public static bool HighlightBulletDropPredictionTarget = false;

		// Token: 0x040001DB RID: 475
		[Save]
		public static bool Zoom;

		// Token: 0x040001DC RID: 476
		[Save]
		public static float ZoomValue = 16f;
	}
}
