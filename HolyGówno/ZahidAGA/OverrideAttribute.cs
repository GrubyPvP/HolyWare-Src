using System;
using System.Linq;
using System.Reflection;

namespace ZahidAGA
{
	// Token: 0x02000017 RID: 23
	[AttributeUsage(AttributeTargets.Method)]
	public class OverrideAttribute : Attribute
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00002C9F File Offset: 0x00000E9F
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00002CA7 File Offset: 0x00000EA7
		public Type Class { get; private set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00002CB0 File Offset: 0x00000EB0
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00002CB8 File Offset: 0x00000EB8
		public string MethodName { get; private set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00002CC1 File Offset: 0x00000EC1
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00002CC9 File Offset: 0x00000EC9
		public MethodInfo Method { get; private set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00002CD2 File Offset: 0x00000ED2
		// (set) Token: 0x060000EA RID: 234 RVA: 0x00002CDA File Offset: 0x00000EDA
		public BindingFlags Flags { get; private set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00002CE3 File Offset: 0x00000EE3
		// (set) Token: 0x060000EC RID: 236 RVA: 0x00002CEB File Offset: 0x00000EEB
		public bool MethodFound { get; private set; }

		// Token: 0x060000ED RID: 237 RVA: 0x000085DC File Offset: 0x000067DC
		public OverrideAttribute(Type tClass, string method, BindingFlags flags, int index = 0)
		{
			this.Class = tClass;
			this.MethodName = method;
			this.Flags = flags;
			try
			{
				this.Method = (from a in this.Class.GetMethods(flags)
				where a.Name == method
				select a).ToArray<MethodInfo>()[index];
				this.MethodFound = true;
			}
			catch (Exception)
			{
				this.MethodFound = false;
			}
		}
	}
}
