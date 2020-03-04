using Verse;

namespace LevelUp
{
    public class Settings : ModSettings
    {
        public bool DoLevelUp = true;
        public bool DoLevelDown;

        public AnimationDef LevelUpAnimation = DefDatabase<AnimationDef>.GetNamed("KrafsLevelUpAnimationBrightBubble");
        public AnimationDef LevelDownAnimation = DefDatabase<AnimationDef>.GetNamed("KrafsLevelUpAnimationRedBubble");
        public LevelSoundDef LevelUpSound = DefDatabase<LevelSoundDef>.GetNamed("KrafsLevelUpDing");
        public LevelSoundDef LevelDownSound = DefDatabase<LevelSoundDef>.GetNamed("KrafsLevelUpDrop");
        public float LevelUpSoundVolume;
        public float LevelDownSoundVolume;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref DoLevelUp, nameof(DoLevelUp));
            Scribe_Values.Look(ref DoLevelDown, nameof(DoLevelDown));
            Scribe_Defs.Look(ref LevelUpAnimation, nameof(LevelUpAnimation));
            Scribe_Defs.Look(ref LevelDownAnimation, nameof(LevelDownAnimation));
            Scribe_Defs.Look(ref LevelUpSound, nameof(LevelUpSound));
            Scribe_Defs.Look(ref LevelDownSound, nameof(LevelDownSound));
            Scribe_Values.Look(ref LevelUpSoundVolume, nameof(LevelUpSoundVolume), 25f);
            Scribe_Values.Look(ref LevelDownSoundVolume, nameof(LevelDownSoundVolume), 25f);
        }
    }
}