using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000C6 RID: 198
	public class SettingsTab
	{
		// Token: 0x0600034E RID: 846 RVA: 0x00017E24 File Offset: 0x00016024
		public static void Tab()
		{
			GUILayout.BeginArea(new Rect(300f, 0f, 940f, 40f), "TabBtn");
			SettingsTab.Select = (SettingsOptions)GUI.Toolbar(new Rect(15f, 10f, 700f, 40f), (int)SettingsTab.Select, Main.buttons4.ToArray(), "TabBtn");
			GUILayout.EndArea();
			Rect rect = new Rect(345f, 70f, 310f, 530f);
			GUIStyle guistyle = "box";
			GUILayout.BeginArea(rect, string.Format("<size=15>{0}</size>", SettingsTab.Select), guistyle);
			SettingsTab.scrollPosition1 = GUILayout.BeginScrollView(SettingsTab.scrollPosition1, Array.Empty<GUILayoutOption>());
			switch (SettingsTab.Select)
			{
			case SettingsOptions.Config:
				if (GUILayout.Button("Save", Array.Empty<GUILayoutOption>()))
				{
					ConfigManager.ConfigPath = ConfigManager.appdata + "/Amturned/" + ConfigManager.current + ".txt";
					ConfigManager.SaveConfig();
				}
				if (GUILayout.Button("Load", Array.Empty<GUILayoutOption>()))
				{
					ConfigManager.ConfigPath = ConfigManager.appdata + "/Amturned/" + ConfigManager.current + ".txt";
					ConfigManager.Init();
					SkinsUtilities.ApplyFromConfig();
				}
				ConfigManager.current = GUILayout.TextField(ConfigManager.current, string.Empty, Array.Empty<GUILayoutOption>());
				GUILayout.EndArea();
				break;
			case SettingsOptions.Info:
				GUILayout.Label("Status: UNDETECTED", Array.Empty<GUILayoutOption>());
				GUILayout.EndArea();
				break;
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(670f, 70f, 310f, 530f), "", "box");
			SettingsOptions select = SettingsTab.Select;
			if (select != SettingsOptions.Colors)
			{
			}
			GUILayout.EndArea();
		}

		// Token: 0x040003A6 RID: 934
		public static string SelectedColorIdentifier = "";

		// Token: 0x040003A7 RID: 935
		private static Vector2 scrollPosition1 = new Vector2(0f, 0f);

		// Token: 0x040003A8 RID: 936
		private static Vector2 scrollPosition4 = new Vector2(0f, 0f);

		// Token: 0x040003A9 RID: 937
		public static SettingsOptions Select = SettingsOptions.Info;

		// Token: 0x040003AA RID: 938
		private static string textfield = "New Config";

		// Token: 0x040003AB RID: 939
		private static Vector2 scrollPosition2 = new Vector2(0f, 0f);

		// Token: 0x040003AC RID: 940
		private static Vector2 scrollPosition3 = new Vector2(0f, 0f);
	}
}
