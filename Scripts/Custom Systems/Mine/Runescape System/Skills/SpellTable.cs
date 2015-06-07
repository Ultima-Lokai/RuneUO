using System;

namespace Server.Runescape
{
    public enum SpellCategory
    {
        Teleport,Combat,Skilling
    }

    public enum SpellType
    {
        Standard,Lunar
    }

    public class RunescapeSpell
    {

        public RunescapeSpell(int id, string name, int level, int air, int water, int earth, int fire, int mind,
            int body, int cosmic, int chaos, int astral, int nature, int death, int law, int blood, int soul, double exp,
            SpellCategory category, SpellType spellGroup, string description, params Type[] ingredients)
            : this(id, name, level, air, water, earth, fire, mind, body, cosmic, chaos, astral, nature, death, law, blood,
                soul, exp, category, spellGroup, description, null, ingredients)
        {
        }

        public RunescapeSpell(int id, string name, int level, int air, int water, int earth, int fire, int mind,
            int body, int cosmic, int chaos, int astral, int nature, int death, int law, int blood, int soul, double exp,
            SpellCategory category, SpellType spellGroup, string description, Type requiredItem, params Type[] ingredients)
        {
            ID = id;
            Name = name;
            Level = level;
            Air = air;
            Water = water;
            Earth = earth;
            Fire = fire;
            Mind = mind;
            Body = body;
            Cosmic = cosmic;
            Chaos = chaos;
            Astral = astral;
            Nature = nature;
            Death = death;
            Law = law;
            Blood = blood;
            Soul = soul;
            Exp = exp;
            Category = category;
            SpellGroup = spellGroup;
            Description = description;
            RequiredItem = requiredItem;
            Ingredients = ingredients;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Air { get; set; }
        public int Water { get; set; }
        public int Earth { get; set; }
        public int Fire { get; set; }
        public int Mind { get; set; }
        public int Body { get; set; }
        public int Cosmic { get; set; }
        public int Chaos { get; set; }
        public int Astral { get; set; }
        public int Nature { get; set; }
        public int Death { get; set; }
        public int Law { get; set; }
        public int Blood { get; set; }
        public int Soul { get; set; }
        public double Exp { get; set; }
        public SpellCategory Category { get; set; }
        public SpellType SpellGroup { get; set; }
        public string Description { get; set; }
        public Type RequiredItem { get; set; }
        public Type[] Ingredients { get; set; }
    }

