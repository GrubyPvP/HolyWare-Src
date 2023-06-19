using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000065 RID: 101
	public class SerializableVector
	{
		// Token: 0x06000231 RID: 561 RVA: 0x0000399B File Offset: 0x00001B9B
		public SerializableVector(float nx, float ny, float nz)
		{
			this.x = nx;
			this.y = ny;
			this.z = nz;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000039B8 File Offset: 0x00001BB8
		public Vector3 ToVector()
		{
			return new Vector3(this.x, this.y, this.z);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x000039D1 File Offset: 0x00001BD1
		public static implicit operator Vector3(SerializableVector vector)
		{
			return vector.ToVector();
		}

		// Token: 0x0400018C RID: 396
		public float x;

		// Token: 0x0400018D RID: 397
		public float y;

		// Token: 0x0400018E RID: 398
		public float z;
	}
}
