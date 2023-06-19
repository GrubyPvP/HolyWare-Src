using System;
using System.Collections;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000026 RID: 38
	[DisallowMultipleComponent]
	public class RaycastComponent : MonoBehaviour
	{
		// Token: 0x06000134 RID: 308 RVA: 0x000030A5 File Offset: 0x000012A5
		public void Awake()
		{
			base.StartCoroutine(this.RedoSphere());
			base.StartCoroutine(this.CalcSphere());
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000030C1 File Offset: 0x000012C1
		public IEnumerator CalcSphere()
		{
			for (;;)
			{
				yield return new WaitForSeconds(0.1f);
				if (this.Sphere)
				{
					Rigidbody component = base.gameObject.GetComponent<Rigidbody>();
					if (component)
					{
						float num = 1f - Provider.ping * component.velocity.magnitude * 2f;
						this.Sphere.transform.localScale = new Vector3(num, num, num);
					}
				}
			}
			yield break;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000030D0 File Offset: 0x000012D0
		public IEnumerator RedoSphere()
		{
			for (;;)
			{
				Object sphere = this.Sphere;
				this.Sphere = IcoSphere.Create("HitSphere", SphereOptions.SpherePrediction ? 15.5f : SphereOptions.SphereRadius, (float)SphereOptions.RecursionLevel);
				this.Sphere.layer = 24;
				this.Sphere.transform.parent = base.transform;
				this.Sphere.transform.localPosition = Vector3.zero;
				Object.Destroy(sphere);
				yield return new WaitForSeconds(1f);
			}
			yield break;
		}

		// Token: 0x04000079 RID: 121
		public GameObject Sphere;
	}
}
