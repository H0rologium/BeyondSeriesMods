using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace BetweenTheStars
{
    public class BTSModSettings : ModSettings
    {
        public bool passiveMode;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref passiveMode, "BTSpassiveMode", false);
            base.ExposeData();
        }
    }

    public class BetweenTheStars : Mod
    {
        BTSModSettings settings;

        public BetweenTheStars(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<BTSModSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard lst = new Listing_Standard();

            lst.Begin(inRect);
            lst.CheckboxLabeled("BTS_MS_PassiveMode".Translate(), ref settings.passiveMode, "BTS_MS_PassiveModeDescription".Translate());

            lst.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "Between the Stars";
        }
    }
}
