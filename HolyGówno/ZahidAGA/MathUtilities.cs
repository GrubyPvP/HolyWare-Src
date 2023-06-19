using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000095 RID: 149
	public static class MathUtilities
	{
		// Token: 0x060002BE RID: 702 RVA: 0x00003EAC File Offset: 0x000020AC
		[Initializer]
		public static void GenerateRandom()
		{
			MathUtilities.Random = new Random();
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0001363C File Offset: 0x0001183C
		public static bool Intersect(Vector3 p0, Vector3 p1, Vector3 oVector, Vector3 bCenter, out Vector3 intersection)
		{
			intersection = Vector3.zero;
			Vector3 vector = p1 - p0;
			float num = Vector3.Dot(vector, oVector);
			bool result;
			if (num == 0f)
			{
				result = false;
			}
			else
			{
				float num2 = -(Vector3.Dot(p0 - bCenter, oVector) / num);
				intersection = p0 + num2 * vector;
				result = true;
			}
			return result;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0001369C File Offset: 0x0001189C
		public static Vector3 GetOrthogonalVector(Vector3 vCenter, Vector3 vPoint)
		{
			Vector3 vector = vCenter - vPoint;
			double distance = VectorUtilities.GetDistance(vCenter, vPoint);
			return vector / (float)distance;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000136C0 File Offset: 0x000118C0
		public static Vector3[] GetRectanglePoints(Vector3 playerPos, Vector3[] bCorners, Bounds bound)
		{
			Vector3 orthogonalVector = MathUtilities.GetOrthogonalVector(bound.center, playerPos);
			List<Vector3> list = new List<Vector3>();
			Vector3[] array = new Vector3[]
			{
				bCorners[0],
				bCorners[1],
				bCorners[1],
				bCorners[3],
				bCorners[3],
				bCorners[2],
				bCorners[2],
				bCorners[0],
				bCorners[4],
				bCorners[5],
				bCorners[5],
				bCorners[7],
				bCorners[7],
				bCorners[6],
				bCorners[6],
				bCorners[4],
				bCorners[0],
				bCorners[4],
				bCorners[1],
				bCorners[5],
				bCorners[2],
				bCorners[6],
				bCorners[3],
				bCorners[7]
			};
			for (int i = 0; i < 24; i += 2)
			{
				Vector3 p = array[i];
				Vector3 p2 = array[i + 1];
				Vector3 item;
				if (MathUtilities.Intersect(p, p2, orthogonalVector, bound.center, out item))
				{
					list.Add(item);
				}
			}
			Bounds bounds;
			bounds..ctor(bound.center, bound.size * 1.2f);
			for (int j = list.Count - 1; j > -1; j--)
			{
				if (!bounds.Contains(list[j]))
				{
					list.RemoveAt(j);
				}
			}
			return list.ToArray();
		}

		// Token: 0x040002B9 RID: 697
		private static readonly WebClient web = new WebClient();

		// Token: 0x040002BA RID: 698
		public static Random Random;
	}
}
