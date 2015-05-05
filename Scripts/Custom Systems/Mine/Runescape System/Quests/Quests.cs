using System;
using System.Collections.Generic;
using Server.Engines.Quests;
using VitaNex;
using Server.Commands;
using Server.Custom;
using Server.Gumps;
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

        public QuestHolder(string name, string description, string mobileName)
        {
            Name = name;
            Description = description;
            MobileName = mobileName;
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

        private static void CQCommand(CommandEventArgs e)
        {
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
                        QuestHolders.Add(new QuestHolder(name, offer, null));
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
                                Mobile mobile = baseQuest.StartingMobile;
                                QuestHolders.Add(new QuestHolder(name, desc, mobile));
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
                    string name = "";
                    string description = "";
                    Mobile startMobile = null;
                    ClilocInfo cliloc;

                    if (quest.oName is int)
                    {
                        cliloc = Clilocs.Tables[ClilocLNG.ENU].Lookup((int)quest.oName);
                        if (cliloc != null)
                        {
                            name = cliloc.Text;
                            quest.Name = name;
                        }
                        else
                        {
                            name = string.Format("Cliloc not found for {0}. (Out of {1} entries.)", (int) quest.oName,
                                Clilocs.Tables[ClilocLNG.ENU].Count);
                            quest.Name = ((int) quest.oName).ToString();
                        }
                    }
                    else if (quest.oName is string)
                    {
                        name = (string) quest.oName;
                        quest.Name = (string) quest.oName;
                    }

                    if (quest.oDescription is int)
                    {
                        cliloc = Clilocs.Tables[ClilocLNG.ENU].Lookup((int) quest.oDescription);
                        if (cliloc != null)
                        {
                            description = cliloc.Text;
                            quest.Description = description;
                        }
                        else
                        {
                            description = string.Format("Cliloc not found for {0}", (int) quest.oDescription);
                            quest.Description = ((int) quest.oDescription).ToString();
                        }
                    }
                    else if (quest.oDescription is string)
                    {
                        description = (string) quest.oDescription;
                        quest.Description = (string) quest.oDescription;
                    }

                    if (quest.oStartMobile is MondainQuester)
                    {
                        startMobile = (MondainQuester) quest.oStartMobile;
                        quest.MobileName = startMobile.Name;
                    }

                    //Console.WriteLine("Quest: {0}. {1} Talk to {2} to begin.", name, description,
                    //    startMobile == null ? "someone" : startMobile.Name);
                }
                catch
                {
                    count++;
                }
            }
            Console.WriteLine("There were {0} errors reading quests.", count);
        }
    }


    public class QuestSearch : CG
    {
        private PlayerMobile mPlayer;
        private int mPage;
        private int mIndex;

        public QuestSearch(Mobile from, PlayerMobile mobile)
            : this(from, mobile, 1)
        {
        }

        public QuestSearch(Mobile from, PlayerMobile mobile, int page)
            : this(from, mobile, page, 0, 50, 50)
        {
        }

        public QuestSearch(Mobile from, PlayerMobile mobile, int page, int index, int x, int y)
            : base(x, y)
        {
            mPlayer = mobile;
            mPage = page;
            mIndex = index;

            int pages = Quests.QuestHolders.Count;

            AddBackground(0, 0, 700, 500, 3600); // Dark Grey background
            AddBackground(15, 15, 270, 472, 9350); // Light Grey background
            AddBackground(285, 15, 400, 472, 9300); // Parchment background
            AddImage(20, 411, 2362);
            AddLabel(35, 407, 0, "In Progress");
            AddImage(20, 433, 2361);
            AddLabel(35, 429, 0, "Completed");
            AddImage(20, 459, 2360);
            AddLabel(35, 455, 0, "Not Started");

            AddHtml(432, 22, 70, 20, Italic("Active"), GreenHue, false, false);

            int questNum;
            string questString = "";

            if (page == 1)
            {
                // Add page forward button
                AddButton(439, 39, 9728, 9728, 3, GumpButtonType.Reply, 0);  //436,21
                AddHtml(95, 20, 300, 20, Bold(String.Format("{0}'s Completed Quests", mPlayer.Name)), GreenHue, false,
                    false);
                questNum = mobile.DoneQuests.Count;
                questString = "completed";
            }
            else
            {
                // Add page back button
                AddButton(439, 39, 9730, 9730, 4, GumpButtonType.Reply, 0);
                AddHtml(95, 20, 300, 20, Bold(String.Format("{0}'s Current Quests", mPlayer.Name)), GreenHue, false,
                    false);
                questNum = mobile.Quests.Count;
                questString = "current";
            }
            if (questNum > 0)
            {
                if (index < questNum - 1)
                {
                    AddButton(355, 50, 2224, 2224, 13, GumpButtonType.Reply, 0); // Add index forward button
                    AddImage(319, 51, 2509);
                }

                if (index > 0)
                {
                    AddButton(165, 50, 2223, 2223, 14, GumpButtonType.Reply, 0); // Add index back button
                    AddImage(190, 51, 2508);
                }

                try
                {
                    BaseQuest quest;
                    if (page == 1)
                    {
                        Type questType = mobile.DoneQuests[index].QuestType;
                        quest = (BaseQuest)Activator.CreateInstance(questType);
                        AddButton(245, 47, 5531, 5532, index + 1000, GumpButtonType.Reply, 0); // Button to delete from completed quests
                    }
                    else
                    {
                        quest = mobile.Quests[index];
                        AddButton(245, 47, 5531, 5532, index + 2000, GumpButtonType.Reply, 0); // Button to delete from active quests
                    }
                    AddDetail(quest);
                }
                catch
                {
                    AddLabel(90, 75, 0, String.Format("There was an exception reading {0}'s {1} quests.", mPlayer.Name, questString));
                }
            }
            else
            {
                AddLabel(90, 75, 0, String.Format("{0} does not have any {1} quests.", mPlayer.Name, questString));
            }

        }

        private void AddDetail(BaseQuest quest)
        {
            AddLabel(90, 75, GreenHue, "Title");
            AddHtml(90, 95, 185, 50, quest.Title, 0x20, true, true);
            AddLabel(280, 75, GreenHue, "Chain ID");
            AddHtml(280, 95, 185, 50, quest.ChainID.ToString(), 0x20, true, true);
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
        }
    }
}
