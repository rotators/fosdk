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
                ListWrapperTests.Crit_GetItems();
                ListWrapperTests.Crit_GetItemsByType();
                ListWrapperTests.Map_GetItemsHex();
                ListWrapperTests.Map_GetItemsHexEx();
                ListWrapperTests.Map_GetItemsByPid();
                ListWrapperTests.Map_GetItemsByType();
                ListWrapperTests.Global_MoveItemsCr();
                ListWrapperTests.Global_MoveItemsCont();
                ListWrapperTests.Global_MoveItemsMap();
                ListWrapperTests.Container_GetItems();
                ListWrapperTests.Global_DeleteItems();
                ListWrapperTests.Global_GetAllItems();
            };
            Console.WriteLine ("Hello World!");
        }
    }
}
