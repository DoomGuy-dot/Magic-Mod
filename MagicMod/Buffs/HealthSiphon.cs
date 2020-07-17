using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Buffs
{
    class HealthSiphon : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Health Siphon");
			Description.SetDefault("Extracting souls... Increased health regen!");

			Main.debuff[Type] = false; //prevents nurse heal
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 5; //bonus health regen while active
		}
	}
}
