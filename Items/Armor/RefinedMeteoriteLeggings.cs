using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RefinedMeteoriteLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Leggings");
			Tooltip.SetDefault("+7% increased damage"
				+ "\n+8% increased movement speed");

			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Grebas de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.Spanish, "+7% daño"
				+ "\n+8% velocidad de movimiento");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 11;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.08f;
			player.allDamage += 0.07f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Placeable.RefinedMeteoriteBar>(), 18);
			recipe.AddTile(TileType<Tiles.RefinedMeteoriteAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}