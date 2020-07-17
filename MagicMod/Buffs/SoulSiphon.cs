using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Buffs
{
    class SoulSiphon : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("True Soul Siphon");
			Description.SetDefault("The reaper is stealing souls...");

			Main.debuff[Type] = false; //prevents nurse heal
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 10; //bonus health regen while active
			player.manaRegenBonus += 40; //bonus mana regen while active
			player.manaRegenDelayBonus += 10; //removes mana regen delay
		}
	}
}
