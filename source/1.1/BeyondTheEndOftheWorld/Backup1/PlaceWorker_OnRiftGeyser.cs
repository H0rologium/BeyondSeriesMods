// Decompiled with JetBrains decompiler
// Type: BeyondTheEndOftheWorld.PlaceWorker_OnRiftGeyser
// Assembly: BeyondTheEndOftheWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9E32187-6B99-46B5-AEB8-149D10156F48
// Assembly location: C:\Users\emurphy\git\BeyondTheEndOfTheWorld\beyondTheEndOfTheWorld\Assemblies\BeyondTheEndOftheWorld.dll

using Verse;

namespace BeyondTheEndOftheWorld
{
  public class PlaceWorker_OnRiftGeyser : PlaceWorker
  {
    public virtual AcceptanceReport AllowsPlacing(
      BuildableDef checkingDef,
      IntVec3 loc,
      Rot4 rot,
      Map map,
      Thing thingToIgnore = null)
    {
      Thing thing = ((ThingGrid) map.thingGrid).ThingAt(loc, DefDatabase<ThingDef>.GetNamed("RiftGeyser", true));
      return thing != null && !IntVec3.op_Inequality(thing.get_Position(), loc) ? AcceptanceReport.op_Implicit(true) : AcceptanceReport.op_Implicit(Translator.Translate("MustPlaceOnRiftGeyser"));
    }

    public virtual bool ForceAllowPlaceOver(BuildableDef otherDef)
    {
      return otherDef == DefDatabase<ThingDef>.GetNamed("RiftGeyser", true);
    }

    public PlaceWorker_OnRiftGeyser()
    {
      base.\u002Ector();
    }
  }
}
