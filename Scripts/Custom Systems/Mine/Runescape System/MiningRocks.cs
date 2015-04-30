using System;
using Server.Items;

namespace Server.Runescape
{
    public abstract class BaseMiningRocks : Item
    {
        private Ores mOreType;

        private MyTimer myTimer;

        private class MyTimer : Timer
        {
            private BaseMiningRocks mRocks;

            public MyTimer(BaseMiningRocks rocks)
                : base(TimeSpan.FromSeconds(RespawnSeconds(rocks.OreType)))
            {
                mRocks = rocks;
                mRocks.InvalidateProperties();
            }
            
            protected override void OnTick()
            {
                mRocks.OrePresent = true;
                mRocks.InvalidateProperties();
            }
        }

        private static int RespawnSeconds(Ores ores)
        {
            switch (ores)
            {
                case Ores.Clay:
                    return 4;
                case Ores.Iron:
                    return 6;
                case Ores.Silver:
                    return 15;
                case Ores.Gold:
                    return 27;
                case Ores.Coal:
                    return 103;
                case Ores.Mithril:
                    return 226;
                case Ores.Adamantite:
                    return 1156;
                case Ores.Rune:
                    return 12019;
                case Ores.RuneEssence:
                case Ores.Copper:
                case Ores.Tin:
                default:
                    return 2;
            }
        }

        public Ores OreType
        {
            get { return mOreType; }
        }

        public bool OrePresent { get; set; }

        public abstract BaseRunescapeOre GetOre();

        public bool GiveOreTo(Mobile m)
        {

            return false;
        }

        public override void AddNameProperties(ObjectPropertyList list)
        {
            base.AddNameProperties(list);

            list.Add(OrePresent ? "* Double-click to mine. *" : "* No ore present. *");
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Backpack != null && from.InRange(this.Location, 1))
            {
                if (OrePresent)
                {
                    Item pick = from.FindItemOnLayer(Layer.OneHanded);
                    if (pick == null) pick = SelectBestPick(from, from.Backpack);
                    if (pick != null && pick is RunescapePickaxe)
                    {
                        from.SendMessage("You swing your {0} at the rocks.", pick.Name);
                        // Face toward the Rocks
                        // Do Mining animation
                        // Keep doing it until successful
                        // Better picks mine faster
                        // Higher level rocks mine slower
                        // Chance to find a Gem
                        // Give ore
                        Item ore = GetOre();
                        from.AddToBackpack(ore);

                        // Reset the OreRespawnTime
                        OrePresent = false;
                        myTimer.Start();
                        Hue = 0;
                        InvalidateProperties();
                    }
                    else
                    {
                        from.SendMessage("You must have a proper pickaxe to mine for ore.");
                    }
                }
                else
                {
                    from.SendMessage("There is no ore left in this rock.");
                }
            }
        }

        private Item SelectBestPick(Mobile from, Container pack)
        {
            RunescapePickaxe item = null;
            Item[] picks = pack.FindItemsByType(typeof(RunescapePickaxe));
            foreach (Item pickitem in picks)
            {
                if (pickitem is RunescapePickaxe)
                {
                    RunescapePickaxe pick = (RunescapePickaxe) pickitem;
                    if ((item != null && pick.WeaponType > item.WeaponType) || (item == null))
                    {
                        if (pick.CanEquip(from))
                            item = pick;
                    }
                }
            }

            return item;
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
            myTimer = new MyTimer(this);
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
                    OrePresent = true;
                    myTimer = new MyTimer(this);
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