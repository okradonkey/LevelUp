using RimWorld;
using System.Reflection;
using Verse;

namespace LevelUp
{
    public static partial class SkillRecordLearnPatch
    {
        private static HarmonyPatcher patcher;
        private static readonly MethodBase original = typeof(SkillRecord).GetMethod(nameof(SkillRecord.Learn));
        private static LevelEventListener LevelEventMaker => Current.Game.GetComponent<GameHandler>().LevelEventMaker;
        private static readonly MethodBase levelEventMakerGetter = typeof(SkillRecordLearnPatch).GetProperty(nameof(LevelEventMaker), BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetProperty).GetGetMethod(true);

        private static readonly MethodBase onLevelUp = typeof(LevelEventListener).GetMethod(nameof(LevelEventMaker.OnLevelUp));

        private static readonly MethodBase onLevelDown = typeof(LevelEventListener).GetMethod(nameof(LevelEventMaker.OnLevelDown));

        private static readonly FieldInfo levelField = typeof(SkillRecord).GetField(nameof(SkillRecord.levelInt));
        private static readonly FieldInfo pawnField = typeof(SkillRecord).GetField("pawn", BindingFlags.NonPublic | BindingFlags.Instance);

        public static void ReApplyPatch()
        {
            patcher.ReApplyAllPatchesOn(original);
        }

        public static void InitializePatch(HarmonyPatcher harmonyPatcher)
        {
            patcher = harmonyPatcher;

            var transpilerMethod = typeof(SkillRecordLearnPatch).GetMethod(nameof(SkillRecordLearnPatch.LearnTranspilerPatch), BindingFlags.Static | BindingFlags.NonPublic);

            harmonyPatcher.Patch(original, transpiler: transpilerMethod);
        }
    }
}