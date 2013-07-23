using System;

using FOnline;

namespace IntegrationTests
{
    public static class Test
    {
        const int testLoc = 1001;

        public static void OnMap (string msg, Func<Map, bool> test)
        {
            var loc = Global.CreateLocation (testLoc, 1, 1, null);
            if(loc != 0)
            {
                try
                {
                    var map = Global.GetLocation(loc).GetMapByIndex(0);
                    var res = test(map);
                    if(res) Global.Log("{0} PASSED", msg);
                    else Global.Log("{0} FAILED", msg);
                } 
                catch(Exception ex)
                {
                    Global.Log("Exception caught: {0}.", ex.Message);
                }
                finally
                {
                    Global.DeleteLocation(loc);
                }
            }
            else
            {
                Global.Log("Unable to spawn test location");
            }
        }

        public static Critter SpawnTestNpc(Map map, int x, int y, Direction dir = Direction.NorthEast)
        {
            return map.AddNpc (1, (ushort)x, (ushort)y, dir, null, null, null);
        }

        public static Item SpawnContainer(Map map, int x, int y, int count = 1)
        {
            // we're gonna exploit the content of test.fopro - pid=type for first 13 entries
            return map.AddItem ((ushort)x, (ushort)y, (ushort)ItemType.Container, (uint)count);
        }
    }
}

