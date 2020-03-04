using System;
using Verse;

namespace LevelUp
{
    public class AnimationDef : Def
    {
        public AnimationWorker Worker
        {
            get
            {
                this.workerInt ??= Activator.CreateInstance(this.workerClass) as AnimationWorker;
                this.workerInt.def = this;
                return this.workerInt;
            }
        }

        public Type workerClass;

        private AnimationWorker workerInt;
    }
}