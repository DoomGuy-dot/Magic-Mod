using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace MagicMod
{
    public class PrefixItem : GlobalItem
    {
        public int manaReduction;
        public int manaRegen;

        public PrefixItem()
        {
            manaReduction = 0;
            manaRegen = 0;
        }

        public override bool InstancePerEntity => true;

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            PrefixItem myClone = (PrefixItem)base.Clone(item, itemClone);

            myClone.manaReduction = manaReduction;
            myClone.manaRegen = manaRegen;

            return myClone;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!item.social && item.prefix > 0)
            {
                int bonus = manaReduction - Main.cpItem.GetGlobalItem<PrefixItem>().manaReduction;

                if (bonus > 0)
                {
                    TooltipLine line = new TooltipLine(mod, "ManaPrefix", "+" + bonus + "% Reduced Mana Usage");
                    line.isModifier = true;
                    tooltips.Add(line);
                }
            }

            if (!item.social && item.prefix > 0)
            {
                int bonus = manaRegen - Main.cpItem.GetGlobalItem<PrefixItem>().manaRegen;

                if (bonus > 0)
                {
                    TooltipLine line = new TooltipLine(mod, "ManaPrefix", "+" + bonus / 2 + " Mana Regen");
                    line.isModifier = true;
                    tooltips.Add(line);
                }
            }
        }

        public override bool NewPreReforge(Item item)
        {
            manaReduction = 0;
            manaRegen = 0;
            return base.NewPreReforge(item);
        }


        public override void UpdateEquip(Item item, Player player)
        {
            if (item.GetGlobalItem<PrefixItem>().manaReduction > 0)
            {
                player.manaCost -= manaReduction / 100f;
                //player.statManaMax2 -= manaReduction; //"mana reduction variable equals 8: Confirmed"
            }
            
            if (item.GetGlobalItem<PrefixItem>().manaRegen > 0)
            {
                player.manaRegenBonus += manaRegen;
                player.manaRegenDelayBonus += manaRegen / 20;
            }
        }

        public override void NetSend(Item item, BinaryWriter writer)
        {
            writer.Write(manaReduction);
            writer.Write(manaRegen);
        }

        public override void NetReceive(Item item, BinaryReader reader)
        {
            manaReduction = reader.ReadByte();
            manaRegen = reader.ReadByte();
        }
    }
}