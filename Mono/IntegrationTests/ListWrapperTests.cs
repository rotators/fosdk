using System;
using System.Linq;
using System.Collections.Generic;

using FOnline;

namespace IntegrationTests
{
    public static class ListWrapperTests
    {
        public static void Crit_GetCritters ()
        {
            Test.OnMap ("Crit_GetCritters", map =>
            {
                var allCrits = 
                    Enumerable.Range (1, 10)
                    .Select (i => map.AddNpc (1, (ushort)i, (ushort)i, Direction.East, null, null, null))
                    .ToList();
                var crits = new List<Critter> ();
                var count = allCrits[0].GetCritters (true, Find.All, crits);
                return crits.Count == count;
            });
        }
    }
}
