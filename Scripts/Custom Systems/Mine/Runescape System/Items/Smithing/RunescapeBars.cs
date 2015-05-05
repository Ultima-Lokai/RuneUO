

namespace Server.Runescape
{
    public abstract class RunescapeBar : Item
    {
        private Bars mBarType;

        public Bars BarType
        {
            get { return mBarType; }
        }

        public override int Hue
        {
            get { return Utilities.Hue(BarType); }
            set { base.Hue = value; }
        }

        public RunescapeBar(Bars barType)
            : base(0x1BF5)
        {
            mBarType = barType;
            Stackable = true;
        }

        public RunescapeBar(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write((int)mBarType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        mBarType = (Bars)reader.ReadInt();
                        break;
                    }
            }
        }
    }

    public class RuneBar : RunescapeBar
    {
        [Constructable]
        public RuneBar() : base(Bars.Rune) { }

        public RuneBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Rune Bar"; } }

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

    public class AdamantiteBar : RunescapeBar
    {
        [Constructable]
        public AdamantiteBar() : base(Bars.Adamantite) { }

        public AdamantiteBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Adamantite Bar"; } }

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

    public class MithrilBar : RunescapeBar
    {
        [Constructable]
        public MithrilBar() : base(Bars.Mithril) { }

        public MithrilBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Mithril Bar"; } }

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

    public class SteelBar : RunescapeBar
    {
        [Constructable]
        public SteelBar() : base(Bars.Steel) { }

        public SteelBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Steel Bar"; } }

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

    public class GoldMetalBar : RunescapeBar
    {
        [Constructable]
        public GoldMetalBar() : base(Bars.Gold) { }

        public GoldMetalBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Gold Bar"; } }

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

    public class SilverMetalBar : RunescapeBar
    {
        [Constructable]
        public SilverMetalBar() : base(Bars.Silver) { }

        public SilverMetalBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Silver Bar"; } }

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

    public class IronMetalBar : RunescapeBar
    {
        [Constructable]
        public IronMetalBar() : base(Bars.Iron) { }

        public IronMetalBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Iron Bar"; } }

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

    public class BronzeBar : RunescapeBar
    {
        [Constructable]
        public BronzeBar() : base(Bars.Bronze) { }

        public BronzeBar(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Bronze Bar"; } }

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
