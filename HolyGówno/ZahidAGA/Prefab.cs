using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000008 RID: 8
	internal class Prefab
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00002B44 File Offset: 0x00000D44
		[Initializer]
		public static void Initialize()
		{
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000052B8 File Offset: 0x000034B8
		public static void CheckStyles()
		{
			Prefab._None = new GUIStyle();
			Prefab._None.normal.background = null;
			Prefab._MenuTabStyle = new GUIStyle
			{
				font = MenuComponent._TabFont,
				fontSize = 29
			};
			Prefab._HeaderStyle = new GUIStyle
			{
				font = MenuComponent._TabFont,
				fontSize = 15,
				alignment = 4
			};
			Prefab._TextStyle = new GUIStyle
			{
				font = MenuComponent._TextFont,
				fontSize = 16
			};
			Prefab._sliderStyle = new GUIStyle();
			Prefab._sliderThumbStyle = new GUIStyle(GUI.skin.horizontalSliderThumb)
			{
				fixedWidth = 7f
			};
			Prefab._sliderVThumbStyle = new GUIStyle(GUI.skin.verticalSliderThumb)
			{
				fixedHeight = 7f
			};
			Prefab._listStyle = new GUIStyle
			{
				alignment = 4,
				font = MenuComponent._TextFont,
				fontSize = 15
			};
			RectOffset padding = Prefab._listStyle.padding;
			RectOffset padding2 = Prefab._listStyle.padding;
			RectOffset padding3 = Prefab._listStyle.padding;
			Prefab._listStyle.padding.bottom = 4;
			padding3.top = 4;
			padding2.right = 4;
			padding.left = 4;
			Prefab._ButtonStyle = new GUIStyle
			{
				alignment = 3,
				font = MenuComponent._TextFont,
				fontSize = 15
			};
			RectOffset padding4 = Prefab._ButtonStyle.padding;
			RectOffset padding5 = Prefab._ButtonStyle.padding;
			RectOffset padding6 = Prefab._ButtonStyle.padding;
			Prefab._ButtonStyle.padding.bottom = 4;
			padding6.top = 4;
			padding5.right = 4;
			padding4.left = 4;
			Prefab._FlagButtonStyle = new GUIStyle
			{
				alignment = 3,
				font = MenuComponent._TextFont,
				fontSize = 15
			};
			RectOffset padding7 = Prefab._FlagButtonStyle.padding;
			RectOffset padding8 = Prefab._FlagButtonStyle.padding;
			RectOffset padding9 = Prefab._FlagButtonStyle.padding;
			Prefab._FlagButtonStyle.padding.bottom = 4;
			padding9.top = 4;
			padding8.right = 4;
			padding7.left = 4;
			MenuUtilities.FixGUIStyleColor(Prefab._sliderStyle);
			MenuUtilities.FixGUIStyleColor(Prefab._MenuTabStyle);
			MenuUtilities.FixGUIStyleColor(Prefab._TextStyle);
			Prefab.UpdateColors();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x000054D4 File Offset: 0x000036D4
		public static void ToggleLast(ref bool state)
		{
			Rect lastRect = GUILayoutUtility.GetLastRect();
			lastRect..ctor(lastRect.x + 161f, lastRect.y - 14f, 13f, 13f);
			Rect position = MenuUtilities.Inline(lastRect, 1f);
			Drawing.DrawRect(lastRect, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(position, Prefab._ToggleBoxBG, null);
			if (GUI.Button(lastRect, GUIContent.none, Prefab._TextStyle))
			{
				state = !state;
			}
			if (state)
			{
				Drawing.DrawRect(position, MenuComponent._Accent2, null);
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005570 File Offset: 0x00003770
		public static bool IMenuTab(int i, ref bool state)
		{
			GUI.color = ((!state) ? Prefab._MenuTabStyle.normal.textColor : Prefab._MenuTabStyle.active.textColor);
			bool result;
			if (GUILayout.Button(MenuComponent.Icons[i], Prefab._None, Array.Empty<GUILayoutOption>()))
			{
				state = !state;
				GUI.color = Color.white;
				result = true;
			}
			else
			{
				GUI.color = Color.white;
				result = false;
			}
			return result;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000055E0 File Offset: 0x000037E0
		public static void UpdateColors()
		{
			try
			{
				Prefab._MenuTabStyle.normal.textColor = new Color32(160, 160, 160, byte.MaxValue);
				Prefab._MenuTabStyle.onNormal.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._MenuTabStyle.hover.textColor = new Color32(210, 210, 210, byte.MaxValue);
				Prefab._MenuTabStyle.onHover.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._MenuTabStyle.active.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._MenuTabStyle.onActive.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._MenuTabStyle.focused.textColor = new Color32(160, 160, 160, byte.MaxValue);
				Prefab._MenuTabStyle.onFocused.textColor = new Color32(160, 160, 160, byte.MaxValue);
				Prefab._TextStyle.normal.textColor = new Color32(160, 160, 160, byte.MaxValue);
				Prefab._TextStyle.onNormal.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._TextStyle.hover.textColor = new Color32(210, 210, 210, byte.MaxValue);
				Prefab._TextStyle.onHover.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._TextStyle.active.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._TextStyle.onActive.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._TextStyle.focused.textColor = new Color32(160, 160, 160, byte.MaxValue);
				Prefab._TextStyle.onFocused.textColor = new Color32(160, 160, 160, byte.MaxValue);
				Prefab._HeaderStyle.normal.textColor = new Color32(210, 210, 210, byte.MaxValue);
				Prefab._listStyle.normal.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._listStyle.onNormal.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._listStyle.hover.textColor = new Color32(3, 3, 3, byte.MaxValue);
				Prefab._ButtonStyle.normal.textColor = new Color32(200, 200, 200, byte.MaxValue);
				Prefab._ButtonStyle.onNormal.textColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				Prefab._ButtonStyle.hover.textColor = new Color32(3, 3, 3, byte.MaxValue);
				Prefab._ButtonStyle.onHover.textColor = new Color32(3, 3, 3, byte.MaxValue);
				Texture2D texture2D = new Texture2D(1, 1);
				texture2D.SetPixel(0, 0, new Color32(210, 210, 210, byte.MaxValue));
				texture2D.Apply();
				Prefab._ButtonStyle.hover.background = texture2D;
				Texture2D texture2D2 = new Texture2D(1, 1);
				texture2D2.SetPixel(0, 0, new Color32(60, 60, 60, byte.MaxValue));
				texture2D2.Apply();
				Prefab._ButtonStyle.normal.background = texture2D2;
				Texture2D texture2D3 = new Texture2D(1, 1);
				texture2D3.SetPixel(0, 0, new Color32(100, 100, 100, byte.MaxValue));
				texture2D3.Apply();
				Prefab._ButtonStyle.active.background = texture2D3;
				Prefab._FlagButtonStyle.normal.textColor = new Color32(25, 25, 25, byte.MaxValue);
				Prefab._FlagButtonStyle.onNormal.textColor = new Color32(25, 25, 25, byte.MaxValue);
				Prefab._FlagButtonStyle.hover.textColor = new Color32(25, 25, 25, byte.MaxValue);
				Prefab._FlagButtonStyle.onHover.textColor = new Color32(25, 25, 25, byte.MaxValue);
				Texture2D texture2D4 = new Texture2D(1, 1);
				texture2D4.SetPixel(0, 0, new Color32(25, 25, 25, byte.MaxValue));
				texture2D4.Apply();
				Prefab._FlagButtonStyle.hover.background = texture2D4;
				Texture2D texture2D5 = new Texture2D(1, 1);
				texture2D5.SetPixel(0, 0, new Color32(25, 25, 25, byte.MaxValue));
				texture2D5.Apply();
				Prefab._FlagButtonStyle.normal.background = texture2D5;
				Texture2D texture2D6 = new Texture2D(1, 1);
				texture2D6.SetPixel(0, 0, new Color32(25, 25, 25, byte.MaxValue));
				texture2D6.Apply();
				Prefab._FlagButtonStyle.active.background = texture2D6;
				Prefab._listStyle.hover.background = texture2D3;
				Prefab._listStyle.onHover.background = texture2D3;
				Prefab._listStyle.normal.background = texture2D2;
				Prefab._listStyle.onNormal.background = texture2D2;
				Prefab._ToggleBoxBG = new Color32(71, 70, 71, byte.MaxValue);
			}
			catch
			{
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00005C7C File Offset: 0x00003E7C
		public static bool MenuTab(string text, ref bool state, int fontsize = 29)
		{
			bool result = false;
			bool flag = state;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.fontSize = fontsize;
			bool flag2 = GUILayout.Toggle(flag, text.ToUpper(), Prefab._MenuTabStyle, new GUILayoutOption[0]);
			if (flag != flag2)
			{
				state = !state;
				result = true;
			}
			Prefab._MenuTabStyle.fontSize = fontSize;
			return result;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00005CD8 File Offset: 0x00003ED8
		public static bool MenuTabAbsolute(Vector2 pos, string text, ref bool state, int fontsize = 29)
		{
			bool result = false;
			bool flag = state;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.fontSize = fontsize;
			Vector2 vector = Prefab._MenuTabStyle.CalcSize(new GUIContent(text));
			bool flag2 = GUI.Toggle(new Rect(pos, vector), flag, text.ToUpper(), Prefab._MenuTabStyle);
			if (flag != flag2)
			{
				state = !state;
				result = true;
			}
			Prefab._MenuTabStyle.fontSize = fontSize;
			return result;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00005D4C File Offset: 0x00003F4C
		public static void MenuArea(Rect area, string header, Action code)
		{
			Rect rect = new Rect(area.x, area.y + 5f, area.width, area.height - 5f);
			Rect rect2 = MenuUtilities.Inline(rect, 1f);
			Rect position = MenuUtilities.Inline(rect2, 1f);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderLightGray, null);
			Drawing.DrawRect(position, MenuComponent._FillLightBlack, null);
			Vector2 vector = Prefab._HeaderStyle.CalcSize(new GUIContent(header));
			Drawing.DrawRect(new Rect(area.x + 18f, area.y, vector.x + 4f, vector.y), MenuComponent._FillLightBlack, null);
			GUI.Label(new Rect(area.x + 20f, area.y - 3f, vector.x, vector.y), header, Prefab._HeaderStyle);
			GUILayout.BeginArea(area);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space(15f);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.Space(20f);
			try
			{
				code();
			}
			catch (Exception)
			{
			}
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00005EAC File Offset: 0x000040AC
		public static void SectionTabButton(string text, Action code, float space = 0f, int fontsize = 30)
		{
			bool flag = false;
			GUILayout.Space(space);
			Prefab.MenuTab(text, ref flag, fontsize);
			GUILayout.Space(space);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005ED4 File Offset: 0x000040D4
		public static bool Toggle(string text, ref bool state, int fontsize = 17)
		{
			bool result = false;
			int num = 1;
			int num2 = 15;
			int fontSize = Prefab._TextStyle.fontSize;
			Prefab._TextStyle.fontSize = fontsize;
			GUILayout.Space(3f);
			Rect rect = GUILayoutUtility.GetRect(150f, 15f);
			Rect rect2 = new Rect(rect.x + (float)num, rect.y + (float)num, (float)(num2 - num * 2), (float)(num2 - num * 2));
			Rect position = MenuUtilities.Inline(rect2, 1f);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(position, Prefab._ToggleBoxBG, null);
			if (GUI.Button(rect, GUIContent.none, Prefab._TextStyle))
			{
				state = !state;
				result = true;
			}
			if (Event.current.type == 7)
			{
				bool flag = rect.Contains(Event.current.mousePosition);
				bool flag2 = flag && Input.GetMouseButton(0);
				Prefab._TextStyle.Draw(new Rect(rect.x + 20f, rect.y, 130f, (float)num2), text, flag, flag2, false, false);
			}
			Prefab._TextStyle.fontSize = fontSize;
			if (state)
			{
				Drawing.DrawRect(position, MenuComponent._Accent2, null);
			}
			return result;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00006010 File Offset: 0x00004210
		public static void Slider(float left, float right, ref float value, int size)
		{
			GUIStyle sliderThumbStyle = Prefab._sliderThumbStyle;
			GUIStyle sliderStyle = Prefab._sliderStyle;
			float num = (sliderThumbStyle.fixedWidth != 0f) ? sliderThumbStyle.fixedWidth : ((float)sliderThumbStyle.padding.horizontal);
			value = GUILayout.HorizontalSlider(value, left, right, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb, new GUILayoutOption[]
			{
				GUILayout.Width((float)size)
			});
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = (lastRect.width - (float)sliderStyle.padding.horizontal - num) / (right - left);
			Rect rect = new Rect((value - left) * num2 + lastRect.x + (float)sliderStyle.padding.left, lastRect.y + (float)sliderStyle.padding.top, num, lastRect.height - (float)sliderStyle.padding.vertical);
			Drawing.DrawRect(lastRect, MenuComponent._FillLightBlack, null);
			Drawing.DrawRect(new Rect(lastRect.x, lastRect.y + lastRect.height / 2f - 2f, lastRect.width, 4f), Prefab._ToggleBoxBG, null);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(MenuUtilities.Inline(rect, 1f), Prefab._MenuTabStyle.onNormal.textColor, null);
			GUILayout.Space(5f);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00006174 File Offset: 0x00004374
		public static float Slider(float left, float right, float value, int size)
		{
			GUIStyle sliderThumbStyle = Prefab._sliderThumbStyle;
			GUIStyle sliderStyle = Prefab._sliderStyle;
			float num = (sliderThumbStyle.fixedWidth != 0f) ? sliderThumbStyle.fixedWidth : ((float)sliderThumbStyle.padding.horizontal);
			value = GUILayout.HorizontalSlider(value, left, right, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb, new GUILayoutOption[]
			{
				GUILayout.Width((float)size)
			});
			Rect lastRect = GUILayoutUtility.GetLastRect();
			float num2 = (lastRect.width - (float)sliderStyle.padding.horizontal - num) / (right - left);
			Rect rect = new Rect((value - left) * num2 + lastRect.x + (float)sliderStyle.padding.left, lastRect.y + (float)sliderStyle.padding.top, num, lastRect.height - (float)sliderStyle.padding.vertical);
			Drawing.DrawRect(lastRect, MenuComponent._FillLightBlack, null);
			Drawing.DrawRect(new Rect(lastRect.x, lastRect.y + lastRect.height / 2f - 2f, lastRect.width, 4f), Prefab._ToggleBoxBG, null);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(MenuUtilities.Inline(rect, 1f), Prefab._MenuTabStyle.onNormal.textColor, null);
			GUILayout.Space(5f);
			return value;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000062D8 File Offset: 0x000044D8
		public static void VerticalSlider(Rect pos, float top, float bottom, ref float value)
		{
			GUIStyle sliderVThumbStyle = Prefab._sliderVThumbStyle;
			GUIStyle sliderStyle = Prefab._sliderStyle;
			float num = (sliderVThumbStyle.fixedHeight != 0f) ? sliderVThumbStyle.fixedHeight : ((float)sliderVThumbStyle.padding.vertical);
			value = GUI.VerticalSlider(pos, value, top, bottom, Prefab._sliderStyle, GUI.skin.verticalSliderThumb);
			Rect position = pos;
			float num2 = (position.height - (float)sliderStyle.padding.vertical - num) / (bottom - top);
			Rect rect = new Rect(position.x + (float)sliderStyle.padding.left, (value - top) * num2 + position.y + (float)sliderStyle.padding.top, position.width - (float)sliderStyle.padding.horizontal, num);
			Drawing.DrawRect(position, MenuComponent._FillLightBlack, null);
			Drawing.DrawRect(new Rect(position.x + position.width / 2f - 2f, position.y, 4f, position.height), Prefab._ToggleBoxBG, null);
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(MenuUtilities.Inline(rect, 1f), Prefab._MenuTabStyle.onNormal.textColor, null);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000641C File Offset: 0x0000461C
		public static void ScrollView(Rect area, string title, ref Vector2 scrollpos, Action code, int padding = 20, params GUILayoutOption[] options)
		{
			Drawing.DrawRect(area, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(MenuUtilities.Inline(area, 1f), MenuComponent._OutlineBorderLightGray, null);
			Rect rect = MenuUtilities.Inline(area, 2f);
			Drawing.DrawRect(rect, MenuComponent._FillLightBlack, null);
			Color textColor = Prefab._MenuTabStyle.normal.textColor;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.normal.textColor = Prefab._MenuTabStyle.onNormal.textColor;
			Prefab._MenuTabStyle.fontSize = 15;
			Drawing.DrawRect(new Rect(rect.x, rect.y, rect.width, Prefab._MenuTabStyle.CalcSize(new GUIContent(title)).y + 2f), MenuComponent._OutlineBorderLightGray, null);
			GUILayout.BeginArea(rect);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.Label(title, Prefab._MenuTabStyle, new GUILayoutOption[0]);
			Prefab._MenuTabStyle.normal.textColor = textColor;
			Prefab._MenuTabStyle.fontSize = fontSize;
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.Space(2f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			scrollpos = GUILayout.BeginScrollView(scrollpos, false, true, new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space((float)padding);
			GUILayout.BeginVertical(new GUILayoutOption[]
			{
				GUILayout.MinHeight(rect.height)
			});
			try
			{
				code();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
			GUILayout.EndVertical();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			GUILayout.EndHorizontal();
			GUILayout.EndScrollView();
			Rect lastRect2 = GUILayoutUtility.GetLastRect();
			GUILayout.Space(1f);
			GUILayout.EndHorizontal();
			GUILayout.Space(1f);
			Drawing.DrawRect(new Rect(lastRect2.x + lastRect2.width - 16f, lastRect2.y, 16f, lastRect2.height), MenuComponent._FillLightBlack, null);
			if (lastRect.height - lastRect2.height > 0f)
			{
				Prefab.VerticalSlider(new Rect(lastRect2.x + 4f, lastRect2.y + 8f, 12f, lastRect2.height - 14f), 0f, lastRect.height - lastRect2.height, ref scrollpos.y);
			}
			GUILayout.EndArea();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000066A4 File Offset: 0x000048A4
		public static void ScrollView(Rect area, string title, ref SerializableVector2 scrollpos, Action code, int padding = 20, params GUILayoutOption[] options)
		{
			Drawing.DrawRect(area, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(MenuUtilities.Inline(area, 1f), MenuComponent._OutlineBorderLightGray, null);
			Rect rect = MenuUtilities.Inline(area, 2f);
			Drawing.DrawRect(rect, MenuComponent._FillLightBlack, null);
			Color textColor = Prefab._MenuTabStyle.normal.textColor;
			int fontSize = Prefab._MenuTabStyle.fontSize;
			Prefab._MenuTabStyle.normal.textColor = Prefab._MenuTabStyle.onNormal.textColor;
			Prefab._MenuTabStyle.fontSize = 15;
			Drawing.DrawRect(new Rect(rect.x, rect.y, rect.width, Prefab._MenuTabStyle.CalcSize(new GUIContent(title)).y + 2f), MenuComponent._OutlineBorderLightGray, null);
			GUILayout.BeginArea(rect);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.Label(title, Prefab._MenuTabStyle, new GUILayoutOption[0]);
			Prefab._MenuTabStyle.normal.textColor = textColor;
			Prefab._MenuTabStyle.fontSize = fontSize;
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.Space(2f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			scrollpos = GUILayout.BeginScrollView(scrollpos.ToVector2(), false, true, new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space((float)padding);
			GUILayout.BeginVertical(new GUILayoutOption[]
			{
				GUILayout.MinHeight(rect.height)
			});
			try
			{
				code();
			}
			catch (Exception)
			{
			}
			GUILayout.EndVertical();
			Rect lastRect = GUILayoutUtility.GetLastRect();
			GUILayout.EndHorizontal();
			GUILayout.EndScrollView();
			Rect lastRect2 = GUILayoutUtility.GetLastRect();
			GUILayout.Space(1f);
			GUILayout.EndHorizontal();
			GUILayout.Space(1f);
			Drawing.DrawRect(new Rect(lastRect2.x + lastRect2.width - 16f, lastRect2.y, 16f, lastRect2.height), MenuComponent._FillLightBlack, null);
			if (lastRect.height - lastRect2.height > 0f)
			{
				Prefab.VerticalSlider(new Rect(lastRect2.x + 4f, lastRect2.y + 8f, 12f, lastRect2.height - 14f), 0f, lastRect.height - lastRect2.height, ref scrollpos.y);
			}
			GUILayout.EndArea();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00006928 File Offset: 0x00004B28
		public static bool List(float width, string identifier, GUIContent buttonContent, GUIContent[] listContent, params GUILayoutOption[] options)
		{
			Vector2 vector = Prefab._listStyle.CalcSize(buttonContent);
			List<GUILayoutOption> list = options.ToList<GUILayoutOption>();
			list.Add(GUILayout.Height(vector.y));
			list.Add(GUILayout.Width(width));
			Rect rect = GUILayoutUtility.GetRect(width, vector.y, list.ToArray());
			DropDown dropDown = DropDown.Get(identifier);
			return Prefab.List(rect, ref dropDown.IsEnabled, ref dropDown.ListIndex, ref dropDown.ScrollView, buttonContent, listContent, "button", "box", Prefab._listStyle);
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000069B4 File Offset: 0x00004BB4
		public static bool List(string identifier, GUIContent buttonContent, GUIContent[] listContent, params GUILayoutOption[] options)
		{
			Vector2 vector = Prefab._listStyle.CalcSize(buttonContent);
			List<GUILayoutOption> list = options.ToList<GUILayoutOption>();
			list.Add(GUILayout.Height(vector.y));
			list.Add(GUILayout.Width(vector.x + 5f));
			Rect rect = GUILayoutUtility.GetRect(vector.x + 5f, vector.y, list.ToArray());
			DropDown dropDown = DropDown.Get(identifier);
			return Prefab.List(rect, ref dropDown.IsEnabled, ref dropDown.ListIndex, ref dropDown.ScrollView, buttonContent, listContent, "button", "box", Prefab._listStyle);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00006A54 File Offset: 0x00004C54
		public static bool List(Rect position, ref bool showList, ref int listEntry, ref Vector2 scrollPos, GUIContent buttonContent, GUIContent[] listContent)
		{
			return Prefab.List(position, ref showList, ref listEntry, ref scrollPos, buttonContent, listContent, "button", "box", Prefab._listStyle);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00006A88 File Offset: 0x00004C88
		public static bool List(Rect position, ref bool showList, ref int listEntry, ref Vector2 scrollPos, GUIContent buttonContent, GUIContent[] listContent, GUIStyle buttonStyle, GUIStyle boxStyle, GUIStyle listStyle)
		{
			Drawing.DrawRect(position, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(MenuUtilities.Inline(position, 1f), MenuComponent._OutlineBorderDarkGray, null);
			int fontSize = Prefab._TextStyle.fontSize;
			Color textColor = Prefab._TextStyle.normal.textColor;
			Prefab._TextStyle.fontSize = 15;
			Prefab._TextStyle.normal.textColor = Prefab._TextStyle.onNormal.textColor;
			Prefab._TextStyle.alignment = 4;
			GUI.Label(new Rect(position.x + position.height + 4f, position.y, position.width - position.height * 2f, position.height), buttonContent, Prefab._TextStyle);
			bool result = false;
			if (Prefab.AbsButton(new Rect(position.x, position.y, position.height, position.height), "<", new GUILayoutOption[0]))
			{
				result = true;
				listEntry = Math.Max(0, listEntry - 1);
			}
			if (Prefab.AbsButton(new Rect(position.x + position.width - position.height, position.y, position.height, position.height), ">", new GUILayoutOption[0]))
			{
				result = true;
				listEntry = Math.Min(listContent.Length - 1, listEntry + 1);
			}
			Prefab._TextStyle.alignment = 0;
			Prefab._TextStyle.fontSize = fontSize;
			Prefab._TextStyle.normal.textColor = textColor;
			return result;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00002B46 File Offset: 0x00000D46
		public static bool AbsButton(Rect area, string text, params GUILayoutOption[] options)
		{
			Drawing.DrawRect(area, MenuComponent._OutlineBorderBlack, null);
			return GUI.Button(MenuUtilities.Inline(area, 1f), text, Prefab._ButtonStyle);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00002B6F File Offset: 0x00000D6F
		public static bool Button(string text, Rect rect)
		{
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack, null);
			return GUI.Button(MenuUtilities.Inline(rect, 1f), text, Prefab._ButtonStyle);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00002B98 File Offset: 0x00000D98
		public static bool Button2(Rect rect, Texture2D sa)
		{
			return GUI.Button(MenuUtilities.Inline(rect, 1f), sa, Prefab._FlagButtonStyle);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00006C1C File Offset: 0x00004E1C
		public static bool Button(string text, float width, float height = 25f, params GUILayoutOption[] options)
		{
			List<GUILayoutOption> list = options.ToList<GUILayoutOption>();
			list.Add(GUILayout.Height(height));
			list.Add(GUILayout.Width(width));
			return Prefab.AbsButton(GUILayoutUtility.GetRect(width, height, list.ToArray()), text, options);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00006C5C File Offset: 0x00004E5C
		public static bool ColorButton(float width, ColorVariable color, float height = 25f, params GUILayoutOption[] options)
		{
			List<GUILayoutOption> list = options.ToList<GUILayoutOption>();
			list.Add(GUILayout.Height(height));
			list.Add(GUILayout.Width(width));
			Rect rect = GUILayoutUtility.GetRect(width, height, list.ToArray());
			Drawing.DrawRect(rect, MenuComponent._OutlineBorderBlack, null);
			Rect rect2 = new Rect(rect.x + 4f, rect.y + 4f, rect.height - 8f, rect.height - 8f);
			bool result = GUI.Button(MenuUtilities.Inline(rect, 1f), color.name ?? "", Prefab._ButtonStyle);
			Drawing.DrawRect(rect2, MenuComponent._OutlineBorderBlack, null);
			Drawing.DrawRect(MenuUtilities.Inline(rect2, 1f), MenuComponent._OutlineBorderLightGray, null);
			Drawing.DrawRect(MenuUtilities.Inline(rect2, 2f), color.color, null);
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00006D50 File Offset: 0x00004F50
		public static string TextField(string text, string label, int width)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(label, Prefab._TextStyle, new GUILayoutOption[0]);
			int fontSize = Prefab._TextStyle.fontSize;
			Prefab._TextStyle.fontSize = 13;
			float y = Prefab._TextStyle.CalcSize(new GUIContent("asdf")).y;
			Rect rect = GUILayoutUtility.GetRect((float)width, y);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height + 1f), MenuComponent._OutlineBorderLightGray, null);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height), MenuComponent._FillLightBlack, null);
			text = GUI.TextField(new Rect(rect.x + 4f, rect.y + 2f, rect.width, rect.height), text, Prefab._TextStyle);
			GUILayout.FlexibleSpace();
			Prefab._TextStyle.fontSize = fontSize;
			GUILayout.EndHorizontal();
			return text;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00006E78 File Offset: 0x00005078
		public static int TextField(int text, string label, int width, int min = 0, int max = 255)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(label, Prefab._TextStyle, new GUILayoutOption[0]);
			int fontSize = Prefab._TextStyle.fontSize;
			Prefab._TextStyle.fontSize = 13;
			float y = Prefab._TextStyle.CalcSize(new GUIContent("asdf")).y;
			Rect rect = GUILayoutUtility.GetRect((float)width, y);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height + 1f), MenuComponent._OutlineBorderLightGray, null);
			Drawing.DrawRect(new Rect(rect.x, rect.y + 2f, rect.width, rect.height), MenuComponent._FillLightBlack, null);
			try
			{
				int num = int.Parse(Prefab.digitsOnly.Replace(GUI.TextField(new Rect(rect.x + 4f, rect.y + 2f, rect.width, rect.height), text.ToString(), Prefab._TextStyle), ""));
				if (num >= min && num <= max)
				{
					text = num;
				}
			}
			catch (Exception)
			{
			}
			GUILayout.FlexibleSpace();
			Prefab._TextStyle.fontSize = fontSize;
			GUILayout.EndHorizontal();
			return text;
		}

		// Token: 0x0400001F RID: 31
		public static GUIStyle _None;

		// Token: 0x04000020 RID: 32
		public static GUIStyle _MenuTabStyle;

		// Token: 0x04000021 RID: 33
		public static GUIStyle _HeaderStyle;

		// Token: 0x04000022 RID: 34
		public static GUIStyle _TextStyle;

		// Token: 0x04000023 RID: 35
		public static GUIStyle _sliderStyle;

		// Token: 0x04000024 RID: 36
		public static GUIStyle _sliderThumbStyle;

		// Token: 0x04000025 RID: 37
		public static GUIStyle _sliderVThumbStyle;

		// Token: 0x04000026 RID: 38
		public static GUIStyle _listStyle;

		// Token: 0x04000027 RID: 39
		public static GUIStyle _FlagButtonStyle;

		// Token: 0x04000028 RID: 40
		public static GUIStyle _ButtonStyle;

		// Token: 0x04000029 RID: 41
		public static Color32 _ToggleBoxBG;

		// Token: 0x0400002A RID: 42
		private static int popupListHash = "PopupList".GetHashCode();

		// Token: 0x0400002B RID: 43
		public static Regex digitsOnly = new Regex("[^\\d]");
	}
}
