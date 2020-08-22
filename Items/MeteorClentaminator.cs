using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectionMod.Items
{
	public class MeteorClentaminator : ModItem
    {

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Meteor Clentaminator");
        }

        public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Clentaminator);
			item.value = Item.buyPrice(0, 40, 0, 0);
			item.autoReuse = false;
		}
	}
}
