using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200001C RID: 28
	[Component]
	public class AimbotComponent : MonoBehaviour
	{
		// Token: 0x060000F3 RID: 243 RVA: 0x00002D07 File Offset: 0x00000F07
		public void Start()
		{
			CoroutineComponent.LockCoroutine = base.StartCoroutine(AimbotCoroutines.SetLockedObject());
			CoroutineComponent.AimbotCoroutine = base.StartCoroutine(AimbotCoroutines.AimToObject());
			base.StartCoroutine(RaycastCoroutines.UpdateObjects());
		}
	}
}
