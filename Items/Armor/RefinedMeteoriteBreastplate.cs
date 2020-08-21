using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RefinedMeteoriteBreastplate : ModItem
	{
		public override void SetStaticDefaults() 
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Refined Meteorite Breastplate");
			Tooltip.SetDefault("7% Increased critical strike chance");

			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Cota de malla de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.Spanish, "+7% probabilidad de ataque crítico.");
		}

		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 7;
			player.rangedCrit += 7;
			player.magicCrit += 7;
			player.thrownCrit += 7;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Placeable.RefinedMeteoriteBar>(), 24);
			recipe.AddTile(TileType<Tiles.RefinedMeteoriteAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}