using System;
using System.Reflection;
using SDG.Unturned;

namespace ZahidAGA
{
	// Token: 0x02000084 RID: 132
	public class OV_VendorUI
	{
		// Token: 0x06000278 RID: 632 RVA: 0x00010C20 File Offset: 0x0000EE20
		[Override(typeof(PlayerNPCVendorUI), "onClickedBuyingButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void onClickedBuyingButton(SleekButtonIcon button)
		{
			if (MiscOptions.FastSell)
			{
				for (int i = 0; i < MiscOptions.FastSellCount; i++)
				{
					OverrideUtilities.CallOriginal(null, new object[]
					{
						button
					});
				}
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				button
			});
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00010C68 File Offset: 0x0000EE68
		[Override(typeof(PlayerNPCVendorUI), "onClickedSellingButton", BindingFlags.Static | BindingFlags.NonPublic, 0)]
		public static void onClickedSellingButton(SleekButtonIcon button)
		{
			if (MiscOptions.FastBuy)
			{
				for (int i = 0; i < MiscOptions.FastSellCount; i++)
				{
					OverrideUtilities.CallOriginal(null, new object[]
					{
						button
					});
				}
				return;
			}
			OverrideUtilities.CallOriginal(null, new object[]
			{
				button
			});
		}
	}
}
