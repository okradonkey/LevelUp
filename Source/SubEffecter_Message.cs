using RimWorld;
using Verse;

namespace LevelUp
{
    public class SubEffecter_Message : SubEffecter_Text
    {
        public SubEffecter_Message(SubEffecterDef subDef, Effecter parent) : base(subDef, parent)
        { }

        protected override void TryTrigger(TargetInfo target, SkillRecord skillRecord, string languageKey)
        {
            var text = languageKey.Translate(target.Thing, skillRecord.Level, skillRecord.def)
#if NET472
                .Resolve()
#endif
                ;

            var message = new Message(text, MessageTypeDefOf.SilentInput, target);
            Messages.Message(message, false);
        }
    }
}