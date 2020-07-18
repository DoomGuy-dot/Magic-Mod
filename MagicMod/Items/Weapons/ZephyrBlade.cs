using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Weapons
{
	public class ZephyrBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zephyr's Blade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The divine blade of Zephyr, Master of the Wind.");
		}

		public override void SetDefaults() 
		{
			item.width = 60;
			item.height = 60;

			item.magic = true;

			item.mana = 0;

			item.damage = 100;
			item.knockBack = 12;
			item.crit = 10;

			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.shoot = ProjectileID.TerraBeam;
			item.shootSpeed = 20;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Expert;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(ItemID.ManaCrystal, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}