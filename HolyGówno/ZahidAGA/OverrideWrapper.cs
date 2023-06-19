using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ZahidAGA
{
	// Token: 0x020000B0 RID: 176
	public class OverrideWrapper
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600030F RID: 783 RVA: 0x00004289 File Offset: 0x00002489
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00004291 File Offset: 0x00002491
		public MethodInfo Original { get; set; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000429A File Offset: 0x0000249A
		// (set) Token: 0x06000312 RID: 786 RVA: 0x000042A2 File Offset: 0x000024A2
		public MethodInfo Modified { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000313 RID: 787 RVA: 0x000042AB File Offset: 0x000024AB
		// (set) Token: 0x06000314 RID: 788 RVA: 0x000042B3 File Offset: 0x000024B3
		public IntPtr PtrOriginal { get; private set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000315 RID: 789 RVA: 0x000042BC File Offset: 0x000024BC
		// (set) Token: 0x06000316 RID: 790 RVA: 0x000042C4 File Offset: 0x000024C4
		public IntPtr PtrModified { get; private set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000317 RID: 791 RVA: 0x000042CD File Offset: 0x000024CD
		// (set) Token: 0x06000318 RID: 792 RVA: 0x000042D5 File Offset: 0x000024D5
		public OverrideUtilities.OffsetBackup OffsetBackup { get; private set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000319 RID: 793 RVA: 0x000042DE File Offset: 0x000024DE
		// (set) Token: 0x0600031A RID: 794 RVA: 0x000042E6 File Offset: 0x000024E6
		public OverrideAttribute Attribute { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600031B RID: 795 RVA: 0x000042EF File Offset: 0x000024EF
		// (set) Token: 0x0600031C RID: 796 RVA: 0x000042F7 File Offset: 0x000024F7
		public bool Detoured { get; private set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600031D RID: 797 RVA: 0x00004300 File Offset: 0x00002500
		public object Instance { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600031E RID: 798 RVA: 0x00004308 File Offset: 0x00002508
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00004310 File Offset: 0x00002510
		public bool Local { get; private set; }

		// Token: 0x06000320 RID: 800 RVA: 0x000158B8 File Offset: 0x00013AB8
		public OverrideWrapper(MethodInfo original, MethodInfo modified, OverrideAttribute attribute, object instance = null)
		{
			try
			{
				this.Original = original;
				this.Modified = modified;
				this.Instance = instance;
				this.Attribute = attribute;
				this.Local = (this.Modified.DeclaringType.Assembly == Assembly.GetExecutingAssembly());
				RuntimeHelpers.PrepareMethod(original.MethodHandle);
				RuntimeHelpers.PrepareMethod(modified.MethodHandle);
				this.PtrOriginal = this.Original.MethodHandle.GetFunctionPointer();
				this.PtrModified = this.Modified.MethodHandle.GetFunctionPointer();
				this.OffsetBackup = new OverrideUtilities.OffsetBackup(this.PtrOriginal);
				this.Detoured = false;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00015980 File Offset: 0x00013B80
		public bool Override()
		{
			bool result;
			if (this.Detoured)
			{
				result = true;
			}
			else
			{
				bool flag = OverrideUtilities.OverrideFunction(this.PtrOriginal, this.PtrModified);
				if (flag)
				{
					this.Detoured = true;
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000159B8 File Offset: 0x00013BB8
		public bool Revert()
		{
			bool result;
			if (!this.Detoured)
			{
				result = false;
			}
			else
			{
				bool flag = OverrideUtilities.RevertOverride(this.OffsetBackup);
				if (flag)
				{
					this.Detoured = false;
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x00004319 File Offset: 0x00002519
		public object CallOriginal(object[] args, object instance = null)
		{
			this.Revert();
			object result = this.Original.Invoke(instance ?? this.Instance, args);
			this.Override();
			return result;
		}
	}
}
