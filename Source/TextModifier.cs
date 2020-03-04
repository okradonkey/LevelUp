using RimWorld;
using Verse;

namespace LevelUp
{
    public static class TextModifier
    {
        public static string Replace(string text, SkillRecord skillRecord = null, Pawn pawn = null, int level = default)
        {
            
            if (skillRecord != null)
            {
                text = text.Replace("{2}", skillRecord.def.LabelCap);
            }

            if (pawn != null)
            {
                text = text.Replace("{0}", pawn.LabelShortCap.Colorize(ColoredText.NameColor));
            }

            text = text.Replace("{1}", level.ToString());

            return text;
        }
    }
}