using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x0200007E RID: 126
	public class OV_PlayerEquipment
	{
		// Token: 0x06000256 RID: 598 RVA: 0x00003B4B File Offset: 0x00001D4B
		[Override(typeof(PlayerEquipment), "punch", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_punch(EPlayerPunch p)
		{
			if (MiscOptions.PunchSilentAim)
			{
				OV_DamageTool.OVType = OverrideType.PlayerHit;
			}
			OverrideUtilities.CallOriginal(OptimizationVariables.MainPlayer.equipment, new object[]
			{
				p
			});
			OV_DamageTool.OVType = OverrideType.None;
		}

		// Token: 0x04000294 RID: 660
		public static bool WasPunching;

		// Token: 0x04000295 RID: 661
		public static uint CurrSim;
	}
}
