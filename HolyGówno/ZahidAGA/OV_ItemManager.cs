using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200007A RID: 122
	public static class OV_ItemManager
	{
		// Token: 0x0600024F RID: 591 RVA: 0x0000FEEC File Offset: 0x0000E0EC
		[Override(typeof(ItemManager), "getItemsInRadius", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_getItemsInRadius(Vector3 center, float sqrRadius, List<RegionCoordinate> search, List<InteractableItem> result)
		{
			if (MiscOptions.IncreaseNearbyItemDistance)
			{
				OverrideUtilities.CallOriginal(null, new object[]
				{
					center,
					20,
					search,
					result
				});
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				center,
				sqrRadius,
				search,
				result
			});
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000FF50 File Offset: 0x0000E150
		[Override(typeof(ItemManager), "findSimulatedItemsInRadius", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_findSimulatedItemsInRadius(Vector3 center, float sqrRadius, List<InteractableItem> result)
		{
			if (MiscOptions.IncreaseNearbyItemDistance)
			{
				OverrideUtilities.CallOriginal(null, new object[]
				{
					center,
					20,
					result
				});
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				center,
				sqrRadius,
				result
			});
		}
	}
}
