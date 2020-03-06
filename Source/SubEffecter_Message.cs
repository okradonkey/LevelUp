using RimWorld;
using Verse;

namespace LevelUp
{
    public class SubEffecter_Message : SubEffecter_InjectedText
    {
        public SubEffecter_Message(SubEffecterDef subDef, Effecter parent) : base(subDef, parent)
        { }

        protected override void TryTrigger(TargetInfo target, string text)
        {
            var message = new Message(text, MessageTypeDefOf.SilentInput, target);
            Messages.Message(message, false);
        }
    }
}