using System;

namespace ZahidAGA
{
	// Token: 0x02000006 RID: 6
	public struct EmbedColor
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000020D7 File Offset: 0x000002D7
		public EmbedColor(byte r, byte g, byte b)
		{
			this.R = r;
			this.G = g;
			this.B = b;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00004D90 File Offset: 0x00002F90
		public override bool Equals(object obj)
		{
			if (obj is EmbedColor)
			{
				EmbedColor embedColor = (EmbedColor)obj;
				return embedColor.R == this.R && embedColor.G == this.G && embedColor.B == this.B;
			}
			return false;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020EE File Offset: 0x000002EE
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002100 File Offset: 0x00000300
		public static EmbedColor Transparent
		{
			get
			{
				return new EmbedColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002116 File Offset: 0x00000316
		public static EmbedColor AliceBlue
		{
			get
			{
				return new EmbedColor(240, 248, byte.MaxValue);
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000212C File Offset: 0x0000032C
		public static EmbedColor AntiqueWhite
		{
			get
			{
				return new EmbedColor(250, 235, 215);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002142 File Offset: 0x00000342
		public static EmbedColor Aqua
		{
			get
			{
				return new EmbedColor(0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002154 File Offset: 0x00000354
		public static EmbedColor Aquamarine
		{
			get
			{
				return new EmbedColor(127, byte.MaxValue, 212);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002167 File Offset: 0x00000367
		public static EmbedColor Azure
		{
			get
			{
				return new EmbedColor(240, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000217D File Offset: 0x0000037D
		public static EmbedColor Beige
		{
			get
			{
				return new EmbedColor(245, 245, 220);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002193 File Offset: 0x00000393
		public static EmbedColor Bisque
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 228, 196);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000021A9 File Offset: 0x000003A9
		public static EmbedColor Black
		{
			get
			{
				return new EmbedColor(0, 0, 0);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000021B3 File Offset: 0x000003B3
		public static EmbedColor BlanchedAlmond
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 235, 205);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000021C9 File Offset: 0x000003C9
		public static EmbedColor Blue
		{
			get
			{
				return new EmbedColor(0, 0, byte.MaxValue);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000021D7 File Offset: 0x000003D7
		public static EmbedColor BlueViolet
		{
			get
			{
				return new EmbedColor(138, 43, 226);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000021EA File Offset: 0x000003EA
		public static EmbedColor Brown
		{
			get
			{
				return new EmbedColor(165, 42, 42);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000021FA File Offset: 0x000003FA
		public static EmbedColor BurlyWood
		{
			get
			{
				return new EmbedColor(222, 184, 135);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002210 File Offset: 0x00000410
		public static EmbedColor CadetBlue
		{
			get
			{
				return new EmbedColor(95, 158, 160);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34 RVA: 0x00002223 File Offset: 0x00000423
		public static EmbedColor Chartreuse
		{
			get
			{
				return new EmbedColor(127, byte.MaxValue, 0);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002232 File Offset: 0x00000432
		public static EmbedColor Chocolate
		{
			get
			{
				return new EmbedColor(210, 105, 30);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000024 RID: 36 RVA: 0x00002242 File Offset: 0x00000442
		public static EmbedColor Coral
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 127, 80);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002252 File Offset: 0x00000452
		public static EmbedColor CornflowerBlue
		{
			get
			{
				return new EmbedColor(100, 149, 237);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002265 File Offset: 0x00000465
		public static EmbedColor Cornsilk
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 248, 220);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000227B File Offset: 0x0000047B
		public static EmbedColor Crimson
		{
			get
			{
				return new EmbedColor(220, 20, 60);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002142 File Offset: 0x00000342
		public static EmbedColor Cyan
		{
			get
			{
				return new EmbedColor(0, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000029 RID: 41 RVA: 0x0000228B File Offset: 0x0000048B
		public static EmbedColor DarkBlue
		{
			get
			{
				return new EmbedColor(0, 0, 139);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002299 File Offset: 0x00000499
		public static EmbedColor DarkCyan
		{
			get
			{
				return new EmbedColor(0, 139, 139);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000022AB File Offset: 0x000004AB
		public static EmbedColor DarkGoldenrod
		{
			get
			{
				return new EmbedColor(184, 134, 11);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000022BE File Offset: 0x000004BE
		public static EmbedColor DarkGray
		{
			get
			{
				return new EmbedColor(169, 169, 169);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000022D4 File Offset: 0x000004D4
		public static EmbedColor DarkGreen
		{
			get
			{
				return new EmbedColor(0, 100, 0);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000022DF File Offset: 0x000004DF
		public static EmbedColor DarkKhaki
		{
			get
			{
				return new EmbedColor(189, 183, 107);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000022F2 File Offset: 0x000004F2
		public static EmbedColor DarkMagenta
		{
			get
			{
				return new EmbedColor(139, 0, 139);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002304 File Offset: 0x00000504
		public static EmbedColor DarkOliveGreen
		{
			get
			{
				return new EmbedColor(85, 107, 47);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002311 File Offset: 0x00000511
		public static EmbedColor DarkOrange
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 140, 0);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002323 File Offset: 0x00000523
		public static EmbedColor DarkOrchid
		{
			get
			{
				return new EmbedColor(153, 50, 204);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002336 File Offset: 0x00000536
		public static EmbedColor DarkRed
		{
			get
			{
				return new EmbedColor(139, 0, 0);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002344 File Offset: 0x00000544
		public static EmbedColor DarkSalmon
		{
			get
			{
				return new EmbedColor(233, 150, 122);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002357 File Offset: 0x00000557
		public static EmbedColor DarkSeaGreen
		{
			get
			{
				return new EmbedColor(143, 188, 143);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000236D File Offset: 0x0000056D
		public static EmbedColor DarkSlateBlue
		{
			get
			{
				return new EmbedColor(72, 61, 139);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000237D File Offset: 0x0000057D
		public static EmbedColor DarkSlateGray
		{
			get
			{
				return new EmbedColor(47, 79, 79);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000238A File Offset: 0x0000058A
		public static EmbedColor DarkTurquoise
		{
			get
			{
				return new EmbedColor(0, 206, 209);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000239C File Offset: 0x0000059C
		public static EmbedColor DarkViolet
		{
			get
			{
				return new EmbedColor(148, 0, 211);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000023AE File Offset: 0x000005AE
		public static EmbedColor DeepPink
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 20, 147);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000023C1 File Offset: 0x000005C1
		public static EmbedColor DeepSkyBlue
		{
			get
			{
				return new EmbedColor(0, 191, byte.MaxValue);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000023D3 File Offset: 0x000005D3
		public static EmbedColor DimGray
		{
			get
			{
				return new EmbedColor(105, 105, 105);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000023E0 File Offset: 0x000005E0
		public static EmbedColor DodgerBlue
		{
			get
			{
				return new EmbedColor(30, 144, byte.MaxValue);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000023F3 File Offset: 0x000005F3
		public static EmbedColor Firebrick
		{
			get
			{
				return new EmbedColor(178, 34, 34);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002403 File Offset: 0x00000603
		public static EmbedColor FloralWhite
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 250, 240);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002419 File Offset: 0x00000619
		public static EmbedColor ForestGreen
		{
			get
			{
				return new EmbedColor(34, 139, 34);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002429 File Offset: 0x00000629
		public static EmbedColor Fuchsia
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000042 RID: 66 RVA: 0x0000243B File Offset: 0x0000063B
		public static EmbedColor Gainsboro
		{
			get
			{
				return new EmbedColor(220, 220, 220);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002451 File Offset: 0x00000651
		public static EmbedColor GhostWhite
		{
			get
			{
				return new EmbedColor(248, 248, byte.MaxValue);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002467 File Offset: 0x00000667
		public static EmbedColor Gold
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 215, 0);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002479 File Offset: 0x00000679
		public static EmbedColor Goldenrod
		{
			get
			{
				return new EmbedColor(218, 165, 32);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000248C File Offset: 0x0000068C
		public static EmbedColor Gray
		{
			get
			{
				return new EmbedColor(128, 128, 128);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000024A2 File Offset: 0x000006A2
		public static EmbedColor Green
		{
			get
			{
				return new EmbedColor(0, 128, 0);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000024B0 File Offset: 0x000006B0
		public static EmbedColor GreenYellow
		{
			get
			{
				return new EmbedColor(173, byte.MaxValue, 47);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000024C3 File Offset: 0x000006C3
		public static EmbedColor Honeydew
		{
			get
			{
				return new EmbedColor(240, byte.MaxValue, 240);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000024D9 File Offset: 0x000006D9
		public static EmbedColor HotPink
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 105, 180);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000024EC File Offset: 0x000006EC
		public static EmbedColor IndianRed
		{
			get
			{
				return new EmbedColor(205, 92, 92);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000024FC File Offset: 0x000006FC
		public static EmbedColor Indigo
		{
			get
			{
				return new EmbedColor(75, 0, 130);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600004D RID: 77 RVA: 0x0000250B File Offset: 0x0000070B
		public static EmbedColor Ivory
		{
			get
			{
				return new EmbedColor(byte.MaxValue, byte.MaxValue, 240);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002521 File Offset: 0x00000721
		public static EmbedColor Khaki
		{
			get
			{
				return new EmbedColor(240, 230, 140);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002537 File Offset: 0x00000737
		public static EmbedColor Lavender
		{
			get
			{
				return new EmbedColor(230, 230, 250);
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000050 RID: 80 RVA: 0x0000254D File Offset: 0x0000074D
		public static EmbedColor LavenderBlush
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 240, 245);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002563 File Offset: 0x00000763
		public static EmbedColor LawnGreen
		{
			get
			{
				return new EmbedColor(124, 252, 0);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002572 File Offset: 0x00000772
		public static EmbedColor LemonChiffon
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 250, 205);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00002588 File Offset: 0x00000788
		public static EmbedColor LightBlue
		{
			get
			{
				return new EmbedColor(173, 216, 230);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000259E File Offset: 0x0000079E
		public static EmbedColor LightCoral
		{
			get
			{
				return new EmbedColor(240, 128, 128);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000055 RID: 85 RVA: 0x000025B4 File Offset: 0x000007B4
		public static EmbedColor LightCyan
		{
			get
			{
				return new EmbedColor(224, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000025CA File Offset: 0x000007CA
		public static EmbedColor LightGoldenrodYellow
		{
			get
			{
				return new EmbedColor(250, 250, 210);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000025E0 File Offset: 0x000007E0
		public static EmbedColor LightGreen
		{
			get
			{
				return new EmbedColor(144, 238, 144);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000058 RID: 88 RVA: 0x000025F6 File Offset: 0x000007F6
		public static EmbedColor LightGray
		{
			get
			{
				return new EmbedColor(211, 211, 211);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000260C File Offset: 0x0000080C
		public static EmbedColor LightPink
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 182, 193);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002622 File Offset: 0x00000822
		public static EmbedColor LightSalmon
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 160, 122);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002635 File Offset: 0x00000835
		public static EmbedColor LightSeaGreen
		{
			get
			{
				return new EmbedColor(32, 178, 170);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002648 File Offset: 0x00000848
		public static EmbedColor LightSkyBlue
		{
			get
			{
				return new EmbedColor(135, 206, 250);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600005D RID: 93 RVA: 0x0000265E File Offset: 0x0000085E
		public static EmbedColor LightSlateGray
		{
			get
			{
				return new EmbedColor(119, 136, 153);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002671 File Offset: 0x00000871
		public static EmbedColor LightSteelBlue
		{
			get
			{
				return new EmbedColor(176, 196, 222);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00002687 File Offset: 0x00000887
		public static EmbedColor LightYellow
		{
			get
			{
				return new EmbedColor(byte.MaxValue, byte.MaxValue, 224);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000269D File Offset: 0x0000089D
		public static EmbedColor Lime
		{
			get
			{
				return new EmbedColor(0, byte.MaxValue, 0);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000061 RID: 97 RVA: 0x000026AB File Offset: 0x000008AB
		public static EmbedColor LimeGreen
		{
			get
			{
				return new EmbedColor(50, 205, 50);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000062 RID: 98 RVA: 0x000026BB File Offset: 0x000008BB
		public static EmbedColor Linen
		{
			get
			{
				return new EmbedColor(250, 240, 230);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002429 File Offset: 0x00000629
		public static EmbedColor Magenta
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 0, byte.MaxValue);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000064 RID: 100 RVA: 0x000026D1 File Offset: 0x000008D1
		public static EmbedColor Maroon
		{
			get
			{
				return new EmbedColor(128, 0, 0);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000026DF File Offset: 0x000008DF
		public static EmbedColor MediumAquamarine
		{
			get
			{
				return new EmbedColor(102, 205, 170);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000026F2 File Offset: 0x000008F2
		public static EmbedColor MediumBlue
		{
			get
			{
				return new EmbedColor(0, 0, 205);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002700 File Offset: 0x00000900
		public static EmbedColor MediumOrchid
		{
			get
			{
				return new EmbedColor(186, 85, 211);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002713 File Offset: 0x00000913
		public static EmbedColor MediumPurple
		{
			get
			{
				return new EmbedColor(147, 112, 219);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002726 File Offset: 0x00000926
		public static EmbedColor MediumSeaGreen
		{
			get
			{
				return new EmbedColor(60, 179, 113);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002736 File Offset: 0x00000936
		public static EmbedColor MediumSlateBlue
		{
			get
			{
				return new EmbedColor(123, 104, 238);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002746 File Offset: 0x00000946
		public static EmbedColor MediumSpringGreen
		{
			get
			{
				return new EmbedColor(0, 250, 154);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002758 File Offset: 0x00000958
		public static EmbedColor MediumTurquoise
		{
			get
			{
				return new EmbedColor(72, 209, 204);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000276B File Offset: 0x0000096B
		public static EmbedColor MediumVioletRed
		{
			get
			{
				return new EmbedColor(199, 21, 133);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600006E RID: 110 RVA: 0x0000277E File Offset: 0x0000097E
		public static EmbedColor MidnightBlue
		{
			get
			{
				return new EmbedColor(25, 25, 112);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600006F RID: 111 RVA: 0x0000278B File Offset: 0x0000098B
		public static EmbedColor MintCream
		{
			get
			{
				return new EmbedColor(245, byte.MaxValue, 250);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000027A1 File Offset: 0x000009A1
		public static EmbedColor MistyRose
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 228, 225);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000027B7 File Offset: 0x000009B7
		public static EmbedColor Moccasin
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 228, 181);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000027CD File Offset: 0x000009CD
		public static EmbedColor NavajoWhite
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 222, 173);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000027E3 File Offset: 0x000009E3
		public static EmbedColor Navy
		{
			get
			{
				return new EmbedColor(0, 0, 128);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000074 RID: 116 RVA: 0x000027F1 File Offset: 0x000009F1
		public static EmbedColor OldLace
		{
			get
			{
				return new EmbedColor(253, 245, 230);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002807 File Offset: 0x00000A07
		public static EmbedColor Olive
		{
			get
			{
				return new EmbedColor(128, 128, 0);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00002819 File Offset: 0x00000A19
		public static EmbedColor OliveDrab
		{
			get
			{
				return new EmbedColor(107, 142, 35);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002829 File Offset: 0x00000A29
		public static EmbedColor Orange
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 165, 0);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0000283B File Offset: 0x00000A3B
		public static EmbedColor OrangeRed
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 69, 0);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000284A File Offset: 0x00000A4A
		public static EmbedColor Orchid
		{
			get
			{
				return new EmbedColor(218, 112, 214);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600007A RID: 122 RVA: 0x0000285D File Offset: 0x00000A5D
		public static EmbedColor PaleGoldenrod
		{
			get
			{
				return new EmbedColor(238, 232, 170);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002873 File Offset: 0x00000A73
		public static EmbedColor PaleGreen
		{
			get
			{
				return new EmbedColor(152, 251, 152);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002889 File Offset: 0x00000A89
		public static EmbedColor PaleTurquoise
		{
			get
			{
				return new EmbedColor(175, 238, 238);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000289F File Offset: 0x00000A9F
		public static EmbedColor PaleVioletRed
		{
			get
			{
				return new EmbedColor(219, 112, 147);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000028B2 File Offset: 0x00000AB2
		public static EmbedColor PapayaWhip
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 239, 213);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000028C8 File Offset: 0x00000AC8
		public static EmbedColor PeachPuff
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 218, 185);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000028DE File Offset: 0x00000ADE
		public static EmbedColor Peru
		{
			get
			{
				return new EmbedColor(205, 133, 63);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000028F1 File Offset: 0x00000AF1
		public static EmbedColor Pink
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 192, 203);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002907 File Offset: 0x00000B07
		public static EmbedColor Plum
		{
			get
			{
				return new EmbedColor(221, 160, 221);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000083 RID: 131 RVA: 0x0000291D File Offset: 0x00000B1D
		public static EmbedColor PowderBlue
		{
			get
			{
				return new EmbedColor(176, 224, 230);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00002933 File Offset: 0x00000B33
		public static EmbedColor Purple
		{
			get
			{
				return new EmbedColor(128, 0, 128);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00002945 File Offset: 0x00000B45
		public static EmbedColor RebeccaPurple
		{
			get
			{
				return new EmbedColor(102, 51, 153);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00002955 File Offset: 0x00000B55
		public static EmbedColor Red
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 0, 0);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00002963 File Offset: 0x00000B63
		public static EmbedColor RosyBrown
		{
			get
			{
				return new EmbedColor(188, 143, 143);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00002979 File Offset: 0x00000B79
		public static EmbedColor RoyalBlue
		{
			get
			{
				return new EmbedColor(65, 105, 225);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00002989 File Offset: 0x00000B89
		public static EmbedColor SaddleBrown
		{
			get
			{
				return new EmbedColor(139, 69, 19);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00002999 File Offset: 0x00000B99
		public static EmbedColor Salmon
		{
			get
			{
				return new EmbedColor(250, 128, 114);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000029AC File Offset: 0x00000BAC
		public static EmbedColor SandyBrown
		{
			get
			{
				return new EmbedColor(244, 164, 96);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000029BF File Offset: 0x00000BBF
		public static EmbedColor SeaGreen
		{
			get
			{
				return new EmbedColor(46, 139, 87);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000029CF File Offset: 0x00000BCF
		public static EmbedColor SeaShell
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 245, 238);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000029E5 File Offset: 0x00000BE5
		public static EmbedColor Sienna
		{
			get
			{
				return new EmbedColor(160, 82, 45);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000029F5 File Offset: 0x00000BF5
		public static EmbedColor Silver
		{
			get
			{
				return new EmbedColor(192, 192, 192);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00002A0B File Offset: 0x00000C0B
		public static EmbedColor SkyBlue
		{
			get
			{
				return new EmbedColor(135, 206, 235);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00002A21 File Offset: 0x00000C21
		public static EmbedColor SlateBlue
		{
			get
			{
				return new EmbedColor(106, 90, 205);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00002A31 File Offset: 0x00000C31
		public static EmbedColor SlateGray
		{
			get
			{
				return new EmbedColor(112, 128, 144);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00002A44 File Offset: 0x00000C44
		public static EmbedColor Snow
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 250, 250);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00002A5A File Offset: 0x00000C5A
		public static EmbedColor SpringGreen
		{
			get
			{
				return new EmbedColor(0, byte.MaxValue, 127);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002A69 File Offset: 0x00000C69
		public static EmbedColor SteelBlue
		{
			get
			{
				return new EmbedColor(70, 130, 180);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00002A7C File Offset: 0x00000C7C
		public static EmbedColor Tan
		{
			get
			{
				return new EmbedColor(210, 180, 140);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002A92 File Offset: 0x00000C92
		public static EmbedColor Teal
		{
			get
			{
				return new EmbedColor(0, 128, 128);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00002AA4 File Offset: 0x00000CA4
		public static EmbedColor Thistle
		{
			get
			{
				return new EmbedColor(216, 191, 216);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00002ABA File Offset: 0x00000CBA
		public static EmbedColor Tomato
		{
			get
			{
				return new EmbedColor(byte.MaxValue, 99, 71);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00002ACA File Offset: 0x00000CCA
		public static EmbedColor Turquoise
		{
			get
			{
				return new EmbedColor(64, 224, 208);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002ADD File Offset: 0x00000CDD
		public static EmbedColor Violet
		{
			get
			{
				return new EmbedColor(238, 130, 238);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00002AF3 File Offset: 0x00000CF3
		public static EmbedColor Wheat
		{
			get
			{
				return new EmbedColor(245, 222, 179);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00002100 File Offset: 0x00000300
		public static EmbedColor White
		{
			get
			{
				return new EmbedColor(byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00002B09 File Offset: 0x00000D09
		public static EmbedColor WhiteSmoke
		{
			get
			{
				return new EmbedColor(245, 245, 245);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00002B1F File Offset: 0x00000D1F
		public static EmbedColor Yellow
		{
			get
			{
				return new EmbedColor(byte.MaxValue, byte.MaxValue, 0);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00002B31 File Offset: 0x00000D31
		public static EmbedColor YellowGreen
		{
			get
			{
				return new EmbedColor(154, 205, 50);
			}
		}

		// Token: 0x04000010 RID: 16
		public byte R;

		// Token: 0x04000011 RID: 17
		public byte G;

		// Token: 0x04000012 RID: 18
		public byte B;
	}
}
