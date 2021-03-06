using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RefinedMeteoriteHeadgear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Headgear");
			Tooltip.SetDefault("+100 max mana"
			+ "\n+12% increased magic damage and critical strike chance");

			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Tocado de meteorito refinado");
			Tooltip.AddTranslation(GameCulture.Spanish, "+100 de man� m�ximo"
			+ "\n+12% da�o m�gico"
			+ "\n+12% probabilidad de ataque cr�tico m�gico");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 5;
		}
		public override void UpdateEquip(Player player)
		{
			player.statManaMax2 += 100;
			player.magicDamage += 0.12f;
			player.magicCrit = 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{

			return body.type == ItemType<RefinedMeteoriteBreastplate>() && legs.type == ItemType<RefinedMeteoriteLeggings>();
		}
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Immunity to 'On Fire','Burning' and lava"
							+ "\nEmits an aura of light"
							+ "\nIncreased defense when under 200 health"
							+ "\n20% reduced mana usage"
							+ "\nRefined Meteor Staff don't consume mana";
			player.AddBuff(BuffID.Shine, 2);
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Burning] = true;
			player.lavaImmune = true;
			if (player.statLife < 200)  /*Ej condicion: A�ade el buffo cuando la vida baja de 200*/
			{
				player.AddBuff(mod.BuffType("MeteorbodyBuff"), 2);
			}
			player.manaCost -= 0.2f;    /*20% decreased mana cost*/
			if (Main.LocalPlayer.HasItem(ItemID.MeteorStaff))
			{
				player.spaceGun = true;
			}
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
			recipe.AddIngredient(ItemType<Placeable.RefinedMeteoriteBar>(), 12);
			recipe.AddTile(TileType<Tiles.RefinedMeteoriteAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}