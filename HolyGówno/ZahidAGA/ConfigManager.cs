using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZahidAGA
{
	// Token: 0x0200004C RID: 76
	public class ConfigManager
	{
		// Token: 0x06000203 RID: 515 RVA: 0x0000371A File Offset: 0x0000191A
		public static void Init()
		{
			Directory.CreateDirectory(ConfigManager.appdata + "\\Amturned");
			ConfigManager.LoadConfig(ConfigManager.GetConfig());
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000EF00 File Offset: 0x0000D100
		public static Dictionary<string, object> CollectConfig()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>
			{
				{
					"Version",
					ConfigManager.ConfigVersion
				}
			};
			foreach (Type type in (from T in Assembly.GetExecutingAssembly().GetTypes()
			where T.IsClass
			select T).ToArray<Type>())
			{
				foreach (FieldInfo fieldInfo in (from F in type.GetFields()
				where F.IsDefined(typeof(SaveAttribute), false)
				select F).ToArray<FieldInfo>())
				{
					dictionary.Add(type.Name + "_" + fieldInfo.Name, fieldInfo.GetValue(null));
				}
			}
			return dictionary;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000EFDC File Offset: 0x0000D1DC
		public static Dictionary<string, object> GetConfig()
		{
			if (!File.Exists(ConfigManager.ConfigPath))
			{
				ConfigManager.SaveConfig();
			}
			Dictionary<string, object> result = new Dictionary<string, object>();
			try
			{
				result = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(ConfigManager.ConfigPath), new JsonSerializerSettings
				{
					Formatting = 1
				});
			}
			catch
			{
				ConfigManager.SaveConfig();
			}
			return result;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0000373B File Offset: 0x0000193B
		public static void SaveConfig()
		{
			ColorOptions.ColorDict = ColorOptions.ColorDict;
			File.WriteAllText(ConfigManager.ConfigPath, JsonConvert.SerializeObject(ConfigManager.CollectConfig(), 1));
			T.AddNotification("Save Config - " + ConfigManager.current);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000F03C File Offset: 0x0000D23C
		public static void LoadConfig(Dictionary<string, object> Config)
		{
			if (File.Exists(ConfigManager.ConfigPath))
			{
				foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
				{
					foreach (FieldInfo fieldInfo in from f in type.GetFields()
					where Attribute.IsDefined(f, typeof(SaveAttribute))
					select f)
					{
						string key = string.Format("{0}_{1}", type.Name, fieldInfo.Name);
						Type fieldType = fieldInfo.FieldType;
						object value = fieldInfo.GetValue(null);
						if (!Config.ContainsKey(key))
						{
							Config.Add(key, value);
						}
						try
						{
							if (Config[key].GetType() == typeof(JArray))
							{
								Config[key] = ((JArray)Config[key]).ToObject(fieldInfo.FieldType);
							}
							if (Config[key].GetType() == typeof(JObject))
							{
								Config[key] = ((JObject)Config[key]).ToObject(fieldInfo.FieldType);
							}
							fieldInfo.SetValue(null, fieldInfo.FieldType.IsEnum ? Enum.ToObject(fieldInfo.FieldType, Config[key]) : Convert.ChangeType(Config[key], fieldInfo.FieldType));
						}
						catch
						{
							Config[key] = value;
						}
					}
				}
				HotkeyUtilities.Initialize();
				T.AddNotification("Load Config - " + ConfigManager.current);
			}
		}

		// Token: 0x040000FD RID: 253
		public static string ConfigPath = string.Format("{0}/Amturned/config.txt", Environment.ExpandEnvironmentVariables("%appdata%"));

		// Token: 0x040000FE RID: 254
		public static string appdata = Environment.ExpandEnvironmentVariables("%appdata%/");

		// Token: 0x040000FF RID: 255
		public static string current = "config";

		// Token: 0x04000100 RID: 256
		public static string ConfigVersion = "1.0.2";
	}
}
