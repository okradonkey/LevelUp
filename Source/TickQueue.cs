using System.Collections.Generic;
using Verse;

namespace LevelUp
{
    public class TickQueue
    {
        private List<Pair<int, Effecter>> activeEffecters;

        public TickQueue()
        {
            this.activeEffecters = new List<Pair<int, Effecter>>();
        }

        public void Add(int durationTicks, Effecter effecter)
        {
            this.activeEffecters.Add(new Pair<int, Effecter>(durationTicks, effecter));
        }

        public void Tick()
        {
            for (int i = 0; i < this.activeEffecters.Count; i++)
            {
                if (this.activeEffecters[i].First > 0)
                {
                    //this.activeEffecters[i].Second.
                }
            }
        }
    }
}