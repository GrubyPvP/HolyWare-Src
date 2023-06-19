using System;
using System.Collections.Generic;

namespace ZahidAGA
{
	// Token: 0x02000059 RID: 89
	public class SkinOptionList
	{
		// Token: 0x06000224 RID: 548 RVA: 0x00003874 File Offset: 0x00001A74
		public SkinOptionList(SkinType Type)
		{
			this.Type = Type;
		}

		// Token: 0x04000141 RID: 321
		public SkinType Type = SkinType.Weapons;

		// Token: 0x04000142 RID: 322
		public HashSet<Skin> Skins = new HashSet<Skin>();
	}
}
