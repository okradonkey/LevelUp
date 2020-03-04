using UnityEngine;
using Verse;

namespace LevelUp
{
    public class AnimationWorker_BrightBubble : AnimationWorker
    {
        private ThingDef moteLevelUpDef;
        private ThingDef MoteLevelUpDef => moteLevelUpDef ??= DefDatabase<ThingDef>.GetNamed("Mote_LevelUp");

        public override void Execute(TargetInfo target)
        {
            var mote = ThingMaker.MakeThing(MoteLevelUpDef) as Mote;
            mote.Scale = 1.0f;
            mote.rotationRate = 100f;
            var position = target;
            mote.Attach(target);
            mote.exactPosition = target.CenterVector3;

            GenSpawn.Spawn(mote, target.CenterVector3.ToIntVec3(), Find.CurrentMap);
        }

        //public override void Execute(Pawn pawn)
        //{
        //    var mote = ThingMaker.MakeThing(MoteLevelUpDef) as Mote;
        //    mote.Scale = 1.0f;
        //    mote.rotationRate = 100f;
        //    var position = pawn.DrawPos;
        //    mote.Attach(pawn);
        //    mote.exactPosition = position;

        //    GenSpawn.Spawn(mote, position.ToIntVec3(), Find.CurrentMap);
        //}

        //public override void Execute(Vector3 location)
        //{
        //    var mote = ThingMaker.MakeThing(MoteLevelUpDef) as Mote;
        //    mote.Scale = 1.0f;
        //    mote.rotationRate = 100f;

        //    mote.exactPosition = location;

        //    GenSpawn.Spawn(mote, location.ToIntVec3(), Find.CurrentMap);
        //}
    }
}