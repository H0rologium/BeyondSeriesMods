using RimWorld;
using System;
using Verse;
using Verse.AI;

namespace BetweenTheStars
{
    public class CompProperties_ResearchCore_CPT : CompProperties_Usable
    {
        public CompProperties_ResearchCore_CPT()
        {
            this.compClass = typeof(CompUseableResearchCore);
        }
    }

    [StaticConstructorOnStartup]
    public class CompUseableResearchCore : CompUsable
    {
        public override LocalTargetInfo GetExtraTarget(Pawn pawn)
        {
            return GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForDef(InternalDefOf.DecryptionBench), PathEndMode.InteractionCell, TraverseParms.For(pawn, Danger.Some, TraverseMode.ByPawn, false, false, false, true), 9999f, (Thing thing) => pawn.CanReserve(thing, 1, -1, null, false), null, 0, -1, false, RegionType.Set_Passable, false, false);
        }

        public override AcceptanceReport CanBeUsedBy(Pawn p, bool forced = false, bool ignoreReserveAndReachable = false)
        {
            AcceptanceReport acceptanceReport = base.CanBeUsedBy(p, forced, ignoreReserveAndReachable);
            bool flag = !acceptanceReport.Accepted;
            AcceptanceReport acceptanceReport2;
            if (flag)
            {
                acceptanceReport2 = acceptanceReport;
            }
            else
            {
                bool flag2 = !this.GetExtraTarget(p).HasThing;
                if (flag2)
                {
                    acceptanceReport2 = "NoDecryption".Translate();
                }
                else
                {
                    acceptanceReport2 = true;
                }
            }
            return acceptanceReport2;
        }
    }
}
