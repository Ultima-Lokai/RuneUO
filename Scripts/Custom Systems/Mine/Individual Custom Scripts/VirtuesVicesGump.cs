/******************* Virtues and Vices *****************************************************************************************
 *
 *					(C) 2015, by Lokai
 *   
/*******************************************************************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License 
 *   as published by the Free Software Foundation; either version 2 of the License, or (at your option) any later version.
 *
 ******************************************************************************************************************************/
using Server.Mobiles;
using Server.Network;
using VitaNex;

namespace Server.Gumps
{
    class VirtuesVicesGump : Gump
    {
        public static void Initialize()
        {
            CommandUtility.Register("VVGump", AccessLevel.Counselor, e => DisplayTo(e.Mobile as PlayerMobile));
        }

        public static void DisplayTo(PlayerMobile user)
        {
            user.SendGump(new VirtuesVicesGump(user, 1, 60, 60));
        }

        private int m_Page;
        private Mobile m_From;

        public VirtuesVicesGump(Mobile from, int page, int x, int y)
            : base(x, y)
        {
            m_Page = page;
            m_From = from;
            int imageID = m_Page + 30566;

            AddPage(0);
            AddBackground(0, 0, 600, 500, 3600);
            AddImage(20, 50, imageID);
            AddHtml(270, 50, 310, 430, mDescriptions[m_Page], true, true);
            AddHtml(160, 460, 100, 30, string.Format("<BASEFONT COLOR=#{0:X6}><BOLD>{1}</BOLD></BASEFONT>", 0xFFFFFF, mNames[m_Page]), false, false);

            if (m_Page > 1)
                AddButton(20, 25, 2468, 2467, 2, GumpButtonType.Reply, 0); // Previous Page
            if (m_Page < 16)
                AddButton(510, 25, 2471, 2470, 3, GumpButtonType.Reply, 0); // Next Page

        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 3)
                m_From.SendGump(new VirtuesVicesGump(m_From, m_Page + 1, X, Y));
            else if (info.ButtonID == 2)
                m_From.SendGump(new VirtuesVicesGump(m_From, m_Page - 1, X, Y));
        }

