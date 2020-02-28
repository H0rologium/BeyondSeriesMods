using Verse;

namespace BeyondTheEndOftheWorld
{
  public class PlaceWorker_OnRiftGeyser : PlaceWorker
	{// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public virtual AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map, Thing thingToIgnore = null)
		{
			Thing thing = map.thingGrid.ThingAt(loc, DefDatabase<ThingDef>.GetNamed("RiftGeyser", true));
			bool flag = thing == null || thing.Position != loc;
			AcceptanceReport result;
			if (flag)
			{
				result = Translator.Translate("MustPlaceOnRiftGeyser");
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020B0 File Offset: 0x000002B0
		public override bool ForceAllowPlaceOver(BuildableDef otherDef)
		{
			return otherDef == DefDatabase<ThingDef>.GetNamed("RiftGeyser", true);
		}
	}
}
