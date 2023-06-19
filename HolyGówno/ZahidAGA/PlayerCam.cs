using System;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000007 RID: 7
	[Component]
	public class PlayerCam : MonoBehaviour
	{
		// Token: 0x060000A1 RID: 161 RVA: 0x00004DDC File Offset: 0x00002FDC
		public static Vector3 GetLimbPosition(Transform target, string objName)
		{
			Transform[] componentsInChildren = target.transform.GetComponentsInChildren<Transform>();
			Vector3 result = Vector3.zero;
			if (componentsInChildren == null)
			{
				return result;
			}
			foreach (Transform transform in componentsInChildren)
			{
				if (!(transform.name.Trim() != objName))
				{
					result = transform.position + new Vector3(PlayerCam.x, PlayerCam.y, PlayerCam.z);
					break;
				}
			}
			return result;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004E50 File Offset: 0x00003050
		public void Update()
		{
			if (!PlayerCam.cam_obj || !PlayerCam.subCam)
			{
				return;
			}
			if (PlayerCam.BeingSpied)
			{
				PlayerCam.Enabled = false;
			}
			else
			{
				PlayerCam.Enabled = true;
			}
			if (PlayerCam.Enabled)
			{
				PlayerCam.subCam.enabled = true;
				return;
			}
			PlayerCam.subCam.enabled = false;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00004EAC File Offset: 0x000030AC
		private void OnGUI()
		{
			if (PlayerCam.MainCamera == null)
			{
				PlayerCam.MainCamera = Camera.main;
			}
			if (PlayerCam.Enabled && PlayerCam.player != null && Provider.isConnected && !PlayerCam.BeingSpied)
			{
				GUI.color = new Color(1f, 1f, 1f, 0f);
				PlayerCam.viewport = GUI.Window(98, PlayerCam.viewport, new GUI.WindowFunction(this.DoMenu), "Player Cam");
				GUI.color = Color.white;
				if (PlayerCam.IsFullScreen)
				{
					PlayerCam.x = Prefab.Slider(0f, 5f, PlayerCam.x, 100);
					PlayerCam.y = Prefab.Slider(0f, 5f, PlayerCam.y, 100);
					PlayerCam.z = Prefab.Slider(0f, 5f, PlayerCam.z, 100);
					if (GUI.Button(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height - 100), 100f, 50f), ""))
					{
						PlayerCam.IsFullScreen = false;
					}
				}
			}
			if (PlayerCam.player == null || PlayerCam.BeingSpied || (!Provider.isConnected && PlayerCam.subCam != null && PlayerCam.cam_obj != null))
			{
				Object.Destroy(PlayerCam.subCam);
				PlayerCam.subCam = null;
				PlayerCam.cam_obj = null;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00005024 File Offset: 0x00003224
		private void DoMenu(int windowID)
		{
			if (PlayerCam.cam_obj == null || PlayerCam.subCam == null)
			{
				PlayerCam.cam_obj = new GameObject();
				if (PlayerCam.subCam != null)
				{
					Object.Destroy(PlayerCam.subCam);
				}
				PlayerCam.subCam = PlayerCam.cam_obj.AddComponent<Camera>();
				PlayerCam.subCam.CopyFrom(PlayerCam.MainCamera);
				PlayerCam.subCam.enabled = true;
				PlayerCam.subCam.rect = new Rect(0.6f, 0.6f, 0.6f, 0.4f);
				PlayerCam.subCam.depth = 98f;
				Object.DontDestroyOnLoad(PlayerCam.cam_obj);
			}
			PlayerCam.subCam.transform.SetPositionAndRotation(PlayerCam.GetLimbPosition(PlayerCam.player.transform, "Skull") + new Vector3(0f, 0.2f, 0f) + PlayerCam.player.look.aim.forward / 1.6f, PlayerCam.player.look.aim.rotation);
			float num = PlayerCam.viewport.x / (float)Screen.width;
			float num2 = (PlayerCam.viewport.y + 40f) / (float)Screen.height;
			float num3 = PlayerCam.viewport.width / (float)Screen.width;
			float num4 = PlayerCam.viewport.height / (float)Screen.height;
			if (PlayerCam.IsFullScreen)
			{
				num = 0f;
				num2 = 0f;
				num3 = (float)Screen.width;
				num4 = (float)Screen.height;
			}
			num2 = 1f - num2;
			num2 -= num4;
			PlayerCam.subCam.rect = new Rect(num, num2, num3, num4);
			if (!PlayerCam.IsFullScreen)
			{
				GUILayout.Space(-13f);
				GUILayout.BeginHorizontal(Array.Empty<GUILayoutOption>());
				if (GUILayout.Button("", new GUILayoutOption[]
				{
					GUILayout.Height(25f)
				}))
				{
					PlayerCam.IsFullScreen = true;
				}
				GUILayout.TextArea(PlayersTab2.SelectedPlayer.name, new GUILayoutOption[]
				{
					GUILayout.Height(25f)
				});
				GUILayout.EndHorizontal();
			}
			GUI.DragWindow();
		}

		// Token: 0x04000013 RID: 19
		public static Rect viewport = new Rect((float)(Screen.width - Screen.width / 4 - 10), 30f, (float)(Screen.width / 4), (float)(Screen.height / 4));

		// Token: 0x04000014 RID: 20
		public static GameObject cam_obj;

		// Token: 0x04000015 RID: 21
		public static Camera subCam;

		// Token: 0x04000016 RID: 22
		public static Camera MainCamera;

		// Token: 0x04000017 RID: 23
		public static bool WasEnabled;

		// Token: 0x04000018 RID: 24
		public static bool Enabled = true;

		// Token: 0x04000019 RID: 25
		public static Player player = null;

		// Token: 0x0400001A RID: 26
		public static bool IsFullScreen = false;

		// Token: 0x0400001B RID: 27
		public static bool BeingSpied = false;

		// Token: 0x0400001C RID: 28
		public static float x = 0f;

		// Token: 0x0400001D RID: 29
		public static float y = 0.4f;

		// Token: 0x0400001E RID: 30
		public static float z = 0f;
	}
}
