using System;
using System.Collections.Generic;
using Server.Engines.Quests;
using VitaNex;
using Server.Commands;
using Server.Custom;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Runescape
{
    public class QuestHolder
    {
        public object oName { get; set; }
        public object oDescription { get; set; }
        public object oStartMobile { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string MobileName { get; set; }
        public string Refuse { get; set; }
        public string Complete { get; set; }
        public string Uncomplete { get; set; }

        public QuestHolder(string name, string description, string mobileName)
        {
            Name = name;
            Description = description;
            if (mobileName == null) MobileName = "";
            else
                MobileName = mobileName;
            Refuse = "";
            Complete = "";
            Uncomplete = "";
        }

        public QuestHolder(object name, object description, object startMobile)
        {
            oName = name;
            oDescription = description;
            oStartMobile = startMobile;
        }
    }

    public static class Quests
    {

        public static List<QuestHolder> QuestHolders; 
         
        public static void Initialize()
        {
            CommandUtility.Register("ClilocQuest", AccessLevel.Administrator, CQCommand);
        }

        private static BaseQuester findQuester(Type quest)
        {
            BaseQuester q = null;
            foreach (var quester in questStarters)
            {
                if (quester.ParentQuestSystem == quest)
                {
                    q = quester;
                }
            }
            return q;
        }

        private static List<BaseQuester> questStarters;

        private static void CQCommand(CommandEventArgs e)
        {
            questStarters = new List<BaseQuester>();
            foreach (var mobile in World.Mobiles.Values)
            {
                if (mobile is BaseQuester && ((BaseQuester) mobile).DoesOffer)
                {
                    questStarters.Add((BaseQuester)mobile);
                }
            }

            QuestHolders = new List<QuestHolder>();
            foreach (var quest in QuestSystem.QuestTypes)
            {
                QuestSystem questSystem = (QuestSystem)Activator.CreateInstance(quest);
                if (questSystem != null)
                {
                    try
                    {
                        object name = questSystem.Name;
                        object offer = questSystem.OfferMessage;
                        BaseQuester quester = findQuester(quest);
                        QuestHolders.Add(new QuestHolder(name, offer, quester));
                    }
                    catch
                    {
                    }
                }
            }

            foreach (var assembly in ScriptCompiler.Assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.BaseType == typeof(BaseQuest))
                    {
                        BaseQuest baseQuest = (BaseQuest)Activator.CreateInstance(type);
                        if (baseQuest != null)
                        {
                            try
                            {
                                object name = baseQuest.Title;
                                object desc = baseQuest.Description;
                                MondainQuester quester = baseQuest.StartingMobile;
                                QuestHolders.Add(new QuestHolder(name, desc, quester));
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }

            Console.WriteLine("There are {0} generic quests in the system!", QuestHolders.Count);
            int count = 0;
            foreach (var quest in QuestHolders)
            {
                try
                {
                    Mobile startMobile = null;
                    ClilocInfo cliloc;

                    if (quest.oName is int)
                    {
                        cliloc = Clilocs.Tables[ClilocLNG.ENU].Lookup((int)quest.oName);
                        if (cliloc != null)
                        {
                            quest.Name = cliloc.Text;
                        }
                        else
                        {
                            quest.Name = ((int) quest.oName).ToString();
                        }
                    }
                    else if (quest.oName is string)
                    {
                        quest.Name = (string) quest.oName;
                    }

                    if (quest.oDescription is int)
                    {
                        cliloc = Clilocs.Tables[ClilocLNG.ENU].Lookup((int) quest.oDescription);
                        if (cliloc != null)
                        {
                            quest.Description = cliloc.Text;
                        }
                        else
                        {
                            quest.Description = ((int) quest.oDescription).ToString();
                        }
                    }
                    else if (quest.oDescription is string)
                    {
                        quest.Description = (string) quest.oDescription;
                    }

                    if (quest.oStartMobile is MondainQuester)
                    {
                        startMobile = (MondainQuester) quest.oStartMobile;
                        quest.MobileName = startMobile.Name;
                    }

                    else if (quest.oStartMobile is BaseQuester)
                    {
                        startMobile = (BaseQuester)quest.oStartMobile;
                        quest.MobileName = startMobile.Name;
                    }
                }
                catch
                {
                    count++;
                }
            }
            Console.WriteLine("There were {0} errors reading quests.", count);
            PlayerMobile pm = (PlayerMobile) e.Mobile;
            e.Mobile.SendGump(new QuestSearch(e.Mobile, pm));
        }
    }


    public class QuestSearch : Gump
    {
        public const int LabelHue = 0x480;
        public const int GreenHue = 0x40;
        public const int RedHue = 0x20;

        private Mobile mFrom;
        private PlayerMobile mPlayer;

        private int mPage;
        private int mIndex;

        public QuestSearch(Mobile from, PlayerMobile mobile)
            : this(from, mobile, 1)
        {
        }

        public QuestSearch(Mobile from, PlayerMobile mobile, int page)
            : this(from, mobile, page, 0, 50, 50, true, true, true, true, true, false, "")
        {
        }

        public QuestSearch(Mobile from, PlayerMobile mobile, int page, int index, int xPos, int yPos,
            bool active, bool completed, bool notstarted, bool basequests, bool questsystems, bool details, string searchphrase)
            : base(xPos, yPos)
        {
            mFrom = from;
            mPlayer = mobile;
            mPage = page;
            mIndex = index;

            int y = 75;
            List<QuestHolder> holders = searchphrase == "" ? Quests.QuestHolders : FilteredHolders(searchphrase);

            AddPage(0);

            AddBackground(0, 0, 250, 230, 5054);
            AddAlphaRegion(1, 1, 248, 228);
            AddBackground(0, 231, 250, 269, 5054);
            AddAlphaRegion(1, 232, 248, 267);

            if (details)
            {
                AddBackground(251, 0, 504, 500, 5054);
                AddAlphaRegion(252, 1, 502, 498);
            }

            if (mPlayer != null)
            {
                AddLabel(23, 26, 0x384, mPlayer.Name);

                y = 13;
                AddCheck(133, y, 0xD2, 0xD3, active, 6);
                AddLabel(156, y, 0x384, "Active");

                y += 30;
                AddCheck(133, y, 0xD2, 0xD3, completed, 7);
                AddLabel(156, y, 0x384, "Completed");

                y += 30;
                AddCheck(133, y, 0xD2, 0xD3, notstarted, 8);
                AddLabel(156, y, 0x384, "Not Started");

                y = 75;
            }

            AddButton(5, y, 0xFA8, 0xFAA, 5, GumpButtonType.Reply, 0);
            AddLabel(38, y, 0x384, "Select Player");

            y += 30;
            AddCheck(5, y, 0xD2, 0xD3, questsystems, 9);
            AddLabel(28, y, 0x384, "Quest System");

            y += 30;
            AddCheck(5, y, 0xD2, 0xD3, basequests, 10);
            AddLabel(28, y, 0x384, "Base Quest");

            y += 30;
            AddImageTiled(5, y, 200, 19, 0xBBC);
            AddTextEntry(5, y, 200, 19, 0, 11, searchphrase);

            y += 30;
            AddButton(5, y, 0xFA8, 0xFAA, 4, GumpButtonType.Reply, 0);
            AddLabel(38, y, 0x384, "Apply Filters");
            y += 10;

            if (holders.Count > 0)
            {
                int maxpages = (int)Math.Ceiling((decimal)holders.Count/8);
                int highestindex = holders.Count/mPage >= 8 ? 8 : holders.Count - ((maxpages - 1)*8);
                if (mPage > 1)
                    AddButton(6, 246, 250, 251, 15, GumpButtonType.Reply, 0);
                if (mPage < maxpages)
                    AddButton(6, 460, 252, 253, 16, GumpButtonType.Reply, 0);

                for (int x = 0; x < highestindex; x++)
                {
                    bool now = (mPage - 1)*8 + x == mIndex && details;
                    y += 30;
                    if (now)
                        AddImage(35, y, 2154);
                    else
                        AddButton(35, y, 2152, 2152, 1000 + ((mPage - 1) * 8 + x), GumpButtonType.Reply, 0);
                    AddLabel(69, y + 5, 0x384, holders[(mPage - 1)*8 + x].Name);
                }
            }
        }

        private List<QuestHolder> FilteredHolders(string search)
        {
            List<QuestHolder> holders = new List<QuestHolder>();
            foreach (var quest in Quests.QuestHolders)
            {
                if (!holders.Contains(quest) && quest.Description.Contains(search)) holders.Add(quest);
                if (!holders.Contains(quest) && quest.Name.Contains(search)) holders.Add(quest);
                if (!holders.Contains(quest) && quest.MobileName != null && quest.MobileName.Contains(search))
                    holders.Add(quest);
            }

            return holders;
        }

        public void AddHtml(int x, int y, int width, int height, string text, int color, bool background,
            bool scrollbar)
        {
            AddHtml(x, y, width, height, Color(text, color), background, scrollbar);
        }

        public string Color(string text, int color)
        {
            return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
        }

        private void AddDetail(QuestHolder quest)
        {
            AddLabel(90, 75, GreenHue, "Title");
            AddHtml(90, 95, 185, 50, quest.Name, 0x20, true, true);
            AddLabel(280, 75, GreenHue, "Mobile Name");
            AddHtml(280, 95, 185, 50, quest.MobileName, 0x20, true, true);
            AddLabel(90, 150, GreenHue, "Description");
            AddHtml(90, 170, 380, 100, quest.Description, 0x20, true, true);
            AddLabel(90, 275, GreenHue, "Refuse");
            AddHtml(90, 295, 380, 100, quest.Refuse, 0x20, true, true);
            AddLabel(90, 400, GreenHue, "Complete");
            AddHtml(90, 420, 380, 100, quest.Complete, 0x20, true, true);
            AddLabel(90, 525, GreenHue, "Uncomplete");
            AddHtml(90, 545, 380, 100, quest.Uncomplete, 0x20, true, true);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {

            // Apply Filters
            if (info.ButtonID == 4)
            {
                bool active = info.IsSwitched(6);
                bool completed = info.IsSwitched(7);
                bool notstarted = info.IsSwitched(8);
                bool questsystem = info.IsSwitched(9);
                bool basequest = info.IsSwitched(10);
                string searchtext = info.GetTextEntry(11).Text;

                if (mPlayer != null && !active && !completed && !notstarted)
                {
                    active = true;
                    mFrom.SendMessage("At least one of the top 3 checkboxes must be checked.");
                }

                if (!questsystem && !basequest)
                {
                    questsystem = true;
                    mFrom.SendMessage("At least one of the bottom 2 checkboxes must be checked.");
                }
                mFrom.SendGump(new QuestSearch(mFrom, mPlayer, mPage, mIndex, X, Y, active, completed, notstarted,
                    basequest, questsystem, false, searchtext));
            }

            // Select Player
            if (info.ButtonID == 5)
            {

            }
        }
    }
}
