using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Verse;

#if NET35

using Harmony;

#elif NET472
using HarmonyLib;
#endif

namespace LevelUp
{
    public static partial class SkillRecordLearnPatch
    {
        private static IEnumerable<CodeInstruction> LearnTranspilerPatch(IEnumerable<CodeInstruction> instructions)
        {
            var gameHandler = Current.Game.GetComponent<GameHandler>();

            CodeInstruction previousInstruction = default;

            foreach (var currentInstruction in instructions)
            {
                yield return currentInstruction;

                if (currentInstruction.opcode == OpCodes.Stfld && currentInstruction.operand as FieldInfo == levelField)
                {
                    MethodBase onLevelChangeMethod = null;
                    if (previousInstruction.opcode == OpCodes.Add && gameHandler.LevelUpInfo.Active)
                    {
                        onLevelChangeMethod = onLevelUp;
                    }
                    else if (previousInstruction.opcode == OpCodes.Sub && gameHandler.LevelDownInfo.Active)
                    {
                        onLevelChangeMethod = onLevelDown;
                    }

                    if (onLevelChangeMethod != null)
                    {
                        yield return new CodeInstruction(OpCodes.Call, levelEventMakerGetter);
                        yield return new CodeInstruction(OpCodes.Ldarg_0);
                        yield return new CodeInstruction(OpCodes.Ldarg_0);
                        yield return new CodeInstruction(OpCodes.Ldfld, pawnField);
                        //yield return new CodeInstruction(OpCodes.Ldarg_0);
                        //yield return new CodeInstruction(OpCodes.Ldfld, levelField);
                        yield return new CodeInstruction(OpCodes.Call, onLevelChangeMethod);
                    }
                }

                previousInstruction = currentInstruction;
            }
        }
    }
}