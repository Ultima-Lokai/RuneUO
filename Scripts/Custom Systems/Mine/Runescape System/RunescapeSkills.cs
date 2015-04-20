using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server.Custom
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

    /*
     Logs: Normal, Oak, Willow, Maple, Yew, Magic, Mahogany, Teak
     Ore: Copper, Tin, Clay, Iron, Silver, Gold, Coal, Mithril, Adamantite, RuneOre, RuneEssence
     Bars: Bronze, Iron, Silver, Gold, Mithril, Adamantite, Rune
     Bows: Regular, Oak, Willow, Maple, Yew, Magic
     Fish: Sardine, Mackerel, Anchovie, Shrimp, Pike, Salmon, Trout, Bass, Lobster, Swordfish, Shark, Eel, MantaRay, Turtle
     Jewelry: Necklace, Ring, Amulet, Bracelet, Tiara
     Gem: Sapphire, Emerald, Ruby, Diamond, Dragonstone, Opal, Jade, Topaz
     Runes: Body, Mind, Air, Water, Earth, Fire, Chaos, Nature, Cosmic, Law, Astral, Soul, Blood
     Hides: CowHide, GreenDragonHide, BlueDragonHide, RedDragonHide, BlackDragonHide
     Leather: Leather, HardLeather, GreenDragonLeather, BlueDragonLeather, RedDragonLeather, BlackDragonLeather
     
     
     */

    class RunescapeSkills
    {
        public static void Initialize()
        {
            Console.WriteLine("Exp needed from Level 1 - Level 45: " + ShowSkillNeeded(2, 45) + " xp");
            Console.WriteLine("Exp needed from Level 45 - Level 99: " + ShowSkillNeeded(45, 99) + " xp");
            Console.WriteLine("Exp needed from Level 1 - Level 99: " + ShowSkillNeeded(2, 99) + " xp");
        }

        public static int ShowSkillNeeded(int currentLevel, int desiredLevel)
        {
            int totalpoints = 0;
            int mypoints = 0;

            for (int lvl = 1; lvl < desiredLevel; lvl++)
            {
                totalpoints += (int)Math.Floor(lvl + 300 * Math.Pow(2, (double)lvl / 7));
                if (lvl == currentLevel)
                    mypoints = totalpoints;
            }
            return (int)Math.Floor((double)(totalpoints - mypoints) / 4);
        }
    }
}
