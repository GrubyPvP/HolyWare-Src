using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200001E RID: 30
	[Component]
	public class HotkeyComponent : MonoBehaviour
	{
		// Token: 0x060000F6 RID: 246 RVA: 0x00008664 File Offset: 0x00006864
		public void Update()
		{
			if (HotkeyComponent.NeedsKeys)
			{
				List<KeyCode> currentKeys = HotkeyComponent.CurrentKeys.ToList<KeyCode>();
				HotkeyComponent.CurrentKeys.Clear();
				foreach (KeyCode keyCode in HotkeyComponent.Keys)
				{
					if (Input.GetKey(keyCode))
					{
						HotkeyComponent.CurrentKeys.Add(keyCode);
					}
				}
				if (HotkeyComponent.CurrentKeys.Count < HotkeyComponent.CurrentKeyCount && HotkeyComponent.CurrentKeyCount > 0)
				{
					HotkeyComponent.CurrentKeys = currentKeys;
					HotkeyComponent.StopKeys = true;
				}
				HotkeyComponent.CurrentKeyCount = HotkeyComponent.CurrentKeys.Count;
			}
			if (!MenuComponent.IsInMenu)
			{
				foreach (KeyValuePair<string, Action> keyValuePair in HotkeyComponent.ActionDict)
				{
					if ((!MiscOptions.PanicMode || keyValuePair.Key == "_PanicButton") && HotkeyUtilities.IsHotkeyDown(keyValuePair.Key))
					{
						keyValuePair.Value.Invoke();
					}
				}
				return;
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00002D35 File Offset: 0x00000F35
		public static void Clear()
		{
			HotkeyComponent.NeedsKeys = false;
			HotkeyComponent.StopKeys = false;
			HotkeyComponent.CurrentKeyCount = 0;
			HotkeyComponent.CurrentKeys = new List<KeyCode>();
		}

		// Token: 0x04000041 RID: 65
		public static bool NeedsKeys;

		// Token: 0x04000042 RID: 66
		public static bool StopKeys;

		// Token: 0x04000043 RID: 67
		public static int CurrentKeyCount;

		// Token: 0x04000044 RID: 68
		public static List<KeyCode> CurrentKeys;

		// Token: 0x04000045 RID: 69
		public static Dictionary<string, Action> ActionDict = new Dictionary<string, Action>();

		// Token: 0x04000046 RID: 70
		public static KeyCode[] Keys = (KeyCode[])Enum.GetValues(typeof(KeyCode));
	}
}
