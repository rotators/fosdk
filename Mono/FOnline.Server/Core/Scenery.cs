using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOnline.Server
{
    public partial class Scenery : IManagedWrapper
    {
        readonly IntPtr thisptr;
        internal Scenery(IntPtr ptr)
        {
            thisptr = ptr;
            AddRef();
        }
        ~Scenery()
        {
            Release();
        }
        public static explicit operator IntPtr(Scenery self)
        {
            return self != null ? self.ThisPtr : IntPtr.Zero;
        }
        public static explicit operator Scenery(IntPtr ptr)
        {
            return ptr != IntPtr.Zero ? new Scenery (ptr) : null;
        }

        public IntPtr ThisPtr { get { return thisptr; } }
		public virtual void AddRef ()
		{
			AddRef (thisptr);
		}
		public virtual void Release()
		{
			Release (thisptr);
		}

        // called by engine
        static Scenery Create(IntPtr ptr)
        {
            return new Scenery(ptr);
        }
    }
}
