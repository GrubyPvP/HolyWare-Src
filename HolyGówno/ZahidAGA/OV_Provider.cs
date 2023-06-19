using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000086 RID: 134
	public static class OV_Provider
	{
		// Token: 0x0600027D RID: 637 RVA: 0x00003D42 File Offset: 0x00001F42
		[Override(typeof(Provider), "legacyReceiveClient", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void OV_legacyReceiveClient(byte[] packet, int offset, int size)
		{
			if (!OV_Provider.IsConnected)
			{
				OV_Provider.IsConnected = true;
			}
		}

		// Token: 0x040002B1 RID: 689
		public static bool IsConnected;
	}
}
