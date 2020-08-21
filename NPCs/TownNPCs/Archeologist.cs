using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using Terraria.Utilities;

namespace TheCollectionMod.TownNPCs
{
	[AutoloadHead]
	public class Archeologist : ModNPC
	{
		public override string Texture 
		{
			get { return "TheCollectionMod/NPCs/TownNPCs/Archeologist"; }
		}

		public override string[] AltTextures
		{
			get { return new[] { "TheCollectionMod/NPCs/TownNPCs/Archeologist_alt" }; }
		}

		public override bool Autoload(ref string name)
		{
			name = "Archeologist";
			return mod.Properties.Autoload;
		}
		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Archeologist");
			DisplayName.AddTranslation(GameCulture.Spanish, "Arqueólogo");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 5;
			NPCID.Sets.DangerDetectRange[npc.type] = 100;
			NPCID.Sets.AttackType[npc.type] = 1; //Tipo de ataque, 0 (throwing), 1 (shooting), or 2 (magic). 3 (melee)
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
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
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
					if (item.type == ItemID.RopeCoil)
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
					return "Dr. Jones";
				case 1:
					return "Indy";
				case 2:
					return "Capitán Dinamita";
				case 3:
					return "Jonesy";
				default: 
					return "Mungo Kidogo";
			}
		}

		public override string GetChat()
		{
			int WitchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
			if (WitchDoctor >= 0 && Main.rand.NextBool(4))
			{
				return Main.npc[WitchDoctor].GivenName + " causes me mixed feelings";
			}

			int Dryad = NPC.FindFirstNPC(NPCID.Dryad);
			if (Dryad >= 0 && Main.rand.NextBool(9))
			{
				return "I really like " + Main.npc[Dryad].GivenName + " , she is very pretty.";
			}

			switch (Main.rand.Next(5))
			{
				case 0:
					return "They had to be snakes ...";
				case 1:
					if (NPC.downedPlantBoss)
					{
						return "That key has to be the one that opens the jungle temple.";
					}
					else
					{
						return "It is said that there is a hidden temple in the jungle.";
					}

				case 2:
					return "I wanted to use a whip, but it's not implemented yet ";
				case 3:
					{
						// Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
						Main.npcChatCornerItem = ItemID.EndlessMusketPouch;
						return $"Hey, if you find a [i:{ItemID.EndlessMusketPouch}], I can upgrade it for you. 'Not yet implemented'";
					}
				default: // Default is the default if no other case is true. In this case if random nu
					return "Hello, I am an experienced archaeologist, I can provide very useful basic equipment.";
			}
		}
		/*public override string GetChat()
        {
			int WitchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
			if(WitchDoctor >= 0 && Main.rand.NextBool(4))
			{
			return  Main.npc[WitchDoctor].GivenName + " me provoca sentimientos encontrados";
		}
			switch(Main.rand.Next(4))
            {
				case 0:
					return "Tenian que ser serpientes...";
				case 1:
					if (NPC.downedPlantBoss)
                    {
					return "Esa llave tiene que ser la que abre el templo de la jungla.";
					}
                    else
                    {
					return "Se dice que hay un templo oculto en la jungla.";
					}
					
				case 2:
					return "Quería usar un látigo, pero no está implementado todavía";
				default: // Default is the default if no other case is true. In this case if random nu
					return "default drprueba";
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
			shop.item[nextSlot].SetDefaults(ItemID.Torch); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Rope); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.RopeCoil); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Bomb); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.GrapplingHook); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Boomstick); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.MusketBall); nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ChainKnife); nextSlot++;

			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.DyeTradersScimitar); nextSlot++;
			} 
			
			if (Main.bloodMoon)
				shop.item[nextSlot].SetDefaults(ItemID.SilverBullet);
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
			item = !Main.hardMode ? ItemID.Boomstick : ItemID.Boomstick;
			closeness = 20;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)//Allows you to determine the projectile type of this town NPC's attack, and how long it takes for the projectile to actually appear
		{
			projType = !Main.hardMode ? ProjectileID.FireArrow : ProjectileID.ExplosiveBullet;
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
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArqueologistGore1"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArqueologistGore2"), 1f);
					Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ArqueologistGore3"), 1f);
			}
		}
	}
}