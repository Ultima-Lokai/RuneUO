using System;
using Server.Items;
using Server.Network;

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
                : base(TimeSpan.FromSeconds(Utilities.RespawnSeconds(rocks.OreType)))
            {
                mRocks = rocks;
                mRocks.Hue = Utilities.Hue(mRocks.OreType);
                mRocks.InvalidateProperties();
            }
            
            protected override void OnTick()
            {
                mRocks.OrePresent = true;
                mRocks.Hue = Utilities.Hue(mRocks.OreType);
                mRocks.ReleaseWorldPackets();
                mRocks.InvalidateProperties();
            }
        }

        public Ores OreType
        {
            get { return mOreType; }
        }

        private bool mOrePresent;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool OrePresent
        {
            get { return mOrePresent; }
            set
            {
                mOrePresent = value;
                InvalidateProperties();
            }
        }

        public abstract BaseRunescapeOre GetOre();

        public void GiveOreTo(Mobile from)
        {
            Item ore = GetOre();
            if (from.AddToBackpack(ore))
                from.SendMessage("You mined some {0}", ore.Name);
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
                if (!from.Mounted)
                {
                    if (OrePresent)
                    {
                        Item pick = from.FindItemOnLayer(Layer.OneHanded);
                        if (pick == null) pick = SelectBestPick(from, from.Backpack);
                        if (pick != null && pick is RunescapePickaxe)
                        {
                            from.SendMessage("You swing your {0} at the rocks.", pick.Name);
                            new InternalTimer(from, this, (RunescapePickaxe)pick).Start();
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
                else
                {
                    from.SendLocalizedMessage(1061089); // You must dismount first.
                }
            }
        }

        private void ResetOreSpawn()
        {
            OrePresent = false;
            Hue = 0;
            myTimer.Start();
            InvalidateProperties();
            ReleaseWorldPackets();
        }

        private class InternalTimer : Timer
        {
            private Mobile player;
            private BaseMiningRocks rocks;
            private RunescapePickaxe pick;
            private bool successful;
            private int count;

            public InternalTimer(Mobile from, BaseMiningRocks miningRocks, RunescapePickaxe pickaxe)
                : base(TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(2), 30)
            {
                player = from;
                rocks = miningRocks;
                pick = pickaxe;
                successful = false;
                count = 0;
            }

            protected override void OnTick()
            {
                count++;
                // Face toward the Rocks
                player.Direction = player.GetDirectionTo(rocks.Location);

                if (rocks == null || !rocks.OrePresent || pick == null || !player.InRange(rocks.Location, 1))
                {
                    player.SendMessage("You stop mining.");
                    Stop();
                }

                // Do Mining animation
                player.Animate(Utility.RandomBool() ? 11 : 12, 4, 2, true, true, 1);

                // Chance to find a Gem
                BaseRunescapeGem gem = Utilities.FindGem(player, rocks.OreType, pick);
                if (gem != null)
                {
                    //give player a gem
                    if (player.AddToBackpack(gem))
                        player.SendMessage("You have found an {0}!", gem.Name);

                    return;
                }

                // Keep doing it until successful
                successful = Utility.Random(100) - (40 - count) > Utilities.MiningLevelNeeded(rocks.OreType); // This will be replaced once Levels are implemented.

                // Better picks mine faster
                // Higher level rocks mine slower
                
                if (successful)
                {
                    rocks.GiveOreTo(player);
                    rocks.ResetOreSpawn();
                    player.Animate(4, 1, 1, true, false, 0);
                    player.InvalidateProperties();
                    Stop();
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
                        if (Utilities.CanUse(from, pick))
                            item = pick;
                    }
                }
            }

            return item;
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public override int Hue
        {
            get { return OrePresent ? Utilities.Hue(OreType) : 0; }
            set { base.Hue = value; InvalidateProperties(); }
        }

        public BaseMiningRocks(Ores oreType)
            : base(Utility.RandomBool() ? 0x1367 : Utility.RandomList(0x1363, 0x1364, 0x1367, 0x136A, 0x136D))
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