using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000066 RID: 102
	public class SerializableVector2
	{
		// Token: 0x06000234 RID: 564 RVA: 0x000039D9 File Offset: 0x00001BD9
		public SerializableVector2(float nx, float ny)
		{
			this.x = nx;
			this.y = ny;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x000039EF File Offset: 0x00001BEF
		public Vector2 ToVector2()
		{
			return new Vector2(this.x, this.y);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00003A02 File Offset: 0x00001C02
		public static implicit operator Vector2(SerializableVector2 vector)
		{
			return vector.ToVector2();
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00003A0A File Offset: 0x00001C0A
		public static implicit operator SerializableVector2(Vector2 vector)
		{
			return new SerializableVector2(vector.x, vector.y);
		}

		// Token: 0x0400018F RID: 399
		public float x;

		// Token: 0x04000190 RID: 400
		public float y;
	}
}
