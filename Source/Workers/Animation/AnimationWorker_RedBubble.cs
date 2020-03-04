using UnityEngine;
using Verse;

namespace LevelUp
{
    public class AnimationWorker_RedBubble : AnimationWorker
    {
        private ThingDef moteLevelDownDef;
        private ThingDef MoteLevelDownDef => moteLevelDownDef ??= DefDatabase<ThingDef>.GetNamed("Mote_LevelDown");

        //public override void Execute(Pawn pawn)
        //{
        //    var mote = ThingMaker.MakeThing(MoteLevelDownDef) as Mote;
        //    mote.Scale = 8.0f;
        //    mote.rotationRate = -100f;
        //    var position = pawn.DrawPos;
        //    mote.Attach(pawn);
        //    mote.exactPosition = position;

        //    GenSpawn.Spawn(mote, position.ToIntVec3(), Find.CurrentMap);
        //}

        public override void Execute(TargetInfo target)
        {
            throw new System.NotImplementedException();
        }

        //public override void Execute(Vector3 location)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}