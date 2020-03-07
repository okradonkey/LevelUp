using RimWorld;
using Verse;

namespace LevelUp
{
    public class SubEffecter_Message : SubEffecter_InjectedText
    {
        public SubEffecter_Message(SubEffecterDef subDef, Effecter parent) : base(subDef, parent)
        { }

        protected override void TryTrigger(TargetInfo target, SkillRecord skillRecord, string languageKey)
        {
            var text = languageKey.Translate(target.Thing, skillRecord.Level, skillRecord.def.LabelCap);
            string fixedText;
#if NET472
            fixedText = text.Resolve();

#else
            fixedText = text;

#endif
            var message = new Message(fixedText, MessageTypeDefOf.SilentInput, target);
            Messages.Message(message, false);
        }
    }
}