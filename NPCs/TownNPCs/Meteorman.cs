using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TheCollectionMod;
using System.Linq;
using Terraria.Utilities;

namespace TheCollectionMod.TownNPCs
{
	[AutoloadHead]
	public class Meteorman : ModNPC
	{
		public override string Texture
		{
			get { return "TheCollectionMod/NPCs/TownNPCs/Meteorman"; }
		}

		public override string[] AltTextures
		{
			get { return new[] { "TheCollectionMod/NPCs/TownNPCs/Meteorman_alt" }; }
		}

		public override bool UsesPartyHat()
		{
			return true;
		}

		public override bool Autoload(ref string name)
		{
			name = "Meteorman";
			return mod.Properties.Autoload;

		}

		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorman");
			DisplayName.AddTranslation(GameCulture.Spanish, "Hombre de Meteorito");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 100;
			NPCID.Sets.AttackType[npc.type] = 2;
			NPCID.Sets.AttackTime[npc.type] = 10;
			NPCID.Sets.AttackAverageChance[npc.type] = 10;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 36;
			npc.height = 48;
			npc.aiStyle = 7; // Town NPC AI Style
			npc.damage = 30;
			npc.defense = 40;
			npc.lifeMax = 500;
			npc.knockBackResist = 0.5f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			animationType = NPCID.DyeTrader;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				foreach (Item item in player.inventory)
				{
					if (item.type == mod.ItemType("MeteormanHeart"))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Roco";
				case 1:
					return "Meteoro";
				case 2:
					return "Rocky Taicho";
				case 3:
					return "Stonesy";
				default: // Default is the default if no other case is true. In this case if random nu
					return "Space Rock";
			}
		}

		public override string GetChat()
		{
			int Demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
			if (Demolitionist >= 0 && Main.rand.NextBool(9))
			{
				return Main.npc[Demolitionist].GivenName + "'s explosives are very good for my digestion.";
			}

			int Dryad = NPC.FindFirstNPC(NPCID.Dryad);
			if (Dryad >= 0 && Main.rand.NextBool(9))
			{
				return "Thanks to " + Main.npc[Dryad].GivenName + " I have been able to heal, I am very grateful to her.";
			}

			switch (Main.rand.Next(7))
			{
				case 0:
					return "The equipment you forge with meteorite is very good, but you do not get the maximum potential from it.";
				case 1:
					return "It's not bad around here, but I'd prefer a warmer place";
				case 2:
					return "When you defeated that evil monster, the seal that keeps the Lord of the Moon imprisoned weakened, it was able to bring down my base and I ended up crashing here.";
				case 3:
					if (Main.hardMode)
					{
						Main.npcChatCornerItem = mod.ItemType("MeteoriteHardenerSolution");
						return "It has taken me longer than I expected, but with this solution, you will be able to harden the meteorite and refine it.";
					}
					else
					{
						return "To improve the equipment we will have to harden the meteorite, it will take time to prepare the solution";
					}
				case 4:
					if (Main.invasionType == 4)     /* (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4), (Main.eclipse)*/
					{
						return "I hope they won't send him to fight, he's a friendly Martian.";
					}
					else
					{
						return "I wonder what happened to my friend.";
					}
				case 5:
					Main.npcChatCornerItem = ItemID.MythrilPickaxe;
					return "To mine the hardened meteorite you will need at least a Mythril Pickaxe.";
				default:
					return "You have good stones around here...";
			}
		}
		/*public override string GetChat()
		{
			int Demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
			if (Demolitionist >= 0 && Main.rand.NextBool(9))
			{
				return "Los explosivos de " + Main.npc[Demolitionist].GivenName + " me vienen muy bien para la digestión.";
			}

			int Dryad = NPC.FindFirstNPC(NPCID.Dryad);
			if (Dryad >= 0 && Main.rand.NextBool(9))
			{
				return "Gracias a " + Main.npc[Dryad].GivenName + " he podido reconstruirme, le estoy muy agradecido.";
			}

			switch (Main.rand.Next(7))
			{
				case 0:
					return "Ese equipamiento que forjais con meteorito está muy bien, pero no le sacais mucho potencial.";
				case 1:
					if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
					{
						return "Han utilizado mi equipo en esas máquinas, por suerte todavía se puede aprovechar";
					}
					else
					{
						return "Si encontrara parte de mi equipo podría mejorarlas, ¿Donde estarán?";
					}
				case 2:
					return "No se está mal por aquí, pero preferiría un lugar mas caluroso";
				case 3:
					if (Main.hardMode)
					{
						return "!Por fin lo tengo!, con esta solución podremos endurecer el meteorito y refinarlo";
					}
					else
					{
						return "Para mejorar el equipo vamos a tener que endurecer el meteorito, me llevará tiempo preparar la solución";
					}
				case 4:
					if (NPC.downedBoss2)
					{
						return "Cuando derrotaste al Devorador de mundos, el sello que mantiene encerrado al Señor de la Luna se debilitó, pudo derribar mi base y terminé estrellandome en la superficie";
					}
					else
					{
						return "Cuando derrotaste al Cerebro de Cthulhu, el sello que mantiene encerrado al Señor de la Luna se debilitó, pudo derribar mi base y terminé estrellandome en la superficie";
					}
				case 5:
					if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
					{
						return "Si necesitas mas piezas, sólo tienes traerme algún pedazo de esas máquinas";
					}
					else
					{
						return "Han utilizado mi equipo en esas máquinas, por suerte todavía se puede aprovechar";
					}
				case 6:
					return "No se está mal por aquí, pero preferiría un lugar mas caluroso";
				default:
					return "Teneís buenas piedras por aquí...";
			}
		}*/

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				// Esto lo convierte en tienda
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(mod.ItemType("MeteorClentaminator")); nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("MeteoriteSolution")); nextSlot++;

			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MeteoriteHardenerSolution")); nextSlot++;
			}
			/*if (NPC.downedMechBoss1 || NPC.downedMechBoss2 || NPC.downedMechBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("RefinedMeteoriteHelmetBlueprint")); nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("RefinedMeteoriteMaskBlueprint")); nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("RefinedMeteoriteHoodBlueprint")); nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("RefinedMeteoriteBreastplateBlueprint")); nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("RefinedMeteoriteLeggingsBlueprint")); nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("RefinedMeteoriteSwordBlueprint")); nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("BookBlueprint")); nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("GunBlueprint")); nextSlot++;
			}*/
			if (NPC.downedMechBoss1)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MeteormanMask")); nextSlot++;
			}
			if (NPC.downedMechBoss2)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MeteormanBody")); nextSlot++;
			}
			if (NPC.downedMechBoss3)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MeteormanLegs")); nextSlot++;
			}
		}
		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness) //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). Scale is a multiplier for the item's drawing size, item is the ID of the item to be drawn, and closeness is how close the item should be drawn to the NPC.
		{
			scale = 1f;
			if (Main.hardMode)
			{
				item = ItemID.MeteorStaff;
			}
			else
			{
				item = ItemID.SpaceGun;
			}
			closeness = 20;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
		{
			if (Main.hardMode)
			{
				projType = ProjectileID.Meteor3;
			}
			else
			{
				projType = ProjectileID.MeteorShot;
			}
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)//Allows you to determine the speed at which this town NPC throws a projectile when it attacks. Multiplier is the speed of the projectile, gravityCorrection is how much extra the projectile gets thrown upwards, and randomOffset allows you to randomize the projectile's velocity in a square centered around the original velocity
		{
			multiplier = 7f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MeteormanGore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MeteormanGore2"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/MeteormanGore3"), 1f);
			}
		}
	}
}