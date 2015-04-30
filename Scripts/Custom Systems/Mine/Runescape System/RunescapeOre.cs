

namespace Server.Runescape
{
    public abstract class BaseRunescapeOre : Item
    {
        private Ores mOreType;

        public Ores OreType
        {
            get { return mOreType; }
        }

        public override int Hue
        {
            get
            {
                switch (OreType)
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
            set { base.Hue = value; }
        }
        

        public BaseRunescapeOre(Ores oreType)
            : base(Utility.RandomBool() ? 0x19B9 : Utility.Random(4) + 0x19B7)
        {
            mOreType = oreType;
            Stackable = true;
        }

        public BaseRunescapeOre(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write((int)mOreType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        mOreType = (Ores)reader.ReadInt();
                        break;
                    }
            }
        }
    }

    public class ClayOre : BaseRunescapeOre
    {
        [Constructable]
        public ClayOre() : base(Ores.Clay) { }

        public ClayOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Clay Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class RuneOre : BaseRunescapeOre
    {
        [Constructable]
        public RuneOre() : base(Ores.Rune) { }

        public RuneOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Rune Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class RuneEssence : BaseRunescapeOre
    {
        [Constructable]
        public RuneEssence() : base(Ores.RuneEssence) { }

        public RuneEssence(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Rune Essence"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class AdamantiteOre : BaseRunescapeOre
    {
        [Constructable]
        public AdamantiteOre() : base(Ores.Adamantite) { }

        public AdamantiteOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Adamantite Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class MithrilOre : BaseRunescapeOre
    {
        [Constructable]
        public MithrilOre() : base(Ores.Mithril) { }

        public MithrilOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Mithril Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CoalOre : BaseRunescapeOre
    {
        [Constructable]
        public CoalOre() : base(Ores.Coal) { }

        public CoalOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Coal Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class GoldMetalOre : BaseRunescapeOre
    {
        [Constructable]
        public GoldMetalOre() : base(Ores.Gold) { }

        public GoldMetalOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Gold Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class SilverMetalOre : BaseRunescapeOre
    {
        [Constructable]
        public SilverMetalOre() : base(Ores.Silver) { }

        public SilverMetalOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Silver Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class IronMetalOre : BaseRunescapeOre
    {
        [Constructable]
        public IronMetalOre() : base(Ores.Iron) { }

        public IronMetalOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Iron Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class TinOre : BaseRunescapeOre
    {
        [Constructable]
        public TinOre() : base(Ores.Tin) { }

        public TinOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Tin Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class CopperMetalOre : BaseRunescapeOre
    {
        [Constructable]
        public CopperMetalOre() : base(Ores.Copper) { }

        public CopperMetalOre(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Copper Ore"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
