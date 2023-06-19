using System;
using System.Collections;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200002A RID: 42
	[Component]
	public class TriggerbotComponent : MonoBehaviour
	{
		// Token: 0x06000146 RID: 326 RVA: 0x0000310D File Offset: 0x0000130D
		[Initializer]
		public static void Init()
		{
			TriggerbotComponent.CurrentFiremode = typeof(UseableGun).GetField("firemode", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000312A File Offset: 0x0000132A
		public void Start()
		{
			base.StartCoroutine(TriggerbotComponent.CheckTrigger());
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00003138 File Offset: 0x00001338
		public static IEnumerator CheckTrigger()
		{
			for (;;)
			{
				yield return new WaitForSeconds(0.1f);
				if (!TriggerbotOptions.Enabled || !DrawUtilities.ShouldRun() || OptimizationVariables.MainPlayer.stance.stance == 2 || OptimizationVariables.MainPlayer.stance.stance == null || OptimizationVariables.MainPlayer.stance.stance == 6)
				{
					TriggerbotOptions.IsFiring = false;
				}
				else
				{
					PlayerLook look = OptimizationVariables.MainPlayer.look;
					Useable useable = OptimizationVariables.MainPlayer.equipment.useable;
					UseableGun useableGun;
					if (useable == null)
					{
						TriggerbotOptions.IsFiring = false;
					}
					else if ((useableGun = (useable as UseableGun)) != null)
					{
						UseableGun obj = useableGun;
						ItemGunAsset itemGunAsset = (ItemGunAsset)OptimizationVariables.MainPlayer.equipment.asset;
						RaycastInfo raycastInfo = RaycastUtilities.GenerateOriginalRaycast(new Ray(look.aim.position, look.aim.forward), itemGunAsset.range, RayMasks.DAMAGE_CLIENT, null);
						if (AimbotCoroutines.LockedObject != null && AimbotCoroutines.IsAiming)
						{
							Ray ray = OV_UseableGun.GetAimRay(look.aim.position, AimbotCoroutines.GetAimPosition(AimbotCoroutines.LockedObject.transform, "Skull"));
							raycastInfo = RaycastUtilities.GenerateOriginalRaycast(new Ray(ray.origin, ray.direction), itemGunAsset.range, RayMasks.DAMAGE_CLIENT, null);
							ray = default(Ray);
						}
						bool flag = raycastInfo.player == null;
						if (RaycastOptions.Enabled)
						{
							flag = RaycastUtilities.GenerateRaycast(out raycastInfo);
							WeaponComponent.AddTracer(raycastInfo);
							WeaponComponent.AddDamage(raycastInfo);
						}
						if (flag)
						{
							TriggerbotOptions.IsFiring = false;
						}
						else if ((EFiremode)TriggerbotComponent.CurrentFiremode.GetValue(obj) == 2)
						{
							TriggerbotOptions.IsFiring = true;
						}
						else
						{
							TriggerbotOptions.IsFiring = !TriggerbotOptions.IsFiring;
						}
					}
					else if (useable as UseableMelee != null)
					{
						ItemMeleeAsset itemMeleeAsset = (ItemMeleeAsset)OptimizationVariables.MainPlayer.equipment.asset;
						RaycastInfo raycastInfo2 = RaycastUtilities.GenerateOriginalRaycast(new Ray(look.aim.position, look.aim.forward), itemMeleeAsset.range, RayMasks.DAMAGE_CLIENT, null);
						if (AimbotCoroutines.LockedObject != null && AimbotCoroutines.IsAiming)
						{
							Ray ray2 = OV_UseableGun.GetAimRay(look.aim.position, AimbotCoroutines.GetAimPosition(AimbotCoroutines.LockedObject.transform, "Skull"));
							raycastInfo2 = RaycastUtilities.GenerateOriginalRaycast(new Ray(ray2.origin, ray2.direction), itemMeleeAsset.range, RayMasks.DAMAGE_CLIENT, null);
							ray2 = default(Ray);
						}
						bool flag2 = raycastInfo2.player != null;
						if (RaycastOptions.Enabled)
						{
							flag2 = RaycastUtilities.GenerateRaycast(out raycastInfo2);
						}
						if (!flag2)
						{
							TriggerbotOptions.IsFiring = false;
						}
						else if (itemMeleeAsset.isRepeated)
						{
							TriggerbotOptions.IsFiring = true;
						}
						else
						{
							TriggerbotOptions.IsFiring = !TriggerbotOptions.IsFiring;
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x04000080 RID: 128
		public static FieldInfo CurrentFiremode;
	}
}
