using System;
using Newtonsoft.Json;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000AC RID: 172
	public class ColorVariable
	{
		// Token: 0x06000300 RID: 768 RVA: 0x000041A1 File Offset: 0x000023A1
		[JsonConstructor]
		public ColorVariable(string identity, string name, Color32 color, Color32 origColor, bool disableAlpha)
		{
			this.identity = identity;
			this.name = name;
			this.color = color;
			this.origColor = origColor;
			this.disableAlpha = disableAlpha;
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000041D8 File Offset: 0x000023D8
		public ColorVariable(string identity, string name, Color32 color, bool disableAlpha = true)
		{
			this.identity = identity;
			this.name = name;
			this.color = color;
			this.origColor = color;
			this.disableAlpha = disableAlpha;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00015830 File Offset: 0x00013A30
		public ColorVariable(ColorVariable option)
		{
			this.identity = option.identity;
			this.name = option.name;
			this.color = option.color;
			this.origColor = option.origColor;
			this.disableAlpha = option.disableAlpha;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000420E File Offset: 0x0000240E
		public static implicit operator Color(ColorVariable color)
		{
			return color.color.ToColor();
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00004220 File Offset: 0x00002420
		public static implicit operator Color32(ColorVariable color)
		{
			return color.color;
		}

		// Token: 0x040002F2 RID: 754
		public SerializableColor color;

		// Token: 0x040002F3 RID: 755
		public SerializableColor origColor;

		// Token: 0x040002F4 RID: 756
		public string name;

		// Token: 0x040002F5 RID: 757
		public string identity;

		// Token: 0x040002F6 RID: 758
		public bool disableAlpha;
	}
}
