using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ZahidAGA
{
	// Token: 0x0200004E RID: 78
	public class OverrideManager
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600020F RID: 527 RVA: 0x000037E7 File Offset: 0x000019E7
		public Dictionary<OverrideAttribute, OverrideWrapper> Overrides
		{
			get
			{
				return OverrideManager._overrides;
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000F230 File Offset: 0x0000D430
		public void OffHook()
		{
			foreach (OverrideWrapper overrideWrapper in this.Overrides.Values)
			{
				overrideWrapper.Revert();
			}
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000F288 File Offset: 0x0000D488
		public void LoadOverride(MethodInfo method)
		{
			try
			{
				OverrideAttribute attribute = (OverrideAttribute)Attribute.GetCustomAttribute(method, typeof(OverrideAttribute));
				if (this.Overrides.Count((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Key.Method == attribute.Method) <= 0)
				{
					OverrideWrapper overrideWrapper = new OverrideWrapper(attribute.Method, method, attribute, null);
					overrideWrapper.Override();
					this.Overrides.Add(attribute, overrideWrapper);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000F31C File Offset: 0x0000D51C
		public void InitHook()
		{
			Type[] types = Assembly.GetExecutingAssembly().GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				foreach (MethodInfo methodInfo in types[i].GetMethods())
				{
					if (methodInfo.Name == "OV_GetKey" && methodInfo.IsDefined(typeof(OverrideAttribute), false))
					{
						this.LoadOverride(methodInfo);
					}
				}
			}
		}

		// Token: 0x04000105 RID: 261
		public static Dictionary<OverrideAttribute, OverrideWrapper> _overrides = new Dictionary<OverrideAttribute, OverrideWrapper>();
	}
}
