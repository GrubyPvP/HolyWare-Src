using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000A6 RID: 166
	public static class AssetVariables
	{
		// Token: 0x040002DA RID: 730
		public static AssetBundle ABundle;

		// Token: 0x040002DB RID: 731
		public static Dictionary<string, Material> Materials = new Dictionary<string, Material>();

		// Token: 0x040002DC RID: 732
		public static Dictionary<string, Font> Fonts = new Dictionary<string, Font>();

		// Token: 0x040002DD RID: 733
		public static Dictionary<string, Cursor> Cursor = new Dictionary<string, Cursor>();

		// Token: 0x040002DE RID: 734
		public static Dictionary<string, AudioClip> Audio = new Dictionary<string, AudioClip>();

		// Token: 0x040002DF RID: 735
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

		// Token: 0x040002E0 RID: 736
		public static Dictionary<string, Shader> Shaders = new Dictionary<string, Shader>();
	}
}
