using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteMask : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Refined Meteorite Mask");
			Tooltip.SetDefault("15% increased ranged damage"
				+ "\n8% increased ranged critical strike chance");

			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Máscara de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.Spanish, "+15% daño a distancia"
				+ "\n+8% probabilidad de ataque crítico a distancia");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player)
		{
			player.rangedDamage += 0.15f;   /*15% increased ranged damage*/
			player.rangedCrit += 8;        /*8% increased ranged critical strike chance*/
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nReduced damage taken when under 200 health"
							+ "\n20% chance to not consume ammo";

			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			if (player.statLife < 200)  /*Ej condicion: Añade buff cuando la vida baja de 200*/
			{
				player.AddBuff(mod.BuffType("MeteorbodyBuff"), 2);
			}
			player.ammoCost80 = true;
			/*AddTranslation(GameCulture.Spanish, "Inmunidad a '¡En llamas!','Ardiendo' y lava"
			+ "\nEmite un aura de luz"
			+ "\n+2 máximo de súbditos.");*/
		}
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawShadowLokis = true;
			player.armorEffectDrawShadowSubtle = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("RefinedMeteoriteMaskBlueprint"), 1);
			recipe.AddIngredient(ItemType<Placeable.RefinedMeteoriteBar>(), 12);
			recipe.AddTile(TileType<Tiles.RefinedMeteoriteAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}