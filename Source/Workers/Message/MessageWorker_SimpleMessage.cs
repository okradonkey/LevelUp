using RimWorld;
using Verse;

namespace LevelUp
{
    public class MessageWorker_SimpleMessage : MessageWorker
    {
        public override void Execute(string text, TargetInfo target)
        {
            var message = new Message(text, MessageTypeDefOf.SilentInput, target);
            Messages.Message(message, false);
        }
    }
}