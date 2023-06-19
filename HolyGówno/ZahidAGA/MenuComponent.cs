using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200002F RID: 47
	[SpyComponent]
	[Component]
	public class MenuComponent : MonoBehaviour
	{
		// Token: 0x06000161 RID: 353 RVA: 0x00003282 File Offset: 0x00001482
		[Initializer]
		private static void Init()
		{
			int count = MenuTabOption.tabs.Count;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000BCE4 File Offset: 0x00009EE4
		public void Update()
		{
			HotkeyUtilities.Initialize();
			if ((HotkeyOptions.UnorganizedHotkeys["_MenuComponent"].Keys.Length == 0 && Input.GetKeyDown(MenuComponent.MenuKey)) || HotkeyUtilities.IsHotkeyDown("_MenuComponent"))
			{
				MenuComponent.IsInMenu = !MenuComponent.IsInMenu;
				bool isInMenu = MenuComponent.IsInMenu;
			}
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00002B44 File Offset: 0x00000D44
		public void OnGUI()
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00002B44 File Offset: 0x00000D44
		public static void DoMenu(int id)
		{
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000BD38 File Offset: 0x00009F38
		public static void DoBorder()
		{
			Rect rect;
			rect..ctor(0f, 0f, MenuComponent.MenuRect.width, MenuComponent.MenuRect.height);
			Rect rect2 = MenuUtilities.Inline(rect, 1f);
			Rect rect3 = MenuUtilities.Inline(rect2, 1f);
			Rect position = MenuUtilities.Inline(MenuUtilities.Inline(rect3, 3f), 1f);
			Rect position2;
			position2..ctor(position.x + 2f, position.y + 2f, position.width - 4f, 2f);
			Rect position3 = new Rect(position.x + 2f, position.y + 4f, position.width - 4f, 2f);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderLightGray, null);
			Drawing.DrawRect(rect3, MenuComponent._OutlineBorderDarkGray, null);
			Drawing.DrawRect(position, MenuComponent._FillLightBlack, null);
			Drawing.DrawRect(position2, MenuComponent._Accent1, null);
			Drawing.DrawRect(position3, MenuComponent._Accent2, null);
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000BE64 File Offset: 0x0000A064
		public static void DoTabs()
		{
			GUILayout.BeginArea(new Rect(15f, 25f, 620f, 100f));
			GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
			for (int i = 0; i < MenuTabOption.tabs.Count; i++)
			{
				if (Prefab.IMenuTab(i, ref MenuTabOption.tabs[i].enabled))
				{
					MenuTabOption.CurrentTab = (MenuTabOption.tabs[i].enabled ? MenuTabOption.tabs[i] : null);
				}
				GUILayout.Space(1f);
				if (MenuTabOption.tabs[i] != MenuTabOption.CurrentTab)
				{
					MenuTabOption.tabs[i].enabled = false;
				}
			}
			GUILayout.Space(20f);
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00003292 File Offset: 0x00001492
		public static void DrawTabs()
		{
			GUILayout.BeginArea(new Rect(15f, 80f, 611f, 406f));
			if (MenuTabOption.CurrentTab != null)
			{
				MenuTabOption.CurrentTab.tab();
			}
			GUILayout.EndArea();
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00002B44 File Offset: 0x00000D44
		public static void DoSectionTab()
		{
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000BF2C File Offset: 0x0000A12C
		public static void UpdateColors()
		{
			MenuComponent._OutlineBorderBlack = new Color32(3, 3, 3, byte.MaxValue);
			MenuComponent._OutlineBorderLightGray = new Color32(75, 75, 75, byte.MaxValue);
			MenuComponent._OutlineBorderDarkGray = new Color32(55, 55, 55, byte.MaxValue);
			MenuComponent._FillLightBlack = new Color32(25, 25, 25, byte.MaxValue);
			MenuComponent._Accent1 = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			MenuComponent._Accent2 = new Color32(244, 244, 244, byte.MaxValue);
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000032D0 File Offset: 0x000014D0
		public static void SetGUIColors()
		{
			MenuComponent.UpdateColors();
			Prefab.UpdateColors();
		}

		// Token: 0x0400008F RID: 143
		public static Texture2D[] Icons;

		// Token: 0x04000090 RID: 144
		public static Font _TabFont;

		// Token: 0x04000091 RID: 145
		public static Font _TextFont;

		// Token: 0x04000092 RID: 146
		public static Texture2D _Logo;

		// Token: 0x04000093 RID: 147
		public static bool IsInMenu;

		// Token: 0x04000094 RID: 148
		public static KeyCode MenuKey = 282;

		// Token: 0x04000095 RID: 149
		public static Rect MenuRect = new Rect(400f, 200f, 640f, 500f);

		// Token: 0x04000096 RID: 150
		public static Color32 _OutlineBorderBlack;

		// Token: 0x04000097 RID: 151
		public static Color32 _OutlineBorderLightGray;

		// Token: 0x04000098 RID: 152
		public static Color32 _OutlineBorderDarkGray;

		// Token: 0x04000099 RID: 153
		public static Color32 _FillLightBlack;

		// Token: 0x0400009A RID: 154
		public static Color32 _Accent1;

		// Token: 0x0400009B RID: 155
		public static Color32 _Accent2;

		// Token: 0x0400009C RID: 156
		public static Rect _cursor = new Rect(0f, 0f, 23f, 31f);

		// Token: 0x0400009D RID: 157
		private Texture _cursorTexture;

		// Token: 0x0400009E RID: 158
		public static int _pIndex = 0;
	}
}
