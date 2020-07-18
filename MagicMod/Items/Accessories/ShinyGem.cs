using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Accessories
{
    class ShinyGem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BasicSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Glows bright, even in darkness.\nIncreases maximum mana by 60 and reduces mana usage by 10%");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.accessory = true;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.expert = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.RemoveAll(l => l.Name.EndsWith("Expert"));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statManaMax2 += 60;

			player.manaCost -= 0.10f;
			player.AddBuff(BuffID.Shine, 1);
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LargeDiamond, 1);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddIngredient(ItemID.ShinePotion, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}