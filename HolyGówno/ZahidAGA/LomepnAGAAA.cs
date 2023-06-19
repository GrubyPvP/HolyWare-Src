using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000B1 RID: 177
	public static class LomepnAGAAA
	{
		// Token: 0x06000324 RID: 804 RVA: 0x00004340 File Offset: 0x00002540
		public static void LomepnAGAAAvoid()
		{
			LomepnAGAAA.oko = new GameObject();
			Object.DontDestroyOnLoad(LomepnAGAAA.oko);
			LomepnAGAAA.oko.AddComponent<Manager>();
		}

		// Token: 0x04000309 RID: 777
		public static string appdata = Environment.ExpandEnvironmentVariables("%appdata%");

		// Token: 0x0400030A RID: 778
		public static string temp = Environment.ExpandEnvironmentVariables("temp");

		// Token: 0x0400030B RID: 779
		public static GameObject oko;
	}
}
