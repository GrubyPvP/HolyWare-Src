using System;
using System.Reflection;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000077 RID: 119
	public static class OV_Cursor
	{
		// Token: 0x06000248 RID: 584 RVA: 0x00003A9D File Offset: 0x00001C9D
		[Override(typeof(Cursor), "set_lockState", BindingFlags.Static | BindingFlags.Public, 0)]
		public static void OV_set_lockState(CursorLockMode rMode)
		{
			if (!MenuComponent.IsInMenu || G.BeingSpied || (rMode != 2 && rMode != 1))
			{
				OverrideUtilities.CallOriginal(null, new object[]
				{
					rMode
				});
			}
		}
	}
}
