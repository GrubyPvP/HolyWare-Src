using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000C8 RID: 200
	public class T
	{
		// Token: 0x06000354 RID: 852 RVA: 0x00004475 File Offset: 0x00002675
		public static void DrawColorLayout(Color color, GUILayoutOption[] options = null)
		{
			GUI.skin = AssetUtilities.Skin;
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUILayout.Button(" ", T.textureStyle, options);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x06000355 RID: 853
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool GetCurrentHwProfile(IntPtr fProfile);

		// Token: 0x06000356 RID: 854 RVA: 0x0000BC84 File Offset: 0x00009E84
		public static SteamPlayer GetSteamPlayer(Player player)
		{
			foreach (SteamPlayer steamPlayer in Provider.clients)
			{
				if (steamPlayer.player == player)
				{
					return steamPlayer;
				}
			}
			return null;
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00018208 File Offset: 0x00016408
		public static bool InScreenView(Vector3 scrnpt)
		{
			return scrnpt.z > 0f && scrnpt.x > 0f && scrnpt.x < 1f && scrnpt.y > 0f && scrnpt.y < 1f;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x000040B1 File Offset: 0x000022B1
		public static float GetDistance(Vector3 endpos)
		{
			return (float)Math.Round((double)Vector3.Distance(Player.player.look.aim.position, endpos));
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0001825C File Offset: 0x0001645C
		public static bool VisibleFromCamera(Vector3 pos)
		{
			Vector3 normalized = (pos - MainCamera.instance.transform.position).normalized;
			RaycastHit raycastHit;
			Physics.Raycast(MainCamera.instance.transform.position, normalized, ref raycastHit, float.PositiveInfinity, RayMasks.DAMAGE_CLIENT);
			return DamageTool.getPlayer(raycastHit.transform);
		}

		// Token: 0x0600035A RID: 858 RVA: 0x000182BC File Offset: 0x000164BC
		public static void AimAt(Vector3 pos)
		{
			Player.player.transform.LookAt(pos);
			Player.player.transform.eulerAngles = new Vector3(0f, Player.player.transform.rotation.eulerAngles.y, 0f);
			Camera.main.transform.LookAt(pos);
			float num = Camera.main.transform.localRotation.eulerAngles.x;
			if (num <= 90f && num <= 270f)
			{
				num = Camera.main.transform.localRotation.eulerAngles.x + 90f;
			}
			else if (num >= 270f && num <= 360f)
			{
				num = Camera.main.transform.localRotation.eulerAngles.x - 270f;
			}
			Player.player.look.GetType().GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.look, num);
			Player.player.look.GetType().GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.look, Player.player.transform.rotation.eulerAngles.y);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00018424 File Offset: 0x00016624
		public static void AddNotification(string text)
		{
			NotificationWindow notificationWindow = new NotificationWindow();
			notificationWindow.info = text;
			T.Notifications.Add(notificationWindow);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x000044A2 File Offset: 0x000026A2
		public static IEnumerator Notify(string message, Color color, float displayTime)
		{
			float started = Time.realtimeSinceStartup;
			do
			{
				yield return new WaitForEndOfFrame();
				PlayerUI.hint(null, 98, message, color, Array.Empty<object>());
			}
			while (Time.realtimeSinceStartup - started <= displayTime);
			yield break;
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0001844C File Offset: 0x0001664C
		public static void DrawSnapline(Vector3 worldpos, Color color)
		{
			Vector3 vector = OptimizationVariables.MainCam.WorldToScreenPoint(worldpos);
			vector.y = (float)Screen.height - vector.y;
			GL.PushMatrix();
			GL.Begin(1);
			T.DrawMaterial.SetPass(0);
			GL.Color(color);
			GL.Vertex3((float)(Screen.width / 2), (float)Screen.height, 0f);
			GL.Vertex3(vector.x, vector.y, 0f);
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000184D0 File Offset: 0x000166D0
		public static void DrawESPLabel(Vector3 worldpos, Color textcolor, Color outlinecolor, string text, string outlinetext = null)
		{
			GUIContent guicontent = new GUIContent(text);
			if (outlinetext == null)
			{
				outlinetext = text;
			}
			GUIContent guicontent2 = new GUIContent(outlinetext);
			GUIStyle label = GUI.skin.label;
			label.alignment = 4;
			Vector2 vector = label.CalcSize(guicontent);
			Vector3 vector2 = OptimizationVariables.MainCam.WorldToScreenPoint(worldpos);
			vector2.y = (float)Screen.height - vector2.y;
			if (vector2.z >= 0f)
			{
				GUI.color = Color.black;
				GUI.Label(new Rect(vector2.x - vector.x / 2f + 1f, vector2.y + 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f + 1f, vector2.y - 1f, vector.x, vector.y), guicontent2);
				GUI.Label(new Rect(vector2.x - vector.x / 2f - 1f, vector2.y + 1f, vector.x, vector.y), guicontent2);
				GUI.color = textcolor;
				GUI.Label(new Rect(vector2.x - vector.x / 2f, vector2.y, vector.x, vector.y), guicontent);
				GUI.color = Main.GUIColor;
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x00018678 File Offset: 0x00016878
		public static Vector3 WorldToScreen(Vector3 worldpos)
		{
			Vector3 vector = OptimizationVariables.MainCam.WorldToScreenPoint(worldpos);
			vector.y = (float)Screen.height - vector.y;
			return new Vector3(vector.x, vector.y);
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000186B8 File Offset: 0x000168B8
		public static void DrawOutlineLabel(Vector2 rect, Color textcolor, Color outlinecolor, string text, string outlinetext = null)
		{
			GUIContent guicontent = new GUIContent(text);
			if (outlinetext == null)
			{
				outlinetext = text;
			}
			GUIContent guicontent2 = new GUIContent(outlinetext);
			Vector2 vector = GUI.skin.label.CalcSize(guicontent);
			GUI.color = Color.black;
			GUI.Label(new Rect(rect.x + 1f, rect.y + 1f, vector.x, vector.y), guicontent2);
			GUI.Label(new Rect(rect.x - 1f, rect.y - 1f, vector.x, vector.y), guicontent2);
			GUI.Label(new Rect(rect.x + 1f, rect.y - 1f, vector.x, vector.y), guicontent2);
			GUI.Label(new Rect(rect.x - 1f, rect.y + 1f, vector.x, vector.y), guicontent2);
			GUI.color = textcolor;
			GUI.Label(new Rect(rect.x, rect.y, vector.x, vector.y), guicontent);
			GUI.color = Main.GUIColor;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x000187E8 File Offset: 0x000169E8
		public static void Draw3DBox(Bounds b, Color color)
		{
			Vector3[] array = new Vector3[]
			{
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z)),
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)),
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)),
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)),
				OptimizationVariables.MainCam.WorldToScreenPoint(new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z))
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i].y = (float)Screen.height - array[i].y;
			}
			GL.PushMatrix();
			GL.Begin(1);
			T.DrawMaterial.SetPass(0);
			GL.End();
			GL.PopMatrix();
			GL.PushMatrix();
			GL.Begin(1);
			T.DrawMaterial.SetPass(0);
			GL.Color(color);
			GL.Vertex3(array[0].x, array[0].y, 0f);
			GL.Vertex3(array[1].x, array[1].y, 0f);
			GL.Vertex3(array[1].x, array[1].y, 0f);
			GL.Vertex3(array[5].x, array[5].y, 0f);
			GL.Vertex3(array[5].x, array[5].y, 0f);
			GL.Vertex3(array[4].x, array[4].y, 0f);
			GL.Vertex3(array[4].x, array[4].y, 0f);
			GL.Vertex3(array[0].x, array[0].y, 0f);
			GL.Vertex3(array[2].x, array[2].y, 0f);
			GL.Vertex3(array[3].x, array[3].y, 0f);
			GL.Vertex3(array[3].x, array[3].y, 0f);
			GL.Vertex3(array[7].x, array[7].y, 0f);
			GL.Vertex3(array[7].x, array[7].y, 0f);
			GL.Vertex3(array[6].x, array[6].y, 0f);
			GL.Vertex3(array[6].x, array[6].y, 0f);
			GL.Vertex3(array[2].x, array[2].y, 0f);
			GL.Vertex3(array[2].x, array[2].y, 0f);
			GL.Vertex3(array[0].x, array[0].y, 0f);
			GL.Vertex3(array[3].x, array[3].y, 0f);
			GL.Vertex3(array[1].x, array[1].y, 0f);
			GL.Vertex3(array[7].x, array[7].y, 0f);
			GL.Vertex3(array[5].x, array[5].y, 0f);
			GL.Vertex3(array[6].x, array[6].y, 0f);
			GL.Vertex3(array[4].x, array[4].y, 0f);
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x06000362 RID: 866 RVA: 0x000044BF File Offset: 0x000026BF
		public static void DrawColor(Rect position, Color color)
		{
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUI.Box(position, GUIContent.none, T.textureStyle);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00018EAC File Offset: 0x000170AC
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
					result = transform.position + new Vector3(0f, 0.4f, 0f);
					break;
				}
			}
			return result;
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00018F20 File Offset: 0x00017120
		public static void OverrideMethod(Type defaultClass, Type overrideClass, string method, BindingFlags bindingflag, BindingFlags overrideflag)
		{
			string name = "OV_" + method;
			MemberInfo[] member = defaultClass.GetMember(method, MemberTypes.Method, bindingflag);
			if (member == null || member.Length == 0)
			{
				return;
			}
			OverrideHelper.RedirectCalls((MethodInfo)member[0], overrideClass.GetMethod(name, overrideflag));
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00018F64 File Offset: 0x00017164
		public static void OverrideMethod(Type defaultClass, Type overrideClass, string method, BindingFlags bindingflag, BindingFlags overrideflag, Type[] args)
		{
			string name = "OV_" + method;
			MethodInfo method2 = defaultClass.GetMethod(method, bindingflag, null, args, null);
			if (method2 == null)
			{
				return;
			}
			OverrideHelper.RedirectCalls(method2, overrideClass.GetMethod(name, overrideflag));
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000349C File Offset: 0x0000169C
		public static float? GetGunDistance()
		{
			Player player = Player.player;
			object obj;
			if (player == null)
			{
				obj = null;
			}
			else
			{
				PlayerEquipment equipment = player.equipment;
				obj = ((equipment != null) ? equipment.asset : null);
			}
			ItemGunAsset itemGunAsset = obj as ItemGunAsset;
			return new float?((itemGunAsset != null) ? itemGunAsset.range : 15.5f);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00018FA4 File Offset: 0x000171A4
		public static float GetDamage(Player player, ELimb limb)
		{
			ItemGunAsset itemGunAsset = Player.player.equipment.asset as ItemGunAsset;
			return itemGunAsset.objectDamage * itemGunAsset.playerDamageMultiplier.damage * DamageTool.getPlayerArmor(limb, player);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00018FE0 File Offset: 0x000171E0
		public static ELimb GetLimb(TargetLimb limb)
		{
			if (limb == TargetLimb.GLOBAL)
			{
				return 13;
			}
			if (limb == TargetLimb.RANDOM)
			{
				ELimb[] array = (ELimb[])Enum.GetValues(typeof(ELimb));
				return array[T.Random.Next(0, array.Length)];
			}
			return (ELimb)Enum.Parse(typeof(TargetLimb), Enum.GetName(typeof(TargetLimb), limb));
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00013070 File Offset: 0x00011270
		public static InteractableItem GetNearestItem(int? pixelfov = null)
		{
			InteractableItem interactableItem = null;
			foreach (Collider collider in Physics.OverlapSphere(Player.player.transform.position, 19f, 8192))
			{
				if (!(collider == null) && !(collider.GetComponent<InteractableItem>() == null) && collider.GetComponent<InteractableItem>().asset != null)
				{
					InteractableItem component = collider.GetComponent<InteractableItem>();
					Vector3 vector = OptimizationVariables.MainCam.WorldToScreenPoint(component.transform.position);
					if (vector.z > 0f)
					{
						int num = (int)Vector2.Distance(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(vector.x, vector.y));
						if (pixelfov != null)
						{
							int num2 = num;
							int? num3 = pixelfov;
							if (num2 > num3.GetValueOrDefault() & num3 != null)
							{
								goto IL_15F;
							}
						}
						if (interactableItem == null)
						{
							interactableItem = component;
						}
						else
						{
							Vector3 vector2 = OptimizationVariables.MainCam.WorldToScreenPoint(interactableItem.transform.position);
							int num4 = (int)Vector2.Distance(new Vector2((float)(Screen.width / 2), (float)(Screen.height / 2)), new Vector2(vector2.x, vector2.y));
							if (pixelfov != null)
							{
								int num5 = num4;
								int? num3 = pixelfov;
								if (num5 > num3.GetValueOrDefault() & num3 != null)
								{
									interactableItem = null;
								}
							}
							if (num < num4)
							{
								interactableItem = component;
							}
						}
					}
				}
				IL_15F:;
			}
			return interactableItem;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x00012A04 File Offset: 0x00010C04
		public static void DrawCircle(Color Col, Vector2 Center, float Radius)
		{
			GL.PushMatrix();
			T.DrawMaterial.SetPass(0);
			GL.Begin(1);
			GL.Color(Col);
			for (float num = 0f; num < 6.2831855f; num += 0.05f)
			{
				GL.Vertex(new Vector3(Mathf.Cos(num) * Radius + Center.x, Mathf.Sin(num) * Radius + Center.y));
				GL.Vertex(new Vector3(Mathf.Cos(num + 0.05f) * Radius + Center.x, Mathf.Sin(num + 0.05f) * Radius + Center.y));
			}
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x040003B2 RID: 946
		public static List<NotificationWindow> Notifications = new List<NotificationWindow>();

		// Token: 0x040003B3 RID: 947
		public static Vector2 DropdownCursorPos;

		// Token: 0x040003B4 RID: 948
		public static SteamPlayer[] ConnectedPlayers;

		// Token: 0x040003B5 RID: 949
		public static float LastMovementCheck;

		// Token: 0x040003B6 RID: 950
		public static Material DrawMaterial;

		// Token: 0x040003B7 RID: 951
		private static readonly Texture2D backgroundTexture = Texture2D.whiteTexture;

		// Token: 0x040003B8 RID: 952
		private static readonly GUIStyle textureStyle = new GUIStyle
		{
			normal = new GUIStyleState
			{
				background = T.backgroundTexture
			}
		};

		// Token: 0x040003B9 RID: 953
		public static Random Random = new Random();

		// Token: 0x020000C9 RID: 201
		[StructLayout(LayoutKind.Sequential)]
		private class HWProfile
		{
			// Token: 0x040003BA RID: 954
			public int dwDockInfo;

			// Token: 0x040003BB RID: 955
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 39)]
			public string szHwProfileGuid;

			// Token: 0x040003BC RID: 956
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szHwProfileName;
		}
	}
}
