using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SDG.Provider;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000022 RID: 34
	[Component]
	public class MiscComponent : MonoBehaviour
	{
		// Token: 0x0600010A RID: 266 RVA: 0x00008BB8 File Offset: 0x00006DB8
		[Initializer]
		public static void Initialize()
		{
			HotkeyComponent.ActionDict.Add("_Cam", delegate
			{
				if (MiscOptions.Freecam = !MiscOptions.Freecam)
				{
					T.AddNotification("Freecam <b> ON</b>");
					return;
				}
				T.AddNotification("Freecam <b> OFF</b>");
			});
			HotkeyComponent.ActionDict.Add("_SpinOyuncu", delegate
			{
				ESPOptions.SpinBotOyuncu = !ESPOptions.SpinBotOyuncu;
			});
			HotkeyComponent.ActionDict.Add("_SpinAraç", delegate
			{
				ESPOptions.SpinBotAraç = !ESPOptions.SpinBotAraç;
			});
			HotkeyComponent.ActionDict.Add("_Çık", delegate
			{
				Provider.disconnect();
			});
			HotkeyComponent.ActionDict.Add("_ArIş", delegate
			{
				Random random = new Random();
				Player player = Provider.clients[random.Next(0, Provider.clients.Count)].player;
				if (!player.life.isDead)
				{
					OptimizationVariables.MainPlayer.movement.getVehicle().transform.position = player.transform.position;
				}
			});
			HotkeyComponent.ActionDict.Add("_VFToggle", delegate
			{
				if (MiscOptions.VehicleFly = !MiscOptions.VehicleFly)
				{
					T.AddNotification("Vechicle Fly<b> ON</b>");
					return;
				}
				T.AddNotification("Vechicle Fly<b> OFF</b>");
			});
			HotkeyComponent.ActionDict.Add("_ToggleAimbot", delegate
			{
				AimbotOptions.Enabled = !AimbotOptions.Enabled;
			});
			HotkeyComponent.ActionDict.Add("_AimbotOnKey", delegate
			{
				AimbotOptions.OnKey = !AimbotOptions.OnKey;
			});
			HotkeyComponent.ActionDict.Add("_InstantDisconnect", delegate
			{
				Provider.disconnect();
				T.AddNotification("Disconnect");
			});
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00002E3E File Offset: 0x0000103E
		[OnSpy]
		public static void Disable()
		{
			if (MiscOptions.WasNightVision)
			{
				MiscComponent.NightvisionBeforeSpy = true;
				MiscOptions.NightVision = false;
			}
			if (ESPOptions.ShowMap)
			{
				ESPOptions.ShowMap2 = true;
				ESPOptions.ShowMap = false;
			}
			if (MiscOptions.Freecam)
			{
				MiscComponent.FreecamBeforeSpy = true;
				MiscOptions.Freecam = false;
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00002E79 File Offset: 0x00001079
		[OffSpy]
		public static void Enable()
		{
			if (ESPOptions.ShowMap2)
			{
				ESPOptions.ShowMap2 = false;
				ESPOptions.ShowMap = true;
			}
			if (MiscComponent.NightvisionBeforeSpy)
			{
				MiscComponent.NightvisionBeforeSpy = false;
				MiscOptions.NightVision = true;
			}
			if (MiscComponent.FreecamBeforeSpy)
			{
				MiscComponent.FreecamBeforeSpy = false;
				MiscOptions.Freecam = true;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00008D64 File Offset: 0x00006F64
		public void Start()
		{
			MiscComponent.Instance = this;
			Provider.onClientConnected = (Provider.ClientConnected)Delegate.Combine(Provider.onClientConnected, new Provider.ClientConnected(delegate()
			{
				if (MiscOptions.AlwaysCheckMovementVerification)
				{
					MiscComponent.CheckMovementVerification();
					return;
				}
				MiscOptions.NoMovementVerification = false;
			}));
			SkinsUtilities.RefreshEconInfo();
			HotkeyComponent.ActionDict.Add("_Com1", delegate
			{
				ChatManager.sendChat(0, "/" + BindOptions.Com1);
			});
			HotkeyComponent.ActionDict.Add("_Com2", delegate
			{
				ChatManager.sendChat(0, "/" + BindOptions.Com2);
			});
			HotkeyComponent.ActionDict.Add("_Com3", delegate
			{
				ChatManager.sendChat(0, "/" + BindOptions.Com3);
			});
			HotkeyComponent.ActionDict.Add("_Com4", delegate
			{
				ChatManager.sendChat(0, "/" + BindOptions.Com4);
			});
			HotkeyComponent.ActionDict.Add("_Com5", delegate
			{
				ChatManager.sendChat(0, "/" + BindOptions.Com5);
			});
			HotkeyComponent.ActionDict.Add("_AutoPickUp", delegate
			{
				ItemOptions.AutoItemPickup = !ItemOptions.AutoItemPickup;
			});
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00008EC4 File Offset: 0x000070C4
		public void Update()
		{
			if (Camera.main != null && OptimizationVariables.MainCam == null)
			{
				OptimizationVariables.MainCam = Camera.main;
			}
			if (OptimizationVariables.MainPlayer && DrawUtilities.ShouldRun())
			{
				if (MiscOptions.hang)
				{
					Player.player.movement.pluginGravityMultiplier = -1f;
				}
				else
				{
					Player.player.movement.pluginGravityMultiplier = 1f;
				}
				int num;
				Provider.provider.statisticsService.userStatisticsService.getStatistic("Kills_Players", ref num);
				if (WeaponOptions.OofOnDeath)
				{
					if (num != this.currentKills)
					{
						if (this.currentKills != -1)
						{
							OptimizationVariables.MainPlayer.GetComponentInChildren<AudioSource>().PlayOneShot(AssetVariables.Audio["oof"], WeaponOptions.OofOnDeathVol);
						}
						this.currentKills = num;
					}
				}
				else
				{
					this.currentKills = num;
				}
				if (MiscOptions.NightVision)
				{
					LevelLighting.vision = 1;
					LevelLighting.updateLighting();
					PlayerLifeUI.updateGrayscale();
					MiscOptions.WasNightVision = true;
				}
				else if (MiscOptions.WasNightVision)
				{
					LevelLighting.vision = 0;
					LevelLighting.updateLighting();
					PlayerLifeUI.updateGrayscale();
					MiscOptions.WasNightVision = false;
				}
				if (OptimizationVariables.MainPlayer.life.isDead)
				{
					MiscComponent.LastDeath = OptimizationVariables.MainPlayer.transform.position;
				}
				if (MiscOptions.NoFlash && MiscOptions.NoFlash && ((Color)typeof(PlayerUI).GetField("stunColor", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null)).a > 0f)
				{
					Color color = (Color)typeof(PlayerUI).GetField("stunColor", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
					color.a = 0f;
					typeof(PlayerUI).GetField("stunColor", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, color);
				}
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000090A8 File Offset: 0x000072A8
		public void FixedUpdate()
		{
			if (OptimizationVariables.MainPlayer)
			{
				MiscComponent.VehicleFlight();
				MiscComponent.PlayerFlight();
			}
			MiscComponent.PlayerFlight();
			if (MiscOptions.RunspeedMult2 || MiscOptions.JumpMult2)
			{
				this.standSpeed.SetValue(this.sprintSpeed, MiscOptions.RunspeedMult);
				this.proneSpeed.SetValue(this.sprintSpeed, MiscOptions.RunspeedMult);
				this.sprintSpeed.SetValue(this.sprintSpeed, MiscOptions.RunspeedMult);
				this.jumpHeight.SetValue(this.jumpHeight, MiscOptions.JumpMult);
				return;
			}
			this.standSpeed.SetValue(this.sprintSpeed, MiscComponent.SPEED_STAND);
			this.proneSpeed.SetValue(this.sprintSpeed, MiscComponent.SPEED_PRONE);
			this.sprintSpeed.SetValue(this.sprintSpeed, MiscComponent.SPEED_SPRINT);
			this.jumpHeight.SetValue(this.jumpHeight, MiscComponent.JUMP);
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000091BC File Offset: 0x000073BC
		public static void PlayerFlight()
		{
			Player mainPlayer = OptimizationVariables.MainPlayer;
			if (!MiscOptions.PlayerFlight)
			{
				ItemCloudAsset itemCloudAsset = mainPlayer.equipment.asset as ItemCloudAsset;
				mainPlayer.movement.itemGravityMultiplier = ((itemCloudAsset != null) ? itemCloudAsset.gravity : 1f);
				return;
			}
			mainPlayer.movement.itemGravityMultiplier = 0f;
			float flightSpeedMultiplier = MiscOptions.FlightSpeedMultiplier;
			if (HotkeyUtilities.IsHotkeyHeld("_FlyUp"))
			{
				mainPlayer.transform.position += mainPlayer.transform.up / 5f * flightSpeedMultiplier;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_FlyDown"))
			{
				mainPlayer.transform.position -= mainPlayer.transform.up / 5f * flightSpeedMultiplier;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_FlyLeft"))
			{
				mainPlayer.transform.position -= mainPlayer.transform.right / 5f * flightSpeedMultiplier;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_FlyRight"))
			{
				mainPlayer.transform.position += mainPlayer.transform.right / 5f * flightSpeedMultiplier;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_FlyForward"))
			{
				mainPlayer.transform.position += mainPlayer.transform.forward / 5f * flightSpeedMultiplier;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_FlyBackward"))
			{
				mainPlayer.transform.position -= mainPlayer.transform.forward / 5f * flightSpeedMultiplier;
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000938C File Offset: 0x0000758C
		public static void VehicleFlight()
		{
			InteractableVehicle vehicle = Player.player.movement.getVehicle();
			if (vehicle == null)
			{
				return;
			}
			Rigidbody component = vehicle.GetComponent<Rigidbody>();
			if (component == null)
			{
				return;
			}
			if (!vehicle.isDriver)
			{
				return;
			}
			if (!MiscOptions.VehicleFly)
			{
				if (MiscComponent.fly)
				{
					MiscComponent.fly = false;
					component.isKinematic = false;
				}
				return;
			}
			MiscComponent.fly = true;
			component.isKinematic = true;
			float num = MiscOptions.VehicleUseMaxSpeed ? (vehicle.asset.speedMax * Time.fixedDeltaTime) : (MiscOptions.SpeedMultiplier / 3f);
			num *= 0.98f;
			Transform transform = component.transform;
			Vector3 zero = Vector3.zero;
			Vector3 vector = Vector3.zero;
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateRight"))
			{
				zero.y += 2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateLeft"))
			{
				zero.y += -2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRollLeft"))
			{
				zero.z += 2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRollRight"))
			{
				zero.z += -2f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateUp"))
			{
				zero.x += -1.5f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFRotateDown"))
			{
				zero.x += 1.5f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeUp"))
			{
				vector.y += 0.6f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeDown"))
			{
				vector.y -= 0.6f;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeLeft"))
			{
				vector -= transform.right;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFStrafeRight"))
			{
				vector += transform.right;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFMoveForward"))
			{
				vector += transform.forward;
			}
			if (HotkeyUtilities.IsHotkeyHeld("_VFMoveBackward"))
			{
				vector -= transform.forward;
			}
			vector = vector * num + transform.position;
			if (MiscOptions.VehicleRigibody)
			{
				transform.position = vector;
				transform.Rotate(zero);
				return;
			}
			component.MovePosition(vector);
			component.MoveRotation(transform.localRotation * Quaternion.Euler(zero));
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00002EB4 File Offset: 0x000010B4
		public static void CheckMovementVerification()
		{
			MiscComponent.Instance.StartCoroutine(MiscComponent.CheckVerification(OptimizationVariables.MainPlayer.transform.position));
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000095D4 File Offset: 0x000077D4
		public static void incrementStatTrackerValue(ushort itemID, int newValue)
		{
			if (Player.player == null)
			{
				return;
			}
			SteamPlayer owner = Player.player.channel.owner;
			if (owner == null)
			{
				return;
			}
			int num;
			if (!owner.getItemSkinItemDefID(itemID, ref num))
			{
				return;
			}
			string text;
			string text2;
			if (!owner.getTagsAndDynamicPropsForItem(num, ref text, ref text2))
			{
				return;
			}
			DynamicEconDetails dynamicEconDetails;
			dynamicEconDetails..ctor(text, text2);
			EStatTrackerType estatTrackerType;
			int num2;
			if (dynamicEconDetails.getStatTrackerValue(ref estatTrackerType, ref num2))
			{
				if (!owner.modifiedItems.Contains(itemID))
				{
					owner.modifiedItems.Add(itemID);
				}
				int i = 0;
				while (i < owner.skinItems.Length)
				{
					if (owner.skinItems[i] != num)
					{
						i++;
					}
					else
					{
						if (i < owner.skinDynamicProps.Length)
						{
							owner.skinDynamicProps[i] = dynamicEconDetails.getPredictedDynamicPropsJsonForStatTracker(estatTrackerType, newValue);
							return;
						}
						break;
					}
				}
				return;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00002ED5 File Offset: 0x000010D5
		public static IEnumerator CheckVerification(Vector3 LastPos)
		{
			if (Time.realtimeSinceStartup - MiscComponent.LastMovementCheck < 0.8f)
			{
				yield break;
			}
			MiscComponent.LastMovementCheck = Time.realtimeSinceStartup;
			OptimizationVariables.MainPlayer.transform.position = new Vector3(0f, -1337f, 0f);
			yield return new WaitForSeconds(3f);
			if (VectorUtilities.GetDistance(OptimizationVariables.MainPlayer.transform.position, LastPos) < 10.0)
			{
				MiscOptions.NoMovementVerification = false;
			}
			else
			{
				MiscOptions.NoMovementVerification = true;
				OptimizationVariables.MainPlayer.transform.position = LastPos + new Vector3(0f, 5f, 0f);
			}
			yield break;
		}

		// Token: 0x0400004D RID: 77
		private FieldInfo standSpeed = typeof(PlayerMovement).GetField("SPEED_STAND", BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x0400004E RID: 78
		private FieldInfo sprintSpeed = typeof(PlayerMovement).GetField("SPEED_SPRINT", BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x0400004F RID: 79
		private FieldInfo proneSpeed = typeof(PlayerMovement).GetField("SPEED_PRONE", BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x04000050 RID: 80
		private FieldInfo jumpHeight = typeof(PlayerMovement).GetField("JUMP", BindingFlags.Static | BindingFlags.NonPublic);

		// Token: 0x04000051 RID: 81
		private static readonly float SPEED_STAND = 4.5f;

		// Token: 0x04000052 RID: 82
		private static readonly float SPEED_PRONE = 1.5f;

		// Token: 0x04000053 RID: 83
		private static readonly float SPEED_SPRINT = 7f;

		// Token: 0x04000054 RID: 84
		private static readonly float JUMP = 7f;

		// Token: 0x04000055 RID: 85
		private static bool fly;

		// Token: 0x04000056 RID: 86
		public static Vector3 LastDeath;

		// Token: 0x04000057 RID: 87
		public static MiscComponent Instance;

		// Token: 0x04000058 RID: 88
		public static float LastMovementCheck;

		// Token: 0x04000059 RID: 89
		public static bool FreecamBeforeSpy;

		// Token: 0x0400005A RID: 90
		public static bool NightvisionBeforeSpy;

		// Token: 0x0400005B RID: 91
		public static List<PlayerInputPacket> ClientsidePackets;

		// Token: 0x0400005C RID: 92
		public static FieldInfo Primary = typeof(PlayerEquipment).GetField("_primary", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400005D RID: 93
		public static FieldInfo Sequence = typeof(PlayerInput).GetField("sequence", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400005E RID: 94
		public static FieldInfo CPField = typeof(PlayerInput).GetField("clientsidePackets", BindingFlags.Instance | BindingFlags.NonPublic);

		// Token: 0x0400005F RID: 95
		public int currentKills = -1;

		// Token: 0x04000060 RID: 96
		public bool _isBroken;
	}
}
