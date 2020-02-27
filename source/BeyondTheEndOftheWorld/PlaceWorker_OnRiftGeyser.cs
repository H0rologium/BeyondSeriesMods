// Decompiled with JetBrains decompiler
// Type: BeyondTheEndOftheWorld.PlaceWorker_OnRiftGeyser
// Assembly: BeyondTheEndOftheWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9E32187-6B99-46B5-AEB8-149D10156F48
// Assembly location: C:\Users\emurphy\git\BeyondTheEndOfTheWorld\beyondTheEndOfTheWorld\Assemblies\BeyondTheEndOftheWorld.dll

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
