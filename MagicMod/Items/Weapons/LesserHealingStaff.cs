using MagicMod.Items.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Weapons
{
	public class LesserHealingStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Lesser Healing Staff"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Restores 8 health (Affected by magic damage bonuses)");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;

			item.noMelee = true;
			item.magic = true;

			item.material = true;

			item.mana = 24;

			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item24;

			item.autoReuse = true;

			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Expert;
		}

        public override void OnConsumeMana(Player player, int manaConsumed)
        {
			int healAmount = (int)(8 * player.magicDamage);
			player.statLife += healAmount;
			player.HealEffect(healAmount, true);

			//player.AddBuff (too much health, decreased effectiveness)
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddIngredient(ModContent.ItemType<ManaCore>(), 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}