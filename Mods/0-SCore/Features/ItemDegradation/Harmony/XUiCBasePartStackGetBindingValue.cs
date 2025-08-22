// using HarmonyLib;
// using SCore.Features.ItemDegradation.Utils;
//
// namespace SCore.Features.ItemDegradation.Harmony
// {
//     [HarmonyPatch(typeof(XUiC_ItemStack))]
//     [HarmonyPatch(nameof(XUiC_ItemStack.Update))]
//     public class XUiCBasePartStackGetBindingValue
//     {
//         private static bool ShouldSkipDurability(XUiC_ItemStack instance)
//         {
//             if (instance == null) return true;
//             if (instance.StackLocation == XUiC_ItemStack.StackLocationTypes.Creative) return true; // Skip creative
//
//             var itemStack = instance.ItemStack;
//             if (itemStack == null || itemStack.IsEmpty()) return true; // Skip empty/null stacks
//
//             // If locked in drag/drop, it might be temporary, skip for stability
//             if (instance.IsLocked && instance.IsDragAndDrop) return true;
//
//             if (itemStack.itemValue == null) return true;
//             return !ItemDegradationHelpers.CanDegrade(itemStack.itemValue);
//         }
//
//         public static void Postfix(XUiC_ItemStack __instance)
//         {
//             if (ShouldSkipDurability(__instance)) return;
//             var durabilityController = __instance.GetChildById("durability");
//             if (durabilityController?.ViewComponent is XUiV_Sprite durabilitySprite)
//             {
//                 float percentFresh = 1f - ItemDegradationHelpers.GetPercentUsed(__instance.itemStack.itemValue);
//                 durabilitySprite.IsVisible = true;
//                 durabilitySprite.Fill = percentFresh;
//             }
//         }
//     }
//     
//    
//     
// }