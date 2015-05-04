

using Server.Items;

namespace Server.Runescape
{

    public class AmuletOfGlory : SilverNecklace
    {
        private int mCharges;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get { return mCharges; }
            set
            {
                mCharges = value;
                InvalidateProperties();
            }
        }

        [Constructable]
        public AmuletOfGlory() : base()
        {
            mCharges = 0;
        }

        public AmuletOfGlory(Serial serial) : base(serial) { }

        public override string DefaultName
        {
            get
            {
                return string.Format("Amulet of Glory{0}", Charges == 0 ? " (Uncharged)" : " (" + Charges + " Charges)");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
            writer.Write(mCharges);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            mCharges = reader.ReadInt();
        }
    }
}
