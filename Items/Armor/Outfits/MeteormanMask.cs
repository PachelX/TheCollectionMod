using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace TheCollectionMod.Items.Armor.Outfits
{
	[AutoloadEquip(EquipType.Head)]
	public class MeteormanMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorman's Mask");
			Tooltip.SetDefault("It's a bit hot ...");
			DisplayName.AddTranslation(GameCulture.Spanish, "Máscara hombre de meteorito");
			Tooltip.AddTranslation(GameCulture.Spanish, "Hace un poco de calor...");
		}
		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Blue;
			item.value = 100000; /*10000 = 1 Gold*/
			item.vanity = true;
		}

		public override bool DrawHead() {
			return false;
		}
	}
}