using System;
using System.Collections;
using System.Collections.Generic;

namespace FOnline
{
    /// <summary>
    /// Helpers for engine to be able to call IList implementations without hassle
    /// </summary>
    static class ListHelper
    {
        // called by engine
        static void Add(IList list, object o)
        {
            list.Add (o);
        }
        // called by engine
        static int GetSize(IList list)
        {
            return list.Count;
        }
        // called by engine
        static object Get(IList list, int idx)
        {
            return list[idx];
        }
        // called by engine
        static object Create(Type t)
        {
            var listType = typeof(List<>).MakeGenericType (t);
            return Activator.CreateInstance(listType);
        }
    }
}
