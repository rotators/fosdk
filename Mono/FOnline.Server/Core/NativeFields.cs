using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace FOnline
{
    static class NativeFields
    {
        public static IntPtr GetIntPtr(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(IntPtr*)(ptr + offset);
            }
        }
        public static void SetIntPtr(IntPtr ptr, int offset, IntPtr value)
        {
            unsafe
            {
                *(IntPtr*)(ptr + offset) = value;
            }
        }
        public static bool GetBoolean(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(bool*)(ptr + offset);
            }
        }
        public static void SetBoolean(IntPtr ptr, int offset, bool value)
        {
            unsafe
            {
                *(bool*)(ptr + offset) = value;
            }
        }
        public static byte GetByte(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(byte*)(ptr + offset);
            }
        }
        public static void SetByte(IntPtr ptr, int offset, byte value)
        {
            unsafe
            {
                *(byte*)(ptr + offset) = value;
            }
        }
        public static sbyte GetSByte(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(sbyte*)(ptr + offset);
            }
        }
        public static void SetSByte(IntPtr ptr, int offset, sbyte value)
        {
            unsafe
            {
                *(sbyte*)(ptr + offset) = value;
            }
        }
        public static short GetInt16(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(short*)(ptr + offset);
            }
        }
        public static void SetInt16(IntPtr ptr, int offset, short value)
        {
            unsafe
            {
                *(short*)(ptr + offset) = value;
            }
        }
        public static int GetInt32(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(int*)(ptr + offset);
            }
        }
        public static void SetInt32(IntPtr ptr, int offset, int value)
        {
            unsafe
            {
                *(int*)(ptr + offset) = value;
            }
        }
        public static uint GetUInt32(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(uint*)(ptr + offset);
            }
        }
        public static void SetUInt32(IntPtr ptr, int offset, uint value)
        {
            unsafe
            {
                *(uint*)(ptr + offset) = value;
            }
        }

        public static ushort GetUInt16(IntPtr ptr, int offset)
        {
            unsafe
            {
                return *(ushort*)(ptr + offset);
            }
        }
        public static void SetUInt16(IntPtr ptr, int offset, ushort value)
        {
            unsafe
            {
                *(ushort*)(ptr + offset) = value;
            }
        }
    }
}
