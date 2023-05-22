using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Vintagestory.GameContent;

namespace resregrow2
{
    [HarmonyPatch(typeof(BlockEntitySapling), "CheckGrow")]
    public static class Sapling
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var prevIndex = -1;

            var codes = new List<CodeInstruction>(instructions);
            for (var i = 0; i < codes.Count; i++)
            {
                if (prevIndex != -1)
                {
                    if (codes[i].opcode == OpCodes.Stfld)
                    {

                        var fieldInfo = codes[i].operand as FieldInfo;
                        if (fieldInfo.Name == "otherBlockChance" && codes[prevIndex].opcode == OpCodes.Ldc_R4)
                        {
                            codes[prevIndex] = new CodeInstruction(OpCodes.Ldc_R4, 1.0f);
                        }
                    }
                }
                prevIndex = i;
            }

            return codes.AsEnumerable();
        }

    }
}