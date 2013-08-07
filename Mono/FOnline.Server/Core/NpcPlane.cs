using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOnline.Server
{
    public partial class NpcPlane : IManagedWrapper
    {
        IntPtr thisptr;

        public NpcPlane(IntPtr ptr)
        {
            thisptr = ptr;
            AddRef();
        }
        ~NpcPlane()
        {
            Release();
        }
		
        public IntPtr ThisPtr { get { return thisptr; } }

        public static explicit operator NpcPlane(IntPtr ptr)
        {
            return ptr != IntPtr.Zero ? new NpcPlane (ptr) : null;
        }

        // called by engine
        static NpcPlane Create(IntPtr ptr)
        {
            return new NpcPlane (ptr);
        }
    }
    public enum PlaneType
    {
        Misc = 0,
        Attack = 1,
        Walk = 2,
        Pick = 3,
        Patrol = 4, // WIP
        Courier = 5 // WIP
    }
    public static class Priorities
    {
        public const uint Misc = 10;
        public const uint Attack = 50;
        public const uint Walk = 20;
        public const uint Pick = 35;
        public const uint Patrol = 25;
        public const uint Courier = 30;
    }
}
