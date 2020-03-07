using RimWorld;

using Verse;

namespace LevelUp
{
    public static class LevelActionTrigger
    {
        public static void Trigger(LevelingInfo levelingInfo, SkillRecord skillRecord, Pawn pawn)
        {
            var levelingParms = new LevelingParms { skillRecord = skillRecord, languageKey = levelingInfo.MessageKey };
            levelingInfo.Effect.Spawn().Trigger(pawn, levelingParms);
        }
    }
}