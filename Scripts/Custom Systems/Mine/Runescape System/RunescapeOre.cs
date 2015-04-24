using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Runescape
{
    public abstract class BaseRunescapeOre : Item
    {
        private Ores mOreType;

        public Ores OreType
        {
            get { return mOreType; }
        }
        public abstract BaseRunescapeOre GetOre();
        

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
}
