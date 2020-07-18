using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Prefixes
{
    class ManaRegen : ModPrefix
	{
		private readonly byte manaRegen = 0;

		public override float RollChance(Item item)
		{
			return 1f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

		public ManaRegen()
		{

		}

		public ManaRegen(byte manaRegen)
		{
			this.manaRegen = manaRegen;
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Twinkling", new ManaRegen(10));
				mod.AddPrefix("Shimmering", new ManaRegen(20));
				mod.AddPrefix("Sparkling", new ManaRegen(30));
				mod.AddPrefix("Glistening", new ManaRegen(40));
			}
			return false;
		}

		public override void Apply(Item item)
		{
			item.GetGlobalItem<PrefixItem>().manaRegen = manaRegen;
		}

		public override void ModifyValue(ref float valueMult)
		{
			if (manaRegen == 10)
			{
				valueMult *= 1.05f;
			}

			if (manaRegen == 20)
			{
				valueMult *= 1.1f;
			}

			else if (manaRegen == 30)
			{
				valueMult *= 1.15f;
			}

			else if (manaRegen == 40)
			{
				valueMult *= 1.2f;
			}
		}
	}
}
