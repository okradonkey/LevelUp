using RimWorld;
using Verse;

namespace LevelUp
{
    public abstract class MessageWorker
    {
        public MessageDef def;

        public abstract void Execute(string text, TargetInfo target);
    }
}