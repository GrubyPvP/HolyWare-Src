using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000029 RID: 41
	[Component]
	public class SpectatorComponent : MonoBehaviour
	{
		// Token: 0x06000144 RID: 324 RVA: 0x00009FBC File Offset: 0x000081BC
		public void FixedUpdate()
		{
			if (DrawUtilities.ShouldRun())
			{
				if (MiscOptions.SpectatedPlayer != null && !G.BeingSpied)
				{
					OptimizationVariables.MainPlayer.look.isOrbiting = true;
					OptimizationVariables.MainPlayer.look.orbitPosition = MiscOptions.SpectatedPlayer.transform.position - OptimizationVariables.MainPlayer.transform.position;
					OptimizationVariables.MainPlayer.look.orbitPosition += new Vector3(0f, 3f, 0f);
					return;
				}
				OptimizationVariables.MainPlayer.look.isOrbiting = MiscOptions.Freecam;
			}
		}
	}
}
