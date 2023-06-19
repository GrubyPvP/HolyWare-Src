using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000088 RID: 136
	public class OV_UseableGun
	{
		// Token: 0x06000281 RID: 641 RVA: 0x00003D74 File Offset: 0x00001F74
		[Initializer]
		public static void Load()
		{
			OV_UseableGun.BulletsField = typeof(UseableGun).GetField("bullets", ReflectionVariables.publicInstance);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00010E0C File Offset: 0x0000F00C
		public static bool IsRaycastInvalid(RaycastInfo info)
		{
			return info.player == null && info.zombie == null && info.animal == null && info.vehicle == null && info.transform == null;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00010E60 File Offset: 0x0000F060
		[Override(typeof(UseableGun), "ballistics", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_ballistics()
		{
			Useable useable = OptimizationVariables.MainPlayer.equipment.useable;
			if (Provider.isServer)
			{
				OverrideUtilities.CallOriginal(useable, new object[0]);
				return;
			}
			if (Time.realtimeSinceStartup - PlayerLifeUI.hitmarkers[0].lastHit > PlayerUI.HIT_TIME)
			{
				PlayerLifeUI.hitmarkers[0].image.isVisible = false;
			}
			ItemGunAsset itemGunAsset = (ItemGunAsset)OptimizationVariables.MainPlayer.equipment.asset;
			PlayerLook look = OptimizationVariables.MainPlayer.look;
			if (!(itemGunAsset.projectile != null))
			{
				List<BulletInfo> list = (List<BulletInfo>)OV_UseableGun.BulletsField.GetValue(useable);
				if (list.Count != 0)
				{
					RaycastInfo raycastInfo = null;
					if (RaycastOptions.Enabled)
					{
						RaycastUtilities.GenerateRaycast(out raycastInfo);
						WeaponComponent.AddTracer(raycastInfo);
						WeaponComponent.AddDamage(raycastInfo);
					}
					if (Provider.modeConfigData.Gameplay.Ballistics)
					{
						if (raycastInfo == null)
						{
							if (AimbotOptions.NoAimbotDrop && (AimbotCoroutines.IsAiming && AimbotCoroutines.LockedObject != null))
							{
								Vector3 aimPosition = AimbotCoroutines.GetAimPosition(AimbotCoroutines.LockedObject.transform, "Skull");
								Ray aimRay = OV_UseableGun.GetAimRay(look.aim.position, aimPosition);
								float num = (float)VectorUtilities.GetDistance(look.aim.position, aimPosition);
								RaycastHit raycastHit;
								if (!Physics.Raycast(aimRay, ref raycastHit, num, RayMasks.DAMAGE_SERVER))
								{
									raycastInfo = RaycastUtilities.GenerateOriginalRaycast(aimRay, itemGunAsset.range, 1024, null);
								}
							}
							if (WeaponOptions.NoDrop && raycastInfo == null)
							{
								for (int i = 0; i < list.Count; i++)
								{
									BulletInfo bulletInfo = list[i];
									RaycastInfo raycastInfo2 = DamageTool.raycast(new Ray(bulletInfo.pos, bulletInfo.dir), itemGunAsset.ballisticTravel, RayMasks.DAMAGE_CLIENT);
									if (OV_UseableGun.IsRaycastInvalid(raycastInfo2))
									{
										bulletInfo.pos += bulletInfo.dir * itemGunAsset.ballisticTravel;
									}
									else
									{
										EPlayerHit eplayerHit = OV_UseableGun.CalcHitMarker(itemGunAsset, ref raycastInfo2);
										PlayerUI.hitmark(0, Vector3.zero, false, eplayerHit);
										OptimizationVariables.MainPlayer.input.sendRaycast(raycastInfo2, 3);
										bulletInfo.steps = 254;
									}
								}
								for (int j = list.Count - 1; j >= 0; j--)
								{
									BulletInfo bulletInfo2 = list[j];
									bulletInfo2.steps += 1;
									if (bulletInfo2.steps >= itemGunAsset.ballisticSteps)
									{
										list.RemoveAt(j);
									}
								}
								return;
							}
							if (raycastInfo == null)
							{
								OverrideUtilities.CallOriginal(useable, new object[0]);
								return;
							}
						}
						for (int k = 0; k < list.Count; k++)
						{
							BulletInfo bulletInfo3 = list[k];
							double distance = VectorUtilities.GetDistance(OptimizationVariables.MainPlayer.transform.position, raycastInfo.point);
							if ((double)((float)bulletInfo3.steps * itemGunAsset.ballisticTravel) >= distance)
							{
								EPlayerHit eplayerHit2 = OV_UseableGun.CalcHitMarker(itemGunAsset, ref raycastInfo);
								PlayerUI.hitmark(0, Vector3.zero, false, eplayerHit2);
								OptimizationVariables.MainPlayer.input.sendRaycast(raycastInfo, 3);
								bulletInfo3.steps = 254;
							}
						}
						for (int l = list.Count - 1; l >= 0; l--)
						{
							BulletInfo bulletInfo4 = list[l];
							bulletInfo4.steps += 1;
							if (bulletInfo4.steps >= itemGunAsset.ballisticSteps)
							{
								list.RemoveAt(l);
							}
						}
						return;
					}
					if (raycastInfo != null)
					{
						for (int m = 0; m < list.Count; m++)
						{
							EPlayerHit eplayerHit3 = OV_UseableGun.CalcHitMarker(itemGunAsset, ref raycastInfo);
							PlayerUI.hitmark(0, Vector3.zero, false, eplayerHit3);
							OptimizationVariables.MainPlayer.input.sendRaycast(raycastInfo, 3);
						}
						list.Clear();
						return;
					}
					OverrideUtilities.CallOriginal(useable, new object[0]);
				}
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00011228 File Offset: 0x0000F428
		public static EPlayerHit CalcHitMarker(ItemGunAsset PAsset, ref RaycastInfo ri)
		{
			EPlayerHit eplayerHit = 0;
			EPlayerHit result;
			if (ri == null || PAsset == null)
			{
				result = eplayerHit;
			}
			else
			{
				if (ri.animal || ri.player || ri.zombie)
				{
					eplayerHit = 1;
					if (ri.limb == 13)
					{
						eplayerHit = 2;
					}
				}
				else if (ri.transform)
				{
					if (ri.transform.CompareTag("Barricade") && PAsset.barricadeDamage > 1f)
					{
						InteractableDoorHinge component = ri.transform.GetComponent<InteractableDoorHinge>();
						if (component != null)
						{
							ri.transform = component.transform.parent.parent;
						}
						ushort num;
						if (!ushort.TryParse(ri.transform.name, out num))
						{
							return eplayerHit;
						}
						ItemBarricadeAsset itemBarricadeAsset = (ItemBarricadeAsset)Assets.find(1, num);
						if (itemBarricadeAsset == null || (!itemBarricadeAsset.isVulnerable && !PAsset.isInvulnerable))
						{
							return eplayerHit;
						}
						if (eplayerHit == 0)
						{
							eplayerHit = 3;
						}
					}
					else if (ri.transform.CompareTag("Structure") && PAsset.structureDamage > 1f)
					{
						ushort num2;
						if (!ushort.TryParse(ri.transform.name, out num2))
						{
							return eplayerHit;
						}
						ItemStructureAsset itemStructureAsset = (ItemStructureAsset)Assets.find(1, num2);
						if (itemStructureAsset == null || (!itemStructureAsset.isVulnerable && !PAsset.isInvulnerable))
						{
							return eplayerHit;
						}
						if (eplayerHit == 0)
						{
							eplayerHit = 3;
						}
					}
					else if (ri.transform.CompareTag("Resource") && PAsset.resourceDamage > 1f)
					{
						byte b;
						byte b2;
						ushort num3;
						if (!ResourceManager.tryGetRegion(ri.transform, ref b, ref b2, ref num3))
						{
							return eplayerHit;
						}
						ResourceSpawnpoint resourceSpawnpoint = ResourceManager.getResourceSpawnpoint(b, b2, num3);
						if (resourceSpawnpoint == null || resourceSpawnpoint.isDead || !PAsset.hasBladeID(resourceSpawnpoint.asset.bladeID))
						{
							return eplayerHit;
						}
						if (eplayerHit == 0)
						{
							eplayerHit = 3;
						}
					}
					else if (PAsset.objectDamage > 1f)
					{
						InteractableObjectRubble component2 = ri.transform.GetComponent<InteractableObjectRubble>();
						if (component2 == null)
						{
							return eplayerHit;
						}
						ri.section = component2.getSection(ri.collider.transform);
						if (component2.isSectionDead(ri.section) || (!component2.asset.rubbleIsVulnerable && !PAsset.isInvulnerable))
						{
							return eplayerHit;
						}
						if (eplayerHit == 0)
						{
							eplayerHit = 3;
						}
					}
				}
				else if (ri.vehicle && !ri.vehicle.isDead && PAsset.vehicleDamage > 1f && (ri.vehicle.asset != null && (ri.vehicle.asset.isVulnerable || PAsset.isInvulnerable)) && eplayerHit == 0)
				{
					eplayerHit = 3;
				}
				result = eplayerHit;
			}
			return result;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001153C File Offset: 0x0000F73C
		public static Ray GetAimRay(Vector3 origin, Vector3 pos)
		{
			Vector3 vector = VectorUtilities.Normalize(pos - origin);
			return new Ray(pos, vector);
		}

		// Token: 0x040002B3 RID: 691
		public static FieldInfo BulletsField;
	}
}
