using RimWorld;
using Verse;

namespace LevelUp
{
    public abstract class SubEffecter_Text : SubEffecter
    {
        public SubEffecter_Text(SubEffecterDef subDef, Effecter parent) : base(subDef, parent)
        { }

        public override void SubTrigger(TargetInfo target, TargetInfo disguisedLevelingParms)
        {
            var levelingParms = disguisedLevelingParms.Thing as LevelingParms;
            var skillRecord = levelingParms.skillRecord;
            var languageKey = levelingParms.languageKey;
            TryTrigger(target, skillRecord, languageKey);
        }

        protected abstract void TryTrigger(TargetInfo target, SkillRecord skillRecord, string languageKey);
    }
}