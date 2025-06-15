using RimWorld;
using System;
using System.Linq;
using Verse;
using Verse.AI;

namespace BetweenTheStars
{
    public class GenStep_Terminal : Verse.GenStep
    {
        public override int SeedPart
        {
            get
            {
                return 98641684;
            }
        }

        public override void Generate(Map map, GenStepParams parms)
        {
            if (ShouldSkipMap(map)) return;
            IntVec3 spIV;
            if (!TryFindCell(map, out spIV)) return;
            atcDef = DefDatabase<ThingDef>.GetNamed("AncientTerminalQuantSegment", true);
            GenSpawn.Spawn(this.atcDef,spIV,map,WipeMode.Vanish);
            Log.Message("Spawned ancient terminal");
        }

        protected bool TryFindCell(Map map, out IntVec3 result)
        {
            if (CellFinderLoose.TryFindRandomNotEdgeCellWith(6, (IntVec3 x) => this.CanSpawnAt(x, map), map, out result))
            {
                return true;
            }
            return false;
        }

        protected virtual bool ShouldSkipMap(Map map)
        {
            return !map.IsStartingMap && !map.TileInfo.WaterCovered;
        }

        protected bool CanSpawnAt(IntVec3 loc, Map map)
        {
            if (!loc.Standable(map) || loc.Fogged(map) || !loc.GetRoom(map).PsychologicallyOutdoors)
            {
                return false;
            }
            if (GenRadial.RadialDistinctThingsAround(loc, map, 20f, false).Any(new Func<Thing, bool>(MeditationUtility.CountsAsArtificialBuilding)))
            {
                return false;
            }
            for (int i = 0; i < GenRadial.NumCellsInRadius(40); i++)
            {
                IntVec3 intVec = loc + GenRadial.RadialPattern[i];
                if (WanderUtility.InSameRoom(intVec, loc, map))
                {
                    if (intVec.InBounds(map) && !intVec.Roofed(map) && intVec.GetFertility(map) > 0f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected ThingDef atcDef;
    }
}
