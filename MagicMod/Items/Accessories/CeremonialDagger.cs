using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;


namespace MagicMod.Items.Accessories
{
	public class CeremonialDagger : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Casts spells using health if not enough mana is available\nOnly uses health when over 25% max health\nWill not stack with Blood Sigil");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.accessory = true;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Expert;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MagicModPlayer>().ceremonialKnife = true;
		}

		public override int ChoosePrefix(UnifiedRandom rand)
		{
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddIngredient(ModContent.ItemType<ManaCore>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
