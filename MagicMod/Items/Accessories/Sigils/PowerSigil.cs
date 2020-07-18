using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Accessories.Sigils
{
    class PowerSigil : Sigils
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BasicSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Devote yourself to the way of Power\n30% increased magic damage and critical strike chance\n20% increased mana cost\nMana costs are doubled if the player has the Mana Sickness debuff");
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
			player.magicDamage += 0.30f;
			player.magicCrit += 30;
			player.manaCost += 0.20f;

			player.GetModPlayer<MagicModPlayer>().powerSigil = true;
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