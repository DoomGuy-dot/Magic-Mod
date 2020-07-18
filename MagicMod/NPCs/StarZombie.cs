using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicMod.NPCs
{
	public class StarZombie : ModNPC
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Star Zombie");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;

			npc.damage = 25;
			npc.defense = 3;
			npc.lifeMax = 200;

			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;

			npc.value = 10000f;
			npc.knockBackResist = 0.1f;

			npc.aiStyle = 3;
			aiType = NPCID.Zombie;

			animationType = NPCID.Zombie;
			banner = Item.NPCtoBanner(NPCID.Zombie);
			bannerItem = Item.BannerToItem(banner);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldNightMonster.Chance * 0.2f;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(163, 166);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);

				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            base.OnHitPlayer(target, damage, crit);

			target.AddBuff(BuffID.ManaSickness, 600);
			target.AddBuff(BuffID.OnFire, 190);
			target.AddBuff(BuffID.Darkness, 310);
        }

        public override void NPCLoot()
        {
            base.NPCLoot();

			Item.NewItem(npc.getRect(), ItemID.FallenStar, 3);
		}
    }
}
