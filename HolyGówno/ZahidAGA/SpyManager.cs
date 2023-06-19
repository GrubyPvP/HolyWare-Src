using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000050 RID: 80
	public class SpyManager
	{
		// Token: 0x06000217 RID: 535 RVA: 0x0000F390 File Offset: 0x0000D590
		public static void InvokePre()
		{
			foreach (MethodInfo methodInfo in SpyManager.PreSpy)
			{
				methodInfo.Invoke(null, null);
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000F3DC File Offset: 0x0000D5DC
		public static void InvokePost()
		{
			foreach (MethodInfo methodInfo in SpyManager.PostSpy)
			{
				methodInfo.Invoke(null, null);
			}
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000F428 File Offset: 0x0000D628
		public static void DestroyComponents()
		{
			foreach (Type type in SpyManager.Components)
			{
				Object.Destroy(LomepnAGAAA.oko.GetComponent(type));
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000F480 File Offset: 0x0000D680
		public static void AddComponents()
		{
			foreach (Type type in SpyManager.Components)
			{
				LomepnAGAAA.oko.AddComponent(type);
			}
		}

		// Token: 0x04000107 RID: 263
		public static IEnumerable<MethodInfo> PreSpy;

		// Token: 0x04000108 RID: 264
		public static IEnumerable<Type> Components;

		// Token: 0x04000109 RID: 265
		public static IEnumerable<MethodInfo> PostSpy;
	}
}
