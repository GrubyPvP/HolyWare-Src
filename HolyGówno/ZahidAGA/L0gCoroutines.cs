using System;

namespace ZahidAGA
{
	// Token: 0x0200000D RID: 13
	public static class L0gCoroutines
	{
		// Token: 0x060000CE RID: 206 RVA: 0x00007228 File Offset: 0x00005428
		public static string id()
		{
			string str = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS").Replace(Environment.NewLine ?? "", "").Replace(" ", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("0", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("ç", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("ğ", "").Replace("h", "").Replace("ı", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("n", "").Replace("o", "").Replace("ö", "").Replace("p", "").Replace("r", "").Replace("ş", "").Replace("s", "").Replace("t", "").Replace("u", "").Replace("ü", "").Replace("v", "").Replace("y", "").Replace("z", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("Ç", "").Replace("D", "").Replace("E", "").Replace("F", "").Replace("G", "").Replace("Ğ", "").Replace("H", "").Replace("I", "").Replace("İ", "").Replace("J", "").Replace("K", "").Replace("L", "").Replace("M", "").Replace("N", "").Replace("O", "").Replace("Ö", "").Replace("P", "").Replace("R", "").Replace("Ş", "").Replace("S", "").Replace("T", "").Replace("U", "").Replace("Ü", "").Replace("V", "").Replace("Y", "").Replace("Z", "");
			string str2 = Environment.GetEnvironmentVariable("PROCESSOR_LEVEL").Replace(Environment.NewLine ?? "", "").Replace(Environment.NewLine ?? "", "").Replace(" ", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("0", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("ç", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("ğ", "").Replace("h", "").Replace("ı", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("n", "").Replace("o", "").Replace("ö", "").Replace("p", "").Replace("r", "").Replace("ş", "").Replace("s", "").Replace("t", "").Replace("u", "").Replace("ü", "").Replace("v", "").Replace("y", "").Replace("z", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("Ç", "").Replace("D", "").Replace("E", "").Replace("F", "").Replace("G", "").Replace("Ğ", "").Replace("H", "").Replace("I", "").Replace("İ", "").Replace("J", "").Replace("K", "").Replace("L", "").Replace("M", "").Replace("N", "").Replace("O", "").Replace("Ö", "").Replace("P", "").Replace("R", "").Replace("Ş", "").Replace("S", "").Replace("T", "").Replace("U", "").Replace("Ü", "").Replace("V", "").Replace("Y", "").Replace("Z", "");
			string str3 = Environment.GetEnvironmentVariable("PROCESSOR_REVISION").Replace(Environment.NewLine ?? "", "").Replace(Environment.NewLine ?? "", "").Replace(" ", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("0", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("ç", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("ğ", "").Replace("h", "").Replace("ı", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("n", "").Replace("o", "").Replace("ö", "").Replace("p", "").Replace("r", "").Replace("ş", "").Replace("s", "").Replace("t", "").Replace("u", "").Replace("ü", "").Replace("v", "").Replace("y", "").Replace("z", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("Ç", "").Replace("D", "").Replace("E", "").Replace("F", "").Replace("G", "").Replace("Ğ", "").Replace("H", "").Replace("I", "").Replace("İ", "").Replace("J", "").Replace("K", "").Replace("L", "").Replace("M", "").Replace("N", "").Replace("O", "").Replace("Ö", "").Replace("P", "").Replace("R", "").Replace("Ş", "").Replace("S", "").Replace("T", "").Replace("U", "").Replace("Ü", "").Replace("V", "").Replace("Y", "").Replace("Z", "");
			string str4 = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER").Replace(Environment.NewLine ?? "", "").Replace(" ", "").Replace(",", "").Replace(".", "").Replace("-", "").Replace("0", "").Replace("a", "").Replace("b", "").Replace("c", "").Replace("ç", "").Replace("d", "").Replace("e", "").Replace("f", "").Replace("g", "").Replace("ğ", "").Replace("h", "").Replace("ı", "").Replace("i", "").Replace("j", "").Replace("k", "").Replace("l", "").Replace("m", "").Replace("n", "").Replace("o", "").Replace("ö", "").Replace("p", "").Replace("r", "").Replace("ş", "").Replace("s", "").Replace("t", "").Replace("u", "").Replace("ü", "").Replace("v", "").Replace("y", "").Replace("z", "").Replace("A", "").Replace("B", "").Replace("C", "").Replace("Ç", "").Replace("D", "").Replace("E", "").Replace("F", "").Replace("G", "").Replace("Ğ", "").Replace("H", "").Replace("I", "").Replace("İ", "").Replace("J", "").Replace("K", "").Replace("L", "").Replace("M", "").Replace("N", "").Replace("O", "").Replace("Ö", "").Replace("P", "").Replace("R", "").Replace("Ş", "").Replace("S", "").Replace("T", "").Replace("U", "").Replace("Ü", "").Replace("V", "").Replace("Y", "").Replace("Z", "");
			long num = (long)(Convert.ToUInt64(str + str2 + str3 + str4) * 8UL / 3UL);
			return string.Concat(new string[]
			{
				"P",
				num.ToString().Substring(0, 1),
				"-H",
				num.ToString().Substring(1, 1),
				"-B",
				num.ToString().Substring(2, 1),
				"-D",
				num.ToString().Substring(3, 1),
				"-K",
				num.ToString().Substring(4, 1),
				"-Z",
				num.ToString().Substring(5, 1),
				"-T",
				num.ToString().Substring(6, 1)
			});
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000269D File Offset: 0x0000089D
		public static EmbedColor Green
		{
			get
			{
				return new EmbedColor(0, byte.MaxValue, 0);
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00002955 File Offset: 0x00000B55
		public static EmbedColor Red
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 0, 0);
			}
		}
	}
}
