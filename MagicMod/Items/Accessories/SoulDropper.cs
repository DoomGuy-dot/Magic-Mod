using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;


namespace MagicMod.Items.Accessories
{
	public class SoulDropper : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Dealing damage boosts health regen for 3 seconds\nWill not stack with Reaper's Vial");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.material = true;

			item.accessory = true;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Expert;
			item.expert = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.RemoveAll(l => l.Name.EndsWith("Expert"));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MagicModPlayer>().soulDropper = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EmptyDropper, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
