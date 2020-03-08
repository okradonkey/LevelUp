using RimWorld;

using Verse;

namespace LevelUp
{
    public class LevelEventListener
    {
        private readonly PawnSkillTimer pawnSkillTimer;
        private readonly GameHandler gameHandler;

        public LevelEventListener(PawnSkillTimer pawnSkillTimer, GameHandler gameHandler)
        {
            this.pawnSkillTimer = pawnSkillTimer;
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
            if (pawn.IsFreeColonist && this.pawnSkillTimer.EnoughTimeHasPassed(pawn, skillRecord.def))
            {
                LevelActionTrigger.Trigger(levelingInfo, skillRecord, pawn);
            }
        }
    }
}