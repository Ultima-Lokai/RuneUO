/***************************************************************************
 *   TreeHarvestTool. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/

using System;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Targeting;
using Server.Engines.Harvest;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
    public class TreeHarvestTool : BaseHarvestTool
    {
        public override HarvestSystem HarvestSystem { get { return TreeHarvest.System; } }

        private Type m_Resource;

        private TreeResourceType m_ResourceType;
        public TreeResourceType ResourceType { get { return m_ResourceType; } set { m_ResourceType = value; } }

        public override string DefaultName { get { return "tree harvest tool"; } }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            list.Add(new ResourceEntry(from, this));
        }

        private class ResourceEntry : ContextMenuEntry
        {
            TreeHarvestTool m_Tool;
            Mobile m_From;

            public ResourceEntry(Mobile from, TreeHarvestTool tool)
                : base(5055)
            {
                m_From = from;
                m_Tool = tool;
            }

            public override void OnClick()
            {
                m_From.SendGump(new ResourceGump(m_From, m_Tool));
            }
        }

        [Constructable]
        public TreeHarvestTool()
            : this(500)
        {
        }

        [Constructable]
        public TreeHarvestTool(int uses)
            : base(uses, 0x2561)
        {
            Weight = 3.0;
        }

        public TreeHarvestTool(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((int)m_ResourceType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_ResourceType = (TreeResourceType)reader.ReadInt();
        }
    }

    public class ResourceGump : Gump
    {
        TreeHarvestTool m_Tool;
        Mobile m_From;

        public ResourceGump(Mobile from, TreeHarvestTool tool)
            : base(0, 0)
        {

            m_From = from;
            m_Tool = tool;

            m_From.CloseGump(typeof(ResourceGump));

            Closable = true;
            Dragable = true;
            Resizable = false;
            int bark = m_Tool.ResourceType == TreeResourceType.BarkSkin ? 2361 : 2360;
            int fruit = m_Tool.ResourceType == TreeResourceType.FruitNut ? 2361 : 2360;
            int leaf = m_Tool.ResourceType == TreeResourceType.LeafSpine ? 2361 : 2360;
            int root = m_Tool.ResourceType == TreeResourceType.RootBranch ? 2361 : 2360;
            int sap = m_Tool.ResourceType == TreeResourceType.SapJuice ? 2361 : 2360;
            int log = m_Tool.ResourceType == TreeResourceType.LogsBranches ? 2361 : 2360;
            //int body = m_From.Race.Name.Contains("argoyle") ? ( m_From.Female ? 665 : 666 )
            //    : m_From.Race.Name.Contains("lf") ? ( m_From.Female ? 15 : 14 )
            //    : m_From.Female ? 13 : 12;
            AddPage(0);
            AddBackground(40, 40, 404, 475, 9250);
            AddImage(40, 40, 50693); // Sapping blade
            AddImage(40, 40, from.Female ? 13 : 12, 145); // Body
            AddImage(40, 40, 50981); // Bark scraping wand
            AddImage(40, 40, 60479); // Sandals
            AddImage(40, 0, 50931); // Scythe
            AddImage(40, 20, 50644); // Axe
            AddImage(40, 40, 50561); // Coif
            AddImage(40, 40, 60517); // Robe
            AddImage(40, 40, 50617); // Staff
            AddImage(-3, 178, 50497); // Root digging blade
            AddImage(100, 50, m_Tool.ResourceType == TreeResourceType.FruitNut ? 11340 : 11374); // A Background
            AddImage(132, 50, m_Tool.ResourceType == TreeResourceType.LeafSpine ? 11340 : 11374);// B Background
            AddImage(52, 72, m_Tool.ResourceType == TreeResourceType.LogsBranches ? 11340 : 11374); // F Background
            AddImage(55, 109, m_Tool.ResourceType == TreeResourceType.BarkSkin ? 11340 : 11374); // C Background
            AddImage(60, 175, m_Tool.ResourceType == TreeResourceType.SapJuice ? 11340 : 11374); // D Background
            AddImage(61, 233, m_Tool.ResourceType == TreeResourceType.RootBranch ? 11340 : 11374); // E Background
            AddLabel(106, 55, 1378, @"A");
            AddLabel(121, 54, 1378, @"+");
            AddLabel(138, 55, 1378, @"B");
            AddLabel(58, 77, 1378, @"F");
            AddLabel(61, 114, 1378, @"C");
            AddLabel(66, 180, 1378, @"D");
            AddLabel(67, 238, 1378, @"E");
            AddLabel(70, 300, 1378, @"A");
            AddLabel(70, 330, 1378, @"B");
            AddLabel(70, 360, 1378, @"C");
            AddLabel(70, 390, 1378, @"D");
            AddLabel(70, 420, 1378, @"E");
            AddLabel(70, 450, 1378, @"F");
            AddLabel(170, 54, 0, @"Tree Harvest Tool");
            AddLabel(88, 300, 0, @"Fruit Picking Tool: for harvesting fruit and nuts");
            AddLabel(88, 330, 0, @"Leaf Picking Tool: for harvesting leaves and spines");
            AddLabel(88, 360, 0, @"Carving Tool: for harvesting bark and skin");
            AddLabel(88, 390, 0, @"Sapping Tool: for harvesting sap and juice");
            AddLabel(88, 420, 0, @"Digging Tool: for harvesting roots and buried branches");
            AddLabel(88, 450, 0, @"Chopping Tool: for harvesting logs and sturdy branches");
            AddButton(55, 304, fruit, 2362, (int)Buttons.FruitNut, GumpButtonType.Reply, 0);
            AddButton(55, 394, sap, 2362, (int)Buttons.SapJuice, GumpButtonType.Reply, 0);
            AddButton(55, 364, bark, 2362, (int)Buttons.BarkSkin, GumpButtonType.Reply, 0);
            AddButton(55, 334, leaf, 2362, (int)Buttons.LeafSpine, GumpButtonType.Reply, 0);
            AddButton(55, 424, root, 2362, (int)Buttons.RootBranch, GumpButtonType.Reply, 0);
            AddButton(55, 454, log, 2362, (int)Buttons.LogBranch, GumpButtonType.Reply, 0);
            AddItem(300, 65, 0x0C96);
            AddItem(167, 201, 0x194F);
            AddItem(207, 211, 0x0993);
            AddItem(220, 75, 0x0D94);
            AddItem(220, 75, 0x0D96);
            AddItem(270, 145, 0x0CDA);
            AddItem(270, 145, 0x0CDC);
            AddButton(133, 477, 9904, 9905, (int)Buttons.Investigate, GumpButtonType.Reply, 0);
            AddLabel(159, 478, 0, @"Investigate Tree");

        }

        private enum Buttons { FruitNut = 10, SapJuice, BarkSkin, LeafSpine, RootBranch, LogBranch, Investigate }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Buttons choice = (Buttons)info.ButtonID;
            switch (choice)
            {
                case Buttons.BarkSkin: m_Tool.ResourceType = TreeResourceType.BarkSkin;
                    m_From.SendGump(new ResourceGump(m_From, m_Tool)); break;
                case Buttons.FruitNut: m_Tool.ResourceType = TreeResourceType.FruitNut;
                    m_From.SendGump(new ResourceGump(m_From, m_Tool)); break;
                case Buttons.LeafSpine: m_Tool.ResourceType = TreeResourceType.LeafSpine;
                    m_From.SendGump(new ResourceGump(m_From, m_Tool)); break;
                case Buttons.RootBranch: m_Tool.ResourceType = TreeResourceType.RootBranch;
                    m_From.SendGump(new ResourceGump(m_From, m_Tool)); break;
                case Buttons.SapJuice: m_Tool.ResourceType = TreeResourceType.SapJuice;
                    m_From.SendGump(new ResourceGump(m_From, m_Tool)); break;
                case Buttons.LogBranch: m_Tool.ResourceType = TreeResourceType.LogsBranches;
                    m_From.SendGump(new ResourceGump(m_From, m_Tool)); break;
                case Buttons.Investigate: m_From.Target = new InternalTarget();
                    m_From.SendGump(new ResourceGump(m_From, m_Tool)); break;
                default: break;
            }
        }

        private class InternalTarget : Target
        {
            public InternalTarget()
                : base(6, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                bool none = true;
                bool validtarget = false;
                int tileID = 0;

                if (targeted is Static && !((Static)targeted).Movable)
                {
                    Static obj = (Static)targeted;
                    tileID = (obj.ItemID & 0x3FFF) | 0x4000;
                    validtarget = true;
                }
                else if (targeted is StaticTarget)
                {
                    StaticTarget obj = (StaticTarget)targeted;
                    tileID = (obj.ItemID & 0x3FFF) | 0x4000;
                    validtarget = true;
                }

                if (validtarget)
                {                    
                    TreeResource[] resources = TreeHarvest.GetResources(tileID);
                    if (resources.Length > 0)
                    {
                        none = false;
                        StringBuilder sb = new StringBuilder("That contains the following resources: ");
                        sb.Append(resources[0].ToString());
                        if (resources.Length > 1)
                        {
                            for (int x = 1; x < resources.Length; x++)
                            {
                                sb.Append(", ");
                                sb.Append(resources[x].ToString());
                            }
                        }
                        from.SendMessage(sb.ToString());
                    }
                }

                if (none)
                {
                    from.SendMessage("There are no tree resources there.");
                }
            }
        }
    }
}