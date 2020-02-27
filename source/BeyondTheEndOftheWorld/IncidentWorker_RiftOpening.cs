// Decompiled with JetBrains decompiler
// Type: BeyondTheEndOftheWorld.IncidentWorker_RiftOpening
// Assembly: BeyondTheEndOftheWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9E32187-6B99-46B5-AEB8-149D10156F48
// Assembly location: C:\Users\emurphy\git\BeyondTheEndOfTheWorld\beyondTheEndOfTheWorld\Assemblies\BeyondTheEndOftheWorld.dll

using RimWorld;
using System;
using System.Collections.Generic;
using Verse;

namespace BeyondTheEndOftheWorld
{
  public class IncidentWorker_RiftOpening : IncidentWorker
  {
    protected virtual int CountToSpawn
    {
      get
      {
        return 1;
      }
    }

    protected virtual bool CanFireNowSub(IncidentParms parms)
    {
      return ((ListerThings) ((Map) parms.target).listerThings).ThingsOfDef(DefDatabase<ThingDef>.GetNamed("RiftGeyser", true)).Count <= 0;
    }

    protected virtual bool TryExecuteWorker(IncidentParms parms)
    {
      Map target = (Map) parms.target;
      int num = 0;
      int countToSpawn = this.CountToSpawn;
      List<TargetInfo> targetInfoList = new List<TargetInfo>();
      IntVec3 intVec3;
      for (int index = 0; index < countToSpawn && CellFinderLoose.TryFindSkyfallerCell((ThingDef) ThingDefOf.CrashedShipPartIncoming, target, ref intVec3, 14, (IntVec3) null, -1, false, false, false, false, false, false, (Predicate<IntVec3>) null); ++index)
      {
        Building_CrashedShipPart buildingCrashedShipPart = (Building_CrashedShipPart) ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("RiftGeyser", true), (ThingDef) null);
        GenSpawn.Spawn((Thing) SkyfallerMaker.MakeSkyfaller((ThingDef) ThingDefOf.CrashedShipPartIncoming, (Thing) buildingCrashedShipPart), intVec3, target, (WipeMode) 0);
        ++num;
        targetInfoList.Add(new TargetInfo(intVec3, target, false));
      }
      if (num > 0)
        this.SendStandardLetter(LookTargets.op_Implicit(targetInfoList), (Faction) null, new string[0]);
      return num > 0;
    }

    public IncidentWorker_RiftOpening()
    {
      base.\u002Ector();
    }

    public class Hediff_QuantumContact : HediffWithComps
    {
      public Hediff_QuantumContact()
      {
        base.\u002Ector();
      }
    }
  }
}
