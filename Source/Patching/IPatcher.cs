using System.Reflection;

namespace LevelUp
{
    public interface IPatcher
    {
        void Patch(MethodBase original, MethodInfo prefix = null, MethodInfo postfix = null, MethodInfo transpiler = null);

        void ReApplyAllPatchesOn(MethodBase original);
    }
}