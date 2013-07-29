using System;
using System.Runtime.CompilerServices;

namespace FOnline
{
    public partial class ProtoItem
    {
        public virtual UInt16 ProtoId { get { return GetProtoId (thisptr); }}
        public virtual Int32 Type { get { return GetType (thisptr); }}
        public virtual ItemFlag Flags { get { return (ItemFlag)GetFlags (thisptr); }}
        public virtual Boolean Stackable { get { return GetStackable (thisptr); }}
        public virtual Boolean Deteriorable { get { return GetDeteriorable (thisptr); }}
        public virtual Byte Slot { get { return GetSlot (thisptr); }}
        public virtual UInt32 Weight { get { return GetWeight (thisptr); }}
        public virtual UInt32 Volume { get { return GetVolume (thisptr); }}
        public virtual UInt32 Cost { get { return GetCost (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetProtoId(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetType(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetFlags(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetStackable(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetDeteriorable(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static byte GetSlot(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetWeight(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetVolume(IntPtr ptr);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetCost(IntPtr ptr);
	}
}
