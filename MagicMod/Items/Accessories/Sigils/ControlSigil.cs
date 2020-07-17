using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Accessories.Sigils
{
    class ControlSigil : Sigils
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BasicSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Devote yourself to the way of Control\n+30 second mana regen delay\n75% reduced mana usage\n100 increased maximum mana");
		} // need to change mana regen delay to remove natural mana regen somehow, or make the regen delay go away upon removing the accessory

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.accessory = true;

			item.value = Item.sellPrice(0, 0, 10, 0);
			item.rare = ItemRarityID.Expert;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.manaRegenDelayBonus -= 30;
			player.manaCost *= 0.25f;
			player.statManaMax2 += 100;
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