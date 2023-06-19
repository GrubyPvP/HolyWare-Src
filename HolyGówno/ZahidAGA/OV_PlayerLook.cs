using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000082 RID: 130
	public class OV_PlayerLook
	{
		// Token: 0x06000274 RID: 628 RVA: 0x00003D12 File Offset: 0x00001F12
		[Override(typeof(PlayerLook), "onDamaged", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public static void OV_onDamaged(byte damage)
		{
			if (!MiscOptions.NoFlinch)
			{
				OverrideUtilities.CallOriginal(null, new object[]
				{
					damage
				});
			}
		}
	}
}
