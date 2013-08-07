using System;
using System.Runtime.CompilerServices;

namespace FOnline.Server
{
    public partial class Scenery
    {
        public virtual UInt16 ProtoId { get { return GetProtoId (thisptr); }}
        public virtual UInt16 HexX { get { return GetHexX (thisptr); }}
        public virtual UInt16 HexY { get { return GetHexY (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetProtoId(IntPtr ptr);

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetHexX(IntPtr ptr);

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetHexY(IntPtr ptr);
	}
}
