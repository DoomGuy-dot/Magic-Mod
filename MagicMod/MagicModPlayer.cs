using IL.Terraria.GameContent.Shaders;
using MagicMod.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework.Input;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Shaders;

namespace MagicMod
{
    class MagicModPlayer : ModPlayer
    {
        public bool manaCore; //restores health when spending mana
        public int manaCoreCounter;

        public bool essenceDropper; //dealing damage boosts mana regen
        public bool soulDropper; //dealing damage boosts health regen

        public bool reapersVial; //dealing damage greatly boosts health and mana regen
        public int manaCounter;

        public bool ceremonialKnife; //spends health instead of mana

        public bool bloodSigil; //spends health instead of mana, 80% reduced health cost
        public int bloodCost;

        public bool chaosSigil; //randomly modifies spell damage and cost by 50%

        public bool controlSigil; //no mana regen for 30 seconds

        //public bool soulRobe; 


		public override void ResetEffects()
		{
			manaCore = false;

            essenceDropper = false;
            soulDropper = false;
            reapersVial = false;

            ceremonialKnife = false;

            bloodSigil = false;
            bloodCost = 0;

            chaosSigil = false;
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (proj.magic)
            {
                if (reapersVial)
                {
                    player.AddBuff(BuffType<Buffs.SoulSiphon>(), 310);
                }
                else
                {
                    if (essenceDropper)
                    {
                        player.AddBuff(BuffType<Buffs.ManaSiphon>(), 190);
                    }

                    if (soulDropper)
                    {
                        player.AddBuff(BuffType<Buffs.HealthSiphon>(), 190);
                    }
                }
            }
        }

        public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
        {
            if (bloodSigil)
            {
                if (player.statLife * 4 > player.statLifeMax2)
                {
                    bloodCost = (int)(item.mana * 0.2f);
                    mult = 0;
                }
                else
                {
                    mult = 1000;
                }
            }
        }

        public override void UpdateLifeRegen()
        {
            if (player.HasBuff(BuffType<Buffs.ManaSiphon>()))
            {
                int num = 6;
                manaCounter++; // 10 mana regen/s
                if (manaCounter >= num)
                {
                    manaCounter -= num;
                    player.statMana++;
                    if (player.statMana >= player.statManaMax2)
                    {
                        player.statMana = player.statManaMax2;
                    }
                }
            }
            
            if (player.HasBuff(BuffType<Buffs.SoulSiphon>()))
            {
                int num = 6;
                manaCounter += 3; // 30 mana regen/s
                if (manaCounter >= num)
                {
                    manaCounter -= num;
                    player.statMana++;
                    if (player.statMana >= player.statManaMax2)
                    {
                        player.statMana = player.statManaMax2;
                    }
                }
            }
        }

        public override void OnConsumeMana(Item item, int manaConsumed)
        {
            if (manaCore && !player.manaSick)
            {
                manaCoreCounter += manaConsumed;
                if (manaCoreCounter > 10)
                {
                    if (player.statLife < player.statLifeMax2)
                    {
                        player.statLife += 1;
                    }
                    manaCoreCounter -= 10;
                }
            }

            if (bloodSigil)
            {
                if (player.statLife * 4 > player.statLifeMax2)
                {
                    player.statLife -= bloodCost;
                    player.lifeRegenTime -= 20;
                }
            }

            if (controlSigil)
            {
                player.AddBuff(BuffType<Buffs.ManaLock>(), 30 * 60 + 10);
            }
        }

        public override void OnMissingMana(Item item, int neededMana)
        {
            if (ceremonialKnife)
            {
                if (player.statLife * 4 > player.statLifeMax2)
                {
                    player.statMana += neededMana;
                    player.statLife -= neededMana;
                }
            }
        }
    }
}
