using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectionMod.Items.Weapons
{
	public class RefinedMeteorSword : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteor Wrath");
			Tooltip.SetDefault("Can fire meteoric waves");
			// Be sure to have "using Terraria.Localization".
			DisplayName.AddTranslation(GameCulture.Spanish, "Ira meteórica");
			Tooltip.AddTranslation(GameCulture.Spanish, "Dispara ondas meteóricas");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.StarWrath);
			item.shootSpeed *= 0.75f;
			item.damage = (int)(item.damage * 0.5f);
			item.width = 42;
			item.height = 50;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			type = (ushort)ProjectileType<Projectiles.MeteorProjectile>(); 
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
				target.AddBuff(BuffID.OnFire, 100);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Placeable.RefinedMeteoriteBar>(), 24);
			recipe.AddTile(TileType<Tiles.RefinedMeteoriteAnvil>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}