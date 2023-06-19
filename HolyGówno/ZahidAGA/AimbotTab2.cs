using System;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000B2 RID: 178
	public class AimbotTab2
	{
		// Token: 0x06000326 RID: 806 RVA: 0x000159EC File Offset: 0x00013BEC
		public static void Tab()
		{
			GUILayout.Space(0f);
			GUILayout.BeginArea(new Rect(340f, 70f, 350f, 300f), "Silent Aimbot", "box");
			AimbotTab2.scrollPosition = GUILayout.BeginScrollView(AimbotTab2.scrollPosition, Array.Empty<GUILayoutOption>());
			RaycastOptions.Enabled = GUILayout.Toggle(RaycastOptions.Enabled, "Silent Aim", Array.Empty<GUILayoutOption>());
			if (RaycastOptions.Enabled)
			{
				MiscOptions.PunchSilentAim = true;
				MiscOptions.ExtendMeleeRange = true;
				RaycastOptions.SilentAimUseFOV = GUILayout.Toggle(RaycastOptions.SilentAimUseFOV, "Pixel FOV Limit", Array.Empty<GUILayoutOption>());
				if (RaycastOptions.SilentAimUseFOV)
				{
					RaycastOptions.ShowSilentAimUseFOV = true;
					GUILayout.Label("Pixels: " + RaycastOptions.SilentAimFOV.ToString(), Array.Empty<GUILayoutOption>());
					RaycastOptions.SilentAimFOV = (float)((int)GUILayout.HorizontalSlider(RaycastOptions.SilentAimFOV, 1f, 180f, Array.Empty<GUILayoutOption>()));
					RaycastOptions.ShowSilentAimUseFOV = GUILayout.Toggle(RaycastOptions.ShowSilentAimUseFOV, "Draw Pixel FOV Circle", Array.Empty<GUILayoutOption>());
				}
				WeaponOptions.Tracers = GUILayout.Toggle(WeaponOptions.Tracers, "Tracers", Array.Empty<GUILayoutOption>());
				WeaponOptions.DamageIndicators = GUILayout.Toggle(WeaponOptions.DamageIndicators, "Damage Indicators", Array.Empty<GUILayoutOption>());
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 70f, 290f, 400f), "Silent Aim Targets", "box");
			if (RaycastOptions.Enabled)
			{
				RaycastOptions.TargetPlayers = GUILayout.Toggle(RaycastOptions.TargetPlayers, "Target: Players", Array.Empty<GUILayoutOption>());
				RaycastOptions.TargetBeds = GUILayout.Toggle(RaycastOptions.TargetBeds, "Target: Beds", Array.Empty<GUILayoutOption>());
				RaycastOptions.TargetZombies = GUILayout.Toggle(RaycastOptions.TargetZombies, "Target: Zombies", Array.Empty<GUILayoutOption>());
				RaycastOptions.TargetAnimal = GUILayout.Toggle(RaycastOptions.TargetAnimal, "Target: Animals", Array.Empty<GUILayoutOption>());
				RaycastOptions.TargetClaimFlags = GUILayout.Toggle(RaycastOptions.TargetClaimFlags, "Target: Claim Flag", Array.Empty<GUILayoutOption>());
				RaycastOptions.TargetVehicles = GUILayout.Toggle(RaycastOptions.TargetVehicles, "Target: Vehicle", Array.Empty<GUILayoutOption>());
				RaycastOptions.TargetStorage = GUILayout.Toggle(RaycastOptions.TargetStorage, "Target: Storage", Array.Empty<GUILayoutOption>());
				RaycastOptions.TargetSentries = GUILayout.Toggle(RaycastOptions.TargetSentries, "Target: Sentries", Array.Empty<GUILayoutOption>());
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(340f, 380f, 350f, 250f), "Other", "box");
			if (GUILayout.Button("Silent Aim Limb: " + Enum.GetName(typeof(ELimb), RaycastOptions.TargetLimb), Array.Empty<GUILayoutOption>()))
			{
				RaycastOptions.TargetLimb = RaycastOptions.TargetLimb.Next<ELimb>();
			}
			RaycastOptions.UseRandomLimb = GUILayout.Toggle(RaycastOptions.UseRandomLimb, "Random Limb", Array.Empty<GUILayoutOption>());
			SphereOptions.SpherePrediction = GUILayout.Toggle(SphereOptions.SpherePrediction, "Sphere Prediction", Array.Empty<GUILayoutOption>());
			if (!SphereOptions.SpherePrediction)
			{
				GUILayout.Label(Math.Round((double)SphereOptions.SphereRadius, 2).ToString() + "m", Array.Empty<GUILayoutOption>());
				SphereOptions.SphereRadius = (float)((int)GUILayout.HorizontalSlider(SphereOptions.SphereRadius, 0f, 15.5f, Array.Empty<GUILayoutOption>()));
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(700f, 480f, 290f, 150f), "Aimlock", "box");
			AimbotTab2.scrollPosition2 = GUILayout.BeginScrollView(AimbotTab2.scrollPosition2, Array.Empty<GUILayoutOption>());
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		// Token: 0x0400030C RID: 780
		private static Vector2 scrollPosition;

		// Token: 0x0400030D RID: 781
		private static Vector2 scrollPosition2;
	}
}
