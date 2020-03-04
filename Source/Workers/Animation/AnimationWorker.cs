using Verse;

namespace LevelUp
{
    public abstract class AnimationWorker
    {
        public AnimationDef def;

        public abstract void Execute(TargetInfo target);

        //public abstract void Execute(Pawn pawn);

        //public abstract void Execute(Vector3 location);
    }
}