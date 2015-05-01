using System;
using Server.Commands;
using Server.Items;
using Server.Network;

namespace Server.Runescape
{
    public static class Utilities
    {
        public static int Hue(Gems gemType)
        {
            switch (gemType)
            {
                case Gems.Sapphire:
                    return 0x62;
                case Gems.Emerald:
                    return 0x48;
                case Gems.Ruby:
                    return 0x25;
                case Gems.Diamond:
                    return 0x7FE;
                case Gems.Opal:
                    return 0x903;
                case Gems.Jade:
                    return 0x243;
                case Gems.Topaz:
                    return 0x210;
                case Gems.Dragonstone:
                    return 0x139;
            }
            return 0;
        }
        public static int Hue(Ores oreType)
        {
            switch (oreType)
            {
                case Ores.Adamantite:
                    return 0x363;
                case Ores.Clay:
                    return 0x222;
                case Ores.Coal:
                    return 0x7E3;
                case Ores.Copper:
                    return 0x466;
                case Ores.Gold:
                    return 0x501;
                case Ores.Iron:
                    return 0x21F;
                case Ores.Mithril:
                    return 0x18A;
                case Ores.RuneEssence:
                    return 0x7C4;
                case Ores.Rune:
                    return 0xBC;
                case Ores.Silver:
                    return 0x47E;
                case Ores.Tin:
                    return 0x764;
            }
            return 0;
        }

        public static int Hue(RuneWeaponType weapType)
        {
            switch (weapType)
            {
                case RuneWeaponType.Bronze:
                    return 0x46B;
                case RuneWeaponType.Iron:
                    return 0x349;
                case RuneWeaponType.Silver:
                    return 0x47E;
                case RuneWeaponType.Steel:
                    return 0x358;
                case RuneWeaponType.Black:
                    return 0x7E3;
                case RuneWeaponType.Gold:
                    return 0x501;
                case RuneWeaponType.Mithril:
                    return 0x18A;
                case RuneWeaponType.Adamantite:
                    return 0x363;
                case RuneWeaponType.Rune:
                    return 0xBC;
                case RuneWeaponType.Dragon:
                    return 0x151;
            }
            return 0;
        }

        public static bool CanUse(Mobile runescapeMobile, Item runescapeItem)
        {

            return true;
        }

        public static bool CanWield(Mobile runescapeMobile, Item runescapeWeapon)
        {

            return true;
        }

        public static bool CanWear(Mobile runescapeMobile, Item runescapeArmor)
        {

            return true;
        }

        public static BaseRunescapeGem FindGem(Mobile from, Ores oreType, RunescapePickaxe pick)
        {
            BaseRunescapeGem gem = null;
            double chance = 0.005; // Half of 1%
            Item necklace = from.FindItemOnLayer(Layer.Neck);
            if (necklace != null && necklace is AmuletOfGlory)
                chance = 0.015; // Increased to 1.5% chance if wearing Glory Ammy
            chance = oreType >= Ores.Mithril ? chance + 0.005 : chance; // increased by another half percent if Mith rock and above
            chance = pick.WeaponType >= RuneWeaponType.Mithril ? chance + 0.005 : chance; // increased by another half percent if Mith pick and above

            if (chance > Utility.RandomDouble())
            {
                int select = Utility.Random(100);

                if (select>97) gem=new DiamondGem();
                else if (select>90) gem = new RubyGem();
                else if (select>60) gem=new EmeraldGem();
                else gem = new SapphhireGem();
            }

            return gem;
        }

        public static int AttackLevelNeeded(RuneWeaponType toWieldWeapon)
        {
            switch (toWieldWeapon)
            {
                case RuneWeaponType.Steel:
                    return 5;
                case RuneWeaponType.Black:
                    return 10;
                case RuneWeaponType.Mithril:
                    return 20;
                case RuneWeaponType.Adamantite:
                case RuneWeaponType.BattleStaff:
                    return 30;
                case RuneWeaponType.Rune:
                    return 40;
                case RuneWeaponType.AncientStaff:
                    return 50;
                case RuneWeaponType.Dragon:
                    return 60;
                case RuneWeaponType.Bronze:
                case RuneWeaponType.Iron:
                default:
                    return 1;
            }
        }

