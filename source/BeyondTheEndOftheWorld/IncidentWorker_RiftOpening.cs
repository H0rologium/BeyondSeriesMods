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
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020DC File Offset: 0x000002DC
		protected virtual int CountToSpawn
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020F0 File Offset: 0x000002F0
		protected override bool CanFireNowSub(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			return map.listerThings.ThingsOfDef(DefDatabase<ThingDef>.GetNamed("RiftGeyser", true)).Count <= 0;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002130 File Offset: 0x00000330
		protected override bool TryExecuteWorker(IncidentParms parms)
		{
			Map map = (Map)parms.target;
			int num = 0;
			int countToSpawn = this.CountToSpawn;
			List<TargetInfo> list = new List<TargetInfo>();
			for (int i = 0; i < countToSpawn; i++)
			{
				IntVec3 intVec;
				bool flag = !CellFinderLoose.TryFindSkyfallerCell(ThingDefOf.CrashedShipPartIncoming, map, out intVec, 14, default(IntVec3), -1, false, false, false, false, false, false, null);
				if (flag)
				{
					break;
				}
				Building_SteamGeyser innerThing = (Building_SteamGeyser)ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("RiftGeyser", true), null);
				Skyfaller newThing = SkyfallerMaker.MakeSkyfaller(ThingDefOf.CrashedShipPartIncoming, innerThing);
				GenSpawn.Spawn(newThing, intVec, map, WipeMode.Vanish);
				num++;
				list.Add(new TargetInfo(intVec, map, false));
			}
			bool flag2 = num > 0;
			if (flag2)
			{
				base.SendStandardLetter(list, null, "A mysterious drop pod just crashed, quickly consumed by some sort of gap.\nWhaveter this space is, it is not safe to be near.", LetterDefOf.ThreatMedium);
			}
			return num > 0;
		}

		// Token: 0x02000004 RID: 4
		public class Hediff_QuantumContact : HediffWithComps
		{
		}
	}
}
