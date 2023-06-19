using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000020 RID: 32
	[Component]
	public class MainThreadDispatcherComponent : MonoBehaviour
	{
		// Token: 0x060000FE RID: 254 RVA: 0x000087D0 File Offset: 0x000069D0
		public void Update()
		{
			Queue<Action> methodQueue = MainThreadDispatcherComponent.MethodQueue;
			lock (methodQueue)
			{
				while (MainThreadDispatcherComponent.MethodQueue.Count > 0)
				{
					MainThreadDispatcherComponent.MethodQueue.Dequeue()();
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00008828 File Offset: 0x00006A28
		public static void InvokeOnMain(Action a)
		{
			Queue<Action> methodQueue = MainThreadDispatcherComponent.MethodQueue;
			lock (methodQueue)
			{
				MainThreadDispatcherComponent.MethodQueue.Enqueue(a);
			}
		}

		// Token: 0x04000048 RID: 72
		public static readonly Queue<Action> MethodQueue = new Queue<Action>();
	}
}
