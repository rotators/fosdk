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
                    else Global.Log("{0} FAILED");
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
    }
}

