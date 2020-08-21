using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Helmet");
			Tooltip.SetDefault("+10% increased melee damage."
				+ "\n+10% increased melee critical strike chance."
				+ "\n+10% increased melee speed.");

			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Casco de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.Spanish, "+10% daño cuerpo a cuerpo."
				+ "\n+10% probabilidad de ataque crítico cuerpo a cuerpo."
				+ "\n+10% velocidad cuerpo a cuerpo.");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 24;
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.10f;   /*10 % increased melee damage*/
			player.meleeCrit += 10;        /*10 % increased melee critical strike chance*/
			player.meleeSpeed += 0.1f;	   /*10% increased melee speed*/
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nReduced damage taken when under 200 health"
							+ "\n19% Increased melee speed"
							+ "\n19% Increases movement speed"
							+ "\nIncreases maximum life by 25";
			
			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			player.meleeSpeed += 0.19f;      /*19% Increased melee speed*/
			player.moveSpeed += 0.19f;       /*19% Increases movement speed*/
			player.statLifeMax2 += 25;     /*Increases maximum life by 25*/
			if (player.statLife < 200)  /*Ej condicion: Añade buff cuando la vida baja de 200*/
			{
				player.AddBuff(mod.BuffType("MeteorbodyBuff"), 2);
			}
			/*AddTranslation(GameCulture.Spanish, "Inmunidad a '¡En llamas!','Ardiendo' y lava"
		+ "\nEmite un aura de luz"
		+ "\n+2 máximo de súbditos.");*/
		}
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowSubtle = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Placeable.RefinedMeteoriteBar>(), 12);
			recipe.AddTile(TileType<Tiles.RefinedMeteoriteAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}