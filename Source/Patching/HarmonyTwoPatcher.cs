using HarmonyLib;
using System.Reflection;

namespace LevelUp
{
    public class HarmonyTwoPatcher : IPatcher
    {
        private readonly Harmony harmony;

        public HarmonyTwoPatcher(string id)
        {
            this.harmony = new Harmony(id);
        }

        public void ReApplyAllPatchesOn(MethodBase original)
        {
            var patchProcessor = new PatchProcessor(this.harmony, original);
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