

namespace Server.Runescape
{
    public abstract class BaseRunescapeGem : Item
    {
        private Gems mGemType;
        private bool mCut;

        public bool Cut { get { return mCut; } }

        public Gems GemType
        {
            get { return mGemType; }
        }

        public override int Hue
        {
            get { return Utilities.Hue(GemType); }
            set { base.Hue = value; }
        }


        public BaseRunescapeGem(Gems gemType)
            : base(Utility.RandomBool() ? 0x136C : Utility.RandomList(0x1368, 0x1369, 0x136B, 0x136C))
        {
            mGemType = gemType;
            Stackable = false;
            mCut = false;
        }

        public BaseRunescapeGem(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write((int)mGemType);
            writer.Write(mCut);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        mGemType = (Gems)reader.ReadInt();
                        mCut = reader.ReadBool();
                        //Cut gem should be 0x13A6
                        if (mCut) ItemID = 0x13A6;
                        break;
                    }
            }
        }
    }

    public class GemCuttingTools : Item
    {
        [Constructable]
        public GemCuttingTools() : base(0x1026) { }

        public GemCuttingTools(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "gem cutting tools"; } }

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

    public class EmeraldGem : BaseRunescapeGem
    {
        [Constructable]
        public EmeraldGem() : base(Gems.Emerald) { }

        public EmeraldGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Emerald", Cut ? "" : "Uncut "); } }

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

    public class RubyGem : BaseRunescapeGem
    {
        [Constructable]
        public RubyGem() : base(Gems.Ruby) { }

        public RubyGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Ruby", Cut ? "" : "Uncut "); } }

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

    public class DiamondGem : BaseRunescapeGem
    {
        [Constructable]
        public DiamondGem() : base(Gems.Diamond) { }

        public DiamondGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Diamond", Cut ? "" : "Uncut "); } }

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

    public class DragonstoneGem : BaseRunescapeGem
    {
        [Constructable]
        public DragonstoneGem() : base(Gems.Dragonstone) { }

        public DragonstoneGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Dragonstone", Cut ? "" : "Uncut "); } }

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

    public class OpalGem : BaseRunescapeGem
    {
        [Constructable]
        public OpalGem() : base(Gems.Opal) { }

        public OpalGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Opal", Cut ? "" : "Uncut "); } }

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

    public class JadeGem : BaseRunescapeGem
    {
        [Constructable]
        public JadeGem() : base(Gems.Jade) { }

        public JadeGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Jade", Cut ? "" : "Uncut "); } }

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

    public class TopazGem : BaseRunescapeGem
    {
        [Constructable]
        public TopazGem() : base(Gems.Topaz) { }

        public TopazGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Topaz", Cut ? "" : "Uncut "); } }

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

    public class SapphhireGem : BaseRunescapeGem
    {
        [Constructable]
        public SapphhireGem() : base(Gems.Sapphire) { }

        public SapphhireGem(Serial serial) : base(serial) { }

        public override string DefaultName { get { return string.Format("{0}Sapphire", Cut ? "" : "Uncut "); } }

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
