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
            Scribe_Values.Look(ref passiveMode, "passiveMode", false);
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
            lst.CheckboxLabeled("Enable passive mode", ref settings.passiveMode, "-Requires Reload-\n\nPassive mode will allow you to bypass raiding faction bases and adds generation of the structure to tiles that you settle on or set up camp on.\n\nNote that this WILL make obtaining these resources much easier, however spawning rules will still be random and require Fabrication to start\n\nENFORCEMENT RAIDS WILL STILL SPAWN IF YOU ATTEMPT TO DECRYPT THE ITEMS EARLY.");

            lst.End();
            base.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "Between the Stars";
        }
    }
}
