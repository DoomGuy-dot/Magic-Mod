using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;


namespace MagicMod.Items.Accessories
{
	public class ManaCore : ModItem
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("Every 10 mana spent will restore 1 health\nThe Core's power will only show when infused with pure mana. Casting spells with Mana from a bottle will be ineffective...");

		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.material = true;

			item.accessory = true;
			item.defense = 2;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.expert = true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.RemoveAll(l => l.Name.EndsWith("Expert"));
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MagicModPlayer>().manaCore = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(ItemID.ManaCrystal, 2);
			recipe.AddIngredient(ItemID.StoneBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
