using Verse;

namespace LevelUp
{
    public abstract class SubEffecter_InjectedText : SubEffecter
    {
        public SubEffecter_InjectedText(SubEffecterDef subDef, Effecter parent) : base(subDef, parent)
        { }

        public override void SubTrigger(TargetInfo target, TargetInfo labelHolderThing)
        {
            TryTrigger(target, labelHolderThing.Thing.Label);
        }

        protected virtual void TryTrigger(TargetInfo target, string text)
        {
        }
    }
}