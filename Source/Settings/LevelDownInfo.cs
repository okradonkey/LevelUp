using Verse;

namespace LevelUp
{
    public class LevelDownInfo : LevelingInfo
    {
        public override void SetDefaults()
        {
            Sound = DefDatabase<LevelSoundDef>.GetNamed("KrafsLevelUpDrop");
            Animation = DefDatabase<AnimationDef>.GetNamed("KrafsLevelUpAnimationRedBubble");
            Message = DefDatabase<MessageDef>.GetNamed("KrafsLevelUpMessageTopLeftSimple");
            MessageText = I18n.Translate("Krafs.LevelUp.LevelDownMessage");
        }
    }
}