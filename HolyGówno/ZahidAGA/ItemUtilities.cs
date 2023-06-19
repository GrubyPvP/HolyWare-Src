using System;
using System.Collections.Generic;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000091 RID: 145
	public static class ItemUtilities
	{
		// Token: 0x060002B0 RID: 688 RVA: 0x000131EC File Offset: 0x000113EC
		public static bool Whitelisted(ItemAsset asset, ItemOptionList OptionList)
		{
			return (OptionList.ItemfilterCustom && OptionList.AddedItems.Contains(asset.id)) || (OptionList.ItemfilterGun && asset is ItemGunAsset) || (OptionList.ItemfilterGunMeel && asset is ItemMeleeAsset) || (OptionList.ItemfilterAmmo && asset is ItemMagazineAsset) || (OptionList.ItemfilterMedical && asset is ItemMedicalAsset) || (OptionList.ItemfilterFoodAndWater && (asset is ItemFoodAsset || asset is ItemWaterAsset)) || (OptionList.ItemfilterBackpack && asset is ItemBackpackAsset) || (OptionList.ItemfilterCharges && asset is ItemChargeAsset) || (OptionList.ItemfilterFuel && asset is ItemFuelAsset) || (OptionList.ItemfilterClothing && asset is ItemClothingAsset);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00013318 File Offset: 0x00011518
		public static void DrawItemButton(ItemAsset asset, HashSet<ushort> AddedItems)
		{
			string text = asset.itemName;
			if (asset.itemName.Length > 60)
			{
				text = asset.itemName.Substring(0, 60) + "..";
			}
			if (Prefab.Button(text, 390f, 25f, new GUILayoutOption[0]))
			{
				if (AddedItems.Contains(asset.id))
				{
					AddedItems.Remove(asset.id);
				}
				else
				{
					AddedItems.Add(asset.id);
				}
			}
			GUILayout.Space(3f);
		}
	}
}
