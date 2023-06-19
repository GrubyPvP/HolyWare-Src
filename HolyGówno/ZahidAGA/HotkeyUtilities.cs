using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200008F RID: 143
	public static class HotkeyUtilities
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x00012C20 File Offset: 0x00010E20
		[Initializer]
		public static void Initialize()
		{
			HotkeyUtilities.AddHotkey("Menü", "Menü Tuşu", "_MenuComponent", new KeyCode[]
			{
				282
			});
			HotkeyUtilities.AddHotkey("Kamera", "Admin Kamerası", "_Cam", new KeyCode[]
			{
				283
			});
			HotkeyUtilities.AddHotkey("Mevlana", "Spin Bot Oyuncu", "_SpinOyuncu", new KeyCode[]
			{
				284
			});
			HotkeyUtilities.AddHotkey("Mevlana", "Spin Bot Araç", "_SpinAraç", new KeyCode[]
			{
				285
			});
			HotkeyUtilities.AddHotkey("Sunucu", "Sunucudan Hızlı Çıkma", "_Çık", new KeyCode[]
			{
				286
			});
			HotkeyUtilities.AddHotkey("Aimbot", "Triggerbot Tuşu", "_AimbotKey", new KeyCode[]
			{
				102
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Araçla Uçma Aç/Kapat", "_VFToggle", new KeyCode[]
			{
				301
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Araçla Işınlanma Aç/Kapat", "_ArIş", new KeyCode[]
			{
				53
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "İleri", "_VFMoveForward", new KeyCode[]
			{
				119
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Geri", "_VFMoveBackward", new KeyCode[]
			{
				115
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Sola", "_VFRotateLeft", new KeyCode[]
			{
				97
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Sağa", "_VFRotateRight", new KeyCode[]
			{
				100
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Yukarı Çıkma", "_VFStrafeUp", new KeyCode[]
			{
				32
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Aşağı İnme", "_VFStrafeDown", new KeyCode[]
			{
				306
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Yukarı Çevirme (Arrow=YönTuşu)", "_VFRotateUp", new KeyCode[]
			{
				273
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Aşağı Çevirme (Arrow=YönTuşu)", "_VFRotateDown", new KeyCode[]
			{
				274
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Sağa Çevirme (Arrow=YönTuşu)", "_VFRollLeft", new KeyCode[]
			{
				276
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Sola Çevirme (Arrow=YönTuşu)", "_VFRollRight", new KeyCode[]
			{
				275
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Sola Gitme", "_VFStrafeLeft", new KeyCode[]
			{
				113
			});
			HotkeyUtilities.AddHotkey("Araçla Uçma", "Sağata Gitme", "_VFStrafeRight", new KeyCode[]
			{
				101
			});
			HotkeyUtilities.AddHotkey("Uçma", "Yukarı", "_FlyUp", new KeyCode[]
			{
				32
			});
			HotkeyUtilities.AddHotkey("Uçma", "Aşağı", "_FlyDown", new KeyCode[]
			{
				306
			});
			HotkeyUtilities.AddHotkey("Uçma", "Sola", "_FlyLeft", new KeyCode[]
			{
				97
			});
			HotkeyUtilities.AddHotkey("Uçma", "Sağa", "_FlyRight", new KeyCode[]
			{
				100
			});
			HotkeyUtilities.AddHotkey("Uçma", "İleri", "_FlyForward", new KeyCode[]
			{
				119
			});
			HotkeyUtilities.AddHotkey("Uçma", "Geri", "_FlyBackward", new KeyCode[]
			{
				115
			});
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00012F78 File Offset: 0x00011178
		public static void AddHotkey(string Group, string Name, string Identifier, params KeyCode[] DefaultKeys)
		{
			if (!HotkeyOptions.HotkeyDict.ContainsKey(Group))
			{
				HotkeyOptions.HotkeyDict.Add(Group, new Dictionary<string, Hotkey>());
			}
			Dictionary<string, Hotkey> dictionary = HotkeyOptions.HotkeyDict[Group];
			if (dictionary.ContainsKey(Identifier))
			{
				return;
			}
			Hotkey value = new Hotkey
			{
				Name = Name,
				Keys = DefaultKeys
			};
			dictionary.Add(Identifier, value);
			HotkeyOptions.UnorganizedHotkeys.Add(Identifier, value);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00012FE0 File Offset: 0x000111E0
		public static bool IsHotkeyDown(string Identifier)
		{
			return HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.Any(new Func<KeyCode, bool>(Input.GetKeyDown)) && HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.All(new Func<KeyCode, bool>(Input.GetKey));
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00003E6A File Offset: 0x0000206A
		public static bool IsHotkeyHeld(string Identifier)
		{
			return HotkeyOptions.UnorganizedHotkeys[Identifier].Keys.All(new Func<KeyCode, bool>(Input.GetKey));
		}
	}
}
