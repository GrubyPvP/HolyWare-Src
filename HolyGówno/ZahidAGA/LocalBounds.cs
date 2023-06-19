using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000056 RID: 86
	public class LocalBounds
	{
		// Token: 0x06000221 RID: 545 RVA: 0x00003835 File Offset: 0x00001A35
		public LocalBounds(Vector3 po, Vector3 e)
		{
			this.PosOffset = po;
			this.Extents = e;
		}

		// Token: 0x04000135 RID: 309
		public Vector3 PosOffset;

		// Token: 0x04000136 RID: 310
		public Vector3 Extents;
	}
}
