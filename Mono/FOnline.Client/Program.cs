using System;
using main = FOnline.Client.Main;

namespace FOnline.Server.Client
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Hello World!");
            main.Start += (_, e) => e.Fail ();
        }
    }
}
