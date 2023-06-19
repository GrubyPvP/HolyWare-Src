using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000BF RID: 191
	public static class HotkeyTab2
	{
		// Token: 0x0600032E RID: 814 RVA: 0x00015FF4 File Offset: 0x000141F4
		public static void Tab()
		{
			GUILayout.BeginArea(new Rect(340f, 70f, 650f, 550f), "Online Players", "box");
			HotkeyTab2.scrollPosition1 = GUILayout.BeginScrollView(HotkeyTab2.scrollPosition1, Array.Empty<GUILayoutOption>());
			foreach (KeyValuePair<string, Dictionary<string, Hotkey>> keyValuePair in HotkeyOptions.HotkeyDict)
			{
				if (HotkeyTab2.IsFirst)
				{
					HotkeyTab2.IsFirst = false;
					HotkeyTab2.DrawSpacer(keyValuePair.Key, true);
				}
				else
				{
					HotkeyTab2.DrawSpacer(keyValuePair.Key, false);
				}
				foreach (KeyValuePair<string, Hotkey> keyValuePair2 in keyValuePair.Value)
				{
					HotkeyTab2.DrawButton(keyValuePair2.Value.Name, keyValuePair2.Key);
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00004397 File Offset: 0x00002597
		public static void DrawSpacer(string Text, bool First)
		{
			if (!First)
			{
				GUILayout.Space(10f);
			}
			GUILayout.Label(Text, new GUILayoutOption[0]);
			GUILayout.Space(8f);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0001610C File Offset: 0x0001430C
		public static void DrawButton(string Option, string Identifier)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(Option, new GUILayoutOption[0]);
			if (HotkeyTab2.ClickedOption == Identifier)
			{
				if (GUILayout.Button("Put away", new GUILayoutOption[0]))
				{
					HotkeyComponent.Clear();
					HotkeyOptions.UnorganizedHotkeys[Identifier].Keys = new KeyCode[0];
					HotkeyTab2.ClickedOption = "";
				}
				if (!HotkeyComponent.StopKeys)
				{
					string text;
					if (HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Length != 0)
					{
						text = string.Join(" + ", HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Select(delegate(KeyCode k)
						{
							KeyCode keyCode = k;
							return keyCode.ToString();
						}).ToArray<string>());
					}
					else
					{
						text = "Not assigned";
					}
					GUILayout.Button(text, new GUILayoutOption[0]);
				}
				else
				{
					HotkeyOptions.UnorganizedHotkeys[Identifier].Keys = HotkeyComponent.CurrentKeys.ToArray();
					HotkeyComponent.Clear();
					GUILayout.Button(string.Join(" + ", HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Select(delegate(KeyCode k)
					{
						KeyCode keyCode = k;
						return keyCode.ToString();
					}).ToArray<string>()), new GUILayoutOption[0]);
					HotkeyTab2.ClickedOption = "";
				}
			}
			else
			{
				string text2;
				if (HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Length != 0)
				{
					text2 = string.Join(" + ", HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Select(delegate(KeyCode k)
					{
						KeyCode keyCode = k;
						return keyCode.ToString();
					}).ToArray<string>());
				}
				else
				{
					text2 = "Not assigned";
				}
				if (GUILayout.Button(text2, new GUILayoutOption[0]))
				{
					HotkeyComponent.Clear();
					HotkeyTab2.ClickedOption = Identifier;
					HotkeyComponent.NeedsKeys = true;
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(2f);
		}

		// Token: 0x04000366 RID: 870
		private static Vector2 scrollPosition1 = new Vector2(0f, 0f);

		// Token: 0x04000367 RID: 871
		public static Vector2 HotkeyScroll;

		// Token: 0x04000368 RID: 872
		public static string ClickedOption;

		// Token: 0x04000369 RID: 873
		public static bool IsFirst = true;
	}
}
