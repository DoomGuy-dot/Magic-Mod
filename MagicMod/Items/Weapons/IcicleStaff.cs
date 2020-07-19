using MagicMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace MagicMod.Items.Weapons
{
	public class IcicleStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Icicle Staff - WIP"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Creates a magical Icicle that deals more damages the longer it falls\n-----WORK IN PROGRESS-----");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
			item.height = 24;

			item.noMelee = true;
			item.magic = true;

			item.damage = 24;
			item.knockBack = 4;
			item.mana = 4;
			item.crit = 10;

			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.shoot = ProjectileType<IcicleSpike>();
			item.shootSpeed = 10f;

			item.value = Item.sellPrice(0, 0, 20, 0);
			item.rare = ItemRarityID.Expert;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            //return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);

			Projectile.NewProjectile(new Vector2 (Main.MouseWorld.X -4, Main.MouseWorld.Y), new Vector2(0f, 0f), ProjectileType<IcicleSpike>(), damage, knockBack, player.whoAmI, 0f, 0f);

			return false;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 80);
			recipe.AddIngredient(ItemID.BorealWood, 12);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}