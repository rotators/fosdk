using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOnline.Server
{
    public partial class ProtoItem : IManagedWrapper
    {
        readonly IntPtr thisptr;
        internal ProtoItem(IntPtr ptr)
        {
            thisptr = ptr;
            AddRef();
        }
        ~ProtoItem()
        {
            Release();
        }

        public static explicit operator ProtoItem(IntPtr ptr)
        {
            return ptr != IntPtr.Zero ? new ProtoItem (ptr) : null;
        }

        public IntPtr ThisPtr { get { return thisptr; } }
		public virtual void AddRef()
		{
			AddRef (thisptr);
		}
		public virtual void Release()
		{
			Release (thisptr);
		}
    }
}
