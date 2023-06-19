using System;

namespace ZahidAGA
{
	// Token: 0x0200005B RID: 91
	[Flags]
	public enum AllocationType : uint
	{
		// Token: 0x04000146 RID: 326
		COMMIT = 4096U,
		// Token: 0x04000147 RID: 327
		RESERVE = 8192U,
		// Token: 0x04000148 RID: 328
		RESET = 524288U,
		// Token: 0x04000149 RID: 329
		LARGE_PAGES = 536870912U,
		// Token: 0x0400014A RID: 330
		PHYSICAL = 4194304U,
		// Token: 0x0400014B RID: 331
		TOP_DOWN = 1048576U,
		// Token: 0x0400014C RID: 332
		WRITE_WATCH = 2097152U
	}
}
