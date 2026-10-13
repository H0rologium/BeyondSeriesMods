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

        //Adds vanilla defs bench for usability
        public static ThingDef HiTechResearchBench;
        public static ResearchProjectDef Fabrication;

        public static ThingDef ArchoComponent;

        public static ResearchProjectDef QuantUnderstand;

        public static FactionDef BTS_Starway;

        public static PawnKindDef BTS_Frontierman;
    }
}
