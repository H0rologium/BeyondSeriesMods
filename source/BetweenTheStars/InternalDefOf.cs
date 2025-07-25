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

        //public static JobDef UseQRB;

        //public static ResearchTabDef QRT;

        public static ResearchProjectDef QuantUnderstand;

        public static ThingDef QuantRSB;

        public static ThingDef DecryptionBench;

        public static FactionDef BTS_Starway;

        public static PawnKindDef BTS_Frontierman;
    }
}
