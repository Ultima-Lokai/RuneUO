using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Gumps;

namespace Server.Mobiles
{
	public class Mannequin : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }
		public override bool NoHouseRestrictions{ get{ return true; } }
		public override bool AllowEquipFrom( Mobile from ){ return m_Owner == from; }
		public override bool CheckNonlocalLift( Mobile from, Item item ){ return m_Owner == from; }
		public override bool CanBeDamaged(){ return false; }
		public override bool CanBeRenamedBy( Mobile from ){ return m_Owner == from; }
		public override bool CanPaperdollBeOpenedBy(Mobile from){ return true; }

	    public override bool IsInvulnerable { get { return true; } }

	    public Mobile m_Owner;

		[Constructable]
		public Mannequin( Mobile owner, bool female ) : base( AIType.AI_Use_Default, FightMode.None, 1, 1, 0.2, 0.2 )
		{
			m_Owner = owner;
			Name = "Mannequin";
			Title = "";
			NameHue = 1150;
			if( female )
				Body = 401;
			else
				Body = 400;

			CantWalk = true;
			Direction = Direction.South;
		    Blessed = true;
		}

		public override void GenerateLoot()
		{
		}

		public Mannequin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( m_Owner );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Owner = reader.ReadMobile();
		}
	}
}