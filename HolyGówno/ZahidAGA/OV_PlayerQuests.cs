using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000010 RID: 16
	public class OV_PlayerQuests
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x00002C90 File Offset: 0x00000E90
		[Override(typeof(PlayerQuests), "isMemberOfSameGroupAs", BindingFlags.Instance | BindingFlags.Public, 0)]
		public bool OV_isMemberOfSameGroupAs(Player player)
		{
			return ESPOptions.ShowMap;
		}
	}
}
