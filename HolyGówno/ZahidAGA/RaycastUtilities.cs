using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000A1 RID: 161
	public static class RaycastUtilities
	{
		// Token: 0x060002E1 RID: 737 RVA: 0x00014700 File Offset: 0x00012900
		public static bool NoShootthroughthewalls(Transform transform)
		{
			Vector3 vector = AimbotCoroutines.GetAimPosition(transform, "Skull") - Player.player.look.aim.position;
			RaycastHit raycastHit;
			return Physics.Raycast(new Ray(Player.player.look.aim.position, vector), ref raycastHit, vector.magnitude, RayMasks.DAMAGE_CLIENT, 0) && raycastHit.transform.IsChildOf(transform);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00014774 File Offset: 0x00012974
		public static RaycastInfo GenerateOriginalRaycast(Ray ray, float range, int mask, Player ignorePlayer = null)
		{
			RaycastHit raycastHit;
			Physics.Raycast(ray, ref raycastHit, range, mask);
			RaycastInfo raycastInfo = new RaycastInfo(raycastHit);
			raycastInfo.direction = ray.direction;
			raycastInfo.limb = 12;
			if (raycastInfo.transform != null)
			{
				if (raycastInfo.transform.CompareTag("Barricade"))
				{
					raycastInfo.transform = DamageTool.getBarricadeRootTransform(raycastInfo.transform);
				}
				else if (raycastInfo.transform.CompareTag("Structure"))
				{
					raycastInfo.transform = DamageTool.getStructureRootTransform(raycastInfo.transform);
				}
				else if (raycastInfo.transform.CompareTag("Resource"))
				{
					raycastInfo.transform = DamageTool.getResourceRootTransform(raycastInfo.transform);
				}
				else if (raycastInfo.transform.CompareTag("Enemy"))
				{
					raycastInfo.player = DamageTool.getPlayer(raycastInfo.transform);
					if (raycastInfo.player == ignorePlayer)
					{
						raycastInfo.player = null;
					}
					raycastInfo.limb = DamageTool.getLimb(raycastInfo.transform);
				}
				else if (raycastInfo.transform.CompareTag("Zombie"))
				{
					raycastInfo.zombie = DamageTool.getZombie(raycastInfo.transform);
					raycastInfo.limb = DamageTool.getLimb(raycastInfo.transform);
				}
				else if (raycastInfo.transform.CompareTag("Animal"))
				{
					raycastInfo.animal = DamageTool.getAnimal(raycastInfo.transform);
					raycastInfo.limb = DamageTool.getLimb(raycastInfo.transform);
				}
				else if (raycastInfo.transform.CompareTag("Vehicle"))
				{
					raycastInfo.vehicle = DamageTool.getVehicle(raycastInfo.transform);
				}
				if (raycastInfo.zombie != null && raycastInfo.zombie.isRadioactive)
				{
					raycastInfo.materialName = "ALIEN_DYNAMIC";
				}
				else
				{
					raycastInfo.materialName = PhysicsTool.GetMaterialName(raycastHit.point, raycastInfo.transform, raycastInfo.collider);
				}
			}
			return raycastInfo;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00014958 File Offset: 0x00012B58
		public static bool GenerateRaycast(out RaycastInfo info)
		{
			ItemGunAsset itemGunAsset = OptimizationVariables.MainPlayer.equipment.asset as ItemGunAsset;
			float num = (itemGunAsset != null) ? itemGunAsset.range : 15.5f;
			info = RaycastUtilities.GenerateOriginalRaycast(new Ray(OptimizationVariables.MainPlayer.look.aim.position, OptimizationVariables.MainPlayer.look.aim.forward), num, RayMasks.DAMAGE_CLIENT, null);
			if (RaycastOptions.EnablePlayerSelection && RaycastUtilities.TargetedPlayer != null)
			{
				GameObject gameObject = RaycastUtilities.TargetedPlayer.gameObject;
				bool flag = true;
				Vector3 position = OptimizationVariables.MainPlayer.look.aim.position;
				if (Vector3.Distance(position, gameObject.transform.position) > num)
				{
					flag = false;
				}
				Vector3 point;
				if (!SphereUtilities.GetRaycast(gameObject, position, out point))
				{
					flag = false;
				}
				if (flag)
				{
					info = RaycastUtilities.GenerateRaycast(gameObject, point, info.collider);
					return true;
				}
				if (RaycastOptions.OnlyShootAtSelectedPlayer)
				{
					return false;
				}
			}
			GameObject @object;
			Vector3 point2;
			if (RaycastUtilities.GetTargetObject(RaycastUtilities.Objects, out @object, out point2, num))
			{
				info = RaycastUtilities.GenerateRaycast(@object, point2, info.collider);
				return true;
			}
			return false;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00014A70 File Offset: 0x00012C70
		public static RaycastInfo GenerateRaycast(GameObject Object, Vector3 Point, Collider col)
		{
			ELimb limb = RaycastOptions.TargetLimb;
			if (RaycastOptions.UseRandomLimb)
			{
				ELimb[] array = (ELimb[])Enum.GetValues(typeof(ELimb));
				limb = array[MathUtilities.Random.Next(0, array.Length)];
			}
			return new RaycastInfo(Object.transform)
			{
				point = Point,
				direction = OptimizationVariables.MainPlayer.look.aim.forward,
				limb = limb,
				player = Object.GetComponent<Player>(),
				zombie = Object.GetComponent<Zombie>(),
				vehicle = Object.GetComponent<InteractableVehicle>()
			};
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00014B08 File Offset: 0x00012D08
		public static bool GetTargetObject(HashSet<GameObject> Objects, out GameObject Object, out Vector3 Point, float Range)
		{
			double num = (double)(Range + 1f);
			double num2 = 180.0;
			Object = null;
			Point = Vector3.zero;
			Vector3 position = OptimizationVariables.MainPlayer.look.aim.position;
			Vector3 forward = OptimizationVariables.MainPlayer.look.aim.forward;
			foreach (GameObject gameObject in Objects)
			{
				if (!(gameObject == null))
				{
					if (gameObject.GetComponent<RaycastComponent>() == null)
					{
						gameObject.AddComponent<RaycastComponent>();
					}
					else
					{
						Vector3 position2 = gameObject.transform.position;
						Player component = gameObject.GetComponent<Player>();
						if ((!component || (!component.life.isDead && !FriendUtilities.IsFriendly(component))) && (!WeaponOptions.SafeZone || !LevelNodes.isPointInsideSafezone(component.transform.position, ref RaycastUtilities.isSafeInfo)) && (!WeaponOptions.Admin || !component.channel.owner.isAdmin))
						{
							Zombie component2 = gameObject.GetComponent<Zombie>();
							if (!component2 || !component2.isDead)
							{
								double distance = VectorUtilities.GetDistance(position, position2);
								if (distance <= (double)Range)
								{
									if (RaycastOptions.SilentAimUseFOV)
									{
										double angleDelta = VectorUtilities.GetAngleDelta(position, forward, position2);
										if (angleDelta > (double)RaycastOptions.SilentAimFOV || angleDelta > num2)
										{
											continue;
										}
										num2 = angleDelta;
									}
									else if (distance > num)
									{
										continue;
									}
									Vector3 vector;
									if (SphereUtilities.GetRaycast(gameObject, position, out vector))
									{
										Object = gameObject;
										num = distance;
										Point = vector;
									}
								}
							}
						}
					}
				}
			}
			return Object != null;
		}

		// Token: 0x040002D1 RID: 721
		public static SafezoneNode isSafeInfo;

		// Token: 0x040002D2 RID: 722
		public static HashSet<GameObject> Objects = new HashSet<GameObject>();

		// Token: 0x040002D3 RID: 723
		public static List<GameObject> AttachedObjects = new List<GameObject>();

		// Token: 0x040002D4 RID: 724
		public static Player TargetedPlayer;
	}
}
