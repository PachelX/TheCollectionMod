using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectionMod.Items
{
	public class MeteoriteHardenerSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorite Hardener");
			Tooltip.SetDefault("Used by the Clentaminator, spread true meteorite ore on meteorite ore.");
			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Endurecedor de meteorito");
			Tooltip.AddTranslation(GameCulture.Spanish, "Úsalo con el clentaminator, transforma el meteorito en meteorito endurecido");

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
			item.shoot = mod.ProjectileType("MeteoriteHardenerSolution") - ProjectileID.PureSpray;
		}
	}
}
