using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace ZahidAGA
{
	// Token: 0x0200009B RID: 155
	public static class OverrideUtilities
	{
		// Token: 0x060002D0 RID: 720 RVA: 0x00014358 File Offset: 0x00012558
		public static object CallOriginalFunc(MethodInfo method, object instance = null, params object[] args)
		{
			OverrideManager overrideManager = new OverrideManager();
			if (overrideManager.Overrides.All((KeyValuePair<OverrideAttribute, OverrideWrapper> o) => o.Value.Original != method))
			{
				throw new Exception("The Override specified was not found!");
			}
			return overrideManager.Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == method).Value.CallOriginal(args, instance);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x000143C0 File Offset: 0x000125C0
		public static object CallOriginal(object instance = null, params object[] args)
		{
			OverrideManager overrideManager = new OverrideManager();
			StackTrace stackTrace = new StackTrace(false);
			if (stackTrace.FrameCount < 1)
			{
				throw new Exception("Invalid trace back to the original method! Please provide the methodinfo instead!");
			}
			MethodBase method = stackTrace.GetFrame(1).GetMethod();
			MethodInfo original = null;
			if (!Attribute.IsDefined(method, typeof(OverrideAttribute)))
			{
				method = stackTrace.GetFrame(2).GetMethod();
			}
			OverrideAttribute overrideAttribute = (OverrideAttribute)Attribute.GetCustomAttribute(method, typeof(OverrideAttribute));
			if (overrideAttribute == null)
			{
				throw new Exception("This method can only be called from an overwritten method!");
			}
			if (!overrideAttribute.MethodFound)
			{
				throw new Exception("The original method was never found!");
			}
			original = overrideAttribute.Method;
			if (overrideManager.Overrides.All((KeyValuePair<OverrideAttribute, OverrideWrapper> o) => o.Value.Original != original))
			{
				throw new Exception("The Override specified was not found!");
			}
			return overrideManager.Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == original).Value.CallOriginal(args, instance);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000144C0 File Offset: 0x000126C0
		public static bool EnableOverride(MethodInfo method)
		{
			OverrideWrapper value = new OverrideManager().Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == method).Value;
			return value != null && value.Override();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0001450C File Offset: 0x0001270C
		public static bool DisableOverride(MethodInfo method)
		{
			OverrideWrapper value = new OverrideManager().Overrides.First((KeyValuePair<OverrideAttribute, OverrideWrapper> a) => a.Value.Original == method).Value;
			return value != null && value.Revert();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00014558 File Offset: 0x00012758
		public unsafe static bool OverrideFunction(IntPtr ptrOriginal, IntPtr ptrModified)
		{
			bool result;
			try
			{
				int size = IntPtr.Size;
				if (size != 4)
				{
					if (size != 8)
					{
						return false;
					}
					byte* ptr = (byte*)ptrOriginal.ToPointer();
					*ptr = 72;
					ptr[1] = 184;
					*(long*)(ptr + 2) = ptrModified.ToInt64();
					ptr[10] = byte.MaxValue;
					ptr[11] = 224;
				}
				else
				{
					byte* ptr2 = (byte*)ptrOriginal.ToPointer();
					*ptr2 = 104;
					*(int*)(ptr2 + 1) = ptrModified.ToInt32();
					ptr2[5] = 195;
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000145F0 File Offset: 0x000127F0
		public unsafe static bool RevertOverride(OverrideUtilities.OffsetBackup backup)
		{
			bool result;
			try
			{
				byte* ptr = (byte*)backup.Method.ToPointer();
				*ptr = backup.A;
				ptr[1] = backup.B;
				ptr[10] = backup.C;
				ptr[11] = backup.D;
				ptr[12] = backup.E;
				if (IntPtr.Size == 4)
				{
					*(int*)(ptr + 1) = (int)backup.F32;
					ptr[5] = backup.G;
				}
				else
				{
					*(long*)(ptr + 2) = (long)backup.F64;
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0200009C RID: 156
		public class OffsetBackup
		{
			// Token: 0x060002D6 RID: 726 RVA: 0x00014680 File Offset: 0x00012880
			public unsafe OffsetBackup(IntPtr method)
			{
				this.Method = method;
				byte* ptr = (byte*)method.ToPointer();
				this.A = *ptr;
				this.B = ptr[1];
				this.C = ptr[10];
				this.D = ptr[11];
				this.E = ptr[12];
				if (IntPtr.Size == 4)
				{
					this.F32 = *(uint*)(ptr + 1);
					this.G = ptr[5];
					return;
				}
				this.F64 = (ulong)(*(long*)(ptr + 2));
			}

			// Token: 0x040002C4 RID: 708
			public IntPtr Method;

			// Token: 0x040002C5 RID: 709
			public byte A;

			// Token: 0x040002C6 RID: 710
			public byte B;

			// Token: 0x040002C7 RID: 711
			public byte C;

			// Token: 0x040002C8 RID: 712
			public byte D;

			// Token: 0x040002C9 RID: 713
			public byte E;

			// Token: 0x040002CA RID: 714
			public byte G;

			// Token: 0x040002CB RID: 715
			public ulong F64;

			// Token: 0x040002CC RID: 716
			public uint F32;
		}
	}
}
