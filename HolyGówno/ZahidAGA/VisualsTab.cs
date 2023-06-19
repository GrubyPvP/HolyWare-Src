using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000CB RID: 203
	public class VisualsTab
	{
		// Token: 0x06000374 RID: 884 RVA: 0x000190C4 File Offset: 0x000172C4
		public static void Tab()
		{
			GUILayout.Space(0f);
			GUILayout.BeginArea(new Rect(300f, 0f, 940f, 40f));
			VisualsTab.SelectedObject = (ESPTarget)GUI.Toolbar(new Rect(25f, 10f, 680f, 40f), (int)VisualsTab.SelectedObject, Main.buttons2.ToArray(), "TabBtn");
			GUILayout.EndArea();
			Rect rect = new Rect(340f, 70f, 350f, 440f);
			GUIStyle guistyle = "box";
			GUILayout.BeginArea(rect, Enum.GetName(typeof(ESPTarget), VisualsTab.SelectedObject), guistyle);
			VisualsTab.scrollPosition = GUILayout.BeginScrollView(VisualsTab.scrollPosition, Array.Empty<GUILayoutOption>());
			switch (VisualsTab.SelectedObject)
			{
			case ESPTarget.Player:
				VisualsTab.DrawGlobals(ESPTarget.Player, "Players");
				ESPOptions.ShowPlayerWeapon = GUILayout.Toggle(ESPOptions.ShowPlayerWeapon, "Show Weapon", Array.Empty<GUILayoutOption>());
				ESPOptions.showhotbar = GUILayout.Toggle(ESPOptions.showhotbar, "Show Weapon Icon", Array.Empty<GUILayoutOption>());
				VisualsTab.DrawGlobals2(ESPTarget.Player);
				break;
			case ESPTarget.Zombie:
				VisualsTab.DrawGlobals(ESPTarget.Zombie, "Zombies");
				VisualsTab.DrawGlobals2(ESPTarget.Zombie);
				break;
			case ESPTarget.Item:
				VisualsTab.DrawGlobals(ESPTarget.Item, "Items");
				VisualsTab.DrawGlobals2(ESPTarget.Item);
				break;
			case ESPTarget.Sentry:
				VisualsTab.DrawGlobals(ESPTarget.Sentry, "Sentry");
				ESPOptions.ShowSentryItem = GUILayout.Toggle(ESPOptions.ShowSentryItem, "Show Sentry Gun", Array.Empty<GUILayoutOption>());
				VisualsTab.DrawGlobals2(ESPTarget.Sentry);
				break;
			case ESPTarget.Bed:
				VisualsTab.DrawGlobals(ESPTarget.Bed, "Beds");
				ESPOptions.ClaimNameBed = GUILayout.Toggle(ESPOptions.ClaimNameBed, "Show Claimed State", Array.Empty<GUILayoutOption>());
				VisualsTab.DrawGlobals2(ESPTarget.Bed);
				break;
			case ESPTarget.Flag:
				VisualsTab.DrawGlobals(ESPTarget.Flag, "Claim Flags");
				VisualsTab.DrawGlobals2(ESPTarget.Flag);
				break;
			case ESPTarget.Vehicle:
				VisualsTab.DrawGlobals(ESPTarget.Vehicle, "Vehicles");
				ESPOptions.ShowVehicleLocked = GUILayout.Toggle(ESPOptions.ShowVehicleLocked, "Show Lock State", Array.Empty<GUILayoutOption>());
				ESPOptions.FilterVehicleLocked = GUILayout.Toggle(ESPOptions.FilterVehicleLocked, "Only Display Unlocked Vehicles", Array.Empty<GUILayoutOption>());
				VisualsTab.DrawGlobals2(ESPTarget.Vehicle);
				break;
			case ESPTarget.Storage:
				VisualsTab.DrawGlobals(ESPTarget.Storage, "Storages");
				VisualsTab.DrawGlobals2(ESPTarget.Storage);
				break;
			case ESPTarget.Airdrop:
				VisualsTab.DrawGlobals(ESPTarget.Airdrop, "Airdrop");
				VisualsTab.DrawGlobals2(ESPTarget.Airdrop);
				break;
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 70f, 290f, 400f), "Other", "box");
			MiscOptions.NoRain = GUILayout.Toggle(MiscOptions.NoRain, "No Rain", Array.Empty<GUILayoutOption>());
			ESPOptions.ChamsFlat = GUILayout.Toggle(ESPOptions.ChamsFlat, "Flat Chams", Array.Empty<GUILayoutOption>());
			MiscOptions.GPS = GUILayout.Toggle(MiscOptions.GPS, "Force GPS", Array.Empty<GUILayoutOption>());
			ESPOptions.ShowMap = GUILayout.Toggle(ESPOptions.ShowMap, "Show Player On Map", Array.Empty<GUILayoutOption>());
			MiscOptions.NightVision = GUILayout.Toggle(MiscOptions.NightVision, "NightVision", Array.Empty<GUILayoutOption>());
			MiscOptions.Compass = GUILayout.Toggle(MiscOptions.Compass, "Force Compass", Array.Empty<GUILayoutOption>());
			GUILayout.Space(2f);
			GUILayout.EndArea();
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000193EC File Offset: 0x000175EC
		private static void DrawGlobals2(ESPTarget esptarget)
		{
			ESPVisual espvisual = ESPOptions.VisualOptions[(int)esptarget];
			GUILayout.Space(2f);
			GUILayout.Label("Max Render Distance: " + espvisual.Distance.ToString(), Array.Empty<GUILayoutOption>());
			espvisual.Distance = (float)((int)GUILayout.HorizontalSlider(espvisual.Distance, 0f, 3000f, Array.Empty<GUILayoutOption>()));
			GUILayout.Space(2f);
			GUILayout.Label("Font Size: " + espvisual.FixedTextSize.ToString(), Array.Empty<GUILayoutOption>());
			espvisual.FixedTextSize = (int)GUILayout.HorizontalSlider((float)espvisual.FixedTextSize, 0f, 24f, Array.Empty<GUILayoutOption>());
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00019498 File Offset: 0x00017698
		private static void DrawGlobals(ESPTarget esptarget, string objname)
		{
			ESPVisual espvisual = ESPOptions.VisualOptions[(int)esptarget];
			GUILayout.Space(2f);
			espvisual.Enabled = GUILayout.Toggle(espvisual.Enabled, objname + " ESP Enabled", Array.Empty<GUILayoutOption>());
			if (!espvisual.Enabled)
			{
				espvisual.Glow = false;
			}
			espvisual.Boxes = GUILayout.Toggle(espvisual.Boxes, "Box", Array.Empty<GUILayoutOption>());
			espvisual.Glow = GUILayout.Toggle(espvisual.Glow, "Glow", Array.Empty<GUILayoutOption>());
			espvisual.LineToObject = GUILayout.Toggle(espvisual.LineToObject, "Snaplines", Array.Empty<GUILayoutOption>());
			espvisual.ShowName = GUILayout.Toggle(espvisual.ShowName, "Name", Array.Empty<GUILayoutOption>());
			espvisual.ShowDistance = GUILayout.Toggle(espvisual.ShowDistance, "Distance", Array.Empty<GUILayoutOption>());
		}

		// Token: 0x040003C3 RID: 963
		public static ESPTarget SelectedObject;

		// Token: 0x040003C4 RID: 964
		private static Vector2 scrollPosition;
	}
}
