using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Placeable
{
	public class HardenedMeteoriteOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hardened Meteorite Ore");

			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Meteorito endurecido");

			ItemID.Sets.SortingPriorityMaterials[item.type] = 89; // influences the inventory sort order. 89 is HallowedBar, higher is more valuable.
		}
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = mod.TileType("HardenedMeteoriteOre");
			item.rare = ItemRarityID.Orange;
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}
	}
}
