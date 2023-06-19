using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;
using ZahidAGA;

// Token: 0x02000003 RID: 3
[Component]
public class VanishPlayerComponent : MonoBehaviour
{
	// Token: 0x06000007 RID: 7 RVA: 0x000047F8 File Offset: 0x000029F8
	private void OnGUI()
	{
		if (!MiscOptions.ShowVanish || G.BeingSpied || !Provider.isConnected || Provider.clients.Count <= 0)
		{
			return;
		}
		GUI.color = new Color(1f, 1f, 1f, 0f);
		using (List<SteamPlayer>.Enumerator enumerator = Provider.clients.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (Vector3.Distance(enumerator.Current.player.transform.position, Vector3.zero) < 10f)
				{
					GUILayout.Window(7, VanishPlayerComponent.vew, new GUI.WindowFunction(this.VanishPlayerWindow), "", Array.Empty<GUILayoutOption>());
				}
			}
		}
		GUI.color = Color.white;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000048D0 File Offset: 0x00002AD0
	private void VanishPlayerWindow(int winid)
	{
		T.DrawColor(new Rect(0f, 0f, VanishPlayerComponent.vew.width, 25f), new Color32(34, 34, 34, 200));
		T.DrawColor(new Rect(0f, 25f, VanishPlayerComponent.vew.width, VanishPlayerComponent.vew.height + 25f), new Color32(34, 34, 34, 200));
		foreach (SteamPlayer steamPlayer in Provider.clients)
		{
			if (Vector3.Distance(steamPlayer.player.transform.position, Vector3.zero) < 10f)
			{
				GUILayout.Label(steamPlayer.playerID.characterName, Array.Empty<GUILayoutOption>());
			}
		}
		GUI.DragWindow();
	}

	// Token: 0x04000004 RID: 4
	public static Rect vew = new Rect((float)(Screen.width - 395), 50f, 200f, 100f);
}
