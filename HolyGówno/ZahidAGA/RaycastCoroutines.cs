using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000047 RID: 71
	public class RaycastCoroutines
	{
		// Token: 0x060001EC RID: 492 RVA: 0x00003679 File Offset: 0x00001879
		public static IEnumerator UpdateObjects()
		{
			for (;;)
			{
				if (!DrawUtilities.ShouldRun())
				{
					RaycastUtilities.Objects.Clear();
					yield return new WaitForSeconds(1f);
				}
				else
				{
					try
					{
						ItemGunAsset itemGunAsset = OptimizationVariables.MainPlayer.equipment.asset as ItemGunAsset;
						float num = (itemGunAsset != null) ? itemGunAsset.range : 15.5f;
						num += 10f;
						GameObject[] array = (from c in Physics.OverlapSphere(OptimizationVariables.MainPlayer.transform.position, num)
						select c.gameObject).ToArray<GameObject>();
						RaycastUtilities.Objects.Clear();
						if (RaycastOptions.TargetPlayers)
						{
							RaycastCoroutines.CachedPlayers.Clear();
							GameObject[] array2 = array;
							for (int i = 0; i < array2.Length; i++)
							{
								Player player = DamageTool.getPlayer(array2[i].transform);
								if (!(player == null) && !RaycastCoroutines.CachedPlayers.Contains(player) && !(player == OptimizationVariables.MainPlayer) && !player.life.isDead)
								{
									RaycastCoroutines.CachedPlayers.Add(player);
								}
							}
							RaycastUtilities.Objects.AddRange(from c in RaycastCoroutines.CachedPlayers
							select c.gameObject);
						}
						if (RaycastOptions.TargetZombies)
						{
							RaycastUtilities.Objects.AddRange((from g in array
							where g.GetComponent<Zombie>() != null
							select g).ToArray<GameObject>());
						}
						if (RaycastOptions.TargetSentries)
						{
							RaycastUtilities.Objects.AddRange(from g in array
							where g.GetComponent<InteractableSentry>() != null
							select g);
						}
						if (RaycastOptions.TargetBeds)
						{
							RaycastUtilities.Objects.AddRange(from g in array
							where g.GetComponent<InteractableBed>() != null
							select g);
						}
						if (RaycastOptions.TargetAnimal)
						{
							RaycastUtilities.Objects.AddRange((from g in array
							where g.GetComponent<Animal>() != null
							select g).ToArray<GameObject>());
						}
						if (RaycastOptions.TargetClaimFlags)
						{
							RaycastUtilities.Objects.AddRange(from g in array
							where g.GetComponent<InteractableClaim>() != null
							select g);
						}
						if (RaycastOptions.TargetVehicles)
						{
							RaycastUtilities.Objects.AddRange(from g in array
							where g.GetComponent<InteractableVehicle>() != null
							select g);
						}
						if (RaycastOptions.TargetStorage)
						{
							RaycastUtilities.Objects.AddRange(from g in array
							where g.GetComponent<InteractableStorage>() != null
							select g);
						}
					}
					catch (Exception)
					{
					}
					yield return new WaitForSeconds(0f);
				}
			}
			yield break;
		}

		// Token: 0x040000EF RID: 239
		public static List<Player> CachedPlayers = new List<Player>();
	}
}
