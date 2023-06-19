using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000089 RID: 137
	public class OV_UseableMelee
	{
		// Token: 0x06000287 RID: 647 RVA: 0x00011560 File Offset: 0x0000F760
		[Override(typeof(UseableMelee), "fire", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public static void OV_fire()
		{
			OV_DamageTool.OVType = OverrideType.None;
			if (RaycastOptions.Enabled && MiscOptions.ExtendMeleeRange)
			{
				OV_DamageTool.OVType = OverrideType.SilentAimMelee;
			}
			else if (RaycastOptions.Enabled)
			{
				OV_DamageTool.OVType = OverrideType.SilentAim;
			}
			else if (MiscOptions.ExtendMeleeRange)
			{
				OV_DamageTool.OVType = OverrideType.Extended;
			}
			OverrideUtilities.CallOriginal(OptimizationVariables.MainPlayer.equipment.useable, new object[0]);
			OV_DamageTool.OVType = OverrideType.None;
		}
	}
}
