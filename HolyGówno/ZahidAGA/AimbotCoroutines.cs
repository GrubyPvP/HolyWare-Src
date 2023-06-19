using System;
using System.Collections;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000037 RID: 55
	public static class AimbotCoroutines
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000192 RID: 402 RVA: 0x0000340A File Offset: 0x0000160A
		// (set) Token: 0x06000193 RID: 403 RVA: 0x0000341B File Offset: 0x0000161B
		public static float Pitch
		{
			get
			{
				return OptimizationVariables.MainPlayer.look.pitch;
			}
			set
			{
				AimbotCoroutines.PitchInfo.SetValue(OptimizationVariables.MainPlayer.look, value);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00003437 File Offset: 0x00001637
		// (set) Token: 0x06000195 RID: 405 RVA: 0x00003448 File Offset: 0x00001648
		public static float Yaw
		{
			get
			{
				return OptimizationVariables.MainPlayer.look.yaw;
			}
			set
			{
				AimbotCoroutines.YawInfo.SetValue(OptimizationVariables.MainPlayer.look, value);
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00003464 File Offset: 0x00001664
		[Initializer]
		public static void Init()
		{
			AimbotCoroutines.PitchInfo = typeof(PlayerLook).GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic);
			AimbotCoroutines.YawInfo = typeof(PlayerLook).GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000349C File Offset: 0x0000169C
		public static float? GetGunDistance()
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
			ItemGunAsset itemGunAsset = obj as ItemGunAsset;
			return new float?((itemGunAsset != null) ? itemGunAsset.range : 15.5f);
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000034D5 File Offset: 0x000016D5
		public static IEnumerator SetLockedObject()
		{
			for (;;)
			{
				if (!DrawUtilities.ShouldRun() || !AimbotOptions.Enabled)
				{
					yield return new WaitForSeconds(0.1f);
				}
				else
				{
					Player player = null;
					Vector3 mainPos = OptimizationVariables.MainPlayer.look.aim.position;
					Vector3 forward = OptimizationVariables.MainPlayer.look.aim.forward;
					SteamPlayer[] array = Provider.clients.ToArray();
					int num2;
					for (int i = 0; i < array.Length; i = num2 + 1)
					{
						TargetMode targetMode = AimbotOptions.TargetMode;
						SteamPlayer steamPlayer = array[i];
						if (steamPlayer != null && !(steamPlayer.player == OptimizationVariables.MainPlayer) && !(steamPlayer.player.life == null) && !steamPlayer.player.life.isDead && !FriendUtilities.IsFriendly(steamPlayer.player))
						{
							if (targetMode == TargetMode.FOV)
							{
								bool flag;
								if (VectorUtilities.GetAngleDelta(mainPos, forward, array[i].player.transform.position) < (double)AimbotOptions.FOV)
								{
									double distance = VectorUtilities.GetDistance(array[i].player.transform.position);
									float? gunDistance = AimbotCoroutines.GetGunDistance();
									double? num = (gunDistance != null) ? new double?((double)gunDistance.GetValueOrDefault()) : null;
									flag = (distance < num.GetValueOrDefault() & num != null);
								}
								else
								{
									flag = false;
								}
								if (flag)
								{
									if (player == null)
									{
										player = array[i].player;
									}
									else if (VectorUtilities.GetAngleDelta(mainPos, forward, array[i].player.transform.position) < VectorUtilities.GetAngleDelta(mainPos, forward, player.transform.position))
									{
										player = array[i].player;
									}
								}
							}
						}
						num2 = i;
					}
					if (!AimbotCoroutines.IsAiming)
					{
						AimbotCoroutines.LockedObject = ((player != null) ? player.gameObject : null);
					}
					yield return new WaitForEndOfFrame();
					mainPos = default(Vector3);
					forward = default(Vector3);
				}
			}
			yield break;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000034DD File Offset: 0x000016DD
		public static IEnumerator AimToObject()
		{
			for (;;)
			{
				if (!DrawUtilities.ShouldRun() || !AimbotOptions.Enabled)
				{
					yield return new WaitForSeconds(0.1f);
				}
				else
				{
					if (AimbotCoroutines.LockedObject != null && AimbotCoroutines.LockedObject.transform != null && OptimizationVariables.MainCam != null)
					{
						if (HotkeyUtilities.IsHotkeyHeld("_AimbotKey") || !AimbotOptions.OnKey)
						{
							AimbotCoroutines.IsAiming = true;
							if (AimbotOptions.Smooth)
							{
								AimbotCoroutines.SmoothAim(AimbotCoroutines.LockedObject);
							}
							else
							{
								AimbotCoroutines.Aim(AimbotCoroutines.LockedObject);
							}
						}
						else
						{
							AimbotCoroutines.IsAiming = false;
						}
					}
					else
					{
						AimbotCoroutines.IsAiming = false;
					}
					yield return new WaitForEndOfFrame();
				}
			}
			yield break;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000CEF0 File Offset: 0x0000B0F0
		public static void Aim(GameObject obj)
		{
			Camera mainCam = OptimizationVariables.MainCam;
			Vector3 aimPosition = AimbotCoroutines.GetAimPosition(obj.transform, "Skull");
			if (!(aimPosition == AimbotCoroutines.PiVector))
			{
				OptimizationVariables.MainPlayer.transform.LookAt(aimPosition);
				OptimizationVariables.MainPlayer.transform.eulerAngles = new Vector3(0f, OptimizationVariables.MainPlayer.transform.rotation.eulerAngles.y, 0f);
				mainCam.transform.LookAt(aimPosition);
				float num = mainCam.transform.localRotation.eulerAngles.x;
				if (num <= 90f && num <= 270f)
				{
					num = mainCam.transform.localRotation.eulerAngles.x + 90f;
				}
				else if (num >= 270f && num <= 360f)
				{
					num = mainCam.transform.localRotation.eulerAngles.x - 270f;
				}
				AimbotCoroutines.Pitch = num;
				AimbotCoroutines.Yaw = OptimizationVariables.MainPlayer.transform.rotation.eulerAngles.y;
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000D02C File Offset: 0x0000B22C
		public static void SmoothAim(GameObject obj)
		{
			Camera mainCam = OptimizationVariables.MainCam;
			Vector3 aimPosition = AimbotCoroutines.GetAimPosition(obj.transform, "Skull");
			if (!(aimPosition == AimbotCoroutines.PiVector))
			{
				OptimizationVariables.MainPlayer.transform.rotation = Quaternion.Slerp(OptimizationVariables.MainPlayer.transform.rotation, Quaternion.LookRotation(aimPosition - OptimizationVariables.MainPlayer.transform.position), Time.deltaTime * AimbotOptions.AimSpeed);
				OptimizationVariables.MainPlayer.transform.eulerAngles = new Vector3(0f, OptimizationVariables.MainPlayer.transform.rotation.eulerAngles.y, 0f);
				mainCam.transform.localRotation = Quaternion.Slerp(mainCam.transform.localRotation, Quaternion.LookRotation(aimPosition - mainCam.transform.position), Time.deltaTime * AimbotOptions.AimSpeed);
				float num = mainCam.transform.localRotation.eulerAngles.x;
				if (num <= 90f && num <= 270f)
				{
					num = mainCam.transform.localRotation.eulerAngles.x + 90f;
				}
				else if (num >= 270f && num <= 360f)
				{
					num = mainCam.transform.localRotation.eulerAngles.x - 270f;
				}
				AimbotCoroutines.Pitch = num;
				AimbotCoroutines.Yaw = OptimizationVariables.MainPlayer.transform.rotation.eulerAngles.y;
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x000034E5 File Offset: 0x000016E5
		public static Vector2 CalcAngle(GameObject obj)
		{
			OptimizationVariables.MainCam.WorldToScreenPoint(AimbotCoroutines.GetAimPosition(obj.transform, "Skull"));
			return Vector2.zero;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00003507 File Offset: 0x00001707
		public static void AimMouseTo(float x, float y)
		{
			AimbotCoroutines.Yaw = x;
			AimbotCoroutines.Pitch = y;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000D1D0 File Offset: 0x0000B3D0
		public static Vector3 GetAimPosition(Transform parent, string name)
		{
			Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
			Vector3 piVector;
			if (componentsInChildren == null)
			{
				piVector = AimbotCoroutines.PiVector;
			}
			else
			{
				foreach (Transform transform in componentsInChildren)
				{
					if (transform.name.Trim() == name)
					{
						return transform.position + new Vector3(0f, 0.4f, 0f);
					}
				}
				piVector = AimbotCoroutines.PiVector;
			}
			return piVector;
		}

		// Token: 0x040000CC RID: 204
		public static Vector3 PiVector = new Vector3(0f, 3.1415927f, 0f);

		// Token: 0x040000CD RID: 205
		public static GameObject LockedObject;

		// Token: 0x040000CE RID: 206
		public static bool IsAiming = false;

		// Token: 0x040000CF RID: 207
		public static FieldInfo PitchInfo;

		// Token: 0x040000D0 RID: 208
		public static FieldInfo YawInfo;
	}
}
