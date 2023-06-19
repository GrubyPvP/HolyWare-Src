using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000078 RID: 120
	public static class OV_DamageTool
	{
		// Token: 0x06000249 RID: 585 RVA: 0x00003AD3 File Offset: 0x00001CD3
		[Override(typeof(DamageTool), "raycast", BindingFlags.Static | BindingFlags.Public, 1)]
		public static RaycastInfo OV_raycast(Ray ray, float range, int mask, Player ignorePlayer = null)
		{
			return OV_DamageTool.SetupRaycast(ray, range, mask, ignorePlayer);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000FD74 File Offset: 0x0000DF74
		public static RaycastInfo SetupRaycast(Ray ray, float range, int mask, Player ignorePlayer = null)
		{
			switch (OV_DamageTool.OVType)
			{
			case OverrideType.Extended:
				return RaycastUtilities.GenerateOriginalRaycast(ray, range, mask, null);
			case OverrideType.PlayerHit:
				for (int i = 0; i < Provider.clients.Count; i++)
				{
					if (VectorUtilities.GetDistance(Player.player.transform.position, Provider.clients[i].player.transform.position) <= 15.5)
					{
						RaycastInfo result;
						RaycastUtilities.GenerateRaycast(out result);
						return result;
					}
				}
				break;
			case OverrideType.SilentAim:
			{
				RaycastInfo result2;
				if (!RaycastUtilities.GenerateRaycast(out result2))
				{
					return RaycastUtilities.GenerateOriginalRaycast(ray, range, mask, null);
				}
				return result2;
			}
			case OverrideType.SilentAimMelee:
			{
				RaycastInfo result3;
				if (!RaycastUtilities.GenerateRaycast(out result3))
				{
					return RaycastUtilities.GenerateOriginalRaycast(ray, Mathf.Max(5.5f, range), mask, null);
				}
				return result3;
			}
			}
			return RaycastUtilities.GenerateOriginalRaycast(ray, range, mask, ignorePlayer);
		}

		// Token: 0x04000290 RID: 656
		public static OverrideType OVType;
	}
}
