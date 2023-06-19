using System;
using System.Linq;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000C4 RID: 196
	public static class PlayersTab2
	{
		// Token: 0x06000348 RID: 840 RVA: 0x0000BC84 File Offset: 0x00009E84
		public static SteamPlayer GetSteamPlayer(Player player)
		{
			foreach (SteamPlayer steamPlayer in Provider.clients)
			{
				if (steamPlayer.player == player)
				{
					return steamPlayer;
				}
			}
			return null;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000178D8 File Offset: 0x00015AD8
		public static void Tab()
		{
			GUILayout.BeginArea(new Rect(340f, 70f, 650f, 370f), "Online Players", "box");
			PlayersTab2.SearchString = GUILayout.TextField(PlayersTab2.SearchString, "\nSearch: ", Array.Empty<GUILayoutOption>());
			PlayersTab2.scrollPosition1 = GUILayout.BeginScrollView(PlayersTab2.scrollPosition1, Array.Empty<GUILayoutOption>());
			for (int i = 0; i < Provider.clients.Count; i++)
			{
				Player player = Provider.clients[i].player;
				if (!(player == OptimizationVariables.MainPlayer) && !(player == null) && (!(PlayersTab2.SearchString != "") || player.name.IndexOf(PlayersTab2.SearchString, StringComparison.OrdinalIgnoreCase) != -1))
				{
					bool flag = FriendUtilities.IsFriendly(player);
					bool flag2 = MiscOptions.SpectatedPlayer == player;
					bool flag3 = false;
					bool flag4 = player == PlayersTab2.SelectedPlayer;
					string text = flag3 ? "<color=#ff0000ff>" : (flag ? "<color=#00ff00ff>" : "");
					if (GUILayout.Button(string.Concat(new string[]
					{
						flag4 ? "<b>" : "",
						flag2 ? "<color=#0000ffff>[SPECTATING]</color> " : "",
						text,
						player.name,
						(flag || flag3) ? "</color>" : "",
						flag4 ? "</b>" : ""
					}), new GUILayoutOption[0]))
					{
						PlayersTab2.SelectedPlayer = player;
					}
					GUILayout.Space(2f);
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(340f, 450f, 250f, 180f), "Other", "box");
			if (!(PlayersTab2.SelectedPlayer == null))
			{
				CSteamID steamID = PlayersTab2.SelectedPlayer.channel.owner.playerID.steamID;
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.BeginVertical(new GUILayoutOption[0]);
				if (FriendUtilities.IsFriendly(PlayersTab2.SelectedPlayer))
				{
					if (GUILayout.Button("Remove Friends", new GUILayoutOption[0]))
					{
						FriendUtilities.RemoveFriend(PlayersTab2.SelectedPlayer);
					}
				}
				else if (GUILayout.Button("Add Friends", new GUILayoutOption[0]))
				{
					FriendUtilities.AddFriend(PlayersTab2.SelectedPlayer);
				}
				if (GUILayout.Button("Teleport Vehicle", new GUILayoutOption[0]))
				{
					OptimizationVariables.MainPlayer.movement.getVehicle().transform.position = PlayersTab2.SelectedPlayer.transform.position;
				}
				if (GUILayout.Button("Teleport", new GUILayoutOption[0]))
				{
					OptimizationVariables.MainPlayer.transform.position = PlayersTab2.SelectedPlayer.transform.position;
				}
				if (GUILayout.Button("Open Steam Profile", new GUILayoutOption[0]))
				{
					Provider.provider.browserService.open("http://steamcommunity.com/profiles/" + PlayersTab2.SelectedPlayer.channel.owner.playerID.steamID.ToString());
				}
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}
			GUILayout.EndArea();
			GUILayout.BeginArea(new Rect(600f, 450f, 390f, 180f), "Info", "box");
			if (!(PlayersTab2.SelectedPlayer == null))
			{
				string str = Convert.ToString(Convert.ToInt32(Provider.clients.Count((SteamPlayer c) => c.player != PlayersTab2.SelectedPlayer && c.player.quests.isMemberOfSameGroupAs(PlayersTab2.SelectedPlayer))) + 1);
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.BeginVertical(new GUILayoutOption[0]);
				float x = PlayersTab2.SelectedPlayer.transform.position.x;
				float y = PlayersTab2.SelectedPlayer.transform.position.y;
				float z = PlayersTab2.SelectedPlayer.transform.position.z;
				string.Format("", Math.Round((double)x, 2).ToString(), Math.Round((double)y, 2).ToString(), Math.Round((double)z, 2).ToString());
				GUILayout.TextField("Location: " + LocationUtilities.GetClosestLocation(PlayersTab2.SelectedPlayer.transform.position).name, new GUILayoutOption[0]);
				GUILayout.TextField("Coordinates X,Y,Z:\r\n" + PlayersTab2.SelectedPlayer.transform.position.ToString(), new GUILayoutOption[0]);
				GUILayout.Label("Weapon: " + ((PlayersTab2.SelectedPlayer.equipment.asset != null) ? PlayersTab2.SelectedPlayer.equipment.asset.itemName : "Fists"), new GUILayoutOption[0]);
				GUILayout.Label("Vehicle: " + ((PlayersTab2.SelectedPlayer.movement.getVehicle() != null) ? PlayersTab2.SelectedPlayer.movement.getVehicle().asset.name : "No Vehicle"), new GUILayoutOption[0]);
				GUILayout.Label("Number in a group: " + str, new GUILayoutOption[0]);
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
			}
			GUILayout.EndArea();
		}

		// Token: 0x040003A0 RID: 928
		private static Vector2 scrollPosition1 = new Vector2(0f, 0f);

		// Token: 0x040003A1 RID: 929
		public static Vector2 PlayersScroll;

		// Token: 0x040003A2 RID: 930
		public static Player SelectedPlayer;

		// Token: 0x040003A3 RID: 931
		public static string SearchString = "";
	}
}
