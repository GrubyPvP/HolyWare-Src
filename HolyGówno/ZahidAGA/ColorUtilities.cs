using System;
using System.Globalization;
using System.Linq;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200008C RID: 140
	internal class ColorUtilities
	{
		// Token: 0x0600028D RID: 653 RVA: 0x00003DB4 File Offset: 0x00001FB4
		public static void addColor(ColorVariable ColorVariable)
		{
			if (!ColorOptions.DefaultColorDict.ContainsKey(ColorVariable.identity))
			{
				ColorOptions.DefaultColorDict.Add(ColorVariable.identity, ColorVariable);
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0001178C File Offset: 0x0000F98C
		public static ColorVariable getColor(string identifier)
		{
			ColorVariable colorVariable;
			ColorVariable result;
			if (ColorOptions.ColorDict.TryGetValue(identifier, out colorVariable))
			{
				result = colorVariable;
			}
			else
			{
				result = ColorOptions.errorColor;
			}
			return result;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x000117B4 File Offset: 0x0000F9B4
		public static string getHex(string identifier)
		{
			ColorVariable color;
			string result;
			if (ColorOptions.ColorDict.TryGetValue(identifier, out color))
			{
				result = ColorUtilities.ColorToHex(color);
			}
			else
			{
				result = ColorUtilities.ColorToHex(ColorOptions.errorColor);
			}
			return result;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000117F0 File Offset: 0x0000F9F0
		public static void setColor(string identifier, Color32 color)
		{
			ColorVariable colorVariable;
			if (ColorOptions.ColorDict.TryGetValue(identifier, out colorVariable))
			{
				colorVariable.color = color.ToSerializableColor();
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00003DDC File Offset: 0x00001FDC
		public static string ColorToHex(Color32 color)
		{
			return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + "FF";
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00003E1B File Offset: 0x0000201B
		public static ColorVariable[] getArray()
		{
			return ColorOptions.ColorDict.Values.ToArray<ColorVariable>();
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00011818 File Offset: 0x0000FA18
		public static Color32 HexToColor(string hex)
		{
			byte b = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
			byte b2 = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
			byte b3 = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
			return new Color32(b, b2, b3, byte.MaxValue);
		}
	}
}
