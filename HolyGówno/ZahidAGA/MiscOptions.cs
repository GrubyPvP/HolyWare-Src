using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200006F RID: 111
	public static class MiscOptions
	{
		// Token: 0x040001EE RID: 494
		[Save]
		public static bool VehicleRigibody;

		// Token: 0x040001EF RID: 495
		[Save]
		public static bool ShowVanish;

		// Token: 0x040001F0 RID: 496
		[Save]
		public static bool Adam;

		// Token: 0x040001F1 RID: 497
		[Save]
		public static bool Adam2;

		// Token: 0x040001F2 RID: 498
		public static bool spynofity;

		// Token: 0x040001F3 RID: 499
		[Save]
		public static bool fovoç1 = false;

		// Token: 0x040001F4 RID: 500
		[Save]
		public static float fovoç2 = 90f;

		// Token: 0x040001F5 RID: 501
		[Save]
		public static bool AllOnMap = false;

		// Token: 0x040001F6 RID: 502
		[Save]
		public static bool BuildObs;

		// Token: 0x040001F7 RID: 503
		public static bool water;

		// Token: 0x040001F8 RID: 504
		[Save]
		public static bool ChatGlobal = true;

		// Token: 0x040001F9 RID: 505
		[Save]
		public static bool ChatArea = false;

		// Token: 0x040001FA RID: 506
		[Save]
		public static bool ChatGroup = false;

		// Token: 0x040001FB RID: 507
		[Save]
		public static bool ChatSay = false;

		// Token: 0x040001FC RID: 508
		public static Vector3 pos;

		// Token: 0x040001FD RID: 509
		public static bool PanicMode = false;

		// Token: 0x040001FE RID: 510
		[Save]
		public static bool hang = false;

		// Token: 0x040001FF RID: 511
		[Save]
		public static bool PunchSilentAim = false;

		// Token: 0x04000200 RID: 512
		public static float RunspeedMult = 5f;

		// Token: 0x04000201 RID: 513
		public static float JumpMult = 10f;

		// Token: 0x04000202 RID: 514
		public static string UISkin = "";

		// Token: 0x04000203 RID: 515
		[Save]
		public static bool FastSell;

		// Token: 0x04000204 RID: 516
		[Save]
		public static bool FastBuy;

		// Token: 0x04000205 RID: 517
		[Save]
		public static int FastSellCount = 5;

		// Token: 0x04000206 RID: 518
		[Save]
		public static bool EnVehicle = false;

		// Token: 0x04000207 RID: 519
		[Save]
		public static bool BuildinObstacles = false;

		// Token: 0x04000208 RID: 520
		[Save]
		public static bool FToplama = false;

		// Token: 0x04000209 RID: 521
		[Save]
		public static bool NoFlash = false;

		// Token: 0x0400020A RID: 522
		[Save]
		public static bool PunchAura = false;

		// Token: 0x0400020B RID: 523
		[Save]
		public static bool NoCloud = false;

		// Token: 0x0400020C RID: 524
		[Save]
		public static bool NoGrass = true;

		// Token: 0x0400020D RID: 525
		[Save]
		public static bool GPS = false;

		// Token: 0x0400020E RID: 526
		[Save]
		public static bool NoSnow = false;

		// Token: 0x0400020F RID: 527
		[Save]
		public static bool IsRussian = false;

		// Token: 0x04000210 RID: 528
		[Save]
		public static bool IsEnglish = true;

		// Token: 0x04000211 RID: 529
		[Save]
		public static bool NoRain = false;

		// Token: 0x04000212 RID: 530
		[Save]
		public static bool banbypass = false;

		// Token: 0x04000213 RID: 531
		[Save]
		public static bool NoFlinch = false;

		// Token: 0x04000214 RID: 532
		[Save]
		public static bool NoGrayscale = false;

		// Token: 0x04000215 RID: 533
		[Save]
		public static bool CustomSalvageTime = false;

		// Token: 0x04000216 RID: 534
		[Save]
		public static float SalvageTime = 0.2f;

		// Token: 0x04000217 RID: 535
		[Save]
		public static bool SetTimeEnabled = false;

		// Token: 0x04000218 RID: 536
		[Save]
		public static float Time = 0.4f;

		// Token: 0x04000219 RID: 537
		[Save]
		public static bool SlowFall = false;

		// Token: 0x0400021A RID: 538
		[Save]
		public static bool AirStick = false;

		// Token: 0x0400021B RID: 539
		[Save]
		public static bool Compass = false;

		// Token: 0x0400021C RID: 540
		[Save]
		public static bool Bones = false;

		// Token: 0x0400021D RID: 541
		[Save]
		public static bool ShowPlayersOnMap = false;

		// Token: 0x0400021E RID: 542
		[Save]
		public static bool NightVision = false;

		// Token: 0x0400021F RID: 543
		[Save]
		public static bool CIVILIAN = false;

		// Token: 0x04000220 RID: 544
		[Save]
		public static bool HEADLAMP = false;

		// Token: 0x04000221 RID: 545
		public static bool WasNightVision = false;

		// Token: 0x04000222 RID: 546
		[Save]
		public static string SpamText = "HolyWare.cc";

		// Token: 0x04000223 RID: 547
		[Save]
		public static bool Spam = false;

		// Token: 0x04000224 RID: 548
		[Save]
		public static string NickName = "";

		// Token: 0x04000225 RID: 549
		[Save]
		public static string Password = "";

		// Token: 0x04000226 RID: 550
		[Save]
		public static bool SpammerEnabled = false;

		// Token: 0x04000227 RID: 551
		[Save]
		public static int SpammerDelay = 3000;

		// Token: 0x04000228 RID: 552
		[Save]
		public static bool VehicleFly = false;

		// Token: 0x04000229 RID: 553
		[Save]
		public static bool VehicleUseMaxSpeed = false;

		// Token: 0x0400022A RID: 554
		[Save]
		public static bool VehicleInfo = false;

		// Token: 0x0400022B RID: 555
		[Save]
		public static float SpeedMultiplier = 0.85f;

		// Token: 0x0400022C RID: 556
		[Save]
		public static bool ExtendMeleeRange;

		// Token: 0x0400022D RID: 557
		[Save]
		public static float MeleeRangeExtension = 15.5f;

		// Token: 0x0400022E RID: 558
		public static bool NoMovementVerification = false;

		// Token: 0x0400022F RID: 559
		[Save]
		public static bool AlwaysCheckMovementVerification = false;

		// Token: 0x04000230 RID: 560
		public static Player SpectatedPlayer;

		// Token: 0x04000231 RID: 561
		[Save]
		public static bool PlayerFlight = false;

		// Token: 0x04000232 RID: 562
		[Save]
		public static bool RunspeedMult2 = false;

		// Token: 0x04000233 RID: 563
		[Save]
		public static bool JumpMult2 = false;

		// Token: 0x04000234 RID: 564
		[Save]
		public static float FlightSpeedMultiplier = 1f;

		// Token: 0x04000235 RID: 565
		public static bool Freecam = false;

		// Token: 0x04000236 RID: 566
		public static bool OtoKosma = false;

		// Token: 0x04000237 RID: 567
		[Save]
		public static HashSet<ulong> Friends = new HashSet<ulong>();

		// Token: 0x04000238 RID: 568
		[Save]
		public static int SCrashMethod = 1;

		// Token: 0x04000239 RID: 569
		[Save]
		public static int AntiSpyMethod = 0;

		// Token: 0x0400023A RID: 570
		[Save]
		public static string AntiSpyPath = "";

		// Token: 0x0400023B RID: 571
		public static string AntiSpyPath2 = "";

		// Token: 0x0400023C RID: 572
		[Save]
		public static bool AlertOnSpy = true;

		// Token: 0x0400023D RID: 573
		[Save]
		public static bool EnableDistanceCrash = false;

		// Token: 0x0400023E RID: 574
		[Save]
		public static float CrashDistance = 100f;

		// Token: 0x0400023F RID: 575
		[Save]
		public static bool CrashByName = false;

		// Token: 0x04000240 RID: 576
		[Save]
		public static List<string> CrashWords = new List<string>();

		// Token: 0x04000241 RID: 577
		[Save]
		public static List<string> CrashIDs = new List<string>();

		// Token: 0x04000242 RID: 578
		[Save]
		public static bool NearbyItemRaycast = false;

		// Token: 0x04000243 RID: 579
		[Save]
		public static bool IncreaseNearbyItemDistance = false;

		// Token: 0x04000244 RID: 580
		[Save]
		public static float NearbyItemDistance = 15f;

		// Token: 0x04000245 RID: 581
		[Save]
		public static bool ConnectKick = false;

		// Token: 0x04000246 RID: 582
		[Save]
		public static bool epos;

		// Token: 0x04000247 RID: 583
		public static float Altitude;
	}
}
