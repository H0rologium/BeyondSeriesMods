using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace BetweenTheStars
{
    public class HarmonyPatches
    {
        public  HarmonyPatches()
        {
            Log.Message("Constructing patches for BetweenTheStars");
            return;
        }
    }

    [StaticConstructorOnStartup]
    public static class HarmonyInit
    {
        static HarmonyInit()
        {
            HarmonyInit.harmonyInstance.PatchAll();
        }

        public static Harmony harmonyInstance = new Harmony("BetweenTheStars.HarmonyPatches");
    }

    #region Patches

    [HarmonyPatch(typeof(IdeoFoundation), "RandomizePrecepts")]
    public static class IdeoFoundation_RandomizePrecepts_Patch
    {
        public static bool Prefix(IdeoFoundation __instance, bool init, IdeoGenerationParms parms)
        {
            FactionDef forFaction = parms.forFaction;
            FactionGenOptions factionOptions = ((forFaction != null) ? forFaction.GetModExtension<FactionGenOptions>() : null);
            bool flag = ((factionOptions != null) ? factionOptions.preceptsToAdd : null) != null;
            bool flag2;
            if (flag)
            {
                __instance.ideo.ClearPrecepts();
                foreach (PreceptDef preceptDef in factionOptions.preceptsToAdd)
                {
                    __instance.ideo.AddPrecept(PreceptMaker.MakePrecept(preceptDef), true, parms.forFaction, null);
                }
                flag2 = false;
            }
            else
            {
                flag2 = true;
            }
            return flag2;
        }
    }


    [HarmonyPatch(typeof(IdeoUtility), "CanUseIdeo")]
    public static class IdeoUtility_CanUseIdeo_Patch
    {
        public static bool Prefix(FactionDef factionDef, Ideo ideo, IdeoGenerationParms parms)
        {
            IEnumerable<Faction> enumerable = Find.FactionManager.AllFactions.Where(delegate (Faction x)
            {
                FactionIdeosTracker ideos = x.ideos;
                return ((ideos != null) ? ideos.PrimaryIdeo : null) == ideo;
            });
            foreach (Faction faction in enumerable)
            {
                FactionGenOptions modExtension = faction.def.GetModExtension<FactionGenOptions>();
                if (modExtension != null && faction.def != factionDef && modExtension.hasUniqueIdeo)
                {
                    return false;
                }
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Ideo), "SetIcon")]
    public static class Ideo_SetIcon_Patch
    {
        public static void Postfix(Ideo __instance)
        {
            IEnumerable<Faction> enumerable = Find.FactionManager.AllFactions.Where(delegate (Faction x)
            {
                FactionIdeosTracker ideos = x.ideos;
                return ((ideos != null) ? ideos.PrimaryIdeo : null) == __instance;
            });
            foreach (Faction faction in enumerable)
            {
                FactionGenOptions modExtension = faction.def.GetModExtension<FactionGenOptions>();
                if (modExtension != null)
                {
                    if (modExtension.customIdeoIcon != null)
                    {
                        __instance.iconDef = modExtension.customIdeoIcon;
                    }
                    if (modExtension.customIdeoColor != null)
                    {
                        __instance.colorDef = modExtension.customIdeoColor;
                    }
                    if (!GenText.NullOrEmpty(modExtension.customIdeoDescription))
                    {
                        __instance.description = modExtension.customIdeoDescription;
                    }
                }
            }
        }
    }
    #endregion
}
