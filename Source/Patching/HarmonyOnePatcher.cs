using Harmony;
using System.Collections.Generic;
using System.Reflection;

namespace LevelUp
{
    public class HarmonyOnePatcher : IPatcher
    {
        private readonly HarmonyInstance harmony;

        public HarmonyOnePatcher(string id)
        {
            this.harmony = HarmonyInstance.Create(id);
        }

        public void ReApplyAllPatchesOn(MethodBase original)
        {
            var method = new List<MethodBase> { original };

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