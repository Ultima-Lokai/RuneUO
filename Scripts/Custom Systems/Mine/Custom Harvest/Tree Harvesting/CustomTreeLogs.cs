/***************************************************************************
 *   CustomTreeLogs.cs. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/

using System;

namespace Server.Items
{
    public class AppleTreeLog : CustomTreeLog
    {
        [Constructable]
        public AppleTreeLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Apple Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public AppleTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class AshTreeLog : CustomTreeLog
    {
        [Constructable]
        public AshTreeLog()
            : base(1, CraftResource.AshWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Ash Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public AshTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class BananaTreeLog : CustomTreeLog
    {
        [Constructable]
        public BananaTreeLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Banana Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public BananaTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class BlackCherryTreeLog : CustomTreeLog
    {
        [Constructable]
        public BlackCherryTreeLog()
            : base(1, CraftResource.Bloodwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Black Cherry Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public BlackCherryTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class BlackOakTreeLog : CustomTreeLog
    {
        [Constructable]
        public BlackOakTreeLog()
            : base(1, CraftResource.OakWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Black Oak Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public BlackOakTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CassiaTreeLog : CustomTreeLog
    {
        [Constructable]
        public CassiaTreeLog()
            : base(1, CraftResource.AshWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Cassia Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public CassiaTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CedarTreeLog : CustomTreeLog
    {
        [Constructable]
        public CedarTreeLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Cedar Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public CedarTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CherryTreeLog : CustomTreeLog
    {
        [Constructable]
        public CherryTreeLog()
            : base(1, CraftResource.Bloodwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Cherry Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public CherryTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CoconutPalmLog : CustomTreeLog
    {
        [Constructable]
        public CoconutPalmLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Coconut Palm Log{0}", Amount > 1 ? "s" : ""); }
        }

        public CoconutPalmLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CypressTreeLog : CustomTreeLog
    {
        [Constructable]
        public CypressTreeLog()
            : base(1, CraftResource.Frostwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Cypress Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public CypressTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class DatePalmLog : CustomTreeLog
    {
        [Constructable]
        public DatePalmLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Date Palm Log{0}", Amount > 1 ? "s" : ""); }
        }

        public DatePalmLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class DogwoodTreeLog : CustomTreeLog
    {
        [Constructable]
        public DogwoodTreeLog()
            : base(1, CraftResource.OakWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Dogwood Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public DogwoodTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class EucalyptusTreeLog : CustomTreeLog
    {
        [Constructable]
        public EucalyptusTreeLog()
            : base(1, CraftResource.Frostwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Eucalyptus Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public EucalyptusTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class FigTreeLog : CustomTreeLog
    {
        [Constructable]
        public FigTreeLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Fig Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public FigTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class HickoryTreeLog : CustomTreeLog
    {
        [Constructable]
        public HickoryTreeLog()
            : base(1, CraftResource.Bloodwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Hickory Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public HickoryTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class IronwoodTreeLog : CustomTreeLog
    {
        [Constructable]
        public IronwoodTreeLog()
            : base(1, CraftResource.Frostwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Ironwood Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public IronwoodTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class JuniperBushLog : CustomTreeLog
    {
        [Constructable]
        public JuniperBushLog()
            : base(1, CraftResource.RegularWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Juniper Bush Branch{0}", Amount > 1 ? "es" : ""); }
        }

        public JuniperBushLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class MapleTreeLog : CustomTreeLog
    {
        [Constructable]
        public MapleTreeLog()
            : base(1, CraftResource.RegularWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Maple Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public MapleTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class OakTreeLog : CustomTreeLog
    {
        [Constructable]
        public OakTreeLog()
            : base(1, CraftResource.OakWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Oak Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public OakTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class OhiiTreeLog : CustomTreeLog
    {
        [Constructable]
        public OhiiTreeLog()
            : base(1, CraftResource.Frostwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Ohii Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public OhiiTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class OliveTreeLog : CustomTreeLog
    {
        [Constructable]
        public OliveTreeLog()
            : base(1, CraftResource.Bloodwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Olive Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public OliveTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class PeachTreeLog : CustomTreeLog
    {
        [Constructable]
        public PeachTreeLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Peach Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public PeachTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class PearTreeLog : CustomTreeLog
    {
        [Constructable]
        public PearTreeLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Pear Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public PearTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class PipeCactusLog : CustomTreeLog
    {
        [Constructable]
        public PipeCactusLog()
            : base(1, CraftResource.Frostwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Pipe Cactus Log{0}", Amount > 1 ? "s" : ""); }
        }

        public PipeCactusLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class PlumTreeLog : CustomTreeLog
    {
        [Constructable]
        public PlumTreeLog()
            : base(1, CraftResource.Bloodwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Plum Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public PlumTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class PoplarTreeLog : CustomTreeLog
    {
        [Constructable]
        public PoplarTreeLog()
            : base(1, CraftResource.AshWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Poplar Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public PoplarTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SandalwoodTreeLog : CustomTreeLog
    {
        [Constructable]
        public SandalwoodTreeLog()
            : base(1, CraftResource.Frostwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Sandalwood Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public SandalwoodTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SpiderTreeLog : CustomTreeLog
    {
        [Constructable]
        public SpiderTreeLog()
            : base(1, CraftResource.OakWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Spider Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public SpiderTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TuscanyPineTreeLog : CustomTreeLog
    {
        [Constructable]
        public TuscanyPineTreeLog()
            : base(1, CraftResource.Frostwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Tuscany Pine Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public TuscanyPineTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class WalnutTreeLog : CustomTreeLog
    {
        [Constructable]
        public WalnutTreeLog()
            : base(1, CraftResource.Heartwood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Walnut Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public WalnutTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class WhiteBeechTreeLog : CustomTreeLog
    {
        [Constructable]
        public WhiteBeechTreeLog()
            : base(1, CraftResource.AshWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("White Beech Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public WhiteBeechTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class WillowTreeLog : CustomTreeLog
    {
        [Constructable]
        public WillowTreeLog()
            : base(1, CraftResource.AshWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Willow Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public WillowTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class YewTreeLog : CustomTreeLog
    {
        [Constructable]
        public YewTreeLog()
            : base(1, CraftResource.AshWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Yew Tree Log{0}", Amount > 1 ? "s" : ""); }
        }

        public YewTreeLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class YuccaPlantLog : CustomTreeLog
    {
        [Constructable]
        public YuccaPlantLog() : base(1, CraftResource.AshWood)
        {
        }

        public override string DefaultName
        {
            get { return string.Format("Yucca Plant Branch{0}", Amount > 1 ? "es" : ""); }
        }

        public YuccaPlantLog(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CustomTreeLog : BaseLog
    {
        public double MinSkill
        {
            get
            {
                switch (Resource)
                {
                    case CraftResource.Bloodwood:
                    case CraftResource.Frostwood:
                    case CraftResource.Heartwood:
                        return 85.0;
                    case CraftResource.YewWood:
                        return 60.0;
                    case CraftResource.AshWood:
                        return 45.0;
                    case CraftResource.OakWood:
                        return 30.0;
                }
                return 0.0;
            }
        }

        [Constructable]
        public CustomTreeLog()
            : this(1)
        {
        }

        [Constructable]
        public CustomTreeLog(int amount)
            : this(amount, CraftResource.RegularWood)
        {
        }

        [Constructable]
        public CustomTreeLog(int amount, CraftResource resource)
            : base(resource, amount)
        {
        }

        public CustomTreeLog(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override bool Axe(Mobile from, BaseAxe axe)
        {
            return false;
        }
    }
}
