using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000B3 RID: 179
	public class AssetUtilities
	{
		// Token: 0x06000328 RID: 808 RVA: 0x00015D6C File Offset: 0x00013F6C
		public static void GetAssets()
		{
			AssetBundle assetBundle = AssetBundle.LoadFromMemory(new WebClient().DownloadData("https://cdn.discordapp.com/attachments/994674232170647722/1036690244856201316/CUMbo.assets"));
			if (assetBundle)
			{
				T.AddNotification("<b>[!]</b>    Assets Loaded");
			}
			foreach (Shader shader in assetBundle.LoadAllAssets<Shader>())
			{
				AssetUtilities.Shaders.Add(shader.name, shader);
			}
			foreach (Texture2D texture2D in assetBundle.LoadAllAssets<Texture2D>())
			{
				if (texture2D.name != "Font Texture")
				{
					AssetUtilities.Textures.Add(texture2D.name, texture2D);
				}
			}
			Main._Aimbot = AssetUtilities.Textures["aimbot"];
			Main._other = AssetUtilities.Textures["misc"];
			Main._settings = AssetUtilities.Textures["misc"];
			Main._player = AssetUtilities.Textures["players"];
			Main._other = AssetUtilities.Textures["misc"];
			Main._Visual = AssetUtilities.Textures["visual"];
			Main._Skin = AssetUtilities.Textures["skins"];
			Main._Keyboard = AssetUtilities.Textures["keyboard"];
			AssetUtilities.BonkClip = assetBundle.LoadAllAssets<AudioClip>().First<AudioClip>();
			AssetUtilities.VanillaSkin = assetBundle.LoadAllAssets<GUISkin>().First<GUISkin>();
			if (!string.IsNullOrEmpty(MiscOptions.UISkin))
			{
				AssetUtilities.LoadGUISkinFromName(MiscOptions.UISkin);
				return;
			}
			AssetUtilities.Skin = AssetUtilities.VanillaSkin;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00015EF0 File Offset: 0x000140F0
		public static void LoadGUISkinFromName(string name)
		{
			if (File.Exists(Application.dataPath + "/GUISkins/" + name + ".assets"))
			{
				AssetBundle assetBundle = AssetBundle.LoadFromMemory(File.ReadAllBytes(Application.dataPath + "/GUISkins/" + name + ".assets"));
				AssetUtilities.Skin = assetBundle.LoadAllAssets<GUISkin>().First<GUISkin>();
				assetBundle.Unload(false);
				MiscOptions.UISkin = name;
				return;
			}
			AssetUtilities.Skin = AssetUtilities.VanillaSkin;
			MiscOptions.UISkin = "";
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00015F6C File Offset: 0x0001416C
		public static List<string> GetSkins(bool Extensions = false)
		{
			List<string> list = new List<string>();
			foreach (FileInfo fileInfo in new DirectoryInfo(Application.dataPath + "/GUISkins/").GetFiles("*.assets"))
			{
				if (Extensions)
				{
					list.Add(fileInfo.Name.Substring(0, fileInfo.Name.Length));
				}
				else
				{
					list.Add(fileInfo.Name.Substring(0, fileInfo.Name.Length - 7));
				}
			}
			return list;
		}

		// Token: 0x0400030E RID: 782
		public static Dictionary<string, Shader> Shaders = new Dictionary<string, Shader>();

		// Token: 0x0400030F RID: 783
		public static GUISkin Skin;

		// Token: 0x04000310 RID: 784
		public static GUISkin VanillaSkin;

		// Token: 0x04000311 RID: 785
		public static AudioClip BonkClip;

		// Token: 0x04000312 RID: 786
		public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
	}
}
