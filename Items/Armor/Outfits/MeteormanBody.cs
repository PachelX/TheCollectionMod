using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace TheCollectionMod.Items.Armor.Outfits
{
	[AutoloadEquip(EquipType.Body)]
	public class MeteormanBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorman's Body");
			Tooltip.SetDefault("It's a bit hot ...");
			DisplayName.AddTranslation(GameCulture.Spanish, "Peto de hombre de meteorito");
			Tooltip.AddTranslation(GameCulture.Spanish, "Hace un poco de calor...");
		}
		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.rare = ItemRarityID.Blue;
			item.value = 100000;
			item.vanity = true;
		}

		public override bool DrawBody() 
		{
			return false;
		}
	}
}