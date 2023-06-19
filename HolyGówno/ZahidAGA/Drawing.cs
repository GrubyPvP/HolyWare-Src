using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200002E RID: 46
	public class Drawing
	{
		// Token: 0x0600015D RID: 349 RVA: 0x00003203 File Offset: 0x00001403
		public static void DrawRect(Rect position, Color color, GUIContent content = null)
		{
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUI.Box(position, content ?? GUIContent.none, Drawing.textureStyle);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000322A File Offset: 0x0000142A
		public static void LayoutBox(Color color, GUIContent content = null)
		{
			Color backgroundColor = GUI.backgroundColor;
			GUI.backgroundColor = color;
			GUILayout.Box(content ?? GUIContent.none, Drawing.textureStyle, new GUILayoutOption[0]);
			GUI.backgroundColor = backgroundColor;
		}

		// Token: 0x0400008D RID: 141
		public static Texture2D backgroundTexture = Texture2D.whiteTexture;

		// Token: 0x0400008E RID: 142
		public static GUIStyle textureStyle = new GUIStyle
		{
			normal = new GUIStyleState
			{
				background = Drawing.backgroundTexture
			}
		};
	}
}
