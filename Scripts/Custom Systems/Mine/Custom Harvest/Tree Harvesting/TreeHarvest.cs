/***************************************************************************
 *   Tree Harvest System 
 *   TreeHarvest.cs.  This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/

using System;
using Server.Items;

namespace Server.Engines.Harvest
{
    public enum HarvestSuccessRating
    {
        Failure, PartialSuccess, Success
    }
    public enum TreeHarvestMethod
    {
        Carving, Picking, Digging, Sapping, Chopping
    }

    public enum TreeResourceType
    {
        BarkSkin, FruitNut, LeafSpine, RootBranch, SapJuice, LogsBranches
    }

    public enum TreeProductType
    {
        Crafting, Food, Medicine, Reagent, Spice
    }

    public class TreeHarvest : HarvestSystem
    {
        private static TreeHarvest m_System;

        public static TreeHarvest System
        {
            get
            {
                if (m_System == null)
                    m_System = new TreeHarvest();

                return m_System;
            }
        }

        public static void GetHarvestInfo(Mobile from, TreeProductItem product)
        {
            string use = "for unknown purposes";
            switch (product.ProductType)
            {
                case TreeProductType.Crafting: use = "for various types of crafting"; break;
                case TreeProductType.Food: use = "for food"; break;
                case TreeProductType.Medicine: use = "in the healing arts"; break;
                case TreeProductType.Reagent: use = "in the practice of magic"; break;
                case TreeProductType.Spice: use = "as a culinary spice"; break;
            }
            //TEMP: Show gump or something?
            from.SendMessage("This product is called {0}. It is used {1}.", product.Name, use);
        }

        private HarvestDefinition m_AppleTree, m_AshTree, m_BananaTree, m_BlackCherryTree, m_BlackOakTree, m_CassiaTree,
            m_CedarTree, m_CherryTree, m_CoconutPalm, m_CypressTree, m_DatePalm, m_DogwoodTree, m_EucalyptusTree,
            m_FigTree, m_HickoryTree, m_IronwoodTree, m_JuniperBush, m_MapleTree, m_OakTree, m_OhiiTree,
            m_OliveTree, m_PeachTree, m_PearTree, m_PipeCactus, m_PlumTree, m_PoplarTree,
            m_SandalwoodTree, m_SpiderTree, m_TuscanyPineTree, m_WalnutTree,
            m_WhiteBeechTree, m_WillowTree, m_YewTree, m_YuccaPlant;

        public HarvestDefinition AppleTree { get { return m_AppleTree; } }
        public HarvestDefinition AshTree { get { return m_AshTree; } }
        public HarvestDefinition BananaTree { get { return m_BananaTree; } }
        public HarvestDefinition BlackCherryTree { get { return m_BlackCherryTree; } }
        public HarvestDefinition BlackOakTree { get { return m_BlackOakTree; } }
        public HarvestDefinition CassiaTree { get { return m_CassiaTree; } }
        public HarvestDefinition CedarTree { get { return m_CedarTree; } }
        public HarvestDefinition CherryTree { get { return m_CherryTree; } }
        public HarvestDefinition CoconutPalm { get { return m_CoconutPalm; } }
        public HarvestDefinition CypressTree { get { return m_CypressTree; } }
        public HarvestDefinition DatePalm { get { return m_DatePalm; } }
        public HarvestDefinition DogwoodTree { get { return m_DogwoodTree; } }
        public HarvestDefinition EucalyptusTree { get { return m_EucalyptusTree; } }
        public HarvestDefinition FigTree { get { return m_FigTree; } }
        public HarvestDefinition HickoryTree { get { return m_HickoryTree; } }
        public HarvestDefinition IronwoodTree { get { return m_IronwoodTree; } }
        public HarvestDefinition JuniperBush { get { return m_JuniperBush; } }
        public HarvestDefinition MapleTree { get { return m_MapleTree; } }
        public HarvestDefinition OakTree { get { return m_OakTree; } }
        public HarvestDefinition OhiiTree { get { return m_OhiiTree; } }
        public HarvestDefinition OliveTree { get { return m_OliveTree; } }
        public HarvestDefinition PeachTree { get { return m_PeachTree; } }
        public HarvestDefinition PearTree { get { return m_PearTree; } }
        public HarvestDefinition PipeCactus { get { return m_PipeCactus; } }
        public HarvestDefinition PlumTree { get { return m_PlumTree; } }
        public HarvestDefinition PoplarTree { get { return m_PoplarTree; } }
        public HarvestDefinition SandalwoodTree { get { return m_SandalwoodTree; } }
        public HarvestDefinition SpiderTree { get { return m_SpiderTree; } }
        public HarvestDefinition TuscanyPineTree { get { return m_TuscanyPineTree; } }
        public HarvestDefinition WalnutTree { get { return m_WalnutTree; } }
        public HarvestDefinition WhiteBeechTree { get { return m_WhiteBeechTree; } }
        public HarvestDefinition WillowTree { get { return m_WillowTree; } }
        public HarvestDefinition YewTree { get { return m_YewTree; } }
        public HarvestDefinition YuccaPlant { get { return m_YuccaPlant; } }

        private TreeHarvest()
        {

            #region Harvesting Apple trees
            HarvestDefinition tree = m_AppleTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_AppleTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof (AppleTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            HarvestResource[] res;
            HarvestVein[] veins;

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.RedApple, typeof( TreeResourceItem ) ),
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.AppleBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 90.0, 0.0, res[0], null ),
					new HarvestVein( 10.0, 0.5, res[1], res[0] )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Apple Tree

            #region Harvesting Ash trees
            tree = m_AshTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_AshTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(AshTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.AshBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.BonusResources = new BonusHarvestResource[]
                {
                    new BonusHarvestResource(40.0, 50.0, "", typeof(AshLog))
                };

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Ash Tree

            #region Harvesting Banana trees
            tree = m_BananaTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_BananaTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(BananaTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.RipeBanana, typeof( TreeResourceItem ) ),
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.PalmHusks, typeof( TreeResourceItem ) ),
					new HarvestResource( 70.0, 60.0, 120.0, TreeResource.PalmTreeSap, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 70.0, 0.0, res[0], null ),
					new HarvestVein( 20.0, 0.5, res[1], res[0] ),
					new HarvestVein( 10.0, 0.5, res[2], res[0] )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Banana Tree

            #region Harvesting BlackCherry trees
            tree = m_BlackCherryTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_BlackCherryTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(BlackCherryTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.BlackCherry, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //BlackCherry Tree

            #region Harvesting BlackOak trees
            tree = m_BlackOakTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_BlackOakTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(BlackOakTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.BlackOakBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //BlackOak Tree

            #region Harvesting Cassia trees
            tree = m_CassiaTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_CassiaTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(CassiaTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.CassiaBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Cassia Tree

            #region Harvesting Cedar trees
            tree = m_CedarTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_CedarTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(CedarTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.CedarBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Cedar Tree

            #region Harvesting Cherry trees
            tree = m_CherryTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_CherryTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(CherryTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.Cherry, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Cherry Tree

            #region Harvesting Coconut Palm trees
            tree = m_CoconutPalm = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_CoconutTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(CoconutPalmLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.WholeCoconut, typeof( TreeResourceItem ) ),
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.PalmHusks, typeof( TreeResourceItem ) ),
					new HarvestResource( 70.0, 60.0, 120.0, TreeResource.PalmTreeSap, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 70.0, 0.0, res[0], null ),
					new HarvestVein( 20.0, 0.5, res[1], res[0] ),
					new HarvestVein( 10.0, 0.5, res[2], res[0] )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Coconut Palm Tree

            #region Harvesting Cypress trees
            tree = m_CypressTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_CypressTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(CypressTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 40.0, 30.0, 120.0, TreeResource.CypressLeaves, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Cypress Tree

            #region Harvesting Date Palm trees
            tree = m_DatePalm = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_DateTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(DatePalmLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.TropicalDates, typeof( TreeResourceItem ) ),
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.PalmHusks, typeof( TreeResourceItem ) ),
					new HarvestResource( 70.0, 60.0, 120.0, TreeResource.PalmTreeSap, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 70.0, 0.0, res[0], null ),
					new HarvestVein( 20.0, 0.5, res[1], res[0] ),
					new HarvestVein( 10.0, 0.5, res[2], res[0] )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Date Palm Tree

            #region Harvesting Dogwood trees
            tree = m_DogwoodTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_DogwoodTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(DogwoodTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.DogwoodBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Dogwood Tree

            #region Harvesting Eucalyptus trees
            tree = m_EucalyptusTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_EucalyptusTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(EucalyptusTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 40.0, 30.0, 120.0, TreeResource.EucalyptusLeaves, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Eucalyptus Tree

            #region Harvesting Fig trees
            tree = m_FigTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_FigTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(FigTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.FigFruit, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Fig Tree

            #region Harvesting Hickory trees
            tree = m_HickoryTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_HickoryTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(HickoryTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.HickoryBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Hickory Tree

            #region Harvesting Ironwood trees
            tree = m_IronwoodTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_IronwoodTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(IronwoodTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 70.0, 60.0, 120.0, TreeResource.IronwoodBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Ironwood Tree

            #region Harvesting Juniper trees
            tree = m_JuniperBush = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_JuniperTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(JuniperBushLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 45.0, 35.0, 120.0, TreeResource.JuniperLeaves, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Juniper Bush

            #region Harvesting Maple trees
            tree = m_MapleTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_MapleTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(MapleTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 40.0, 30.0, 120.0, TreeResource.MapleTreeSap, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Maple Tree

            #region Harvesting Oak trees
            tree = m_OakTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_OakTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(OakTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 35.0, 25.0, 120.0, TreeResource.Acorn, typeof( TreeResourceItem ) ),
					new HarvestResource( 55.0, 45.0, 120.0, TreeResource.OakBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.BonusResources = new BonusHarvestResource[]
                {
                    new BonusHarvestResource(30.0, 40.0, "", typeof(OakLog))
                };

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Oak Tree

            #region Harvesting Ohii trees
            tree = m_OhiiTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_OhiiTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(OhiiTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 55.0, 45.0, 120.0, TreeResource.OhiiRoot, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Ohii Tree

            #region Harvesting Olive trees
            tree = m_OliveTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_OliveTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(OliveTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.BlackOlives, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.BonusResources = new BonusHarvestResource[] 
                { 
                    new BonusHarvestResource(60, 0.25, (int)TreeResource.GreenOlives, typeof( TreeResourceItem ) ) 
                };

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Olive Tree

            #region Harvesting Peach trees
            tree = m_PeachTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_PeachTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(PeachTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.HarvestPeach, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Peach Tree

            #region Harvesting Pear trees
            tree = m_PearTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_PearTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(PearTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.GoldenPear, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Pear Tree

            #region Harvesting PipeCactus trees
            tree = m_PipeCactus = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_CactusTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(PipeCactusLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 80.0, 70.0, 120.0, TreeResource.CactusSpine, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Pipe Cactus Tree

            #region Harvesting Plum trees
            tree = m_PlumTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_PlumTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(PlumTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.Plum, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Plum Tree

            #region Harvesting Poplar trees
            tree = m_PoplarTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_PoplarTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(PoplarTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.TreeSap, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Poplar Tree

            #region Harvesting Sandalwood trees
            tree = m_SandalwoodTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_SandalwoodTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(SandalwoodTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 40.0, 30.0, 120.0, TreeResource.SandalwoodSap, typeof( TreeResourceItem ) ),
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.SandalwoodRoot, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 70.0, 0.0, res[0], null ),
					new HarvestVein( 30.0, 0.0, res[1], res[0] )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Sandalwood Tree

            #region Harvesting Spider trees
            tree = m_SpiderTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_SpiderTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(SpiderTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.SpiderTreeLeaves, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Spider Tree

            #region Harvesting TuscanyPine trees
            tree = m_TuscanyPineTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_TuscanyPineTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(TuscanyPineTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.PineTreeSap, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //TuscanyPine Tree

            #region Harvesting Walnut trees
            tree = m_WalnutTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_WalnutTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(WalnutTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 35.0, 25.0, 120.0, TreeResource.Walnut, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Walnut Tree

            #region Harvesting WhiteBeech trees
            tree = m_WhiteBeechTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_WhiteBeechTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(WhiteBeechTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.BeechBark, typeof( TreeResourceItem ) ),
					new HarvestResource( 40.0, 30.0, 120.0, TreeResource.Beechnut, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 60.0, 0.0, res[0], null ),
					new HarvestVein( 40.0, 0.0, res[1], res[0] )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //WhiteBeech Tree

            #region Harvesting Willow trees
            tree = m_WillowTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_WillowTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(WillowTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 30.0, 20.0, 120.0, TreeResource.WillowBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Willow Tree

            #region Harvesting Yew trees
            tree = m_YewTree = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Camping;

            // Set the list of harvestable tiles
            tree.Tiles = m_YewTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(YewTreeLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 60.0, 50.0, 120.0, TreeResource.YewBark, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 100.0, 0.0, res[0], null )
				};

            tree.BonusResources = new BonusHarvestResource[]
                {
                    new BonusHarvestResource(40.0, 50.0, "", typeof(YewLog))
                };

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Yew Tree

            #region Harvesting Yucca trees
            tree = m_YuccaPlant = new HarvestDefinition();

            // Resource banks are every 2x3 tiles
            tree.BankWidth = 2;
            tree.BankHeight = 3;

            // Every bank holds from 10 to 24 resources
            tree.MinTotal = 10;
            tree.MaxTotal = 24;

            // A resource bank will respawn its content every 10 to 20 minutes
            tree.MinRespawn = TimeSpan.FromMinutes(10.0);
            tree.MaxRespawn = TimeSpan.FromMinutes(20.0);

            // Skill checking is done on the related Harvesting skill
            tree.Skill = SkillName.Cooking;

            // Set the list of harvestable tiles
            tree.Tiles = m_YuccaTreeTiles;

            // Players must be within 2 tiles to harvest
            tree.MaxRange = 2;

            // Resources per harvest action
            tree.ConsumedPerHarvest = 2;
            tree.ConsumedPerFeluccaHarvest = 2;

            // The harvest effect
            tree.EffectActions = new int[] { 11 };
            tree.EffectSounds = new int[] { 0x125, 0x126 };
            tree.EffectCounts = new int[] { 3 };
            tree.EffectDelay = TimeSpan.FromSeconds(1.0);
            tree.EffectSoundDelay = TimeSpan.FromSeconds(0.9);

            tree.NoResourcesMessage = "There is no resource here to harvest.";
            tree.DoubleHarvestMessage = typeof(YuccaPlantLog);
            tree.TimedOutOfRangeMessage = "You have moved too far away to continue harvesting.";
            tree.OutOfRangeMessage = 500446; // That is too far away.
            tree.FailMessage = "You fail to find any resources to harvest.";
            tree.PackFullMessage = "Your backpack can't hold any more resources!";
            tree.ToolBrokeMessage = 1044038; // You have worn out your tool!

            res = new HarvestResource[]
				{
					new HarvestResource( 75.0, 65.0, 120.0, TreeResource.YuccaRoot, typeof( TreeResourceItem ) ),
					new HarvestResource( 50.0, 40.0, 120.0, TreeResource.PalmHusks, typeof( TreeResourceItem ) ),
					new HarvestResource( 70.0, 60.0, 120.0, TreeResource.PalmTreeSap, typeof( TreeResourceItem ) )
				};

            veins = new HarvestVein[]
				{
					new HarvestVein( 70.0, 0.0, res[0], null ),
					new HarvestVein( 20.0, 0.5, res[1], res[0] ),
					new HarvestVein( 10.0, 0.5, res[2], res[0] )
				};

            tree.Resources = res;
            tree.Veins = veins;

            Definitions.Add(tree);
            #endregion //Yucca Plant
        }

        public override void OnBadHarvestTarget(Mobile from, Item tool, object toHarvest)
        {
            if (tool is TreeHatchet)
            {
                if (toHarvest is CustomTreeLog)
                {
                    Item boards = null;
                    CustomTreeLog log = (CustomTreeLog) toHarvest;
                    switch (log.Resource)
                    {
                        case CraftResource.Bloodwood:
                            boards = new BloodwoodBoard(log.Amount);
                            break;
                        case CraftResource.Frostwood:
                            boards = new FrostwoodBoard(log.Amount);
                            break;
                        case CraftResource.Heartwood:
                            boards = new HeartwoodBoard(log.Amount);
                            break;
                        case CraftResource.YewWood:
                            boards = new YewBoard(log.Amount);
                            break;
                        case CraftResource.AshWood:
                            boards = new AshBoard(log.Amount);
                            break;
                        case CraftResource.OakWood:
                            boards = new OakBoard(log.Amount);
                            break;
                        case CraftResource.RegularWood:
                            boards = new Board(log.Amount);
                            break;
                    }
                    if (boards != null)
                    {
                        if (Give(from, boards, true))
                        {
                            log.Delete();
                            from.SendMessage("You convert the logs into boards.");
                            return;
                        }
                    }
                }
            }
            from.SendMessage("You cannot harvest anything there using {0}.", tool.Name);
        }

        public override void SendSuccessTo(Mobile from, Item item, HarvestResource resource)
        {
            from.SendMessage("You harvest {0} {1}", item.Amount.ToString(), item.DefaultName);
        }

        public override bool CheckResources(Mobile from, Item tool, HarvestDefinition def, Map map, Point3D loc, bool timed)
        {
            HarvestBank bank = def.GetBank(map, loc.X, loc.Y);
            bool available = (bank != null && bank.Current >= def.ConsumedPerHarvest);

            if (!available)
                def.SendMessageTo(from, def.NoResourcesMessage);

            return available;
        }

        public override void FinishHarvesting(Mobile from, Item tool, HarvestDefinition def, object toHarvest, object locked)
        {
            from.EndAction(locked);

            if (!CheckHarvest(from, tool)) return;

            int tileID;
            Map map;
            Point3D loc;

            if (!GetHarvestDetails(from, tool, toHarvest, out tileID, out map, out loc))
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }
            else if (!def.Validate(tileID))
            {
                OnBadHarvestTarget(from, tool, toHarvest);
                return;
            }

            if (!CheckRange(from, tool, def, map, loc, true)) return;
            else if (!CheckResources(from, tool, def, map, loc, false)) return;
            else if (!CheckHarvest(from, tool, def, toHarvest)) return;

            if (SpecialHarvest(from, tool, def, map, loc)) return;

            HarvestBank bank = def.GetBank(map, loc.X, loc.Y);
            if (bank == null) return;

            HarvestVein vein = bank.Vein;
            if (vein == null) return;

            HarvestResource resource = null;
            TreeHarvestTool thtool = null;
            TreeResourceItem trsource = null;
            HarvestSuccessRating rating = HarvestSuccessRating.Failure;
            bool gave = false;
            TreeHarvestMethod method = TreeHarvestMethod.Picking;
            string toolType = "unknown";
            string resType = "resources";

            if (tool is TreeHarvestTool)
            {
                thtool = tool as TreeHarvestTool;
                switch (thtool.ResourceType)
                {
                    case TreeResourceType.BarkSkin: toolType = "carving"; method = TreeHarvestMethod.Carving; break;
                    case TreeResourceType.FruitNut: toolType = "picking"; method = TreeHarvestMethod.Picking; break;
                    case TreeResourceType.LeafSpine: toolType = "pinching"; method = TreeHarvestMethod.Picking; break;
                    case TreeResourceType.RootBranch: toolType = "digging"; method = TreeHarvestMethod.Digging; break;
                    case TreeResourceType.SapJuice: toolType = "sapping"; method = TreeHarvestMethod.Sapping; break;
                    case TreeResourceType.LogsBranches: toolType = "chopping"; method = TreeHarvestMethod.Chopping; break;
                }
                bool found = false;
                for (int x = 0; x < def.Resources.Length && !found; x++)
                {
                    if (method == TreeHarvestMethod.Chopping)
                    {
                        //give logs
                        Item logs = Activator.CreateInstance((Type) def.DoubleHarvestMessage) as Item;
                        if (logs is CustomTreeLog)
                        {
                            rating = from.CheckSkill(SkillName.Lumberjacking, ((CustomTreeLog)logs).MinSkill, 100.0)
                                ? Utility.RandomBool()
                                    ? HarvestSuccessRating.PartialSuccess
                                    : HarvestSuccessRating.Success
                                : HarvestSuccessRating.Failure;

                            if (rating >= HarvestSuccessRating.PartialSuccess)
                            {
                                logs.Amount = 10;

                                if (Give(from, logs, def.PlaceAtFeetIfFull))
                                {
                                    from.SendMessage("You receive some {0}.", logs.DefaultName);
                                    gave = true;
                                }
                                else
                                {
                                    from.SendMessage("Your pack is full. Some logs were lost.");
                                    logs.Delete();
                                    return;
                                }
                                bank.Consume(def.ConsumedPerHarvest, from);
                            }
                        }
                        found = true;
                        continue;
                    }

                    object[] obj = new object[] { def.Resources[x].SuccessMessage };
                    Item item = Activator.CreateInstance(def.Resources[x].Types[0], obj) as Item;
                    if (item is TreeResourceItem)
                    {
                        trsource = item as TreeResourceItem;
                        switch (trsource.ResourceType)
                        {
                            case TreeResourceType.BarkSkin: resType = "bark or skin"; break;
                            case TreeResourceType.FruitNut: resType = "fruits or nuts"; break;
                            case TreeResourceType.LeafSpine: resType = "leaves or spines"; break;
                            case TreeResourceType.RootBranch: resType = "roots or buried branches"; break;
                            case TreeResourceType.SapJuice: resType = "sap or juice"; break;
                            case TreeResourceType.LogsBranches: resType = "logs or sturdy branches"; break;
                        }
                        if (thtool.ResourceType == trsource.ResourceType)
                        {
                            found = true;
                            resource = def.Resources[x];
                        }
                        else
                            trsource.Delete();
                    }
                    else
                        if (item != null) item.Delete();
                }

                if (!found)
                {
                    from.SendMessage("You will not get any {0} with the {1} tool.", resType, toolType);
                    return;
                }
            }
            else
            {
                Console.WriteLine("How did someone try to harvest a tree without a Tree Harvest Tool?");
                return;
            }

            if (trsource != null)
            {
                rating = from.CheckSkill(SkillName.Camping, 0.0, 100.0)? Utility.RandomBool()
                        ? HarvestSuccessRating.PartialSuccess
                        : HarvestSuccessRating.Success
                    : HarvestSuccessRating.Failure;

                if (rating >= HarvestSuccessRating.PartialSuccess)
                {
                    if (trsource.Stackable) trsource.Amount = def.ConsumedPerHarvest;

                    Container pack = from.Backpack;
                    if (pack == null)
                    {
                        from.SendMessage("Why don't you have a pack?");
                        trsource.Delete();
                        return;
                    }
                    Item tap = pack.FindItemByType(typeof(BarrelTap));

                    if (trsource.ResourceType == TreeResourceType.SapJuice && tap == null)
                    {
                        from.SendMessage("You need a barrel tap to sap this tree.");
                        trsource.Delete();
                        return;
                    }
                    if (trsource.ResourceType == TreeResourceType.SapJuice)
                        trsource.Amount = 1;

                    bank.Consume(trsource.Amount, from);

                    if (tool is TreeHarvestTool)
                    {
                        TreeHarvestTool toolWithUses = (TreeHarvestTool)tool;

                        toolWithUses.ShowUsesRemaining = true;

                        if (toolWithUses.UsesRemaining > 0)
                            --toolWithUses.UsesRemaining;

                        if (toolWithUses.UsesRemaining < 1)
                        {
                            tool.Delete();
                            def.SendMessageTo(from, def.ToolBrokeMessage);
                        }
                    }

                    if (trsource.ResourceType != TreeResourceType.SapJuice || pack.ConsumeTotal(typeof(EmptyJar), 1))
                    {
                        if (trsource.ResourceType == TreeResourceType.SapJuice && 0.12 >= Utility.RandomDouble())
                        {
                            from.SendMessage("Your tap broke in the process, and is now gone.");
                            tap.Delete();
                        }

                        if (Give(from, trsource, def.PlaceAtFeetIfFull))
                        {
                            SendSuccessTo(from, trsource, resource);
                            gave = true;
                        }
                        else
                        {
                            SendPackFullTo(from, trsource, def, resource);
                            trsource.Delete();
                            return;
                        }
                    }
                    else
                    {
                        from.SendMessage("You don't have an empty jar to hold the sap, so it was lost!");
                        trsource.Delete();
                        return;
                    }
                }
                else
                    trsource.Delete();
            }

            BonusHarvestResource bonus = def.GetBonusResource();

            if (bonus != null && bonus.Type != null && rating >= HarvestSuccessRating.Success)
            {
                Item bonusItem;
                if (bonus.Type == typeof(TreeResource))
                {
                    object[] obj = new object[] { (TreeResource)bonus.SuccessMessage.Number };
                    bonusItem = Activator.CreateInstance(bonus.Type, obj) as Item;
                }
                else
                {
                    bonusItem = Activator.CreateInstance(bonus.Type) as Item;
                }

                if (Give(from, bonusItem, true))
                {
                    from.SendMessage("You find a bonus resource.");
                    gave = true;
                }
                else
                {
                    if (bonusItem != null)
                        bonusItem.Delete();
                }
            }

            if (gave)
            {
                //do nothing
            }
            else if (trsource == null || trsource.Deleted)
                def.SendMessageTo(from, def.FailMessage);

            OnHarvestFinished(from, tool, def, vein, bank, resource, toHarvest);
        }

        public static TreeResource[] GetResources(int tileID)
        {
            switch (tileID)
            {
                case 0x4CA8:
                case 0x4CAA:
                case 0x4CAB: return new TreeResource[] { TreeResource.RipeBanana, TreeResource.PalmHusks, TreeResource.PalmTreeSap };
                case 0x4C95: return new TreeResource[] { TreeResource.WholeCoconut, TreeResource.PalmHusks, TreeResource.PalmTreeSap };
                case 0x4C96: return new TreeResource[] { TreeResource.TropicalDates, TreeResource.PalmHusks, TreeResource.PalmTreeSap };
                case 0x4CC8: return new TreeResource[] { TreeResource.JuniperLeaves };
                case 0x4CC9: return new TreeResource[] { TreeResource.SpiderTreeLeaves };
                case 0x4CCA: return new TreeResource[] { TreeResource.IronwoodBark };
                case 0x4CCB: return new TreeResource[] { TreeResource.HickoryBark };
                case 0x4CCC: return new TreeResource[] { TreeResource.DogwoodBark };
                case 0x4C9E: return new TreeResource[] { TreeResource.OhiiRoot };
                case 0x4CCD:
                case 0x4CCE:
                case 0x4CCF: return new TreeResource[] { TreeResource.AshBark };
                case 0x4CD0:
                case 0x4CD1:
                case 0x4CD2: return new TreeResource[] { TreeResource.EucalyptusLeaves };
                case 0x4CD3:
                case 0x4CD4:
                case 0x4CD5: return new TreeResource[] { TreeResource.BlackOlives, TreeResource.GreenOlives };
                case 0x4CD6:
                case 0x4CD7:
                case 0x4CD8:
                case 0x4CD9: return new TreeResource[] { TreeResource.CedarBark };
                case 0x5B7E: return new TreeResource[] { TreeResource.PineTreeSap };
                case 0x6471:
                case 0x6472:
                case 0x6473:
                case 0x6474:
                case 0x6475:
                case 0x6476:
                case 0x6477: return new TreeResource[] { TreeResource.Cherry };
                case 0x6478:
                case 0x6479:
                case 0x647A:
                case 0x647B:
                case 0x647C:
                case 0x647D:
                case 0x647E: return new TreeResource[] { TreeResource.MapleTreeSap };
                case 0x4CDA:
                case 0x4CDB:
                case 0x4CDC:
                case 0x4CDD:
                case 0x4CDE:
                case 0x4CDF: return new TreeResource[] { TreeResource.Acorn, TreeResource.OakBark };
                case 0x4CE0:
                case 0x4CE1:
                case 0x4CE2:
                case 0x4CE3:
                case 0x4CE4:
                case 0x4CE5: return new TreeResource[] { TreeResource.Walnut };
                case 0x4CE6:
                case 0x4CE7:
                case 0x4CE8: return new TreeResource[] { TreeResource.WillowBark };
                case 0x4CF8:
                case 0x4CF9:
                case 0x4CFA:
                case 0x4CFB:
                case 0x4CFC:
                case 0x4CFD:
                case 0x4CFE:
                case 0x4CFF:
                case 0x4D00:
                case 0x4D01:
                case 0x4D02:
                case 0x4D03: return new TreeResource[] { TreeResource.CypressLeaves };
                case 0x4D35: return new TreeResource[] { TreeResource.CactusSpine };
                case 0x4D37:
                case 0x4D38: return new TreeResource[] { TreeResource.YuccaRoot, TreeResource.PalmHusks, TreeResource.PalmTreeSap };
                case 0x4D41:
                case 0x4D42:
                case 0x4D43:
                case 0x4D44:
                case 0x4D45:
                case 0x4D46:
                case 0x4D47:
                case 0x4D48:
                case 0x4D49:
                case 0x4D4A:
                case 0x4D4B:
                case 0x4D4C:
                case 0x4D4D:
                case 0x4D4E:
                case 0x4D4F:
                case 0x4D50:
                case 0x4D51:
                case 0x4D52:
                case 0x4D53: return new TreeResource[] { TreeResource.BlackCherry };
                case 0x4D57:
                case 0x4D58:
                case 0x4D59:
                case 0x4D5A:
                case 0x4D5B:
                case 0x4D5C:
                case 0x4D5D:
                case 0x4D5E:
                case 0x4D5F:
                case 0x4D60:
                case 0x4D61:
                case 0x4D62:
                case 0x4D63:
                case 0x4D64:
                case 0x4D65:
                case 0x4D66:
                case 0x4D67:
                case 0x4D68:
                case 0x4D69: return new TreeResource[] { TreeResource.TreeSap };
                case 0x4D6A:
                case 0x4D6B:
                case 0x4D6C:
                case 0x4D6D:
                case 0x4D6E:
                case 0x4D6F:
                case 0x4D70:
                case 0x4D71:
                case 0x4D72:
                case 0x4D73:
                case 0x4D74:
                case 0x4D75:
                case 0x4D76:
                case 0x4D77:
                case 0x4D78:
                case 0x4D79:
                case 0x4D7A:
                case 0x4D7B:
                case 0x4D7C:
                case 0x4D7D:
                case 0x4D7E:
                case 0x4D7F: return new TreeResource[] { TreeResource.FigFruit };
                case 0x4D84:
                case 0x4D85:
                case 0x4D86:
                case 0x4D87:
                case 0x4D88:
                case 0x4D89:
                case 0x4D8A:
                case 0x4D8B:
                case 0x4D8C:
                case 0x4D8D:
                case 0x4D8E:
                case 0x4D8F:
                case 0x4D90: return new TreeResource[] { TreeResource.SandalwoodSap, TreeResource.SandalwoodRoot };
                case 0x4D94:
                case 0x4D95:
                case 0x4D96:
                case 0x4D97:
                case 0x4D98:
                case 0x4D99:
                case 0x4D9A:
                case 0x4D9B:
                case 0x7124: return new TreeResource[] { TreeResource.RedApple, TreeResource.AppleBark };
                case 0x4D9C:
                case 0x4D9D:
                case 0x4D9E:
                case 0x4D9F:
                case 0x4DA0:
                case 0x4DA1:
                case 0x4DA2:
                case 0x4DA3:
                case 0x7123: return new TreeResource[] { TreeResource.HarvestPeach };
                case 0x4DA4:
                case 0x4DA5:
                case 0x4DA6:
                case 0x4DA7:
                case 0x4DA8:
                case 0x4DA9:
                case 0x4DAA:
                case 0x4DAB: return new TreeResource[] { TreeResource.GoldenPear };
                case 0x52B5:
                case 0x52B6:
                case 0x52B7:
                case 0x52B8:
                case 0x52B9:
                case 0x52BA:
                case 0x52BB:
                case 0x52BC:
                case 0x52BD:
                case 0x52BE:
                case 0x52BF:
                case 0x52C0:
                case 0x52C1:
                case 0x52C2:
                case 0x52C3:
                case 0x52C4:
                case 0x52C5:
                case 0x52C6:
                case 0x52C7: return new TreeResource[] { TreeResource.YewBark };
                case 0x66ED:
                case 0x66EE:
                case 0x66EF:
                case 0x66F0:
                case 0x66F1:
                case 0x66F2:
                case 0x66F3:
                case 0x7122: return new TreeResource[] { TreeResource.Plum };
                case 0x709C:
                case 0x709D:
                case 0x709E:
                case 0x709F:
                case 0x70A0:
                case 0x70A1:
                case 0x70A2:
                case 0x70A3:
                case 0x70A4:
                case 0x70A5:
                case 0x70A6:
                case 0x70A7:
                case 0x70A8:
                case 0x70A9:
                case 0x70AA:
                case 0x70AB:
                case 0x70AC:
                case 0x70AD:
                case 0x70AE:
                case 0x70AF:
                case 0x70B0:
                case 0x70B1:
                case 0x70B2:
                case 0x70B3:
                case 0x70B4:
                case 0x70B5:
                case 0x70B6:
                case 0x70B7:
                case 0x70B8:
                case 0x70B9:
                case 0x70BA:
                case 0x70BB:
                case 0x70BC: return new TreeResource[] { TreeResource.BlackOakBark };
                case 0x70D4:
                case 0x70D5:
                case 0x70D6:
                case 0x70D7:
                case 0x70D8:
                case 0x70D9:
                case 0x70DA:
                case 0x70DB:
                case 0x70DC:
                case 0x70DD:
                case 0x70DE: return new TreeResource[] { TreeResource.Beechnut, TreeResource.BeechBark };
                case 0x70BD:
                case 0x70BE:
                case 0x70BF:
                case 0x70C0:
                case 0x70C1:
                case 0x70C2:
                case 0x70C3:
                case 0x70C4:
                case 0x70C5:
                case 0x70C6:
                case 0x70C7:
                case 0x70C8:
                case 0x70C9:
                case 0x70CA:
                case 0x70CB:
                case 0x70CC:
                case 0x70CD:
                case 0x70CE:
                case 0x70CF:
                case 0x70D0:
                case 0x70D1:
                case 0x70D2:
                case 0x70D3: return new TreeResource[] { TreeResource.CassiaBark };
            }
            return new TreeResource[0];
        }

        #region Harvest Tree Tiles
        private static int[] m_AppleTreeTiles = new int[]
			{
                0x4D94, 0x4D95, 0x4D96, 0x4D97, 0x4D98, 0x4D99, 0x4D9A, 0x4D9B, 0x7124, //Apple Tree
			};

        private static int[] m_AshTreeTiles = new int[]
			{
                0x4CCD, 0x4CCE, 0x4CCF, //Ash
			};

        private static int[] m_BananaTreeTiles = new int[]
			{
                0x4CA8, 0x4CAA, 0x4CAB, //Banana Tree
			};

        private static int[] m_BlackCherryTreeTiles = new int[]
			{
				0x4D41, 0x4D42, 0x4D43, 0x4D44, 0x4D45, 0x4D46, 
				0x4D47, 0x4D48, 0x4D49, 0x4D4A, 0x4D4B, 0x4D4C, 
				0x4D4D, 0x4D4E, 0x4D4F, 0x4D50, 0x4D51, 0x4D52, 0x4D53, //BlackCherry
			};

        private static int[] m_BlackOakTreeTiles = new int[]
			{
                0x709C, 0x709D, 0x709E, 0x709F, 0x70A0, 0x70A1, 0x70A2, 0x70A3, 
                0x70A4, 0x70A5, 0x70A6, 0x70A7, 0x70A8, 0x70A9, 0x70AA, 0x70AB,
                0x70AC, 0x70AD, 0x70AE, 0x70AF, 0x70B0, 0x70B1, 0x70B2, 0x70B3, 
                0x70B4, 0x70B5, 0x70B6, 0x70B7, 0x70B8, 0x70B9, 0x70BA, 0x70BB, 0x70BC, //BlackOak
			};

        private static int[] m_CactusTreeTiles = new int[]
			{
                0x4D35, //Pipe Cactus
			};

        private static int[] m_CassiaTreeTiles = new int[]
			{
                0x70BD, 0x70BE, 0x70BF, 0x70C0, 0x70C1, 0x70C2, 0x70C3, 
                0x70C4, 0x70C5, 0x70C6, 0x70C7, 0x70C8, 0x70C9, 0x70CA, 0x70CB,
                0x70CC, 0x70CD, 0x70CE, 0x70CF, 0x70D0, 0x70D1, 0x70D2, 0x70D3, //Cassia
			};

        private static int[] m_CedarTreeTiles = new int[]
			{
                0x4CD6, 0x4CD7, 0x4CD8, 0x4CD9, //Cedar
			};

        private static int[] m_CherryTreeTiles = new int[]
			{
				0x6471, 0x6472, 0x6473, 
                0x6474, 0x6475, 0x6476, 0x6477, //Cherry
			};

        private static int[] m_CoconutTreeTiles = new int[]
			{
                0x4C95, //Coconut Palm
			};

        private static int[] m_CypressTreeTiles = new int[]
			{
                0x4CF8, 0x4CF9, 0x4CFA, 0x4CFB, 0x4CFC, 0x4CFD, 
                0x4CFE, 0x4CFF, 0x4D00, 0x4D01, 0x4D02, 0x4D03, //Cypress
			};

        private static int[] m_DateTreeTiles = new int[]
			{
                0x4C96, //Date Palm
			};

        private static int[] m_DogwoodTreeTiles = new int[]
			{
                0x4CCC, //Dogwood
			};

        private static int[] m_EucalyptusTreeTiles = new int[]
			{
                0x4CD0, 0x4CD1, 0x4CD2, //Eucalyptus
			};

        private static int[] m_FigTreeTiles = new int[]
			{
                0x4D6A, 0x4D6B, 0x4D6C, 0x4D6D, 0x4D6E, 0x4D6F, 0x4D70, 
                0x4D71, 0x4D72, 0x4D73, 0x4D74, 0x4D75, 0x4D76, 0x4D77, 
                0x4D78, 0x4D79, 0x4D7A, 0x4D7B, 0x4D7C, 0x4D7D, 0x4D7E, 0x4D7F, //Fig
			};

        private static int[] m_HickoryTreeTiles = new int[]
			{
                0x4CCB, //Hickory
			};

        private static int[] m_IronwoodTreeTiles = new int[]
			{
				0x4CCA, //Ironwood
			};

        private static int[] m_JuniperTreeTiles = new int[]
			{
                0x4CC8, //Juniper Bush
			};

        private static int[] m_MapleTreeTiles = new int[]
			{
				0x6478, 0x6479, 0x647A, 
                0x647B, 0x647C, 0x647D, 0x647E, //Maple
			};

        private static int[] m_OhiiTreeTiles = new int[]
			{
                0x4C9E, //Ohii
			};

        private static int[] m_OliveTreeTiles = new int[]
			{
                0x4CD3, 0x4CD4, 0x4CD5, //Olive
			};

        private static int[] m_OakTreeTiles = new int[]
			{
				0x4CDA, 0x4CDB, 0x4CDC, 
                0x4CDD, 0x4CDE, 0x4CDF, //Oak
			};

        private static int[] m_PeachTreeTiles = new int[]
			{
                0x4D9C, 0x4D9D, 0x4D9E, 0x4D9F, 0x4DA0, 0x4DA1, 0x4DA2, 0x4DA3, 0x7123, //Peach Tree
			};

        private static int[] m_PearTreeTiles = new int[]
			{
                0x4DA4, 0x4DA5, 0x4DA6, 0x4DA7, 0x4DA8, 0x4DA9, 0x4DAA, 0x4DAB, //Pear Tree
			};

        private static int[] m_PlumTreeTiles = new int[]
			{
                0x66ED, 0x66EE, 0x66EF, 0x66F0, 0x66F1, 0x66F2, 0x66F3, 0x7122, //Plum
			};

        private static int[] m_PoplarTreeTiles = new int[]
			{
				0x4D57, 0x4D58, 0x4D59, 0x4D5A, 0x4D5B, 0x4D5C, 
				0x4D5D, 0x4D5E, 0x4D5F, 0x4D60, 0x4D61, 0x4D62, 
                0x4D63, 0x4D64, 0x4D65, 0x4D66, 0x4D67, 0x4D68, 0x4D69, //Poplar
			};

        private static int[] m_SandalwoodTreeTiles = new int[]
			{
                0x4D84, 0x4D85, 0x4D86, 0x4D87, 0x4D88, 0x4D89, 
				0x4D8A, 0x4D8B, 0x4D8C, 0x4D8D, 0x4D8E, 0x4D8F, 0x4D90, //Sandalwood
			};

        private static int[] m_SpiderTreeTiles = new int[]
			{
                0x4CC9, //Spider Tree
			};

        private static int[] m_TuscanyPineTreeTiles = new int[]
			{
                0x5B7E, //Tuscany Pine
			};

        private static int[] m_WalnutTreeTiles = new int[]
			{
                0x4CE0, 0x4CE1, 0x4CE2, 
                0x4CE3, 0x4CE4, 0x4CE5, //Walnut
			};

        private static int[] m_WhiteBeechTreeTiles = new int[]
			{
                0x70D4, 0x70D5, 0x70D6, 0x70D7, 0x70D8, 
                0x70D9, 0x70DA, 0x70DB, 0x70DC, 0x70DD, 0x70DE, //WhiteBeech
			};

        private static int[] m_WillowTreeTiles = new int[]
			{
                0x4CE6, 0x4CE7, 0x4CE8, //Willow
			};

        private static int[] m_YewTreeTiles = new int[]
			{
				0x52B5, 0x52B6, 0x52B7, 0x52B8, 0x52B9, 0x52BA, 
				0x52BB, 0x52BC, 0x52BD, 0x52BE, 0x52BF, 0x52C0, 
				0x52C1, 0x52C2, 0x52C3, 0x52C4, 0x52C5, 0x52C6, 0x52C7, //Yew
			};

        private static int[] m_YuccaTreeTiles = new int[]
			{
                0x4D37, 0x4D38, //Yucca
			};
        #endregion

    }
}
