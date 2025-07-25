

using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace BetweenTheStars
{
    public class JobDriver_ActivateMachine : JobDriver
    {
        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return pawn.Reserve(job.targetA, job, 1, -1, null, errorOnFailed);
        }

        protected override IEnumerable<Toil> MakeNewToils()
        {
            this.FailOnIncapable(PawnCapacityDefOf.Moving);
            this.FailOnDespawnedNullOrForbidden(TargetIndex.A);
            this.FailOnBurningImmobile(TargetIndex.A);
            if (InternalDefOf.QuantUnderstand.IsFinished)
            {
                Messages.Message("The machine has already been activated",null);
                yield break;
            }

            yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.InteractionCell, false);
            yield return Toils_Effects.MakeSound(SoundDefOf.MechanoidsWakeUp);
            yield break;
        }

    }
}
