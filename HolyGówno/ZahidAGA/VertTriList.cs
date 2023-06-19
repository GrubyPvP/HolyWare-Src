using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200009A RID: 154
	public class VertTriList
	{
		// Token: 0x170000BE RID: 190
		public int[] this[int index]
		{
			get
			{
				return this.list[index];
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00003F59 File Offset: 0x00002159
		public VertTriList(int[] tri, int numVerts)
		{
			this.Init(tri, numVerts);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00003F69 File Offset: 0x00002169
		public VertTriList(Mesh mesh)
		{
			this.Init(mesh.triangles, mesh.vertexCount);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000142C8 File Offset: 0x000124C8
		public void Init(int[] tri, int numVerts)
		{
			int[] array = new int[numVerts];
			for (int i = 0; i < tri.Length; i++)
			{
				array[tri[i]]++;
			}
			this.list = new int[numVerts][];
			for (int j = 0; j < array.Length; j++)
			{
				this.list[j] = new int[array[j]];
			}
			for (int k = 0; k < tri.Length; k++)
			{
				int num = tri[k];
				int[] array2 = this.list[num];
				int[] array3 = array;
				int num2 = num;
				int num3 = array3[num2] - 1;
				array3[num2] = num3;
				array2[num3] = k / 3;
			}
		}

		// Token: 0x040002C3 RID: 707
		public int[][] list;
	}
}
