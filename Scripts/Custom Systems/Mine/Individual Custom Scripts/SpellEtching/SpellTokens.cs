
using System;

namespace Server.Custom
{
    // First circle
    public class ClumsySpellToken : SpellToken
    {
        [Constructable]
        public ClumsySpellToken() : base(0)
        {
        }

        public ClumsySpellToken(Serial serial) : base(serial)
        {
        }

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
    }



    public class CreateFoodSpellToken : SpellToken
    {
        [Constructable]
        public CreateFoodSpellToken() : base(1)
        {
        }

        public CreateFoodSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class FeeblemindSpellToken : SpellToken
    {
        [Constructable]
        public FeeblemindSpellToken() : base(2)
        {
        }

        public FeeblemindSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class HealSpellToken : SpellToken
    {
        [Constructable]
        public HealSpellToken() : base(3)
        {
        }

        public HealSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MagicArrowSpellToken : SpellToken
    {
        [Constructable]
        public MagicArrowSpellToken() : base(4)
        {
        }

        public MagicArrowSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class NightSightSpellToken : SpellToken
    {
        [Constructable]
        public NightSightSpellToken() : base(5)
        {
        }

        public NightSightSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ReactiveArmorSpellToken : SpellToken
    {
        [Constructable]
        public ReactiveArmorSpellToken() : base(6)
        {
        }

        public ReactiveArmorSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class WeakenSpellToken : SpellToken
    {
        [Constructable]
        public WeakenSpellToken() : base(7)
        {
        }

        public WeakenSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Second circle
    public class AgilitySpellToken : SpellToken
    {
        [Constructable]
        public AgilitySpellToken() : base(8)
        {
        }

        public AgilitySpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class CunningSpellToken : SpellToken
    {
        [Constructable]
        public CunningSpellToken() : base(9)
        {
        }

        public CunningSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class CureSpellToken : SpellToken
    {
        [Constructable]
        public CureSpellToken() : base(10)
        {
        }

        public CureSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class HarmSpellToken : SpellToken
    {
        [Constructable]
        public HarmSpellToken() : base(11)
        {
        }

        public HarmSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MagicTrapSpellToken : SpellToken
    {
        [Constructable]
        public MagicTrapSpellToken() : base(12)
        {
        }

        public MagicTrapSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class RemoveTrapSpellToken : SpellToken
    {
        [Constructable]
        public RemoveTrapSpellToken() : base(13)
        {
        }

        public RemoveTrapSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ProtectionSpellToken : SpellToken
    {
        [Constructable]
        public ProtectionSpellToken() : base(14)
        {
        }

        public ProtectionSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class StrengthSpellToken : SpellToken
    {
        [Constructable]
        public StrengthSpellToken() : base(15)
        {
        }

        public StrengthSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Third circle
    public class BlessSpellToken : SpellToken
    {
        [Constructable]
        public BlessSpellToken() : base(16)
        {
        }

        public BlessSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class FireballSpellToken : SpellToken
    {
        [Constructable]
        public FireballSpellToken() : base(17)
        {
        }

        public FireballSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MagicLockSpellToken : SpellToken
    {
        [Constructable]
        public MagicLockSpellToken() : base(18)
        {
        }

        public MagicLockSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class PoisonSpellToken : SpellToken
    {
        [Constructable]
        public PoisonSpellToken() : base(19)
        {
        }

        public PoisonSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class TelekinesisSpellToken : SpellToken
    {
        [Constructable]
        public TelekinesisSpellToken() : base(20)
        {
        }

        public TelekinesisSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class TeleportSpellToken : SpellToken
    {
        [Constructable]
        public TeleportSpellToken() : base(21)
        {
        }

        public TeleportSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class UnlockSpellToken : SpellToken
    {
        [Constructable]
        public UnlockSpellToken() : base(22)
        {
        }

        public UnlockSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class WallOfStoneSpellToken : SpellToken
    {
        [Constructable]
        public WallOfStoneSpellToken() : base(23)
        {
        }

        public WallOfStoneSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Fourth circle
    public class ArchCureSpellToken : SpellToken
    {
        [Constructable]
        public ArchCureSpellToken() : base(24)
        {
        }

        public ArchCureSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ArchProtectionSpellToken : SpellToken
    {
        [Constructable]
        public ArchProtectionSpellToken() : base(25)
        {
        }

        public ArchProtectionSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class CurseSpellToken : SpellToken
    {
        [Constructable]
        public CurseSpellToken() : base(26)
        {
        }

        public CurseSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class FireFieldSpellToken : SpellToken
    {
        [Constructable]
        public FireFieldSpellToken() : base(27)
        {
        }

        public FireFieldSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class GreaterHealSpellToken : SpellToken
    {
        [Constructable]
        public GreaterHealSpellToken() : base(28)
        {
        }

        public GreaterHealSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class LightningSpellToken : SpellToken
    {
        [Constructable]
        public LightningSpellToken() : base(29)
        {
        }

        public LightningSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ManaDrainSpellToken : SpellToken
    {
        [Constructable]
        public ManaDrainSpellToken() : base(30)
        {
        }

        public ManaDrainSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class RecallSpellToken : SpellToken
    {
        [Constructable]
        public RecallSpellToken() : base(31)
        {
        }

        public RecallSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Fifth circle
    public class BladeSpiritsSpellToken : SpellToken
    {
        [Constructable]
        public BladeSpiritsSpellToken() : base(32)
        {
        }

        public BladeSpiritsSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class DispelFieldSpellToken : SpellToken
    {
        [Constructable]
        public DispelFieldSpellToken() : base(33)
        {
        }

        public DispelFieldSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class IncognitoSpellToken : SpellToken
    {
        [Constructable]
        public IncognitoSpellToken() : base(34)
        {
        }

        public IncognitoSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MagicReflectSpellToken : SpellToken
    {
        [Constructable]
        public MagicReflectSpellToken() : base(35)
        {
        }

        public MagicReflectSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MindBlastSpellToken : SpellToken
    {
        [Constructable]
        public MindBlastSpellToken() : base(36)
        {
        }

        public MindBlastSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ParalyzeSpellToken : SpellToken
    {
        [Constructable]
        public ParalyzeSpellToken() : base(37)
        {
        }

        public ParalyzeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class PoisonFieldSpellToken : SpellToken
    {
        [Constructable]
        public PoisonFieldSpellToken() : base(38)
        {
        }

        public PoisonFieldSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SummonCreatureSpellToken : SpellToken
    {
        [Constructable]
        public SummonCreatureSpellToken() : base(39)
        {
        }

        public SummonCreatureSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Sixth circle
    public class DispelSpellToken : SpellToken
    {
        [Constructable]
        public DispelSpellToken() : base(40)
        {
        }

        public DispelSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EnergyBoltSpellToken : SpellToken
    {
        [Constructable]
        public EnergyBoltSpellToken() : base(41)
        {
        }

        public EnergyBoltSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ExplosionSpellToken : SpellToken
    {
        [Constructable]
        public ExplosionSpellToken() : base(42)
        {
        }

        public ExplosionSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class InvisibilitySpellToken : SpellToken
    {
        [Constructable]
        public InvisibilitySpellToken() : base(43)
        {
        }

        public InvisibilitySpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MarkSpellToken : SpellToken
    {
        [Constructable]
        public MarkSpellToken() : base(44)
        {
        }

        public MarkSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MassCurseSpellToken : SpellToken
    {
        [Constructable]
        public MassCurseSpellToken() : base(45)
        {
        }

        public MassCurseSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ParalyzeFieldSpellToken : SpellToken
    {
        [Constructable]
        public ParalyzeFieldSpellToken() : base(46)
        {
        }

        public ParalyzeFieldSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class RevealSpellToken : SpellToken
    {
        [Constructable]
        public RevealSpellToken() : base(47)
        {
        }

        public RevealSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Seventh circle
    public class ChainLightningSpellToken : SpellToken
    {
        [Constructable]
        public ChainLightningSpellToken() : base(48)
        {
        }

        public ChainLightningSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EnergyFieldSpellToken : SpellToken
    {
        [Constructable]
        public EnergyFieldSpellToken() : base(49)
        {
        }

        public EnergyFieldSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class FlameStrikeSpellToken : SpellToken
    {
        [Constructable]
        public FlameStrikeSpellToken() : base(50)
        {
        }

        public FlameStrikeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class GateTravelSpellToken : SpellToken
    {
        [Constructable]
        public GateTravelSpellToken() : base(51)
        {
        }

        public GateTravelSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ManaVampireSpellToken : SpellToken
    {
        [Constructable]
        public ManaVampireSpellToken() : base(52)
        {
        }

        public ManaVampireSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MassDispelSpellToken : SpellToken
    {
        [Constructable]
        public MassDispelSpellToken() : base(53)
        {
        }

        public MassDispelSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MeteorSwarmSpellToken : SpellToken
    {
        [Constructable]
        public MeteorSwarmSpellToken() : base(54)
        {
        }

        public MeteorSwarmSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class PolymorphSpellToken : SpellToken
    {
        [Constructable]
        public PolymorphSpellToken() : base(55)
        {
        }

        public PolymorphSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Eighth circle
    public class EarthquakeSpellToken : SpellToken
    {
        [Constructable]
        public EarthquakeSpellToken() : base(56)
        {
        }

        public EarthquakeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EnergyVortexSpellToken : SpellToken
    {
        [Constructable]
        public EnergyVortexSpellToken() : base(57)
        {
        }

        public EnergyVortexSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ResurrectionSpellToken : SpellToken
    {
        [Constructable]
        public ResurrectionSpellToken() : base(58)
        {
        }

        public ResurrectionSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class AirElementalSpellToken : SpellToken
    {
        [Constructable]
        public AirElementalSpellToken() : base(59)
        {
        }

        public AirElementalSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SummonDaemonSpellToken : SpellToken
    {
        [Constructable]
        public SummonDaemonSpellToken() : base(60)
        {
        }

        public SummonDaemonSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EarthElementalSpellToken : SpellToken
    {
        [Constructable]
        public EarthElementalSpellToken() : base(61)
        {
        }

        public EarthElementalSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class FireElementalSpellToken : SpellToken
    {
        [Constructable]
        public FireElementalSpellToken() : base(62)
        {
        }

        public FireElementalSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class WaterElementalSpellToken : SpellToken
    {
        [Constructable]
        public WaterElementalSpellToken() : base(63)
        {
        }

        public WaterElementalSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Necromancy spells
    public class AnimateDeadSpellToken : SpellToken
    {
        [Constructable]
        public AnimateDeadSpellToken() : base(100)
        {
        }

        public AnimateDeadSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class BloodOathSpellToken : SpellToken
    {
        [Constructable]
        public BloodOathSpellToken() : base(101)
        {
        }

        public BloodOathSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class CorpseSkinSpellToken : SpellToken
    {
        [Constructable]
        public CorpseSkinSpellToken() : base(102)
        {
        }

        public CorpseSkinSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class CurseWeaponSpellToken : SpellToken
    {
        [Constructable]
        public CurseWeaponSpellToken() : base(103)
        {
        }

        public CurseWeaponSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EvilOmenSpellToken : SpellToken
    {
        [Constructable]
        public EvilOmenSpellToken() : base(104)
        {
        }

        public EvilOmenSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class HorrificBeastSpellToken : SpellToken
    {
        [Constructable]
        public HorrificBeastSpellToken() : base(105)
        {
        }

        public HorrificBeastSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class LichFormSpellToken : SpellToken
    {
        [Constructable]
        public LichFormSpellToken() : base(106)
        {
        }

        public LichFormSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MindRotSpellToken : SpellToken
    {
        [Constructable]
        public MindRotSpellToken() : base(107)
        {
        }

        public MindRotSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class PainSpikeSpellToken : SpellToken
    {
        [Constructable]
        public PainSpikeSpellToken() : base(108)
        {
        }

        public PainSpikeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class PoisonStrikeSpellToken : SpellToken
    {
        [Constructable]
        public PoisonStrikeSpellToken() : base(109)
        {
        }

        public PoisonStrikeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class StrangleSpellToken : SpellToken
    {
        [Constructable]
        public StrangleSpellToken() : base(110)
        {
        }

        public StrangleSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SummonFamiliarSpellToken : SpellToken
    {
        [Constructable]
        public SummonFamiliarSpellToken() : base(111)
        {
        }

        public SummonFamiliarSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class VampiricEmbraceSpellToken : SpellToken
    {
        [Constructable]
        public VampiricEmbraceSpellToken() : base(112)
        {
        }

        public VampiricEmbraceSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class VengefulSpiritSpellToken : SpellToken
    {
        [Constructable]
        public VengefulSpiritSpellToken() : base(113)
        {
        }

        public VengefulSpiritSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class WitherSpellToken : SpellToken
    {
        [Constructable]
        public WitherSpellToken() : base(114)
        {
        }

        public WitherSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class WraithFormSpellToken : SpellToken
    {
        [Constructable]
        public WraithFormSpellToken() : base(115)
        {
        }

        public WraithFormSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ExorcismSpellToken : SpellToken
    {
        [Constructable]
        public ExorcismSpellToken() : base(116)
        {
        }

        public ExorcismSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    // Paladin abilities
    public class CleanseByFireSpellToken : SpellToken
    {
        [Constructable]
        public CleanseByFireSpellToken() : base(200)
        {
        }

        public CleanseByFireSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class CloseWoundsSpellToken : SpellToken
    {
        [Constructable]
        public CloseWoundsSpellToken() : base(201)
        {
        }

        public CloseWoundsSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ConsecrateWeaponSpellToken : SpellToken
    {
        [Constructable]
        public ConsecrateWeaponSpellToken() : base(202)
        {
        }

        public ConsecrateWeaponSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class DispelEvilSpellToken : SpellToken
    {
        [Constructable]
        public DispelEvilSpellToken() : base(203)
        {
        }

        public DispelEvilSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class DivineFurySpellToken : SpellToken
    {
        [Constructable]
        public DivineFurySpellToken() : base(204)
        {
        }

        public DivineFurySpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EnemyOfOneSpellToken : SpellToken
    {
        [Constructable]
        public EnemyOfOneSpellToken() : base(205)
        {
        }

        public EnemyOfOneSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class HolyLightSpellToken : SpellToken
    {
        [Constructable]
        public HolyLightSpellToken() : base(206)
        {
        }

        public HolyLightSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class NobleSacrificeSpellToken : SpellToken
    {
        [Constructable]
        public NobleSacrificeSpellToken() : base(207)
        {
        }

        public NobleSacrificeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class RemoveCurseSpellToken : SpellToken
    {
        [Constructable]
        public RemoveCurseSpellToken() : base(208)
        {
        }

        public RemoveCurseSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SacredJourneySpellToken : SpellToken
    {
        [Constructable]
        public SacredJourneySpellToken() : base(209)
        {
        }

        public SacredJourneySpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    public class ArcaneCircleSpellToken : SpellToken
    {
        [Constructable]
        public ArcaneCircleSpellToken() : base(600)
        {
        }

        public ArcaneCircleSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class GiftOfRenewalSpellToken : SpellToken
    {
        [Constructable]
        public GiftOfRenewalSpellToken() : base(601)
        {
        }

        public GiftOfRenewalSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ImmolatingWeaponSpellToken : SpellToken
    {
        [Constructable]
        public ImmolatingWeaponSpellToken() : base(602)
        {
        }

        public ImmolatingWeaponSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class AttuneWeaponSpellToken : SpellToken
    {
        [Constructable]
        public AttuneWeaponSpellToken() : base(603)
        {
        }

        public AttuneWeaponSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ThunderstormSpellToken : SpellToken
    {
        [Constructable]
        public ThunderstormSpellToken() : base(604)
        {
        }

        public ThunderstormSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class NatureFurySpellToken : SpellToken
    {
        [Constructable]
        public NatureFurySpellToken() : base(605)
        {
        }

        public NatureFurySpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SummonFeySpellToken : SpellToken
    {
        [Constructable]
        public SummonFeySpellToken() : base(606)
        {
        }

        public SummonFeySpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SummonFiendSpellToken : SpellToken
    {
        [Constructable]
        public SummonFiendSpellToken() : base(607)
        {
        }

        public SummonFiendSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ReaperFormSpellToken : SpellToken
    {
        [Constructable]
        public ReaperFormSpellToken() : base(608)
        {
        }

        public ReaperFormSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class WildfireSpellToken : SpellToken
    {
        [Constructable]
        public WildfireSpellToken() : base(609)
        {
        }

        public WildfireSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EssenceOfWindSpellToken : SpellToken
    {
        [Constructable]
        public EssenceOfWindSpellToken() : base(610)
        {
        }

        public EssenceOfWindSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class DryadAllureSpellToken : SpellToken
    {
        [Constructable]
        public DryadAllureSpellToken() : base(611)
        {
        }

        public DryadAllureSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EtherealVoyageSpellToken : SpellToken
    {
        [Constructable]
        public EtherealVoyageSpellToken() : base(612)
        {
        }

        public EtherealVoyageSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class WordOfDeathSpellToken : SpellToken
    {
        [Constructable]
        public WordOfDeathSpellToken() : base(613)
        {
        }

        public WordOfDeathSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class GiftOfLifeSpellToken : SpellToken
    {
        [Constructable]
        public GiftOfLifeSpellToken() : base(614)
        {
        }

        public GiftOfLifeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class ArcaneEmpowermentSpellToken : SpellToken
    {
        [Constructable]
        public ArcaneEmpowermentSpellToken() : base(615)
        {
        }

        public ArcaneEmpowermentSpellToken(Serial serial) : base(serial)
        {
        }

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
    }


    public class NetherBoltSpellToken : SpellToken
    {
        [Constructable]
        public NetherBoltSpellToken() : base(677)
        {
        }

        public NetherBoltSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class HealingStoneSpellToken : SpellToken
    {
        [Constructable]
        public HealingStoneSpellToken() : base(678)
        {
        }

        public HealingStoneSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class PurgeMagicSpellToken : SpellToken
    {
        [Constructable]
        public PurgeMagicSpellToken() : base(679)
        {
        }

        public PurgeMagicSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EnchantSpellToken : SpellToken
    {
        [Constructable]
        public EnchantSpellToken() : base(680)
        {
        }

        public EnchantSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SleepSpellToken : SpellToken
    {
        [Constructable]
        public SleepSpellToken() : base(681)
        {
        }

        public SleepSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class EagleStrikeSpellToken : SpellToken
    {
        [Constructable]
        public EagleStrikeSpellToken() : base(682)
        {
        }

        public EagleStrikeSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class AnimatedWeaponSpellToken : SpellToken
    {
        [Constructable]
        public AnimatedWeaponSpellToken() : base(683)
        {
        }

        public AnimatedWeaponSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class StoneFormSpellToken : SpellToken
    {
        [Constructable]
        public StoneFormSpellToken() : base(684)
        {
        }

        public StoneFormSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SpellTriggerSpellToken : SpellToken
    {
        [Constructable]
        public SpellTriggerSpellToken() : base(685)
        {
        }

        public SpellTriggerSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class MassSleepSpellToken : SpellToken
    {
        [Constructable]
        public MassSleepSpellToken() : base(686)
        {
        }

        public MassSleepSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class CleansingWindsSpellToken : SpellToken
    {
        [Constructable]
        public CleansingWindsSpellToken() : base(687)
        {
        }

        public CleansingWindsSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class BombardSpellToken : SpellToken
    {
        [Constructable]
        public BombardSpellToken() : base(688)
        {
        }

        public BombardSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class SpellPlagueSpellToken : SpellToken
    {
        [Constructable]
        public SpellPlagueSpellToken() : base(689)
        {
        }

        public SpellPlagueSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class HailStormSpellToken : SpellToken
    {
        [Constructable]
        public HailStormSpellToken() : base(690)
        {
        }

        public HailStormSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class NetherCycloneSpellToken : SpellToken
    {
        [Constructable]
        public NetherCycloneSpellToken() : base(691)
        {
        }

        public NetherCycloneSpellToken(Serial serial) : base(serial)
        {
        }

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
    }

    public class RisingColossusSpellToken : SpellToken
    {
        [Constructable]
        public RisingColossusSpellToken() : base(692)
        {
        }

        public RisingColossusSpellToken(Serial serial) : base(serial)
        {
        }

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
    }
}