using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000021 RID: 33
	[Component]
	public class MirrorCameraComponent : MonoBehaviour
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00002DB2 File Offset: 0x00000FB2
		[OnSpy]
		public static void Disable()
		{
			MirrorCameraComponent.WasEnabled = MirrorCameraOptions.Enabled;
			MirrorCameraOptions.Enabled = false;
			Object.Destroy(MirrorCameraComponent.cam_obj);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002DCE File Offset: 0x00000FCE
		[OffSpy]
		public static void Enable()
		{
			MirrorCameraOptions.Enabled = MirrorCameraComponent.WasEnabled;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00002DDA File Offset: 0x00000FDA
		public void Update()
		{
			if (MirrorCameraComponent.cam_obj && MirrorCameraComponent.subCam)
			{
				if (MirrorCameraOptions.Enabled)
				{
					MirrorCameraComponent.subCam.enabled = true;
					return;
				}
				MirrorCameraComponent.subCam.enabled = false;
			}
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0000886C File Offset: 0x00006A6C
		public void OnGUI()
		{
			if (MirrorCameraOptions.Enabled)
			{
				GUI.color = new Color(1f, 1f, 1f, 0f);
				MirrorCameraComponent.viewport = GUILayout.Window(99, MirrorCameraComponent.viewport, new GUI.WindowFunction(this.DoMenu), "Mirror Camera", new GUILayoutOption[0]);
				GUI.color = Color.white;
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000088D0 File Offset: 0x00006AD0
		public void DoMenu(int windowID)
		{
			if (MirrorCameraComponent.cam_obj == null || MirrorCameraComponent.subCam == null)
			{
				MirrorCameraComponent.cam_obj = new GameObject();
				if (MirrorCameraComponent.subCam != null)
				{
					Object.Destroy(MirrorCameraComponent.subCam);
				}
				MirrorCameraComponent.subCam = MirrorCameraComponent.cam_obj.AddComponent<Camera>();
				MirrorCameraComponent.subCam.CopyFrom(OptimizationVariables.MainCam);
				MirrorCameraComponent.cam_obj.transform.position = OptimizationVariables.MainCam.gameObject.transform.position;
				MirrorCameraComponent.cam_obj.transform.rotation = OptimizationVariables.MainCam.gameObject.transform.rotation;
				MirrorCameraComponent.cam_obj.transform.Rotate(0f, 180f, 0f);
				MirrorCameraComponent.subCam.transform.SetParent(OptimizationVariables.MainCam.transform, true);
				MirrorCameraComponent.subCam.enabled = true;
				MirrorCameraComponent.subCam.rect = new Rect(0.6f, 0.6f, 0.4f, 0.4f);
				MirrorCameraComponent.subCam.depth = 99f;
				Object.DontDestroyOnLoad(MirrorCameraComponent.cam_obj);
			}
			float num = MirrorCameraComponent.viewport.x / (float)Screen.width;
			float num2 = (MirrorCameraComponent.viewport.y + 25f) / (float)Screen.height;
			float num3 = MirrorCameraComponent.viewport.width / (float)Screen.width;
			float num4 = MirrorCameraComponent.viewport.height / (float)Screen.height;
			num2 = 1f - num2;
			num2 -= num4;
			MirrorCameraComponent.subCam.rect = new Rect(num, num2, num3, num4);
			Drawing.DrawRect(new Rect(0f, 0f, MirrorCameraComponent.viewport.width, 20f), new Color32(44, 44, 44, byte.MaxValue), null);
			Drawing.DrawRect(new Rect(0f, 20f, MirrorCameraComponent.viewport.width, 5f), new Color32(34, 34, 34, byte.MaxValue), null);
			GUILayout.Space(-19f);
			GUI.DragWindow();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00008AF0 File Offset: 0x00006CF0
		public static void FixCam()
		{
			if (MirrorCameraComponent.cam_obj != null && MirrorCameraComponent.subCam != null)
			{
				MirrorCameraComponent.cam_obj.transform.position = OptimizationVariables.MainCam.gameObject.transform.position;
				MirrorCameraComponent.cam_obj.transform.rotation = OptimizationVariables.MainCam.gameObject.transform.rotation;
				MirrorCameraComponent.cam_obj.transform.Rotate(0f, 180f, 0f);
				MirrorCameraComponent.subCam.transform.SetParent(OptimizationVariables.MainCam.transform, true);
				MirrorCameraComponent.subCam.depth = 99f;
				MirrorCameraComponent.subCam.enabled = true;
			}
		}

		// Token: 0x04000049 RID: 73
		public static Rect viewport = new Rect(1075f, 10f, (float)(Screen.width / 4), (float)(Screen.height / 4));

		// Token: 0x0400004A RID: 74
		public static GameObject cam_obj;

		// Token: 0x0400004B RID: 75
		public static Camera subCam;

		// Token: 0x0400004C RID: 76
		public static bool WasEnabled;
	}
}
