﻿using HarmonyLib;
using System.Linq;
using UnityEngine;
using Verse;

namespace LevelUp
{
    public class GameHandler : GameComponent
    {
        private static Harmony harmony;
        private static Harmony Harmony => harmony ??= new Harmony("krafs.levelup");

        public GameHandler(Game _)
        { }

        public override void FinalizeInit()
        {
            var pawnSkillTimerCache = new PawnSkillTimerCache(25);
            var levelEventMaker = new LevelEventMaker(pawnSkillTimerCache);
            SkillRecordLearnPatch.InitializePatch(Harmony, levelEventMaker);
        }

#if DEBUG

        public override void GameComponentOnGUI()
        {
            var map = Find.CurrentMap;
            var pawn = map.mapPawns.FreeColonists.FirstOrFallback();
            var skill = pawn.skills.skills.First(x => !(x is null));
            if (Widgets.ButtonText(new Rect(20f, 100f, 200f, 24f), $"Level up {pawn.LabelShortCap} in {skill.def.LabelCap}"))
            {
                var xp = skill.XpRequiredForLevelUp + skill.XpRequiredForLevelUp * 1.2f;
                skill.Learn(xp, true);
            }

            if (Widgets.ButtonText(new Rect(20f, 130f, 200f, 24f), $"Level down {pawn.LabelShortCap} in {skill.def.LabelCap}"))
            {
                var xp = skill.xpSinceLastLevel + skill.xpSinceLastLevel * 1.2f;
                skill.Learn(-xp, true);
            }
        }

#endif
    }
}