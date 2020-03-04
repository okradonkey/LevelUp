using RimWorld;
using Verse;
using Verse.Sound;

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

        public void OnLevelDown(SkillRecord skillRecord, Pawn pawn, int level)
        {
            OnLevelChange(gameHandler.LevelDownInfo, skillRecord, pawn, level);
        }

        public void OnLevelUp(SkillRecord skillRecord, Pawn pawn, int level)
        {
            OnLevelChange(gameHandler.LevelUpInfo, skillRecord, pawn, level);
        }

        public void OnLevelChange(LevelingInfo levelingInfo, SkillRecord skillRecord, Pawn pawn, int level)
        {
            if (pawn.IsFreeColonist && this.pawnSkillTimerCache.EnoughTimeHasPassed(pawn, skillRecord.def))
            {
                levelingInfo.Animation.Worker.Execute(pawn);
                var text = TextModifier.Replace(levelingInfo.MessageText, skillRecord, pawn, level); // Turn this into textworker?
                levelingInfo.Message.Worker.Execute(text, pawn);
                var soundInfo = SoundInfo.OnCamera(MaintenanceType.None);
                soundInfo.volumeFactor = levelingInfo.Volume;
                levelingInfo.Sound.PlayOneShot(soundInfo); // Remake this into soundworker?
            }
        }
    }
}