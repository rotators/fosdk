using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOnline
{
    public partial class Location : IManagedWrapper
    {
        readonly IntPtr thisptr;
        internal Location(IntPtr ptr)
        {
            thisptr = ptr;
            AddRef();
        }
        ~Location()
        {
            Release();
        }

        public static explicit operator Location(IntPtr ptr)
        {
            return ptr != IntPtr.Zero ? new Location (ptr) : null;
        }
        public IntPtr ThisPtr { get { return thisptr; } }
        
        static Dictionary<uint, Location> locations = new Dictionary<uint, Location>();
        // called by engine
        static Location Create(IntPtr ptr)
        {
            var loc = new Location(ptr);
            locations[loc.Id] = loc;
            return loc;
        }
        static void Remove(Location loc)
        {
            locations.Remove(loc.Id);
        }
    }
}
