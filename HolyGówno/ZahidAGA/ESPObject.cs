using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000053 RID: 83
	public class ESPObject
	{
		// Token: 0x0600021E RID: 542 RVA: 0x00003818 File Offset: 0x00001A18
		public ESPObject(ESPTarget t, object o, GameObject go)
		{
			this.Target = t;
			this.Object = o;
			this.GObject = go;
		}

		// Token: 0x0400010E RID: 270
		public ESPTarget Target;

		// Token: 0x0400010F RID: 271
		public object Object;

		// Token: 0x04000110 RID: 272
		public GameObject GObject;
	}
}
