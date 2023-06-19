using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000C1 RID: 193
	[Component]
	public class Main : MonoBehaviour
	{
		// Token: 0x06000337 RID: 823 RVA: 0x00016320 File Offset: 0x00014520
		private void Start()
		{
			Main.GUIColor = GUI.color;
			foreach (object obj in Enum.GetValues(typeof(MenuTab)))
			{
				MenuTab menuTab = (MenuTab)obj;
				Main.buttons.Add(new GUIContent(Enum.GetName(typeof(MenuTab), menuTab)));
			}
			foreach (object obj2 in Enum.GetValues(typeof(ESPTarget)))
			{
				ESPTarget esptarget = (ESPTarget)obj2;
				Main.buttons2.Add(new GUIContent(Enum.GetName(typeof(ESPTarget), esptarget)));
			}
			foreach (object obj3 in Enum.GetValues(typeof(SkinType)))
			{
				SkinType skinType = (SkinType)obj3;
				Main.buttons7.Add(new GUIContent(Enum.GetName(typeof(SkinType), skinType)));
			}
			foreach (object obj4 in Enum.GetValues(typeof(SettingsOptions)))
			{
				SettingsOptions settingsOptions = (SettingsOptions)obj4;
				Main.buttons4.Add(new GUIContent(Enum.GetName(typeof(SettingsOptions), settingsOptions)));
			}
			Main.timeDelta = Random.value;
			Main.objHSV.GetComponent<Renderer>().sharedMaterial = (Main.objHSVMaterial = new Material(Shader.Find("Standard")));
			Main.objPlainColor.GetComponent<Renderer>().sharedMaterial = (Main.objPlainColorMaterial = new Material(Shader.Find("Standard")));
			Main.guiStyleState = new GUIStyleState
			{
				textColor = Color.red
			};
			Main.guiStyle = new GUIStyle
			{
				fontSize = 36,
				normal = Main.guiStyleState
			};
		}

		// Token: 0x06000338 RID: 824 RVA: 0x000043E7 File Offset: 0x000025E7
		[Override(typeof(LocalHwid), "GetHwids", BindingFlags.Static | BindingFlags.Public, 0)]
		public static byte[][] OV_GetHwids()
		{
			byte[][] array = (byte[][])Main.method.Invoke(null, null);
			array.SetValue(Main.CreateRandomHwid(), 0);
			array.SetValue(Main.CreateRandomHwid(), 1);
			array.SetValue(Main.CreateRandomHwid(), 2);
			return array;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0001657C File Offset: 0x0001477C
		public static byte[] CreateRandomHwid()
		{
			byte[] array = new byte[20];
			for (int i = 0; i < 20; i++)
			{
				array[i] = (byte)Random.Range(0, 256);
			}
			return array;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000165B0 File Offset: 0x000147B0
		private void Update()
		{
			if (ESPOptions.SpinBotOyuncu && OptimizationVariables.MainPlayer != null)
			{
				PlayerLook.characterYaw = (float)new Random().Next(0, 360);
			}
			if (MiscOptions.NoRain)
			{
				LightingManager.DisableWeather();
			}
			if (MiscOptions.Spam)
			{
				ChatManager.sendChat(0, MiscOptions.SpamText);
			}
			if ((HotkeyOptions.UnorganizedHotkeys["_MenuComponent"].Keys.Length == 0 && Input.GetKeyDown(Main.MenuKey)) || HotkeyUtilities.IsHotkeyDown("_MenuComponent"))
			{
				if (!Main.MenuOpen)
				{
					Main.MenuOpen = true;
				}
				else
				{
					Main.MenuOpen = false;
					this.i = -40;
				}
			}
			Main.timeDelta += Time.deltaTime / 200f;
			Main.objHSVMaterial.color = Main.GetRandomHSVColor();
			Main.objPlainColorMaterial.color = Main.GetRandomColor();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00016688 File Offset: 0x00014888
		public static Color GetRandomHSVColor()
		{
			float[] array = Main.Perlin();
			return Color.HSVToRGB(array[0], array[1], array[2]);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x000166AC File Offset: 0x000148AC
		public static Color GetRandomColor()
		{
			float[] array = Main.Perlin();
			return new Color(array[0], array[1], array[2]);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000166D0 File Offset: 0x000148D0
		public static float[] Perlin()
		{
			return new float[]
			{
				Mathf.PerlinNoise(0.5f, 23.3f * Main.timeDelta),
				Mathf.PerlinNoise(0.5f, 54.4f * Main.timeDelta),
				Mathf.PerlinNoise(0.5f, 12.6f * Main.timeDelta)
			};
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0001672C File Offset: 0x0001492C
		private void OnGUI()
		{
			if (!G.BeingSpied)
			{
				if (MiscOptions.water)
				{
					byte[][] hwids = LocalHwid.GetHwids();
					for (int i = 0; i < hwids.Length; i++)
					{
						string str = BitConverter.ToString(hwids[i]);
						T.DrawOutlineLabel(new Vector2(125f, 50f), WeaponComponent.RGBRenk, Color.black, str + "\n", null);
					}
				}
				foreach (NotificationWindow notificationWindow in T.Notifications)
				{
					notificationWindow.Run();
				}
				if (Main.MenuOpen)
				{
					GUI.skin = AssetUtilities.Skin;
					if (this._cursorTexture == null)
					{
						this._cursorTexture = AssetUtilities.Textures["indir"];
					}
					GUI.Label(new Rect(this.windowRect.x + 80f, this.windowRect.y + 125f, 32f, 32f), Main._Aimbot);
					GUI.Label(new Rect(this.windowRect.x + 80f, this.windowRect.y + 185f, 32f, 32f), Main._Visual);
					GUI.Label(new Rect(this.windowRect.x + 80f, this.windowRect.y + 250f, 32f, 32f), Main._other);
					GUI.Label(new Rect(this.windowRect.x + 80f, this.windowRect.y + 310f, 32f, 32f), Main._player);
					GUI.Label(new Rect(this.windowRect.x + 80f, this.windowRect.y + 370f, 40f, 40f), Main._Skin);
					GUI.Label(new Rect(this.windowRect.x + 80f, this.windowRect.y + 435f, 32f, 32f), Main._settings);
					GUI.Label(new Rect(this.windowRect.x + 80f, this.windowRect.y + 495f, 32f, 32f), Main._Keyboard);
					GUI.Label(new Rect(this.windowRect.x + 18f, this.windowRect.y + 615f, 400f, 20f), "HOLYWARE");
					GUI.Label(new Rect(this.windowRect.x + 40f, this.windowRect.y + 30f, 500f, 70f), "<size=40><b>HOLYWARE</b></size>");
					GUI.depth = -1;
					GUIStyle guistyle = new GUIStyle("label");
					guistyle.margin = new RectOffset(10, 10, 5, 5);
					guistyle.fontSize = 22;
					if (this.i < 0)
					{
						this.i++;
					}
					this.windowRect = GUILayout.Window(0, this.windowRect, new GUI.WindowFunction(this.MenuWindow), "", Array.Empty<GUILayoutOption>());
					GUILayout.BeginArea(new Rect(0f, (float)this.i, (float)Screen.width, 40f), "");
					GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
					GUI.color = new Color32(34, 177, 76, byte.MaxValue);
					GUILayout.Label(string.Concat(new string[]
					{
						"<b>",
						this.Name,
						"</b> <size=15>",
						this.Version,
						"</size>"
					}), guistyle, Array.Empty<GUILayoutOption>());
					GUI.color = Main.GUIColor;
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
					GUI.depth = -2;
					Main.CursorPos.x = Input.mousePosition.x;
					Main.CursorPos.y = (float)Screen.height - Input.mousePosition.y;
					GUI.DrawTexture(Main.CursorPos, this._cursorTexture);
					Cursor.lockState = 0;
					if (PlayerUI.window != null)
					{
						PlayerUI.window.showCursor = true;
					}
					GUI.skin = null;
				}
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00016B94 File Offset: 0x00014D94
		private void MenuWindow(int windowID)
		{
			GUILayout.Space(0f);
			switch (Main.SelectedTab)
			{
			case MenuTab.Aimbot:
				AimbotTab2.Tab();
				break;
			case MenuTab.Visuals:
				VisualsTab.Tab();
				break;
			case MenuTab.Misc:
				MiscTab2.Tab();
				break;
			case MenuTab.Players:
				PlayersTab2.Tab();
				break;
			case MenuTab.Skins:
				Skins2.Tab();
				break;
			case MenuTab.Settings:
				SettingsTab.Tab();
				break;
			case MenuTab.Keybınds:
				HotkeyTab2.Tab();
				break;
			}
			GUILayout.BeginArea(new Rect(35f, 108f, 260f, 500f));
			int fontSize = GUI.skin.button.fontSize;
			GUI.skin.button.fixedHeight = 58f;
			GUI.skin.button.fontSize = 20;
			Main.SelectedTab = (MenuTab)GUILayout.SelectionGrid((int)Main.SelectedTab, Main.buttons.ToArray(), 1, Array.Empty<GUILayoutOption>());
			GUI.skin.button.fixedHeight = 40f;
			GUI.skin.button.fontSize = fontSize;
			GUILayout.EndArea();
			GUI.DragWindow();
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00016CA4 File Offset: 0x00014EA4
		public Main()
		{
			Main.buttons = new List<GUIContent>();
			this.i = -40;
			this.windowRect = new Rect(80f, 80f, 1010f, 645f);
			this.itemRect = new Rect(400f, 465f, 300f, 200f);
			this.guiRect = new Rect(100f, 755f, 200f, 250f);
			this.colorect = new Rect(20f, 465f, 250f, 300f);
		}

		// Token: 0x0400036E RID: 878
		public static GameObject objHSV;

		// Token: 0x0400036F RID: 879
		public static GameObject objPlainColor;

		// Token: 0x04000370 RID: 880
		public static Material objHSVMaterial;

		// Token: 0x04000371 RID: 881
		public static Material objPlainColorMaterial;

		// Token: 0x04000372 RID: 882
		public static float timeDelta;

		// Token: 0x04000373 RID: 883
		public static Rect rect = new Rect(10f, 10f, 0f, 0f);

		// Token: 0x04000374 RID: 884
		public static readonly GUIContent guiContent = new GUIContent("HSV coloring on the left, RGB on the right.");

		// Token: 0x04000375 RID: 885
		public static GUIStyleState guiStyleState;

		// Token: 0x04000376 RID: 886
		public static GUIStyle guiStyle;

		// Token: 0x04000377 RID: 887
		public static KeyCode MenuKey = 282;

		// Token: 0x04000378 RID: 888
		public static bool changedHwid = false;

		// Token: 0x04000379 RID: 889
		public static MenuTab SelectedTab = MenuTab.Aimbot;

		// Token: 0x0400037A RID: 890
		public static bool MenuOpen = false;

		// Token: 0x0400037B RID: 891
		public static string DropdownTitle;

		// Token: 0x0400037C RID: 892
		public static Rect DropdownPos;

		// Token: 0x0400037D RID: 893
		public static Color GUIColor;

		// Token: 0x0400037E RID: 894
		public static Texture2D _Logo;

		// Token: 0x0400037F RID: 895
		public static Texture2D _Aimbot;

		// Token: 0x04000380 RID: 896
		public static Texture2D _Visual;

		// Token: 0x04000381 RID: 897
		public static Texture2D _other;

		// Token: 0x04000382 RID: 898
		public static Texture2D _settings;

		// Token: 0x04000383 RID: 899
		public static Texture2D _asset;

		// Token: 0x04000384 RID: 900
		public static Texture2D _Skin;

		// Token: 0x04000385 RID: 901
		public static Texture2D _Keyboard;

		// Token: 0x04000386 RID: 902
		public static Texture2D _maps;

		// Token: 0x04000387 RID: 903
		public static Texture2D _player;

		// Token: 0x04000388 RID: 904
		public static List<GUIContent> buttons2 = new List<GUIContent>();

		// Token: 0x04000389 RID: 905
		public static List<GUIContent> buttons = new List<GUIContent>();

		// Token: 0x0400038A RID: 906
		public static List<GUIContent> buttons3 = new List<GUIContent>();

		// Token: 0x0400038B RID: 907
		public static List<GUIContent> buttons4 = new List<GUIContent>();

		// Token: 0x0400038C RID: 908
		public static List<GUIContent> buttons5 = new List<GUIContent>();

		// Token: 0x0400038D RID: 909
		public static List<GUIContent> buttons6 = new List<GUIContent>();

		// Token: 0x0400038E RID: 910
		public static List<GUIContent> buttons7 = new List<GUIContent>();

		// Token: 0x0400038F RID: 911
		public static Rect CursorPos = new Rect(0f, 0f, 20f, 20f);

		// Token: 0x04000390 RID: 912
		private int i;

		// Token: 0x04000391 RID: 913
		private Texture _cursorTexture;

		// Token: 0x04000392 RID: 914
		private Rect windowRect;

		// Token: 0x04000393 RID: 915
		private Rect itemRect;

		// Token: 0x04000394 RID: 916
		private Rect guiRect;

		// Token: 0x04000395 RID: 917
		private Rect colorect;

		// Token: 0x04000396 RID: 918
		private readonly string Name;

		// Token: 0x04000397 RID: 919
		private readonly string Version;

		// Token: 0x04000398 RID: 920
		public static MethodBase method = typeof(LocalHwid).GetMethod("InitHwids", BindingFlags.Static | BindingFlags.NonPublic);
	}
}
