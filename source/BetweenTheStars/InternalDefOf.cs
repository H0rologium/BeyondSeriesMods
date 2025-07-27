using RimWorld;
using Verse;



namespace BetweenTheStars
{
    [DefOf]
    public static class InternalDefOf
    {

        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static ThingDef ArchoComponent;

        public static ResearchProjectDef QuantUnderstand;

        public static ThingDef DecryptionBench;

        public static FactionDef BTS_Starway;

        public static PawnKindDef BTS_Frontierman;
    }
}
