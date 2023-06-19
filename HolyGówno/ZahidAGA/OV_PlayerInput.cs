using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200007F RID: 127
	public class OV_PlayerInput
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00003B7F File Offset: 0x00001D7F
		public static List<PlayerInputPacket> ClientsidePackets
		{
			get
			{
				if (!DrawUtilities.ShouldRun() || !OV_PlayerInput.Run)
				{
					return null;
				}
				return (List<PlayerInputPacket>)OV_PlayerInput.ClientsidePacketsField.GetValue(OptimizationVariables.MainPlayer.input);
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x00010018 File Offset: 0x0000E218
		public static void OV_askAck(PlayerInput instance, CSteamID steamId, int ack)
		{
			if (!(steamId != Provider.server))
			{
				for (int i = OV_PlayerInput.Packets.Count - 1; i >= 0; i--)
				{
				}
			}
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0001004C File Offset: 0x0000E24C
		public static void OV_FixedUpdate()
		{
			Player mainPlayer = OptimizationVariables.MainPlayer;
			if (MiscOptions.PunchSilentAim)
			{
				OV_DamageTool.OVType = OverrideType.PlayerHit;
			}
			DamageTool.raycast(new Ray(mainPlayer.look.aim.position, mainPlayer.look.aim.forward), 15.5f, RayMasks.DAMAGE_SERVER);
			OverrideUtilities.CallOriginal(null, new object[0]);
			List<PlayerInputPacket> clientsidePackets = OV_PlayerInput.ClientsidePackets;
			OV_PlayerInput.LastPacket = ((clientsidePackets != null) ? clientsidePackets.Last<PlayerInputPacket>() : null);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000100C8 File Offset: 0x0000E2C8
		[Override(typeof(PlayerInput), "InitializePlayer", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public static void OV_InitializePlayer(PlayerInput instance)
		{
			if (instance.player != Player.player)
			{
				OverrideUtilities.CallOriginal(instance, new object[0]);
				return;
			}
			OptimizationVariables.MainPlayer = Player.player;
			OV_PlayerInput.Rate = 4;
			OV_PlayerInput.Count = 0;
			OV_PlayerInput.Buffer = 0;
			OV_PlayerInput.Packets.Clear();
			OV_PlayerInput.LastPacket = null;
			OV_PlayerInput.SequenceDiff = 0;
			OV_PlayerInput.ClientSequence = 0;
			OverrideUtilities.CallOriginal(instance, new object[0]);
		}

		// Token: 0x04000296 RID: 662
		public static FieldInfo ClientsidePacketsField = typeof(PlayerInput).GetField("clientsidePackets", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x04000297 RID: 663
		public static PlayerInputPacket LastPacket;

		// Token: 0x04000298 RID: 664
		public static float Yaw;

		// Token: 0x04000299 RID: 665
		public static float Pitch;

		// Token: 0x0400029A RID: 666
		public static int Count;

		// Token: 0x0400029B RID: 667
		public static int Buffer;

		// Token: 0x0400029C RID: 668
		public static int Choked;

		// Token: 0x0400029D RID: 669
		public static uint Clock = 1U;

		// Token: 0x0400029E RID: 670
		public static int Rate;

		// Token: 0x0400029F RID: 671
		public static int ClientSequence = 1;

		// Token: 0x040002A0 RID: 672
		public static int SequenceDiff;

		// Token: 0x040002A1 RID: 673
		public static List<PlayerInputPacket> Packets = new List<PlayerInputPacket>();

		// Token: 0x040002A2 RID: 674
		public static Queue<PlayerInputPacket> WaitingPackets = new Queue<PlayerInputPacket>();

		// Token: 0x040002A3 RID: 675
		public static float LastReal;

		// Token: 0x040002A4 RID: 676
		public static bool Run;

		// Token: 0x040002A5 RID: 677
		public static FieldInfo SimField = typeof(PlayerInput).GetField("_simulation", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040002A6 RID: 678
		public static Vector3 lastSentPositon = Vector3.zero;
	}
}
