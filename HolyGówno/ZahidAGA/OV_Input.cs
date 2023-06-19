using System;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000079 RID: 121
	public static class OV_Input
	{
		// Token: 0x0600024B RID: 587 RVA: 0x00003ADE File Offset: 0x00001CDE
		[OnSpy]
		public static void OnSpied()
		{
			OV_Input.InputEnabled = false;
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00003AE6 File Offset: 0x00001CE6
		[OffSpy]
		public static void OnEndSpy()
		{
			OV_Input.InputEnabled = true;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000FE48 File Offset: 0x0000E048
		[Override(typeof(Input), "GetKey", BindingFlags.Static | BindingFlags.Public, 0)]
		public static bool OV_GetKey(KeyCode key)
		{
			bool result;
			if (!DrawUtilities.ShouldRun() || !OV_Input.InputEnabled)
			{
				result = (bool)OverrideUtilities.CallOriginal(null, new object[]
				{
					key
				});
			}
			else
			{
				result = ((key == ControlsSettings.primary && TriggerbotOptions.IsFiring) || (((key != ControlsSettings.left && key != ControlsSettings.right && key != ControlsSettings.up && key != ControlsSettings.down) || !(MiscOptions.SpectatedPlayer != null)) && (bool)OverrideUtilities.CallOriginal(null, new object[]
				{
					key
				})));
			}
			return result;
		}

		// Token: 0x04000291 RID: 657
		public static bool InputEnabled = true;
	}
}
