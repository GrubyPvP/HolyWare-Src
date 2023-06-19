using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000094 RID: 148
	public class OverrideHelper
	{
		// Token: 0x060002B7 RID: 695
		[DllImport("mono.dll", CallingConvention = CallingConvention.FastCall)]
		private static extern IntPtr mono_domain_get();

		// Token: 0x060002B8 RID: 696
		[DllImport("mono.dll", CallingConvention = CallingConvention.FastCall)]
		private static extern IntPtr mono_method_get_header(IntPtr method);

		// Token: 0x060002B9 RID: 697 RVA: 0x00013440 File Offset: 0x00011640
		public static void RedirectCalls(MethodInfo from, MethodInfo to)
		{
			IntPtr functionPointer = from.MethodHandle.GetFunctionPointer();
			IntPtr functionPointer2 = to.MethodHandle.GetFunctionPointer();
			OverrideHelper.PatchJumpTo(functionPointer, functionPointer2);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00013470 File Offset: 0x00011670
		private unsafe static void RedirectCall(MethodInfo from, MethodInfo to)
		{
			IntPtr value = from.MethodHandle.Value;
			IntPtr value2 = to.MethodHandle.Value;
			from.MethodHandle.GetFunctionPointer();
			to.MethodHandle.GetFunctionPointer();
			byte* ptr = (byte*)OverrideHelper.mono_domain_get().ToPointer() + 232;
			long** ptr2 = *(IntPtr*)((byte*)ptr + 32);
			uint num = *(uint*)((byte*)ptr + 24);
			void* ptr3 = null;
			void* ptr4 = null;
			long num2 = value.ToInt64();
			uint num3 = (uint)num2 >> 3;
			for (long* ptr5 = *(IntPtr*)(ptr2 + (ulong)(num3 % num) * (ulong)((long)sizeof(long*)) / (ulong)sizeof(long*)); ptr5 != null; ptr5 = *(IntPtr*)(ptr5 + 1))
			{
				if (num2 == *ptr5)
				{
					ptr3 = (void*)ptr5;
					break;
				}
			}
			long num4 = value2.ToInt64();
			uint num5 = (uint)num4 >> 3;
			for (long* ptr6 = *(IntPtr*)(ptr2 + (ulong)(num5 % num) * (ulong)((long)sizeof(long*)) / (ulong)sizeof(long*)); ptr6 != null; ptr6 = *(IntPtr*)(ptr6 + 1))
			{
				if (num4 == *ptr6)
				{
					ptr4 = (void*)ptr6;
					break;
				}
			}
			if (ptr3 == null || ptr4 == null)
			{
				Debug.Log("Could not find methods");
				return;
			}
			ulong* ptr7 = (ulong*)ptr3;
			ulong* ptr8 = (ulong*)ptr4;
			ptr7[2] = ptr8[2];
			ptr7[3] = ptr8[3];
		}

		// Token: 0x060002BB RID: 699 RVA: 0x000135A4 File Offset: 0x000117A4
		private unsafe static void PatchJumpTo(IntPtr site, IntPtr target)
		{
			byte* ptr = (byte*)site.ToPointer();
			*ptr = 73;
			ptr[1] = 187;
			*(long*)(ptr + 2) = target.ToInt64();
			ptr[10] = 65;
			ptr[11] = byte.MaxValue;
			ptr[12] = 227;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000135EC File Offset: 0x000117EC
		private unsafe static void RedirectCallIL(MethodInfo from, MethodInfo to)
		{
			IntPtr value = from.MethodHandle.Value;
			IntPtr value2 = to.MethodHandle.Value;
			OverrideHelper.mono_method_get_header(value2);
			byte* ptr = (byte*)value.ToPointer();
			byte* ptr2 = (byte*)value2.ToPointer();
			*(IntPtr*)(ptr + 40) = *(IntPtr*)(ptr2 + 40);
		}
	}
}
