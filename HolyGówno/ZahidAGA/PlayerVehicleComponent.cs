using System;
using SDG.Unturned;
using UnityEngine;
using ZahidAGA;

// Token: 0x02000002 RID: 2
[Component]
public class PlayerVehicleComponent : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
	[OnSpy]
	public static void Disable()
	{
		PlayerVehicleComponent.WasEnabled = ESPOptions.ShowVehiclePlayers;
		ESPOptions.ShowVehiclePlayers = false;
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000205A File Offset: 0x0000025A
	[OffSpy]
	public static void Enable()
	{
		ESPOptions.ShowVehiclePlayers = PlayerVehicleComponent.WasEnabled;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00004538 File Offset: 0x00002738
	public void OnGUI()
	{
		if (ESPOptions.ShowVehiclePlayers)
		{
			GUI.color = new Color(1f, 1f, 1f, 0f);
			PlayerVehicleComponent.vew = GUILayout.Window(399, PlayerVehicleComponent.vew, new GUI.WindowFunction(this.PlayersMenu2), "", new GUILayoutOption[0]);
			GUI.color = Color.white;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000045A0 File Offset: 0x000027A0
	public void PlayersMenu2(int vehicle)
	{
		Rect rect = new Rect(0f, 0f, VanishPlayerComponent.vew.width, 25f);
		Drawing.DrawRect(rect, new Color32(15, 15, 15, byte.MaxValue), null);
		GUIStyle guistyle = new GUIStyle
		{
			alignment = 4
		};
		guistyle.normal.textColor = Color.white;
		GUI.Label(rect, "", guistyle);
		int num = 50;
		Drawing.DrawRect(new Rect(0f, 25f, VanishPlayerComponent.vew.width, VanishPlayerComponent.vew.height + 25f), new Color32(34, 34, 34, 190), null);
		GUILayout.Space(10f);
		if (Provider.isConnected)
		{
			foreach (SteamPlayer steamPlayer in Provider.clients)
			{
				Vector3 vector;
				vector..ctor(steamPlayer.player.transform.position.x, LevelGround.getHeight(steamPlayer.player.transform.position), steamPlayer.player.transform.position.z);
				if (steamPlayer.player.movement.getVehicle() != null && steamPlayer.player.movement.getVehicle().asset.engine == null && Vector3.Distance(steamPlayer.player.transform.position, vector) >= 15f && !Physics.Raycast(steamPlayer.player.transform.position, Vector3.down, 15f, 402882560))
				{
					GUILayout.Space(4f);
					GUILayout.Label(steamPlayer.playerID.characterName, guistyle, Array.Empty<GUILayoutOption>());
					num += 13;
				}
				else
				{
					PlayerVehicleComponent.vew.width = 200f;
					PlayerVehicleComponent.vew.height = 50f;
				}
			}
		}
		if (!Provider.isConnected)
		{
			PlayerVehicleComponent.vew.width = 200f;
			PlayerVehicleComponent.vew.height = 50f;
		}
		PlayerVehicleComponent.vew.height = (float)num;
		GUI.DragWindow();
	}

	// Token: 0x04000001 RID: 1
	public VehicleAsset asset;

	// Token: 0x04000002 RID: 2
	public static bool WasEnabled;

	// Token: 0x04000003 RID: 3
	public static Rect vew = new Rect(1000f, 10f, 200f, 50f);
}
