using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x0200007D RID: 125
	public static class OV_SearchForMapsInInventory
	{
		// Token: 0x06000255 RID: 597 RVA: 0x00003B1C File Offset: 0x00001D1C
		[Override(typeof(PlayerDashboardInformationUI), "searchForMapsInInventory", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_searchForMapsInInventory(ref bool enableChart, ref bool enableMap)
		{
			if (MiscOptions.GPS)
			{
				enableMap = true;
				enableChart = true;
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				true,
				true
			});
		}
	}
}
