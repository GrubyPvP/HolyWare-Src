using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000031 RID: 49
	[Component]
	[SpyComponent]
	public class WeaponComponent : MonoBehaviour
	{
		// Token: 0x0600016E RID: 366 RVA: 0x00003310 File Offset: 0x00001510
		public static byte Ammo()
		{
			return (byte)WeaponComponent.AmmoInfo.GetValue(OptimizationVariables.MainPlayer.equipment.useable);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000C024 File Offset: 0x0000A224
		public void Update()
		{
			if (Provider.isConnected && !Provider.isLoading)
			{
				Player player = Player.player;
				object obj;
				if (player == null)
				{
					obj = null;
				}
				else
				{
					PlayerEquipment equipment = player.equipment;
					obj = ((equipment != null) ? equipment.asset : null);
				}
				if (obj is ItemGunAsset)
				{
					Player player2 = Player.player;
					object obj2;
					if (player2 == null)
					{
						obj2 = null;
					}
					else
					{
						PlayerEquipment equipment2 = player2.equipment;
						obj2 = ((equipment2 != null) ? equipment2.asset : null);
					}
					ItemGunAsset itemGunAsset = (ItemGunAsset)obj2;
					if (!WeaponComponent.SpreadBackup.ContainsKey(itemGunAsset.id))
					{
						WeaponComponent.SpreadBackup.Add(itemGunAsset.id, itemGunAsset.spreadHip);
					}
					if (WeaponOptions.RemoveBurstDelay || WeaponOptions.RemoveHammerDelay || WeaponOptions.InstantReload)
					{
						Player.player.equipment.isBusy = false;
					}
					if (WeaponOptions.RemoveHammerDelay)
					{
						Player.player.equipment.useable.GetType().GetField("isHammering", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, false);
					}
					if (WeaponOptions.RemoveHammerDelay)
					{
						Player.player.equipment.useable.GetType().GetField("needsRechamber", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, false);
					}
					if (WeaponOptions.InstantReload)
					{
						Player.player.equipment.useable.GetType().GetField("reloadTime", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, 0f);
					}
					if (WeaponOptions.NoRecoil)
					{
						itemGunAsset.recoilMax_x = 0f;
						itemGunAsset.recoilMax_y = 0f;
						itemGunAsset.recoilMin_x = 0f;
						itemGunAsset.recoilMin_y = 0f;
					}
					if (WeaponOptions.NoSway)
					{
						Player.player.animator.viewmodelSwayMultiplier = 0f;
					}
				}
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000C1F4 File Offset: 0x0000A3F4
		[Initializer]
		public static void Initialize()
		{
			HotkeyComponent.ActionDict.Add("_ToggleTriggerbot", delegate
			{
				TriggerbotOptions.Enabled = !TriggerbotOptions.Enabled;
			});
			HotkeyComponent.ActionDict.Add("_ToggleNoRecoil", delegate
			{
				WeaponOptions.NoRecoil = !WeaponOptions.NoRecoil;
			});
			HotkeyComponent.ActionDict.Add("_ToggleNoSpread", delegate
			{
				WeaponOptions.NoSpread = !WeaponOptions.NoSpread;
			});
			HotkeyComponent.ActionDict.Add("_ToggleNoSway", delegate
			{
				WeaponOptions.NoSway = !WeaponOptions.NoSway;
			});
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00003330 File Offset: 0x00001530
		public void Start()
		{
			base.StartCoroutine(WeaponComponent.UpdateWeapon());
			base.StartCoroutine(WeaponComponent.Colorr());
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000334A File Offset: 0x0000154A
		public static IEnumerator Colorr()
		{
			for (;;)
			{
				WeaponComponent.rgb.r = (byte)Random.Range(0, 255);
				WeaponComponent.rgb.g = (byte)Random.Range(0, 255);
				WeaponComponent.rgb.b = (byte)Random.Range(0, 255);
				WeaponComponent.rgb.a = byte.MaxValue;
				yield return new WaitForSeconds(1f);
			}
			yield break;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000C2BC File Offset: 0x0000A4BC
		private void FixedUpdate()
		{
			if (this.r > 0 && this.b == 0)
			{
				this.r--;
				this.g++;
			}
			if (this.g > 0 && this.r == 0)
			{
				this.g--;
				this.b++;
			}
			if (this.b > 0 && this.g == 0)
			{
				this.b--;
				this.r++;
			}
			WeaponComponent.RGBRenk = new Color((float)this.r, (float)this.g, (float)this.b, 255f);
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000C374 File Offset: 0x0000A574
		public void OnGUI()
		{
			if (!G.BeingSpied)
			{
				if (WeaponComponent.MainCamera == null)
				{
					WeaponComponent.MainCamera = Camera.main;
				}
				if (WeaponOptions.NoSway && (OptimizationVariables.MainPlayer != null && OptimizationVariables.MainPlayer.animator != null))
				{
					OptimizationVariables.MainPlayer.animator.viewmodelSwayMultiplier = 0f;
				}
				if (Event.current.type == 7 && DrawUtilities.ShouldRun())
				{
					if (RaycastOptions.ShowSilentAimUseFOV && RaycastOptions.Enabled)
					{
						DrawUtilities.DrawCircle(WeaponComponent.RGBRenk, new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), WeaponComponent.FOVRadius(RaycastOptions.SilentAimFOV));
					}
					if (WeaponOptions.Tracers && WeaponComponent.TracerLines.Count > 0)
					{
						T.DrawMaterial.SetPass(0);
						GL.PushMatrix();
						GL.LoadProjectionMatrix(OptimizationVariables.MainCam.projectionMatrix);
						GL.modelview = OptimizationVariables.MainCam.worldToCameraMatrix;
						GL.Begin(1);
						for (int i = WeaponComponent.TracerLines.Count - 1; i > -1; i--)
						{
							WeaponComponent.TracerObject tracerObject = WeaponComponent.TracerLines[i];
							if (DateTime.Now - tracerObject.ShotTime > TimeSpan.FromSeconds(3.0))
							{
								WeaponComponent.TracerLines.Remove(tracerObject);
							}
							else
							{
								GL.Color(WeaponComponent.RGBRenk);
								GL.Vertex(tracerObject.PlayerPos);
								GL.Vertex(tracerObject.HitPos);
							}
						}
						GL.End();
						GL.PopMatrix();
					}
					if (WeaponOptions.DamageIndicators && WeaponComponent.DamageIndicators.Count > 0)
					{
						T.DrawMaterial.SetPass(0);
						for (int j = WeaponComponent.DamageIndicators.Count - 1; j > -1; j--)
						{
							WeaponComponent.IndicatorObject indicatorObject = WeaponComponent.DamageIndicators[j];
							if (DateTime.Now - indicatorObject.ShotTime > TimeSpan.FromSeconds(3.0))
							{
								WeaponComponent.DamageIndicators.Remove(indicatorObject);
							}
							else
							{
								GUI.color = Color.red;
								Vector3 vector = OptimizationVariables.MainCam.WorldToScreenPoint(indicatorObject.HitPos + new Vector3(0f, 1f, 0f));
								vector.y = (float)Screen.height - vector.y;
								if (vector.z >= 0f)
								{
									GUIStyle label = GUI.skin.label;
									label.alignment = 4;
									Vector2 vector2 = label.CalcSize(new GUIContent(string.Format("<b>{0}</b>", indicatorObject.Damage)));
									T.DrawOutlineLabel(new Vector2(vector.x - vector2.x / 2f, vector.y - (float)(DateTime.Now - indicatorObject.ShotTime).TotalSeconds * 10f), WeaponComponent.RGBRenk, Color.black, string.Format("<b>{0}</b>", indicatorObject.Damage), null);
									label.alignment = 3;
								}
								GUI.color = Main.GUIColor;
							}
						}
					}
					if (RaycastOptions.ShowAimUseFOV && AimbotOptions.Enabled)
					{
						DrawUtilities.DrawCircle(ColorUtilities.getColor("_ShowFOVAim"), new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), WeaponComponent.FOVRadius(AimbotOptions.FOV));
					}
					if (WeaponOptions.ShowWeaponInfo)
					{
						ItemAsset asset = Player.player.equipment.asset;
						if (asset != null && asset is ItemWeaponAsset)
						{
							ItemWeaponAsset itemWeaponAsset = (ItemWeaponAsset)asset;
							string content = string.Format("<size=13>{0}\nRange: {1}\nDamage:{2}</size>", itemWeaponAsset.itemName, itemWeaponAsset.range, itemWeaponAsset.playerDamageMultiplier.damage);
							DrawUtilities.DrawLabel(Font.CreateDynamicFontFromOSFont("Arial", 11), LabelLocation.MiddleLeft, new Vector2((float)(Screen.width - 20), (float)(Screen.height / 2)), content, Color.green, Color.black, 1, null, 12);
						}
					}
					if (ESPOptions.ShowCoordinates)
					{
						float x = OptimizationVariables.MainPlayer.transform.position.x;
						float y = OptimizationVariables.MainPlayer.transform.position.y;
						float z = OptimizationVariables.MainPlayer.transform.position.z;
						string content2 = string.Format("", Math.Round((double)x, 2).ToString(), Math.Round((double)y, 2).ToString(), Math.Round((double)z, 2).ToString());
						DrawUtilities.DrawLabel(Font.CreateDynamicFontFromOSFont("Arial", 11), LabelLocation.MiddleLeft, new Vector2((float)(Screen.width - 20), (float)(Screen.height / 2 + 50)), content2, ColorUtilities.getColor("_Coordinates"), ColorUtilities.getColor("_CoordinatesTick"), 1, null, 12);
					}
				}
			}
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00003352 File Offset: 0x00001552
		public static IEnumerator UpdateWeapon()
		{
			for (;;)
			{
				yield return new WaitForSeconds(0.1f);
				ItemGunAsset itemGunAsset;
				if (DrawUtilities.ShouldRun() && (itemGunAsset = (OptimizationVariables.MainPlayer.equipment.asset as ItemGunAsset)) != null)
				{
					if (WeaponOptions.Zoom && !G.BeingSpied)
					{
						float num = 90f / WeaponOptions.ZoomValue;
						WeaponComponent.ZoomInfo.SetValue(Player.player.equipment.useable, num);
						Player.player.look.scopeCamera.fieldOfView = num;
						if (((UseableGun)Player.player.equipment.useable).isAiming)
						{
							EPlayerPerspective perspective = Player.player.look.perspective;
						}
					}
					if (!WeaponComponent.AssetBackups.ContainsKey(itemGunAsset.id))
					{
						float[] array = new float[]
						{
							itemGunAsset.recoilAim,
							itemGunAsset.recoilMax_x,
							itemGunAsset.recoilMax_y,
							itemGunAsset.recoilMin_x,
							itemGunAsset.recoilMin_y,
							itemGunAsset.spreadAim,
							itemGunAsset.spreadSprint,
							itemGunAsset.spreadCrouch
						};
						array[6] = itemGunAsset.spreadSprint;
						WeaponComponent.AssetBackups.Add(itemGunAsset.id, array);
					}
					if (WeaponOptions.RemoveReloadDelay)
					{
						Player.player.equipment.useable.GetType().GetField("reloadTime", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, 0f);
					}
					if (WeaponOptions.NoSpread && !G.BeingSpied)
					{
						PlayerLifeUI.crosshair.SetGameWantsCenterDotVisible(true);
						PlayerLifeUI.crosshair.SetDirectionalArrowsVisible(false);
					}
					else
					{
						PlayerLifeUI.crosshair.SetGameWantsCenterDotVisible(false);
						PlayerLifeUI.crosshair.SetDirectionalArrowsVisible(true);
					}
					WeaponComponent.Reload();
				}
			}
			yield break;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000C84C File Offset: 0x0000AA4C
		public static void Reload()
		{
			if (WeaponOptions.AutoReload && WeaponComponent.Ammo() <= 0)
			{
				List<InventorySearch> list = (from i in OptimizationVariables.MainPlayer.inventory.search(12, ((ItemGunAsset)OptimizationVariables.MainPlayer.equipment.asset).magazineCalibers)
				where i.jar.item.amount > 0
				select i).ToList<InventorySearch>();
				if (list.Count != 0)
				{
					InventorySearch inventorySearch = (from i in list
					orderby i.jar.item.amount descending
					select i).First<InventorySearch>();
					OptimizationVariables.MainPlayer.channel.send("askAttachMagazine", 5, 1, new object[]
					{
						inventorySearch.page,
						inventorySearch.jar.x,
						inventorySearch.jar.y
					});
				}
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000C94C File Offset: 0x0000AB4C
		public static void AddTracer(RaycastInfo ri)
		{
			if (WeaponOptions.Tracers && ri.point != new Vector3(0f, 0f, 0f))
			{
				WeaponComponent.TracerObject item = new WeaponComponent.TracerObject
				{
					HitPos = ri.point,
					PlayerPos = Player.player.look.aim.transform.position,
					ShotTime = DateTime.Now
				};
				WeaponComponent.TracerLines.Add(item);
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000C9C8 File Offset: 0x0000ABC8
		public static void AddDamage(RaycastInfo ri)
		{
			if (WeaponOptions.DamageIndicators && ri.point != new Vector3(0f, 0f, 0f))
			{
				ItemGunAsset itemGunAsset = Player.player.equipment.asset as ItemGunAsset;
				if (itemGunAsset != null && ri.player != null)
				{
					WeaponComponent.IndicatorObject item = new WeaponComponent.IndicatorObject
					{
						HitPos = ri.point,
						Damage = Mathf.FloorToInt(DamageTool.getPlayerArmor(ri.limb, ri.player) * itemGunAsset.playerDamageMultiplier.multiply(ri.limb)),
						ShotTime = DateTime.Now
					};
					WeaponComponent.DamageIndicators.Add(item);
				}
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000CA7C File Offset: 0x0000AC7C
		internal static float FOVRadius(float fov)
		{
			float fieldOfView = OptimizationVariables.MainCam.fieldOfView;
			return (float)(Math.Tan((double)fov * 0.017453292519943295 / 2.0) / Math.Tan((double)fieldOfView * 0.017453292519943295 / 2.0) * (double)Screen.height);
		}

		// Token: 0x040000A4 RID: 164
		public static Dictionary<ushort, float> SpreadBackup = new Dictionary<ushort, float>();

		// Token: 0x040000A5 RID: 165
		public static List<WeaponComponent.TracerObject> TracerLines = new List<WeaponComponent.TracerObject>();

		// Token: 0x040000A6 RID: 166
		public static List<WeaponComponent.IndicatorObject> DamageIndicators = new List<WeaponComponent.IndicatorObject>();

		// Token: 0x040000A7 RID: 167
		private static Color32 rgb = default(Color32);

		// Token: 0x040000A8 RID: 168
		private int r = 255;

		// Token: 0x040000A9 RID: 169
		private int g;

		// Token: 0x040000AA RID: 170
		private int b;

		// Token: 0x040000AB RID: 171
		public static Color RGBRenk;

		// Token: 0x040000AC RID: 172
		public static Dictionary<ushort, float[]> AssetBackups = new Dictionary<ushort, float[]>();

		// Token: 0x040000AD RID: 173
		public static List<TracerLine> Tracers = new List<TracerLine>();

		// Token: 0x040000AE RID: 174
		public static Camera MainCamera;

		// Token: 0x040000AF RID: 175
		public static FieldInfo look1 = typeof(PlayerLook).GetField("fov", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B0 RID: 176
		public static FieldInfo ZoomInfo = typeof(UseableGun).GetField("zoom", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B1 RID: 177
		public static FieldInfo AmmoInfo = typeof(UseableGun).GetField("ammo", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B2 RID: 178
		public static MethodInfo UpdateCrosshair = typeof(UseableGun).GetMethod("updateCrosshair", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B3 RID: 179
		public static FieldInfo attachments1 = typeof(UseableGun).GetField("firstAttachments", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B4 RID: 180
		public static FieldInfo fov = typeof(PlayerLook).GetField("fov", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B5 RID: 181
		public static FieldInfo oryaw = typeof(PlayerLook).GetField("_orbitPitch", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B6 RID: 182
		public static FieldInfo orpitch = typeof(PlayerLook).GetField("_orbitYaw", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B7 RID: 183
		public static FieldInfo yaw = typeof(PlayerLook).GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B8 RID: 184
		public static FieldInfo pitch = typeof(PlayerLook).GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000B9 RID: 185
		public static FieldInfo lookx = typeof(PlayerLook).GetField("_look_x", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x040000BA RID: 186
		public static FieldInfo looky = typeof(PlayerLook).GetField("_look_y", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x02000032 RID: 50
		public class TracerObject
		{
			// Token: 0x040000BB RID: 187
			public DateTime ShotTime;

			// Token: 0x040000BC RID: 188
			public Vector3 PlayerPos;

			// Token: 0x040000BD RID: 189
			public Vector3 HitPos;
		}

		// Token: 0x02000033 RID: 51
		public class IndicatorObject
		{
			// Token: 0x040000BE RID: 190
			public DateTime ShotTime;

			// Token: 0x040000BF RID: 191
			public Vector3 HitPos;

			// Token: 0x040000C0 RID: 192
			public int Damage;
		}
	}
}
