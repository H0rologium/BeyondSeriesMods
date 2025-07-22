using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace BetweenTheStars
{
    public class JobDriver_UseDecryptionBench : JobDriver_UseItem
    {
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return base.TryMakePreToilReservations(errorOnFailed) && this.pawn.Reserve(this.job.targetB, this.job, 1, -1, null, errorOnFailed, false);
        }
        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnIncapable(PawnCapacityDefOf.Manipulation);
            this.FailOn(() => !base.TargetThingA.TryGetComp<CompUsable>().CanBeUsedBy(this.pawn, false, false));
            this.FailOnDespawnedNullOrForbidden(TargetIndex.B);
            this.FailOnBurningImmobile(TargetIndex.B);
            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.ClosestTouch, false).FailOnDespawnedNullOrForbidden(TargetIndex.A).FailOnSomeonePhysicallyInteracting(TargetIndex.A);
            yield return Toils_Haul.StartCarryThing(TargetIndex.A, false, false, false, true, false).FailOnDestroyedNullOrForbidden(TargetIndex.A);
            yield return Toils_Goto.GotoThing(TargetIndex.B, PathEndMode.InteractionCell, false);
            yield return Toils_Haul.PlaceHauledThingInCell(TargetIndex.B, null, false, false);
            yield return base.PrepareToUse();
            yield return base.Use();
            yield break;
        }
        private const TargetIndex Item = TargetIndex.A;

        private const TargetIndex BenchIndex = TargetIndex.B;
    }
    
}
