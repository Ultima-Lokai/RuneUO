using System;
using Server.Items;

namespace Server.Runescape
{
    public abstract class BaseMiningRocks : Item
    {
        private Ores mOreType;

        private DateTime mOreRespawnTime;

        public Ores OreType
        {
            get { return mOreType; }
        }

        public DateTime OreRespawnTime
        {
            get { return mOreRespawnTime; }
            set { mOreRespawnTime = value; }
        }

        public bool OrePresent { get; set; }

        public abstract BaseRunescapeOre GetOre();

        public bool GiveOreTo(Mobile m)
        {

            return false;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from != null && from.Backpack != null && from.InRange(this.Location, 1))
            {
                Item pick = from.FindItemOnLayer(Layer.OneHanded);
                Item[] items = from.Backpack.FindItemsByType(typeof (Pickaxe));
                if ((pick != null && pick is Pickaxe) ||
                    (from.Backpack != null && from.Backpack.FindItemByType(typeof (Pickaxe)) != null))
                {
                    // Face toward the Rocks
                    // Do Mining animation
                    // Keep doing it until successful
                    // Better picks mine faster
                    // Higher level rocks mine slower
                    // Chance to find a Gem
                    // Give ore
                    // Reset the OreRespawnTime
                }
                else
                {
                    from.SendMessage("You must have a pickaxe to Mine for ore.");
                }
            }
        }

        private Item SelectBestPick(Mobile from, Container pack)
        {
            Pickaxe item = null;
            Pickaxe[] picks = (Pickaxe[])pack.FindItemsByType(typeof(Pickaxe));
            foreach (Pickaxe pick in picks)
            {
                if ((item != null && PickIsBetterThanItem(pick, item)) || (item == null))
                {
                    if (pick.CanEquip(from))
                        item = pick;
                }
            }

            return item;
        }

        private bool PickIsBetterThanItem(Pickaxe pick, Pickaxe item)
        {

            return false;
        }

        public override int Hue
        {
            get
            {
                if (OrePresent)
                    switch (OreType)
                    {
                        case Ores.Adamantite:
                            return 0x363;
                        case Ores.Clay:
                            return 0x222;
                        case Ores.Coal:
                            return 0x7E3;
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
            OrePresent = true;
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
            return new GoldMetalOre();
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
            return new SilverMetalOre();
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
            return new IronMetalOre();
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
            return new CopperMetalOre();
        }
    }
}