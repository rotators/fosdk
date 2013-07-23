using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace FOnline
{
    public interface IItemManager
    {
        Item FromNative(IntPtr ptr);
        Item GetItem(uint item_id);
        ProtoItem GetProtoItem (ushort pid);
        void MoveItem(Item item, uint count, Critter to_cr);
        void MoveItem(Item item, uint count, Item to_cont, uint stack_id);
        void MoveItem(Item item, uint count, Map to_map, ushort to_hx, ushort to_hy);
        void MoveItems(IList<Item> items, Critter to_cr);
        void MoveItems(IList<Item> items, Item to_cont, uint stack_id);
        void MoveItems(IList<Item> items, Map to_map, ushort to_hx, ushort to_hy);
        void DeleteItem(Item item);
        void DeleteItems(IList<Item> items);
        ulong WorldItemCount(ushort pid);
        uint GetAllItems(ushort pid, IList<Item> items);
    }
    public class ItemManager : IItemManager
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static Item Item_FromNative(IntPtr ptr);
        public Item FromNative(IntPtr ptr)
        {
            return Item_FromNative(ptr);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static IntPtr Global_GetItem(uint item_id);
        public Item GetItem(uint item_id)
        {
            return (Item)Global_GetItem(item_id);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static IntPtr Global_GetProtoItem(ushort pid);
        public ProtoItem GetProtoItem(ushort pid)
        {
            return (ProtoItem)Global_GetProtoItem(pid);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_MoveItemCr(IntPtr item, uint count, IntPtr to_cr);
        public void MoveItem(Item item, uint count, Critter to_cr)
        {
            Global_MoveItemCr(item.ThisPtr, count, to_cr.ThisPtr);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_MoveItemCont(IntPtr item, uint count, IntPtr to_cont, uint stack_id);
        public void MoveItem(Item item, uint count, Item to_cont, uint stack_id)
        {
            Global_MoveItemCont(item.ThisPtr, count, to_cont.ThisPtr, stack_id);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_MoveItemMap(IntPtr item, uint count, IntPtr to_map, ushort to_hx, ushort to_hy);
        public void MoveItem(Item item, uint count, Map to_map, ushort to_hx, ushort to_hy)
        {
            Global_MoveItemMap(item.ThisPtr, count, to_map.ThisPtr, to_hx, to_hy);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_MoveItemsCr(IList<Item> items, IntPtr to_cr);
        public void MoveItems(IList<Item> items, Critter to_cr)
        {
            if (items == null)
                throw new ArgumentNullException ("items");
            Global_MoveItemsCr(items, to_cr.ThisPtr);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_MoveItemsCont(IList<Item> items, IntPtr to_cont, uint stack_id);
        public void MoveItems(IList<Item> items, Item to_cont, uint stack_id)
        {
            if (items == null)
                throw new ArgumentNullException ("items");
            Global_MoveItemsCont(items, to_cont.ThisPtr, stack_id);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_MoveItemsMap(IList<Item> items, IntPtr to_map, ushort to_hx, ushort to_hy);
        public void MoveItems(IList<Item> items, Map to_map, ushort to_hx, ushort to_hy)
        {
            if (items == null)
                throw new ArgumentNullException ("items");
            Global_MoveItemsMap(items, to_map.ThisPtr, to_hx, to_hy);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_DeleteItem(IntPtr item);
        public void DeleteItem(Item item)
        {
            Global_DeleteItem(item.ThisPtr);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void Global_DeleteItems(IList<Item> items);
        public void DeleteItems(IList<Item> items)
        {
            if (items == null)
                throw new ArgumentNullException ("items");
            Global_DeleteItems(items);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ulong Global_WorldItemCount(ushort pid);
        public ulong WorldItemCount(ushort pid)
        {
            return Global_WorldItemCount(pid);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_GetAllItems(ushort pid, IList<Item> array);
        public uint GetAllItems(ushort pid, IList<Item> items)
        {
            return Global_GetAllItems(pid, items);
        }
    }
}
