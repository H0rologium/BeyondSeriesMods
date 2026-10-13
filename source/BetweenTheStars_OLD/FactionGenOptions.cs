using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace BetweenTheStars
{
    public class FactionGenOptions : DefModExtension
    {
        public List<PreceptDef> preceptsToAdd = new List<PreceptDef>();
        public IdeoIconDef customIdeoIcon;
        public ColorDef customIdeoColor;
        public string customIdeoDescription;
        public bool hasUniqueIdeo;
    }

}
