using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x0200007B RID: 123
	public static class OV_LevelLighting
	{
		// Token: 0x06000251 RID: 593 RVA: 0x00003AEE File Offset: 0x00001CEE
		[OnSpy]
		public static void Disable()
		{
			if (DrawUtilities.ShouldRun())
			{
				OV_LevelLighting.OV_updateLighting();
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00003AEE File Offset: 0x00001CEE
		[OffSpy]
		public static void Enable()
		{
			if (DrawUtilities.ShouldRun())
			{
				OV_LevelLighting.OV_updateLighting();
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00003AFF File Offset: 0x00001CFF
		[Initializer]
		public static void Init()
		{
			OV_LevelLighting.Time = typeof(LevelLighting).GetField("_time", BindingFlags.Static | BindingFlags.NonPublic);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000FFAC File Offset: 0x0000E1AC
		[Override(typeof(LevelLighting), "updateLighting", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_updateLighting()
		{
			float time = LevelLighting.time;
			if (!DrawUtilities.ShouldRun() || !MiscOptions.SetTimeEnabled || G.BeingSpied)
			{
				OverrideUtilities.CallOriginal(null, new object[0]);
				return;
			}
			OV_LevelLighting.Time.SetValue(null, MiscOptions.Time);
			OverrideUtilities.CallOriginal(null, new object[0]);
			OV_LevelLighting.Time.SetValue(null, time);
		}

		// Token: 0x04000292 RID: 658
		public static FieldInfo Time;

		// Token: 0x04000293 RID: 659
		public static bool WasEnabled;
	}
}
