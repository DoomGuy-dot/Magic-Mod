using Microsoft.Xna.Framework;
using Steamworks;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MagicMod;

namespace MagicMod.Items.Weapons
{
	public class GreaterHealingStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Greater Healing Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Restores 40 health (This is the base amount, and is affected by damage bonuses)\nHealing amount is decreased by 50% if the player has the Mana Sickness debuff");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;

			item.noMelee = true;
			item.magic = true;

			item.mana = 80;

			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item24;

			item.autoReuse = true;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Expert;
		}

		public override void OnConsumeMana(Player player, int manaConsumed)
        {
			float healAmount = (int)(40 * (player.magicDamage + player.allDamage - 1));
			if (player.manaSick)
            {
				healAmount /= 2;
            }
			if (player.GetModPlayer<MagicModPlayer>().HealSickCheck())
            {
                healAmount *= 0.7f;
            }

			player.statLife += (int)healAmount;
            player.HealEffect((int)healAmount, true);
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<LesserHealingStaff>(), 1);
			recipe.AddIngredient(ItemID.PixieDust, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}