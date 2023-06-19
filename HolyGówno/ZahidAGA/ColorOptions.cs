using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000071 RID: 113
	public static class ColorOptions
	{
		// Token: 0x0400024A RID: 586
		[Save]
		public static Dictionary<string, ColorVariable> ColorDict = new Dictionary<string, ColorVariable>();

		// Token: 0x0400024B RID: 587
		public static Dictionary<string, ColorVariable> DefaultColorDict = new Dictionary<string, ColorVariable>();

		// Token: 0x0400024C RID: 588
		public static ColorVariable errorColor = new ColorVariable("errorColor", "#ERROR.NOTFOUND", Color.magenta, true);

		// Token: 0x0400024D RID: 589
		public static ColorVariable preview = new ColorVariable("preview", "Renk Seçilmedi", Color.white, true);

		// Token: 0x0400024E RID: 590
		public static ColorVariable previewselected;

		// Token: 0x0400024F RID: 591
		public static string selectedOption;
	}
}
