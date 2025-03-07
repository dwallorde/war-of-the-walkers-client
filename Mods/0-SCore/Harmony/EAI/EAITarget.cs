﻿using System;
using HarmonyLib;
using UAI;
using UnityEngine;

namespace Harmony.EAI
{
    [HarmonyPatch(typeof(EAITarget))]
    [HarmonyPatch("check")]
    public class EAITarget_check
    {
        public static void Postfix(ref bool __result, EAITarget __instance, global::EntityAlive _e)
        {
            if (!__result) return;

            // Only "humans" and entities with Use Factions tags should use faction-based targeting
            if (!EntityUtilities.IsHuman(__instance.theEntity.entityId)
                && !EntityUtilities.UseFactions(__instance.theEntity))
                return;

            // If its a vehicle.. umm.. no.
            if (_e is EntityVehicle)
            {
                __result = false;
                return;
            }

            // Checks if we are allies, either share a leader, or is our leader.
            if (EntityTargetingUtilities.IsAlly(__instance.theEntity, _e))
            {
                __result = false;
                return;
            }


            // Do we have a revenge target? Are they the ones attacking us?
            if (EntityTargetingUtilities.IsCurrentRevengeTarget(__instance.theEntity, _e))
            {
                __result = true;
                return;
            }

            // If the target entity is attacking our ally, target them too.
            var leader = EntityUtilities.GetLeaderOrOwner(__instance.theEntity.entityId);
            if (EntityTargetingUtilities.IsFightingFollowers(leader, _e))
            {
                __result = true;
                return;
            }

            if (!EntityUtilities.UseFactionTargeting(__instance.theEntity))
                return;

            var myRelationship = FactionManager.Instance.GetRelationshipTier(__instance.theEntity, _e);
            switch (myRelationship)
            {
                case FactionManager.Relationship.Hate:
                    __result = true;
                    break;
                case FactionManager.Relationship.Dislike:  
                    __result = true;
                    break;
                case FactionManager.Relationship.Neutral:
                case FactionManager.Relationship.Like:
                case FactionManager.Relationship.Love:
                case FactionManager.Relationship.Leader:
                default:
                    __result = false;
                    break;
            }

            return;
        }
    }
}
