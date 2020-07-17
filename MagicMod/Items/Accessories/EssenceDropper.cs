using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;


namespace MagicMod.Items.Accessories
{
	public class EssenceDropper : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Dealing damage boosts mana regen for 3 seconds\nWill not stack with Reaper's Vial");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.material = true;

			item.accessory = true;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Expert;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MagicModPlayer>().essenceDropper = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand)
		{
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EmptyDropper, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.ManaCrystal, 3);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
