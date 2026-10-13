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



    #endregion
}
