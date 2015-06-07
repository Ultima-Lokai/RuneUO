using System;
using Server.Items;
using Server.Spells;
using Server.Custom;

namespace Server.Engines.Craft
{
    public class DefEtching : CraftSystem
    {
        public override SkillName MainSkill
        {
            get
            {
                return SkillName.Magery;
            }
        }

        public override string GumpTitleString
        {
            get { return "<CENTER>SPELL ETCHING MENU</CENTER>"; }
        }

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefEtching();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.0; // 0%
        }

        private DefEtching()
            : base(1, 1, 1.25)// base( 1, 1, 3.0 )
        {
        }

        public override int CanCraft(Mobile from, BaseTool tool, Type typeItem)
        {
            if (tool == null || tool.Deleted || tool.UsesRemaining < 0)
                return 1044038; // You have worn out your tool!
            else if (!BaseTool.CheckAccessible(tool, from))
                return 1044263; // The tool must be on your person to use.

            if (typeItem != null)
            {
                object o = Activator.CreateInstance(typeItem);

                if (o is SpellToken)
                {
                    SpellScroll scroll = (SpellToken)o;
                    Spellbook book = Spellbook.Find(from, scroll.SpellID);

                    bool hasSpell = (book != null && book.HasSpell(scroll.SpellID));

                    scroll.Delete();

                    return (hasSpell ? 0 : 1042404); // null : You don't have that spell!
                }
                else if (o is Item)
                {
                    ((Item)o).Delete();
                }
            }

            return 0;
        }

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x249);
        }

        private static readonly Type typeofSpellScroll = typeof(SpellToken);

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (!typeofSpellScroll.IsAssignableFrom(item.ItemType)) //  not a scroll
            {
                if (failed)
                {
                    if (lostMaterial)
                        return 1044043; // You failed to create the item, and some of your materials are lost.
                    else
                        return 1044157; // You failed to create the item, but no materials were lost.
                }
                else
                {
                    if (quality == 0)
                        return 502785; // You were barely able to make this item.  It's quality is below average.
                    else if (makersMark && quality == 2)
                        return 1044156; // You create an exceptional quality item and affix your maker's mark.
                    else if (quality == 2)
                        return 1044155; // You create an exceptional quality item.
                    else
                        return 1044154; // You create the item.
                }
            }
            else
            {
                if (failed)
                    return 501630; // You fail to inscribe the scroll, and the scroll is ruined.
                else
                    return 501629; // You inscribe the spell and put the scroll in your backpack.
            }
        }

        private int m_Circle, m_Mana;

        private enum Reg
        {
            BlackPearl,
            Bloodmoss,
            Garlic,
            Ginseng,
            MandrakeRoot,
            Nightshade,
            SulfurousAsh,
            SpidersSilk,
            DaemonBone,
            FertileDirt,
            DragonBlood,
            Bone,
            Blackmoor,
            Bloodspawn,
            Brimstone,
            EyeOfNewt,
            Obsidian,
            Pumice,
            WyrmsHeart
        }

        private readonly Type[] m_RegTypes = new Type[]
        {
            typeof (BlackPearl),
            typeof (Bloodmoss),
            typeof (Garlic),
            typeof (Ginseng),
            typeof (MandrakeRoot),
            typeof (Nightshade),
            typeof (SulfurousAsh),
            typeof (SpidersSilk),
            //Mysticism
            typeof (DaemonBone),
            typeof (FertileDirt),
            typeof (DragonBlood),
            typeof (Bone),
            //END
            typeof (Blackmoor),
            typeof (Bloodspawn),
            typeof (Brimstone),
            typeof (EyeOfNewt),
            typeof (Obsidian),
            typeof (Pumice),
            typeof (WyrmsHeart)
        };

        private int m_Index;

        private void AddSpell(Type type, params Reg[] regs)
        {
            double minSkill, maxSkill;

            switch (this.m_Circle)
            {
                default:
                case 0:
                    minSkill = -25.0;
                    maxSkill = 25.0;
                    break;
                case 1:
                    minSkill = -10.8;
                    maxSkill = 39.2;
                    break;
                case 2:
                    minSkill = 03.5;
                    maxSkill = 53.5;
                    break;
                case 3:
                    minSkill = 17.8;
                    maxSkill = 67.8;
                    break;
                case 4:
                    minSkill = 32.1;
                    maxSkill = 82.1;
                    break;
                case 5:
                    minSkill = 46.4;
                    maxSkill = 96.4;
                    break;
                case 6:
                    minSkill = 60.7;
                    maxSkill = 110.7;
                    break;
                case 7:
                    minSkill = 75.0;
                    maxSkill = 125.0;
                    break;
            }

            int index = this.AddCraft(type, 1044369 + this.m_Circle, 1044381 + this.m_Index++, minSkill, maxSkill, this.m_RegTypes[(int)regs[0]], 1044353 + (int)regs[0], 1, 1044361 + (int)regs[0]);

            for (int i = 1; i < regs.Length; ++i)
                this.AddRes(index, this.m_RegTypes[(int)regs[i]], 1044353 + (int)regs[i], 1, 1044361 + (int)regs[i]);

            this.AddRes(index, typeof(EyeOfNewt), 1023975, 1, "You do not have enough Eye Of Newt to Etch this spell.");

            this.SetManaReq(index, this.m_Mana);
        }

        private void AddNecroSpell(int spell, int mana, double minSkill, Type type, params Type[] regs)
        {
            int id = CraftItem.ItemIDOf(regs[0]);

            int index = this.AddCraft(type, 1061677, 1060509 + spell, minSkill, minSkill + 1.0, regs[0], id < 0x4000 ? 1020000 + id : 1078872 + id, 1, 501627);	//Yes, on OSI it's only 1.0 skill diff'.  Don't blame me, blame OSI.

            for (int i = 1; i < regs.Length; ++i)
            {
                id = CraftItem.ItemIDOf(regs[i]);
                this.AddRes(index, regs[i], id < 0x4000 ? 1020000 + id : 1078872 + id, 1, 501627);
            }

            this.AddRes(index, typeof(Obsidian), 1023977, 1, "You do not have enough Obsidian to Etch this spell.");

            this.SetManaReq(index, mana);
        }

        private void AddPaladinSpell(string spell, int mana, double minSkill, Type type, params Type[] regs)
        {
            int index = this.AddCraft(type, "Paladin Abilities", spell, minSkill, minSkill + 1.0, regs[0], 1020000 + CraftItem.ItemIDOf(regs[0]), 1, 501627);

            for (int i = 1; i < regs.Length; ++i)
                this.AddRes(index, regs[i], 1020000 + CraftItem.ItemIDOf(regs[i]), 1, 501627);

            this.AddRes(index, typeof(WyrmsHeart), 1023985, 1, "You do not have enough Wyrm's Heart to Etch this spell.");

            this.SetManaReq(index, mana);
        }

        private void AddSpellWeavingSpell(string spell, int mana, double minSkill, Type type, params Type[] regs)
        {
            int index = this.AddCraft(type, "Spells Weaving", spell, minSkill, minSkill + 1.0, regs[0], 1020000 + CraftItem.ItemIDOf(regs[0]), 1, 501627);

            for (int i = 1; i < regs.Length; ++i)
                this.AddRes(index, regs[i], 1020000 + CraftItem.ItemIDOf(regs[i]), 1, 501627);

            this.AddRes(index, typeof(Pumice), 1023979, 1, "You do not have enough Pumice to Etch this spell.");

            this.SetManaReq(index, mana);
        }

        private void AddMysticSpell(string spell, int mana, double minSkill, Type type, params Type[] regs)
        {
            int index = this.AddCraft(type, "Spells of Mysticism", spell, minSkill, minSkill + 1.0, regs[0], 1020000 + CraftItem.ItemIDOf(regs[0]), 1, 501627);	

            for (int i = 1; i < regs.Length; ++i)
                this.AddRes(index, regs[i], 1020000 + CraftItem.ItemIDOf(regs[i]), 1, 501627);

            this.AddRes(index, typeof(Bloodspawn), 1023964, 1, "You do not have enough Bloodspawn to Etch this spell.");

            this.SetManaReq(index, mana);
        }

        public override void InitCraftList()
        {
            this.m_Circle = 0;
            this.m_Mana = 4;

            this.AddSpell(typeof(ReactiveArmorSpellToken), Reg.Garlic, Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(ClumsySpellToken), Reg.Bloodmoss, Reg.Nightshade);
            this.AddSpell(typeof(CreateFoodSpellToken), Reg.Garlic, Reg.Ginseng, Reg.MandrakeRoot);
            this.AddSpell(typeof(FeeblemindSpellToken), Reg.Nightshade, Reg.Ginseng);
            this.AddSpell(typeof(HealSpellToken), Reg.Garlic, Reg.Ginseng, Reg.SpidersSilk);
            this.AddSpell(typeof(MagicArrowSpellToken), Reg.SulfurousAsh);
            this.AddSpell(typeof(NightSightSpellToken), Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(WeakenSpellToken), Reg.Garlic, Reg.Nightshade);

            this.m_Circle = 1;
            this.m_Mana = 6;

            this.AddSpell(typeof(AgilitySpellToken), Reg.Bloodmoss, Reg.MandrakeRoot);
            this.AddSpell(typeof(CunningSpellToken), Reg.Nightshade, Reg.MandrakeRoot);
            this.AddSpell(typeof(CureSpellToken), Reg.Garlic, Reg.Ginseng);
            this.AddSpell(typeof(HarmSpellToken), Reg.Nightshade, Reg.SpidersSilk);
            this.AddSpell(typeof(MagicTrapSpellToken), Reg.Garlic, Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(RemoveTrapSpellToken), Reg.Bloodmoss, Reg.SulfurousAsh);
            this.AddSpell(typeof(ProtectionSpellToken), Reg.Garlic, Reg.Ginseng, Reg.SulfurousAsh);
            this.AddSpell(typeof(StrengthSpellToken), Reg.Nightshade, Reg.MandrakeRoot);

            this.m_Circle = 2;
            this.m_Mana = 9;

            this.AddSpell(typeof(BlessSpellToken), Reg.Garlic, Reg.MandrakeRoot);
            this.AddSpell(typeof(FireballSpellToken), Reg.BlackPearl);
            this.AddSpell(typeof(MagicLockSpellToken), Reg.Bloodmoss, Reg.Garlic, Reg.SulfurousAsh);
            this.AddSpell(typeof(PoisonSpellToken), Reg.Nightshade);
            this.AddSpell(typeof(TelekinesisSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot);
            this.AddSpell(typeof(TeleportSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot);
            this.AddSpell(typeof(UnlockSpellToken), Reg.Bloodmoss, Reg.SulfurousAsh);
            this.AddSpell(typeof(WallOfStoneSpellToken), Reg.Bloodmoss, Reg.Garlic);

            this.m_Circle = 3;
            this.m_Mana = 11;

            this.AddSpell(typeof(ArchCureSpellToken), Reg.Garlic, Reg.Ginseng, Reg.MandrakeRoot);
            this.AddSpell(typeof(ArchProtectionSpellToken), Reg.Garlic, Reg.Ginseng, Reg.MandrakeRoot, Reg.SulfurousAsh);
            this.AddSpell(typeof(CurseSpellToken), Reg.Garlic, Reg.Nightshade, Reg.SulfurousAsh);
            this.AddSpell(typeof(FireFieldSpellToken), Reg.BlackPearl, Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(GreaterHealSpellToken), Reg.Garlic, Reg.SpidersSilk, Reg.MandrakeRoot, Reg.Ginseng);
            this.AddSpell(typeof(LightningSpellToken), Reg.MandrakeRoot, Reg.SulfurousAsh);
            this.AddSpell(typeof(ManaDrainSpellToken), Reg.BlackPearl, Reg.SpidersSilk, Reg.MandrakeRoot);
            this.AddSpell(typeof(RecallSpellToken), Reg.BlackPearl, Reg.Bloodmoss, Reg.MandrakeRoot);

            this.m_Circle = 4;
            this.m_Mana = 14;

            this.AddSpell(typeof(BladeSpiritsSpellToken), Reg.BlackPearl, Reg.Nightshade, Reg.MandrakeRoot);
            this.AddSpell(typeof(DispelFieldSpellToken), Reg.BlackPearl, Reg.Garlic, Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(IncognitoSpellToken), Reg.Bloodmoss, Reg.Garlic, Reg.Nightshade);
            this.AddSpell(typeof(MagicReflectSpellToken), Reg.Garlic, Reg.MandrakeRoot, Reg.SpidersSilk);
            this.AddSpell(typeof(MindBlastSpellToken), Reg.BlackPearl, Reg.MandrakeRoot, Reg.Nightshade, Reg.SulfurousAsh);
            this.AddSpell(typeof(ParalyzeSpellToken), Reg.Garlic, Reg.MandrakeRoot, Reg.SpidersSilk);
            this.AddSpell(typeof(PoisonFieldSpellToken), Reg.BlackPearl, Reg.Nightshade, Reg.SpidersSilk);
            this.AddSpell(typeof(SummonCreatureSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk);

            this.m_Circle = 5;
            this.m_Mana = 20;

            this.AddSpell(typeof(DispelSpellToken), Reg.Garlic, Reg.MandrakeRoot, Reg.SulfurousAsh);
            this.AddSpell(typeof(EnergyBoltSpellToken), Reg.BlackPearl, Reg.Nightshade);
            this.AddSpell(typeof(ExplosionSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot);
            this.AddSpell(typeof(InvisibilitySpellToken), Reg.Bloodmoss, Reg.Nightshade);
            this.AddSpell(typeof(MarkSpellToken), Reg.Bloodmoss, Reg.BlackPearl, Reg.MandrakeRoot);
            this.AddSpell(typeof(MassCurseSpellToken), Reg.Garlic, Reg.MandrakeRoot, Reg.Nightshade, Reg.SulfurousAsh);
            this.AddSpell(typeof(ParalyzeFieldSpellToken), Reg.BlackPearl, Reg.Ginseng, Reg.SpidersSilk);
            this.AddSpell(typeof(RevealSpellToken), Reg.Bloodmoss, Reg.SulfurousAsh);

            this.m_Circle = 6;
            this.m_Mana = 40;

            this.AddSpell(typeof(ChainLightningSpellToken), Reg.BlackPearl, Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SulfurousAsh);
            this.AddSpell(typeof(EnergyFieldSpellToken), Reg.BlackPearl, Reg.MandrakeRoot, Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(FlameStrikeSpellToken), Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(GateTravelSpellToken), Reg.BlackPearl, Reg.MandrakeRoot, Reg.SulfurousAsh);
            this.AddSpell(typeof(ManaVampireSpellToken), Reg.BlackPearl, Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk);
            this.AddSpell(typeof(MassDispelSpellToken), Reg.BlackPearl, Reg.Garlic, Reg.MandrakeRoot, Reg.SulfurousAsh);
            this.AddSpell(typeof(MeteorSwarmSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SulfurousAsh, Reg.SpidersSilk);
            this.AddSpell(typeof(PolymorphSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk);

            this.m_Circle = 7;
            this.m_Mana = 50;

            this.AddSpell(typeof(EarthquakeSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.Ginseng, Reg.SulfurousAsh);
            this.AddSpell(typeof(EnergyVortexSpellToken), Reg.BlackPearl, Reg.Bloodmoss, Reg.MandrakeRoot, Reg.Nightshade);
            this.AddSpell(typeof(ResurrectionSpellToken), Reg.Bloodmoss, Reg.Garlic, Reg.Ginseng);
            this.AddSpell(typeof(AirElementalSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk);
            this.AddSpell(typeof(SummonDaemonSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(EarthElementalSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk);
            this.AddSpell(typeof(FireElementalSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk, Reg.SulfurousAsh);
            this.AddSpell(typeof(WaterElementalSpellToken), Reg.Bloodmoss, Reg.MandrakeRoot, Reg.SpidersSilk);

            if (Core.SE)
            {
                this.AddNecroSpell(0, 23, 39.6, typeof(AnimateDeadSpellToken), Reagent.GraveDust, Reagent.DaemonBlood);
                this.AddNecroSpell(1, 13, 19.6, typeof(BloodOathSpellToken), Reagent.DaemonBlood);
                this.AddNecroSpell(2, 11, 19.6, typeof(CorpseSkinSpellToken), Reagent.BatWing, Reagent.GraveDust);
                this.AddNecroSpell(3, 7, 19.6, typeof(CurseWeaponSpellToken), Reagent.PigIron);
                this.AddNecroSpell(4, 11, 19.6, typeof(EvilOmenSpellToken), Reagent.BatWing, Reagent.NoxCrystal);
                this.AddNecroSpell(5, 11, 39.6, typeof(HorrificBeastSpellToken), Reagent.BatWing, Reagent.DaemonBlood);
                this.AddNecroSpell(6, 23, 69.6, typeof(LichFormSpellToken), Reagent.GraveDust, Reagent.DaemonBlood, Reagent.NoxCrystal);
                this.AddNecroSpell(7, 17, 29.6, typeof(MindRotSpellToken), Reagent.BatWing, Reagent.DaemonBlood, Reagent.PigIron);
                this.AddNecroSpell(8, 5, 19.6, typeof(PainSpikeSpellToken), Reagent.GraveDust, Reagent.PigIron);
                this.AddNecroSpell(9, 17, 49.6, typeof(PoisonStrikeSpellToken), Reagent.NoxCrystal);
                this.AddNecroSpell(10, 29, 64.6, typeof(StrangleSpellToken), Reagent.DaemonBlood, Reagent.NoxCrystal);
                this.AddNecroSpell(11, 17, 29.6, typeof(SummonFamiliarSpellToken), Reagent.BatWing, Reagent.GraveDust, Reagent.DaemonBlood);
                this.AddNecroSpell(12, 23, 98.6, typeof(VampiricEmbraceSpellToken), Reagent.BatWing, Reagent.NoxCrystal, Reagent.PigIron);
                this.AddNecroSpell(13, 41, 79.6, typeof(VengefulSpiritSpellToken), Reagent.BatWing, Reagent.GraveDust, Reagent.PigIron);
                this.AddNecroSpell(14, 23, 59.6, typeof(WitherSpellToken), Reagent.GraveDust, Reagent.NoxCrystal, Reagent.PigIron);
                this.AddNecroSpell(15, 17, 79.6, typeof(WraithFormSpellToken), Reagent.NoxCrystal, Reagent.PigIron);
                this.AddNecroSpell(16, 40, 79.6, typeof(ExorcismSpellToken), Reagent.NoxCrystal, Reagent.GraveDust);
            }

            if (Core.ML)
            {
                //Mysticism Scrolls
                this.AddMysticSpell("Nether Bolt", 4, 0.0, typeof(NetherBoltSpellToken), Reagent.SulfurousAsh, Reagent.BlackPearl);
                this.AddMysticSpell("Healing Stone", 4, 0.0, typeof(HealingStoneSpellToken), Reagent.Bone, Reagent.Garlic, Reagent.Ginseng, Reagent.SpidersSilk);
                this.AddMysticSpell("Purge Magic", 6, 0.0, typeof(PurgeMagicSpellToken), Reagent.FertileDirt, Reagent.Garlic, Reagent.MandrakeRoot, Reagent.SulfurousAsh);
                this.AddMysticSpell("Enchant", 6, 0.0, typeof(EnchantSpellToken), Reagent.SpidersSilk, Reagent.MandrakeRoot, Reagent.SulfurousAsh);
                this.AddMysticSpell("Sleep", 9, 3.5, typeof(SleepSpellToken), Reagent.SpidersSilk, Reagent.BlackPearl, Reagent.Nightshade);
                this.AddMysticSpell("Eagle Strike", 9, 3.5, typeof(EagleStrikeSpellToken), Reagent.SpidersSilk, Reagent.Bloodmoss, Reagent.MandrakeRoot, Reagent.Bone);
                this.AddMysticSpell("Animated Weapon", 11, 17.8, typeof(AnimatedWeaponSpellToken), Reagent.Bone, Reagent.BlackPearl, Reagent.MandrakeRoot, Reagent.Nightshade);
                this.AddMysticSpell("Stone Form", 11, 17.8, typeof(StoneFormSpellToken), Reagent.Bloodmoss, Reagent.FertileDirt, Reagent.Garlic);
                this.AddMysticSpell("Spell Trigger", 14, 32.1, typeof(SpellTriggerSpellToken), Reagent.SpidersSilk, Reagent.MandrakeRoot, Reagent.Garlic, Reagent.DragonBlood);
                this.AddMysticSpell("Mass Sleep", 14, 32.1, typeof(MassSleepSpellToken), Reagent.SpidersSilk, Reagent.Nightshade, Reagent.Ginseng);
                this.AddMysticSpell("Cleansing Winds", 20, 46.4, typeof(CleansingWindsSpellToken), Reagent.Ginseng, Reagent.Garlic, Reagent.DragonBlood, Reagent.MandrakeRoot);
                this.AddMysticSpell("Bombard", 20, 46.4, typeof(BombardSpellToken), Reagent.Garlic, Reagent.DragonBlood, Reagent.SulfurousAsh, Reagent.Bloodmoss);
                this.AddMysticSpell("Spell Plague", 40, 60.7, typeof(SpellPlagueSpellToken), Reagent.Garlic, Reagent.DragonBlood, Reagent.MandrakeRoot, Reagent.Nightshade, Reagent.SulfurousAsh, Reagent.DaemonBone);
                this.AddMysticSpell("Hail Storm", 40, 60.7, typeof(HailStormSpellToken), Reagent.DragonBlood, Reagent.BlackPearl, Reagent.MandrakeRoot, Reagent.Bloodmoss);
                this.AddMysticSpell("Nether Cyclone", 50, 75.0, typeof(NetherCycloneSpellToken), Reagent.Bloodmoss, Reagent.Nightshade, Reagent.SulfurousAsh, Reagent.MandrakeRoot);
                this.AddMysticSpell("Rising Colossus", 50, 75.0, typeof(RisingColossusSpellToken), Reagent.DaemonBone, Reagent.FertileDirt, Reagent.DragonBlood, Reagent.Nightshade, Reagent.MandrakeRoot);
                //END
            }

            this.MarkOption = true;
        }
    }
}