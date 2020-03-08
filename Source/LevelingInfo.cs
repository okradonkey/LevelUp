using System.Collections.Generic;
using Verse;

namespace LevelUp
{
    public class LevelingInfo : IExposable
    {
        private bool active;
        private string messageKey;
        private EffecterDef effect;
        private FloatMenu menu;

        public ref bool Active => ref active;
        public ref string MessageKey => ref messageKey;

        public ref EffecterDef Effect => ref effect;

        public FloatMenu Menu
        {
            get
            {
                if (this.menu is null)
                {
                    var options = new List<FloatMenuOption>();
                    foreach (var def in DefDatabase<LevelingDef>.AllDefs)
                    {
                        options.Add(new FloatMenuOption(def.label.CapitalizeFirst(), () => this.Effect = def));
                    }
                    this.menu = new FloatMenu(options);
                }

                return this.menu;
            }
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref active, nameof(Active));
            Scribe_Defs.Look(ref effect, nameof(Effect));
        }
    }
}