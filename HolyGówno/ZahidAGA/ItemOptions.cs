using System;

namespace ZahidAGA
{
	// Token: 0x0200006E RID: 110
	public static class ItemOptions
	{
		// Token: 0x040001E6 RID: 486
		[Save]
		public static bool AutoItemPickup = false;

		// Token: 0x040001E7 RID: 487
		[Save]
		public static bool AutoItemPickupFiltresiz = false;

		// Token: 0x040001E8 RID: 488
		[Save]
		public static float ItemPickupDelayFiltresizDelay = 1f;

		// Token: 0x040001E9 RID: 489
		[Save]
		public static int ItemPickupDelayFiltresizRange = 20;

		// Token: 0x040001EA RID: 490
		[Save]
		public static float ItemPickupDelay = 1f;

		// Token: 0x040001EB RID: 491
		[Save]
		public static int ItemPickupRange = 20;

		// Token: 0x040001EC RID: 492
		[Save]
		public static ItemOptionList ItemFilterOptions = new ItemOptionList();

		// Token: 0x040001ED RID: 493
		[Save]
		public static ItemOptionList ItemESPOptions = new ItemOptionList();
	}
}
