using IL.Terraria.GameContent.Events;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectionMod.Buffs
{
    public class ShurikenjutsuBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing

            if (Main.hardMode)
            {
                DisplayName.SetDefault("Shuriken Jutsu v9");
                DisplayName.AddTranslation(GameCulture.Spanish, "Arte Ninja - Shuriken v9");
                Description.SetDefault(" +200% Increases throwing damage"
                    + "\n+60% increased throwing critical strike chance."
                    + "\n+60% increased throwing speed.");
                Description.AddTranslation(GameCulture.Spanish, "+200% de daño a las armas arrojadizas."
                    + "\n+60% probabilidad de crítico."
                    + "\n+60% velocidad de lanzamiento a las armas arrojadizas.");
            }
            else if (NPC.downedBoss3)
            {
                DisplayName.SetDefault("Shuriken Jutsu v4");
                DisplayName.AddTranslation(GameCulture.Spanish, "Arte Ninja - Shuriken v4");
                Description.SetDefault(" +60% Increases throwing damage"
                    + "\n+60% increased throwing critical strike chance."
                    + "\n+60% increased throwing speed.");
                Description.AddTranslation(GameCulture.Spanish, "+60% de daño a las armas arrojadizas."
                    + "\n+60% probabilidad de crítico."
                    + "\n+60% velocidad de lanzamiento a las armas arrojadizas.");
            }
            else if (NPC.downedBoss2)
            {
                DisplayName.SetDefault("Shuriken Jutsu v3");
                DisplayName.AddTranslation(GameCulture.Spanish, "Arte Ninja - Shuriken v3");
                Description.SetDefault(" +50% Increases throwing damage"
                    + "\n+50% increased throwing critical strike chance."
                    + "\n+50% increased throwing speed.");
                Description.AddTranslation(GameCulture.Spanish, "+50% de daño a las armas arrojadizas."
                    + "\n+50% probabilidad de crítico."
                    + "\n+50% velocidad de lanzamiento a las armas arrojadizas.");
            }
            else if (NPC.downedBoss1)
            {
                DisplayName.SetDefault("Shuriken Jutsu v2");
                DisplayName.AddTranslation(GameCulture.Spanish, "Arte Ninja - Shuriken v2");
                Description.SetDefault(" +40% Increases throwing damage"
                    + "\n+40% increased throwing critical strike chance."
                    + "\n+40% increased throwing speed.");
                Description.AddTranslation(GameCulture.Spanish, "+40% de daño a las armas arrojadizas."
                    + "\n+40% probabilidad de crítico."
                    + "\n+40% velocidad de lanzamiento a las armas arrojadizas.");
            }
            else
            {
                DisplayName.SetDefault("Shuriken Jutsu");
                DisplayName.AddTranslation(GameCulture.Spanish, "Arte Ninja - Shuriken");
                Description.SetDefault(" +30% Increases throwing damage"
                    + "\n+30% increased throwing critical strike chance."
                    + "\n+30% increased throwing speed.");
                Description.AddTranslation(GameCulture.Spanish, "+30% de daño a las armas arrojadizas."
                    + "\n+30% probabilidad de crítico."
                    + "\n+30% velocidad de lanzamiento a las armas arrojadizas.");
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (NPC.downedMoonlord)
            {
                player.thrownVelocity += 20f;
                player.thrownDamage += 20f;
                player.thrownCrit += 2000;
            }
            else if (NPC.downedTowers)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (NPC.downedAncientCultist)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (NPC.downedFishron)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (DD2Event.DownedInvasionT1)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (NPC.downedBoss3)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (NPC.downedBoss3)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (NPC.downedBoss3)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (NPC.downedBoss3)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 600;
            }
            else if (NPC.down)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 200;
            }
            else if (NPC.downedQueenBee)
            {
                player.thrownVelocity += 6f;
                player.thrownDamage += 6f;
                player.thrownCrit += 200;
            }
            else if (NPC.downedBoss2)
            {
                player.thrownVelocity += 0.5f;
                player.thrownDamage += 0.5f;
                player.thrownCrit += 150;
            }
            else if (NPC.downedBoss1)
            {
                player.thrownVelocity += 0.4f;
                player.thrownDamage += 0.4f;
                player.thrownCrit += 100;
            }
            else if (NPC.downedSlimeKing)
            {
                player.thrownVelocity += 1f;
                player.thrownDamage += 1f;
                player.thrownCrit += 50;
            }
            else 
            {
                player.thrownVelocity += 0.25f;
                player.thrownDamage += 0.25f;
                player.thrownCrit += 25;
            }
        }
    }
}