        public static int DefenseLevelNeeded(RuneArmorType toWearArmor)
        {
            switch (toWearArmor)
            {
                case RuneArmorType.Leather:
                case RuneArmorType.Bronze:
                case RuneArmorType.Iron:
                    return 1;
                case RuneArmorType.Steel:
                    return 5;
                case RuneArmorType.HardLeather:
                case RuneArmorType.StuddedLeather:
                    return 10;
                case RuneArmorType.Mithril:
                    return 20;
                case RuneArmorType.Adamantite:
                    return 30;
                case RuneArmorType.Rune:
                case RuneArmorType.GreenDragonHide:
                case RuneArmorType.BlueDragonHide:
                case RuneArmorType.RedDragonHide:
                case RuneArmorType.BlackDragonHide:
                    return 40;
                case RuneArmorType.Dragon:
                    return 60;
                default:
                    return 1;
            }
        }

        public static int MiningLevelNeeded(RuneWeaponType toWieldPickaxe)
        {
            switch (toWieldPickaxe)
            {
                case RuneWeaponType.Steel:
                    return 6;
                case RuneWeaponType.Mithril:
                    return 21;
                case RuneWeaponType.Adamantite:
                    return 31;
                case RuneWeaponType.Rune:
                    return 41;
                case RuneWeaponType.Dragon:
                    return 61;
                case RuneWeaponType.Bronze:
                case RuneWeaponType.Iron:
                default:
                    return 1;
            }
        }

        public static int MiningLevelNeeded(Ores toMineOre)
        {
            switch (toMineOre)
            {
                case Ores.Adamantite:
                    return 70;
                case Ores.Clay:
                    return 1;
                case Ores.Coal:
                    return 30;
                case Ores.Copper:
                    return 1;
                case Ores.Gold:
                    return 40;
                case Ores.Iron:
                    return 15;
                case Ores.Mithril:
                    return 55;
                case Ores.RuneEssence:
                    return 5;
                case Ores.Rune:
                    return 85;
                case Ores.Silver:
                    return 20;
                case Ores.Tin:
                default:
                    return 1;
            }
        }

        public static double RespawnSeconds(Ores ores)
        {
            double spawnTime = 2.0;
            int count = NetState.Instances.Count > 200 ? 200 : NetState.Instances.Count < 10 ? 10 : NetState.Instances.Count;
            double discount = 1 - (double)count / 400.0;
            switch (ores)
            {
                case Ores.Copper:
                case Ores.Tin:
                    spawnTime = 4.0;
                    break;
                case Ores.Iron:
                    spawnTime = 10.0;
                    break;
                case Ores.Silver:
                    spawnTime = 90.0;
                    break;
                case Ores.Gold:
                    spawnTime = 120.0;
                    break;
                case Ores.Coal:
                    spawnTime = 60.0;
                    break;
                case Ores.Mithril:
                    spawnTime = 240.0;
                    break;
                case Ores.Adamantite:
                    spawnTime = 480.0;
                    break;
                case Ores.Rune:
                    spawnTime = 1500.0;
                    break;
                case Ores.Clay:
                case Ores.RuneEssence:
                default:
                    spawnTime = 2.0;
                    break;
            }
            return spawnTime * discount;
        }
    }

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
        Steel,
        Silver,
        Gold,
        Mithril,
        Adamantite,
        Rune
    }

    public enum RuneWeaponType
    {
        Bronze,
        Iron,
        Silver,
        Steel,
        Black,
        Gold,
        Mithril,
        Adamantite,
        Rune,
        BattleStaff,
        AncientStaff,
        Dragon
    }

    public enum RuneArmorType
    {
        Leather,
        HardLeather,
        StuddedLeather,
        Bronze,
        Iron,
        Steel,
        GreenDragonHide,
        Mithril,
        BlueDragonHide,
        Adamantite,
        RedDragonHide,
        Rune,
        BlackDragonHide,
        Dragon
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
        Opal,
        Jade,
        Topaz,
        Sapphire,
        Emerald,
        Ruby,
        Diamond,
        Dragonstone
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
