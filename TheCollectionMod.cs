using Terraria.ModLoader;

namespace TheCollectionMod
{
	public class TheCollectionMod : Mod
	{
		public static TheCollectionMod Instance;

		public override void Load()
		{
			Instance = this;
		}

		public override void Unload()
		{
			Instance = null;
		}

		public override void PostSetupContent()
		{
			Mod censusMod = ModLoader.GetMod("Census");
			if (censusMod != null)
			{
				censusMod.Call("TownNPCCondition", NPCType("Ninja"), "Slime King has been defeated");
				censusMod.Call("TownNPCCondition", NPCType("Meteorman"), "A player has 'Meteorman Heart' in their inventory.");
				censusMod.Call("TownNPCCondition", NPCType("Archeologist"), "A player has 'Rope Coil' in their inventory.");
			}
		}
    }
}

