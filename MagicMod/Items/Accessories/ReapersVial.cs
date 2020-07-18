using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;


namespace MagicMod.Items.Accessories
{
	public class ReapersVial : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reaper's Vial");
			Tooltip.SetDefault("Dealing damage greatly boosts health and mana regen for 5 seconds.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.accessory = true;

			item.value = Item.sellPrice(0, 5, 0, 0);
			item.expert = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.RemoveAll(l => l.Name.EndsWith("Expert"));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MagicModPlayer>().reapersVial = true;
		}

		//public override int ChoosePrefix(UnifiedRandom rand)
		//{
		//	// When the item is given a prefix, only roll the best modifiers for accessories
		//	return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		//}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EssenceDropper>(), 1);
			recipe.AddIngredient(ModContent.ItemType<SoulDropper>(), 1);
			recipe.AddIngredient(ItemID.Ectoplasm, 4);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
