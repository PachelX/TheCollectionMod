using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TheCollectionMod.Items
{
	public class MeteoriteSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteoric Solution");
			Tooltip.SetDefault("Used by the Clentaminator, spread meteor ore on stone.");
			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Solución de meteorito");
			Tooltip.AddTranslation(GameCulture.Spanish, "Úsalo con el clentaminator, transforma la piedra en meteorito");
		}

		public override void SetDefaults()
		{
			item.width = 10;
			item.height = 12;
			item.value = Item.buyPrice(0, 5, 25, 0);
			item.rare = ItemRarityID.Orange;
			item.maxStack = 999;
			item.consumable = true;
			item.ammo = AmmoID.Solution;
			item.shoot = mod.ProjectileType("MeteoriteSolution") - ProjectileID.PureSpray;
		}
	}
}
