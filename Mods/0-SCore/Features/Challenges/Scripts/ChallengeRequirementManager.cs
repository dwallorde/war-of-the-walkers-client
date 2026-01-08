using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using Challenges;

public static class ChallengeRequirementManager
{
    public static Dictionary<string, MinEffectGroup> ChallengeRequirements =
        new Dictionary<string, MinEffectGroup>();

    public static void AddRequirements(string id, XElement _element)
    {
        if (_element == null) return;
        if (string.IsNullOrEmpty(id)) return;
//
//         MinEffectGroup minEffectGroup = null;
//         List<IRequirement> list = null;
//
//         foreach (var e in _element.Elements())
//         {
//             if (e.Name == "requirement")
//             {
//                 if (minEffectGroup == null)
//                 {
//                     minEffectGroup = new MinEffectGroup();
//                 }
//                 IRequirement requirement = RequirementBase.ParseRequirement(e);
//                 if (requirement != null)
//                 {
//                     if (list == null)
//                     {
//                         list = new List<IRequirement>();
//                     }
//                     list.Add(requirement);
//                 }
//             }
//         }
//         if ( list?.Count == 0) return;
//         RequirementGroup.Op op = RequirementGroup.Op.And;
//
//         minEffectGroup.Requirements = new RequirementGroup(op, list);
//         minEffectGroup.Requirements = RequirementBase.ParseRequirementGroup(_element);
// if ( minEffectGroup.Requirements?.groups == null) return;
//         // foreach (XElement childElement in _element.Elements())
//         // {
//         //     if (childElement.Name.LocalName.EqualsCaseInsensitive("requirements"))
//         //     {
//         //         if (childElement.HasAttribute("compare_type"))
//         //         {
//         //             minEffectGroup.OrCompareRequirements = childElement.GetAttribute("compare_type").EqualsCaseInsensitive("or");
//         //         }
//         //
//         //         minEffectGroup.Requirements.AddRange(RequirementBase.ParseRequirements(childElement));
//         //     }
//         //     else if (childElement.Name.LocalName.EqualsCaseInsensitive("requirement"))
//         //     {
//         //         minEffectGroup.Requirements.Add(RequirementBase.ParseRequirement(childElement));
//         //     }
//         // }
//
//         if (minEffectGroup.Requirements.groups.Count > 0)
//         {
//             ChallengeRequirements.TryAdd(id.ToLower(), minEffectGroup);
//         }
    }

    public static bool IsValid(string id, ChallengeClass challengeClass = null, MinEventParams minEventContext = null)
    {
        // if (!ChallengeRequirements.TryGetValue(id.ToLower(), out var minEffectGroup))
        // {
        //     return true;
        // }

        if (challengeClass == null)
        {
            challengeClass = ChallengeClass.GetChallenge(id);
            if (challengeClass == null)
            {
                return true;
            }
        }

        var primaryPlayer = GameManager.Instance.World.GetPrimaryPlayer();
        if (minEventContext == null)
            minEventContext = primaryPlayer.MinEventContext;

        minEventContext.Biome = primaryPlayer.biomeStandingOn;

        if (challengeClass.Effects?.EffectGroups == null) return true;
        foreach (var group in challengeClass.Effects.EffectGroups)
        {
            Debug.Log($"Group: {group.ToString()}");
            if (!group.canRun(minEventContext))
            {
                Debug.Log("Cannot Run.");
                return false;
            }
                
        }
        // if (canRun(minEffectGroup, minEventContext))
        //     return true;
        return true;
    }

    private static bool canRun(MinEffectGroup minEffectGroup, MinEventParams pParams)
    {
        
        if (minEffectGroup.Requirements == null) return true;
        return minEffectGroup.Requirements.IsValid(pParams);
        // if (minEffectGroup.OrCompareRequirements)
        // {
        //     foreach (var t in minEffectGroup.Requirements)
        //     {
        //         if (t.IsValid(pParams))
        //         {
        //             return true;
        //         }
        //     }
        //
        //     return false;
        // }
        //
        // for (var j = 0; j < minEffectGroup.Requirements.Count; j++)
        // {
        //     if (!minEffectGroup.Requirements[j].IsValid(pParams))
        //     {
        //         return false;
        //     }
        // }
        //
        // return true;
    }
}