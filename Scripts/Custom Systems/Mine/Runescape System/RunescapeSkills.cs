using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Server.Commands;

namespace Server.Runescape
{
    public enum RuneSkillName
    {
        Agility, // Hiding/Stealth/ ***New Content
        Attack, // Swords/Fencing/Macing/Throwing
        Construction, // Carpentry
        Cooking, // Cooking
        Crafting, // Tailoring/Tinkering/
        Defense, // Parrying
        Divining, // SpiritSpeak/Mysticism
        Farming, // ***New Content
        Firemaking, // Camping
        Fishing, // Fishing
        Fletching, // Bowcraft
        Herblore, // Alchemy
        Hitpoints, // Anatomy
        Hunter, // Tracking
        Magic, // Magery
        Mining, // Mining
        Prayer, // Spirit Speak/Meditation/Chivalry
        Ranged, // Archery
        Runecrafting, // Spellweaving/ ***New Content
        Slayer, // ***New Content
        Smithing, // Smithing
        Strength, // Wrestling
        Summoning, // Magery/AnimalLore/Herding/AnimalTaming
        Thieving, // Stealing/Hiding/Snooping/RemoveTrap/Lockpicking
        Woodcutting // Lumberjacking
    }

    public enum Logs
    {
        Normal,
        Oak,
        Willow,
        Maple,
        Yew,
        Magic,
        Mahogany,
        Teak
    }

    public enum Ores
    {
        Copper,
        Tin,
        Clay,
        Iron,
        Silver,
        Gold,
        Coal,
        Mithril,
        Adamantite,
        Rune,
        RuneEssence
    }

    public enum Bars
    {
        Bronze,
        Iron,
        Silver,
        Gold,
        Mithril,
        Adamantite,
        Rune
    }

    public enum Bows
    {
        Regular,
        Oak,
        Willow,
        Maple,
        Yew,
        Magic
    }

    public enum Fish
    {
        Sardine,
        Mackerel,
        Anchovie,
        Shrimp,
        Pike,
        Salmon,
        Trout,
        Bass,
        Lobster,
        Swordfish,
        Shark,
        Eel,
        MantaRay,
        Turtle
    }

    public enum Jewelry
    {
        Necklace,
        Ring,
        Amulet,
        Bracelet,
        Tiara
    }

    public enum Gems
    {
        Sapphire,
        Emerald,
        Ruby,
        Diamond,
        Dragonstone,
        Opal,
        Jade,
        Topaz
    }

    public enum Runes
    {
        Body,
        Mind,
        Air,
        Water,
        Earth,
        Fire,
        Chaos,
        Nature,
        Cosmic,
        Law,
        Astral,
        Soul,
        Blood
    }

    public enum Hides
    {
        CowHide,
        GreenDragonHide,
        BlueDragonHide,
        RedDragonHide,
        BlackDragonHide
    }

    public enum Leathers
    {
        Leather,
        HardLeather,
        GreenDragonLeather,
        BlueDragonLeather,
        RedDragonLeather,
        BlackDragonLeather
    }


    internal class RunescapeSkills
    {
        public static void Initialize()
        {
            Console.WriteLine("Exp needed from Level 1 - Level 45: " + ShowSkillNeeded(2, 45) + " xp");
            Console.WriteLine("Exp needed from Level 45 - Level 99: " + ShowSkillNeeded(45, 99) + " xp");
            Console.WriteLine("Exp needed from Level 1 - Level 99: " + ShowSkillNeeded(2, 99) + " xp");

            CommandSystem.Register("AnimateMe", AccessLevel.GameMaster, new CommandEventHandler(AnimateMe_OnCommand));
        }

        public static int ShowSkillNeeded(int currentLevel, int desiredLevel)
        {
            int totalpoints = 0;
            int mypoints = 0;

            for (int lvl = 1; lvl < desiredLevel; lvl++)
            {
                totalpoints += (int) Math.Floor(lvl + 300*Math.Pow(2, (double) lvl/7));
                if (lvl == currentLevel)
                    mypoints = totalpoints;
            }
            return (int) Math.Floor((double) (totalpoints - mypoints)/4);
        }



        [Usage("AnimateMe <action>")]
        [Description("Makes your character do a specified animation.")]
        public static void AnimateMe_OnCommand(CommandEventArgs e)
        {
            if (e.Length == 1)
            {
                e.Mobile.Animate(e.GetInt32(0), 8, 1, true, false, 0);
            }
            else
            {
                e.Mobile.SendMessage("Format: AnimateMe <action> ");
            }
        }
    }
}
