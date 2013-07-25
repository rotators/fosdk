using System;
using System.Linq;
using System.Collections.Generic;

using FOnline;
using System.Reflection;

namespace IntegrationTests
{
    public class TestAttribute : Attribute
    {
    }
    public static class Test
    {
        public const int TestLoc = 1001;

        public static void OnMap (string msg, Func<Map, bool> test)
        {
            var loc = Global.CreateLocation (TestLoc, 1, 1, null);
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

        public static void Assert(string msg, bool cond)
        {
            if(cond) Global.Log("{0} PASSED", msg);
            else Global.Log("{0} FAILED", msg);
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

        public class SpawnedLocations : IDisposable
        {
            IEnumerable<uint> ids;
            public SpawnedLocations(IEnumerable<uint> ids)
            {
                this.ids = ids;
            }

            public void Dispose()
            {
                foreach (var id in ids)
                    Global.DeleteLocation (id);
            }
        }

        public static void RunAllTests()
        {
            var tests = typeof(Test).Assembly
                .GetTypes ()
                .SelectMany (t => t.GetMethods ())
                .Where (m => m.CustomAttributes.Count(a => a.AttributeType == typeof(TestAttribute)) > 0);
            foreach (var test in tests)
                test.Invoke (null, null);
        }
    }
}

