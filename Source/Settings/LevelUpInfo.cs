using Verse;

namespace LevelUp
{
    public class LevelUpInfo : LevelingInfo
    {
        public override void SetDefaults()
        {
            Sound = DefDatabase<LevelSoundDef>.GetNamed("KrafsLevelUpDing");
            Animation = DefDatabase<AnimationDef>.GetNamed("KrafsLevelUpAnimationBrightBubble");
            Message = DefDatabase<MessageDef>.GetNamed("KrafsLevelUpMessageTopLeftSimple");
            MessageText = "Krafs.LevelUp.LevelUpMessage".TranslateSimple();

        }
    }
}