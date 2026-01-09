using HarmonyLib;
using SCore.Features.ItemDegradation.Utils;
using UnityEngine;

namespace SCore.Features.ItemDegradation.Harmony.General
{
    [HarmonyPatch(typeof(MinEventActionModifyCVar))]
    [HarmonyPatch(nameof(MinEventActionModifyCVar.Execute))]
    public class MinEventActionModifyCVarExecute
    {
        private static readonly string AdvFeatureClass = "AdvancedItemFeatures";
        private static readonly string Feature = "CustomQualityLevels";
       public static bool Prefix(MinEventActionModifyCVar __instance, MinEventParams _params)
{
    if (!Configuration.CheckFeatureStatus(AdvFeatureClass, Feature)) return true;

    // Handle tierList logic separately
    if (__instance.rollType == MinEventActionModifyCVar.RandomRollTypes.tierList)
    {
        if ((_params.ParentType == MinEffectController.SourceParentType.ItemClass || 
             _params.ParentType == MinEffectController.SourceParentType.ItemModifierClass) && 
            !_params.ItemValue.IsEmpty())
        {
            // Use SCore's QualityUtils to handle custom quality scaling
            int tierIndex = QualityUtils.CalculateTier(_params.ItemValue.Quality);

            // Clamp to prevent Index Out of Bounds
            tierIndex = Mathf.Clamp(tierIndex, 0, __instance.valueList.Length - 1);
            __instance.value = __instance.valueList[tierIndex];
        }
    }

    // Apply values to targets
    for (int i = 0; i < __instance.targets.Count; i++)
    {
        float finalValue = __instance.value;

        if (__instance.cvarRef)
        {
            finalValue = __instance.targets[i].Buffs.GetCustomVar(__instance.refCvarName);
        }
        else if (__instance.rollType == MinEventActionModifyCVar.RandomRollTypes.randomInt)
        {
            finalValue = Mathf.Clamp((float)_params.Self.rand.RandomRange((int)__instance.minValue, (int)__instance.maxValue + 1), __instance.minValue, __instance.maxValue);
        }
        else if (__instance.rollType == MinEventActionModifyCVar.RandomRollTypes.randomFloat)
        {
            finalValue = Mathf.Clamp(_params.Self.rand.RandomRange(__instance.minValue, __instance.maxValue + 1f), __instance.minValue, __instance.maxValue);
        }

        // Set the CVar on the target
        __instance.targets[i].Buffs.SetCustomVar(
            __instance.cvarName, 
            finalValue, 
            (__instance.targets[i].isEntityRemote && !_params.Self.isEntityRemote) || _params.IsLocal, 
            __instance.operation
        );
    }

    return false; // Skip the original method
}
    }
}