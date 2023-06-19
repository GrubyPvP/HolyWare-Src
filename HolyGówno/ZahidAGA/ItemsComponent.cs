using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200001F RID: 31
	[Component]
	public class ItemsComponent : MonoBehaviour
	{
		// Token: 0x060000FA RID: 250 RVA: 0x00008768 File Offset: 0x00006968
		public static void RefreshItems()
		{
			ItemsComponent.items.Clear();
			for (ushort num = 0; num < 65535; num += 1)
			{
				ItemAsset itemAsset = (ItemAsset)Assets.find(1, num);
				if (!string.IsNullOrEmpty((itemAsset != null) ? itemAsset.itemName : null) && !ItemsComponent.items.Contains(itemAsset))
				{
					ItemsComponent.items.Add(itemAsset);
				}
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00002D78 File Offset: 0x00000F78
		public void Start()
		{
			CoroutineComponent.ItemPickupCoroutine = base.StartCoroutine(ItemCoroutines.PickupItems());
			CoroutineComponent.ItemPickupCoroutine2 = base.StartCoroutine(ItemCoroutines2.PickupItems());
		}

		// Token: 0x04000047 RID: 71
		public static List<ItemAsset> items = new List<ItemAsset>();
	}
}
