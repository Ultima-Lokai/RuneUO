using System;

namespace Server.Runescape
{
    public abstract class BaseMiningRocks : Item
    {
        private Ores mOreType;

        public Ores OreType
        {
            get { return mOreType; }
        }
        public abstract BaseRunescapeOre GetOre();

        public bool GiveOreTo(Mobile m)
        {

            return false;
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
                        return 0x1E7;
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

        public BaseMiningRocks(Ores oreType)
            : base(Utility.RandomBool() ? 0x1367 : Utility.Random(9) + 0x1363)
        {
            mOreType = oreType;
            Movable = false;
            Stackable = false;
        }

        public BaseMiningRocks(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int) 0);

            writer.Write((int) mOreType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                {
                    mOreType = (Ores) reader.ReadInt();
                    break;
                }
            }
        }
    }

    public class ClayRocks : BaseMiningRocks
    {
        [Constructable]
        public ClayRocks(): base(Ores.Clay){}

        public ClayRocks(Serial serial): base(serial){}

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

        public override BaseRunescapeOre GetOre()
        {
            return new ClayOre();
        }
    }

    public class RuneRocks : BaseMiningRocks
    {
        [Constructable]
        public RuneRocks() : base(Ores.Rune) { }

        public RuneRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new RuneOre();
        }
    }

    public class RuneEssenceRocks : BaseMiningRocks
    {
        [Constructable]
        public RuneEssenceRocks() : base(Ores.RuneEssence) { }

        public RuneEssenceRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new RuneEssence();
        }
    }

    public class AdamantiteRocks : BaseMiningRocks
    {
        [Constructable]
        public AdamantiteRocks() : base(Ores.Adamantite) { }

        public AdamantiteRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new AdamantiteOre();
        }
    }

    public class MithrilRocks : BaseMiningRocks
    {
        [Constructable]
        public MithrilRocks() : base(Ores.Mithril) { }

        public MithrilRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new MithrilOre();
        }
    } 

    public class CoalRocks : BaseMiningRocks
    {
        [Constructable]
        public CoalRocks() : base(Ores.Coal) { }

        public CoalRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new CoalOre();
        }
    }

    public class GoldRocks : BaseMiningRocks
    {
        [Constructable]
        public GoldRocks() : base(Ores.Gold) { }

        public GoldRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new NewGoldOre();
        }
    }

    public class SilverRocks : BaseMiningRocks
    {
        [Constructable]
        public SilverRocks() : base(Ores.Silver) { }

        public SilverRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new NewSilverOre();
        }
    }

    public class IronRocks : BaseMiningRocks
    {
        [Constructable]
        public IronRocks() : base(Ores.Iron) { }

        public IronRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new NewIronOre();
        }
    }

    public class TinRocks : BaseMiningRocks
    {
        [Constructable]
        public TinRocks() : base(Ores.Tin) { }

        public TinRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new TinOre();
        }
    }

    public class CopperRocks : BaseMiningRocks
    {
        [Constructable]
        public CopperRocks() : base(Ores.Copper) { }

        public CopperRocks(Serial serial) : base(serial) { }

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

        public override BaseRunescapeOre GetOre()
        {
            return new NewCopperOre();
        }
    }
}