using System;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000C2 RID: 194
	public class MiscTab2
	{
		// Token: 0x06000342 RID: 834 RVA: 0x00016E20 File Offset: 0x00015020
		public static void Tab()
		{
			GUILayout.Space(0f);
			GUILayout.BeginArea(new Rect(340f, 70f, 350f, 300f), "Game", "box");
			MiscOptions.Freecam = GUILayout.Toggle(MiscOptions.Freecam, "Free Cam", Array.Empty<GUILayoutOption>());
			MiscOptions.ShowVanish = GUILayout.Toggle(MiscOptions.ShowVanish, "Show Vanished Players", Array.Empty<GUILayoutOption>());
			MiscOptions.SpamText = GUILayout.TextField(MiscOptions.SpamText, Array.Empty<GUILayoutOption>());
			MiscOptions.Spam = GUILayout.Toggle(MiscOptions.Spam, "Enable Spam", Array.Empty<GUILayoutOption>());
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 70f, 290f, 400f), "WeaponOptions", "box");
			WeaponOptions.NoRecoil = GUILayout.Toggle(WeaponOptions.NoRecoil, "Remove Recoil", Array.Empty<GUILayoutOption>());
			WeaponOptions.NoSpread = GUILayout.Toggle(WeaponOptions.NoSpread, "Remove Spread", Array.Empty<GUILayoutOption>());
			WeaponOptions.NoSway = GUILayout.Toggle(WeaponOptions.NoSway, "Remove Sway", Array.Empty<GUILayoutOption>());
			WeaponOptions.RemoveBurstDelay = GUILayout.Toggle(WeaponOptions.RemoveBurstDelay, "Remove Burst Delay", Array.Empty<GUILayoutOption>());
			WeaponOptions.RemoveHammerDelay = GUILayout.Toggle(WeaponOptions.RemoveHammerDelay, "Remove Hammer Delay", Array.Empty<GUILayoutOption>());
			WeaponOptions.InstantReload = GUILayout.Toggle(WeaponOptions.InstantReload, "Remove Reload Delay", Array.Empty<GUILayoutOption>());
			WeaponOptions.ShowWeaponInfo = GUILayout.Toggle(WeaponOptions.ShowWeaponInfo, "Show Weapon Info", Array.Empty<GUILayoutOption>());
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(340f, 380f, 350f, 250f), "Other", "box");
			MiscTab2.scrollPosition3 = GUILayout.BeginScrollView(MiscTab2.scrollPosition3, Array.Empty<GUILayoutOption>());
			MiscOptions.BuildObs = GUILayout.Toggle(MiscOptions.BuildObs, "Build OBS", Array.Empty<GUILayoutOption>());
			MiscOptions.CustomSalvageTime = GUILayout.Toggle(MiscOptions.CustomSalvageTime, "Custom Salvage Time", Array.Empty<GUILayoutOption>());
			if (MiscOptions.CustomSalvageTime)
			{
				GUILayout.Label("Time: " + MiscOptions.SalvageTime.ToString() + " seconds", Array.Empty<GUILayoutOption>());
				MiscOptions.SalvageTime = GUILayout.HorizontalSlider(MiscOptions.SalvageTime, 0.2f, 10f, Array.Empty<GUILayoutOption>());
			}
			InteractionOptions.InteractThroughWalls = GUILayout.Toggle(InteractionOptions.InteractThroughWalls, "Interact Through Walls", Array.Empty<GUILayoutOption>());
			MiscOptions.water = GUILayout.Toggle(MiscOptions.water, "HWID CHANCER", Array.Empty<GUILayoutOption>());
			MiscOptions.Adam = GUILayout.Toggle(MiscOptions.Adam, "Change Player Scale", Array.Empty<GUILayoutOption>());
			if (MiscOptions.Adam)
			{
				MiscTab2.zort.x = GUILayout.HorizontalSlider(MiscTab2.zort.x, 0.5f, 14f, Array.Empty<GUILayoutOption>());
				MiscTab2.zort.y = GUILayout.HorizontalSlider(MiscTab2.zort.y, 0.5f, 14f, Array.Empty<GUILayoutOption>());
				MiscTab2.zort.z = GUILayout.HorizontalSlider(MiscTab2.zort.z, 0.5f, 14f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Active Player Size: X: {0} | Y: {1} | {2}", MiscTab2.zort.x, MiscTab2.zort.y, MiscTab2.zort.z), Array.Empty<GUILayoutOption>());
				foreach (SteamPlayer steamPlayer in Provider.clients)
				{
					if (steamPlayer.playerID != OptimizationVariables.MainPlayer.channel.owner.playerID)
					{
						steamPlayer.player.gameObject.transform.localScale = MiscTab2.zort;
					}
				}
				if (GUILayout.Button("Reset Player Size", Array.Empty<GUILayoutOption>()))
				{
					MiscTab2.zort = new Vector3(1f, 1f, 1f);
				}
			}
			MiscOptions.Adam2 = GUILayout.Toggle(MiscOptions.Adam2, "Change Local Player Scale", Array.Empty<GUILayoutOption>());
			if (MiscOptions.Adam2)
			{
				MiscTab2.zort2.x = GUILayout.HorizontalSlider(MiscTab2.zort2.x, 0.5f, 14f, Array.Empty<GUILayoutOption>());
				MiscTab2.zort2.y = GUILayout.HorizontalSlider(MiscTab2.zort2.y, 0.5f, 14f, Array.Empty<GUILayoutOption>());
				MiscTab2.zort2.z = GUILayout.HorizontalSlider(MiscTab2.zort2.z, 0.5f, 14f, Array.Empty<GUILayoutOption>());
				GUILayout.Label(string.Format("Active Player Size: X: {0} | Y: {1} | {2}", MiscTab2.zort2.x, MiscTab2.zort2.y, MiscTab2.zort2.z), Array.Empty<GUILayoutOption>());
				OptimizationVariables.MainPlayer.gameObject.transform.localScale = MiscTab2.zort2;
				if (GUILayout.Button("Reset Player Size", Array.Empty<GUILayoutOption>()))
				{
					MiscTab2.zort2 = new Vector3(1f, 1f, 1f);
				}
			}
			GUILayout.Label(string.Format("Hip: {0}", Provider.preferenceData.Viewmodel.Field_Of_View_Hip), Array.Empty<GUILayoutOption>());
			Provider.preferenceData.Viewmodel.Field_Of_View_Hip = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Field_Of_View_Hip, -5f, 300f, Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Fov Aim: {0}", Provider.preferenceData.Viewmodel.Field_Of_View_Aim), Array.Empty<GUILayoutOption>());
			Provider.preferenceData.Viewmodel.Field_Of_View_Aim = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Field_Of_View_Aim, -5f, 300f, Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Horizontal: {0}", Provider.preferenceData.Viewmodel.Offset_Horizontal), Array.Empty<GUILayoutOption>());
			Provider.preferenceData.Viewmodel.Offset_Horizontal = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Offset_Horizontal, -3f, 150f, Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Vertical:  {0}", Provider.preferenceData.Viewmodel.Offset_Vertical), Array.Empty<GUILayoutOption>());
			Provider.preferenceData.Viewmodel.Offset_Vertical = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Offset_Vertical, -2f, 6f, Array.Empty<GUILayoutOption>());
			GUILayout.Label(string.Format("Depth: {0}", Provider.preferenceData.Viewmodel.Offset_Depth), Array.Empty<GUILayoutOption>());
			Provider.preferenceData.Viewmodel.Offset_Depth = GUILayout.HorizontalSlider(Provider.preferenceData.Viewmodel.Offset_Depth, 0f, 150f, Array.Empty<GUILayoutOption>());
			MiscOptions.SetTimeEnabled = GUILayout.Toggle(MiscOptions.SetTimeEnabled, "Set Time", Array.Empty<GUILayoutOption>());
			if (MiscOptions.SetTimeEnabled)
			{
				GUILayout.Label("Time: " + MiscOptions.Time.ToString(), Array.Empty<GUILayoutOption>());
				MiscOptions.Time = GUILayout.HorizontalSlider(MiscOptions.Time, 0f, 0.9f, Array.Empty<GUILayoutOption>());
			}
			GUILayout.Space(5f);
			if (Provider.cameraMode != 2 && GUILayout.Button("Enable 3rd person", new GUILayoutOption[0]))
			{
				Provider.cameraMode = 2;
			}
			if (Provider.cameraMode == 2 && GUILayout.Button("Turn off 3rd person", new GUILayoutOption[0]))
			{
				Provider.cameraMode = 3;
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 480f, 290f, 150f), "Vehicle", "box");
			MiscTab2.scrollPosition2 = GUILayout.BeginScrollView(MiscTab2.scrollPosition2, Array.Empty<GUILayoutOption>());
			MiscOptions.VehicleFly = GUILayout.Toggle(MiscOptions.VehicleFly, "Vehicle Fly", Array.Empty<GUILayoutOption>());
			if (MiscOptions.VehicleFly)
			{
				MiscOptions.VehicleRigibody = GUILayout.Toggle(MiscOptions.VehicleRigibody, "Vehicle Rigibody", Array.Empty<GUILayoutOption>());
				MiscOptions.VehicleUseMaxSpeed = GUILayout.Toggle(MiscOptions.VehicleUseMaxSpeed, "Vehicle Max Speed", Array.Empty<GUILayoutOption>());
				if (!MiscOptions.VehicleUseMaxSpeed)
				{
					GUILayout.Label("Speed Multiplier: " + MiscOptions.SpeedMultiplier.ToString() + "x", Array.Empty<GUILayoutOption>());
					MiscOptions.SpeedMultiplier = GUILayout.HorizontalSlider(MiscOptions.SpeedMultiplier, 0f, 50f, Array.Empty<GUILayoutOption>());
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x04000399 RID: 921
		public static Vector3 zort = new Vector3(1f, 1f, 1f);

		// Token: 0x0400039A RID: 922
		public static Vector3 zort2 = new Vector3(1f, 1f, 1f);

		// Token: 0x0400039B RID: 923
		private static Vector2 scrollPosition2 = new Vector2(0f, 0f);

		// Token: 0x0400039C RID: 924
		private static Vector2 scrollPosition3 = new Vector2(0f, 0f);
	}
}
