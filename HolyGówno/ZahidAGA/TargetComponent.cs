using System;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000009 RID: 9
	[Component]
	[SpyComponent]
	public class TargetComponent : MonoBehaviour
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x00006FE4 File Offset: 0x000051E4
		public void OnGUI()
		{
			if (WeaponComponent.MainCamera == null)
			{
				TargetComponent.MainCamera = Camera.main;
			}
			if (Event.current.type == 7 && DrawUtilities.ShouldRun() && !G.BeingSpied && RaycastOptions.Enabled)
			{
				ItemGunAsset itemGunAsset = OptimizationVariables.MainPlayer.equipment.asset as ItemGunAsset;
				float range = (itemGunAsset != null) ? itemGunAsset.range : 15.5f;
				GameObject gameObject;
				Vector3 vector;
				RaycastUtilities.GetTargetObject(RaycastUtilities.Objects, out gameObject, out vector, range);
				string content = string.Format("<size=13>Target: [{0}] {1}</size>", VectorUtilities.GetDistance2(gameObject.transform.position), gameObject.name);
				DrawUtilities.DrawLabel(Font.CreateDynamicFontFromOSFont("Arial", 11), LabelLocation.MiddleLeft, new Vector2((float)(Screen.width - 20), (float)(Screen.height / 2 + 45)), content, Color.green, Color.black, 1, null, 12);
				Vector3 vector2;
				vector2..ctor(gameObject.transform.position.x, gameObject.transform.position.y + 1.9f, gameObject.transform.position.z);
				Vector3 vector3 = TargetComponent.MainCamera.WorldToScreenPoint(vector2);
				ESPVariables.DrawBuffer2.Enqueue(new ESPBox2
				{
					Color = Color.cyan,
					Vertices = new Vector2[]
					{
						new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)),
						new Vector2(vector3.x, (float)Screen.height - vector3.y)
					}
				});
			}
		}

		// Token: 0x0400002C RID: 44
		public static Camera MainCamera;
	}
}
