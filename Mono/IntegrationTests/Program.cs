using System;
using System.Linq;

using FOnline;

namespace IntegrationTests
{
    using main = FOnline.Main;

    class MainClass
    {
        public static void Main (string[] args)
        {
            main.Start += (o,e) =>
            {
               // TODO: iterate over types and functions marked as tests
               ListWrapperTests.Crit_GetCritters ();
            };
            Console.WriteLine ("Hello World!");
        }
    }
}
