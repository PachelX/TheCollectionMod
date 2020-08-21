using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHood : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Hood");
			Tooltip.SetDefault("Increases your max number of minions by 1."
				+ "\nIncreases minion damage by 15%.");
			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Caperuza de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.Spanish, "+1 máximo de súbditos."
				+ "\n+15% daño de súbditos.");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.15f;   /*15 % increased minion damage*/
			player.maxMinions += 1;         /*Increases your max number of minions"*/
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nReduced damage taken when under 200 health"
							+ "\nIncreases your max number of minions by 2.";

			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			if (player.statLife < 200)  /*Ej condicion: Añade el buffo cuando la vida baja de 200*/
			{
				player.AddBuff(mod.BuffType("MeteorbodyBuff"), 2);
			}
			player.maxMinions += 2;         /*Increases your max number of minions"*/
		
		/*AddTranslation(GameCulture.Spanish, "Inmunidad a '¡En llamas!','Ardiendo' y lava"
		+ "\nEmite un aura de luz"
		+ "\n+2 máximo de súbditos.");*/
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Placeable.RefinedMeteoriteBar>(), 12);
			recipe.AddTile(TileType<Tiles.RefinedMeteoriteAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}