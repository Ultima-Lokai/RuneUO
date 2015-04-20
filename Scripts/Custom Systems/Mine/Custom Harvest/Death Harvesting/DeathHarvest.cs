using System;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Engines.Harvest
{
    public class DeathHarvest : HarvestSystem
    {
        private static DeathHarvest m_System;

        public static DeathHarvest System
        {
            get
            {
                if (m_System == null)
                    m_System = new DeathHarvest();

                return m_System;
            }
        }

        private readonly HarvestDefinition m_GravesAndMounds;

        private readonly HarvestDefinition m_TombsAndCoffins;

        public HarvestDefinition GravesAndMounds
        {
            get
            {
                return this.m_GravesAndMounds;
            }
        }

        public HarvestDefinition TombsAndCoffins
        {
            get
            {
                return this.m_TombsAndCoffins;
            }
        }

        private DeathHarvest()
        {
            HarvestResource[] res;
            HarvestVein[] veins;

            #region Harvesting graves
            HarvestDefinition gravesAndMounds = this.m_GravesAndMounds = new HarvestDefinition();

            // Resource banks are every 8x8 tiles
            gravesAndMounds.BankWidth = 8;
            gravesAndMounds.BankHeight = 8;

            // Every bank holds from 10 to 34 ore
            gravesAndMounds.MinTotal = 10;
            gravesAndMounds.MaxTotal = 34;

            // A resource bank will respawn its content every 10 to 20 minutes
            gravesAndMounds.MinRespawn = TimeSpan.FromMinutes(10.0);
            gravesAndMounds.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the Mining skill
            gravesAndMounds.Skill = SkillName.Mining;

            // Set the list of harvestable tiles
            gravesAndMounds.Tiles = m_GravesAndMoundsTiles;

            // Players must be within 2 tiles to harvest
            gravesAndMounds.MaxRange = 2;

            // One ore per harvest action
            gravesAndMounds.ConsumedPerHarvest = 1;
            gravesAndMounds.ConsumedPerFeluccaHarvest = 2;

            // The digging effect
            gravesAndMounds.EffectActions = new int[] { 11 };
            gravesAndMounds.EffectSounds = new int[] { 0x125, 0x126 };
            gravesAndMounds.EffectCounts = new int[] { 1 };
            gravesAndMounds.EffectDelay = TimeSpan.FromSeconds(1.6);
            gravesAndMounds.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            gravesAndMounds.NoResourcesMessage = 503040; // There is no metal here to mine.
            gravesAndMounds.DoubleHarvestMessage = 503042; // Someone has gotten to the metal before you.
            gravesAndMounds.TimedOutOfRangeMessage = 503041; // You have moved too far away to continue mining.
            gravesAndMounds.OutOfRangeMessage = 500446; // That is too far away.
            gravesAndMounds.FailMessage = 503043; // You loosen some rocks but fail to find any useable ore.
            gravesAndMounds.PackFullMessage = 1010481; // Your backpack is full, so the ore you mined is lost.
            gravesAndMounds.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
            {
                new HarvestResource(00.0, 00.0, 100.0, 1007072, typeof(IronOre), typeof(Granite)),
                new HarvestResource(65.0, 25.0, 105.0, 1007073, typeof(DullCopperOre),	typeof(DullCopperGranite), typeof(DullCopperElemental)),
                new HarvestResource(70.0, 30.0, 110.0, 1007074, typeof(ShadowIronOre),	typeof(ShadowIronGranite), typeof(ShadowIronElemental)),
                new HarvestResource(75.0, 35.0, 115.0, 1007075, typeof(CopperOre), typeof(CopperGranite), typeof(CopperElemental)),
                new HarvestResource(80.0, 40.0, 120.0, 1007076, typeof(BronzeOre), typeof(BronzeGranite), typeof(BronzeElemental)),
                new HarvestResource(85.0, 45.0, 125.0, 1007077, typeof(GoldOre), typeof(GoldGranite), typeof(GoldenElemental)),
                new HarvestResource(90.0, 50.0, 130.0, 1007078, typeof(AgapiteOre), typeof(AgapiteGranite), typeof(AgapiteElemental)),
                new HarvestResource(95.0, 55.0, 135.0, 1007079, typeof(VeriteOre), typeof(VeriteGranite), typeof(VeriteElemental)),
                new HarvestResource(99.0, 59.0, 139.0, 1007080, typeof(ValoriteOre), typeof(ValoriteGranite), typeof(ValoriteElemental))
            };

            veins = new HarvestVein[]
            {
                new HarvestVein(49.6, 0.0, res[0], null), // Iron
                new HarvestVein(11.2, 0.5, res[1], res[0]), // Dull Copper
                new HarvestVein(09.8, 0.5, res[2], res[0]), // Shadow Iron
                new HarvestVein(08.4, 0.5, res[3], res[0]), // Copper
                new HarvestVein(07.0, 0.5, res[4], res[0]), // Bronze
                new HarvestVein(05.6, 0.5, res[5], res[0]), // Gold
                new HarvestVein(04.2, 0.5, res[6], res[0]), // Agapite
                new HarvestVein(02.8, 0.5, res[7], res[0]), // Verite
                new HarvestVein(01.4, 0.5, res[8], res[0])// Valorite
            };

            gravesAndMounds.Resources = res;
            gravesAndMounds.Veins = veins;

            if (Core.ML)
            {
                gravesAndMounds.BonusResources = new BonusHarvestResource[]
                {
                    new BonusHarvestResource(0, 99.4, null, null), //Nothing
                    new BonusHarvestResource(100, .1, 1072562, typeof(BlueDiamond)),
                    new BonusHarvestResource(100, .1, 1072567, typeof(DarkSapphire)),
                    new BonusHarvestResource(100, .1, 1072570, typeof(EcruCitrine)),
                    new BonusHarvestResource(100, .1, 1072564, typeof(FireRuby)),
                    new BonusHarvestResource(100, .1, 1072566, typeof(PerfectEmerald)),
                    new BonusHarvestResource(100, .1, 1072568, typeof(Turquoise))
                };
            }

            gravesAndMounds.RaceBonus = Core.ML;
            gravesAndMounds.RandomizeVeins = Core.ML;

            this.Definitions.Add(gravesAndMounds);
            #endregion

            #region Mining for sand
            HarvestDefinition tombsAndCoffins = this.m_TombsAndCoffins = new HarvestDefinition();

            // Resource banks are every 8x8 tiles
            tombsAndCoffins.BankWidth = 8;
            tombsAndCoffins.BankHeight = 8;

            // Every bank holds from 6 to 12 
            tombsAndCoffins.MinTotal = 6;
            tombsAndCoffins.MaxTotal = 12;

            // A resource bank will respawn its content every 10 to 20 minutes
            tombsAndCoffins.MinRespawn = TimeSpan.FromMinutes(10.0);
            tombsAndCoffins.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the Mining skill
            tombsAndCoffins.Skill = SkillName.Mining;

            // Set the list of harvestable tiles
            tombsAndCoffins.Tiles = m_TombsAndCoffinsTiles;

            // Players must be within 2 tiles to harvest
            tombsAndCoffins.MaxRange = 2;

            // One tombsAndCoffins per harvest action
            tombsAndCoffins.ConsumedPerHarvest = 1;
            tombsAndCoffins.ConsumedPerFeluccaHarvest = 1;

            // The digging effect
            tombsAndCoffins.EffectActions = new int[] { 11 };
            tombsAndCoffins.EffectSounds = new int[] { 0x125, 0x126 };
            tombsAndCoffins.EffectCounts = new int[] { 6 };
            tombsAndCoffins.EffectDelay = TimeSpan.FromSeconds(1.6);
            tombsAndCoffins.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tombsAndCoffins.NoResourcesMessage = 1044629; // There is no tombsAndCoffins here to mine.
            tombsAndCoffins.DoubleHarvestMessage = 1044629; // There is no tombsAndCoffins here to mine.
            tombsAndCoffins.TimedOutOfRangeMessage = 503041; // You have moved too far away to continue mining.
            tombsAndCoffins.OutOfRangeMessage = 500446; // That is too far away.
            tombsAndCoffins.FailMessage = 1044630; // You dig for a while but fail to find any of sufficient quality for glassblowing.
            tombsAndCoffins.PackFullMessage = 1044632; // Your backpack can't hold the tombsAndCoffins, and it is lost!
            tombsAndCoffins.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
            {
                new HarvestResource(100.0, 70.0, 400.0, 1044631, typeof(Sand))
            };

            veins = new HarvestVein[]
            {
                new HarvestVein(100.0, 0.0, res[0], null)
            };

            tombsAndCoffins.Resources = res;
            tombsAndCoffins.Veins = veins;

            this.Definitions.Add(tombsAndCoffins);
            #endregion
        }

        public override bool BeginHarvesting(Mobile from, Item tool)
        {
            if (!base.BeginHarvesting(from, tool))
                return false;

            from.SendLocalizedMessage(503033); // Where do you wish to dig?
            return true;
        }

        public override void OnHarvestStarted(Mobile from, Item tool, HarvestDefinition def, object toHarvest)
        {
            base.OnHarvestStarted(from, tool, def, toHarvest);

            if (Core.ML)
                from.RevealingAction();
        }

        public override void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
        {
            if (toHarvest is LandTarget)
                from.SendLocalizedMessage(501862); // You can't mine there.
            else
                from.SendLocalizedMessage(501863); // You can't mine that.
        }

        #region Tile lists
        private static readonly int[] m_TombsAndCoffinsTiles = new int[]
        {
                //Graves, coffins, bones, body parts, etc, the dead stuff :)
                0x4ECA, 0x4ECB, 0x4ECC, 0x4ECD, 0x4ECE, 0x4ECF, 0x4ED0, 0x4ED1, 0x4ED2, 
                0x4ED4, 0x4ED5, 0x4ED6, 0x4ED7, 0x4ED8, 0x4ED9, 0x4EDA, 0x4EDB, 0x4EDC, 
                0x4EDD, 0x4EDE, 0x4ED3, 0x4EDF, 0x4EE0, 0x4EE1, 0x4EE2, 0x4EE8, 0x5165, 
                0x5166, 0x5167, 0x5168, 0x5169, 0x516A, 0x516B, 0x516C, 0x516D, 
                0x516E, 0x516F, 0x5170, 0x5171, 0x5172, 0x5173, 0x5174, 0x5175, 
                0x5176, 0x5177, 0x5178, 0x5179, 0x517A, 0x517B, 0x517C, 0x517D, 
                0x517E, 0x517F, 0x5180, 0x5181, 0x5182, 0x5183, 0x5184, 0x5C22, 
                0x5C23, 0x5C24, 0x5C25, 0x5C26, 0x5C27, 0x5C28, 0x5C29, 0x5C2A, 
                0x5C2B, 0x5C2C, 0x5C2D, 0x5C2E, 0x5C2F, 0x5C30, 0x5C31, 0x5C32, 
                0x5C33, 0x5C34, 0x5C35, 0x5C36, 0x5C37, 0x5C38, 0x5C39, 0x5C3A, 
                0x5C3B, 0x5C3C, 0x5C3D, 0x5C3E, 0x5C3F, 0x5C40, 0x5C41, 0x5C42, 
                0x5C43, 0x5C44, 0x5C45, 0x5C46, 0x5C47, 0x5C48, 0x5C49, 0x5C4A, 
                0x5C4B, 0x5C4C, 0x5C4D, 0x5C4E, 0x5C4F, 0x5C50, 0x5C51, 0x5C52, 
                0x5C53, 0x5C54, 0x5C55, 0x5C56, 0x5C57, 0x5C58, 0x5C59, 0x5C5A, 
                0x5C5B, 0x5C5C, 0x5C5D, 0x5C5E, 0x5C5F, 0x6FF9, 0x6FFA, 0x7048, 
                0x7049, 0x704A, 0x704B, 0x5C60, 0x5C61, 0x5C62, 0x5C63, 0x5C64, 
                0x5C65, 0x5C66, 0x5C67, 0x5C68, 0x5C69, 0x5C6A, 0x5C6B, 0x5C6C, 
                0x5C6D, 0x5C6E, 0x5C6F, 0x5C70, 0x5C71, 0x5C72, 0x5C73, 0x5C74, 
                0x5C75, 0x5C76, 0x5C77, 0x5C78, 0x5C79, 0x5C7A, 0x5C7B, 0x5C7C, 
                0x5C7D, 0x5C7E, 0x5C7F, 0x5C80, 0x5C81, 0x5C82, 0x5C83, 0x5C84, 
                0x5C85, 0x5C86, 0x5C87, 0x5C88, 0x5C89, 0x5C8A, 0x5C8B, 0x5C8C, 
                0x5C8D, 0x5C8E, 0x5C8F, 0x5C90, 0x5C91, 0x5C92, 0x5C93, 0x5C94, 
                0x5C95, 0x5C96, 0x5C97, 0x5C98, 0x5C99, 0x5C9A, 0x5C9B, 0x5C9C, 
                0x5C9D, 0x5C9E, 0x5C9F, 0x5CA0, 0x5CA1, 0x5CA2, 0x5CA3, 0x5CA4, 
                0x5CA5, 0x5CA6, 0x5CA7, 0x5CA8, 0x5CA9, 0x5CAA, 0x5CAB, 0x5CAC, 
                0x5CAD, 0x5CAE, 0x5CAF, 0x5CB0, 0x5CB1, 0x5CB2, 0x5CB3, 0x5CB4, 
                0x5CB5, 0x5CB6, 0x5CB7, 0x5CB8, 0x5CB9, 0x5CBA, 0x5CBB, 0x5CBC, 
                0x5CBD, 0x5CBE, 0x5CBF, 0x4F7E, 0x5B09, 0x5B0A, 0x5B0B, 0x5B0C, 
                0x5B0D, 0x5B0E, 0x5B0F, 0x5B10, 0x5B11, 0x5B12, 0x5B13, 0x5B14, 
                0x5B15, 0x5B16, 0x5B17, 0x5B18, 0x5B19, 0x5B1A, 0x5B1B, 0x5B1C, 
                0x5B1D, 0x5B1E, 0x5AD8, 0x5AD9, 0x5ADA, 0x5ADB, 0x5ADC, 0x5ADD, 
                0x5ADE, 0x5ADF, 0x5AE0, 0x5AE1, 0x5AE2, 0x5AE3, 0x5AE4, 0x5853, 
                0x5854, 0x5855, 0x5856, 0x5857, 0x5858, 0x5859, 0x585A, 0x61FC, 
                0x6203, 0x6204, 0x624E, 0x624F, 0x6250, 0x6251, 0x5CDD, 0x5CDE, 
                0x5CDF, 0x5CE0, 0x5CE1, 0x5CE2, 0x5CE3, 0x5CE4, 0x5CE5, 0x5CE6, 
                0x5CE7, 0x5CE8, 0x5CE9, 0x5CEA, 0x5CEB, 0x5CEC, 0x5CED, 0x5CEE, 
                0x5CEF, 0x5CF0, 0x5D9F, 0x5DA0, 0x5DA1, 0x5DA2, 0x5DA3, 0x5DA4, 
                0x5D4C, 0x5D4D, 0x5D4E, 0x5D4F, 0x5D50, 0x5D51, 0x5D52, 0x5D53, 
                0x5D54, 0x5D55, 0x5D56, 0x5D57, 0x5D58, 0x5D59, 0x5D5A, 0x5D5B, 
                0x5D5C, 0x5D5D, 0x5D5E, 0x5D5F, 0x5D60, 0x5D61, 0x5D62, 0x5D63, 
                0x5D64, 0x5D65, 0x5D66, 0x5D67, 0x5D68, 0x5D69, 0x5D6A, 0x5D6B, 
                0x5D6C, 0x5D6D, 0x5D6E, 0x5D6F, 0x5D70, 0x5D71, 0x5D72, 0x5D73, 
                0x5D74, 0x5D75, 0x5D76, 0x5D77, 0x5D78, 0x5D79, 0x5D7A, 0x5D7B, 
                0x5D7C, 0x5D7D, 0x5D7E, 0x5D7F, 0x5D80, 0x5D81, 0x5D82, 0x5D83, 
                0x5D84, 0x5D85, 0x5D86, 0x5D87, 0x5D88, 0x5D89, 0x5D8E, 0x5D8F, 
                0x5D90, 0x5D91, 0x5DAE, 0x5DAF, 0x5DB0, 0x5DB1, 0x5DB2
        };

        private static readonly int[] m_GravesAndMoundsTiles = new int[]
        {
                //Graves, coffins, bones, body parts, etc, the dead stuff :)
                0x4ECA, 0x4ECB, 0x4ECC, 0x4ECD, 0x4ECE, 0x4ECF, 0x4ED0, 0x4ED1, 0x4ED2, 
                0x4ED4, 0x4ED5, 0x4ED6, 0x4ED7, 0x4ED8, 0x4ED9, 0x4EDA, 0x4EDB, 0x4EDC, 
                0x4EDD, 0x4EDE, 0x4ED3, 0x4EDF, 0x4EE0, 0x4EE1, 0x4EE2, 0x4EE8, 0x5165, 
                0x5166, 0x5167, 0x5168, 0x5169, 0x516A, 0x516B, 0x516C, 0x516D, 
                0x516E, 0x516F, 0x5170, 0x5171, 0x5172, 0x5173, 0x5174, 0x5175, 
                0x5176, 0x5177, 0x5178, 0x5179, 0x517A, 0x517B, 0x517C, 0x517D, 
                0x517E, 0x517F, 0x5180, 0x5181, 0x5182, 0x5183, 0x5184, 0x5C22, 
                0x5C23, 0x5C24, 0x5C25, 0x5C26, 0x5C27, 0x5C28, 0x5C29, 0x5C2A, 
                0x5C2B, 0x5C2C, 0x5C2D, 0x5C2E, 0x5C2F, 0x5C30, 0x5C31, 0x5C32, 
                0x5C33, 0x5C34, 0x5C35, 0x5C36, 0x5C37, 0x5C38, 0x5C39, 0x5C3A, 
                0x5C3B, 0x5C3C, 0x5C3D, 0x5C3E, 0x5C3F, 0x5C40, 0x5C41, 0x5C42, 
                0x5C43, 0x5C44, 0x5C45, 0x5C46, 0x5C47, 0x5C48, 0x5C49, 0x5C4A, 
                0x5C4B, 0x5C4C, 0x5C4D, 0x5C4E, 0x5C4F, 0x5C50, 0x5C51, 0x5C52, 
                0x5C53, 0x5C54, 0x5C55, 0x5C56, 0x5C57, 0x5C58, 0x5C59, 0x5C5A, 
                0x5C5B, 0x5C5C, 0x5C5D, 0x5C5E, 0x5C5F, 0x6FF9, 0x6FFA, 0x7048, 
                0x7049, 0x704A, 0x704B, 0x5C60, 0x5C61, 0x5C62, 0x5C63, 0x5C64, 
                0x5C65, 0x5C66, 0x5C67, 0x5C68, 0x5C69, 0x5C6A, 0x5C6B, 0x5C6C, 
                0x5C6D, 0x5C6E, 0x5C6F, 0x5C70, 0x5C71, 0x5C72, 0x5C73, 0x5C74, 
                0x5C75, 0x5C76, 0x5C77, 0x5C78, 0x5C79, 0x5C7A, 0x5C7B, 0x5C7C, 
                0x5C7D, 0x5C7E, 0x5C7F, 0x5C80, 0x5C81, 0x5C82, 0x5C83, 0x5C84, 
                0x5C85, 0x5C86, 0x5C87, 0x5C88, 0x5C89, 0x5C8A, 0x5C8B, 0x5C8C, 
                0x5C8D, 0x5C8E, 0x5C8F, 0x5C90, 0x5C91, 0x5C92, 0x5C93, 0x5C94, 
                0x5C95, 0x5C96, 0x5C97, 0x5C98, 0x5C99, 0x5C9A, 0x5C9B, 0x5C9C, 
                0x5C9D, 0x5C9E, 0x5C9F, 0x5CA0, 0x5CA1, 0x5CA2, 0x5CA3, 0x5CA4, 
                0x5CA5, 0x5CA6, 0x5CA7, 0x5CA8, 0x5CA9, 0x5CAA, 0x5CAB, 0x5CAC, 
                0x5CAD, 0x5CAE, 0x5CAF, 0x5CB0, 0x5CB1, 0x5CB2, 0x5CB3, 0x5CB4, 
                0x5CB5, 0x5CB6, 0x5CB7, 0x5CB8, 0x5CB9, 0x5CBA, 0x5CBB, 0x5CBC, 
                0x5CBD, 0x5CBE, 0x5CBF, 0x4F7E, 0x5B09, 0x5B0A, 0x5B0B, 0x5B0C, 
                0x5B0D, 0x5B0E, 0x5B0F, 0x5B10, 0x5B11, 0x5B12, 0x5B13, 0x5B14, 
                0x5B15, 0x5B16, 0x5B17, 0x5B18, 0x5B19, 0x5B1A, 0x5B1B, 0x5B1C, 
                0x5B1D, 0x5B1E, 0x5AD8, 0x5AD9, 0x5ADA, 0x5ADB, 0x5ADC, 0x5ADD, 
                0x5ADE, 0x5ADF, 0x5AE0, 0x5AE1, 0x5AE2, 0x5AE3, 0x5AE4, 0x5853, 
                0x5854, 0x5855, 0x5856, 0x5857, 0x5858, 0x5859, 0x585A, 0x61FC, 
                0x6203, 0x6204, 0x624E, 0x624F, 0x6250, 0x6251, 0x5CDD, 0x5CDE, 
                0x5CDF, 0x5CE0, 0x5CE1, 0x5CE2, 0x5CE3, 0x5CE4, 0x5CE5, 0x5CE6, 
                0x5CE7, 0x5CE8, 0x5CE9, 0x5CEA, 0x5CEB, 0x5CEC, 0x5CED, 0x5CEE, 
                0x5CEF, 0x5CF0, 0x5D9F, 0x5DA0, 0x5DA1, 0x5DA2, 0x5DA3, 0x5DA4, 
                0x5D4C, 0x5D4D, 0x5D4E, 0x5D4F, 0x5D50, 0x5D51, 0x5D52, 0x5D53, 
                0x5D54, 0x5D55, 0x5D56, 0x5D57, 0x5D58, 0x5D59, 0x5D5A, 0x5D5B, 
                0x5D5C, 0x5D5D, 0x5D5E, 0x5D5F, 0x5D60, 0x5D61, 0x5D62, 0x5D63, 
                0x5D64, 0x5D65, 0x5D66, 0x5D67, 0x5D68, 0x5D69, 0x5D6A, 0x5D6B, 
                0x5D6C, 0x5D6D, 0x5D6E, 0x5D6F, 0x5D70, 0x5D71, 0x5D72, 0x5D73, 
                0x5D74, 0x5D75, 0x5D76, 0x5D77, 0x5D78, 0x5D79, 0x5D7A, 0x5D7B, 
                0x5D7C, 0x5D7D, 0x5D7E, 0x5D7F, 0x5D80, 0x5D81, 0x5D82, 0x5D83, 
                0x5D84, 0x5D85, 0x5D86, 0x5D87, 0x5D88, 0x5D89, 0x5D8E, 0x5D8F, 
                0x5D90, 0x5D91, 0x5DAE, 0x5DAF, 0x5DB0, 0x5DB1, 0x5DB2
        };
        #endregion
    }
}