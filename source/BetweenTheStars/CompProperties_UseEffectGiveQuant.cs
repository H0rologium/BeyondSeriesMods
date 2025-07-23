using RimWorld;
using RimWorld.QuestGen;
using System.Collections.Generic;
using UnityEngine;
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
                Find.LetterStack.ReceiveLetter("ResearchAccessedLabel".Translate(), "ResearchAccessed".Translate(), LetterDefOf.NeutralEvent, new TargetInfo(intVec, map, false));

                //Please do not ever make me create a proper quest through xml. id rather inline in harmony
                if (Find.FactionManager.FirstFactionOfDef(InternalDefOf.BTS_Starway) != null) Find.FactionManager.FirstFactionOfDef(InternalDefOf.BTS_Starway).ChangeGoodwill_Debug(Find.FactionManager.OfPlayer, -100);
                Find.LetterStack.ReceiveLetter("FactionBetrayedLabel".Translate(), "FactionBetrayed".Translate(), LetterDefOf.ThreatSmall);
                
                IncidentParms IP = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, map);
                IP.forced = true;
                IP.faction = Find.FactionManager.FirstFactionOfDef(InternalDefOf.BTS_Starway);
                if (IP.faction != null)
                {
                    IP.target = map;
                    IP.pawnKind = InternalDefOf.BTS_Frontierman;
                    IP.raidStrategy = RaidStrategyDefOf.ImmediateAttack;
                    IP.raidNeverFleeIndividual = true;
                    IP.raidArrivalMode = PawnsArrivalModeDefOf.EdgeWalkIn;
                    IP.customLetterLabel = "EnforcementSentLabel".Translate();
                    IP.customLetterText = "EnforcementSent".Translate();
                    IncidentDefOf.RaidEnemy.Worker.TryExecute(IP);
                }
            }
        }
    }
}
