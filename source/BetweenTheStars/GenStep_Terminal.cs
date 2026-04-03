using RimWorld;
using RimWorld.Planet;
using System;
using System.Linq;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.Noise;

namespace BetweenTheStars
{
    public class GenStep_Terminal : Verse.GenStep
    {
        private bool checkForPassive;

        public GenStep_Terminal()
        {
            checkForPassive = LoadedModManager.GetMod<BetweenTheStars>().GetSettings<BTSModSettings>().passiveMode;
        }
        public override int SeedPart
        {
            get
            {
                return 98641684;
            }
        }
        private void GenTerminal(IntVec3 spIV,Map map)
        {
            atcDef = DefDatabase<ThingDef>.GetNamed("AncientTerminalQuantSegment", true);
            GenSpawn.Spawn(this.atcDef, spIV, map, WipeMode.Vanish);
            return;
        }

        public override void Generate(Map map, GenStepParams parms)
        {

            if (ShouldSkipMap(map)) return;
            IntVec3 spIV;
            if (!TryFindCell(map, out spIV)) return;
            var spawnChance = UnityEngine.Random.Range(1, 100);

            if (spawnChance >= 20)
            {
                if (!InternalDefOf.Fabrication.IsFinished) { Log.Message("[BTS] Skipped terminal generation. this is normal behaviour."); return; }

                if ((checkForPassive && (map.IsPlayerHome || map.Parent is Camp)))
                {
                    GenTerminal(spIV, map);
                    return;
                }
                else if (map.ParentFaction != null)
                {
                    //Redundant but guaranteed to get us what we want
                    if (!map.ParentFaction.IsPlayerSafe() || !map.ParentFaction.IsPlayer) GenTerminal(spIV, map);
                    return;
                }
                else
                {
                    //Camps and item stashes/quests can have a null parentfaction. makes sense.
                    if (checkForPassive) GenTerminal(spIV, map);
                    return;
                }
            }
            return;
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
            return !map.TileInfo.OnSurface && map.TileInfo.WaterCovered;//!map.IsStartingMap
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
