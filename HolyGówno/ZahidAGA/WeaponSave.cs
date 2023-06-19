using System;

namespace ZahidAGA
{
	// Token: 0x0200005A RID: 90
	public class WeaponSave
	{
		// Token: 0x06000225 RID: 549 RVA: 0x00003895 File Offset: 0x00001A95
		public WeaponSave(ushort WeaponID, int SkinID)
		{
			this.WeaponID = WeaponID;
			this.SkinID = SkinID;
		}

		// Token: 0x04000143 RID: 323
		public ushort WeaponID;

		// Token: 0x04000144 RID: 324
		public int SkinID;
	}
}
