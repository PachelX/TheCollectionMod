using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Placeable
{
	public class RefinedMeteoriteAnvil : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Anvil");
			Tooltip.SetDefault("Used to craft items from Refined Meteorite Bar.");

			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Yunque de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.Spanish, "Se usa para fabricar objetos con lingotes de meteorito refinado.");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.rare = ItemRarityID.Orange;
			item.createTile = TileType<Tiles.RefinedMeteoriteAnvil>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronAnvil);
			recipe.AddIngredient(ItemType<RefinedMeteoriteBar>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadAnvil);
			recipe.AddIngredient(ItemType<RefinedMeteoriteBar>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}