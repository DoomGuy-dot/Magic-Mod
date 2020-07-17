using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Buffs
{
    class ManaLock : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mana Lock");
			Description.SetDefault("You are in control... Restoring mana in:");

			Main.debuff[Type] = true; //prevents nurse heal
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.manaRegenDelay = 20; //removes mana regen delay
		}
	}
}
