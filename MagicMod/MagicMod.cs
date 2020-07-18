using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using MagicMod.Items;

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

            ModRecipe altlifeCrystalRecipe1 = new ModRecipe(this);
            altlifeCrystalRecipe1.AddIngredient(ItemID.ManaCrystal, 1);
            altlifeCrystalRecipe1.AddIngredient(ItemID.HealingPotion, 3);
            altlifeCrystalRecipe1.AddTile(TileID.WorkBenches);
            altlifeCrystalRecipe1.SetResult(ItemID.ManaCrystal);
            altlifeCrystalRecipe1.AddRecipe();
        }

        public class NPCShopChanges : GlobalNPC
        {
            public override void SetupShop(int type, Chest shop, ref int nextSlot)
            {
                switch (type)
                {
                    case NPCID.Merchant:

                        shop.item[nextSlot].SetDefaults(ItemID.FallenStar);
                        nextSlot++;

                        break;
                }
            }
        }
    }
}