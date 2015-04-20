using System;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Engines.Harvest;

namespace Server.Items
{
    [FlipableAttribute(0xF43, 0xF44)]
    public class TreeHatchet : TreeHarvestTool
    {
        [Constructable]
        public TreeHatchet()
            : base(75)
        {
            Weight = 4.0;
            ResourceType = TreeResourceType.LogsBranches;
        }

        public override int ItemID
        {
            get { return 0xF43; }
            set { base.ItemID = value; }
        }

        public TreeHatchet(Serial serial)
            : base(serial)
        {
        }

        public override string DefaultName { get { return "tree hatchet"; } }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            // We do not want the context menu on this one.
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            ResourceType = TreeResourceType.LogsBranches;
        }
    }
}