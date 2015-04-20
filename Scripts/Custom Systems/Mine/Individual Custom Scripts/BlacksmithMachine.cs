/***************************************************************************
 *   BlacksmithMachine.cs. This program is free software; you 
 *   can redistribute it and/or modify it under the terms of the GNU GPL. 
 ***************************************************************************/

namespace Server.Items
{
    public class BlacksmithMachine : Item
    {
        [Constructable]
        public BlacksmithMachine()
            : base(0x9AA9)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (ItemID == 0x9AA9)
            {
                ItemID = 0x9A89;
                from.SendMessage("You turn on the machine.");
            }
            else
            {
                ItemID = 0x9AA9;
                from.SendMessage("You turn off the machine.");
            }
        }

        public override string DefaultName
        {
            get { return "a blacksmith machine"; }
        }

        public BlacksmithMachine(Serial serial)
            : base(serial)
        {
        }

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
