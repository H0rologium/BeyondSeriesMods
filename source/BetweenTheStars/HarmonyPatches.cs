using Verse;
using RimWorld;
using HarmonyLib;
using System.Collections.Generic;

namespace BetweenTheStars
{
    //[StaticConstructorOnStartup]
    //public static class HarmonyPatches
    //{
    //    static HarmonyPatches()
    //    {
    //        //package name not necessary, doing for consistency
    //        Harmony h = new Harmony("horo.BTEOTW2.25");


    //        h.PatchAll();
    //        Log.Message("B.T.S Patched everything");
    //    }
    //}

    //[HarmonyPatch]
    //public static class PatchGenStepForTerminal
    //{
    //    [HarmonyPatch(typeof(MapGenerator), nameof(MapGenerator.GenerateMap))]
    //    [HarmonyPostfix]
    //    public static void GenStep_AddStep(Map map, CellRect structure, List<ScatteredPrefabs> groups)
    //    {
    //        GenStep_Terminal genStep_Terminal = new GenStep_Terminal();
    //        GenStepParams gsp = default(GenStepParams);
    //        genStep_Terminal.Generate(map, gsp);
    //    }
    //}
}
