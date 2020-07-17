using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace MagicMod
{
	public class MagicMod : Mod
	{
        public override void AddRecipes()
        {
            ModRecipe altManaCrystalRecipe1 = new ModRecipe(this);
            altManaCrystalRecipe1.AddIngredient(ItemID.LifeCrystal, 1);
            altManaCrystalRecipe1.AddIngredient(ItemID.FallenStar, 1);
            altManaCrystalRecipe1.AddTile(TileID.WorkBenches);
            altManaCrystalRecipe1.SetResult(ItemID.ManaCrystal);
            altManaCrystalRecipe1.AddRecipe();

            ModRecipe altManaCrystalRecipe2 = new ModRecipe(this);
            altManaCrystalRecipe2.AddIngredient(ItemID.LifeCrystal, 1);
            altManaCrystalRecipe2.AddIngredient(ItemID.ManaPotion, 3);
            altManaCrystalRecipe2.AddTile(TileID.WorkBenches);
            altManaCrystalRecipe2.SetResult(ItemID.ManaCrystal);
            altManaCrystalRecipe2.AddRecipe();
        }
    }
}