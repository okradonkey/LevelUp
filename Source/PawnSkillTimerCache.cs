using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace LevelUp
{
    public class PawnSkillTimerCache
    {
        private readonly Dictionary<ValueTuple<Pawn, SkillDef>, DateTime> timerCache;
        private readonly GameHandler gameHandler;

        public PawnSkillTimerCache(int capacity, GameHandler gameHandler)
        {
            this.timerCache = new Dictionary<ValueTuple<Pawn, SkillDef>, DateTime>(capacity);
            this.gameHandler = gameHandler;
        }

        public bool EnoughTimeHasPassed(Pawn pawn, SkillDef skillDef)
        {
            var currentDateTime = DateTime.Now;
            var key = new ValueTuple<Pawn, SkillDef>(pawn, skillDef);

            if (timerCache.TryGetValue(key, out DateTime minDateTime) && currentDateTime < minDateTime)
            {
                return false;
            }

            timerCache[key] = currentDateTime.AddSeconds(gameHandler.LevelIntervalSeconds);
            return true;
        }
    }
}