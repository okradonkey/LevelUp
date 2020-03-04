using System;
using Verse;

namespace LevelUp
{
    public class MessageDef : Def
    {
        public MessageWorker Worker
        {
            get
            {
                this.workerInt ??= Activator.CreateInstance(this.workerClass) as MessageWorker;
                this.workerInt.def = this;
                return this.workerInt;
            }
        }

        public Type workerClass;

        private MessageWorker workerInt;
    }
}