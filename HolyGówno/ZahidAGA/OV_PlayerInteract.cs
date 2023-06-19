using System;
using System.Reflection;
using HighlightingSystem;
using SDG.Unturned;
using UnityEngine;

namespace ZahidAGA
{
	// Token: 0x02000080 RID: 128
	public class OV_PlayerInteract
	{
		// Token: 0x0600025E RID: 606 RVA: 0x000101AC File Offset: 0x0000E3AC
		[Initializer]
		public static void Init()
		{
			OV_PlayerInteract.FocusField = typeof(PlayerInteract).GetField("focus", ReflectionVariables.publicStatic);
			OV_PlayerInteract.TargetField = typeof(PlayerInteract).GetField("target", ReflectionVariables.publicStatic);
			OV_PlayerInteract.InteractableField = typeof(PlayerInteract).GetField("_interactable", ReflectionVariables.publicStatic);
			OV_PlayerInteract.Interactable2Field = typeof(PlayerInteract).GetField("_interactable2", ReflectionVariables.publicStatic);
			OV_PlayerInteract.PurchaseAssetField = typeof(PlayerInteract).GetField("purchaseAsset", ReflectionVariables.publicStatic);
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00003BAA File Offset: 0x00001DAA
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00003BBC File Offset: 0x00001DBC
		public static Transform focus
		{
			get
			{
				return (Transform)OV_PlayerInteract.FocusField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.FocusField.SetValue(null, value);
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00003BCA File Offset: 0x00001DCA
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00003BDC File Offset: 0x00001DDC
		public static Transform target
		{
			get
			{
				return (Transform)OV_PlayerInteract.TargetField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.TargetField.SetValue(null, value);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00003BEA File Offset: 0x00001DEA
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00003BFC File Offset: 0x00001DFC
		public static Interactable interactable
		{
			get
			{
				return (Interactable)OV_PlayerInteract.InteractableField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.InteractableField.SetValue(null, value);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00003C0A File Offset: 0x00001E0A
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00003C1C File Offset: 0x00001E1C
		public static Interactable2 interactable2
		{
			get
			{
				return (Interactable2)OV_PlayerInteract.Interactable2Field.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.Interactable2Field.SetValue(null, value);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00003C2A File Offset: 0x00001E2A
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00003C3C File Offset: 0x00001E3C
		public static ItemAsset purchaseAsset
		{
			get
			{
				return (ItemAsset)OV_PlayerInteract.PurchaseAssetField.GetValue(null);
			}
			set
			{
				OV_PlayerInteract.PurchaseAssetField.SetValue(null, value);
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00003C4A File Offset: 0x00001E4A
		public float salvageTime
		{
			get
			{
				if (MiscOptions.CustomSalvageTime)
				{
					return MiscOptions.SalvageTime;
				}
				if (!OptimizationVariables.MainPlayer.channel.owner.isAdmin)
				{
					return 8f;
				}
				return 1f;
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00003C7A File Offset: 0x00001E7A
		public void hotkey(byte button)
		{
			VehicleManager.swapVehicle(button);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00003C82 File Offset: 0x00001E82
		public void onPurchaseUpdated(PurchaseNode node)
		{
			if (node == null)
			{
				OV_PlayerInteract.purchaseAsset = null;
				return;
			}
			OV_PlayerInteract.purchaseAsset = (ItemAsset)Assets.find(1, node.id);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00010250 File Offset: 0x0000E450
		public static void highlight(Transform target, Color color)
		{
			if (!target.CompareTag("Player") || target.CompareTag("Enemy") || target.CompareTag("Zombie") || target.CompareTag("Animal") || target.CompareTag("Agent"))
			{
				Highlighter highlighter = target.GetComponent<Highlighter>();
				if (highlighter == null)
				{
					highlighter = target.gameObject.AddComponent<Highlighter>();
				}
				highlighter.ConstantOn(color, 0.25f);
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x000102C8 File Offset: 0x0000E4C8
		[OnSpy]
		public static void OnSpied()
		{
			Transform transform = OptimizationVariables.MainCam.transform;
			if (transform != null)
			{
				Physics.Raycast(new Ray(transform.position, transform.forward), ref OV_PlayerInteract.hit, (float)((OptimizationVariables.MainPlayer.look.perspective == 1) ? 6 : 4), RayMasks.PLAYER_INTERACT, 0);
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00010324 File Offset: 0x0000E524
		[Override(typeof(PlayerInteract), "Update", BindingFlags.Instance | BindingFlags.NonPublic, 0)]
		public void OV_Update()
		{
			if (!DrawUtilities.ShouldRun())
			{
				return;
			}
			if (OptimizationVariables.MainPlayer.stance.stance != 6 && OptimizationVariables.MainPlayer.stance.stance != 7 && !OptimizationVariables.MainPlayer.life.isDead && !OptimizationVariables.MainPlayer.workzone.isBuilding)
			{
				if (Time.realtimeSinceStartup - OV_PlayerInteract.lastInteract > 0.1f)
				{
					int num = 0;
					if (InteractionOptions.InteractThroughWalls && !G.BeingSpied)
					{
						if (!InteractionOptions.NoHitBarricades)
						{
							num |= 134217728;
						}
						if (!InteractionOptions.NoHitItems)
						{
							num |= 8192;
						}
						if (!InteractionOptions.NoHitResources)
						{
							num |= 16384;
						}
						if (!InteractionOptions.NoHitStructures)
						{
							num |= 268435456;
						}
						if (!InteractionOptions.NoHitVehicles)
						{
							num |= 67108864;
						}
						if (!InteractionOptions.NoHitEnvironment)
						{
							num |= 1671168;
						}
					}
					else
					{
						num = RayMasks.PLAYER_INTERACT;
					}
					OV_PlayerInteract.lastInteract = Time.realtimeSinceStartup;
					float num2 = (InteractionOptions.InteractThroughWalls && !G.BeingSpied) ? 20f : 4f;
					Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), ref OV_PlayerInteract.hit, (OptimizationVariables.MainPlayer.look.perspective == 1) ? (num2 + 2f) : num2, num, 0);
				}
				Transform transform = (!(OV_PlayerInteract.hit.collider != null)) ? null : OV_PlayerInteract.hit.collider.transform;
				if (transform != OV_PlayerInteract.focus)
				{
					if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
					{
						InteractableDoorHinge componentInParent = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
						if (componentInParent != null)
						{
							HighlighterTool.unhighlight(componentInParent.door.transform);
						}
						else
						{
							HighlighterTool.unhighlight(PlayerInteract.interactable.transform);
						}
					}
					OV_PlayerInteract.focus = null;
					OV_PlayerInteract.target = null;
					OV_PlayerInteract.interactable = null;
					OV_PlayerInteract.interactable2 = null;
					if (transform != null)
					{
						OV_PlayerInteract.focus = transform;
						OV_PlayerInteract.interactable = OV_PlayerInteract.focus.GetComponentInParent<Interactable>();
						OV_PlayerInteract.interactable2 = OV_PlayerInteract.focus.GetComponentInParent<Interactable2>();
						if (PlayerInteract.interactable != null)
						{
							OV_PlayerInteract.target = TransformRecursiveFind.FindChildRecursive(PlayerInteract.interactable.transform, "Target");
							if (PlayerInteract.interactable.checkInteractable())
							{
								if (PlayerUI.window.isEnabled)
								{
									if (PlayerInteract.interactable.checkUseable())
									{
										Color green;
										if (!PlayerInteract.interactable.checkHighlight(ref green))
										{
											green = Color.green;
										}
										InteractableDoorHinge componentInParent2 = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
										if (componentInParent2 != null)
										{
											HighlighterTool.highlight(componentInParent2.door.transform, green);
										}
										else
										{
											HighlighterTool.highlight(PlayerInteract.interactable.transform, green);
										}
									}
									else
									{
										Color red = Color.red;
										InteractableDoorHinge componentInParent3 = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
										if (componentInParent3 != null)
										{
											HighlighterTool.highlight(componentInParent3.door.transform, red);
										}
										else
										{
											HighlighterTool.highlight(PlayerInteract.interactable.transform, red);
										}
									}
								}
							}
							else
							{
								OV_PlayerInteract.target = null;
								OV_PlayerInteract.interactable = null;
							}
						}
					}
				}
			}
			else
			{
				if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
				{
					InteractableDoorHinge componentInParent4 = OV_PlayerInteract.focus.GetComponentInParent<InteractableDoorHinge>();
					if (componentInParent4 != null)
					{
						HighlighterTool.unhighlight(componentInParent4.door.transform);
					}
					else
					{
						HighlighterTool.unhighlight(PlayerInteract.interactable.transform);
					}
				}
				OV_PlayerInteract.focus = null;
				OV_PlayerInteract.target = null;
				OV_PlayerInteract.interactable = null;
				OV_PlayerInteract.interactable2 = null;
			}
			if (OptimizationVariables.MainPlayer.life.isDead)
			{
				return;
			}
			if (PlayerInteract.interactable != null)
			{
				EPlayerMessage eplayerMessage;
				string text;
				Color color;
				if (PlayerInteract.interactable.checkHint(ref eplayerMessage, ref text, ref color) && !PlayerUI.window.showCursor)
				{
					if (PlayerInteract.interactable.CompareTag("Item"))
					{
						PlayerUI.hint((!(OV_PlayerInteract.target != null)) ? OV_PlayerInteract.focus : OV_PlayerInteract.target, eplayerMessage, text, color, new object[]
						{
							((InteractableItem)PlayerInteract.interactable).item,
							((InteractableItem)PlayerInteract.interactable).asset
						});
					}
					else
					{
						PlayerUI.hint((!(OV_PlayerInteract.target != null)) ? OV_PlayerInteract.focus : OV_PlayerInteract.target, eplayerMessage, text, color, new object[0]);
					}
				}
			}
			else if (OV_PlayerInteract.purchaseAsset != null && OptimizationVariables.MainPlayer.movement.purchaseNode != null && !PlayerUI.window.showCursor)
			{
				PlayerUI.hint(null, 47, string.Empty, Color.white, new object[]
				{
					OV_PlayerInteract.purchaseAsset.itemName,
					OptimizationVariables.MainPlayer.movement.purchaseNode.cost
				});
			}
			else if (OV_PlayerInteract.focus != null && OV_PlayerInteract.focus.CompareTag("Enemy"))
			{
				Player player = DamageTool.getPlayer(OV_PlayerInteract.focus);
				if (player != null && player != Player.player && !PlayerUI.window.showCursor)
				{
					PlayerUI.hint(null, 11, string.Empty, Color.white, new object[]
					{
						player.channel.owner
					});
				}
			}
			EPlayerMessage eplayerMessage2;
			float num3;
			if (PlayerInteract.interactable2 != null && PlayerInteract.interactable2.checkHint(ref eplayerMessage2, ref num3) && !PlayerUI.window.showCursor)
			{
				PlayerUI.hint2(eplayerMessage2, (!OV_PlayerInteract.isHoldingKey) ? 0f : ((Time.realtimeSinceStartup - OV_PlayerInteract.lastKeyDown) / this.salvageTime), num3);
			}
			if ((OptimizationVariables.MainPlayer.stance.stance == 6 || OptimizationVariables.MainPlayer.stance.stance == 7) && !Input.GetKey(304))
			{
				if (Input.GetKeyDown(282))
				{
					this.hotkey(0);
				}
				if (Input.GetKeyDown(283))
				{
					this.hotkey(1);
				}
				if (Input.GetKeyDown(284))
				{
					this.hotkey(2);
				}
				if (Input.GetKeyDown(285))
				{
					this.hotkey(3);
				}
				if (Input.GetKeyDown(286))
				{
					this.hotkey(4);
				}
				if (Input.GetKeyDown(287))
				{
					this.hotkey(5);
				}
				if (Input.GetKeyDown(288))
				{
					this.hotkey(6);
				}
				if (Input.GetKeyDown(289))
				{
					this.hotkey(7);
				}
				if (Input.GetKeyDown(290))
				{
					this.hotkey(8);
				}
				if (Input.GetKeyDown(291))
				{
					this.hotkey(9);
				}
			}
			if (Input.GetKeyDown(ControlsSettings.interact))
			{
				OV_PlayerInteract.lastKeyDown = Time.realtimeSinceStartup;
				OV_PlayerInteract.isHoldingKey = true;
			}
			if (Input.GetKeyDown(ControlsSettings.inspect) && ControlsSettings.inspect != ControlsSettings.interact && OptimizationVariables.MainPlayer.equipment.canInspect)
			{
				OptimizationVariables.MainPlayer.channel.send("askInspect", 0, 1, new object[0]);
			}
			if (OV_PlayerInteract.isHoldingKey)
			{
				if (Input.GetKeyUp(ControlsSettings.interact))
				{
					OV_PlayerInteract.isHoldingKey = false;
					if (PlayerUI.window.showCursor)
					{
						if (OptimizationVariables.MainPlayer.inventory.isStoring && OptimizationVariables.MainPlayer.inventory.shouldInteractCloseStorage)
						{
							PlayerDashboardUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerBarricadeSignUI.active)
						{
							PlayerBarricadeSignUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerBarricadeLibraryUI.active)
						{
							PlayerBarricadeLibraryUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerBarricadeMannequinUI.active)
						{
							PlayerBarricadeMannequinUI.close();
							PlayerLifeUI.open();
							return;
						}
						if (PlayerNPCDialogueUI.active)
						{
							if (PlayerNPCDialogueUI.dialogueAnimating)
							{
								PlayerNPCDialogueUI.skipText();
								return;
							}
							if (PlayerNPCDialogueUI.dialogueHasNextPage)
							{
								PlayerNPCDialogueUI.nextPage();
								return;
							}
							PlayerNPCDialogueUI.close();
							PlayerLifeUI.open();
							return;
						}
						else
						{
							if (PlayerNPCQuestUI.active)
							{
								PlayerNPCQuestUI.closeNicely();
								return;
							}
							if (PlayerNPCVendorUI.active)
							{
								PlayerNPCVendorUI.closeNicely();
								return;
							}
						}
					}
					else
					{
						if (OptimizationVariables.MainPlayer.stance.stance == 6 || OptimizationVariables.MainPlayer.stance.stance == 7)
						{
							VehicleManager.exitVehicle();
							return;
						}
						if (OV_PlayerInteract.focus != null && PlayerInteract.interactable != null)
						{
							if (PlayerInteract.interactable.checkUseable())
							{
								PlayerInteract.interactable.use();
								return;
							}
						}
						else if (OV_PlayerInteract.purchaseAsset != null)
						{
							if (OptimizationVariables.MainPlayer.skills.experience >= OptimizationVariables.MainPlayer.movement.purchaseNode.cost)
							{
								OptimizationVariables.MainPlayer.skills.sendPurchase(OptimizationVariables.MainPlayer.movement.purchaseNode);
								return;
							}
						}
						else if (ControlsSettings.inspect == ControlsSettings.interact && OptimizationVariables.MainPlayer.equipment.canInspect)
						{
							OptimizationVariables.MainPlayer.channel.send("askInspect", 0, 1, new object[0]);
							return;
						}
					}
				}
				else if (Time.realtimeSinceStartup - OV_PlayerInteract.lastKeyDown > this.salvageTime)
				{
					OV_PlayerInteract.isHoldingKey = false;
					if (!PlayerUI.window.showCursor && PlayerInteract.interactable2 != null)
					{
						PlayerInteract.interactable2.use();
					}
				}
			}
		}

		// Token: 0x040002A7 RID: 679
		public static FieldInfo FocusField;

		// Token: 0x040002A8 RID: 680
		public static FieldInfo TargetField;

		// Token: 0x040002A9 RID: 681
		public static FieldInfo InteractableField;

		// Token: 0x040002AA RID: 682
		public static FieldInfo Interactable2Field;

		// Token: 0x040002AB RID: 683
		public static FieldInfo PurchaseAssetField;

		// Token: 0x040002AC RID: 684
		public static bool isHoldingKey;

		// Token: 0x040002AD RID: 685
		public static float lastInteract;

		// Token: 0x040002AE RID: 686
		public static float lastKeyDown;

		// Token: 0x040002AF RID: 687
		public static RaycastHit hit;
	}
}
