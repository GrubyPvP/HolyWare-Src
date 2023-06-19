using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000063 RID: 99
	public static class Extensions
	{
		// Token: 0x06000226 RID: 550 RVA: 0x000038AB File Offset: 0x00001AAB
		public static Color Invert(this Color32 color)
		{
			return new Color((float)(byte.MaxValue - color.r), (float)(byte.MaxValue - color.g), (float)(byte.MaxValue - color.b));
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000F570 File Offset: 0x0000D770
		public static T Next<T>(this T src) where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));
			}
			T[] array = (T[])Enum.GetValues(src.GetType());
			int num = Array.IndexOf<T>(array, src) + 1;
			if (array.Length != num)
			{
				return array[num];
			}
			return array[0];
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000038D9 File Offset: 0x00001AD9
		public static SerializableColor ToSerializableColor(this Color32 c)
		{
			return new SerializableColor((int)c.r, (int)c.g, (int)c.b, (int)c.a);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000038F8 File Offset: 0x00001AF8
		public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
		{
			return source.Skip(Math.Max(0, source.Count<T>() - N));
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000F5E4 File Offset: 0x0000D7E4
		public static void AddRange<T>(this HashSet<T> source, IEnumerable<T> target)
		{
			foreach (T item in target)
			{
				source.Add(item);
			}
		}
	}
}
