using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Accessories.Sigils
{
    class ManaSigil : Sigils
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BasicSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Devote yourself to the way of Mana\nGreatly increased mana regen\n200 increased maximum mana\n10% decreased magic damage");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.accessory = true;

			item.value = Item.sellPrice(0, 0, 10, 0);
			item.expert = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.RemoveAll(l => l.Name.EndsWith("Expert"));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.magicDamage -= 0.10f;

			player.manaRegenBonus += 400;

			player.statManaMax2 += 200;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(ItemID.ManaCrystal, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}