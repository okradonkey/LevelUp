using Verse;

namespace LevelUp
{
    public class AnimationWorker_BrightBubble : AnimationWorker
    {
        // GET THIS FROM DEF INSTEAD
        private ThingDef moteLevelUpDef => DefDatabase<ThingDef>.GetNamed("Mote_LevelUp");

        public override void Execute(TargetInfo target)
        {
            var mote = ThingMaker.MakeThing(moteLevelUpDef) as Mote;
            mote.Scale = 1.0f;
            mote.rotationRate = 100f;
            var position = target; // ??
            mote.Attach(target);
            mote.exactPosition = target.CenterVector3;

            GenSpawn.Spawn(mote, target.CenterVector3.ToIntVec3(), Find.CurrentMap);
        }
    }
}