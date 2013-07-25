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
                Test.RunAllTests();
            };
            Console.WriteLine ("Hello World!");
        }
    }
}
