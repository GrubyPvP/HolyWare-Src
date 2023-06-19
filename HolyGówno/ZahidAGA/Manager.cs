using System;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000012 RID: 18
	public class Manager : MonoBehaviour
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00008558 File Offset: 0x00006758
		private void Start()
		{
			T.DrawMaterial = new Material(Shader.Find("Hidden/Internal-Colored"))
			{
				hideFlags = 61
			};
			T.DrawMaterial.SetInt("_SrcBlend", 5);
			T.DrawMaterial.SetInt("_DstBlend", 10);
			T.DrawMaterial.SetInt("_Cull", 0);
			T.DrawMaterial.SetInt("_ZWrite", 0);
			GraphicsSettings.outlineQuality = 4;
			AssetUtilities.GetAssets();
			MenuComponent.SetGUIColors();
			ConfigManager.Init();
			AttributeManager.Init();
		}
	}
}
