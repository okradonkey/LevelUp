using System.Linq;
using UnityEngine;
using Verse;

namespace LevelUp
{
    public class GameHandler : GameComponent
    {
        public override void FinalizeInit()
        {
            LevelIntervalSeconds = 0;
            ShowTabOnlyInDevMode = false;

            if (LevelUpInfo is null)
            {
                LevelUpInfo = new LevelingInfo();
                LevelUpInfo.Active = true;
                LevelUpInfo.Effect = DefDatabase<LevelingDef>.GetNamed("Effecter_LevelUpWIP");
                LevelUpInfo.MessageKey = "Krafs.LevelUp.LevelUpMessage";
            }

            if (LevelDownInfo is null)
            {
                LevelDownInfo = new LevelingInfo();
                LevelDownInfo.Active = true;
                LevelDownInfo.Effect = DefDatabase<LevelingDef>.GetNamed("Effecter_LevelDownRedSpiral");
                LevelDownInfo.MessageKey = "Krafs.LevelUp.LevelDownMessage";
            }

            TickQueue = new TickQueue();
            var pawnSkillTimer = new PawnSkillTimer(25, this);
            LevelEventMaker = new LevelEventListener(pawnSkillTimer, this);

            if (harmonyPatcher is null)
            {
                harmonyPatcher = new HarmonyPatcher("Krafs.LevelUp");

                SkillRecordLearnPatch.InitializePatch(harmonyPatcher);
            }
            else
            {
                SkillRecordLearnPatch.ReApplyPatch();
            }
        }

        private static HarmonyPatcher harmonyPatcher;
        public TickQueue TickQueue;

        // Turn into properties?
        public LevelingInfo LevelUpInfo;

        public LevelingInfo LevelDownInfo;

        public int LevelIntervalSeconds;
        public bool ShowTabOnlyInDevMode;

        public LevelEventListener LevelEventMaker { get; private set; }

        public GameHandler(Game _)
        { }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref LevelIntervalSeconds, nameof(LevelIntervalSeconds));
            Scribe_Deep.Look(ref LevelUpInfo, nameof(LevelUpInfo));
            Scribe_Deep.Look(ref LevelDownInfo, nameof(LevelDownInfo));
        }

        public override void GameComponentTick()
        {
        }

#if DEBUG

        public override void GameComponentOnGUI()
        {
            if (Find.CurrentMap is null)
            {
                return;
            }

            var y = 80f;

            var map = Find.CurrentMap;
            var pawn = map.mapPawns.FreeColonists.FirstOrFallback();
            var skill = pawn.skills.skills.First(x => !(x is null));
            if (Widgets.ButtonText(new Rect(20f, y, 300f, 24f), $"Level up {pawn.LabelShortCap} in {skill.def.LabelCap}"))
            {
                skill.Learn(skill.XpRequiredForLevelUp * 1.2f, true);
            }
            y += 30f;
            if (Widgets.ButtonText(new Rect(20f, y, 300f, 24f), $"Level down {pawn.LabelShortCap} in {skill.def.LabelCap}"))
            {
                skill.Learn(-skill.xpSinceLastLevel * 1.2f, true);
            }

            y += 30f;
            Widgets.Label(new Rect(20f, y, 250f, 24f), "Timer value: " + LevelIntervalSeconds);
        }
    }

#endif
}