#if NET35

using Harmony;
using System.Collections.Generic;

#elif NET472
using HarmonyLib;
#endif

using System.Reflection;
using Verse;

namespace LevelUp
{
    public class HarmonyPatcher : IPatcher
    {
#if NET35
        private readonly HarmonyInstance harmony;

        public HarmonyPatcher(string id)
        {
            this.harmony = HarmonyInstance.Create(id);
        }

#elif NET472
        private readonly Harmony harmony;

        public HarmonyPatcher(string id)
        {
            this.harmony = new Harmony(id);
        }
#endif

        public void ReApplyAllPatchesOn(MethodBase original)
        {
#if NET35
            var method = new List<MethodBase> { original };
#elif NET472
            var method = original;
#endif
            Log.Message("HarmonyPatcher::ReApplyAllPatchesOn");
            var patchProcessor = new PatchProcessor(this.harmony, method);
            patchProcessor.Patch();
        }

        public void Patch(MethodBase original, MethodInfo prefix = null, MethodInfo postfix = null, MethodInfo transpiler = null)
        {
            var hasAlreadyPatched = PatchProcessor.GetPatchInfo(original)?.Owners?.Contains(this.harmony.Id) ?? false;

            if (hasAlreadyPatched)
            {
                ReApplyAllPatchesOn(original);
            }
            else
            {
                var harmonyPrefix = prefix is null ? null : new HarmonyMethod(prefix);
                var harmonyPostfix = postfix is null ? null : new HarmonyMethod(postfix);
                var harmonyTranspiler = transpiler is null ? null : new HarmonyMethod(transpiler);

                this.harmony.Patch(original, harmonyPrefix, harmonyPostfix, harmonyTranspiler);
            }
        }
    }
}