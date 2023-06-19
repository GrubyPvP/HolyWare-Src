using System;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000025 RID: 37
	[Component]
	public class RadarComponent : MonoBehaviour
	{
		// Token: 0x0600012F RID: 303 RVA: 0x000098FC File Offset: 0x00007AFC
		public void RadarMenu(int windowID)
		{
			new Rect(0f, 0f, RadarComponent.vew.width, 25f);
			T.DrawColor(new Rect(0f, 25f, RadarComponent.vew.width, RadarComponent.vew.height + 25f), new Color32(50, 50, 50, 200));
			GUILayout.Space(-19f);
			Vector2 vector;
			vector..ctor(RadarComponent.vew.width / 2f, (RadarComponent.vew.height + 25f) / 2f);
			RadarComponent.radarcenter = new Vector2(RadarComponent.vew.width / 2f, (RadarComponent.vew.height + 25f) / 2f);
			Vector2 vector2 = RadarComponent.GameToRadarPosition(Player.player.transform.position);
			if (RadarOptions.TrackPlayer)
			{
				RadarComponent.radarcenter.x = RadarComponent.radarcenter.x - vector2.x;
				RadarComponent.radarcenter.y = RadarComponent.radarcenter.y + vector2.y;
			}
			Drawing.DrawRect(new Rect(vector.x, 25f, 1f, RadarComponent.vew.height), Color.gray, null);
			Drawing.DrawRect(new Rect(0f, vector.y, RadarComponent.vew.width, 1f), Color.gray, null);
			this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector2.x, RadarComponent.radarcenter.y - vector2.y), Color.black, 4f);
			this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector2.x, RadarComponent.radarcenter.y - vector2.y), Color.white, 3f);
			if (RadarOptions.ShowVehicles)
			{
				foreach (InteractableVehicle interactableVehicle in VehicleManager.vehicles)
				{
					if (RadarOptions.ShowVehiclesUnlocked)
					{
						if (!interactableVehicle.isLocked)
						{
							Vector2 vector3 = RadarComponent.GameToRadarPosition(interactableVehicle.transform.position);
							this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector3.x, RadarComponent.radarcenter.y - vector3.y), Color.black, 3f);
							this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector3.x, RadarComponent.radarcenter.y - vector3.y), Color.magenta, 2f);
						}
					}
					else
					{
						Vector2 vector4 = RadarComponent.GameToRadarPosition(interactableVehicle.transform.position);
						this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector4.x, RadarComponent.radarcenter.y - vector4.y), Color.black, 3f);
						this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector4.x, RadarComponent.radarcenter.y - vector4.y), Color.magenta, 2f);
					}
				}
			}
			if (RadarOptions.ShowPlayers)
			{
				foreach (SteamPlayer steamPlayer in Provider.clients)
				{
					if (steamPlayer.player != OptimizationVariables.MainPlayer)
					{
						Vector2 vector5 = RadarComponent.GameToRadarPosition(steamPlayer.player.transform.position);
						this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector5.x, RadarComponent.radarcenter.y - vector5.y), Color.black, 3f);
						this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector5.x, RadarComponent.radarcenter.y - vector5.y), Color.red, 2f);
					}
				}
			}
			if (MiscComponent.LastDeath != new Vector3(0f, 0f, 0f))
			{
				Vector2 vector6 = RadarComponent.GameToRadarPosition(MiscComponent.LastDeath);
				this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector6.x, RadarComponent.radarcenter.y - vector6.y), Color.black, 4f);
				this.DrawRadarDot(new Vector2(RadarComponent.radarcenter.x + vector6.x, RadarComponent.radarcenter.y - vector6.y), Color.grey, 3f);
			}
			GUI.DragWindow();
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00003040 File Offset: 0x00001240
		public void DrawRadarDot(Vector2 pos, Color color, float size = 2f)
		{
			Drawing.DrawRect(new Rect(pos.x - size, pos.y - size, size * 2f, size * 2f), color, null);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00009E00 File Offset: 0x00008000
		public static Vector2 GameToRadarPosition(Vector3 pos)
		{
			Vector2 result;
			result.x = pos.x / ((float)Level.size / (RadarOptions.RadarZoom * RadarOptions.RadarSize));
			result.y = pos.z / ((float)Level.size / (RadarOptions.RadarZoom * RadarOptions.RadarSize));
			return result;
		}

		// Token: 0x04000075 RID: 117
		public static Rect veww;

		// Token: 0x04000076 RID: 118
		public static Rect vew = new Rect((float)Screen.width - RadarOptions.RadarSize - 20f, 10f, RadarOptions.RadarSize + 10f, RadarOptions.RadarSize + 10f);

		// Token: 0x04000077 RID: 119
		public static Vector2 radarcenter;

		// Token: 0x04000078 RID: 120
		public static bool WasEnabled;
	}
}
