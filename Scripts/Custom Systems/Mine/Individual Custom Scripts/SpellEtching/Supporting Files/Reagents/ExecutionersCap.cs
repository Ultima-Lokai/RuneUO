using System;
using Server;
using Server.Items;

namespace Server.Custom
{
    public class ExecutionersCap : BaseReagent, ICommodity
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
        public ExecutionersCap()
            : this(1)
        {
        }

        [Constructable]
        public ExecutionersCap(int amount)
            : base(0xF83, amount)
        {
        }

        public ExecutionersCap(Serial serial)
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