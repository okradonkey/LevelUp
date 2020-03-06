using Verse;

namespace LevelUp
{
    public class LevelingInfo : IExposable
    {
        private bool active;
        private string messageKey;
        private EffecterDef effect;
        public ref bool Active => ref active;
        public ref string MessageKey => ref messageKey;

        public ref EffecterDef Effect => ref effect;

        public void ExposeData()
        {
            Scribe_Values.Look(ref active, nameof(Active));
            Scribe_Defs.Look(ref effect, nameof(Effect));
        }
    }
}