    public class SpellRegistry
    {
        public static void Initialize()
        {
            /*
            new RunescapeSpell (101,"Home Teleport",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to one of the lodestones. Locations can be found on the Lodestone Network page. It takes around 10 seconds to cast, gives no experience, and is interruptible by combat. Not useful at all as an Emergency teleport, but will suffice as a no cost teleport in a peaceful situation.")
            new RunescapeSpell (102,"Air Strike",0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,5.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 48 damage per cast.")
            new RunescapeSpell (103,"Confuse",3,0,3,2,0,0,1,0,0,0,0,0,0,0,0,13,SpellCategory.Combat,SpellType.Standard,"Reduces the target's chance to hit by 5% for 1 minute.")
            new RunescapeSpell (104,"Water Strike",5,1,1,0,0,1,0,0,0,0,0,0,0,0,0,7.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 48 damage per cast.")
            new RunescapeSpell (105,"Enchant Level 1 jewelry",7,0,1,0,0,0,0,1,0,0,0,0,0,0,0,17.5,SpellCategory.Skilling,SpellType.Standard,"Enchants sapphire jewelry.")
            new RunescapeSpell (106,"Earth Strike",9,1,0,2,0,1,0,0,0,0,0,0,0,0,0,9.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 86 damage per cast.")
            new RunescapeSpell (107,"Mobilising Armies Teleport",10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,19,SpellCategory.Teleport,SpellType.Standard,"Teleport yourself to the Mobilising Armies command centre.")
            new RunescapeSpell (108,"Weaken",11,0,3,2,0,0,1,0,0,0,0,0,0,0,0,21,SpellCategory.Combat,SpellType.Standard,"Reduces the target's damage dealt by 5% for 1 minute.")
            new RunescapeSpell (109,"Fire Strike",13,2,0,0,3,1,0,0,0,0,0,0,0,0,0,11.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 124 damage per cast.")
            new RunescapeSpell (110,"Bones to Bananas",15,0,2,2,0,0,0,0,0,0,1,0,0,0,0,25,SpellCategory.Skilling,SpellType.Standard,"Converts all bones in inventory into bananas.")
            new RunescapeSpell (111,"Air Bolt",17,2,0,0,0,0,0,0,1,0,0,0,0,0,0,13.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 163 damage per cast, previously 120 damage with chaos gauntlets.")
            new RunescapeSpell (112,"Curse",19,0,2,3,0,0,1,0,0,0,0,0,0,0,0,29,SpellCategory.Combat,SpellType.Standard,"Increases the target's damage received by 5% for 1 minute.")
            new RunescapeSpell (113,"Bind",20,0,3,3,0,0,0,0,0,0,2,0,0,0,0,30,SpellCategory.Combat,SpellType.Standard,"Prevents creatures from moving for 20 seconds, or players for 10 seconds.")
            new RunescapeSpell (114,"Low Alchemy *",21,0,0,0,3,0,0,0,0,0,1,0,0,0,0,31,SpellCategory.Skilling,SpellType.Standard,"Converts items into coins, equal to the value if the item was sold at a General Store.")
            new RunescapeSpell (115,"Water Bolt",23,2,2,0,0,0,0,0,1,0,0,0,0,0,0,16.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 220 damage per cast, previously 130 damage with chaos gauntlets.")
            new RunescapeSpell (116,"Varrock Teleport",25,3,0,0,1,0,0,0,0,0,0,0,1,0,0,35,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to the centre of Varrock, by the fountain near the shop. Players who have completed easy Varrock Tasks may teleport to the south entrance of the Grand Exchange instead.")
            new RunescapeSpell (117,"Enchant Level 2 jewelry",27,3,0,0,0,0,0,1,0,0,0,0,0,0,0,37,SpellCategory.Skilling,SpellType.Standard,"Enchants emerald jewelry.")
            new RunescapeSpell (118,"Earth Bolt",29,2,0,3,0,0,0,0,1,0,0,0,0,0,0,19.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 278 damage per cast, previously 140 damage with chaos gauntlets.")
            new RunescapeSpell (119,"Lumbridge Teleport",31,3,0,1,0,0,0,0,0,0,0,0,1,0,0,41,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to the centre of Lumbridge Castle.")
            new RunescapeSpell (120,"Telekinetic grab",33,1,0,0,0,0,0,0,0,0,0,0,1,0,0,43,SpellCategory.Skilling,SpellType.Standard,"Grabs an item off the ground without need for directly taking it.")
            new RunescapeSpell (121,"Fire Bolt",35,3,0,0,4,0,0,0,1,0,0,0,0,0,0,22.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 336 damage per cast, previously 150 damage with chaos gauntlets.")
            new RunescapeSpell (122,"Falador Teleport",37,3,1,0,0,0,0,0,0,0,0,0,1,0,0,48,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to the centre of Falador, next to the statue of Saradomin.")
            new RunescapeSpell (123,"House Teleport",40,1,0,1,0,0,0,0,0,0,0,0,1,0,0,30,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to his or her player-owned house.")
            new RunescapeSpell (124,"Air Blast",41,3,0,0,0,0,0,0,0,0,0,1,0,0,0,25.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 393 damage per cast.")
            new RunescapeSpell (125,"Superheat Item",43,0,0,0,4,0,0,0,0,0,1,0,0,0,0,53,SpellCategory.Skilling,SpellType.Standard,"Smelts ores without the need for a furnace. The chance of smelting iron ore increases to 100%.")
            new RunescapeSpell (126,"Camelot Teleport",45,5,0,0,0,0,0,0,0,0,0,0,1,0,0,55.5,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to the entrance of the castle at Camelot.")
            new RunescapeSpell (127,"Water Blast",47,3,3,0,0,0,0,0,0,0,0,1,0,0,0,28.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 451 damage per cast.")
            new RunescapeSpell (128,"Enchant Level 3 jewelry",49,0,0,0,5,0,0,0,0,0,1,0,0,0,0,59,SpellCategory.Skilling,SpellType.Standard,"Enchants ruby jewelry.")
            new RunescapeSpell (129,"Iban Blast",50,0,0,0,5,0,0,0,0,0,0,1,0,0,0,30,SpellCategory.Combat,SpellType.Standard,"Summons the wrath of Iban (Requires Iban Staff)",Iban Staff)
            new RunescapeSpell (130,"Slayer Dart",50,0,0,0,0,4,0,0,0,0,0,1,0,0,0,30,SpellCategory.Combat,SpellType.Standard,"Maximum damage of 480 per cast. Used to harm Turoths and Kurasks.",Slayer Staff)
            new RunescapeSpell (131,"Snare",50,0,4,4,0,0,0,0,0,0,3,0,0,0,0,60,SpellCategory.Combat,SpellType.Standard,"Prevents creatures from moving for 30 seconds, or players for 15 seconds.")
            new RunescapeSpell (132,"Ardougne Teleport",51,0,2,0,0,0,0,0,0,0,0,0,2,0,0,61,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to the marketplace in East Ardougne in the centre of the square. Completion of Plague City is required to use Ardougne Teleport.")
            new RunescapeSpell (133,"Earth Blast",53,3,0,4,0,0,0,0,0,0,0,1,0,0,0,31.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 508 damage per cast.")
            new RunescapeSpell (134,"High Alchemy",55,0,0,0,5,0,0,0,0,0,1,0,0,0,0,65,SpellCategory.Skilling,SpellType.Standard,"Converts items into more coins than Low Level Alchemy, equal to the value if the item was sold at a Specialty Shop: ie The Sword Shop in Varrock.")
            new RunescapeSpell (135,"Charge Water Orb",56,0,30,0,0,0,0,3,0,0,0,0,0,0,0,66,SpellCategory.Skilling,SpellType.Standard,"When cast at the Water Obelisk, this spell turns an unpowered orb into a water orb.",typeof(UnchargedOrb))
            new RunescapeSpell (136,"Enchant Level 4 jewelry",57,0,0,10,0,0,0,1,0,0,0,0,0,0,0,67,SpellCategory.Skilling,SpellType.Standard,"Enchants diamond jewelry.")
            new RunescapeSpell (137,"Watchtower Teleport",58,0,0,2,0,0,0,0,0,0,0,0,2,0,0,68,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to the top of the Watchtower. Completion of the Watchtower quest is required to use this spell.")
            new RunescapeSpell (138,"Fire Blast",59,4,0,0,5,0,0,0,0,0,0,1,0,0,0,34.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 566 damage per cast. Strongest offensive magic spell available to free players.")
            new RunescapeSpell (139,"Bones to Peaches",60,0,4,4,0,0,0,0,0,0,2,0,0,0,0,35.5,SpellCategory.Skilling,SpellType.Standard,"Converts all bones in inventory to peaches. Players must unlock this spell at the Mage Training Arena before using it.")
            new RunescapeSpell (140,"Charge Earth Orb",60,0,0,30,0,0,0,3,0,0,0,0,0,0,0,70,SpellCategory.Skilling,SpellType.Standard,"When cast at the Earth Obelisk, this spell turns an unpowered orb into an earth orb.",typeof(UnchargedOrb))
            new RunescapeSpell (141,"Trollheim Teleport",61,0,0,0,2,0,0,0,0,0,0,0,2,0,0,68,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to the very top of Trollheim, near Eadgar's cave. Completion of Eadgar's Ruse is required to use this spell.")
            new RunescapeSpell (142,"Air Wave",62,5,0,0,0,0,0,0,0,0,0,0,0,1,0,36,SpellCategory.Combat,SpellType.Standard,"Maximum of 595 damage per cast.")
            new RunescapeSpell (143,"Charge Fire Orb",63,0,0,0,30,0,0,3,0,0,0,0,0,0,0,73,SpellCategory.Skilling,SpellType.Standard,"When cast at the Fire Obelisk, this spell turns an unpowered orb into a fire orb.",typeof(UnchargedOrb))
            new RunescapeSpell (144,"Teleport Ape Atoll",64,0,2,0,2,0,0,0,0,0,0,0,2,0,0,76,SpellCategory.Teleport,SpellType.Standard,"Transports the caster to Ape Atoll. Partial completion of Recipe for Disaster is required to use this spell.",typeof(Banana))
            new RunescapeSpell (145,"Water Wave",65,5,7,0,0,0,0,0,0,0,0,0,0,1,0,37.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 624 damage per cast.")
            new RunescapeSpell (146,"Charge Air Orb",66,30,0,0,0,0,0,3,0,0,0,0,0,0,0,76,SpellCategory.Skilling,SpellType.Standard,"When cast at the Air Obelisk, this spell turns an unpowered orb into an air orb.",typeof(UnchargedOrb))
            new RunescapeSpell (147,"Vulnerability",66,0,5,5,0,0,0,0,0,0,0,0,0,0,1,76,SpellCategory.Combat,SpellType.Standard,"Increases the target's damage received by 10% for 1 minute.")
            new RunescapeSpell (148,"Enchant Level 5 jewelry",68,0,15,15,0,0,0,1,0,0,0,0,0,0,0,78,SpellCategory.Skilling,SpellType.Standard,"Enchants dragonstone jewelry.")
            new RunescapeSpell (149,"Earth Wave",70,5,0,7,0,0,0,0,0,0,0,0,0,1,0,40,SpellCategory.Combat,SpellType.Standard,"Maximum of 672 damage per cast.")
            new RunescapeSpell (150,"Enfeeble",73,0,8,8,0,0,0,0,0,0,0,0,0,0,1,83,SpellCategory.Combat,SpellType.Standard,"Lowers the target's damage dealt by 10% for 1 minute.")
            new RunescapeSpell (151,"Tele-other Lumbridge",74,0,0,1,0,0,0,0,0,0,0,0,1,0,1,84,SpellCategory.Teleport,SpellType.Standard,"Transports another player (who has Accept Aid switched on) to Lumbridge.")
            new RunescapeSpell (152,"Fire Wave",75,5,0,0,7,0,0,0,0,0,0,0,0,1,0,42.5,SpellCategory.Combat,SpellType.Standard,"Maximum of 720 damage per cast.")
            new RunescapeSpell (153,"Storm of Armadyl",77,0,0,0,0,0,0,0,0,0,0,0,0,0,0,91,SpellCategory.Combat,SpellType.Standard,"Maximum of 739 damage per cast.")
            new RunescapeSpell (154,"Entangle",79,0,5,5,0,0,0,0,0,0,4,0,0,0,0,89,SpellCategory.Combat,SpellType.Standard,"Prevents creatures from moving for 40 seconds, or players for 20 seconds.")
            new RunescapeSpell (155,"Stagger",80,0,12,12,0,0,0,0,0,0,0,0,0,0,1,90,SpellCategory.Combat,SpellType.Standard,"Reduces the target's chance to hit by 10% for 1 minute.")
            new RunescapeSpell (156,"Air Surge",81,7,0,0,0,0,0,0,0,0,0,1,0,1,0,75,SpellCategory.Combat,SpellType.Standard,"Maximum of 768 damage per cast.")
            new RunescapeSpell (157,"Tele-other Falador",82,0,1,0,0,0,0,0,0,0,0,0,1,0,1,92,SpellCategory.Teleport,SpellType.Standard,"Transports another player (who has Accept Aid switched on) to Falador.")
            new RunescapeSpell (158,"Teleport Block",85,0,0,0,0,0,0,0,1,0,0,1,1,0,0,80,SpellCategory.Combat,SpellType.Standard,"Blocks target from teleporting")
            new RunescapeSpell (159,"Water Surge",85,7,10,0,0,0,0,0,0,0,0,1,0,1,0,80,SpellCategory.Combat,SpellType.Standard,"Maximum of 816 damage per cast.")
            new RunescapeSpell (160,"Enchant Level 6 jewelry",87,0,0,20,20,0,0,1,0,0,0,0,0,0,0,97,SpellCategory.Skilling,SpellType.Standard,"Enchants onyx jewelry.")
            new RunescapeSpell (161,"Earth Surge",90,7,0,10,0,0,0,0,0,0,0,1,0,1,0,85,SpellCategory.Combat,SpellType.Standard,"Maximum of 864 damage per cast.")
            new RunescapeSpell (162,"Tele-other Camelot",90,0,0,0,0,0,0,0,0,0,0,0,1,0,2,100,SpellCategory.Teleport,SpellType.Standard,"Transports another player (who has Accept Aid switched on) to Camelot.")
            new RunescapeSpell (163,"Fire Surge",95,7,0,0,10,0,0,0,0,0,0,1,0,1,0,90,SpellCategory.Combat,SpellType.Standard,"Maximum of 912 damage per cast. This is the strongest normal elemental spell.")
            new RunescapeSpell (201,"Lunar Home Teleport",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster to one of the lodestones. Locations can be found on the Lodestone Network page. It takes around 10 seconds to cast, gives no experience, and is interruptible by combat. Not useful at all as an Emergency teleport, but will suffice as a no cost teleport in a peaceful situation.")
            new RunescapeSpell (202,"Bake Pie",65,0,4,0,5,0,0,0,0,1,0,0,0,0,0,60,SpellCategory.Skilling,SpellType.Lunar,"Bakes all uncooked pies in the caster's inventory. One set of runes is required for each pie.")
            new RunescapeSpell (203,"Cure Plant",66,0,0,8,0,0,0,0,0,1,0,0,0,0,0,60,SpellCategory.Skilling,SpellType.Lunar,"Cures a diseased plant.")
            new RunescapeSpell (204,"Monster Examine",66,0,0,0,0,1,0,1,0,1,0,0,0,0,0,61,SpellCategory.Combat,SpellType.Lunar,"Casting this on a monster produces the following information: Combat level, life points, maximum hit and whether it can be a Slayer assignment.")
            new RunescapeSpell (205,"NPC Contact",67,2,0,0,0,0,0,1,0,1,0,0,0,0,0,63,Varies,SpellType.Lunar,"Allows remote contact with Slayer masters and some other NPCs.")
            new RunescapeSpell (206,"Cure Other",68,0,0,10,0,0,0,0,0,1,0,0,0,0,0,48,SpellCategory.Combat,SpellType.Lunar,"Cures another player of poison.")
            new RunescapeSpell (207,"Humidify",68,0,3,0,1,0,0,0,0,1,0,0,0,0,0,65,SpellCategory.Skilling,SpellType.Lunar,"Fills all empty water-carrying vessels (such as vials and buckets) in the caster's inventory with water, excluding some quest-specific vessels.")
            new RunescapeSpell (208,"Moonclan Teleport",69,0,0,2,0,0,0,0,0,2,0,0,1,0,0,66,SpellCategory.Teleport,SpellType.Lunar,"Teleports the caster to Moonclan Island.")
            new RunescapeSpell (209,"Tele Group Moonclan",70,0,0,4,0,0,0,0,0,2,0,0,1,0,0,67,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, along with up to 4 other players (with Accept Aid on), to Moonclan Island.")
            new RunescapeSpell (210,"Cure Me",71,0,0,0,0,0,0,2,0,2,0,0,0,0,0,46,SpellCategory.Combat,SpellType.Lunar,"Cures the caster of poison.")
            new RunescapeSpell (211,"Ourania Teleport",71,0,0,6,0,0,0,0,0,2,0,0,1,0,0,69,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster outside the cave with the Ourania Runecrafting Altar")
            new RunescapeSpell (212,"Hunter Kit",71,0,0,2,0,0,0,0,0,2,0,0,0,0,0,70,SpellCategory.Skilling,SpellType.Lunar,"Gives the caster a noose wand, a butterfly net, a bird snare, a rabbit snare, a teasing stick, an unlit torch, and a box trap.")
            new RunescapeSpell (213,"South Falador Teleport",72,1,0,0,0,0,0,0,0,2,0,0,1,0,0,70,SpellCategory.Teleport,SpellType.Lunar,"Teleports the caster to the southern gate of Falador. Unlocked at the Livid Farm.")
            new RunescapeSpell (214,"Waterbirth Teleport",72,0,1,0,0,0,0,0,0,2,0,0,1,0,0,71,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster to Waterbirth Island.")
            new RunescapeSpell (215,"Tele Group Waterbirth",73,0,5,0,0,0,0,0,0,2,0,0,1,0,0,72,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, along with up to 4 other players (who have Accept Aid on), to Waterbirth Island.")
            new RunescapeSpell (216,"Cure Group",74,0,0,0,0,0,0,2,0,2,0,0,0,0,0,59,SpellCategory.Combat,SpellType.Lunar,"Cures up to 4 target players of poison.")
            new RunescapeSpell (217,"Repair Rune Pouch",75,0,0,0,0,0,0,1,0,2,0,0,1,0,0,75,SpellCategory.Skilling,SpellType.Lunar,"Cast on an essence pouch. Pouch is repaired and will take 5 times longer to deteriorate. Unlocked at Livid Farm.")
            new RunescapeSpell (218,"Barbarian Teleport",75,0,0,0,3,0,0,0,0,2,0,0,2,0,0,76,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster to the Barbarian Outpost.")
            new RunescapeSpell (219,"Stat Spy",75,0,0,0,0,0,5,2,0,2,0,0,0,0,0,76,SpellCategory.Combat,SpellType.Lunar,"Casting this on another player allows the caster to see the target's combat and non-combat stats, along with whether or not any stats have been boosted or reduced.")
            new RunescapeSpell (220,"North Ardougne Teleport",76,0,5,0,0,0,0,0,0,2,0,0,1,0,0,76,SpellCategory.Teleport,SpellType.Lunar,"Teleports the caster to the end of the pathway found north of East Ardougne's bank. Unlocked at Livid Farm.")
            new RunescapeSpell (221,"Tele Group Barbarian",76,0,0,0,6,0,0,0,0,2,0,0,2,0,0,77,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, along with up to 4 other players (who have Accept Aid on), to the Barbarian Outpost.")
            new RunescapeSpell (222,"Superglass Make",77,10,0,0,6,0,0,0,0,2,0,0,0,0,0,78,SpellCategory.Skilling,SpellType.Lunar,"Converts all sand and soda ash (or seaweed) in the caster's inventory into molten glass.")
            new RunescapeSpell (223,"Remote Farm",78,0,0,2,0,0,0,0,0,2,3,0,0,0,0,79,SpellCategory.Skilling,SpellType.Lunar,"Allows the status of farming patches in RuneScape to be viewed and, if a patch is diseased, it allows you to cure them. Unlocked at Livid Farm.")
            new RunescapeSpell (224,"Khazard Teleport",78,0,4,0,0,0,0,0,0,2,0,0,2,0,0,80,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster to Port Khazard.")
            new RunescapeSpell (225,"Tele Group Khazard",79,0,8,0,0,0,0,0,0,2,0,0,2,0,0,81,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, along with up to 4 other players (who have Accept Aid on), to Port Khazard.")
            new RunescapeSpell (226,"Dream",79,0,0,0,0,0,5,1,0,2,0,0,0,0,0,82,SpellCategory.Combat,SpellType.Lunar,"This spell puts the caster into a sleep state, during which life points regenerate at twice their usual rate. Any activity except talking will awaken the caster.")
            new RunescapeSpell (227,"Spiritualise Food",80,0,0,0,0,0,5,3,0,2,0,0,0,0,0,81,SpellCategory.Combat,SpellType.Lunar,"Cast on a food. This will heal your familiar and boost its stats. Unlocked at Livid Farm.")
            new RunescapeSpell (228,"String jewelry",80,0,5,10,0,0,0,0,0,2,0,0,0,0,0,83,SpellCategory.Skilling,SpellType.Lunar,"Strings all unstrung amulets in the caster's inventory.")
            new RunescapeSpell (229,"Stat Restore Pot Share",81,0,10,10,0,0,0,0,0,2,0,0,0,0,0,49,SpellCategory.Combat,SpellType.Lunar,"This spell can target up to 4 other players. Each target receives a dose of a restoration potion (such as a prayer potion) from the caster's inventory.")
            new RunescapeSpell (230,"Magic Imbue",82,0,7,0,7,0,0,0,0,2,0,0,0,0,0,86,SpellCategory.Skilling,SpellType.Lunar,"Allows combination of runes without the need for a talisman for a short time.")
            new RunescapeSpell (231,"Fertile Soil",83,0,0,15,0,0,0,0,0,3,2,0,0,0,0,87,SpellCategory.Skilling,SpellType.Lunar,"Treats a farming patch with supercompost.")
            new RunescapeSpell (232,"Make Leather",83,0,0,0,2,0,2,0,0,2,0,0,0,0,0,87,SpellCategory.Skilling,SpellType.Lunar,"Lets the player tan up to 5 hides per cast. Unlocked at Livid Farm.")
            new RunescapeSpell (233,"Boost Potion Share",84,0,10,12,0,0,0,0,0,3,0,0,0,0,0,62,SpellCategory.Combat,SpellType.Lunar,"Has the same effect as Stat Restore Pot Share, except with a potion that boosts a stat (such as a strength potion).")
            new RunescapeSpell (234,"Fishing Guild Teleport",85,0,10,0,0,0,0,0,0,3,0,0,3,0,0,89,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster to the Fishing Guild.")
            new RunescapeSpell (235,"Plank Make",86,0,0,15,0,0,0,0,0,2,1,0,0,0,0,90,SpellCategory.Skilling,SpellType.Lunar,"Transforms one log in the caster's inventory into a plank of the appropriate type. Like the Sawmill, coins are still required to convert logs, but less than if the logs had been taken to the Sawmill.", typeof(Coin))
            new RunescapeSpell (236,"Tele Group Fishing Guild",86,0,14,0,0,0,0,0,0,3,0,0,3,0,0,90,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, along with up to 4 other players (who have Accept Aid turned on) to the Fishing Guild.")
            new RunescapeSpell (237,"Tune Bane Ore",87,0,0,4,0,0,0,0,0,2,0,0,0,0,0,90,SpellCategory.Skilling,SpellType.Lunar,"Tunes bane ore against a specific creature.", typeof(BaneOre), typeof(BaneItem) )
            new RunescapeSpell (238,"Catherby Teleport",87,0,10,0,0,0,0,0,0,3,0,0,3,0,0,92,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster to Catherby.")
            new RunescapeSpell (239,"Tele Group Catherby",88,0,15,0,0,0,0,0,0,3,0,0,3,0,0,93,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, and up to 4 other players (who have Accept Aid on), to Catherby.")
            new RunescapeSpell (240,"Ice Plateau Teleport",89,0,8,0,0,0,0,0,0,3,0,0,3,0,0,96,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster to the Ice Plateau in level 53 Wilderness.")
            new RunescapeSpell (241,"Disruption Shield",90,0,0,0,0,0,10,0,0,3,0,0,0,3,0,97,SpellCategory.Combat,SpellType.Lunar,"Nullifies the next hit you receive from another player. Only works on other players. Unlocked at Livid Farm.")
            new RunescapeSpell (242,"Tele Group Ice Plateau",90,0,16,0,0,0,0,0,0,3,0,0,3,0,0,99,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, along with up to 4 other players (who have Accept Aid on), to the Ice Plateau in level 53 Wilderness.")
            new RunescapeSpell (243,"Heal Other",92,0,0,0,0,0,0,0,0,3,0,0,3,1,0,86,SpellCategory.Combat,SpellType.Lunar,"This spell damages the caster for 75% of their current life points and heals another target player the same amount.")
            new RunescapeSpell (244,"Teleport to Trollheim",92,0,10,0,0,0,0,0,0,3,0,0,3,0,0,101,SpellCategory.Teleport,SpellType.Lunar,"Teleports the caster to Trollheim. Unlocked at the Livid Farm. Completion of My Arm's Big Adventure is required to use this spell.")
            new RunescapeSpell (245,"Vengeance Other",93,0,0,10,0,0,0,0,0,3,0,2,0,0,0,73,SpellCategory.Combat,SpellType.Lunar,"Another target player receives the Vengeance effect. The next time another player or an NPC attacks that player, the attacking player or NPC is dealt damage, up to 75% of the damage that player or NPC's first attack dealt.")
            new RunescapeSpell (246,"Group Teleport to Trollheim",93,0,20,0,0,0,0,0,0,3,0,0,3,0,0,102,SpellCategory.Teleport,SpellType.Lunar,"Transports the caster, along with players in a 3x3 area around them (with Accept Aid on), who have completed My Arm's Big Adventure), to Trollheim. Unlocked at the Livid Farm. Completion of My Arm's Big Adventure is required to cast this spell.")
            new RunescapeSpell (247,"Vengeance",94,0,0,10,0,0,0,0,0,4,0,2,0,0,0,73,SpellCategory.Combat,SpellType.Lunar,"The caster receives the Vengeance effect. The next time a player or NPC attacks the caster, that player or NPC takes up to 75% of the damage their attack dealt.")
            new RunescapeSpell (248,"Vengeance Group",95,0,0,11,0,0,0,0,0,4,0,3,0,0,0,120,SpellCategory.Combat,SpellType.Lunar,"Casts Vengeance on up to 50 players within a 7x7 square around the caster. When activated, all players around the caster with accept aid on receive the effect of vengeance. Unlocked at Livid Farm.")
            new RunescapeSpell (249,"Heal Group",95,0,0,0,0,0,0,0,0,4,0,0,6,3,0,124,SpellCategory.Combat,SpellType.Lunar,"Damages the caster for 75% of their current life points and distributes the lost life points among all other players within a 3x3 grid of the caster.")
            new RunescapeSpell (250,"Spellbook Swap",96,0,0,0,0,0,0,2,0,3,0,0,1,0,0,130,Varies,SpellType.Lunar,"Enables the caster to cast a single spell from either the normal or Ancient Magicks spellbooks."))
            */
        }
    }
}
