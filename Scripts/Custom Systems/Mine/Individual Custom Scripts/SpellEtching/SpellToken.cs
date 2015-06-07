using System.Collections.Generic;
using Server.ContextMenus;
using Server.Items;
using Server.Spells;

namespace Server.Custom
{
    public class SpellToken : SpellScroll
    {
        public SpellToken(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                if (SpellID < 6) return 1027982 + SpellID;
                if (SpellID == 6) return 1027981;
                if (SpellID < 99) return 1027981 + SpellID;
                if (SpellID < 199) return 1028700 + SpellID;
                if (SpellID < 299) return 1028628 + SpellID;
                if (SpellID > 599 && SpellID < 699) return 1031001 + SpellID;

                return 502009;
            }
        }

        [Constructable]
        public SpellToken(int spellID)
            : base(spellID, 0x26B4, 1)
        {
            Stackable = false;
            Weight = 1.0;
        }

        public override int Hue
        {
            get
            {
                if (SpellID < 99) return 47;
                if (SpellID < 199) return 277;
                if (SpellID < 299) return 856;
                if (SpellID > 599 && SpellID < 699) return 872;
                
                return 0;
            }
            set { }
        }

        public string SpellType
        {
            get
            {
                if (SpellID < 99) return "(Regular)";
                if (SpellID < 199) return "(Necromancy)";
                if (SpellID < 299) return "(Paladin)";
                if (SpellID > 599 && SpellID < 650) return "(Spellweaving)";
                if (SpellID > 649 && SpellID < 699) return "(Mystic)";

                return "(Unknown)";
            }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add(1050045, "#{0}\t{1}\t{2}", LabelNumber, "Spell Token", SpellType);
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

            switch (version)
            {
                case 0:
                    {
                        break;
                    }
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!Multis.DesignContext.Check(from))
                return; // They are customizing

            if (!this.IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            Spell spell = SpellRegistry.NewSpell(SpellID, from, this);

            if (spell != null)
            {
                from.PlaySound(0x042);
                spell.Cast();
            }
            else
                from.SendLocalizedMessage(502345); // This spell has been temporarily disabled.
        }
    }
}