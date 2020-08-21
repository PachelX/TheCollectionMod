using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectionMod.Items
{
	public class MeteormanHeart : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteorman Heart");
			Tooltip.SetDefault("Keep it in inventory until Meteorman is healed");
			DisplayName.AddTranslation(GameCulture.Spanish, "Coraz�n del hombre de meteorito");
			Tooltip.AddTranslation(GameCulture.Spanish, "Gu�rdalo en el inventario hasta que" 
							+ "\nel hombre de meteorito est� curado");
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.maxStack = 999;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(ItemID.Meteorite, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool CanBurnInLava() {
			return false;
		}
		/*public override bool CanRightClick()
		{
			return true;
		}*/
	}
}