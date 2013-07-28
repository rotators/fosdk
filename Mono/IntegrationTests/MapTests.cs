using System;
using System.Linq;
using System.Collections.Generic;

using FOnline;

namespace IntegrationTests
{
    public static class MapTests
    {
        [Test]
        public static void Map_AddNpc()
        {
            Test.OnMap ("Map_AddNpcItems", map =>
            {
                var itemPids = new List<int> { 1, 2, 0, 2, 1, 0 };

                var cr = map.AddNpc (1, 0, 0, Direction.East, null, itemPids, null);

                var items = new List<Item> ();
                cr.GetItems (null, items);
                return items.Count == 3 && items.Count (i => i.ProtoId == 1) == 2 && items.Count (i => i.ProtoId == 2) == 1;
            });
            Test.OnMap ("Map_AddNpcParams", map =>
            {
                var @params = new List<int> { 1, 2, 3, 4 };

                var cr = map.AddNpc (1, 0, 0, Direction.East, @params, null, null);

                return cr.Param[1] == 2 && cr.Param[3] == 4;
            });
        }

        [Test]
        public static void GetLocations()
        {
            var old_count = Global.GetLocations (5, 5, 5, null);

            using(new Test.SpawnedLocations(new[]{
                Global.CreateLocation (Test.TestLoc, 1, 1, null),
                Global.CreateLocation (Test.TestLoc, 4, 4, null),
                Global.CreateLocation (Test.TestLoc, 100, 100, null)}))
            {
                var locs = new List<Location> ();
                var count = Global.GetLocations (5, 5, 5, locs);

                Test.Assert ("GetLocations", locs.Count == count && count == old_count + 2);
            }
        }
        /*public static void GetVisibleLocations()
        {
            Test.OnMap ("GetVisibleLocations", map =>
            {
                var cr = //Player 

                var old_count = Global.GetVisibleLocations (5, 5, 5, cr, null);

                using (new Test.SpawnedLocations(new[]{
                    Global.CreateLocation (Test.TestLoc, 1, 1, null),
                    Global.CreateLocation (Test.TestLoc, 4, 4, null),
                    Global.CreateLocation (Test.TestLoc, 100, 100, null)})) {
                    var locs = new List<Location> ();
                    var count = Global.GetVisibleLocations (5, 5, 5, cr, locs);

                    return locs.Count == count && count + 2 == old_count;
                }
            });
        }*/
        [Test]
        public static void MapProperties()
        {
            Test.OnMap ("Reading map id", map =>
            {
                Test.OnMap ("Reading map id", map2 =>
                {
                    return map2.Id == map.Id + 1;
                });
                return true;
            });
        }
    }
}