        private string[] mNames = {"", "Covetous","Deceit","Despise","Destard","Hythloth","Pride","Shame","Wrong","Compassion","Honesty","Honor","Humility","Justice","Sacrifice","Spirituality","Valor"};
        private string[] mDescriptions = new string[]{@"", @"On a rocky eastern shore of Lost Hope Bay, reachable only by sea, the dungeon Covetous has hewn in bygone times as a royal crypt for the rulers of the distant province that is now Minoc.

The town of Minoc has played host to the mysterious hollows of a blackrock mine. Noted for its property of foiling magic, the pure blackrock herein commands a high price. With a metallurgy known to few, it can be forged into magic items to astound even mages. The blackrock mine has been in operation for many years, and the shallower veins have begun to dry. Hearty miners and warriors have begun to explore the deeper veins wherein undead creatures and fickle footing have proved their undoing. Yet, the richness of the blackrock therein continues to inspire the hearty townspeople to venture deeper into the mountain.",
@"Deadly traps and bottomless pits are among the furnishings of this terrible prison. 'Tis said that the lower reaches are filled with sulfurous fumes and bathed in the mephitic light of dragon breath, making Deceit a storinghouse of untold, unreachable treasures. Seek it on a barren outcropping in the Great Sea, just east of Dagger Isle.

In this place, rule by deceit ensures that only the most treacherous liars and pitiless beasts keep head and limb together. Abandoned long ago, the prison now houses evil creatures whose lives are an imprisonment. A spate of recent earthquakes has centered at the dungeon wherein it is believed that a fissure grows in its deepest depths. For, temperatures inside have elevated greatly, clouding the eyes of a visitor with sweat, draining the will, till one of the many illusions trips him forever.", 
@"The cavern Despise is a featureless maze of twisty passages and dizzying corridors. Its entrance lies among the mist-shrouded mountains of the central Serpent's Spine.

Britain, the capital city, expands in all directions save one: towards the dungeon of Despise. Since time immemorial, this dungeon has drawn creatures fearful of the world above. Herein, their fears gather strength and force and are directed at all who dare to enter. The fearful beasts save special attention for the forces of light, for those who with a weakness for the truth. /they must endure nasty traps, terrible pranks, and direct assaults as they search for the many treasures contained herein. ", 
@"Far to the west of the Fens of the Dead, along the untamed coast of southwest Britannia, the cavern called Destard is a dank haven for savage tribes of orcs, trolls, and the like.

For centuries, the caverns of Destard housed an ancient dragon and her treasures. Many of the brave warriors of the city of Valoria tested their mettle in her lair, and few returned. The legend of Talornia, the great red dragon spread through the countryside, as she fed upon village and farm. The Knights of Valoria mounted an expedition to seal her lair which apparently arrested her roamings about the countryside. Some claim that she yet lives and has grown old and mighty in her lair. Rumors of a cult of worshippers persist and are fed by the many disappearances. Plans for a new campaign to root out the dragons of Destard have become mired in the squabbling among the Knights of Valoria. Little is done, and all complain about it. ", 
@"A chilling stronghold of danger, Hythloth is situated on the Isle of the Avatar's distant southern shores. Among its denizens are nightmarish creatures as daemons, ghosts, and dragons. Those who venture inside must be prepared to negotiate diabolical mazes while watching their backs for attacks from unexpected places...

Once the sewers beneath the grand city of Old Magincia, Hythloth has become fouled by the vain creatures herein and the false pride their conquest inspires in those who venture through the twist and turns. Emptying into the ocean, the tunnels of Hythloth have filled with polluted water, souring the grazing fields of the humble flocks of New Magincia. Adventurers are advised to train to swim and to carry many healing remedies, for if the waters do not prove one's undoing, the beasts that guard many fine things will. ", 
@"The absence of Truth, Love, and Courage is Pride. Pride is the surest measure of goals never attained. Pride goes before, shame comes after. This shame leads to awareness of Humility, the root from which all Virtues grow. Humility is to strip oneself of all conceits.", 
@"On the outskirts of the honorable city of Trinsic lies the Dungeon of Shame. The Paladins of the fair city used Shame as a proving ground for acolytes, and many were lost in this fortress of traps and puzzles. Pom of Paws, a Paladin elder, negotiated the depths of Shame and returned with the Chalice of Honor, which has since disappeared. Many suspected that it had been spirited back into the dungeon, yet none volunteers to retrieve it. For, the forces of evil have twisted yet again the traps and illusions herein. Among the Paladins, the Dungeon of Shame has spread its disease, as their code of ethics mocks them who cringe in fear of this place.", 
@"Once the most feared of prisons, the dungeon Wrong is an underground fortress whose cells are haunted by unliving remnants of those who died there. Orcs now cache their victims' treasures in the same chambers where soldiers of ancient kings stood watch over the torture of prisoners, and underground rivers turn the prisoner's oubliettes into breeding grounds for things better left unnamed. In the very heart of northern Britannia is the entrance to this place of hate and ruin.", 
@"Compassion, founded on the principle of Love, is non-judgmental empathy for one's fellow creatures. The quality of empathy, of recognizing and sharing the feelings of others. In Britain, the bards headquartered in this towne of compassion put their emphasis on hospitality.

The Shrine of Compassion is situated south of Lock Lake, near Cove. ", 
@"Honesty, founded on the principle of Truth, is scrupulous respect for truth- the willingness never to deceive oneself or another. The pursuit of truthfulness, with respect to oneself and with respect to other beings. Honesty and the quest for truth is taught by the mages of Moonglow.

The Shrine of Honesty is situated on Dagger Isle, north of Verity Isle. ", 
@"Honor, founded on the principles of Courage and Truth, is the courage to stand for the truth, against any odds. It is the courage to stand for truth regardless of the circumstances. On a grassy plain on the southeastern shore of Britannia, Trinsic's honorable paladins impress visitors with their courage and devotion to truth.

The Shrine of Honor is situated southwest of Trinsic, near the Cape of Heroes. ", 
@"Humility is the opposite of Pride, and independent of the principles of Virtue, is about perceiving one's place in the world, not according to one's own accomplishments, but according to the intrinsic value of all individuals. It is the recognition of the worthiness of all beings, and the perception of one's own place among them, regardless of one's own personal accomplishments or mistakes in the world. New Magincia is a towne built on the ruins of old Magincia by a colony of humble people who understand well the dangers of false, self-serving pride and the beauty of humility.

The Shrine of Humility is situated on the Isle of the Avatar. ", 
@"Justice, founded on the principles of Truth and Love, is the devotion to truth, tempered by love. It is the wisdom that perceives what is right and what is wrong in human action. Yew, a gathering place for druids in their pursuit of justice, is the site of the High Court of Britannia and nurtures the great legal and judicial minds who practice there.

The Shrine of Justice is situated north of Yew, at the coast of the sea. ", 
@"Sacrifice, founded on the principles of Courage and Love, is the courage to give of oneself in the name of love. It is the placing of the interests of others and the ends of virtue over one's own well-being. Minoc is the centre for studying the virtue of sacrifice. The homeless of Britannia are welcomed in Minoc; here they find refuge in the Mission of the Helpless, with ready access to a charitable healer.

The Shrine of Sacrifice is situated east of Minoc, in the middle of the Drylands in the dried-up Lake Generosity. ", 
@"Spirituality, founded on all three principles in equal parts, is the concern with one's inner being and how one deals with truth, love, and courage. It is also the awareness of the love that unites one's own inner being to those around one. A centre for rangers, Skara Brae is a city immersed in the study of spirituality.

The shrine of Spirituality is not situated on Britannia. Instead is deep in the Ethereal Void, with access only through a moongate. ", 
@"Valor, founded on the principle of Courage, is the courage to take actions in support of one's convictions. The courage to uphold virtue, even in the face of a physical or psychological threat. The towne of Jhelom provides food and lodging to its fighters and students of Valor.

The Shrine of Valor is situated on a island south of Jhelom. "};
    }
}
