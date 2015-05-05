
using Server.Items;

namespace Server.Runescape
{
    public abstract class RunescapePickaxe : RunescapeMeleeWeapon
    {
        public RunescapePickaxe(RuneWeaponType weaponType)
            : base(weaponType, 0xE86)
        {
        }

        public RunescapePickaxe(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class BronzePickaxe : RunescapePickaxe
    {
        [Constructable]
        public BronzePickaxe() : base(RuneWeaponType.Bronze) { }

        public BronzePickaxe(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Bronze Pickaxe"; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int) 0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class IronPickaxe : RunescapePickaxe
    {
        [Constructable]
        public IronPickaxe() : base(RuneWeaponType.Iron) { }

        public IronPickaxe(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Iron Pickaxe"; } }

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

    public class SteelPickaxe : RunescapePickaxe
    {
        [Constructable]
        public SteelPickaxe() : base(RuneWeaponType.Steel) { }

        public SteelPickaxe(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Steel Pickaxe"; } }

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

    public class MithrilPickaxe : RunescapePickaxe
    {
        [Constructable]
        public MithrilPickaxe() : base(RuneWeaponType.Mithril) { }

        public MithrilPickaxe(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Mithril Pickaxe"; } }

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

    public class AdamantitePickaxe : RunescapePickaxe
    {
        [Constructable]
        public AdamantitePickaxe() : base(RuneWeaponType.Adamantite) { }

        public AdamantitePickaxe(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Adamantite Pickaxe"; } }

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

    public class RunePickaxe : RunescapePickaxe
    {
        [Constructable]
        public RunePickaxe() : base(RuneWeaponType.Rune) { }

        public RunePickaxe(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Rune Pickaxe"; } }

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

    public class DragonPickaxe : RunescapePickaxe
    {
        [Constructable]
        public DragonPickaxe() : base(RuneWeaponType.Dragon) { }

        public DragonPickaxe(Serial serial) : base(serial) { }

        public override string DefaultName { get { return "Dragon Pickaxe"; } }

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