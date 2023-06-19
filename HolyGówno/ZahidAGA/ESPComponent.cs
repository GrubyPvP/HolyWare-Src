using System;
using System.Collections.Generic;
using System.Linq;
using HighlightingSystem;
using SDG.Framework.Foliage;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x0200002C RID: 44
	[Component]
	public class ESPComponent : MonoBehaviour
	{
		// Token: 0x06000150 RID: 336 RVA: 0x0000A390 File Offset: 0x00008590
		[Initializer]
		public static void Initialize()
		{
			for (int i = 0; i < ESPOptions.VisualOptions.Length; i++)
			{
				ESPTarget esptarget = (ESPTarget)i;
				Color32 color = Color.white;
				switch (esptarget)
				{
				case ESPTarget.Player:
					color..ctor(byte.MaxValue, 0, 0, byte.MaxValue);
					break;
				case ESPTarget.Zombie:
					color..ctor(115, byte.MaxValue, 110, byte.MaxValue);
					break;
				case ESPTarget.Item:
					color..ctor(0, byte.MaxValue, 0, byte.MaxValue);
					break;
				case ESPTarget.Sentry:
					color..ctor(220, 10, 10, byte.MaxValue);
					break;
				case ESPTarget.Bed:
					color..ctor(byte.MaxValue, 170, byte.MaxValue, byte.MaxValue);
					break;
				case ESPTarget.Flag:
					color..ctor(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					break;
				case ESPTarget.Vehicle:
					color..ctor(240, 236, 0, byte.MaxValue);
					break;
				case ESPTarget.Storage:
					color..ctor(byte.MaxValue, byte.MaxValue, 90, byte.MaxValue);
					break;
				}
				ColorUtilities.addColor(new ColorVariable(string.Format("_{0}", esptarget), string.Format("", esptarget), color, false));
				ColorUtilities.addColor(new ColorVariable(string.Format("_{0}_Glow", esptarget), string.Format("", esptarget), color, false));
				ColorUtilities.addColor(new ColorVariable("_ESPFriendly", "      ESP Friendly", new Color32(100, 0, byte.MaxValue, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_Admin", "      Admin", new Color32(byte.MaxValue, 0, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_WeaponInfoColor", "", new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_WeaponInfoBorder", "", new Color32(0, 0, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_Coordinates", "", new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_CoordinatesTick", "", new Color32(0, 0, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_VehicleInfoColor", "", new Color32(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_VehicleInfoBorder", "", new Color32(0, 0, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_ShowFOVAim", "", new Color32(0, byte.MaxValue, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_ShowFOV", "", new Color32(byte.MaxValue, 0, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_SelfColor", "      Chams Self", Color.green, false));
				ColorUtilities.addColor(new ColorVariable("_ChamsFriendVisible", "      Chams Friend - Visible", Color.green, false));
				ColorUtilities.addColor(new ColorVariable("_ChamsFriendInvisible", "      Chams Friend - Invisible", Color.blue, false));
				ColorUtilities.addColor(new ColorVariable("_ChamsEnemyVisible", "      Chams Enemy - Visible", new Color32(byte.MaxValue, 165, 0, byte.MaxValue), false));
				ColorUtilities.addColor(new ColorVariable("_ChamsEnemyInvisible", "      Chams Enemy - Invisible", Color.red, false));
				ColorUtilities.addColor(new ColorVariable("_SlientInfoColor", "      Slient - Info", new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_SlientInfoBorder", "      Slient - Info Border", new Color32(0, 0, 0, byte.MaxValue), true));
				ColorUtilities.addColor(new ColorVariable("_SlientCizgiColor", "      Slient - Tracer", new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue), true));
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00003157 File Offset: 0x00001357
		public void Start()
		{
			CoroutineComponent.ESPCoroutine = base.StartCoroutine(ESPCoroutines.UpdateObjectList());
			CoroutineComponent.ChamsCoroutine = base.StartCoroutine(ESPCoroutines.DoChams());
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000A7A8 File Offset: 0x000089A8
		public void Update()
		{
			if (MiscOptions.NoRain)
			{
				LightingManager.DisableWeather();
			}
			if (MiscOptions.NoCloud)
			{
				RenderSettings.skybox.DisableKeyword("WITH_CLOUDS");
			}
			if (MiscOptions.NoGrass)
			{
				FoliageSettings.enabled = true;
				FoliageSettings.drawDistance = 0;
				FoliageSettings.instanceDensity = 0f;
				FoliageSettings.drawFocusDistance = 0;
				FoliageSettings.focusDistance = 0f;
			}
			if (!MiscOptions.NoGrass || G.BeingSpied)
			{
				float focusDistance = (0.3f + GraphicsSettings.NormalizedFarClipDistance * 0.7f) * 2048f;
				FoliageSettings.enabled = true;
				FoliageSettings.drawDistance = 2;
				FoliageSettings.instanceDensity = 0.25f;
				FoliageSettings.drawFocusDistance = 1;
				FoliageSettings.focusDistance = focusDistance;
			}
			if (ESPOptions.AddFriend)
			{
				foreach (SteamPlayer steamPlayer in Provider.clients)
				{
					if (Input.GetKeyDown(325))
					{
						if (FriendUtilities.IsFriendly(steamPlayer.player))
						{
							Vector3 position = OptimizationVariables.MainPlayer.look.aim.position;
							Vector3 forward = OptimizationVariables.MainPlayer.look.aim.forward;
							Vector3 position2 = steamPlayer.player.transform.position;
							if (VectorUtilities.GetAngleDelta(position, forward, position2) < 10.0)
							{
								FriendUtilities.RemoveFriend(steamPlayer.player);
								T.AddNotification("Remove Friednes - " + steamPlayer.player.character.name);
								break;
							}
						}
						else
						{
							Vector3 position3 = OptimizationVariables.MainPlayer.look.aim.position;
							Vector3 forward2 = OptimizationVariables.MainPlayer.look.aim.forward;
							Vector3 position4 = steamPlayer.player.transform.position;
							if (VectorUtilities.GetAngleDelta(position3, forward2, position4) < 10.0)
							{
								FriendUtilities.AddFriend(steamPlayer.player);
								T.AddNotification("Added Friendes - " + steamPlayer.player.character.name);
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000A9BC File Offset: 0x00008BBC
		public void OnGUI()
		{
			if (Event.current.type != 7 || !ESPOptions.Enabled || G.BeingSpied)
			{
				return;
			}
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			GUI.depth = 1;
			if (ESPComponent.MainCamera == null)
			{
				ESPComponent.MainCamera = OptimizationVariables.MainCam;
			}
			Vector3 position = OptimizationVariables.MainPlayer.transform.position;
			Vector3 position2 = OptimizationVariables.MainPlayer.look.aim.position;
			Vector3 forward = OptimizationVariables.MainPlayer.look.aim.forward;
			for (int i = 0; i < ESPVariables.Objects.Count; i++)
			{
				ESPObject espobject = ESPVariables.Objects[i];
				ESPVisual espvisual = ESPOptions.VisualOptions[(int)espobject.Target];
				GameObject gobject = espobject.GObject;
				if (!espvisual.Enabled)
				{
					Highlighter component = gobject.GetComponent<Highlighter>();
					if (component != null)
					{
						component.ConstantOffImmediate();
					}
				}
				else if (espobject.Target != ESPTarget.Item || !ESPOptions.FilterItems || ItemUtilities.Whitelisted(((InteractableItem)espobject.Object).asset, ItemOptions.ItemESPOptions))
				{
					Color c = ColorUtilities.getColor(string.Format("_{0}", espobject.Target));
					LabelLocation location = espvisual.Location;
					if (!(gobject == null))
					{
						Vector3 position3 = gobject.transform.position;
						double distance = VectorUtilities.GetDistance(position3, position);
						if (distance >= 0.5 && (distance <= (double)espvisual.Distance || espvisual.InfiniteDistance))
						{
							Vector3 vector = ESPComponent.MainCamera.WorldToScreenPoint(position3);
							if (vector.z > 0f)
							{
								Vector3 localScale = gobject.transform.localScale;
								ESPTarget target = espobject.Target;
								Bounds bounds;
								if (target > ESPTarget.Zombie)
								{
									if (target != ESPTarget.Vehicle)
									{
										bounds = gobject.GetComponent<Collider>().bounds;
									}
									else
									{
										bounds = gobject.transform.Find("Model_0").GetComponent<MeshRenderer>().bounds;
										Transform transform = gobject.transform.Find("Model_1");
										if (transform != null)
										{
											bounds.Encapsulate(transform.GetComponent<MeshRenderer>().bounds);
										}
									}
								}
								else
								{
									bounds..ctor(new Vector3(position3.x, position3.y + 1f, position3.z), new Vector3(localScale.x * 2f, localScale.y * 3f, localScale.z * 2f));
								}
								int textSize = DrawUtilities.GetTextSize(espvisual, distance);
								Math.Round(distance);
								string text = string.Format("<size={0}>", textSize);
								string text2 = string.Format("<size={0}>", textSize);
								if (espvisual.ShowDistance)
								{
									if (T.GetDistance(espobject.GObject.transform.position) >= 0f && T.GetDistance(espobject.GObject.transform.position) < 50f)
									{
										text += string.Format("<color=white>[</color><color=red>{0}</color><color=white>]</color> ", T.GetDistance(espobject.GObject.transform.position));
										text2 += string.Format("[{0}] ", T.GetDistance(espobject.GObject.transform.position));
									}
									if (T.GetDistance(espobject.GObject.transform.position) >= 50f && T.GetDistance(espobject.GObject.transform.position) < 300f)
									{
										text += string.Format("<color=white>[</color><color=yellow>{0}</color><color=white>]</color> ", T.GetDistance(espobject.GObject.transform.position));
										text2 += string.Format("[{0}] ", T.GetDistance(espobject.GObject.transform.position));
									}
									if (T.GetDistance(espobject.GObject.transform.position) >= 300f)
									{
										text += string.Format("<color=white>[</color><color=#00FF00>{0}</color><color=white>]</color> ", T.GetDistance(espobject.GObject.transform.position));
										text2 += string.Format("[{0}] ", T.GetDistance(espobject.GObject.transform.position));
									}
								}
								switch (espobject.Target)
								{
								case ESPTarget.Player:
								{
									Player player = (Player)espobject.Object;
									if (player.life.isDead)
									{
										goto IL_10A6;
									}
									if (espvisual.ShowName)
									{
										text = text + ESPComponent.GetSteamPlayer(player).playerID.characterName + "\n";
										text2 = text2 + ESPComponent.GetSteamPlayer(player).playerID.characterName + "\n";
									}
									if (ESPOptions.ShowPlayerWeapon)
									{
										if (ESPOptions.ShowPlayerVehicle)
										{
											text += ((player.equipment.asset != null) ? ("<color=#white>" + player.equipment.asset.itemName + " - </color>") : "<color=#white>No Weapon - </color>");
											text2 += ((player.equipment.asset != null) ? (player.equipment.asset.itemName + " - ") : "No Weapon - ");
										}
										if (!ESPOptions.ShowPlayerVehicle)
										{
											text += ((player.equipment.asset != null) ? ("<color=#white>" + player.equipment.asset.itemName + "</color>") : "<color=#white>No Weapon</color>");
											text2 += ((player.equipment.asset != null) ? (player.equipment.asset.itemName ?? "") : "No Weapon");
										}
									}
									if (ESPOptions.showhotbar)
									{
										for (int j = 0; j < ESPComponent.hotbarImages.Length; j++)
										{
											SleekItemIcon sleekItemIcon = new SleekItemIcon();
											sleekItemIcon.color = new Color(1f, 1f, 1f, 0.5f);
											ESPComponent.hotbarContainer.AddChild(sleekItemIcon);
											sleekItemIcon.isVisible = false;
											ESPComponent.hotbarImages[j] = sleekItemIcon;
										}
									}
									if (ESPOptions.ShowPlayerVehicle)
									{
										text += ((player.movement.getVehicle() != null) ? ("<color=#white>" + player.movement.getVehicle().asset.name + "</color>") : "<color=#white>No Vehicle</color>");
										text2 += ((player.movement.getVehicle() != null) ? (player.movement.getVehicle().asset.name ?? "") : "No Vehicle");
									}
									bounds.size /= 2f;
									bounds.size = new Vector3(bounds.size.x, bounds.size.y * 1.25f, bounds.size.z);
									if (ESPOptions.ArkadaşRengi && FriendUtilities.IsFriendly(player))
									{
										c = Color.cyan;
									}
									if (ESPOptions.AdminRengi && player.channel.owner.isAdmin)
									{
										c = Color.white;
									}
									break;
								}
								case ESPTarget.Zombie:
									if (((Zombie)espobject.Object).isDead)
									{
										goto IL_10A6;
									}
									if (espvisual.ShowName)
									{
										text += "<color=#00f742>Zombie</color>";
									}
									text2 += "Zombie";
									break;
								case ESPTarget.Item:
								{
									InteractableItem interactableItem = (InteractableItem)espobject.Object;
									if (espvisual.ShowName)
									{
										text = text + "<color=#00f742>" + interactableItem.asset.itemName + "</color>";
									}
									text2 += interactableItem.asset.itemName;
									break;
								}
								case ESPTarget.Sentry:
								{
									InteractableSentry interactableSentry = (InteractableSentry)espobject.Object;
									if (espvisual.ShowName)
									{
										text += "<color=#0212eb>Sentry</color>";
										text2 += "Sentry";
									}
									if (ESPOptions.ShowSentryItem)
									{
										text += ESPComponent.SentryName(interactableSentry.displayItem, true);
										text2 += ESPComponent.SentryName(interactableSentry.displayItem, true);
									}
									break;
								}
								case ESPTarget.Bed:
								{
									InteractableBed interactableBed = (InteractableBed)espobject.Object;
									if (espvisual.ShowName)
									{
										text += "<color=#b972cf>Bed</color>";
										text2 += "Bed";
									}
									if (ESPOptions.ShowClaimed)
									{
										if (interactableBed.isClaimed && espvisual.ShowName)
										{
											text += "<color=#00ff00ff> - Claimed</color>";
											text2 += "<color=#00ff00ff> - Claimed</color>";
										}
										if (!interactableBed.isClaimed && espvisual.ShowName)
										{
											text += "<color=#ff0000ff> - No Claimed</color>";
											text2 += "<color=#ff0000ff> - No Claimed</color>";
										}
									}
									if (ESPOptions.ClaimİDBed)
									{
										CSteamID owner = interactableBed.owner;
										if (interactableBed.owner.ToString() == "0")
										{
											text += "\nNull";
											text2 += "\nNull";
										}
										else
										{
											text = text + "\n" + interactableBed.owner.ToString();
											text2 = text2 + "\n" + interactableBed.owner.ToString();
										}
									}
									if (ESPOptions.ClaimNameBed)
									{
										SteamPlayer steamPlayer = null;
										using (List<SteamPlayer>.Enumerator enumerator = Provider.clients.GetEnumerator())
										{
											while (enumerator.MoveNext())
											{
												steamPlayer = enumerator.Current;
											}
										}
										if (steamPlayer.playerID.steamID == interactableBed.owner)
										{
											text = text + "\n" + steamPlayer.player.name;
											text2 = text2 + "\n" + steamPlayer.player.name;
										}
										else
										{
											text += "\nNull";
											text2 += "\nNull";
										}
									}
									break;
								}
								case ESPTarget.Flag:
									if (espvisual.ShowName)
									{
										text += "<color=white>Claim Flag</color>";
									}
									text2 += "Claim Flag";
									break;
								case ESPTarget.Vehicle:
								{
									InteractableVehicle interactableVehicle = (InteractableVehicle)espobject.Object;
									if (interactableVehicle.health == 0 || (ESPOptions.FilterVehicleLocked && interactableVehicle.isLocked))
									{
										goto IL_10A6;
									}
									ushort num;
									ushort num2;
									interactableVehicle.getDisplayFuel(ref num, ref num2);
									float num3 = Mathf.Round(100f * ((float)interactableVehicle.health / (float)interactableVehicle.asset.health));
									float num4 = Mathf.Round(100f * ((float)num / (float)num2));
									if (espvisual.ShowName)
									{
										text = text + "<color=yellow>" + interactableVehicle.asset.name + "</color>";
										text2 += interactableVehicle.asset.name;
									}
									if (ESPOptions.ShowVehicleHealth)
									{
										text = text + "\n" + string.Format("Health: {0}%", num3);
										text2 = text2 + "\n" + string.Format("Health: {0}%", num3);
									}
									if (ESPOptions.ShowVehicleFuel)
									{
										text += string.Format(" - Fuel: {0}%", num4);
										text2 += string.Format(" - Fuel: {0}%", num4);
									}
									if (ESPOptions.ShowVehicleLocked)
									{
										if (interactableVehicle.isLocked && espvisual.ShowName)
										{
											text += "\n<color=#ff0000ff> - LOCKED</color>";
											text2 += "\n- LOCKED";
										}
										if (!interactableVehicle.isLocked && espvisual.ShowName)
										{
											text += "\n<color=#ff0000ff> - Not Locket</color>";
											text2 += "\n - Not Locket";
										}
									}
									if (ESPOptions.ClaimİDCar)
									{
										CSteamID lockedOwner = interactableVehicle.lockedOwner;
										if (interactableVehicle.lockedOwner.ToString() == "0")
										{
											text += "\nNull";
											text2 += "\nNull";
										}
										else
										{
											text = text + "\n" + interactableVehicle.lockedOwner.ToString();
											text2 = text2 + "\n" + interactableVehicle.lockedOwner.ToString();
										}
									}
									if (ESPOptions.ClaimNameCar)
									{
										SteamPlayer steamPlayer2 = null;
										using (List<SteamPlayer>.Enumerator enumerator = Provider.clients.GetEnumerator())
										{
											while (enumerator.MoveNext())
											{
												steamPlayer2 = enumerator.Current;
											}
										}
										if (steamPlayer2.playerID.steamID == interactableVehicle.lockedOwner)
										{
											text = text + "\n" + steamPlayer2.player.name;
											text2 = text2 + "\n" + steamPlayer2.player.name;
										}
										else
										{
											text += "\nNull";
											text2 += "\nNull";
										}
									}
									break;
								}
								case ESPTarget.Storage:
								{
									InteractableStorage interactableStorage = (InteractableStorage)espobject.Object;
									if (espvisual.ShowName)
									{
										text += "<color=#008fb3>Storage</color>";
									}
									text2 += "Storage";
									if (ESPOptions.ClaimİDStorage)
									{
										CSteamID owner2 = interactableStorage.owner;
										if (interactableStorage.owner.ToString() == "0")
										{
											text += "\nNull";
											text2 += "\nNull";
										}
										else
										{
											text = text + "\n" + interactableStorage.owner.ToString();
											text2 = text2 + "\n" + interactableStorage.owner.ToString();
										}
									}
									if (ESPOptions.ClaimNameStorage)
									{
										SteamPlayer steamPlayer3 = null;
										using (List<SteamPlayer>.Enumerator enumerator = Provider.clients.GetEnumerator())
										{
											while (enumerator.MoveNext())
											{
												steamPlayer3 = enumerator.Current;
											}
										}
										if (steamPlayer3.playerID.steamID == interactableStorage.owner)
										{
											text = text + "\n" + steamPlayer3.player.name;
											text2 = text2 + "\n" + steamPlayer3.player.name;
										}
										else
										{
											text += "\nNull";
											text2 += "\nNull";
										}
									}
									break;
								}
								}
								text += "</size>";
								text2 += "</size>";
								Vector3[] boxVectors = DrawUtilities.GetBoxVectors(bounds);
								Vector2[] rectangleLines = DrawUtilities.GetRectangleLines(ESPComponent.MainCamera, bounds, c);
								DrawUtilities.Get2DW2SVector(ESPComponent.MainCamera, rectangleLines, location);
								if (MirrorCameraOptions.Enabled)
								{
									if (rectangleLines.Any((Vector2 v) => MirrorCameraComponent.viewport.Contains(v)))
									{
										Highlighter component2 = gobject.GetComponent<Highlighter>();
										if (component2 != null)
										{
											component2.ConstantOffImmediate();
											goto IL_10A6;
										}
										goto IL_10A6;
									}
								}
								if (espvisual.Boxes)
								{
									if (espvisual.TwoDimensional)
									{
										DrawUtilities.PrepareRectangleLines(rectangleLines, Color.cyan);
									}
									else
									{
										DrawUtilities.PrepareBoxLines(boxVectors, Color.cyan);
										DrawUtilities.Get3DW2SVector(ESPComponent.MainCamera, bounds, location);
									}
								}
								Color.white;
								Color.white;
								if (espvisual.Glow)
								{
									Highlighter highlighter = espobject.GObject.GetComponent<Highlighter>() ?? espobject.GObject.AddComponent<Highlighter>();
									highlighter.occluder = true;
									highlighter.overlay = true;
									highlighter.ConstantOnImmediate(Color.cyan);
									ESPComponent.Highlighters.Add(highlighter);
								}
								else
								{
									Highlighter component3 = gobject.GetComponent<Highlighter>();
									if (component3 != null)
									{
										component3.ConstantOffImmediate();
									}
								}
								if (espvisual.Labels)
								{
									DrawUtilities.DrawESPLabel(espobject.GObject.transform.position, Color.yellow, Color.black, text, text2);
								}
								if (espvisual.LineToObject)
								{
									ESPVariables.DrawBuffer2.Enqueue(new ESPBox2
									{
										Color = Color.cyan,
										Vertices = new Vector2[]
										{
											new Vector2((float)(Screen.width / 2), (float)Screen.height),
											new Vector2(vector.x, (float)Screen.height - vector.y)
										}
									});
								}
							}
						}
					}
				}
				IL_10A6:;
			}
			T.DrawMaterial.SetPass(0);
			GL.PushMatrix();
			GL.LoadProjectionMatrix(ESPComponent.MainCamera.projectionMatrix);
			GL.modelview = ESPComponent.MainCamera.worldToCameraMatrix;
			GL.Begin(1);
			for (int k = 0; k < ESPVariables.DrawBuffer.Count; k++)
			{
				ESPBox espbox = ESPVariables.DrawBuffer.Dequeue();
				GL.Color(espbox.Color);
				Vector3[] vertices = espbox.Vertices;
				for (int l = 0; l < vertices.Length; l++)
				{
					GL.Vertex(vertices[l]);
				}
			}
			GL.End();
			GL.PopMatrix();
			GL.PushMatrix();
			GL.Begin(1);
			for (int m = 0; m < ESPVariables.DrawBuffer2.Count; m++)
			{
				ESPBox2 espbox2 = ESPVariables.DrawBuffer2.Dequeue();
				GL.Color(espbox2.Color);
				Vector2[] vertices2 = espbox2.Vertices;
				bool flag = true;
				for (int n = 0; n < vertices2.Length; n++)
				{
					if (n < vertices2.Length - 1)
					{
						Vector2 vector2 = vertices2[n];
						if (Vector2.Distance(vertices2[n + 1], vector2) > (float)(Screen.width / 2))
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					for (int num5 = 0; num5 < vertices2.Length; num5++)
					{
						GL.Vertex3(vertices2[num5].x, vertices2[num5].y, 0f);
					}
				}
			}
			GL.End();
			GL.PopMatrix();
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000BC1C File Offset: 0x00009E1C
		public static void DisableHighlighters()
		{
			foreach (Highlighter highlighter in ESPComponent.Highlighters)
			{
				highlighter.occluder = false;
				highlighter.overlay = false;
				highlighter.ConstantOffImmediate();
			}
			ESPComponent.Highlighters.Clear();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00003179 File Offset: 0x00001379
		public static string SentryName(Item DisplayItem, bool color)
		{
			if (DisplayItem != null)
			{
				return Assets.find(1, DisplayItem.id).name;
			}
			if (!color)
			{
				return "-No Item";
			}
			return "<color=#ff0000>No Item</color>";
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000319E File Offset: 0x0000139E
		public static string GetPowered(InteractableGenerator Generator, bool color)
		{
			if (!Generator.isPowered)
			{
				if (!color)
				{
					return "-OFF";
				}
				return "<color=#ff0000ff>OFF</color>";
			}
			else
			{
				if (!color)
				{
					return "-ON";
				}
				return "<color=#00ff00ff>-ON</color>";
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000BC84 File Offset: 0x00009E84
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

		// Token: 0x04000083 RID: 131
		private static ISleekElement hotbarContainer;

		// Token: 0x04000084 RID: 132
		private static SleekItemIcon[] hotbarImages;

		// Token: 0x04000085 RID: 133
		public static Font ESPFont;

		// Token: 0x04000086 RID: 134
		public static List<Highlighter> Highlighters = new List<Highlighter>();

		// Token: 0x04000087 RID: 135
		public static Camera MainCamera;

		// Token: 0x04000088 RID: 136
		private static readonly ClientInstanceMethod<byte> SendChangeVolume = ClientInstanceMethod<byte>.Get(typeof(InteractableStereo), "ReceiveChangeVolume");

		// Token: 0x04000089 RID: 137
		public static Interactable it;

		// Token: 0x0400008A RID: 138
		public static InteractableStereo stereo;
	}
}
