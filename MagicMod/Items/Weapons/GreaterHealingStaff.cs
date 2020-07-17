using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Weapons
{
	public class GreaterHealingStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Greater Healing Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Restores 50 health (Affected by magic damage bonuses)");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;

			item.material = true;

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
			int healAmount = (int)(50 * player.magicDamage);
			player.statLife += healAmount;
			player.HealEffect(healAmount, true);

			//player.AddBuff (too much health, decreased effectiveness)
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