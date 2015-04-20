using System;
using Server;
using Server.Mobiles;
using Server.Multis;
using Server.Custom_Systems.Mine.Mannequin;
using Server.Targeting;

namespace Server.Items
{

	[Flipable( 0x14F0, 0x14EF )]
	public class MannequinDeed : Item
	{
		[Constructable]
		public MannequinDeed() : base( 0x14F0 )
		{
			Name = "Mannequin Deed";
			LootType = LootType.Blessed;
		}

        public MannequinDeed(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
			    if (BaseHouse.FindHouseAt(from) != null && BaseHouse.FindHouseAt(from).Owner == from)
			    {
			        from.Target = new PlaceMannequinTarget(this);
			    }
			    else
			    {
                    from.SendLocalizedMessage(502092); // You must be in your house to do this.
			    }
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

        private class PlaceMannequinTarget: Target
        {
            private MannequinDeed mDeed;

            public PlaceMannequinTarget(MannequinDeed deed) : base(10, true, TargetFlags.None)
            {
                mDeed = deed;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is StaticTarget)
                {
                    IPoint3D p3d = targeted as IPoint3D;
                    BaseHouse house = BaseHouse.FindHouseAt(new Point3D(p3d), from.Map, p3d.Z);
                    if (p3d != null && house != null && house.Owner == from)
                    {
                        Mannequin m = new Mannequin(from, false);
                        m.Map = from.Map;
                        m.Location = new Point3D(p3d);
                        m.Direction = Direction.South;
                        mDeed.Delete();
                    }
                }
                else if (targeted is Item)
                {
                    
                }
            }
        }
	}
}
