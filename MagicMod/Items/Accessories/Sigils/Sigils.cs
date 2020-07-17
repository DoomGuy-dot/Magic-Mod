using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.Items.Accessories.Sigils
{
	public abstract class Sigils : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;

			item.accessory = true;

			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = ItemRarityID.Expert;
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			// To prevent the accessory from being equipped, we need to return false if there is one already in another slot
			// Therefore we go through each accessory slot ignoring vanity slots using FindDifferentEquippedExclusiveAccessory()
			// which we declared in this class below

			if (slot < 10) // This allows the accessory to equip in vanity slots with no reservations
			{
				// Here we use named ValueTuples and retrieve the index of the item, since this is what we need here
				int index = FindDifferentEquippedExclusiveAccessory().index;

				if (index != -1)
				{
					return slot == index;
				}
			}
			// Here we want to respect individual items having custom conditions for equipability
			return base.CanEquipAccessory(player, slot);
		}


		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			// Here we want to add a tooltip to the item if it can be swapped with another one of its kind
			// Therefore we retrieve the accessory from the ValueTuple, because the index isn't needed here
			Item accessory = FindDifferentEquippedExclusiveAccessory().accessory;

			if (accessory != null)
			{
				tooltips.Add(new TooltipLine(mod, "Swap", "Right click to swap with '" + accessory.Name + "'!"){overrideColor = Color.OrangeRed});
			}
		}

		public override bool CanRightClick()
		{
			// An intricacy of vanilla is that it directly swaps the items on right click if the items are the same and just their prefixes differ,
			// even in vanity slots. For this, FindDifferentEquippedExclusiveAccessory() doesn't find these items
			// That means, if for whatever reason you have Green equipped, Yellow in a vanity slot, and then right click a Yellow item in your inventory
			// that has a different prefix than the vanity Yellow, it will swap with the vanity Yellow instead of the equipped Green
			// Therefore we need to reimplement this behavior by doing the following check

			// Check vanity accessory slots for the same item type equipped and return false (so vanilla handles it)
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;

			for (int i = 13; i < 13 + maxAccessoryIndex; i++)
			{
				if (Main.LocalPlayer.armor[i].type == item.type) return false;
			}

			// Only allow right clicking if there is a different ExclusiveAccessory equipped

			if (FindDifferentEquippedExclusiveAccessory().accessory != null)
			{
				return true;
			}
			// If this hook returns true, the item is consumed (just like crates and boss bags)
			return base.CanRightClick();
		}

		public override void RightClick(Player player)
		{
			// Here we implement the "swapping" when right clicked to equip this item inplace of another one
			// Because we need both index and accessory, we "unpack" this ValueTuple like this:
			var (index, accessory) = FindDifferentEquippedExclusiveAccessory();

			if (accessory != null)
			{
				Main.LocalPlayer.QuickSpawnClonedItem(accessory);
				// We need to use index instead of accessory because we directly want to alter the equipped accessory
				Main.LocalPlayer.armor[index] = item.Clone();
			}
		}

		protected (int index, Item accessory) FindDifferentEquippedExclusiveAccessory()
		{
			int maxAccessoryIndex = 5 + Main.LocalPlayer.extraAccessorySlots;

			for (int i = 3; i < 3 + maxAccessoryIndex; i++)
			{
				Item otherAccessory = Main.LocalPlayer.armor[i];
				// IsAir makes sure we don't check for "empty" slots
				// IsTheSameAs() compares two items and returns true if their types match
				// "is ExclusiveAccessory" is a way of performing pattern matching
				// Here, inheritance helps us determine if the given item is indeed one of our ExclusiveAccessory ones
				if (!otherAccessory.IsAir && !item.IsTheSameAs(otherAccessory) && otherAccessory.modItem is Sigils)
				{
					// If we find an item that matches these criteria, return both the index and the item itself
					// The second argument is just for convenience, technically we don't need it since we can get the item from just i
					return (i, otherAccessory);
				}
			}
			// If no item is found, we return default values for index and item, always check one of them with this default when you call this method!
			return (-1, null);
		}
	}
}
