using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Buffs
{
    class ManaSiphon : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mana Siphon");
			Description.SetDefault("Extracting essence... Increased mana regen!");

			Main.debuff[Type] = false; //prevents nurse heal
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.manaRegenBonus += 20; //bonus mana regen while active
			player.manaRegenDelayBonus += 5; //removes mana regen delay
		}
	}
}
