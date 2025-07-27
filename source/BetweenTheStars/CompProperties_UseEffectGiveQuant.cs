using RimWorld;
using RimWorld.QuestGen;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.Noise;


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
            if (Find.CurrentMap.TileInfo.OnSurface && !Find.CurrentMap.IsPocketMap)
            {
                if (InternalDefOf.QuantUnderstand.IsFinished)
                {
                    Messages.Message("Further data has been decrypted, providing the resources to build archotech components instead of data",MessageTypeDefOf.NeutralEvent);
                    GenSpawn.Spawn(InternalDefOf.ArchoComponent,user.Position,Find.CurrentMap);
                }
                else
                {
                    Find.LetterStack.ReceiveLetter("FactionBetrayedLabel".Translate(), "FactionBetrayed".Translate(), LetterDefOf.ThreatSmall);
                    SendLoyaltyRaid(1,map);
                }
                //IntVec3 intVec = DropCellFinder.RandomDropSpot(map, true);
                //List<Thing> list = new List<Thing>();
                //Thing t = new Thing();
                //t.def = InternalDefOf.QuantRSB;
                //MinifiedThing minifiedThing = t.MakeMinified(DestroyMode.Vanish);
                //list.Add(minifiedThing);
                //DropPodUtility.DropThingsNear(intVec, map, list, 110, false, true, true, false, false, null);
                //Find.LetterStack.ReceiveLetter("ResearchAccessedLabel".Translate(), "ResearchAccessed".Translate(), LetterDefOf.NeutralEvent, new TargetInfo(intVec, map, false));
            }
            else
            {
                Messages.Message("The encrypted data has been lost due to a weak signal. You can find better signals by decrypting when occupying the surface of a planetary tile.", MessageTypeDefOf.ThreatSmall);
            }
        }


        private void SendLoyaltyRaid(int amt,Map map,string letterLabel = "EnforcementSentLabel", string letterText = "EnforcementSent")
        {
            if (Find.FactionManager.FirstFactionOfDef(InternalDefOf.BTS_Starway) != null) Find.FactionManager.FirstFactionOfDef(InternalDefOf.BTS_Starway).ChangeGoodwill_Debug(Find.FactionManager.OfPlayer, -100);
            
            for (int i = 0; i < amt; i++)
            {
                IncidentParms IP = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, map);
                IP.forced = true;
                IP.faction = Find.FactionManager.FirstFactionOfDef(InternalDefOf.BTS_Starway);
                if (IP.faction != null)
                {
                    IP.target = map;
                    IP.forced = true;
                    IP.pointMultiplier = 1.25f;
                    IP.forced = true;
                    IP.raidStrategy = RaidStrategyDefOf.ImmediateAttack;
                    IP.raidNeverFleeIndividual = true;
                    IP.raidArrivalMode = PawnsArrivalModeDefOf.EdgeWalkIn;
                    IP.customLetterLabel = letterLabel.Translate();
                    IP.customLetterText = letterText.Translate();
                    IncidentDefOf.RaidEnemy.Worker.TryExecute(IP);
                }
            }
            

        }
    }
}
