using System;
using System.Linq;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000092 RID: 146
	public static class LocationUtilities
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x000133A4 File Offset: 0x000115A4
		public static LocationNode GetClosestLocation(Vector3 pos)
		{
			double num = 1337420.0;
			LocationNode result = null;
			foreach (LocationNode locationNode in (from n in LevelNodes.nodes
			where n.type == 0
			select (LocationNode)n).ToArray<LocationNode>())
			{
				double distance = VectorUtilities.GetDistance(pos, locationNode.point);
				if (distance < num)
				{
					num = distance;
					result = locationNode;
				}
			}
			return result;
		}
	}
}
