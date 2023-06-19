using System;
using System.Collections.Generic;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000068 RID: 104
	public static class RaycastOptions
	{
		// Token: 0x0400019D RID: 413
		[Save]
		public static bool Enabled = false;

		// Token: 0x0400019E RID: 414
		[Save]
		public static bool SlientInfo = false;

		// Token: 0x0400019F RID: 415
		[Save]
		public static bool SlientCizgi = false;

		// Token: 0x040001A0 RID: 416
		[Save]
		public static bool TargetPlayers = false;

		// Token: 0x040001A1 RID: 417
		[Save]
		public static bool TargetZombies = false;

		// Token: 0x040001A2 RID: 418
		[Save]
		public static bool TargetSentries = false;

		// Token: 0x040001A3 RID: 419
		[Save]
		public static bool TargetBeds = false;

		// Token: 0x040001A4 RID: 420
		[Save]
		public static bool TargetAnimal = false;

		// Token: 0x040001A5 RID: 421
		[Save]
		public static bool TargetClaimFlags = false;

		// Token: 0x040001A6 RID: 422
		[Save]
		public static bool TargetVehicles = false;

		// Token: 0x040001A7 RID: 423
		[Save]
		public static bool TargetStorage = false;

		// Token: 0x040001A8 RID: 424
		[Save]
		public static bool ExpandHitboxes = false;

		// Token: 0x040001A9 RID: 425
		[Save]
		public static bool Players = false;

		// Token: 0x040001AA RID: 426
		[Save]
		public static bool NoShootthroughthewalls = false;

		// Token: 0x040001AB RID: 427
		[Save]
		public static bool AlwaysHitHead = false;

		// Token: 0x040001AC RID: 428
		[Save]
		public static bool UseRandomLimb = false;

		// Token: 0x040001AD RID: 429
		[Save]
		public static bool UseCustomLimb = false;

		// Token: 0x040001AE RID: 430
		[Save]
		public static bool UseTargetMaterial = false;

		// Token: 0x040001AF RID: 431
		[Save]
		public static bool UseModifiedVector = false;

		// Token: 0x040001B0 RID: 432
		[Save]
		public static bool Targetİnfo = false;

		// Token: 0x040001B1 RID: 433
		[Save]
		public static bool EnablePlayerSelection = false;

		// Token: 0x040001B2 RID: 434
		[Save]
		public static bool OnlyShootAtSelectedPlayer = false;

		// Token: 0x040001B3 RID: 435
		[Save]
		public static float SelectedFOV = 10f;

		// Token: 0x040001B4 RID: 436
		[Save]
		public static bool SilentAimUseFOV = false;

		// Token: 0x040001B5 RID: 437
		[Save]
		public static bool ShowSilentAimUseFOV = false;

		// Token: 0x040001B6 RID: 438
		[Save]
		public static bool ShowAimUseFOV = false;

		// Token: 0x040001B7 RID: 439
		[Save]
		public static float SilentAimFOV = 20f;

		// Token: 0x040001B8 RID: 440
		[Save]
		public static HashSet<TargetPriority> Targets = new HashSet<TargetPriority>();

		// Token: 0x040001B9 RID: 441
		[Save]
		public static TargetPriority Target = TargetPriority.Players;

		// Token: 0x040001BA RID: 442
		[Save]
		public static EPhysicsMaterial TargetMaterial = 20;

		// Token: 0x040001BB RID: 443
		[Save]
		public static ELimb TargetLimb = 13;

		// Token: 0x040001BC RID: 444
		[Save]
		public static SerializableVector TargetRagdoll = new SerializableVector(0f, 10f, 0f);
	}
}
