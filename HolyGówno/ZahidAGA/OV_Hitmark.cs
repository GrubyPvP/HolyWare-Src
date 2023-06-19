using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000011 RID: 17
	public class OV_Hitmark
	{
		// Token: 0x060000DA RID: 218 RVA: 0x000083A0 File Offset: 0x000065A0
		[Override(typeof(PlayerUI), "hitmark", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_hitmark(int index, Vector3 point, bool worldspace, EPlayerHit newHit)
		{
			if (!(bool)OV_Hitmark.wantsWindowEnabled.GetValue(null))
			{
				return;
			}
			if (index < 0 || index >= PlayerLifeUI.hitmarkers.Length)
			{
				return;
			}
			if (!Provider.modeConfigData.Gameplay.Hitmarkers)
			{
				return;
			}
			HitmarkerInfo hitmarkerInfo = PlayerLifeUI.hitmarkers[index];
			hitmarkerInfo.lastHit = Time.realtimeSinceStartup;
			hitmarkerInfo.hit = newHit;
			hitmarkerInfo.point = point;
			hitmarkerInfo.worldspace = (worldspace || OptionsSettings.hitmarker);
			if (newHit == 2)
			{
				if (WeaponOptions.HeatShot)
				{
					MainCamera.instance.GetComponent<AudioSource>().PlayOneShot(AssetVariables.Audio["oof"], WeaponOptions.HeatShotVolume);
				}
				else
				{
					MainCamera.instance.GetComponent<AudioSource>().PlayOneShot(OV_Hitmark.hitCriticalSound, 0.5f);
				}
			}
			Texture2D texture;
			Color color;
			switch (newHit)
			{
			case 0:
				return;
			case 1:
				texture = OV_Hitmark.hitEntityTexture;
				color = OptionsSettings.hitmarkerColor;
				break;
			case 2:
				texture = OV_Hitmark.hitCriticalTexture;
				color = OptionsSettings.criticalHitmarkerColor;
				break;
			case 3:
				texture = OV_Hitmark.hitBuildTexture;
				color = OptionsSettings.hitmarkerColor;
				break;
			case 4:
				texture = OV_Hitmark.hitGhostTexture;
				color = OptionsSettings.hitmarkerColor;
				break;
			default:
				return;
			}
			hitmarkerInfo.image.texture = texture;
			hitmarkerInfo.image.color = color;
		}

		// Token: 0x0400002F RID: 47
		private static StaticResourceRef<Texture2D> hitEntityTexture = new StaticResourceRef<Texture2D>("Bundles/Textures/Player/Icons/PlayerLife/Hit_Entity");

		// Token: 0x04000030 RID: 48
		private static StaticResourceRef<Texture2D> hitCriticalTexture = new StaticResourceRef<Texture2D>("Bundles/Textures/Player/Icons/PlayerLife/Hit_Critical");

		// Token: 0x04000031 RID: 49
		private static StaticResourceRef<Texture2D> hitBuildTexture = new StaticResourceRef<Texture2D>("Bundles/Textures/Player/Icons/PlayerLife/Hit_Build");

		// Token: 0x04000032 RID: 50
		private static StaticResourceRef<Texture2D> hitGhostTexture = new StaticResourceRef<Texture2D>("Bundles/Textures/Player/Icons/PlayerLife/Hit_Ghost");

		// Token: 0x04000033 RID: 51
		private static StaticResourceRef<AudioClip> hitCriticalSound = new StaticResourceRef<AudioClip>("Sounds/General/Hit");

		// Token: 0x04000034 RID: 52
		private static FieldInfo wantsWindowEnabled = typeof(PlayerUI).GetField("wantsWindowEnabled", BindingFlags.Static | BindingFlags.NonPublic);
	}
}
