using System;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x020000C7 RID: 199
	public class Skins2
	{
		// Token: 0x06000351 RID: 849 RVA: 0x0001806C File Offset: 0x0001626C
		public static void Tab()
		{
			GUILayout.BeginArea(new Rect(300f, 0f, 940f, 40f));
			Skins2.Select = (SkinType)GUI.Toolbar(new Rect(20f, 10f, 670f, 40f), (int)Skins2.Select, Main.buttons7.ToArray(), "TabBtn");
			GUILayout.EndArea();
			Rect rect = new Rect(340f, 70f, 650f, 550f);
			GUIStyle guistyle = "box";
			GUILayout.BeginArea(rect, string.Format("<size=15>{0}</size>", Skins2.Select), guistyle);
			switch (Skins2.Select)
			{
			case SkinType.Weapons:
				SkinsUtilities.DrawSkins(SkinOptions.SkinWeapons);
				break;
			case SkinType.Shirts:
				SkinsUtilities.DrawSkins(SkinOptions.SkinClothesShirts);
				break;
			case SkinType.Pants:
				SkinsUtilities.DrawSkins(SkinOptions.SkinClothesPants);
				break;
			case SkinType.Backpacks:
				SkinsUtilities.DrawSkins(SkinOptions.SkinClothesBackpack);
				break;
			case SkinType.Vests:
				SkinsUtilities.DrawSkins(SkinOptions.SkinClothesVest);
				break;
			case SkinType.Hats:
				SkinsUtilities.DrawSkins(SkinOptions.SkinClothesHats);
				break;
			case SkinType.Masks:
				SkinsUtilities.DrawSkins(SkinOptions.SkinClothesMask);
				break;
			case SkinType.Glasses:
				SkinsUtilities.DrawSkins(SkinOptions.SkinClothesGlasses);
				break;
			}
			GUILayout.EndArea();
		}

		// Token: 0x040003AD RID: 941
		public static string SelectedColorIdentifier = "";

		// Token: 0x040003AE RID: 942
		private static Vector2 scrollPosition1 = new Vector2(0f, 0f);

		// Token: 0x040003AF RID: 943
		public static SkinType Select = SkinType.None;

		// Token: 0x040003B0 RID: 944
		private static Vector2 scrollPosition2 = new Vector2(0f, 0f);

		// Token: 0x040003B1 RID: 945
		private static Vector2 scrollPosition3 = new Vector2(0f, 0f);
	}
}
