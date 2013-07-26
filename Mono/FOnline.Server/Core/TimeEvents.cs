using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace FOnline
{
    public interface ITimeEvents
    {
        uint CreateTimeEvent(uint begin_second, string func_name, bool save);
        uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, bool save);
        uint CreateTimeEvent(uint begin_second, string func_name, uint value, bool save);
        uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, uint value, bool save);
        uint CreateTimeEvent(uint begin_second, string func_name, IList<uint> values, bool save);
        uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, IList<uint> values, bool save);
        uint CreateTimeEvent(uint begin_second, string func_name, IList<int> values, bool save);
        uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, IList<int> values, bool save);
        bool EraseTimeEvent(uint id);
        bool GetTimeEvent(uint id, out uint duration, IList<uint> values);
        bool GetTimeEvent(uint id, out uint duration, IList<int> values);
        bool SetTimeEvent(uint id, uint duration, IList<uint> values);
        bool SetTimeEvent(uint id, uint duration, IList<int> values);
    }
    public class TimeEvents : ITimeEvents
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_CreateTimeEventEmpty(uint begin_second, string func_name, bool save);
        public uint CreateTimeEvent(uint begin_second, string func_name, bool save)
        {
            if (func_name == null)
                throw new ArgumentNullException ("func_name");
            return Global_CreateTimeEventEmpty(begin_second, CoreUtils.ParseFuncName(func_name), save);
        }
        public uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, bool save)
        {
            var type = func.Method.DeclaringType;
            return Global_CreateTimeEventEmpty(begin_second, CoreUtils.ParseFuncName(type.FullName + "::" + func.Method.Name), save);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_CreateTimeEventValue(uint begin_second, string func_name, uint value, bool save);
        public uint CreateTimeEvent(uint begin_second, string func_name, uint value, bool save)
        {
            if (func_name == null)
                throw new ArgumentNullException ("func_name");
            return Global_CreateTimeEventValue(begin_second, CoreUtils.ParseFuncName(func_name), value, save);
        }
        public uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, uint value, bool save)
        {
            var type = func.Method.DeclaringType;
            return Global_CreateTimeEventValue(begin_second, CoreUtils.ParseFuncName(type.FullName + "::" + func.Method.Name), value, save);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint Global_CreateTimeEventValues(uint begin_second, string func_name, IList<uint> values, bool save);
        public uint CreateTimeEvent(uint begin_second, string func_name, IList<uint> values, bool save)
        {
            if (values == null)
                throw new ArgumentNullException ("values");
            return Global_CreateTimeEventValues(begin_second, CoreUtils.ParseFuncName(func_name), values, save);
        }
        public uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, IList<uint> values, bool save)
        {
            if (values == null)
                throw new ArgumentNullException ("values");
            var type = func.Method.DeclaringType;
            return Global_CreateTimeEventValues(begin_second, CoreUtils.ParseFuncName(type.FullName + "::" + func.Method.Name), values, save);
        }
        public uint CreateTimeEvent(uint begin_second, string func_name, IList<int> values, bool save)
        {
            if (values == null)
                throw new ArgumentNullException ("values");
            throw new NotImplementedException(); //return Global_CreateTimeEventValues(begin_second, CoreUtils.ParseFuncName(func_name).ThisPtr, values, save);
        }
        public uint CreateTimeEvent(uint begin_second, Func<IntPtr, uint> func, IList<int> values, bool save)
        {
            var type = func.Method.DeclaringType;
            throw new NotImplementedException (); //return Global_CreateTimeEventValues(begin_second, CoreUtils.ParseFuncName(type.FullName + "::" + func.Method.Name).ThisPtr, values, save);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool Global_EraseTimeEvent(uint id);
        public bool EraseTimeEvent(uint id)
        {
            return Global_EraseTimeEvent(id);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool Global_GetTimeEvent(uint id, out uint duration, IList<uint> values);
        public bool GetTimeEvent(uint id, out uint duration, IList<int> values)
        {
            throw new NotImplementedException (); //return Global_GetTimeEvent(id, out duration, values);
        }
        public bool GetTimeEvent(uint id, out uint duration, IList<uint> values)
        {
            return Global_GetTimeEvent(id, out duration, values);
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool Global_SetTimeEvent(uint id, uint duration, IntPtr values);
        public bool SetTimeEvent(uint id, uint duration, IList<int> values)
        {
            throw new NotImplementedException (); //return Global_GetTimeEvent(id, out duration, values);
        }
        public bool SetTimeEvent(uint id, uint duration, IList<uint> values)
        {
            return Global_GetTimeEvent(id, out duration, values);
        }
    }
}
