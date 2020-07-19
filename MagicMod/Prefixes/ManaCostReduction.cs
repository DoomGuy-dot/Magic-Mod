using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Prefixes
{
	class ManaCostReduction : ModPrefix
	{
		private readonly byte manaReduction = 0;

		public override float RollChance(Item item)
		{
			return 1f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

		public ManaCostReduction()
		{

		}

		public ManaCostReduction(byte manaReduction)
		{
			this.manaReduction = manaReduction;
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Curious", new ManaCostReduction(2));
				mod.AddPrefix("Imbued", new ManaCostReduction(4));
				mod.AddPrefix("Enchanted", new ManaCostReduction(6));
				mod.AddPrefix("Ancient", new ManaCostReduction(8));
			}
			return false;
		}

		public override void Apply(Item item)
			=> item.GetGlobalItem<PrefixItem>().manaReduction = manaReduction;

		public override void ModifyValue(ref float valueMult)
		{
			if (manaReduction == 2)
			{
				valueMult *= 1.05f;
			}

			if (manaReduction == 4)
			{
				valueMult *= 1.1f;
			}

			else if (manaReduction == 6)
			{
				valueMult *= 1.15f;
			}

			else if (manaReduction == 8)
			{
				valueMult *= 1.2f;
			}
		}
	}
}
