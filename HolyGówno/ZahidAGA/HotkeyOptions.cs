using System;
using System.Collections.Generic;

namespace ZahidAGA
{
	// Token: 0x0200006C RID: 108
	public static class HotkeyOptions
	{
		// Token: 0x040001DD RID: 477
		[Save]
		public static Dictionary<string, Dictionary<string, Hotkey>> HotkeyDict = new Dictionary<string, Dictionary<string, Hotkey>>();

		// Token: 0x040001DE RID: 478
		[Save]
		public static Dictionary<string, Hotkey> UnorganizedHotkeys = new Dictionary<string, Hotkey>();
	}
}
