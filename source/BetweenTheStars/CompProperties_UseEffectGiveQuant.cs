using RimWorld;
using System;
using System.Collections.Generic;
using Verse;


namespace BetweenTheStars
{
    public class CompProperties_UseEffectGiveQuant : CompProperties_UseEffect
    {
        public CompProperties_UseEffectGiveQuant()
        {
            this.compClass = typeof(CompUseEffect_GiveQuant);
        }
    }

    [StaticConstructorOnStartup]
    public class CompUseEffect_GiveQuant : CompUseEffect
    {
        public override void DoEffect(Pawn user)
        {
            Map map = Find.CurrentMap;
            if (Find.CurrentMap.IsPlayerHome && !Find.CurrentMap.IsPocketMap)
            {
                IntVec3 intVec = DropCellFinder.RandomDropSpot(map, true);
                List<Thing> list = new List<Thing>();
                Thing t = new Thing();
                t.def = InternalDefOf.DecryptionBench;
                MinifiedThing minifiedThing = t.MakeMinified(DestroyMode.Vanish);
                list.Add(minifiedThing);
                DropPodUtility.DropThingsNear(intVec, map, list, 110, false, true, true, false, false, null);
                Find.LetterStack.ReceiveLetter("ResearchAccessedLabel".Translate(), "ResearchAccessed".Translate(), LetterDefOf.ThreatSmall, new TargetInfo(intVec,map,false));
            }
        }
    }
}
