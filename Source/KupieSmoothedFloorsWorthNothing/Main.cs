using RimWorld;
using Verse;
using System.Linq;
using System.Collections.Generic;
using System;


namespace KupieSmoothedFloorsWorthNothing
{
    [StaticConstructorOnStartup]
    public static class Main
    {
        static Main()
        {
            IList<string> defList = new List<string>();

            try
            {
                foreach (ThingDef thingDef in DefDatabase<ThingDef>.AllDefs.Where((ThingDef def) => def.building != null && def.building.isNaturalRock && !def.building.isResourceRock))
                {
                    string text = thingDef.defName + "_Smooth";
                    TerrainDef smooth = DefDatabase<TerrainDef>.GetNamed(text, false);
                    defList.Add(smooth.defName);
                    StatUtility.SetStatValueInList(ref smooth.statBases, StatDefOf.MarketValue, 0f);
                    smooth = null;
                }
                var defListString = string.Join<string>(", ", defList);
                Log.Message("[Smoothed Floors Worth Nothing] Set MarketValue of TerrainDefs to 0: " + defListString);
            }
            catch (Exception e)
            {
                Log.Error("[Smoothed Floors Worth Nothing] Error setting MarketValue to 0 on TerrainDefs: " + e.Message);
            }
        }
    }
}