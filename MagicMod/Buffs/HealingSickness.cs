using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod.Buffs
{
    class HealingSickness : ModBuff
    {
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Healing Sickness");
			Description.SetDefault("30% Decreased healing spell effectiveness!");

			Main.debuff[Type] = true;
		}
	}
}
