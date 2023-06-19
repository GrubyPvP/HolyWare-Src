using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200008A RID: 138
	public class OV_UseableStructure
	{
		// Token: 0x06000289 RID: 649 RVA: 0x000115CC File Offset: 0x0000F7CC
		[Override(typeof(UseableStructure), "checkSpace", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public bool OV_checkSpace()
		{
			if (!MiscOptions.BuildinObstacles || G.BeingSpied)
			{
				return (bool)OverrideUtilities.CallOriginal(this, new object[0]);
			}
			OverrideUtilities.CallOriginal(this, new object[0]);
			if ((Vector3)OV_UseableStructure.pointField.GetValue(this) != Vector3.zero && !MiscOptions.Freecam)
			{
				if (MiscOptions.epos)
				{
					OV_UseableStructure.pointField.SetValue(this, (Vector3)OV_UseableStructure.pointField.GetValue(this) + MiscOptions.pos);
				}
				return true;
			}
			RaycastHit raycastHit;
			if (Physics.Raycast(new Ray(OptimizationVariables.MainCam.transform.position, OptimizationVariables.MainCam.transform.forward), ref raycastHit, 20f, RayMasks.DAMAGE_CLIENT))
			{
				Vector3 vector = raycastHit.point;
				if (MiscOptions.epos)
				{
					vector += MiscOptions.pos;
				}
				OV_UseableStructure.pointField.SetValue(this, vector);
				return true;
			}
			Vector3 vector2 = OptimizationVariables.MainCam.transform.position + OptimizationVariables.MainCam.transform.forward * 7f;
			if (MiscOptions.epos)
			{
				vector2 += MiscOptions.pos;
			}
			OV_UseableStructure.pointField.SetValue(this, vector2);
			return true;
		}

		// Token: 0x040002B4 RID: 692
		public static FieldInfo pointField = typeof(UseableStructure).GetField("point", ReflectionVariables.publicInstance);
	}
}
