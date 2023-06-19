using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000064 RID: 100
	public class SerializableColor
	{
		// Token: 0x0600022B RID: 555 RVA: 0x0000390E File Offset: 0x00001B0E
		public SerializableColor(int nr, int ng, int nb, int na)
		{
			this.r = nr;
			this.g = ng;
			this.b = nb;
			this.a = na;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00003933 File Offset: 0x00001B33
		public SerializableColor(int nr, int ng, int nb)
		{
			this.r = nr;
			this.g = ng;
			this.b = nb;
			this.a = 255;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000395B File Offset: 0x00001B5B
		public static implicit operator Color32(SerializableColor color)
		{
			return color.ToColor();
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00003963 File Offset: 0x00001B63
		public static implicit operator Color(SerializableColor color)
		{
			return color.ToColor();
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00003970 File Offset: 0x00001B70
		public static implicit operator SerializableColor(Color32 color)
		{
			return color.ToSerializableColor();
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00003978 File Offset: 0x00001B78
		public Color32 ToColor()
		{
			return new Color32((byte)this.r, (byte)this.g, (byte)this.b, (byte)this.a);
		}

		// Token: 0x04000188 RID: 392
		public int r;

		// Token: 0x04000189 RID: 393
		public int g;

		// Token: 0x0400018A RID: 394
		public int b;

		// Token: 0x0400018B RID: 395
		public int a;
	}
}
