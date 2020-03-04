using HarmonyLib;
using System.Linq;
using UnityEngine;
using Verse;

namespace LevelUp
{
    public class GameHandler : GameComponent
    {
        // TUrn into properties
        public LevelingInfo LevelUpInfo;

        public LevelingInfo LevelDownInfo;

        public int LevelIntervalSeconds;

        public GameHandler(Game _)
        { }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref LevelIntervalSeconds, nameof(LevelIntervalSeconds), 20);
            Scribe_Deep.Look(ref LevelUpInfo, nameof(LevelUpInfo));
            Scribe_Deep.Look(ref LevelDownInfo, nameof(LevelDownInfo));
        }

        public override void FinalizeInit()
        {
            if (LevelUpInfo is null)
            {
                LevelUpInfo = new LevelUpInfo();
                LevelUpInfo.SetDefaults();
            }

            if (LevelDownInfo is null)
            {
                LevelDownInfo = new LevelDownInfo();
                LevelDownInfo.SetDefaults();
            }

            var pawnSkillTimerCache = new PawnSkillTimerCache(25, this);
            LevelEventMaker = new LevelEventMaker(pawnSkillTimerCache, this);

            SkillRecordLearnPatch.InitializePatch(new Harmony("Krafs.LevelUp"));
        }

        public LevelEventMaker LevelEventMaker { get; private set; }

        public override void GameComponentOnGUI()
        {
            if (Find.CurrentMap is null)
            {
                return;
            }

            var map = Find.CurrentMap;
            var pawn = map.mapPawns.FreeColonists.FirstOrFallback();
            var skill = pawn.skills.skills.First(x => !(x is null));
            if (Widgets.ButtonText(new Rect(20f, 20f, 250f, 24f), $"Level up {pawn.LabelShortCap} in {skill.def.LabelCap}"))
            {
                skill.Learn(skill.XpRequiredForLevelUp * 1.2f, true);
            }

            if (Widgets.ButtonText(new Rect(20f, 50f, 250f, 24f), $"Level down {pawn.LabelShortCap} in {skill.def.LabelCap}"))
            {
                skill.Learn(-skill.xpSinceLastLevel * 1.2f, true);
            }

            if (Widgets.ButtonText(new Rect(20f, 80f, 250f, 24f), $"Level Manager Window"))
            {
                Find.WindowStack.Add(new LevelManagerWindow());
            }
        }
    }
}