using System;
using System.Collections;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200003F RID: 63
	public static class ItemCoroutines
	{
		// Token: 0x060001CC RID: 460 RVA: 0x00003602 File Offset: 0x00001802
		public static IEnumerator PickupItems()
		{
			for (;;)
			{
				if (!DrawUtilities.ShouldRun() || !ItemOptions.AutoItemPickup)
				{
					yield return new WaitForSeconds(0.5f);
				}
				else
				{
					Collider[] array = Physics.OverlapSphere(OptimizationVariables.MainPlayer.transform.position, (float)ItemOptions.ItemPickupRange, 8192);
					int num;
					for (int i = 0; i < array.Length; i = num + 1)
					{
						Collider collider = array[i];
						if (!(collider == null) && !(collider.GetComponent<InteractableItem>() == null) && collider.GetComponent<InteractableItem>().asset != null)
						{
							InteractableItem component = collider.GetComponent<InteractableItem>();
							if (ItemUtilities.Whitelisted(component.asset, ItemOptions.ItemFilterOptions))
							{
								component.use();
							}
						}
						num = i;
					}
					yield return new WaitForSeconds(ItemOptions.ItemPickupDelay);
				}
			}
			yield break;
		}
	}
}
