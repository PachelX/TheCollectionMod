using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectionMod.Projectiles
{
	public class MeteorProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("MeteorProjectile");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Meteor1);
			aiType = ProjectileID.Meteor1;
			projectile.penetrate = 4;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 180;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = ProjectileID.Meteor1;
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			for (int i = 0; i < 5; i++) {
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ProjectileID.Meteor1, (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].aiStyle = 1;
				Main.projectile[a].tileCollide = true;
			}
			return true;
		}
	}
}