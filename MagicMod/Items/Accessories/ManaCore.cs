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

			Tooltip.SetDefault("Every 10 mana spent will restore 1 health.");

		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.material = true;

			item.accessory = true;
			item.defense = 2;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Expert;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MagicModPlayer>().manaCore = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand)
		{
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
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
