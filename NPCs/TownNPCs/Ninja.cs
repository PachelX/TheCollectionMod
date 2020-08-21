using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectionMod.TownNPCs
{
	[AutoloadHead]
	public class Ninja : ModNPC
	{
		public override string Texture 
		{
			get { return "TheCollectionMod/NPCs/TownNPCs/Ninja"; }
		}

		public override string[] AltTextures
		{
			get { return new[] { "TheCollectionMod/NPCs/TownNPCs/Ninja_alt" }; }
		}

		public override bool Autoload(ref string name)
		{
			name = "Ninja";
			return mod.Properties.Autoload;
		}

		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ninja");
			Main.npcFrameCount[npc.type] = 25; //is the number of frames that are in your .png sprite image
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0; //Tipo de ataque, 0 (throwing), 1 (shooting), or 2 (magic). 3 (melee)
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true; // must be set to True for the game to handle it like a Town NPC
			npc.friendly = true; //determines whether or not the NPC can hurt the player. In this case, I set friendly to False, and damage to zero, so that it doesn't hurt the player, and I can kill the NPC easily - for testing purposes of course. This is how bunnies work, I believe.
			npc.width = 36;
			npc.height = 44;
			npc.aiStyle = 7; // Town NPC AI Style
			npc.damage = 15;
			npc.defense = 20;
			npc.lifeMax = 350;
			npc.knockBackResist = 0.6f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			animationType = NPCID.Guide; //determines the internal code used to handle animations. Very often you'll want to make a sprite that is based off of an existing one, and use the same animation code that is already built into the game, instead of going through the process of making new animation code
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) //Whether or not the conditions have been met for this town NPC to be able to move into town.
		{
			if (NPC.downedSlimeKing)  
			{
				return true;
			}
			return false;
		}

		public override string TownNPCName() //Nombres del NPC
        {
			switch (WorldGen.genRand.Next(5))
			{
				case 0:
					return "Saske";
				case 1:
					return "Furamuros";
				case 2:
					return "Smooth Figure";
				case 3:
					return "Hattori";
				default: 
					return "Boninja";
			}
		}

		/*public override string GetChat()
        {
			int Guide = (NPCID.Guide);
			if(Guide >= 0 && Main.rand.NextBool(5))
			{
			return "¿Sabías que " + Main.npc[Guide].GivenName + " es mi hermano?";
		}
			switch(Main.rand.Next(5))
            {
				case 0:
					return "Odio el arroz blanco sin nada más.";
				case 1:
					return "La mejor manera de esquivar al Ojo de Cthulhu... es en un ángulo de 90º.";
				case 2:
					return "Que deshonra para un ninja..., dejarse atrapar por ese Slime gigante...";
				case 3:
					if (NPC.downedMechBossAny)
					{
						return "No esperaba menos de Maestro-san, ni un rasguño.";
					}
					else
					{
						return "Fui con Maestro-San a investigar sobre unas máquinas, pero ya sabes, Slime...";
					}
				default: // Default is the default if no other case is true. In this case if random nu
					return "Gracias por rescatarme, intentaré ayudarte en lo que pueda con mis humildes habilidades";
			}
        }*/

		public override string GetChat()
		{
			int Guide = (NPCID.Guide);
			if (Guide >= 0 && Main.rand.NextBool(4))
			{
				return "Did you know that " + Main.npc[Guide].GivenName + " is my brother?";
			}
			if (Guide >= 0 && Main.rand.NextBool(4))
			{
				return Main.npc[Guide].GivenName + " is the most gifted student of Master-san?";
			}

			switch (Main.rand.Next(5))
			{
				case 0:
					return "I hate white rice without anything else.";
				case 1:
					return "The best way to avoid the Eye of Cthulhu... is at a 90º.";
				case 2:
					return "What a shame for a ninja, to get sucked into that giant Slime...";
				case 3:
					if (NPC.downedMechBossAny)
					{
						return "I expected no less from Master-san, not even a scratch.";
					}
					else
					{
						return "I went with Master-San to investigate some machines, but you know, Slime...";
					}
				default: // Default is the default if no other case is true. In this case if random nu
					return "Thank you for rescuing me, I will try to help you in whatever way I can with my humble ninja arts.";
			}
		}
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Jutsu";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;    // Esto lo convierte en tienda
			}
			else
			{
				Main.npcChatText = "It's ninja time!";
				/*npcChatText.AddTranslation(GameCulture.Spanish, "¡La hora ninja!");*/
				Main.LocalPlayer.AddBuff(mod.BuffType("ShurikenjutsuBuff"), 36000); /*600 = 10seg*/
				Main.LocalPlayer.AddBuff(mod.BuffType("StealthBuff"), 36000); /*600 = 10seg*/
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemID.Katana); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Shuriken); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.NinjaHood); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.NinjaPants); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.NinjaShirt); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.InvisibilityPotion); nextSlot++;

			if (NPC.downedFrost)
			{
				shop.item[nextSlot].SetDefaults(ItemID.StarAnise); nextSlot++;
			}

			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife); nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Muramasa); nextSlot++;
			} 
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			if (Main.hardMode)
			{
				projType = ProjectileID.PoisonedKnife;
				attackDelay = 1;
			}
			else
			{
				projType = ProjectileID.Shuriken;
				attackDelay = 1;
			}

			if (Main.snowMoon)
			{
				projType = ProjectileID.StarAnise;
				attackDelay = 1;
			}

			if (Main.bloodMoon)
			{
				projType = ProjectileID.BoneDagger;
				attackDelay = 1;
			}

			if (Main.pumpkinMoon)
			{
				projType = ProjectileID.MolotovCocktail;
				attackDelay = 1;
			}
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 30f;
			gravityCorrection = 0f;
			randomOffset = 2f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (npc.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(npc.position, npc.width, npc.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 3; ++i)
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NinjaGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NinjaGore2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/NinjaGore3"), 1f);
			}
		}
	}
}