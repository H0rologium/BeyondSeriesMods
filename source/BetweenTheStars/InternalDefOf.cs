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

        
        public static ThingDef DecryptionBench;
    }
}
