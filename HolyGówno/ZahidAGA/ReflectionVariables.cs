using System;
using System.Reflection;

namespace ZahidAGA
{
	// Token: 0x020000AA RID: 170
	public static class ReflectionVariables
	{
		// Token: 0x040002E9 RID: 745
		public static BindingFlags PublicInstance = BindingFlags.Instance | BindingFlags.Public;

		// Token: 0x040002EA RID: 746
		public static BindingFlags publicInstance = BindingFlags.Instance | BindingFlags.NonPublic;

		// Token: 0x040002EB RID: 747
		public static BindingFlags PublicStatic = BindingFlags.Static | BindingFlags.Public;

		// Token: 0x040002EC RID: 748
		public static BindingFlags publicStatic = BindingFlags.Static | BindingFlags.NonPublic;

		// Token: 0x040002ED RID: 749
		public static BindingFlags Everything = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
	}
}
