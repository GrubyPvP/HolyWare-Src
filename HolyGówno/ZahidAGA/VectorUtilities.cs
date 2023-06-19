using System;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000A5 RID: 165
	public static class VectorUtilities
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x0000409A File Offset: 0x0000229A
		public static double GetDistance(Vector3 point)
		{
			return VectorUtilities.GetDistance(OptimizationVariables.MainCam.transform.position, point);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000040B1 File Offset: 0x000022B1
		public static float GetDistance2(Vector3 endpos)
		{
			return (float)Math.Round((double)Vector3.Distance(Player.player.look.aim.position, endpos));
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x000156C8 File Offset: 0x000138C8
		public static double GetDistance(Vector3 start, Vector3 point)
		{
			Vector3 vector;
			vector.x = start.x - point.x;
			vector.y = start.y - point.y;
			vector.z = start.z - point.z;
			return Math.Sqrt((double)(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z));
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00015740 File Offset: 0x00013940
		public static float FOVRadius(float fov)
		{
			float fieldOfView = OptimizationVariables.MainCam.fieldOfView;
			if (GraphicsSettings.scopeQuality != null)
			{
				UseableGun useableGun = Player.player.equipment.useable as UseableGun;
				if (useableGun && useableGun.isAiming && Player.player.look.scopeCamera.enabled)
				{
					fieldOfView = Player.player.look.scopeCamera.fieldOfView;
				}
			}
			return (float)(Math.Tan((double)fov * 0.017453292519943295 / 2.0) / Math.Tan((double)fieldOfView * 0.017453292519943295 / 2.0) * (double)Screen.height);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x000040D4 File Offset: 0x000022D4
		public static double GetMagnitude(Vector3 vector)
		{
			return Math.Sqrt((double)(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z));
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00004105 File Offset: 0x00002305
		public static Vector3 Normalize(Vector3 vector)
		{
			return vector / (float)VectorUtilities.GetMagnitude(vector);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x000157F0 File Offset: 0x000139F0
		public static double GetAngleDelta(Vector3 mainPos, Vector3 forward, Vector3 target)
		{
			Vector3 vector = VectorUtilities.Normalize(target - mainPos);
			return Math.Atan2(VectorUtilities.GetMagnitude(Vector3.Cross(vector, forward)), (double)Vector3.Dot(vector, forward)) * 57.29577951308232;
		}
	}
}
