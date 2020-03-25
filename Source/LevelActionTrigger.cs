using RimWorld;

using Verse;

namespace LevelUp
{
    public static class LevelActionTrigger
    {
        public static void Trigger(LevelingInfo levelingInfo, SkillRecord skillRecord, Pawn pawn)
        {
            var levelingParms = new LevelingParms { skillRecord = skillRecord, languageKey = levelingInfo.MessageKey };
            var effecter = levelingInfo.Effect.Spawn();
            effecter.Trigger(pawn, levelingParms);
            if (effecter.def is LevelingDef def && def.durationTicks > 0)
            {
                var tickQueue = Current.Game.GetComponent<GameHandler>().TickQueue;
            }
        }
    }
}