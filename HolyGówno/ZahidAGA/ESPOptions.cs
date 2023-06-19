using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000072 RID: 114
	public static class ESPOptions
	{
		// Token: 0x04000250 RID: 592
		[Save]
		public static bool Enabled = true;

		// Token: 0x04000251 RID: 593
		[Save]
		public static bool ChamsEnabled = false;

		// Token: 0x04000252 RID: 594
		[Save]
		public static bool Tran = false;

		// Token: 0x04000253 RID: 595
		[Save]
		public static float xxx = 50f;

		// Token: 0x04000254 RID: 596
		[Save]
		public static float yyy = 50f;

		// Token: 0x04000255 RID: 597
		[Save]
		public static float zzz = 50f;

		// Token: 0x04000256 RID: 598
		[Save]
		public static float bnmk = 50f;

		// Token: 0x04000257 RID: 599
		[Save]
		public static bool SelfChams = false;

		// Token: 0x04000258 RID: 600
		[Save]
		public static float ChamsTime = 2f;

		// Token: 0x04000259 RID: 601
		[Save]
		public static bool ChamsFlat = false;

		// Token: 0x0400025A RID: 602
		[Save]
		public static bool RGBChams = false;

		// Token: 0x0400025B RID: 603
		[Save]
		public static bool SpinBotOyuncu = false;

		// Token: 0x0400025C RID: 604
		[Save]
		public static bool SpinBotAraç = false;

		// Token: 0x0400025D RID: 605
		[Save]
		public static bool AddFriend = true;

		// Token: 0x0400025E RID: 606
		[Save]
		public static bool ShowVanishPlayers = false;

		// Token: 0x0400025F RID: 607
		[Save]
		public static bool ShowVehiclePlayers = false;

		// Token: 0x04000260 RID: 608
		[Save]
		public static bool ShowToolTipWindow = false;

		// Token: 0x04000261 RID: 609
		[Save]
		public static bool ShowCoordinates = false;

		// Token: 0x04000262 RID: 610
		[Save]
		public static bool ShowMap = false;

		// Token: 0x04000263 RID: 611
		public static bool ShowMap2 = false;

		// Token: 0x04000264 RID: 612
		[Save]
		public static ESPVisual[] VisualOptions = Enumerable.Repeat<ESPVisual>(new ESPVisual
		{
			Enabled = false,
			Labels = true,
			Boxes = false,
			ShowName = true,
			ShowDistance = true,
			ShowAngle = false,
			TwoDimensional = false,
			Glow = false,
			InfiniteDistance = false,
			LineToObject = false,
			TextScaling = false,
			UseObjectCap = false,
			CustomTextColor = false,
			Distance = 500f,
			Location = LabelLocation.BottomMiddle,
			FixedTextSize = 11,
			MinTextSize = 8,
			MaxTextSize = 11,
			MinTextSizeDistance = 800f,
			BorderStrength = 0,
			ObjectCap = 24
		}, Enum.GetValues(typeof(ESPTarget)).Length).ToArray<ESPVisual>();

		// Token: 0x04000265 RID: 613
		[Save]
		public static Dictionary<ESPTarget, int> PriorityTable = Enum.GetValues(typeof(ESPTarget)).Cast<ESPTarget>().ToDictionary((ESPTarget x) => x, (ESPTarget x) => (int)x);

		// Token: 0x04000266 RID: 614
		[Save]
		public static bool ShowPlayerWeapon = false;

		// Token: 0x04000267 RID: 615
		public static bool showhotbar = false;

		// Token: 0x04000268 RID: 616
		[Save]
		public static bool ShowPlayerVehicle = false;

		// Token: 0x04000269 RID: 617
		[Save]
		public static bool ArkadaşRengi = true;

		// Token: 0x0400026A RID: 618
		[Save]
		public static bool AdminRengi = true;

		// Token: 0x0400026B RID: 619
		[Save]
		public static bool UsePlayerGroup = true;

		// Token: 0x0400026C RID: 620
		[Save]
		public static SerializableColor SameGroupColor = Color.green.ToSerializableColor();

		// Token: 0x0400026D RID: 621
		[Save]
		public static bool FilterItems = false;

		// Token: 0x0400026E RID: 622
		[Save]
		public static bool ShowVehicleFuel;

		// Token: 0x0400026F RID: 623
		[Save]
		public static bool ShowVehicleHealth;

		// Token: 0x04000270 RID: 624
		[Save]
		public static bool ShowVehicleLocked;

		// Token: 0x04000271 RID: 625
		[Save]
		public static bool FilterVehicleLocked;

		// Token: 0x04000272 RID: 626
		[Save]
		public static bool ShowStorageItem;

		// Token: 0x04000273 RID: 627
		[Save]
		public static bool ShowSentryItem;

		// Token: 0x04000274 RID: 628
		[Save]
		public static bool ShowClaimed;

		// Token: 0x04000275 RID: 629
		[Save]
		public static bool ClaimİDStorage;

		// Token: 0x04000276 RID: 630
		[Save]
		public static bool ClaimNameStorage;

		// Token: 0x04000277 RID: 631
		[Save]
		public static bool ClaimİDCar;

		// Token: 0x04000278 RID: 632
		[Save]
		public static bool ClaimNameCar;

		// Token: 0x04000279 RID: 633
		[Save]
		public static bool ClaimİDBed;

		// Token: 0x0400027A RID: 634
		[Save]
		public static bool ClaimNameBed;

		// Token: 0x0400027B RID: 635
		[Save]
		public static bool ShowGeneratorFuel;

		// Token: 0x0400027C RID: 636
		[Save]
		public static bool ShowGeneratorPowered;
	}
}
