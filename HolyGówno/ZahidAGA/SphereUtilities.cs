using System;
using System.Collections.Generic;
using System.Linq;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000A3 RID: 163
	public static class SphereUtilities
	{
		// Token: 0x060002F0 RID: 752 RVA: 0x00015594 File Offset: 0x00013794
		public static bool GetRaycast(GameObject Target, Vector3 StartPos, out Vector3 Point)
		{
			Point = Vector3.zero;
			bool result;
			if (Target == null)
			{
				result = false;
			}
			else
			{
				int layer = Target.layer;
				Target.layer = 24;
				RaycastComponent Component = Target.GetComponent<RaycastComponent>();
				if (VectorUtilities.GetDistance(Target.transform.position, StartPos) <= 15.5)
				{
					Point = OptimizationVariables.MainPlayer.transform.position;
					result = true;
				}
				else
				{
					IEnumerable<Vector3> vertices = Component.Sphere.GetComponent<MeshCollider>().sharedMesh.vertices;
					Func<Vector3, Vector3> selector;
					Func<Vector3, Vector3> <>9__0;
					if ((selector = <>9__0) == null)
					{
						selector = (<>9__0 = ((Vector3 v) => Component.Sphere.transform.TransformPoint(v)));
					}
					foreach (Vector3 vector in vertices.Select(selector).ToArray<Vector3>())
					{
						Vector3 vector2 = VectorUtilities.Normalize(vector - StartPos);
						double distance = VectorUtilities.GetDistance(StartPos, vector);
						if (!Physics.Raycast(StartPos, vector2, (float)distance + 0.5f, RayMasks.DAMAGE_CLIENT))
						{
							Target.layer = layer;
							Point = vector;
							return true;
						}
					}
					Target.layer = layer;
					result = false;
				}
			}
			return result;
		}
	}
}
