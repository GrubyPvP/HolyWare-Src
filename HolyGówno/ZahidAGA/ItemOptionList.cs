using System;
using System.Collections.Generic;

namespace ZahidAGA
{
	// Token: 0x02000055 RID: 85
	public class ItemOptionList
	{
		// Token: 0x04000127 RID: 295
		public HashSet<ushort> AddedItems = new HashSet<ushort>();

		// Token: 0x04000128 RID: 296
		public bool ItemfilterGun = true;

		// Token: 0x04000129 RID: 297
		public bool ItemfilterGunMeel = true;

		// Token: 0x0400012A RID: 298
		public bool ItemfilterAmmo = true;

		// Token: 0x0400012B RID: 299
		public bool ItemfilterMedical = true;

		// Token: 0x0400012C RID: 300
		public bool ItemfilterBackpack = true;

		// Token: 0x0400012D RID: 301
		public bool ItemfilterCharges = true;

		// Token: 0x0400012E RID: 302
		public bool ItemfilterFuel = true;

		// Token: 0x0400012F RID: 303
		public bool ItemfilterClothing = true;

		// Token: 0x04000130 RID: 304
		public bool ItemfilterFoodAndWater = true;

		// Token: 0x04000131 RID: 305
		public bool ItemfilterCustom = true;

		// Token: 0x04000132 RID: 306
		public string searchstring = "";

		// Token: 0x04000133 RID: 307
		public SerializableVector2 additemscroll = new SerializableVector2(0f, 0f);

		// Token: 0x04000134 RID: 308
		public SerializableVector2 removeitemscroll = new SerializableVector2(0f, 0f);
	}
}
