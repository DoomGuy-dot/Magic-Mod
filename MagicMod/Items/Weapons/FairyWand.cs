using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Weapons
{
	public class FairyWand : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Fairy Wand"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Looks like something from a cartoon.");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;

			item.noMelee = true;
			item.magic = true;

			item.damage = 8;
			item.knockBack = 6;
			item.mana = 6;
			item.crit = 33;

			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = SoundID.Item1;
			

			item.shoot = ProjectileID.FallingStar;
			item.shootSpeed = 12;

			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Expert;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 1);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}