using System;
using System.Collections.Generic;

namespace ZahidAGA
{
	// Token: 0x020000AE RID: 174
	public class MenuTabOption
	{
		// Token: 0x06000308 RID: 776 RVA: 0x0000425A File Offset: 0x0000245A
		public MenuTabOption(string name, MenuTabOption.MenuTab tab)
		{
			this.tab = tab;
			this.name = name;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00004270 File Offset: 0x00002470
		public static void Add(MenuTabOption tab)
		{
			MenuTabOption.tabs.Add(tab);
		}

		// Token: 0x040002FB RID: 763
		public static MenuTabOption CurrentTab;

		// Token: 0x040002FC RID: 764
		public static List<MenuTabOption> tabs = new List<MenuTabOption>();

		// Token: 0x040002FD RID: 765
		public bool enabled;

		// Token: 0x040002FE RID: 766
		public string name;

		// Token: 0x040002FF RID: 767
		public MenuTabOption.MenuTab tab;

		// Token: 0x020000AF RID: 175
		// (Invoke) Token: 0x0600030C RID: 780
		public delegate void MenuTab();
	}
}
