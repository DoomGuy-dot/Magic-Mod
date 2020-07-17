using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Prefixes
{
    class Enchanted : ModPrefix
    {
        public override bool CanRoll(Item item)

            => true;

        public override PrefixCategory Category

            => PrefixCategory.Accessory;
    }
}
