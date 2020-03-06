using RimWorld;

using Verse;

namespace LevelUp
{
    public class LevelEventMaker
    {
        private readonly PawnSkillTimerCache pawnSkillTimerCache;
        private readonly GameHandler gameHandler;

        public LevelEventMaker(PawnSkillTimerCache pawnSkillTimerCache, GameHandler gameHandler)
        {
            this.pawnSkillTimerCache = pawnSkillTimerCache;
            this.gameHandler = gameHandler;
        }

        public void OnLevelDown(SkillRecord skillRecord, Pawn pawn)
        {
            OnLevelChange(gameHandler.LevelDownInfo, skillRecord, pawn);
        }

        public void OnLevelUp(SkillRecord skillRecord, Pawn pawn)
        {
            OnLevelChange(gameHandler.LevelUpInfo, skillRecord, pawn);
        }

        public void OnLevelChange(LevelingInfo levelingInfo, SkillRecord skillRecord, Pawn pawn)
        {
            if (pawn.IsFreeColonist && this.pawnSkillTimerCache.EnoughTimeHasPassed(pawn, skillRecord.def))
            {
                //var effecterDef = DefDatabase<EffecterDef>.GetNamed("Effecter_LevelUp");
                //var text = TextModifier.Replace(levelingInfo.MessageKey, skillRecord, pawn, skillRecord.Level);
                //var effect = levelingInfo.Effect.Spawn();

                var text = levelingInfo.MessageKey.Translate(pawn.LabelShortCap.Colorize(GUIStuff.PawnName), skillRecord.Level, skillRecord.def.LabelCap);
                var textHolder = new TextHolderThing(text);
                levelingInfo.Effect.Spawn().Trigger(pawn, textHolder);
            }
        }
    }
}

//levelingInfo.Animation.Worker.Execute(pawn);
//levelingInfo.Message.Worker.Execute(text, pawn);
//var soundInfo = SoundInfo.OnCamera(MaintenanceType.None);
//soundInfo.volumeFactor = levelingInfo.Volume;
//levelingInfo.Sound.PlayOneShot(soundInfo); // Remake this into soundworker?