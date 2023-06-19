using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000087 RID: 135
	public class OV_UseableBarricade
	{
		// Token: 0x0600027E RID: 638 RVA: 0x00010CB0 File Offset: 0x0000EEB0
		[Override(typeof(UseableBarricade), "checkSpace", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public bool OV_checkSpace()
		{
			bool result;
			if (!MiscOptions.BuildObs || G.BeingSpied)
			{
				result = (bool)OverrideUtilities.CallOriginal(this, Array.Empty<object>());
			}
			else
			{
				OverrideUtilities.CallOriginal(this, Array.Empty<object>());
				RaycastHit raycastHit;
				if ((Vector3)OV_UseableBarricade.pointField.GetValue(this) != Vector3.zero && !MiscOptions.Freecam)
				{
					if (MiscOptions.epos)
					{
						OV_UseableBarricade.pointField.SetValue(this, (Vector3)OV_UseableBarricade.pointField.GetValue(this) + MiscOptions.pos);
					}
					result = true;
				}
				else if (Physics.Raycast(new Ray(OptimizationVariables.MainCam.transform.position, OptimizationVariables.MainCam.transform.forward), ref raycastHit, 20f, RayMasks.DAMAGE_CLIENT))
				{
					Vector3 vector = raycastHit.point;
					if (MiscOptions.epos)
					{
						vector += MiscOptions.pos;
					}
					OV_UseableBarricade.pointField.SetValue(this, vector);
					result = true;
				}
				else
				{
					Vector3 vector2 = OptimizationVariables.MainCam.transform.position + OptimizationVariables.MainCam.transform.forward * 7f;
					if (MiscOptions.epos)
					{
						vector2 += MiscOptions.pos;
					}
					OV_UseableBarricade.pointField.SetValue(this, vector2);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x040002B2 RID: 690
		public static FieldInfo pointField = typeof(UseableBarricade).GetField("point", ReflectionVariables.publicInstance);
	}
}
