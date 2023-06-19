using System;

namespace ZahidAGA
{
	// Token: 0x0200005E RID: 94
	[Flags]
	public enum MemoryProtection : uint
	{
		// Token: 0x04000162 RID: 354
		EXECUTE = 16U,
		// Token: 0x04000163 RID: 355
		EXECUTE_READ = 32U,
		// Token: 0x04000164 RID: 356
		EXECUTE_READWRITE = 64U,
		// Token: 0x04000165 RID: 357
		EXECUTE_WRITECOPY = 128U,
		// Token: 0x04000166 RID: 358
		NOACCESS = 1U,
		// Token: 0x04000167 RID: 359
		READONLY = 2U,
		// Token: 0x04000168 RID: 360
		READWRITE = 4U,
		// Token: 0x04000169 RID: 361
		WRITECOPY = 8U,
		// Token: 0x0400016A RID: 362
		GUARD_Modifierflag = 256U,
		// Token: 0x0400016B RID: 363
		NOCACHE_Modifierflag = 512U,
		// Token: 0x0400016C RID: 364
		WRITECOMBINE_Modifierflag = 1024U
	}
}
