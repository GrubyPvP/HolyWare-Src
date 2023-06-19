using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SDG.NetPak;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000041 RID: 65
	public class PlayerCoroutines : MonoBehaviour
	{
		// Token: 0x060001D3 RID: 467 RVA: 0x00003621 File Offset: 0x00001821
		[Override(typeof(Player), "ReceiveTakeScreenshot", BindingFlags.Instance | BindingFlags.Public, 0)]
		public void OV_ReceiveTakeScreenshot()
		{
			base.StartCoroutine(PlayerCoroutines.TakeScreenshot());
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000362F File Offset: 0x0000182F
		[Obsolete]
		public static IEnumerator TakeScreenshot()
		{
			Player mainPlayer = OptimizationVariables.MainPlayer;
			SteamChannel channel = mainPlayer.channel;
			switch (MiscOptions.AntiSpyMethod)
			{
			case 0:
			{
				if (Time.realtimeSinceStartup - PlayerCoroutines.LastSpy < 0.5f || G.BeingSpied)
				{
					yield break;
				}
				G.BeingSpied = true;
				PlayerCoroutines.LastSpy = Time.realtimeSinceStartup;
				if (!MiscOptions.PanicMode)
				{
					PlayerCoroutines.DisableAllVisuals();
				}
				yield return new WaitForFixedUpdate();
				yield return new WaitForEndOfFrame();
				MiscOptions.spynofity = true;
				Texture2D texture2D = new Texture2D(Screen.width, Screen.height, 3, false)
				{
					name = "Screenshot_Raw",
					hideFlags = 61
				};
				texture2D.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0, false);
				Texture2D texture2D2 = new Texture2D(640, 480, 3, false)
				{
					name = "Screenshot_Final",
					hideFlags = 61
				};
				Color[] pixels = texture2D.GetPixels();
				Color[] array = new Color[texture2D2.width * texture2D2.height];
				float num = (float)texture2D.width / (float)texture2D2.width;
				float num2 = (float)texture2D.height / (float)texture2D2.height;
				for (int i = 0; i < texture2D2.height; i++)
				{
					int num3 = (int)((float)i * num2) * texture2D.width;
					int num4 = i * texture2D2.width;
					for (int j = 0; j < texture2D2.width; j++)
					{
						int num5 = (int)((float)j * num);
						array[num4 + j] = pixels[num3 + num5];
					}
				}
				texture2D2.SetPixels(array);
				byte[] data = ImageConversion.EncodeToJPG(texture2D2, 33);
				if (data.Length < 30000)
				{
					if (Provider.isServer)
					{
						PlayerCoroutines._HandleScreenshotData(data, channel);
					}
					else
					{
						ServerInstanceMethod.Get(typeof(Player), "ReceiveScreenshotRelay").Invoke(Player.player.GetNetId(), 0, delegate(NetPakWriter writer)
						{
							ushort num16 = (ushort)data.Length;
							SystemNetPakWriterEx.WriteUInt16(writer, num16);
							writer.WriteBytes(data, (int)num16);
						});
					}
				}
				yield return new WaitForFixedUpdate();
				yield return new WaitForEndOfFrame();
				G.BeingSpied = false;
				if (!MiscOptions.PanicMode)
				{
					PlayerCoroutines.EnableAllVisuals();
				}
				break;
			}
			case 1:
			{
				Random random = new Random();
				string[] files = Directory.GetFiles(MiscOptions.AntiSpyPath);
				byte[] array2 = File.ReadAllBytes(files[random.Next(files.Length)]);
				Texture2D texture2D3 = new Texture2D(2, 2);
				ImageConversion.LoadImage(texture2D3, array2);
				Texture2D texture2D4 = new Texture2D(640, 480, 3, false)
				{
					name = "Screenshot_Final",
					hideFlags = 61
				};
				Color[] pixels2 = texture2D3.GetPixels();
				Color[] array3 = new Color[texture2D4.width * texture2D4.height];
				float num6 = (float)texture2D3.width / (float)texture2D4.width;
				float num7 = (float)texture2D3.height / (float)texture2D4.height;
				for (int k = 0; k < texture2D4.height; k++)
				{
					int num8 = (int)((float)k * num7) * texture2D3.width;
					int num9 = k * texture2D4.width;
					for (int l = 0; l < texture2D4.width; l++)
					{
						int num10 = (int)((float)l * num6);
						array3[num9 + l] = pixels2[num8 + num10];
					}
				}
				texture2D4.SetPixels(array3);
				byte[] data = ImageConversion.EncodeToJPG(texture2D4, 33);
				if (data.Length < 30000)
				{
					if (Provider.isServer)
					{
						PlayerCoroutines._HandleScreenshotData(data, channel);
					}
					else
					{
						ServerInstanceMethod.Get(typeof(Player), "ReceiveScreenshotRelay").Invoke(Player.player.GetNetId(), 0, delegate(NetPakWriter writer)
						{
							ushort num16 = (ushort)data.Length;
							SystemNetPakWriterEx.WriteUInt16(writer, num16);
							writer.WriteBytes(data, (int)num16);
						});
					}
				}
				break;
			}
			case 3:
			{
				yield return new WaitForFixedUpdate();
				yield return new WaitForEndOfFrame();
				Texture2D texture2D5 = new Texture2D(Screen.width, Screen.height, 3, false)
				{
					name = "Screenshot_Raw",
					hideFlags = 61
				};
				texture2D5.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0, false);
				Texture2D texture2D6 = new Texture2D(640, 480, 3, false)
				{
					name = "Screenshot_Final",
					hideFlags = 61
				};
				Color[] pixels3 = texture2D5.GetPixels();
				Color[] array4 = new Color[texture2D6.width * texture2D6.height];
				float num11 = (float)texture2D5.width / (float)texture2D6.width;
				float num12 = (float)texture2D5.height / (float)texture2D6.height;
				for (int m = 0; m < texture2D6.height; m++)
				{
					int num13 = (int)((float)m * num12) * texture2D5.width;
					int num14 = m * texture2D6.width;
					for (int n = 0; n < texture2D6.width; n++)
					{
						int num15 = (int)((float)n * num11);
						array4[num14 + n] = pixels3[num13 + num15];
					}
				}
				texture2D6.SetPixels(array4);
				byte[] data = ImageConversion.EncodeToJPG(texture2D6, 33);
				if (data.Length < 30000)
				{
					if (Provider.isServer)
					{
						PlayerCoroutines._HandleScreenshotData(data, channel);
					}
					else
					{
						ServerInstanceMethod.Get(typeof(Player), "ReceiveScreenshotRelay").Invoke(Player.player.GetNetId(), 0, delegate(NetPakWriter writer)
						{
							ushort num16 = (ushort)data.Length;
							SystemNetPakWriterEx.WriteUInt16(writer, num16);
							writer.WriteBytes(data, (int)num16);
						});
					}
				}
				yield return new WaitForFixedUpdate();
				yield return new WaitForEndOfFrame();
				break;
			}
			}
			if (MiscOptions.AlertOnSpy)
			{
				OptimizationVariables.MainPlayer.StartCoroutine(PlayerCoroutines.ScreenShotMessageCoroutine());
			}
			yield break;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x0000E074 File Offset: 0x0000C274
		public static void _HandleScreenshotData(byte[] data, SteamChannel channel)
		{
			if (Dedicator.isDedicated)
			{
				ReadWrite.writeBytes(string.Concat(new string[]
				{
					ReadWrite.PATH,
					ServerSavedata.directory,
					"/",
					Provider.serverID,
					"/Spy.jpg"
				}), false, false, data);
				ReadWrite.writeBytes(string.Concat(new object[]
				{
					ReadWrite.PATH,
					ServerSavedata.directory,
					"/",
					Provider.serverID,
					"/Spy/",
					channel.owner.playerID.steamID.m_SteamID,
					".jpg"
				}), false, false, data);
				if (Player.player.onPlayerSpyReady != null)
				{
					Player.player.onPlayerSpyReady.Invoke(channel.owner.playerID.steamID, data);
				}
				PlayerSpyReady playerSpyReady = new Queue<PlayerSpyReady>().Dequeue();
				if (playerSpyReady != null)
				{
					playerSpyReady.Invoke(channel.owner.playerID.steamID, data);
					return;
				}
			}
			else
			{
				ReadWrite.writeBytes("/Spy.jpg", false, true, data);
				if (Player.onSpyReady != null)
				{
					Player.onSpyReady.Invoke(channel.owner.playerID.steamID, data);
				}
				Debug.Log("0x4");
			}
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00003637 File Offset: 0x00001837
		public static IEnumerator ScreenShotMessageCoroutine()
		{
			float started = Time.realtimeSinceStartup;
			bool flag;
			do
			{
				yield return new WaitForEndOfFrame();
				if (MiscOptions.spynofity && !G.BeingSpied)
				{
					T.AddNotification("<b>[!]</b> You got Spyed");
					MiscOptions.spynofity = false;
				}
				flag = (Time.realtimeSinceStartup - started > 3f);
			}
			while (!flag);
			yield break;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000E1B4 File Offset: 0x0000C3B4
		public static void DisableAllVisuals()
		{
			SpyManager.InvokePre();
			if (DrawUtilities.ShouldRun() && OptimizationVariables.MainPlayer.equipment.asset is ItemGunAsset)
			{
				Useable useable = OptimizationVariables.MainPlayer.equipment.useable;
			}
			if (LevelLighting.seaLevel == 0f)
			{
				LevelLighting.seaLevel = MiscOptions.Altitude;
			}
			SpyManager.DestroyComponents();
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000363F File Offset: 0x0000183F
		public static void EnableAllVisuals()
		{
			SpyManager.AddComponents();
			SpyManager.InvokePost();
		}

		// Token: 0x040000E1 RID: 225
		public static float LastSpy;

		// Token: 0x040000E2 RID: 226
		public static bool IsSpying;

		// Token: 0x040000E3 RID: 227
		public static Player SpecPlayer;
	}
}
