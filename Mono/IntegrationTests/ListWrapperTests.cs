using System;
using System.Linq;
using System.Collections.Generic;

using FOnline;

namespace IntegrationTests
{
    // I shouldn't test the behaviour of underlying engine functions here,
    // but many tests here do this - and they should only test whether MonoListWrapper worked correctly
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
        public static void Crit_GetItems()
        {
            Test.OnMap ("Crit_GetItems", map =>
            {
                var cr = Test.SpawnTestNpc(map, 1, 1);
                cr.AddItem (1, 1);
                cr.AddItem (2, 1);

                var items = new List<Item>();
                var count = cr.GetItems(null, items);

                return items.Count == count && count == 2;
            });
        }
        public static void Crit_GetItemsByType()
        {
            Test.OnMap ("Crit_GetItems", map =>
            {
                var cr = Test.SpawnTestNpc(map, 1, 1);
                cr.AddItem (1, 1);
                cr.AddItem (2, 1);

                var items = new List<Item>();
                var count = cr.GetItemsByType((ItemType)1, items);

                return items.Count == count && count == 1;
            });
        }
        public static void Map_GetItemsHex()
        {
            Test.OnMap ("Map_GetItemsHex", map =>
            {
                var it1 = map.AddItem (1, 1, 1, 1);
                var it2 = map.AddItem (1, 1, 2, 1);

                var items = new List<Item>();
                var count = map.GetItems (1, 1, items);

                return items.Count == count && count == 2 && items.Contains (it1) && items.Contains(it2);
            });
        }
        public static void Map_GetItemsHexEx()
        {
            Test.OnMap("Map_GetItemsHexEx", map =>
            {
                map.AddItem(5, 5, 1, 1);
                map.AddItem(4, 4, 1, 1);
                map.AddItem (5, 6, 2, 1);
                map.AddItem(3, 3, 2, 1);

                var items = new List<Item>();
                var count = map.GetItems(5, 5, 1, 1, items);

                return items.Count == count && count == 2 && (!items.Select(i => i.ProtoId).ToList().Contains(2));
            });
        }
        public static void Map_GetItemsByPid()
        {
            Test.OnMap("Map_GetItemsByPid", map =>
            {
                var rand = new Random();
                var allItems = 
                    Enumerable.Range(1, 10)
                        .Select(i => map.AddItem ((ushort)(rand.Next() % 100), (ushort)(rand.Next() % 100), (ushort)(rand.Next () % 2 + 1), 1))
                        .ToList();

                var items = new List<Item>();
                var count = map.GetItems(1, items);

                return items.Count == count && count == allItems.Count(i => i.ProtoId == 1);
            });
        }
        public static void Map_GetItemsByType()
        {
            Test.OnMap ("Map_GetItemsByType", map =>
            {
                var rand = new Random();
                var allItems =
                    Enumerable.Range(1, 10)
                    .Select(i => map.AddItem ((ushort)i, (ushort)i, (ushort)(rand.Next () % 2 + 1), 1))
                    .ToList();

                var items = new List<Item>();
                var count = map.GetItems(1, items);

                return count == items.Count && count == allItems.Count(i => i.Type == (ItemType)1);
            });
        }
        public static void Global_MoveItemsCr()
        {
            Test.OnMap ("Global_MoveItemsCr", map =>
            {
                var cr = Test.SpawnTestNpc(map, 0, 0);

                var items = new List<Item> { map.AddItem(1, 1, 1, 1), map.AddItem(2, 2, 2, 1) };
                Global.MoveItems (items, cr);
                var crItems = new List<Item>();
                cr.GetItems (null, crItems);

                return crItems.Count == 2 && crItems.Count(i => i.ProtoId == 1) == 1 && crItems.Count(i => i.ProtoId == 2) == 1;
            });
        }
        public static void Global_MoveItemsCont()
        {
            Test.OnMap ("Global_MoveItemsCont", map =>
            {
                var cont = Test.SpawnContainer(map, 0, 0);

                var items = new List<Item> { map.AddItem (1, 1, 1, 1), map.AddItem(2, 2, 2, 1) };
                Global.MoveItems (items, cont, 0);
                var contItems = new List<Item>();
                cont.GetItems (0, contItems);

                return contItems.Count == 2 && contItems.Count(i => i.ProtoId == 1) == 1 && contItems.Count(i => i.ProtoId == 2) == 1;
            });
        }
        public static void Global_MoveItemsMap()
        {
            Test.OnMap ("Global_MoveItemsMap", map =>
            {
                var cr = Test.SpawnTestNpc(map, 0, 0);
                var items = new List<Item> { cr.AddItem (1, 1), cr.AddItem(2, 1) };

                Global.MoveItems(items, map, 1, 1);
                var mapItems = new List<Item>();
                map.GetItems (1, 1, mapItems);

                return mapItems.Count == 2 && mapItems.Count(i => i.ProtoId == 1) == 1 && mapItems.Count(i => i.ProtoId == 2) == 1;
            });
        }
        public static void Container_GetItems()
        {
            Test.OnMap ("Container_GetItems", map =>
            {
                var cont = Test.SpawnContainer(map, 0, 0);
                var items = new List<Item> { cont.AddItem(1, 1, 0), cont.AddItem(2, 1, 0) };

                var contItems = new List<Item>();
                var count = cont.GetItems (0, contItems);

                return items.Count == count && contItems.Count(i => i.ProtoId == 1) == 1 && contItems.Count(i => i.ProtoId == 2) == 1;
            });
        }
        public static void Global_DeleteItems()
        {
            // TODO: how to detect deleted items?
            /*
            Test.OnMap ("Global_DeleteItems", map =>
            {
                var items = new List<Item> { map.AddItem (1, 1, 1, 1), map.AddItem (2, 2, 2, 1) };

                Global.DeleteItems (items);
                map.GetItems (0, null);

                return items.TrueForAll(i => i.IsNotValid);
            });*/
        }
        public static void Global_GetAllItems()
        {
            Test.OnMap ("Global_GetAllItems", map =>
            {
                var items = new List<Item>();
                var count = Global.GetAllItems(0, items);

                return count == items.Count && count > 0;
            });
        }
    }
}
