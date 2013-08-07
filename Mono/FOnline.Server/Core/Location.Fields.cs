using System;
using System.Runtime.CompilerServices;

namespace FOnline.Server
{
    public partial class Location
    {
        public virtual UInt32 Id { get { return GetId (thisptr); }}
        public virtual UInt16 WorldX { get { return GetWorldX (thisptr); } set { SetWorldX (thisptr, value); }}
        public virtual UInt16 WorldY { get { return GetWorldY (thisptr); } set { SetWorldY (thisptr, value); }}
        public virtual Boolean Visible { get { return GetVisible (thisptr); } set { SetVisible (thisptr, value); }}
        public virtual Boolean GeckVisible { get { return GetGeckVisible (thisptr); } set { SetGeckVisible (thisptr, value); }}
        public virtual Boolean AutoGarbage { get { return GetAutoGarbage (thisptr); } set { SetAutoGarbage (thisptr, value); }}
        public virtual Int32 GeckCount { get { return GetGeckCount (thisptr); } set { SetGeckCount (thisptr, value); }}
        public virtual UInt16 Radius { get { return GetRadius (thisptr); } set { SetRadius (thisptr, value); }}
        public virtual UInt32 Color { get { return GetColor (thisptr); } set { SetColor (thisptr, value); }}
        public virtual Boolean IsNotValid { get { return GetIsNotValid (thisptr); }}

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetId(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetWorldX(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetWorldY(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetVisible(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetGeckVisible(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetAutoGarbage(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static int GetGeckCount(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static ushort GetRadius(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static uint GetColor(IntPtr loc);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static bool GetIsNotValid(IntPtr loc);

        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetWorldX(IntPtr loc, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetWorldY(IntPtr loc, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetVisible(IntPtr loc, bool val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetGeckVisible(IntPtr loc, bool val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetAutoGarbage(IntPtr loc, bool val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetGeckCount(IntPtr loc, int val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetRadius(IntPtr loc, ushort val);
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static void SetColor(IntPtr loc, uint val);
	}
}
