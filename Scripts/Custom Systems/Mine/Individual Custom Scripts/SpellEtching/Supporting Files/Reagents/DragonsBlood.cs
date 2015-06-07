using System;
using Server;
using Server.Items;

namespace Server.Custom
{
    public class DragonsBlood : BaseReagent, ICommodity
    {

        int ICommodity.DescriptionNumber
        {
            get
            {
                return this.LabelNumber;
            }
        }
        bool ICommodity.IsDeedable
        {
            get
            {
                return true;
            }
        }

        [Constructable]
        public DragonsBlood()
            : this(1)
        {
        }

        [Constructable]
        public DragonsBlood(int amount)
            : base(0xF82, amount)
        {
        }

        public DragonsBlood(Serial serial)
            : base(serial)
        {
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
        }
    }
}