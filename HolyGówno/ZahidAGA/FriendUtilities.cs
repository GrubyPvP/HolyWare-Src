using System;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x0200008E RID: 142
	public static class FriendUtilities
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x00012B48 File Offset: 0x00010D48
		public static bool IsFriendly(Player player)
		{
			return player.quests.isMemberOfGroup(OptimizationVariables.MainPlayer.quests.groupID) || MiscOptions.Friends.Contains(player.channel.owner.playerID.steamID.m_SteamID);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00012B98 File Offset: 0x00010D98
		public static void AddFriend(Player Friend)
		{
			ulong steamID = Friend.channel.owner.playerID.steamID.m_SteamID;
			if (!MiscOptions.Friends.Contains(steamID))
			{
				MiscOptions.Friends.Add(steamID);
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00012BDC File Offset: 0x00010DDC
		public static void RemoveFriend(Player Friend)
		{
			ulong steamID = Friend.channel.owner.playerID.steamID.m_SteamID;
			if (MiscOptions.Friends.Contains(steamID))
			{
				MiscOptions.Friends.Remove(steamID);
			}
		}
	}
}
