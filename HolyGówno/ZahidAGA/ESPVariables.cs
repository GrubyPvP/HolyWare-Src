using System;
using System.Collections.Generic;

namespace ZahidAGA
{
	// Token: 0x020000A7 RID: 167
	public class ESPVariables
	{
		// Token: 0x040002E1 RID: 737
		public static List<ESPObject> Objects = new List<ESPObject>();

		// Token: 0x040002E2 RID: 738
		public static Queue<ESPBox> DrawBuffer = new Queue<ESPBox>();

		// Token: 0x040002E3 RID: 739
		public static Queue<ESPBox2> DrawBuffer2 = new Queue<ESPBox2>();

		// Token: 0x040002E4 RID: 740
		public static Queue<TracerLine> TracerLine = new Queue<TracerLine>();
	}
}
