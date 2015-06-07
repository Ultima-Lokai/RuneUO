

using Server.Targeting;

namespace Server.Items
{
    public interface IShearable
    {
        bool Shear(Mobile from, Shears shears);
    }

    [Flipable(0xf9f, 0xf9e)]
    public class Shears : Item
    {
        [Constructable]
        public Shears()
            : base(0xF9F)
        {
            Weight = 1.0;
        }

        public Shears(Serial serial)
            : base(serial)
        { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendMessage("What do you want to use these shears on?");

            from.Target = new InternalTarget(this);
        }

        private class InternalTarget : Target
        {
            private readonly Shears _shears;

            public InternalTarget(Shears shears)
                : base(2, false, TargetFlags.None)
            {
                _shears = shears;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (_shears.Deleted)
                {
                    return;
                }
                
                if (targeted is IShearable)
                {
                    IShearable obj = (IShearable)targeted;

                    if (obj.Shear(from, _shears))
                    {
                        from.PlaySound(0x248);
                    }
                }
                else
                {
                    from.SendMessage("Shears can not be used on that to produce anything.");
                }
            }
        }
    }
}