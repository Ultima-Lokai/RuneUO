using System;
using Server.Commands;

namespace Server.Runescape
{
    internal class SkillUtilities
    {
        public static void Initialize()
        {
            Console.WriteLine("Exp needed from Level 1 - Level 45: " + ShowSkillNeeded(2, 45) + " xp");
            Console.WriteLine("Exp needed from Level 45 - Level 99: " + ShowSkillNeeded(45, 99) + " xp");
            Console.WriteLine("Exp needed from Level 1 - Level 99: " + ShowSkillNeeded(2, 99) + " xp");

            CommandSystem.Register("AnimateMe", AccessLevel.GameMaster, new CommandEventHandler(AnimateMe_OnCommand));
        }

        public static int ShowSkillNeeded(int currentLevel, int desiredLevel)
        {
            int totalpoints = 0;
            int mypoints = 0;

            for (int lvl = 1; lvl < desiredLevel; lvl++)
            {
                totalpoints += (int)Math.Floor(lvl + 300 * Math.Pow(2, (double)lvl / 7));
                if (lvl == currentLevel)
                    mypoints = totalpoints;
            }
            return (int)Math.Floor((double)(totalpoints - mypoints) / 4);
        }

        [Usage("AnimateMe <action>")]
        [Description("Makes your character do a specified animation.")]
        public static void AnimateMe_OnCommand(CommandEventArgs e)
        {
            if (e.Length == 1)
            {
                e.Mobile.Animate(e.GetInt32(0), 8, 1, true, false, 0);
            }
            else
            {
                e.Mobile.SendMessage("Format: AnimateMe <action> ");
            }
        }
    }
}
