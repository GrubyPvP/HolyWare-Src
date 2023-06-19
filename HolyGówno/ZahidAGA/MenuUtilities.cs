using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000096 RID: 150
	public class MenuUtilities
	{
		// Token: 0x060002C3 RID: 707 RVA: 0x00003EC4 File Offset: 0x000020C4
		static MenuUtilities()
		{
			MenuUtilities.TexClear.SetPixel(0, 0, new Color(0f, 0f, 0f, 0f));
			MenuUtilities.TexClear.Apply();
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x000138E4 File Offset: 0x00011AE4
		public static void FixGUIStyleColor(GUIStyle style)
		{
			style.normal.background = MenuUtilities.TexClear;
			style.onNormal.background = MenuUtilities.TexClear;
			style.active.background = MenuUtilities.TexClear;
			style.onActive.background = MenuUtilities.TexClear;
			style.focused.background = MenuUtilities.TexClear;
			style.onFocused.background = MenuUtilities.TexClear;
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00003F01 File Offset: 0x00002101
		public static Rect Inline(Rect rect, float border = 1f)
		{
			return new Rect(rect.x + border, rect.y + border, rect.width - border * 2f, rect.height - border * 2f);
		}

		// Token: 0x040002BB RID: 699
		public static Texture2D TexClear = new Texture2D(1, 1);
	}
}
