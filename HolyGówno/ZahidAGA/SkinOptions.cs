using System;

namespace ZahidAGA
{
	// Token: 0x02000076 RID: 118
	public static class SkinOptions
	{
		// Token: 0x04000287 RID: 647
		[Save]
		public static SkinConfig SkinConfig = new SkinConfig();

		// Token: 0x04000288 RID: 648
		public static SkinOptionList SkinWeapons = new SkinOptionList(SkinType.Weapons);

		// Token: 0x04000289 RID: 649
		public static SkinOptionList SkinClothesShirts = new SkinOptionList(SkinType.Shirts);

		// Token: 0x0400028A RID: 650
		public static SkinOptionList SkinClothesPants = new SkinOptionList(SkinType.Pants);

		// Token: 0x0400028B RID: 651
		public static SkinOptionList SkinClothesBackpack = new SkinOptionList(SkinType.Backpacks);

		// Token: 0x0400028C RID: 652
		public static SkinOptionList SkinClothesVest = new SkinOptionList(SkinType.Vests);

		// Token: 0x0400028D RID: 653
		public static SkinOptionList SkinClothesHats = new SkinOptionList(SkinType.Hats);

		// Token: 0x0400028E RID: 654
		public static SkinOptionList SkinClothesMask = new SkinOptionList(SkinType.Masks);

		// Token: 0x0400028F RID: 655
		public static SkinOptionList SkinClothesGlasses = new SkinOptionList(SkinType.Glasses);
	}
}
